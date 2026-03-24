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
    public partial class PLCCollection : Form
    {
        public PLCCollection()
        {
            InitializeComponent();
        }
        private  void PLCCollection_Load(object sender, EventArgs e)
        {
            PLCLoad();
        }

        //=======================初始化列表=========================
        private void PLCLoad()
        {
            PLCData.Columns.Clear();
            PLCData.Rows.Clear();
            PLCData.Columns.Add("PLCName1", "PLC名称");
            PLCData.Columns.Add("PLC_IP", "IP地址");
            PLCData.Columns.Add("CpuType", "Cpu型号");
            PLCData.Columns.Add("PLCStatus", "连接状态");
            foreach (var val in SessionManager._sessions.Values)
            {
                PLCData.Rows.Add(val.Name, val.PlcInstance.IP, val.PlcInstance.CPU, val.IsConnected);
            }
        }


    }
}
