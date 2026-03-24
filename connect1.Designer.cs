namespace project_temporature
{
    partial class connect1
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
            panel1 = new Panel();
            sessionName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label8 = new Label();
            label1 = new Label();
            txtSlot = new TextBox();
            txtRack = new TextBox();
            txtIPAddress = new TextBox();
            btnDisconnect = new Button();
            btnConnect = new Button();
            btnWrtData = new Button();
            btnReadData = new Button();
            panel2 = new Panel();
            txtDataType = new ComboBox();
            label4 = new Label();
            label7 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtVal = new TextBox();
            txtstartByte = new TextBox();
            txtDBNum = new TextBox();
            statusStrip1 = new StatusStrip();
            statuslabel = new ToolStripStatusLabel();
            btnOpenMainForm = new Button();
            label9 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(sessionName);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtSlot);
            panel1.Controls.Add(txtRack);
            panel1.Controls.Add(txtIPAddress);
            panel1.Controls.Add(btnDisconnect);
            panel1.Controls.Add(btnConnect);
            panel1.Location = new Point(64, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(444, 273);
            panel1.TabIndex = 0;
            // 
            // sessionName
            // 
            sessionName.Location = new Point(172, 3);
            sessionName.Name = "sessionName";
            sessionName.Size = new Size(199, 30);
            sessionName.TabIndex = 3;
            // 
            // label3
            // 
            label3.Location = new Point(56, 166);
            label3.Name = "label3";
            label3.Size = new Size(115, 30);
            label3.TabIndex = 2;
            label3.Text = "Plc Slot";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new Point(56, 113);
            label2.Name = "label2";
            label2.Size = new Size(115, 30);
            label2.TabIndex = 2;
            label2.Text = "Plc Rack";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Location = new Point(56, 3);
            label8.Name = "label8";
            label8.Size = new Size(115, 30);
            label8.TabIndex = 2;
            label8.Text = "PLC Name";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Location = new Point(56, 57);
            label1.Name = "label1";
            label1.Size = new Size(115, 30);
            label1.TabIndex = 2;
            label1.Text = "Plc Address";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSlot
            // 
            txtSlot.Location = new Point(167, 166);
            txtSlot.Name = "txtSlot";
            txtSlot.Size = new Size(201, 30);
            txtSlot.TabIndex = 1;
            // 
            // txtRack
            // 
            txtRack.Location = new Point(167, 113);
            txtRack.Name = "txtRack";
            txtRack.Size = new Size(201, 30);
            txtRack.TabIndex = 1;
            // 
            // txtIPAddress
            // 
            txtIPAddress.Location = new Point(167, 57);
            txtIPAddress.Name = "txtIPAddress";
            txtIPAddress.Size = new Size(201, 30);
            txtIPAddress.TabIndex = 1;
            // 
            // btnDisconnect
            // 
            btnDisconnect.FlatStyle = FlatStyle.Popup;
            btnDisconnect.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnDisconnect.Location = new Point(272, 207);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(112, 34);
            btnDisconnect.TabIndex = 0;
            btnDisconnect.Text = "断开";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // btnConnect
            // 
            btnConnect.FlatStyle = FlatStyle.Popup;
            btnConnect.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnConnect.Location = new Point(98, 207);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(112, 34);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "连接";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnWrtData
            // 
            btnWrtData.FlatStyle = FlatStyle.Popup;
            btnWrtData.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnWrtData.Location = new Point(430, 158);
            btnWrtData.Name = "btnWrtData";
            btnWrtData.Size = new Size(112, 34);
            btnWrtData.TabIndex = 0;
            btnWrtData.Text = "写数据";
            btnWrtData.UseVisualStyleBackColor = true;
            btnWrtData.Click += btnWrtData_Click;
            // 
            // btnReadData
            // 
            btnReadData.FlatStyle = FlatStyle.Popup;
            btnReadData.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnReadData.Location = new Point(430, 78);
            btnReadData.Name = "btnReadData";
            btnReadData.Size = new Size(112, 34);
            btnReadData.TabIndex = 0;
            btnReadData.Text = "读数据";
            btnReadData.UseVisualStyleBackColor = true;
            btnReadData.Click += btnReadData_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtDataType);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnReadData);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(btnWrtData);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtVal);
            panel2.Controls.Add(txtstartByte);
            panel2.Controls.Add(txtDBNum);
            panel2.Location = new Point(64, 335);
            panel2.Name = "panel2";
            panel2.Size = new Size(564, 258);
            panel2.TabIndex = 0;
            // 
            // txtDataType
            // 
            txtDataType.FormattingEnabled = true;
            txtDataType.Location = new Point(172, 138);
            txtDataType.Name = "txtDataType";
            txtDataType.Size = new Size(196, 32);
            txtDataType.TabIndex = 3;
            // 
            // label4
            // 
            label4.Location = new Point(56, 187);
            label4.Name = "label4";
            label4.Size = new Size(115, 30);
            label4.TabIndex = 2;
            label4.Text = "Val to Write";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Location = new Point(56, 138);
            label7.Name = "label7";
            label7.Size = new Size(115, 30);
            label7.TabIndex = 2;
            label7.Text = "DataType";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Location = new Point(56, 82);
            label5.Name = "label5";
            label5.Size = new Size(115, 30);
            label5.TabIndex = 2;
            label5.Text = "startByte";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Location = new Point(56, 26);
            label6.Name = "label6";
            label6.Size = new Size(115, 30);
            label6.TabIndex = 2;
            label6.Text = "DB Num";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtVal
            // 
            txtVal.Location = new Point(167, 187);
            txtVal.Name = "txtVal";
            txtVal.Size = new Size(201, 30);
            txtVal.TabIndex = 1;
            // 
            // txtstartByte
            // 
            txtstartByte.Location = new Point(167, 82);
            txtstartByte.Name = "txtstartByte";
            txtstartByte.Size = new Size(201, 30);
            txtstartByte.TabIndex = 1;
            // 
            // txtDBNum
            // 
            txtDBNum.Location = new Point(167, 26);
            txtDBNum.Name = "txtDBNum";
            txtDBNum.Size = new Size(201, 30);
            txtDBNum.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statuslabel });
            statusStrip1.Location = new Point(0, 596);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(976, 31);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statuslabel
            // 
            statuslabel.Name = "statuslabel";
            statuslabel.Size = new Size(125, 24);
            statuslabel.Text = "未连接到Plc！";
            // 
            // btnOpenMainForm
            // 
            btnOpenMainForm.BackColor = SystemColors.ControlLightLight;
            btnOpenMainForm.FlatStyle = FlatStyle.Popup;
            btnOpenMainForm.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpenMainForm.Location = new Point(819, 39);
            btnOpenMainForm.Name = "btnOpenMainForm";
            btnOpenMainForm.Size = new Size(110, 44);
            btnOpenMainForm.TabIndex = 2;
            btnOpenMainForm.Text = "主窗口";
            btnOpenMainForm.UseVisualStyleBackColor = false;
            btnOpenMainForm.Click += button1_Click;
            // 
            // label9
            // 
            label9.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(628, 51);
            label9.TabIndex = 3;
            label9.Text = "当前用户";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // connect1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 627);
            Controls.Add(label9);
            Controls.Add(btnOpenMainForm);
            Controls.Add(statusStrip1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "connect1";
            Text = "connect1";
            Load += connect1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtSlot;
        private TextBox txtRack;
        private TextBox txtIPAddress;
        private Button btnDisconnect;
        private Button btnConnect;
        private Button btnWrtData;
        private Button btnReadData;
        private Panel panel2;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtVal;
        private TextBox txtstartByte;
        private TextBox txtDBNum;
        private ComboBox txtDataType;
        private Label label7;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statuslabel;
        private Button btnOpenMainForm;
        private TextBox sessionName;
        private Label label8;
        private Label label9;
    }
}