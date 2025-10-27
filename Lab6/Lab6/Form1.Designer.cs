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
			btn_Projection = new System.Windows.Forms.Button();
			tb_FOV = new System.Windows.Forms.TrackBar();
			lbl_FOV = new System.Windows.Forms.Label();
			lbl_Distance = new System.Windows.Forms.Label();
			tb_Distance = new System.Windows.Forms.TrackBar();
			btn_Tetra = new System.Windows.Forms.Button();
			btn_Octa = new System.Windows.Forms.Button();
			btn_Hexa = new System.Windows.Forms.Button();
			btn_Ico = new System.Windows.Forms.Button();
			btn_Dode = new System.Windows.Forms.Button();
			btn_Reset = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			((System.ComponentModel.ISupportInitialize)tb_FOV).BeginInit();
			((System.ComponentModel.ISupportInitialize)tb_Distance).BeginInit();
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
			// btn_Projection
			// 
			btn_Projection.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btn_Projection.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btn_Projection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btn_Projection.Location = new System.Drawing.Point(444, 12);
			btn_Projection.Name = "btn_Projection";
			btn_Projection.Size = new System.Drawing.Size(204, 33);
			btn_Projection.TabIndex = 1;
			btn_Projection.Text = "Projection: Perspective";
			btn_Projection.UseVisualStyleBackColor = false;
			btn_Projection.Click += btnProjection_Click;
			// 
			// tb_FOV
			// 
			tb_FOV.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			tb_FOV.CausesValidation = false;
			tb_FOV.LargeChange = 10;
			tb_FOV.Location = new System.Drawing.Point(444, 48);
			tb_FOV.Maximum = 180;
			tb_FOV.Minimum = 1;
			tb_FOV.Name = "tb_FOV";
			tb_FOV.Size = new System.Drawing.Size(198, 45);
			tb_FOV.TabIndex = 2;
			tb_FOV.TickStyle = System.Windows.Forms.TickStyle.None;
			tb_FOV.Value = 70;
			tb_FOV.Scroll += tb_FOV_Scroll;
			// 
			// lbl_FOV
			// 
			lbl_FOV.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			lbl_FOV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
			lbl_FOV.Location = new System.Drawing.Point(648, 48);
			lbl_FOV.Name = "lbl_FOV";
			lbl_FOV.Size = new System.Drawing.Size(140, 38);
			lbl_FOV.TabIndex = 3;
			lbl_FOV.Text = "FOV: 70";
			lbl_FOV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_Distance
			// 
			lbl_Distance.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			lbl_Distance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
			lbl_Distance.Location = new System.Drawing.Point(646, 86);
			lbl_Distance.Name = "lbl_Distance";
			lbl_Distance.Size = new System.Drawing.Size(140, 38);
			lbl_Distance.TabIndex = 5;
			lbl_Distance.Text = "Distance: 200";
			lbl_Distance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tb_Distance
			// 
			tb_Distance.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			tb_Distance.CausesValidation = false;
			tb_Distance.LargeChange = 10;
			tb_Distance.Location = new System.Drawing.Point(444, 86);
			tb_Distance.Maximum = 500;
			tb_Distance.Minimum = 1;
			tb_Distance.Name = "tb_Distance";
			tb_Distance.Size = new System.Drawing.Size(198, 45);
			tb_Distance.TabIndex = 4;
			tb_Distance.TickStyle = System.Windows.Forms.TickStyle.None;
			tb_Distance.Value = 200;
			tb_Distance.Scroll += tb_Distance_Scroll;
			// 
			// btn_Tetra
			// 
			btn_Tetra.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btn_Tetra.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btn_Tetra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btn_Tetra.Location = new System.Drawing.Point(444, 127);
			btn_Tetra.Name = "btn_Tetra";
			btn_Tetra.Size = new System.Drawing.Size(64, 33);
			btn_Tetra.TabIndex = 6;
			btn_Tetra.Text = "Tetra";
			btn_Tetra.UseVisualStyleBackColor = false;
			btn_Tetra.Click += btn_Tetra_Click;
			// 
			// btn_Octa
			// 
			btn_Octa.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btn_Octa.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btn_Octa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btn_Octa.Location = new System.Drawing.Point(584, 127);
			btn_Octa.Name = "btn_Octa";
			btn_Octa.Size = new System.Drawing.Size(64, 33);
			btn_Octa.TabIndex = 7;
			btn_Octa.Text = "Octa";
			btn_Octa.UseVisualStyleBackColor = false;
			btn_Octa.Click += btn_Octa_Click;
			// 
			// btn_Hexa
			// 
			btn_Hexa.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btn_Hexa.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btn_Hexa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btn_Hexa.Location = new System.Drawing.Point(514, 127);
			btn_Hexa.Name = "btn_Hexa";
			btn_Hexa.Size = new System.Drawing.Size(64, 33);
			btn_Hexa.TabIndex = 8;
			btn_Hexa.Text = "Hexa";
			btn_Hexa.UseVisualStyleBackColor = false;
			btn_Hexa.Click += btn_Hexa_Click;
			// 
			// btn_Ico
			// 
			btn_Ico.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btn_Ico.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btn_Ico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btn_Ico.Location = new System.Drawing.Point(654, 127);
			btn_Ico.Name = "btn_Ico";
			btn_Ico.Size = new System.Drawing.Size(64, 33);
			btn_Ico.TabIndex = 9;
			btn_Ico.Text = "Ico";
			btn_Ico.UseVisualStyleBackColor = false;
			btn_Ico.Click += btn_Ico_Click;
			// 
			// btn_Dode
			// 
			btn_Dode.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btn_Dode.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btn_Dode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btn_Dode.Location = new System.Drawing.Point(724, 127);
			btn_Dode.Name = "btn_Dode";
			btn_Dode.Size = new System.Drawing.Size(64, 33);
			btn_Dode.TabIndex = 10;
			btn_Dode.Text = "Dode";
			btn_Dode.UseVisualStyleBackColor = false;
			btn_Dode.Click += btn_Dode_Click;
			// 
			// btn_Reset
			// 
			btn_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btn_Reset.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btn_Reset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btn_Reset.Location = new System.Drawing.Point(654, 12);
			btn_Reset.Name = "btn_Reset";
			btn_Reset.Size = new System.Drawing.Size(134, 33);
			btn_Reset.TabIndex = 11;
			btn_Reset.Text = "Reset";
			btn_Reset.UseVisualStyleBackColor = false;
			btn_Reset.Click += btn_Reset_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(800, 450);
			Controls.Add(btn_Reset);
			Controls.Add(btn_Dode);
			Controls.Add(btn_Ico);
			Controls.Add(btn_Hexa);
			Controls.Add(btn_Octa);
			Controls.Add(btn_Tetra);
			Controls.Add(lbl_Distance);
			Controls.Add(tb_Distance);
			Controls.Add(lbl_FOV);
			Controls.Add(tb_FOV);
			Controls.Add(btn_Projection);
			Controls.Add(pb);
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			((System.ComponentModel.ISupportInitialize)tb_FOV).EndInit();
			((System.ComponentModel.ISupportInitialize)tb_Distance).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		private System.Windows.Forms.Button btn_Reset;

		private System.Windows.Forms.Button btn_Ico;
		private System.Windows.Forms.Button btn_Dode;

		private System.Windows.Forms.Button btn_Hexa;
		private System.Windows.Forms.Button btn_Octa;

		private System.Windows.Forms.Button btn_Tetra;

		private System.Windows.Forms.Label lbl_Distance;

		private System.Windows.Forms.TrackBar tb_Distance;

		private System.Windows.Forms.TrackBar tb_FOV;
		private System.Windows.Forms.Label lbl_FOV;

		private System.Windows.Forms.Button Perspective;

		private System.Windows.Forms.PictureBox pb;
		private System.Windows.Forms.Button btn_Projection;

		#endregion
    }
}
