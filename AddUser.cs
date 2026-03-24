using Google.Protobuf.WellKnownTypes;
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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }
        private void AddUser_Load(object sender, EventArgs e)
        {
            label4.Text = $"当前用户:" + GlobalAuth.CurrentRole.RoleName + "——" + GlobalAuth.CurrentUser.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GlobalAuth.AddUserWay(txtUserName.Text.Trim(), txtPwd.Text.Trim(), txtRoleName.Text.Trim()))
            {
                MessageBox.Show("添加用户成功！");
                LogControl.WriteMessage($@"{GlobalAuth.CurrentRole.RoleName} {GlobalAuth.CurrentUser.UserName}
                                                添加用户{txtRoleName.Text.Trim()} {txtUserName.Text.Trim()}成功");
                this.Close();
                return;
            }
        }


    }
}
