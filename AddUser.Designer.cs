namespace project_temporature
{
    partial class AddUser
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
            txtUserName = new TextBox();
            button1 = new Button();
            txtPwd = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtRoleName = new TextBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(401, 99);
            txtUserName.Multiline = true;
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(270, 45);
            txtUserName.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLightLight;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(456, 383);
            button1.Name = "button1";
            button1.Size = new Size(131, 55);
            button1.TabIndex = 1;
            button1.Text = "添加用户";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(401, 192);
            txtPwd.Multiline = true;
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(270, 43);
            txtPwd.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(301, 99);
            label1.Name = "label1";
            label1.Size = new Size(94, 45);
            label1.TabIndex = 2;
            label1.Text = "用户名";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(301, 193);
            label2.Name = "label2";
            label2.Size = new Size(94, 45);
            label2.TabIndex = 2;
            label2.Text = "密码";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRoleName
            // 
            txtRoleName.Location = new Point(401, 282);
            txtRoleName.Multiline = true;
            txtRoleName.Name = "txtRoleName";
            txtRoleName.Size = new Size(270, 43);
            txtRoleName.TabIndex = 0;
            // 
            // label3
            // 
            label3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(301, 282);
            label3.Name = "label3";
            label3.Size = new Size(94, 45);
            label3.TabIndex = 2;
            label3.Text = "角色";
            label3.TextAlign = ContentAlignment.MiddleRight;
            label3.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            label4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(962, 51);
            label4.TabIndex = 2;
            label4.Text = "当前用户";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 594);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(txtRoleName);
            Controls.Add(txtPwd);
            Controls.Add(txtUserName);
            Name = "AddUser";
            Text = "AddUser";
            Load += AddUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserName;
        private Button button1;
        private TextBox txtPwd;
        private Label label1;
        private Label label2;
        private TextBox txtRoleName;
        private Label label3;
        private Label label4;
    }
}