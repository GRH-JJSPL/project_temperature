namespace project_temporature
{
    partial class CurrentTempForm
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label5 = new Label();
            label1 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            btnTemp = new Button();
            btnGraphy = new Button();
            statusStrip1 = new StatusStrip();
            statuslabel = new ToolStripStatusLabel();
            tempTimer = new System.Windows.Forms.Timer(components);
            btnStop = new Button();
            label12 = new Label();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(78, 89);
            panel1.Name = "panel1";
            panel1.Size = new Size(308, 434);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(21, 308);
            label4.Name = "label4";
            label4.Size = new Size(102, 40);
            label4.TabIndex = 1;
            label4.Text = "区域四";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(21, 238);
            label3.Name = "label3";
            label3.Size = new Size(102, 40);
            label3.TabIndex = 1;
            label3.Text = "区域三";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(21, 163);
            label2.Name = "label2";
            label2.Size = new Size(102, 40);
            label2.TabIndex = 1;
            label2.Text = "区域二";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("宋体", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(142, 40);
            label5.TabIndex = 1;
            label5.Text = "当前区域温度";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(21, 88);
            label1.Name = "label1";
            label1.Size = new Size(102, 40);
            label1.TabIndex = 1;
            label1.Text = "区域一";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(121, 308);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(161, 40);
            textBox4.TabIndex = 0;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(121, 238);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(161, 40);
            textBox3.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(121, 163);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(161, 40);
            textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(121, 88);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(161, 40);
            textBox1.TabIndex = 0;
            // 
            // btnTemp
            // 
            btnTemp.BackColor = SystemColors.ControlLightLight;
            btnTemp.FlatStyle = FlatStyle.Popup;
            btnTemp.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnTemp.Location = new Point(635, 174);
            btnTemp.Name = "btnTemp";
            btnTemp.Size = new Size(210, 52);
            btnTemp.TabIndex = 1;
            btnTemp.Text = "获取当前温度";
            btnTemp.UseVisualStyleBackColor = false;
            btnTemp.Click += btnTemp_Click;
            // 
            // btnGraphy
            // 
            btnGraphy.BackColor = SystemColors.ControlLightLight;
            btnGraphy.FlatStyle = FlatStyle.Popup;
            btnGraphy.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGraphy.Location = new Point(635, 384);
            btnGraphy.Name = "btnGraphy";
            btnGraphy.Size = new Size(210, 50);
            btnGraphy.TabIndex = 1;
            btnGraphy.Text = "实时曲线图";
            btnGraphy.UseVisualStyleBackColor = false;
            btnGraphy.Click += btnGraphy_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statuslabel });
            statusStrip1.Location = new Point(0, 575);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1046, 31);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // statuslabel
            // 
            statuslabel.Name = "statuslabel";
            statuslabel.Size = new Size(146, 24);
            statuslabel.Text = "PlC已断开连接！";
            // 
            // tempTimer
            // 
            tempTimer.Interval = 1000;
            tempTimer.Tick += tempTimer_Tick;
            // 
            // btnStop
            // 
            btnStop.BackColor = SystemColors.ControlLightLight;
            btnStop.FlatStyle = FlatStyle.Popup;
            btnStop.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnStop.Location = new Point(635, 280);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(210, 53);
            btnStop.TabIndex = 3;
            btnStop.Text = "停止获取当前温度";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // label12
            // 
            label12.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(0, -2);
            label12.Name = "label12";
            label12.Size = new Size(677, 51);
            label12.TabIndex = 4;
            label12.Text = "当前用户";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CurrentTempForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 606);
            Controls.Add(label12);
            Controls.Add(btnStop);
            Controls.Add(statusStrip1);
            Controls.Add(btnGraphy);
            Controls.Add(btnTemp);
            Controls.Add(panel1);
            Name = "CurrentTempForm";
            Text = "CurrentTempForm";
            FormClosing += CurrentTempForm_FormClosing;
            Load += CurrentTempForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button btnTemp;
        private Button btnGraphy;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statuslabel;
        private System.Windows.Forms.Timer tempTimer;
        private Button btnStop;
        private Label label12;
    }
}