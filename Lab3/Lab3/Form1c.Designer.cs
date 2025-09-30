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
            btnOpen = new Button();
            pictureBox1 = new PixelPictureBox();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTask
            // 
            lblTask.Size = new Size(118, 27);
            lblTask.Text = "Задание 1в";
            // 
            // btnOpen
            // 
            btnOpen.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOpen.Location = new Point(679, 387);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(91, 42);
            btnOpen.TabIndex = 7;
            btnOpen.Text = "Открыть";
            btnOpen.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            pictureBox1.Location = new Point(12, 58);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(500, 380);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClear.Location = new Point(559, 387);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(91, 42);
            btnClear.TabIndex = 9;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1c
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(pictureBox1);
            Controls.Add(btnOpen);
            Name = "Form1c";
            Text = "Form1c";
            Controls.SetChildIndex(btnOpen, 0);
            Controls.SetChildIndex(lblTask, 0);
            Controls.SetChildIndex(pictureBox1, 0);
            Controls.SetChildIndex(btnClear, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnOpen;
        private PixelPictureBox pictureBox1;
        private Button btnClear;
    }
}