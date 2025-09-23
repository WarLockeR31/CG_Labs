namespace CG_Lab2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pbOriginal = new PictureBox();
            pbResult = new PictureBox();
            pbNTSC = new PictureBox();
            pbSRGB = new PictureBox();
            pbHistogramNTSC = new PictureBox();
            pbHistogramSRGB = new PictureBox();
            btnOpen = new Button();
            btnProcess = new Button();
            btnSave = new Button();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)pbOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbResult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNTSC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSRGB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbHistogramNTSC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbHistogramSRGB).BeginInit();
            SuspendLayout();
            // 
            // lblTask
            // 
            lblTask.Location = new Point(854, 17);
            // 
            // pbOriginal
            // 
            pbOriginal.BorderStyle = BorderStyle.FixedSingle;
            pbOriginal.Location = new Point(20, 80);
            pbOriginal.Name = "pbOriginal";
            pbOriginal.Size = new Size(350, 300);
            pbOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pbOriginal.TabIndex = 4;
            pbOriginal.TabStop = false;
            // 
            // pbResult
            // 
            pbResult.BorderStyle = BorderStyle.FixedSingle;
            pbResult.Location = new Point(1160, 80);
            pbResult.Name = "pbResult";
            pbResult.Size = new Size(350, 300);
            pbResult.SizeMode = PictureBoxSizeMode.Zoom;
            pbResult.TabIndex = 5;
            pbResult.TabStop = false;
            // 
            // pbNTSC
            // 
            pbNTSC.BorderStyle = BorderStyle.FixedSingle;
            pbNTSC.Location = new Point(400, 80);
            pbNTSC.Name = "pbNTSC";
            pbNTSC.Size = new Size(350, 300);
            pbNTSC.SizeMode = PictureBoxSizeMode.Zoom;
            pbNTSC.TabIndex = 6;
            pbNTSC.TabStop = false;
            // 
            // pbSRGB
            // 
            pbSRGB.BorderStyle = BorderStyle.FixedSingle;
            pbSRGB.Location = new Point(780, 80);
            pbSRGB.Name = "pbSRGB";
            pbSRGB.Size = new Size(350, 300);
            pbSRGB.SizeMode = PictureBoxSizeMode.Zoom;
            pbSRGB.TabIndex = 7;
            pbSRGB.TabStop = false;
            // 
            // pbHistogramNTSC
            // 
            pbHistogramNTSC.BorderStyle = BorderStyle.FixedSingle;
            pbHistogramNTSC.Location = new Point(400, 400);
            pbHistogramNTSC.Name = "pbHistogramNTSC";
            pbHistogramNTSC.Size = new Size(350, 268);
            pbHistogramNTSC.SizeMode = PictureBoxSizeMode.Zoom;
            pbHistogramNTSC.TabIndex = 8;
            pbHistogramNTSC.TabStop = false;
            // 
            // pbHistogramSRGB
            // 
            pbHistogramSRGB.BorderStyle = BorderStyle.FixedSingle;
            pbHistogramSRGB.Location = new Point(780, 400);
            pbHistogramSRGB.Name = "pbHistogramSRGB";
            pbHistogramSRGB.Size = new Size(350, 268);
            pbHistogramSRGB.SizeMode = PictureBoxSizeMode.Zoom;
            pbHistogramSRGB.TabIndex = 9;
            pbHistogramSRGB.TabStop = false;
            // 
            // btnOpen
            // 
            btnOpen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOpen.Location = new Point(20, 400);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(100, 40);
            btnOpen.TabIndex = 10;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnProcess
            // 
            btnProcess.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProcess.Location = new Point(140, 400);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(100, 40);
            btnProcess.TabIndex = 11;
            btnProcess.Text = "Process";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Location = new Point(140, 446);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReset.Location = new Point(20, 446);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 40);
            btnReset.TabIndex = 13;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(1837, 950);
            Controls.Add(pbOriginal);
            Controls.Add(pbResult);
            Controls.Add(pbNTSC);
            Controls.Add(pbSRGB);
            Controls.Add(pbHistogramNTSC);
            Controls.Add(pbHistogramSRGB);
            Controls.Add(btnOpen);
            Controls.Add(btnProcess);
            Controls.Add(btnSave);
            Controls.Add(btnReset);
            Name = "Form1";
            Text = "Задание 1";
            Controls.SetChildIndex(btnReset, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnProcess, 0);
            Controls.SetChildIndex(btnOpen, 0);
            Controls.SetChildIndex(pbHistogramSRGB, 0);
            Controls.SetChildIndex(pbHistogramNTSC, 0);
            Controls.SetChildIndex(pbSRGB, 0);
            Controls.SetChildIndex(pbNTSC, 0);
            Controls.SetChildIndex(pbResult, 0);
            Controls.SetChildIndex(pbOriginal, 0);
            Controls.SetChildIndex(lblTask, 0);
            ((System.ComponentModel.ISupportInitialize)pbOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbResult).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNTSC).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSRGB).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbHistogramNTSC).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbHistogramSRGB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pbOriginal;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.PictureBox pbNTSC;
        private System.Windows.Forms.PictureBox pbSRGB;
        private System.Windows.Forms.PictureBox pbHistogramNTSC;
        private System.Windows.Forms.PictureBox pbHistogramSRGB;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
    }
}
