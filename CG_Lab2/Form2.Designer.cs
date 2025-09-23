namespace CG_Lab2
{
    partial class Form2
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
            pbSrc = new PictureBox();
            pbR = new PictureBox();
            pbG = new PictureBox();
            pbB = new PictureBox();
            hR = new PictureBox();
            hG = new PictureBox();
            hB = new PictureBox();
            btnOpen = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)pbSrc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hB).BeginInit();
            SuspendLayout();
            // 
            // lblTask
            // 
            lblTask.Text = "Задание 2";
            // 
            // pbSrc
            // 
            pbSrc.Location = new Point(41, 180);
            pbSrc.Name = "pbSrc";
            pbSrc.Size = new Size(221, 212);
            pbSrc.SizeMode = PictureBoxSizeMode.Zoom;
            pbSrc.TabIndex = 4;
            pbSrc.TabStop = false;
            // 
            // pbR
            // 
            pbR.Location = new Point(300, 140);
            pbR.Name = "pbR";
            pbR.Size = new Size(157, 137);
            pbR.SizeMode = PictureBoxSizeMode.Zoom;
            pbR.TabIndex = 5;
            pbR.TabStop = false;
            // 
            // pbG
            // 
            pbG.Location = new Point(491, 140);
            pbG.Name = "pbG";
            pbG.Size = new Size(157, 137);
            pbG.SizeMode = PictureBoxSizeMode.Zoom;
            pbG.TabIndex = 6;
            pbG.TabStop = false;
            pbG.Click += pbG_Click;
            // 
            // pbB
            // 
            pbB.Location = new Point(686, 140);
            pbB.Name = "pbB";
            pbB.Size = new Size(157, 137);
            pbB.SizeMode = PictureBoxSizeMode.Zoom;
            pbB.TabIndex = 7;
            pbB.TabStop = false;
            pbB.Click += pbB_Click;
            // 
            // hR
            // 
            hR.Location = new Point(300, 297);
            hR.Name = "hR";
            hR.Size = new Size(157, 126);
            hR.SizeMode = PictureBoxSizeMode.Zoom;
            hR.TabIndex = 8;
            hR.TabStop = false;
            // 
            // hG
            // 
            hG.Location = new Point(491, 297);
            hG.Name = "hG";
            hG.Size = new Size(157, 126);
            hG.SizeMode = PictureBoxSizeMode.Zoom;
            hG.TabIndex = 9;
            hG.TabStop = false;
            // 
            // hB
            // 
            hB.Location = new Point(686, 297);
            hB.Name = "hB";
            hB.Size = new Size(157, 126);
            hB.SizeMode = PictureBoxSizeMode.Zoom;
            hB.TabIndex = 10;
            hB.TabStop = false;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(554, 28);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(94, 29);
            btnOpen.TabIndex = 11;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(654, 28);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnSave);
            Controls.Add(btnOpen);
            Controls.Add(hB);
            Controls.Add(hG);
            Controls.Add(hR);
            Controls.Add(pbB);
            Controls.Add(pbG);
            Controls.Add(pbR);
            Controls.Add(pbSrc);
            Margin = new Padding(3, 5, 3, 5);
            Name = "Form2";
            Text = "Form2";
            Controls.SetChildIndex(pbSrc, 0);
            Controls.SetChildIndex(pbR, 0);
            Controls.SetChildIndex(pbG, 0);
            Controls.SetChildIndex(pbB, 0);
            Controls.SetChildIndex(hR, 0);
            Controls.SetChildIndex(hG, 0);
            Controls.SetChildIndex(hB, 0);
            Controls.SetChildIndex(btnOpen, 0);
            Controls.SetChildIndex(lblTask, 0);
            Controls.SetChildIndex(btnSave, 0);
            ((System.ComponentModel.ISupportInitialize)pbSrc).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbR).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbG).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbB).EndInit();
            ((System.ComponentModel.ISupportInitialize)hR).EndInit();
            ((System.ComponentModel.ISupportInitialize)hG).EndInit();
            ((System.ComponentModel.ISupportInitialize)hB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbSrc;
        private PictureBox pbR;
        private PictureBox pbG;
        private PictureBox pbB;
        private PictureBox hR;
        private PictureBox hG;
        private PictureBox hB;
        private Button btnOpen;
        private Button btnSave;
    }
}