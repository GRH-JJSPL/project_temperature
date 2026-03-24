using S7.Net;
using S7.Net.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_temporature
{

    public partial class connect1 : Form
    {
        private string _sessionName;
        private PlcSession _session;
        public connect1()
        {
            InitializeComponent();
        }

        private void connect1_Load(object sender, EventArgs e)
        {
            txtDataType.Items.Add("Real");
            txtDataType.Items.Add("Int");
            txtDataType.Items.Add("DInt");
            txtDataType.Items.Add("String");
            txtDataType.Items.Add("Bool");
            //设置按钮使能
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnWrtData.Enabled = false;
            btnReadData.Enabled = false;
            label9.Text = $"当前用户:" + GlobalAuth.CurrentRole.RoleName + "——" + GlobalAuth.CurrentUser.UserName;

        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {   //连接PLC
            try
            {
                if (string.IsNullOrEmpty(txtIPAddress.Text))
                {
                    MessageBox.Show("请输入IP地址！");
                    return;
                }
                //生成PLC站的名字，作为主键
                _sessionName = txtIPAddress.Text + "_" + sessionName.Text;
                _session = new PlcSession(_sessionName,CpuType.S71500, txtIPAddress.Text,
                                            Int16.Parse(txtRack.Text), Int16.Parse(txtSlot.Text));
                //尝试连接
                await _session.connectAsync();
                if (_session.PlcInstance.IsConnected)
                {
                    SessionManager.Add(_session);
                    statuslabel.Text = $"已连接到Plc：{txtIPAddress.Text} {_sessionName}";
                    LogControl.WriteMessage($"已连接到Plc：{txtIPAddress.Text}——{_sessionName}");
                    if (_session.PlcInstance.IsConnected)
                    {
                        if (GlobalAuth.CurrentRole.Level == 3 || GlobalAuth.CurrentRole.Level == 2)
                        {
                            btnConnect.Enabled = false;
                            btnDisconnect.Enabled = true;
                            btnWrtData.Enabled = true;
                            btnReadData.Enabled = true;
                        }
                        else if (GlobalAuth.CurrentRole.Level == 1)
                        {
                            btnConnect.Enabled = false;
                            btnDisconnect.Enabled = true;
                            btnWrtData.Enabled = false;
                            btnReadData.Enabled = false;
                        }
                    }

                    this.Text = $"PLC连接{_sessionName}";
                }
            }
            catch (Exception ex)
            {
                LogControl.WriteMessage($"连接Plc{txtIPAddress.Text}——{_sessionName}失败：{ex.Message}");
                MessageBox.Show($"连接失败：{ex.Message}");
                _session = null;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (_session!=null && _session.IsConnected)
            {
                SessionManager.Remove(_sessionName);
                _session = null;
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                btnWrtData.Enabled = false;
                btnReadData.Enabled = false;
                LogControl.WriteMessage($"已断开PLC{txtIPAddress.Text}——{_sessionName}连接");
                statuslabel.Text = "PLC连接已断开";
                this.Text = "PLC未连接";
            }
        }
        //==============================读取数据============================================
        private async void btnReadData_Click(object sender, EventArgs e)
        {
            int DBNum = int.Parse(txtDBNum.Text);
            int startByte = int.Parse(txtstartByte.Text);
            byte[] Buffer = new byte[256];
            if (!_session.IsConnected)
            {
                LogControl.WriteMessage("PLC未连接，请连接PLC");
                MessageBox.Show("Plc未连接！");
                return;
            }
            try
            {   //读取数据
                if (txtDataType.Text == "Real")
                {
                    Buffer = await Task.Run(() => _session.PlcInstance.ReadBytes(DataType.DataBlock, DBNum, startByte, 4));
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(Buffer);
                    float val = BitConverter.ToSingle(Buffer, 0);
                    MessageBox.Show(Convert.ToString(val));
                    LogControl.WriteMessage($"{txtIPAddress.Text}——{_sessionName}数据：DB{DBNum}.DBB{startByte}为 {val}");

                }
                else if (txtDataType.Text == "Int")
                {
                    Buffer = await Task.Run(() => _session.PlcInstance.ReadBytes(DataType.DataBlock, DBNum, startByte, 2));
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(Buffer);
                    short val = BitConverter.ToInt16(Buffer);
                    MessageBox.Show(Convert.ToString(val));
                    LogControl.WriteMessage($"{txtIPAddress.Text}——{_sessionName}数据：DB{DBNum}.DBB{startByte}为 {val}");
                }
                else if (txtDataType.Text == "DInt")
                {
                    Buffer = await Task.Run(() => _session.PlcInstance.ReadBytes(DataType.DataBlock, DBNum, startByte, 4));
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(Buffer);
                    int val = BitConverter.ToInt32(Buffer);
                    MessageBox.Show(Convert.ToString(val));
                    LogControl.WriteMessage($"{txtIPAddress.Text}——{_sessionName}数据：DB{DBNum}.DBB{startByte}为 {val}");
                }
                else if (txtDataType.Text == "String")
                {
                    Buffer = await Task.Run(() => _session.PlcInstance.ReadBytes(DataType.DataBlock, DBNum, startByte, 256));
                    byte actualLen = Buffer[1];
                    if (actualLen > 0 && actualLen <= Buffer.Length - 2)
                    {
                        string val = Encoding.ASCII.GetString(Buffer, 2, actualLen);
                        MessageBox.Show(val);
                        LogControl.WriteMessage($"{txtIPAddress.Text}——{_sessionName}数据：DB{DBNum}.DBB{startByte}为 {val}");
                    }
                    else
                        MessageBox.Show("字符串为空或者长度异常");

                }
                /*    ReadBit方法用不了，先不搞
                 else if (txtDataType.Text == "Bool")
                {
                    Buffer = await Task.Run(()=>_session.PlcInstance.ReadBytes(DataType.DataBlock,DBNum,startByte,1));

                }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show($"读取数据失败：{ex.Message}");
                LogControl.WriteMessage($"读取Plc{txtIPAddress.Text}——{_sessionName}数据失败：{ex.Message}");

            }
        }
        //===============================写入数据===========================================
        private async void btnWrtData_Click(object sender, EventArgs e)
        {
            byte[] Buffer = new byte[65536];
            int DBNum = int.Parse(txtDBNum.Text);
            int startByte = int.Parse(txtstartByte.Text);
            string Val = txtVal.Text.Trim();
            try
            {
                if (txtDataType.Text == "Real")
                {
                    float val = float.Parse(Val);
                    Buffer = BitConverter.GetBytes(val);
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(Buffer);
                    await Task.Run(() => _session.PlcInstance.WriteBytes(DataType.DataBlock, DBNum, startByte, Buffer));
                    MessageBox.Show("写入数据成功");
                    LogControl.WriteMessage($"向{txtIPAddress.Text}——{_sessionName}写入数据：DB{DBNum}.DBB{startByte}为 {val}");
                }
                else if (txtDataType.Text == "Int")
                {
                    short val = Int16.Parse(Val);
                    Buffer = BitConverter.GetBytes(val);
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(Buffer);
                    await Task.Run(() => _session.PlcInstance.WriteBytes(DataType.DataBlock, DBNum, startByte, Buffer));
                    MessageBox.Show("写入数据成功");
                    LogControl.WriteMessage($"向{txtIPAddress.Text}——{_sessionName}写入数据：DB{DBNum}.DBB{startByte}为 {val}");
                }
                else if (txtDataType.Text == "DInt")
                {
                    int val = int.Parse(Val);
                    Buffer = BitConverter.GetBytes(val);
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(Buffer);
                    await Task.Run(() => _session.PlcInstance.WriteBytes(DataType.DataBlock, DBNum, startByte, Buffer));
                    MessageBox.Show("写入数据成功");
                    LogControl.WriteMessage($"向{txtIPAddress.Text}——{_sessionName}写入数据：DB{DBNum}.DBB{startByte}为 {val}");
                }
                else if (txtDataType.Text == "String")
                {
                    int maxlen = 254;
                    string str = Val;
                    if (str.Length > maxlen)
                        str = str.Substring(0, maxlen);
                    byte[] buffer = new byte[str.Length + 2];
                    buffer[0] = (byte)maxlen;       //最大长度
                    buffer[1] = (byte)str.Length;       //实际长度
                    Encoding.ASCII.GetBytes(str, 0, str.Length, buffer, 2);
                    await Task.Run(() => _session.PlcInstance.WriteBytes(DataType.DataBlock, DBNum, startByte, buffer));
                    MessageBox.Show("写入数据成功");
                    LogControl.WriteMessage($"向{txtIPAddress.Text}——{_sessionName}写入数据：DB{DBNum}.DBB{startByte}为 {str}");
                }
                /*
                 *此处注释出写Bool功能代码。
                 *
                 */

            }
            catch (Exception ex)
            {
                MessageBox.Show($"写入数据失败；{ex.Message}");
                LogControl.WriteMessage($"向{txtIPAddress.Text}——{_sessionName}写入数据失败");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainWindow = new MainForm(_session);
            mainWindow.Show();
        }
    }

   
}
