namespace Lab3
{
    partial class Form1a
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TrackBar trbTolerance;
        private System.Windows.Forms.Label lblTol;
        private System.Windows.Forms.Label lblTask;

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.trbTolerance = new System.Windows.Forms.TrackBar();
            this.lblTol = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTolerance)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                   | System.Windows.Forms.AnchorStyles.Left)
                                   | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Location = new System.Drawing.Point(12, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(630, 60);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(140, 30);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // trbTolerance
            // 
            this.trbTolerance.Location = new System.Drawing.Point(630, 120);
            this.trbTolerance.Maximum = 128;
            this.trbTolerance.Name = "trbTolerance";
            this.trbTolerance.Size = new System.Drawing.Size(140, 45);
            this.trbTolerance.TabIndex = 2;
            // 
            // lblTol
            // 
            this.lblTol.AutoSize = true;
            this.lblTol.Location = new System.Drawing.Point(630, 100);
            this.lblTol.Name = "lblTol";
            this.lblTol.Size = new System.Drawing.Size(86, 15);
            this.lblTol.TabIndex = 3;
            this.lblTol.Text = "Толерантность";
            // 
            // Form1a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.lblTol);
            this.Controls.Add(this.trbTolerance);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pictureBox1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTolerance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
