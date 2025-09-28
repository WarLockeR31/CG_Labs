namespace Lab3
{
    partial class Form1c
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
            pictureBox1 = new PictureBox();
            btnOpen = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTask
            // 
            lblTask.Size = new Size(118, 27);
            lblTask.Text = "Задание 1в";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 58);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(500, 380);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // btnOpen
            // 
            btnOpen.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOpen.Location = new Point(634, 396);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(85, 42);
            btnOpen.TabIndex = 7;
            btnOpen.Text = "Открыть";
            btnOpen.UseVisualStyleBackColor = true;
            // 
            // Form1c
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOpen);
            Controls.Add(pictureBox1);
            Name = "Form1c";
            Text = "Form1c";
            Controls.SetChildIndex(lblTask, 0);
            Controls.SetChildIndex(pictureBox1, 0);
            Controls.SetChildIndex(btnOpen, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnOpen;
    }
}