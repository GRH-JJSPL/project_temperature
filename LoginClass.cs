using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_temporature
{
    internal class LoginClass
    {
    }
    public partial class Login : Form
    {
    }
    //=================================角色类========================================================================
    public class Role
    {
        public string RoleName { get; set; }
        public int Level { get; set; } //3:管理员   2：操作员    1：访客
    }
    //==================================================用户类==================================================
    public class User
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string RoleName { get; set; }
    }
    //====================================全局认证类，用于设置其他ui的控件enabled==========================
    public static class GlobalAuth
    {
        public static Role CurrentRole { get; set; }        //当前登录的用户
        public static User CurrentUser { get; set; }
        //角色库
        public static Dictionary<string, Role> RoleDict = new Dictionary<string, Role>
        {
            { "管理员",new Role{RoleName="管理员",Level=3} },
            { "操作员",new Role{ RoleName="操作员",Level=2} },
            { "访客",new Role{ RoleName="访客",Level=1} }
        };
        //用户库
        public static Dictionary<string, User> UserDict = new Dictionary<string, User>
        {
            { "李明",new User{ UserName="李明",Pwd="123456",RoleName="管理员"} },
            { "张三",new User{UserName="张三",Pwd="12345",RoleName="操作员"} },
            {"王五",new User{ UserName="王五",Pwd="1234",RoleName="访客"} }
        };
        //===========登录方法==========
        public static bool Login(string userName, string pwd)
        {
            if (!UserDict.ContainsKey(userName))
                return false;
            User user = UserDict[userName];
            if (user.Pwd != pwd)
                return false;
            CurrentUser = user;
            CurrentRole = RoleDict[user.RoleName];
            return true;
        }
        //===============登出方法============
        public static void Logout()
        {
            CurrentUser = null;
            CurrentRole = null;
        }
        //===============添加用户的方法=============
        public static bool AddUserWay(string username, string pwd, string rolename)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("账号或密码为空！");
                return false;
            }
            if (UserDict.ContainsKey(username))
            {
                MessageBox.Show("已存在该用户！");
                return false;
            }
            if (!RoleDict.ContainsKey(rolename))
            {

                MessageBox.Show("不存在该角色！");
                return false;
            }
            User newuser = new User()
            {
                UserName = username,
                Pwd = pwd,
                RoleName = rolename
            };
            UserDict.Add(username, newuser);
            return true;
        }
        //=================移除用户方法===================
        public static bool RemoveUserWay(string username)
        {
            if (!UserDict.ContainsKey(username))
            {
                MessageBox.Show("目标用户不存在");
                return false;
            }
            if (username == CurrentUser.UserName)
            {
                MessageBox.Show("不能删除当前正在登录的用户！");
                return false;
            }
            UserDict.Remove(username);
            MessageBox.Show("已移除目标用户");
            return true;
        }
    }
}
