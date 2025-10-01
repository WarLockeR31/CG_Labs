namespace Lab3
{
    partial class Form1b
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnPattern;
        private PictureBox pictureBox1;

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


        private void InitializeComponent()
        {
            btnPattern = new Button();
            pictureBox1 = new PictureBox();
            btnOpen = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnPattern
            // 
            btnPattern.Location = new Point(648, 408);
            btnPattern.Name = "btnPattern";
            btnPattern.Size = new Size(140, 30);
            btnPattern.TabIndex = 2;
            btnPattern.Text = "Открыть паттерн";
            btnPattern.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.LightGray;
            pictureBox1.Location = new Point(12, 80);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(595, 358);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(648, 372);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(140, 30);
            btnOpen.TabIndex = 6;
            btnOpen.Text = "Открыть";
            btnOpen.UseVisualStyleBackColor = true;
            // 
            // Form1b
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOpen);
            Controls.Add(pictureBox1);
            Controls.Add(btnPattern);
            Name = "Form1b";
            Controls.SetChildIndex(btnPattern, 0);
            Controls.SetChildIndex(pictureBox1, 0);
            Controls.SetChildIndex(btnOpen, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnOpen;
    }
}
