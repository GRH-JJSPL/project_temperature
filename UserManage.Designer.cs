namespace project_temporature
{
    partial class UserManage
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
            btnAddUser = new Button();
            btnDelUser = new Button();
            UserList = new DataGridView();
            label4 = new Label();
            txtRemoveName = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)UserList).BeginInit();
            SuspendLayout();
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = SystemColors.ControlLightLight;
            btnAddUser.FlatStyle = FlatStyle.Popup;
            btnAddUser.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddUser.Location = new Point(711, 136);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(127, 44);
            btnAddUser.TabIndex = 0;
            btnAddUser.Text = "添加用户";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnDelUser
            // 
            btnDelUser.BackColor = SystemColors.ControlLightLight;
            btnDelUser.FlatStyle = FlatStyle.Popup;
            btnDelUser.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelUser.Location = new Point(711, 231);
            btnDelUser.Name = "btnDelUser";
            btnDelUser.Size = new Size(127, 44);
            btnDelUser.TabIndex = 0;
            btnDelUser.Text = "移除用户";
            btnDelUser.UseVisualStyleBackColor = false;
            btnDelUser.Click += btnDelUser_Click;
            // 
            // UserList
            // 
            UserList.AllowUserToAddRows = false;
            UserList.AllowUserToDeleteRows = false;
            UserList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            UserList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UserList.Location = new Point(75, 76);
            UserList.Name = "UserList";
            UserList.ReadOnly = true;
            UserList.RowHeadersWidth = 62;
            UserList.RowTemplate.Height = 32;
            UserList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UserList.Size = new Size(515, 373);
            UserList.TabIndex = 1;
            // 
            // label4
            // 
            label4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(776, 51);
            label4.TabIndex = 3;
            label4.Text = "当前用户";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtRemoveName
            // 
            txtRemoveName.Location = new Point(711, 325);
            txtRemoveName.Name = "txtRemoveName";
            txtRemoveName.Size = new Size(150, 30);
            txtRemoveName.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(623, 328);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 5;
            label1.Text = "移除户名";
            // 
            // UserManage
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 494);
            Controls.Add(label1);
            Controls.Add(txtRemoveName);
            Controls.Add(label4);
            Controls.Add(UserList);
            Controls.Add(btnDelUser);
            Controls.Add(btnAddUser);
            Name = "UserManage";
            Text = "UserManage";
            Load += UserManage_Load;
            ((System.ComponentModel.ISupportInitialize)UserList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddUser;
        private Button btnDelUser;
        private DataGridView UserList;
        private Label label4;
        private TextBox txtRemoveName;
        private Label label1;
    }
}