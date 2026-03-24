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
    public partial class CollectPLC : Form
    {
        public CollectPLC()
        {
            InitializeComponent();
        }

        private void Siemens_Click(object sender, EventArgs e)
        {
            connect1 Form = new connect1();
            LogControl.WriteMessage("已创建一台S西门子PLC连接界面");
            Form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var Forms1 = new PLCCollection())
            {
                Forms1.ShowDialog();
            }
        }
    }
}
