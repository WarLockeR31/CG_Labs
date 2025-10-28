namespace Lab6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Button btn_Projection;
        private System.Windows.Forms.TrackBar tb_FOV;
        private System.Windows.Forms.Label lbl_FOV;
        private System.Windows.Forms.Label lbl_Distance;
        private System.Windows.Forms.TrackBar tb_Distance;
        private System.Windows.Forms.Button btn_Tetra;
        private System.Windows.Forms.Button btn_Octa;
        private System.Windows.Forms.Button btn_Hexa;
        private System.Windows.Forms.Button btn_Ico;
        private System.Windows.Forms.Button btn_Dode;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.GroupBox grpTransform;
        private System.Windows.Forms.NumericUpDown numSZ;
        private System.Windows.Forms.NumericUpDown numSY;
        private System.Windows.Forms.NumericUpDown numSX;
        private System.Windows.Forms.Button btnScale;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.NumericUpDown numRZ;
        private System.Windows.Forms.NumericUpDown numRY;
        private System.Windows.Forms.NumericUpDown numRX;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.Label lblRotate;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.NumericUpDown numTZ;
        private System.Windows.Forms.NumericUpDown numTY;
        private System.Windows.Forms.NumericUpDown numTX;
        private System.Windows.Forms.Label lblTranslate;
        private System.Windows.Forms.GroupBox grpReflection;
        private System.Windows.Forms.Button btnReflectYZ;
        private System.Windows.Forms.Button btnReflectXZ;
        private System.Windows.Forms.Button btnReflectXY;

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
            grpTransform = new System.Windows.Forms.GroupBox();
            numSZ = new System.Windows.Forms.NumericUpDown();
            numSY = new System.Windows.Forms.NumericUpDown();
            numSX = new System.Windows.Forms.NumericUpDown();
            btnScale = new System.Windows.Forms.Button();
            lblScale = new System.Windows.Forms.Label();
            numRZ = new System.Windows.Forms.NumericUpDown();
            numRY = new System.Windows.Forms.NumericUpDown();
            numRX = new System.Windows.Forms.NumericUpDown();
            btnRotate = new System.Windows.Forms.Button();
            lblRotate = new System.Windows.Forms.Label();
            btnTranslate = new System.Windows.Forms.Button();
            numTZ = new System.Windows.Forms.NumericUpDown();
            numTY = new System.Windows.Forms.NumericUpDown();
            numTX = new System.Windows.Forms.NumericUpDown();
            lblTranslate = new System.Windows.Forms.Label();
            grpReflection = new System.Windows.Forms.GroupBox();
            btnReflectYZ = new System.Windows.Forms.Button();
            btnReflectXZ = new System.Windows.Forms.Button();
            btnReflectXY = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_FOV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_Distance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTX).BeginInit();
            grpTransform.SuspendLayout();
            grpReflection.SuspendLayout();
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
            // grpTransform
            // 
            grpTransform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            grpTransform.Controls.Add(numSZ);
            grpTransform.Controls.Add(numSY);
            grpTransform.Controls.Add(numSX);
            grpTransform.Controls.Add(btnScale);
            grpTransform.Controls.Add(lblScale);
            grpTransform.Controls.Add(numRZ);
            grpTransform.Controls.Add(numRY);
            grpTransform.Controls.Add(numRX);
            grpTransform.Controls.Add(btnRotate);
            grpTransform.Controls.Add(lblRotate);
            grpTransform.Controls.Add(btnTranslate);
            grpTransform.Controls.Add(numTZ);
            grpTransform.Controls.Add(numTY);
            grpTransform.Controls.Add(numTX);
            grpTransform.Controls.Add(lblTranslate);
            grpTransform.Location = new System.Drawing.Point(444, 166);
            grpTransform.Name = "grpTransform";
            grpTransform.Size = new System.Drawing.Size(210, 180);
            grpTransform.TabIndex = 12;
            grpTransform.TabStop = false;
            grpTransform.Text = "Аффинные преобразования";
            // 
            // numSZ
            // 
            numSZ.DecimalPlaces = 1;
            numSZ.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numSZ.Location = new System.Drawing.Point(160, 128);
            numSZ.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numSZ.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numSZ.Name = "numSZ";
            numSZ.Size = new System.Drawing.Size(40, 23);
            numSZ.TabIndex = 14;
            numSZ.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numSY
            // 
            numSY.DecimalPlaces = 1;
            numSY.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numSY.Location = new System.Drawing.Point(115, 128);
            numSY.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numSY.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numSY.Name = "numSY";
            numSY.Size = new System.Drawing.Size(40, 23);
            numSY.TabIndex = 13;
            numSY.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numSX
            // 
            numSX.DecimalPlaces = 1;
            numSX.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numSX.Location = new System.Drawing.Point(70, 128);
            numSX.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numSX.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numSX.Name = "numSX";
            numSX.Size = new System.Drawing.Size(40, 23);
            numSX.TabIndex = 12;
            numSX.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnScale
            // 
            btnScale.Location = new System.Drawing.Point(10, 153);
            btnScale.Name = "btnScale";
            btnScale.Size = new System.Drawing.Size(80, 23);
            btnScale.TabIndex = 11;
            btnScale.Text = "От центра";
            btnScale.UseVisualStyleBackColor = true;
            btnScale.Click += BtnScale_Click;
            // 
            // lblScale
            // 
            lblScale.AutoSize = true;
            lblScale.Location = new System.Drawing.Point(10, 130);
            lblScale.Name = "lblScale";
            lblScale.Size = new System.Drawing.Size(58, 15);
            lblScale.TabIndex = 10;
            lblScale.Text = "Масштаб:";
            // 
            // numRZ
            // 
            numRZ.Location = new System.Drawing.Point(160, 73);
            numRZ.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numRZ.Minimum = new decimal(new int[] { 180, 0, 0, -2147483648 });
            numRZ.Name = "numRZ";
            numRZ.Size = new System.Drawing.Size(40, 23);
            numRZ.TabIndex = 9;
            // 
            // numRY
            // 
            numRY.Location = new System.Drawing.Point(115, 73);
            numRY.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numRY.Minimum = new decimal(new int[] { 180, 0, 0, -2147483648 });
            numRY.Name = "numRY";
            numRY.Size = new System.Drawing.Size(40, 23);
            numRY.TabIndex = 8;
            // 
            // numRX
            // 
            numRX.Location = new System.Drawing.Point(70, 73);
            numRX.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numRX.Minimum = new decimal(new int[] { 180, 0, 0, -2147483648 });
            numRX.Name = "numRX";
            numRX.Size = new System.Drawing.Size(40, 23);
            numRX.TabIndex = 7;
            // 
            // btnRotate
            // 
            btnRotate.Location = new System.Drawing.Point(10, 100);
            btnRotate.Name = "btnRotate";
            btnRotate.Size = new System.Drawing.Size(80, 23);
            btnRotate.TabIndex = 6;
            btnRotate.Text = "Применить";
            btnRotate.UseVisualStyleBackColor = true;
            btnRotate.Click += BtnRotate_Click;
            // 
            // lblRotate
            // 
            lblRotate.AutoSize = true;
            lblRotate.Location = new System.Drawing.Point(10, 75);
            lblRotate.Name = "lblRotate";
            lblRotate.Size = new System.Drawing.Size(54, 15);
            lblRotate.TabIndex = 5;
            lblRotate.Text = "Поворот:";
            // 
            // btnTranslate
            // 
            btnTranslate.Location = new System.Drawing.Point(10, 45);
            btnTranslate.Name = "btnTranslate";
            btnTranslate.Size = new System.Drawing.Size(80, 23);
            btnTranslate.TabIndex = 4;
            btnTranslate.Text = "Применить";
            btnTranslate.UseVisualStyleBackColor = true;
            btnTranslate.Click += BtnTranslate_Click;
            // 
            // numTZ
            // 
            numTZ.Location = new System.Drawing.Point(160, 18);
            numTZ.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numTZ.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
            numTZ.Name = "numTZ";
            numTZ.Size = new System.Drawing.Size(40, 23);
            numTZ.TabIndex = 3;
            // 
            // numTY
            // 
            numTY.Location = new System.Drawing.Point(115, 18);
            numTY.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numTY.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
            numTY.Name = "numTY";
            numTY.Size = new System.Drawing.Size(40, 23);
            numTY.TabIndex = 2;
            // 
            // numTX
            // 
            numTX.Location = new System.Drawing.Point(70, 18);
            numTX.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numTX.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
            numTX.Name = "numTX";
            numTX.Size = new System.Drawing.Size(40, 23);
            numTX.TabIndex = 1;
            // 
            // lblTranslate
            // 
            lblTranslate.AutoSize = true;
            lblTranslate.Location = new System.Drawing.Point(10, 20);
            lblTranslate.Name = "lblTranslate";
            lblTranslate.Size = new System.Drawing.Size(60, 15);
            lblTranslate.TabIndex = 0;
            lblTranslate.Text = "Смещение:";
            // 
            // grpReflection
            // 
            grpReflection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            grpReflection.Controls.Add(btnReflectYZ);
            grpReflection.Controls.Add(btnReflectXZ);
            grpReflection.Controls.Add(btnReflectXY);
            grpReflection.Location = new System.Drawing.Point(660, 166);
            grpReflection.Name = "grpReflection";
            grpReflection.Size = new System.Drawing.Size(128, 100);
            grpReflection.TabIndex = 13;
            grpReflection.TabStop = false;
            grpReflection.Text = "Отражение";
            // 
            // btnReflectYZ
            // 
            btnReflectYZ.Location = new System.Drawing.Point(10, 70);
            btnReflectYZ.Name = "btnReflectYZ";
            btnReflectYZ.Size = new System.Drawing.Size(80, 23);
            btnReflectYZ.TabIndex = 2;
            btnReflectYZ.Text = "YZ";
            btnReflectYZ.UseVisualStyleBackColor = true;
            btnReflectYZ.Click += BtnReflectYZ_Click;
            // 
            // btnReflectXZ
            // 
            btnReflectXZ.Location = new System.Drawing.Point(10, 45);
            btnReflectXZ.Name = "btnReflectXZ";
            btnReflectXZ.Size = new System.Drawing.Size(80, 23);
            btnReflectXZ.TabIndex = 1;
            btnReflectXZ.Text = "XZ";
            btnReflectXZ.UseVisualStyleBackColor = true;
            btnReflectXZ.Click += BtnReflectXZ_Click;
            // 
            // btnReflectXY
            // 
            btnReflectXY.Location = new System.Drawing.Point(10, 20);
            btnReflectXY.Name = "btnReflectXY";
            btnReflectXY.Size = new System.Drawing.Size(80, 23);
            btnReflectXY.TabIndex = 0;
            btnReflectXY.Text = "XY";
            btnReflectXY.UseVisualStyleBackColor = true;
            btnReflectXY.Click += BtnReflectXY_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(grpReflection);
            Controls.Add(grpTransform);
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
            ((System.ComponentModel.ISupportInitialize)numSZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTX).EndInit();
            grpTransform.ResumeLayout(false);
            grpTransform.PerformLayout();
            grpReflection.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}