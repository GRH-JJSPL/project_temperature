namespace project_temporature
{
    partial class CollectPLC
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
            Siemens = new Button();
            Mitsubishi = new Button();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // Siemens
            // 
            Siemens.BackColor = SystemColors.ControlLightLight;
            Siemens.FlatStyle = FlatStyle.Popup;
            Siemens.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Siemens.Location = new Point(292, 109);
            Siemens.Name = "Siemens";
            Siemens.Size = new Size(153, 50);
            Siemens.TabIndex = 0;
            Siemens.Text = "西门子";
            Siemens.UseVisualStyleBackColor = false;
            Siemens.Click += Siemens_Click;
            // 
            // Mitsubishi
            // 
            Mitsubishi.BackColor = SystemColors.ControlLightLight;
            Mitsubishi.FlatStyle = FlatStyle.Popup;
            Mitsubishi.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Mitsubishi.Location = new Point(292, 200);
            Mitsubishi.Name = "Mitsubishi";
            Mitsubishi.Size = new Size(153, 50);
            Mitsubishi.TabIndex = 0;
            Mitsubishi.Text = "三菱";
            Mitsubishi.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(179, 48);
            label1.TabIndex = 1;
            label1.Text = "PLC类型";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLightLight;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(238, 299);
            button1.Name = "button1";
            button1.Size = new Size(268, 64);
            button1.TabIndex = 0;
            button1.Text = "查看当前已连接的PLC";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // CollectPLC
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(Mitsubishi);
            Controls.Add(Siemens);
            Name = "CollectPLC";
            Text = "CollectPLC";
            ResumeLayout(false);
        }

        #endregion

        private Button Siemens;
        private Button Mitsubishi;
        private Label label1;
        private Button button1;
    }
}