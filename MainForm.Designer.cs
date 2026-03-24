namespace project_temporature
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel2 = new Panel();
            btnCurrentTemp = new Button();
            btnTempSet = new Button();
            btnLog = new Button();
            btnUser = new Button();
            label4 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCurrentTemp);
            panel2.Controls.Add(btnTempSet);
            panel2.Controls.Add(btnLog);
            panel2.Controls.Add(btnUser);
            panel2.Location = new Point(207, 61);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 377);
            panel2.TabIndex = 1;
            // 
            // btnCurrentTemp
            // 
            btnCurrentTemp.FlatStyle = FlatStyle.Popup;
            btnCurrentTemp.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCurrentTemp.Location = new Point(66, 278);
            btnCurrentTemp.Name = "btnCurrentTemp";
            btnCurrentTemp.Size = new Size(177, 39);
            btnCurrentTemp.TabIndex = 2;
            btnCurrentTemp.Text = "当前温度";
            btnCurrentTemp.UseVisualStyleBackColor = true;
            btnCurrentTemp.Click += btnCurrentTemp_Click;
            // 
            // btnTempSet
            // 
            btnTempSet.FlatStyle = FlatStyle.Popup;
            btnTempSet.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnTempSet.Location = new Point(66, 195);
            btnTempSet.Name = "btnTempSet";
            btnTempSet.Size = new Size(177, 39);
            btnTempSet.TabIndex = 2;
            btnTempSet.Text = "温度阈值设置";
            btnTempSet.UseVisualStyleBackColor = true;
            btnTempSet.Click += btnTempSet_Click;
            // 
            // btnLog
            // 
            btnLog.FlatStyle = FlatStyle.Popup;
            btnLog.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLog.Location = new Point(66, 115);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(177, 39);
            btnLog.TabIndex = 0;
            btnLog.Text = "日志查看";
            btnLog.UseVisualStyleBackColor = true;
            btnLog.Click += btnLog_Click;
            // 
            // btnUser
            // 
            btnUser.FlatStyle = FlatStyle.Popup;
            btnUser.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUser.Location = new Point(66, 35);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(177, 39);
            btnUser.TabIndex = 0;
            btnUser.Text = "用户管理";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += btnUser_Click;
            // 
            // label4
            // 
            label4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(1, 7);
            label4.Name = "label4";
            label4.Size = new Size(609, 51);
            label4.TabIndex = 3;
            label4.Text = "当前用户";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(panel2);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Button btnLog;
        private Button btnUser;
        private Button btnTempSet;
        private Button btnCurrentTemp;
        private Label label4;
    }
}