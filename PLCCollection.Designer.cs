namespace project_temporature
{
    partial class PLCCollection
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
            PLCData = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)PLCData).BeginInit();
            SuspendLayout();
            // 
            // PLCData
            // 
            PLCData.AllowUserToAddRows = false;
            PLCData.AllowUserToDeleteRows = false;
            PLCData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PLCData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PLCData.Location = new Point(0, 0);
            PLCData.Name = "PLCData";
            PLCData.ReadOnly = true;
            PLCData.RowHeadersWidth = 62;
            PLCData.RowTemplate.Height = 32;
            PLCData.Size = new Size(800, 450);
            PLCData.TabIndex = 0;
            // 
            // PLCCollection
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PLCData);
            Name = "PLCCollection";
            Text = "PLCCollection";
            Load += PLCCollection_Load;
            ((System.ComponentModel.ISupportInitialize)PLCData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView PLCData;
    }
}