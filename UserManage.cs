using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI;
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
    public partial class UserManage : Form
    {
        private PlcSession _session;
        public UserManage(PlcSession session)
        {
            InitializeComponent();
            _session = session;

        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            label4.Text = $"当前用户:" + GlobalAuth.CurrentRole.RoleName + "——" + GlobalAuth.CurrentUser.UserName + "——" + _session.Name;

            UserLoad();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var Form=new AddUser())
            {
                Form.ShowDialog();
            }
            this.Show();
            UserLoad();
        }

        private void btnDelUser_Click(object sender, EventArgs e)
        {
            if (GlobalAuth.RemoveUserWay(txtRemoveName.Text))
                LogControl.WriteMessage($@"{GlobalAuth.CurrentRole.RoleName} {GlobalAuth.CurrentUser.UserName}
                                                                    已移除用户{txtRemoveName.Text}");
            UserLoad();

        }
        //===================================初始化列表==================================
        private void UserLoad()
        {
            UserList.Rows.Clear();      //清除原本的行数据
            UserList.Columns.Clear();   //清除原本的列数据，包括表头
            UserList.Columns.Add("UserName", "用户名");        //添加列，列名为“用户名”，标识符为UserName.
            UserList.Columns.Add("RoleName","角色");
            UserList.Columns.Add("Pwd","密码");
            foreach (var user in GlobalAuth.UserDict.Values)
            {
                UserList.Rows.Add(user.UserName,user.RoleName,user.Pwd);
            }
        }
    }
}
