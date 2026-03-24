using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using S7.Net;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;      //这个要自己安装库，画图用的

namespace project_temporature
{
    public partial class CurrentTempForm : Form
    {
        //声明Temperature类的实例
        private PlcSession _session;
        private TemperatureData temperatureData;
        //创建连接SQL的关键字符串
        private string connectionString = "Server=127.0.0.1;Port=3306;Database=temperature_db;Uid=J****L;Pwd=********51@qqCoM;";
        //数据采集状态标志，true表示正在采集
        private bool isCollecting = false;
        //记录开始时间
        private DateTime startTime = DateTime.Now;
        //四个温度区在DB1中的字节偏移量
        private int[] temperatureOffSets = { 0, 2, 4, 6 };
        public CurrentTempForm(PlcSession session)
        {
            InitializeComponent();      //初始化窗体控件
            _session = session;
            temperatureData = _session.TemperatureData;
        }

        private void CurrentTempForm_Load(object sender, EventArgs e)
        {
            if (!_session.PlcInstance.IsConnected)
            {
                statuslabel.Text = "PLC已断开连接，请重新连接!";
                MessageBox.Show("PLC已断开连接，请重新连接!");
                label12.Text = $@"当前用户:" + GlobalAuth.CurrentRole.RoleName + "——" + 
                                    GlobalAuth.CurrentUser.UserName + "——" + _session.Name;
                return;
            }
            else
            {
                statuslabel.Text = "已连接到目标PLC！";
            }
            //初始化MySQL数据库
            InitializeDataBase();
            //读取并显示当前温度
            ReadAndDisplayCurrentTemperatures();
        }

        private async void btnTemp_Click(object sender, EventArgs e)
        {
            //启动定时器
            tempTimer.Start();
            isCollecting = true;
        }

        private void btnGraphy_Click(object sender, EventArgs e)
        {       //实时曲线按钮
            RealTimeChartForm realTimeChartForm = new RealTimeChartForm(_session);   //将实例传过去
            realTimeChartForm.Show();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //停止获取当前温度
            tempTimer.Stop();
            isCollecting = false;
        }
        //定时器逻辑
        private async void tempTimer_Tick(object sender, EventArgs e)
        {
            await ReadAndStoreTemperature();
        }
        //===============================初始化数据库=================================
        private void InitializeDataBase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();      //建立网络连接TCP的三次握手
                    string createDbQuery = "CREATE DATABASE IF NOT EXISTS temperature_db";
                    using (MySqlCommand cmd = new MySqlCommand(createDbQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    connection.ChangeDatabase("temperature_db");
                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS temperature_data(
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            timestamp DATETIME,
                            zone1_temp INT,
                            zone2_temp INT,
                            zone3_temp INT,
                            zone4_temp INT
                    )";
                    using (MySqlCommand cmd = new MySqlCommand(createTableQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化数据库失败:{ex.Message}");
            }
        }
        //======================读取并存储到SQL里面================================
        private async Task ReadAndStoreTemperature()
        {
            if (!_session.PlcInstance.IsConnected)
            {
                MessageBox.Show("PLC未连接，请连接PLC！");
                statuslabel.Text = "未连接到PLC！";
                return;
            }
            try
            {
                int[] temperatures = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    byte[] buffer = await Task.Run(() =>
                    _session.PlcInstance.ReadBytes(DataType.DataBlock, 1, temperatureOffSets[i], 2));
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(buffer);
                    }
                    temperatures[i] = BitConverter.ToInt16(buffer);
                }
                //写入到类实例的双端列表
                double elapsedSeconds = (DateTime.Now - startTime).TotalSeconds;        //TotalSecond作用是，转换成秒数
                temperatureData.AddData(elapsedSeconds, temperatures);      //将两个双端列表写入实例中
                await UpdateTemperatureDisplay(temperatures);
                await SaveDataBase(temperatures);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"读取温度失败：{ex.Message}");
            }
        }

        //=======================读取并显示当前温度(一次性)===============================
        private async Task ReadAndDisplayCurrentTemperatures()
        {
            if (!_session.PlcInstance.IsConnected)
            {
                MessageBox.Show("PLC未连接，请连接PLC！");
                statuslabel.Text = "未连接到PLC！";
                return;
            }
            try
            {
                int[] temperatures=new int[4];
                for (int i = 0; i < 4; i++)
                {
                    byte[] buffer = await Task.Run(() =>
                    _session.PlcInstance.ReadBytes(DataType.DataBlock, 1, temperatureOffSets[i], 2));
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(buffer);
                    }
                    temperatures[i] = BitConverter.ToInt16(buffer, 0);
                    await UpdateTemperatureDisplay(temperatures);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"读取温度失败：{ex.Message}");
            }
        }

        //============================更新所有温度值显示================================
        // 更新所有温度显示
        private async Task UpdateTemperatureDisplay(int[] temperatures)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBox1.Text = temperatures[0].ToString();
                textBox2.Text = temperatures[1].ToString();
                textBox3.Text = temperatures[2].ToString();
                textBox4.Text = temperatures[3].ToString();
                TextBox[] boxe = { textBox1,textBox2, textBox3, textBox4 };
                for (int i = 0; i < 4; i++)
                {
                    int alarm = temperatureData.CheckAlarm(i, temperatures[i]);
                    if (alarm == 1)
                    {
                        boxe[i].BackColor = Color.Red;
                        boxe[i].ForeColor = Color.White;
                        LogControl.WriteMessage($"PLC{_session.Name}区域{i+1}超温");
                    }
                    else
                    {
                        // 温度正常时恢复原色
                        boxe[i].BackColor = SystemColors.Window;
                        boxe[i].ForeColor = SystemColors.WindowText;
                    }
                }
            });

        }
        //===========================将数据保存到数据库===========================
        private async Task SaveDataBase(int[] temperatures)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    connection.ChangeDatabase("temperature_db");
                    string insertQuery = @"
                        INSERT INTO temperature_data 
                        (timestamp,zone1_temp,zone2_temp,zone3_temp,zone4_temp)
                        VALUES(NOW(),@zone1,@zone2,@zone3,@zone4)
                    ";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@zone1", temperatures[0]);
                        cmd.Parameters.AddWithValue("@zone2", temperatures[1]);
                        cmd.Parameters.AddWithValue("@zone3", temperatures[2]);
                        cmd.Parameters.AddWithValue("@zone4", temperatures[3]);
                        cmd.ExecuteNonQuery();      //执行sql非查询语句，前面的只是将占位符和具体值绑定了，在这里才算执行完毕
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"插入数据失败：{ex.Message}");
            }
        }

        private void CurrentTempForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tempTimer?.Stop();
        }
    }
    
}
