using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_temporature
{
    public partial class Temp_Form : Form
    {
        private PlcSession _session;
        public Temp_Form(PlcSession session)
        {
            InitializeComponent();
            _session = session;
        }

        private async void Temp_Form_Load(object sender, EventArgs e)
        {
            label11.Text = $"当前用户:" + GlobalAuth.CurrentRole.RoleName + "——" + GlobalAuth.CurrentUser.UserName + "——" + _session.Name;
            UpdataControlStates();      //更新控件的状态方法，自定义的
            if (_session.PlcInstance.IsConnected)
            {
                Tem_status.Text = "已连接到目标PLC！";
                await ReadCurrentTemperatures();    //异步读取当前的温度
            }
            else
            {
                Tem_status.Text = "连接PLC失败，请重新连接PLC!";
            }

        }
        //一个初始化控件属性Enabled的方法
        private void UpdataControlStates()
        {
            bool isConnected = _session.PlcInstance.IsConnected;
            if (isConnected)
            {
                btnSet.Enabled = isConnected;
                txtSetTemp1.Enabled = isConnected;
                txtSetTemp2.Enabled = isConnected;
                txtSetTemp3.Enabled = isConnected;
                txtSetTemp4.Enabled = isConnected;
            }
        }
        //异步读取当前温度阈值，并且显示在屏幕上
        private async Task ReadCurrentTemperatures()
        {
            if (!_session.PlcInstance.IsConnected)
            {
                MessageBox.Show("PLC未连接");
                Tem_status.Text = "Plc已断开连接！";
                return;
            }
            int dbNum = 1;
            int zone1OffSet = 8;
            int zone2OffSet = 10;
            int zone3OffSet = 12;
            int zone4OffSet = 14;
            try
            {
                //异步读取四个区域温度阈值
                byte[] buffer1 = await Task.Run(() =>
                                        _session.PlcInstance.ReadBytes(S7.Net.DataType.DataBlock, dbNum, zone1OffSet, 2));
                byte[] buffer2 = await Task.Run(() =>
                                        _session.PlcInstance.ReadBytes(S7.Net.DataType.DataBlock, dbNum, zone2OffSet, 2));
                byte[] buffer3 = await Task.Run(() =>
                                        _session.PlcInstance.ReadBytes(S7.Net.DataType.DataBlock, dbNum, zone3OffSet, 2));
                byte[] buffer4 = await Task.Run(() =>
                                        _session.PlcInstance.ReadBytes(S7.Net.DataType.DataBlock, dbNum, zone4OffSet, 2));
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(buffer1);
                    Array.Reverse(buffer2);
                    Array.Reverse(buffer3);
                    Array.Reverse(buffer4);
                }
                short temp1 = BitConverter.ToInt16(buffer1);
                short temp2 = BitConverter.ToInt16(buffer2);
                short temp3 = BitConverter.ToInt16(buffer3);
                short temp4 = BitConverter.ToInt16(buffer4);
                //在ui控件上显示此文本
                this.Invoke((MethodInvoker)delegate
                {
                    txtCurrentTemp1.Text = temp1.ToString();
                    txtCurrentTemp2.Text = temp2.ToString();
                    txtCurrentTemp3.Text = temp3.ToString();
                    txtCurrentTemp4.Text = temp4.ToString();
                    _session.TemperatureData.Thresholds[0] = temp1;
                    _session.TemperatureData.Thresholds[1] = temp2;
                    _session.TemperatureData.Thresholds[2] = temp3;
                    _session.TemperatureData.Thresholds[3] = temp4;
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show($"读取数据失败：{ex.Message}");
            }
        }

        private async void btnSet_Click(object sender, EventArgs e)
        {
            if (!_session.PlcInstance.IsConnected)
            {
                MessageBox.Show("PLC未连接");
                Tem_status.Text = "PLC已断开连接";
                return;
            }
            int dbNum = 1;
            int zone1OffSet = 8;
            int zone2OffSet = 10;
            int zone3OffSet = 12;
            int zone4OffSet = 14;
            try
            {
                if (!short.TryParse(txtSetTemp1.Text, out short value1))
                {       //如果TryParse转换成功，则转换后的值赋给value，同时，不执行if内部语句，如果转换失败，则执行
                    MessageBox.Show("一区目标温度阈值设置值错误，请输入整数！");
                    return;
                }
                if (!short.TryParse(txtSetTemp2.Text, out short value2))
                {
                    MessageBox.Show("二区目标温度阈值设置错误，请输入整数！");
                    return;
                }
                if (!short.TryParse(txtSetTemp3.Text, out short value3))
                {
                    MessageBox.Show("三区目标温度阈值设置错误，请输入整数！");
                    return;
                }
                if (!short.TryParse(txtSetTemp4.Text, out short value4))
                {
                    MessageBox.Show("四区目标温度阈值设置错误，请输入整数！");
                    return;
                }
                byte[] buffer1 = BitConverter.GetBytes(value1);
                byte[] buffer2 = BitConverter.GetBytes(value2);
                byte[] buffer3 = BitConverter.GetBytes(value3);
                byte[] buffer4 = BitConverter.GetBytes(value4);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(buffer1);
                    Array.Reverse(buffer2);
                    Array.Reverse(buffer3);
                    Array.Reverse(buffer4);
                }
                await Task.Run(() =>
                            {
                                _session.PlcInstance.WriteBytes(S7.Net.DataType.DataBlock, dbNum, zone1OffSet, buffer1);
                                _session.PlcInstance.WriteBytes(S7.Net.DataType.DataBlock, dbNum, zone2OffSet, buffer2);
                                _session.PlcInstance.WriteBytes(S7.Net.DataType.DataBlock, dbNum, zone3OffSet, buffer3);
                                _session.PlcInstance.WriteBytes(S7.Net.DataType.DataBlock, dbNum, zone4OffSet, buffer4);
                            });
                await ReadCurrentTemperatures();
                MessageBox.Show("目标区域温度阈值写入PLC完成");
                LogControl.WriteMessage($"{GlobalAuth.CurrentRole.RoleName} {GlobalAuth.CurrentUser.UserName}修改温度阈值成功");

            }
            catch (Exception ex)
            {
                LogControl.WriteMessage($@"{GlobalAuth.CurrentRole.RoleName} {GlobalAuth.CurrentUser.UserName}
                                            修改温度阈值失败{ex.Message}");
                MessageBox.Show($"写入数据失败：{ex.Message}");
            }
        }
    }
}
