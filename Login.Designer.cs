namespace project_temporature
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            txtPwd = new TextBox();
            txtAccount = new TextBox();
            btnLogin = new Button();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtPwd);
            panel1.Controls.Add(txtAccount);
            panel1.Location = new Point(139, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(496, 215);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(83, 114);
            label2.Name = "label2";
            label2.Size = new Size(79, 45);
            label2.TabIndex = 1;
            label2.Text = "密码:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(83, 40);
            label1.Name = "label1";
            label1.Size = new Size(79, 45);
            label1.TabIndex = 1;
            label1.Text = "账号:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(159, 114);
            txtPwd.Multiline = true;
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(264, 45);
            txtPwd.TabIndex = 0;
            // 
            // txtAccount
            // 
            txtAccount.Location = new Point(159, 40);
            txtAccount.Multiline = true;
            txtAccount.Name = "txtAccount";
            txtAccount.Size = new Size(264, 45);
            txtAccount.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ActiveCaptionText;
            btnLogin.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = SystemColors.ControlLightLight;
            btnLogin.Location = new Point(298, 327);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(180, 51);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "登录";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label4
            // 
            label4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(-1, -2);
            label4.Name = "label4";
            label4.Size = new Size(493, 51);
            label4.TabIndex = 3;
            label4.Text = "当前用户";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(btnLogin);
            Controls.Add(panel1);
            Name = "Login";
            Text = "Login";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private TextBox txtPwd;
        private TextBox txtAccount;
        private Button btnLogin;
        private Label label4;
    }
}
