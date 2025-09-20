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
            this.pbOriginal = new System.Windows.Forms.PictureBox();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.pbNTSC = new System.Windows.Forms.PictureBox();
            this.pbSRGB = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNTSC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSRGB)).BeginInit();
            this.SuspendLayout();
            // 
            // pbOriginal
            // 
            this.pbOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOriginal.Location = new System.Drawing.Point(20, 80);
            this.pbOriginal.Name = "pbOriginal";
            this.pbOriginal.Size = new System.Drawing.Size(350, 300);
            this.pbOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOriginal.TabStop = false;
            // 
            // pbNTSC
            // 
            this.pbNTSC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbNTSC.Location = new System.Drawing.Point(400, 80);
            this.pbNTSC.Name = "pbNTSC";
            this.pbNTSC.Size = new System.Drawing.Size(350, 300);
            this.pbNTSC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNTSC.TabStop = false;
            // 
            // pbSRGB
            // 
            this.pbSRGB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSRGB.Location = new System.Drawing.Point(780, 80);
            this.pbSRGB.Name = "pbSRGB";
            this.pbSRGB.Size = new System.Drawing.Size(350, 300);
            this.pbSRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSRGB.TabStop = false;
            // 
            // pbResult
            // 
            this.pbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbResult.Location = new System.Drawing.Point(1160, 80);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(350, 300);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbResult.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpen.Location = new System.Drawing.Point(20, 400);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 40);
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProcess.Location = new System.Drawing.Point(140, 400);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(100, 40);
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(260, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(380, 400);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 40);
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pbOriginal);
            this.Controls.Add(this.pbResult);
            this.Controls.Add(this.pbNTSC);
            this.Controls.Add(this.pbSRGB);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Name = "Form1";
            this.Text = "Задание 1";
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNTSC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSRGB)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pbOriginal;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.PictureBox pbNTSC;
        private System.Windows.Forms.PictureBox pbSRGB;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
    }
}
