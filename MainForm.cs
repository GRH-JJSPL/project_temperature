using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms.Design;

namespace project_temporature
{
    public partial class MainForm : Form
    {
        private PlcSession _session;
        public MainForm(PlcSession session)
        {
            InitializeComponent();
            _session = session;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            label4.Text = $"当前用户:" + GlobalAuth.CurrentRole.RoleName + "——" + GlobalAuth.CurrentUser.UserName + "——" + _session.Name;
            if (GlobalAuth.CurrentRole.Level == 3)
            {
                btnUser.Enabled = true;
                btnLog.Enabled = true;
                btnTempSet.Enabled = true;
                btnCurrentTemp.Enabled = true;
            }
            if (GlobalAuth.CurrentRole.Level == 2)
            {
                btnUser.Enabled = false;
                btnLog.Enabled = true;
                btnTempSet.Enabled = true;
                btnCurrentTemp.Enabled = true;
            }
            if (GlobalAuth.CurrentRole.Level == 1)
            {
                btnUser.Enabled = false;
                btnLog.Enabled = false;
                btnTempSet.Enabled = false;
                btnCurrentTemp.Enabled = true;
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {   //打开用户管理窗口
            UserManage Form = new UserManage(_session);
                Form.Show();
            
        }

        private void btnTempSet_Click(object sender, EventArgs e)
        {   //打开温度阈值设置窗口
            Temp_Form form = new Temp_Form(_session);
                form.Show();
            

        }

        private void btnCurrentTemp_Click(object sender, EventArgs e)
        {   //查看当前温度，实时曲线图
            CurrentTempForm form = new CurrentTempForm(_session);
                form.Show();
            
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            LogControl.WriteMessage("初始化");
            LogControl.WriteMessage($"{GlobalAuth.CurrentRole.RoleName} {GlobalAuth.CurrentUser.UserName}打开日志！");
            LogControl.OpenLog();
        }


    }
}
