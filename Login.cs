using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;       //引入集合命名空间，Dictionary依赖这个



namespace project_temporature
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(pwd))
            {   //string.IsNullOrEmpty(参数)是一个属于string静态类的一个参数
                MessageBox.Show("请输入账号或密码！！！");
                return;
            }
            if (GlobalAuth.Login(account, pwd))
            {
                MessageBox.Show($"登陆成功！\n账号：{account}\n身份：{GlobalAuth.CurrentRole.RoleName}\n欢迎回来");
                LogControl.WriteMessage($"登陆成功！\n账号：{account}\n身份：{GlobalAuth.CurrentRole.RoleName}\n欢迎回来");
                this.DialogResult = DialogResult.OK;        //告诉调用者登陆成功
                this.Close();
            }
            else
            {   if (GlobalAuth.UserDict.ContainsKey(account))
                {
                    MessageBox.Show("密码错误！请重新输入");
                }
                else
                {
                    MessageBox.Show("账号不存在，请重新输入");
                }
            }
        }

            
    }
    
   
}
