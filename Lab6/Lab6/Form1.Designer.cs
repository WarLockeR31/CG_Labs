namespace Lab6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			pb = new System.Windows.Forms.PictureBox();
			btnProjection = new System.Windows.Forms.Button();
			tb_Focal = new System.Windows.Forms.TrackBar();
			lbl_Focal = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			((System.ComponentModel.ISupportInitialize)tb_Focal).BeginInit();
			SuspendLayout();
			// 
			// pb
			// 
			pb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
			pb.BackColor = System.Drawing.SystemColors.ControlLight;
			pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pb.Location = new System.Drawing.Point(12, 12);
			pb.Name = "pb";
			pb.Size = new System.Drawing.Size(426, 426);
			pb.TabIndex = 0;
			pb.TabStop = false;
			pb.Paint += pb_Paint;
			// 
			// btnProjection
			// 
			btnProjection.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btnProjection.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btnProjection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btnProjection.Location = new System.Drawing.Point(444, 12);
			btnProjection.Name = "btnProjection";
			btnProjection.Size = new System.Drawing.Size(344, 33);
			btnProjection.TabIndex = 1;
			btnProjection.Text = "Projection: Perspective";
			btnProjection.UseVisualStyleBackColor = false;
			btnProjection.Click += btnProjection_Click;
			// 
			// tb_Focal
			// 
			tb_Focal.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			tb_Focal.CausesValidation = false;
			tb_Focal.LargeChange = 10;
			tb_Focal.Location = new System.Drawing.Point(444, 48);
			tb_Focal.Maximum = 180;
			tb_Focal.Minimum = 1;
			tb_Focal.Name = "tb_Focal";
			tb_Focal.Size = new System.Drawing.Size(230, 45);
			tb_Focal.TabIndex = 2;
			tb_Focal.TickStyle = System.Windows.Forms.TickStyle.None;
			tb_Focal.Value = 180;
			tb_Focal.Scroll += tb_Focal_Scroll;
			// 
			// lbl_Focal
			// 
			lbl_Focal.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			lbl_Focal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
			lbl_Focal.Location = new System.Drawing.Point(680, 48);
			lbl_Focal.Name = "lbl_Focal";
			lbl_Focal.Size = new System.Drawing.Size(108, 38);
			lbl_Focal.TabIndex = 3;
			lbl_Focal.Text = "Focal: ";
			lbl_Focal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Form1
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(800, 450);
			Controls.Add(lbl_Focal);
			Controls.Add(tb_Focal);
			Controls.Add(btnProjection);
			Controls.Add(pb);
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			((System.ComponentModel.ISupportInitialize)tb_Focal).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		private System.Windows.Forms.TrackBar tb_Focal;
		private System.Windows.Forms.Label lbl_Focal;

		private System.Windows.Forms.Button Perspective;

		private System.Windows.Forms.PictureBox pb;
		private System.Windows.Forms.Button btnProjection;

		#endregion
    }
}
