using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace project_temporature
{
    internal class LogClass
    {
    }
    public static class LogControl
    {
        //指定日志文件路径（此处放在应用文件启动目录）
        //Path.Combine方法，拼接路径的方法，第一个参数，Applicatio.StartupPath作用是获取当前程序的执行路径
        public static string logFilePath = Path.Combine(Application.StartupPath,"log.txt");
        //============================写入日志的方法===========================
        public static void WriteMessage(string message)
        { 
            try
            {
                if (!File.Exists(logFilePath))
                    File.Create(logFilePath).Close();
                string timestamp = System.DateTime.Now.ToString("F");
                //Environment.NewLine是换行的意思
                string logLine = $"[{timestamp}——{message}——{Environment.NewLine}]";
                File.AppendAllText(logFilePath, logLine);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"写入日志失败：{ex.Message}");
            }
        }
        //=========================打开日志的方法===========================
        public static void OpenLog()
        {
            try
            { 
                if(!File.Exists(logFilePath))
                {
                    MessageBox.Show("不存在该日志");
                    return;
                }
                Process.Start("notepad.exe",logFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"打开日志失败：{ex.Message}");
            }
        }

    }

}
