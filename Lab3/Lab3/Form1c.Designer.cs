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
            trbTolerance = new TrackBar();
            lblTol = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trbTolerance).BeginInit();
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
            // trbTolerance
            // 
            trbTolerance.Location = new Point(562, 345);
            trbTolerance.Name = "trbTolerance";
            trbTolerance.Size = new Size(226, 45);
            trbTolerance.TabIndex = 8;
            // 
            // lblTol
            // 
            lblTol.AutoEllipsis = true;
            lblTol.AutoSize = true;
            lblTol.Font = new Font("Segoe UI", 12F);
            lblTol.Location = new Point(624, 311);
            lblTol.Name = "lblTol";
            lblTol.Size = new Size(82, 21);
            lblTol.TabIndex = 9;
            lblTol.Text = "Tolerance: ";
            lblTol.Click += label1_Click;
            // 
            // Form1c
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTol);
            Controls.Add(trbTolerance);
            Controls.Add(btnOpen);
            Controls.Add(pictureBox1);
            Name = "Form1c";
            Text = "Form1c";
            Controls.SetChildIndex(lblTask, 0);
            Controls.SetChildIndex(pictureBox1, 0);
            Controls.SetChildIndex(btnOpen, 0);
            Controls.SetChildIndex(trbTolerance, 0);
            Controls.SetChildIndex(lblTol, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trbTolerance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnOpen;
        private TrackBar trbTolerance;
        private Label lblTol;
    }
}