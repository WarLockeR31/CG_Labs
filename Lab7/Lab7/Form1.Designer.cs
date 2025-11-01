namespace Lab7
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

        private System.Windows.Forms.GroupBox grpRotationAdvanced;
        private System.Windows.Forms.Button btnRotateArbitraryAxis;
        private System.Windows.Forms.Label lblArbitraryAxis;
        private System.Windows.Forms.NumericUpDown numAxisX2;
        private System.Windows.Forms.NumericUpDown numAxisY2;
        private System.Windows.Forms.NumericUpDown numAxisZ2;
        private System.Windows.Forms.NumericUpDown numAxisX1;
        private System.Windows.Forms.NumericUpDown numAxisY1;
        private System.Windows.Forms.NumericUpDown numAxisZ1;
        private System.Windows.Forms.Label lblAxisPoint2;
        private System.Windows.Forms.Label lblAxisPoint1;
        private System.Windows.Forms.NumericUpDown numArbitraryAngle;
        private System.Windows.Forms.Label lblArbitraryAngle;
        private System.Windows.Forms.Button btnRotateParallelAxis;
        private System.Windows.Forms.ComboBox cmbAxis;
        private System.Windows.Forms.NumericUpDown numParallelAngle;
        private System.Windows.Forms.Label lblParallelAngle;
        private System.Windows.Forms.Label lblParallelAxis;

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
			grpRotationAdvanced = new System.Windows.Forms.GroupBox();
			btnRotateArbitraryAxis = new System.Windows.Forms.Button();
			lblArbitraryAxis = new System.Windows.Forms.Label();
			numAxisX2 = new System.Windows.Forms.NumericUpDown();
			numAxisY2 = new System.Windows.Forms.NumericUpDown();
			numAxisZ2 = new System.Windows.Forms.NumericUpDown();
			numAxisX1 = new System.Windows.Forms.NumericUpDown();
			numAxisY1 = new System.Windows.Forms.NumericUpDown();
			numAxisZ1 = new System.Windows.Forms.NumericUpDown();
			lblAxisPoint2 = new System.Windows.Forms.Label();
			lblAxisPoint1 = new System.Windows.Forms.Label();
			numArbitraryAngle = new System.Windows.Forms.NumericUpDown();
			lblArbitraryAngle = new System.Windows.Forms.Label();
			btnRotateParallelAxis = new System.Windows.Forms.Button();
			cmbAxis = new System.Windows.Forms.ComboBox();
			numParallelAngle = new System.Windows.Forms.NumericUpDown();
			lblParallelAngle = new System.Windows.Forms.Label();
			lblParallelAxis = new System.Windows.Forms.Label();
			gb_lab6 = new System.Windows.Forms.GroupBox();
			gb_lab7 = new System.Windows.Forms.GroupBox();
			btn_modelSave = new System.Windows.Forms.Button();
			btn_modelLoad = new System.Windows.Forms.Button();
			btn_lab6 = new System.Windows.Forms.Button();
			btn_lab7 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			((System.ComponentModel.ISupportInitialize)tb_FOV).BeginInit();
			((System.ComponentModel.ISupportInitialize)tb_Distance).BeginInit();
			grpTransform.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numSZ).BeginInit();
			((System.ComponentModel.ISupportInitialize)numSY).BeginInit();
			((System.ComponentModel.ISupportInitialize)numSX).BeginInit();
			((System.ComponentModel.ISupportInitialize)numRZ).BeginInit();
			((System.ComponentModel.ISupportInitialize)numRY).BeginInit();
			((System.ComponentModel.ISupportInitialize)numRX).BeginInit();
			((System.ComponentModel.ISupportInitialize)numTZ).BeginInit();
			((System.ComponentModel.ISupportInitialize)numTY).BeginInit();
			((System.ComponentModel.ISupportInitialize)numTX).BeginInit();
			grpReflection.SuspendLayout();
			grpRotationAdvanced.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numAxisX2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numAxisY2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numAxisZ2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numAxisX1).BeginInit();
			((System.ComponentModel.ISupportInitialize)numAxisY1).BeginInit();
			((System.ComponentModel.ISupportInitialize)numAxisZ1).BeginInit();
			((System.ComponentModel.ISupportInitialize)numArbitraryAngle).BeginInit();
			((System.ComponentModel.ISupportInitialize)numParallelAngle).BeginInit();
			gb_lab6.SuspendLayout();
			gb_lab7.SuspendLayout();
			SuspendLayout();
			// 
			// pb
			// 
			pb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
			pb.BackColor = System.Drawing.SystemColors.ControlLight;
			pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pb.Location = new System.Drawing.Point(14, 16);
			pb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			pb.Name = "pb";
			pb.Size = new System.Drawing.Size(757, 728);
			pb.TabIndex = 0;
			pb.TabStop = false;
			pb.Paint += pb_Paint;
			// 
			// btn_Projection
			// 
			btn_Projection.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btn_Projection.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btn_Projection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btn_Projection.Location = new System.Drawing.Point(777, 16);
			btn_Projection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_Projection.Name = "btn_Projection";
			btn_Projection.Size = new System.Drawing.Size(270, 44);
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
			tb_FOV.Location = new System.Drawing.Point(777, 64);
			tb_FOV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			tb_FOV.Maximum = 180;
			tb_FOV.Minimum = 1;
			tb_FOV.Name = "tb_FOV";
			tb_FOV.Size = new System.Drawing.Size(226, 45);
			tb_FOV.TabIndex = 2;
			tb_FOV.TickStyle = System.Windows.Forms.TickStyle.None;
			tb_FOV.Value = 70;
			tb_FOV.Scroll += tb_FOV_Scroll;
			// 
			// lbl_FOV
			// 
			lbl_FOV.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			lbl_FOV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
			lbl_FOV.Location = new System.Drawing.Point(1011, 64);
			lbl_FOV.Name = "lbl_FOV";
			lbl_FOV.Size = new System.Drawing.Size(160, 51);
			lbl_FOV.TabIndex = 3;
			lbl_FOV.Text = "FOV: 70";
			lbl_FOV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_Distance
			// 
			lbl_Distance.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			lbl_Distance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
			lbl_Distance.Location = new System.Drawing.Point(1008, 115);
			lbl_Distance.Name = "lbl_Distance";
			lbl_Distance.Size = new System.Drawing.Size(160, 51);
			lbl_Distance.TabIndex = 5;
			lbl_Distance.Text = "Distance: 200";
			lbl_Distance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tb_Distance
			// 
			tb_Distance.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			tb_Distance.CausesValidation = false;
			tb_Distance.LargeChange = 10;
			tb_Distance.Location = new System.Drawing.Point(777, 115);
			tb_Distance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			tb_Distance.Maximum = 500;
			tb_Distance.Minimum = 1;
			tb_Distance.Name = "tb_Distance";
			tb_Distance.Size = new System.Drawing.Size(226, 45);
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
			btn_Tetra.Location = new System.Drawing.Point(777, 169);
			btn_Tetra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_Tetra.Name = "btn_Tetra";
			btn_Tetra.Size = new System.Drawing.Size(73, 44);
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
			btn_Octa.Location = new System.Drawing.Point(937, 169);
			btn_Octa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_Octa.Name = "btn_Octa";
			btn_Octa.Size = new System.Drawing.Size(73, 44);
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
			btn_Hexa.Location = new System.Drawing.Point(857, 169);
			btn_Hexa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_Hexa.Name = "btn_Hexa";
			btn_Hexa.Size = new System.Drawing.Size(73, 44);
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
			btn_Ico.Location = new System.Drawing.Point(1017, 169);
			btn_Ico.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_Ico.Name = "btn_Ico";
			btn_Ico.Size = new System.Drawing.Size(73, 44);
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
			btn_Dode.Location = new System.Drawing.Point(1097, 169);
			btn_Dode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_Dode.Name = "btn_Dode";
			btn_Dode.Size = new System.Drawing.Size(73, 44);
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
			btn_Reset.Location = new System.Drawing.Point(1053, 16);
			btn_Reset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_Reset.Name = "btn_Reset";
			btn_Reset.Size = new System.Drawing.Size(117, 44);
			btn_Reset.TabIndex = 11;
			btn_Reset.Text = "Reset";
			btn_Reset.UseVisualStyleBackColor = false;
			btn_Reset.Click += btn_Reset_Click;
			// 
			// grpTransform
			// 
			grpTransform.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
			grpTransform.Location = new System.Drawing.Point(0, 15);
			grpTransform.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			grpTransform.Name = "grpTransform";
			grpTransform.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			grpTransform.Size = new System.Drawing.Size(240, 240);
			grpTransform.TabIndex = 12;
			grpTransform.TabStop = false;
			grpTransform.Text = "Аффинные преобразования";
			// 
			// numSZ
			// 
			numSZ.DecimalPlaces = 1;
			numSZ.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
			numSZ.Location = new System.Drawing.Point(183, 171);
			numSZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numSZ.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			numSZ.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
			numSZ.Name = "numSZ";
			numSZ.Size = new System.Drawing.Size(46, 23);
			numSZ.TabIndex = 14;
			numSZ.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// numSY
			// 
			numSY.DecimalPlaces = 1;
			numSY.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
			numSY.Location = new System.Drawing.Point(131, 171);
			numSY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numSY.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			numSY.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
			numSY.Name = "numSY";
			numSY.Size = new System.Drawing.Size(46, 23);
			numSY.TabIndex = 13;
			numSY.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// numSX
			// 
			numSX.DecimalPlaces = 1;
			numSX.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
			numSX.Location = new System.Drawing.Point(80, 171);
			numSX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numSX.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			numSX.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
			numSX.Name = "numSX";
			numSX.Size = new System.Drawing.Size(46, 23);
			numSX.TabIndex = 12;
			numSX.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// btnScale
			// 
			btnScale.Location = new System.Drawing.Point(11, 204);
			btnScale.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnScale.Name = "btnScale";
			btnScale.Size = new System.Drawing.Size(115, 31);
			btnScale.TabIndex = 11;
			btnScale.Text = "От центра";
			btnScale.UseVisualStyleBackColor = true;
			btnScale.Click += BtnScale_Click;
			// 
			// lblScale
			// 
			lblScale.AutoSize = true;
			lblScale.Location = new System.Drawing.Point(11, 173);
			lblScale.Name = "lblScale";
			lblScale.Size = new System.Drawing.Size(62, 15);
			lblScale.TabIndex = 10;
			lblScale.Text = "Масштаб:";
			// 
			// numRZ
			// 
			numRZ.Location = new System.Drawing.Point(183, 97);
			numRZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numRZ.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
			numRZ.Minimum = new decimal(new int[] { 180, 0, 0, -2147483648 });
			numRZ.Name = "numRZ";
			numRZ.Size = new System.Drawing.Size(46, 23);
			numRZ.TabIndex = 9;
			numRZ.Value = new decimal(new int[] { 180, 0, 0, 0 });
			// 
			// numRY
			// 
			numRY.Location = new System.Drawing.Point(131, 97);
			numRY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numRY.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
			numRY.Minimum = new decimal(new int[] { 180, 0, 0, -2147483648 });
			numRY.Name = "numRY";
			numRY.Size = new System.Drawing.Size(46, 23);
			numRY.TabIndex = 8;
			numRY.Value = new decimal(new int[] { 180, 0, 0, 0 });
			// 
			// numRX
			// 
			numRX.Location = new System.Drawing.Point(80, 97);
			numRX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numRX.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
			numRX.Minimum = new decimal(new int[] { 180, 0, 0, -2147483648 });
			numRX.Name = "numRX";
			numRX.Size = new System.Drawing.Size(46, 23);
			numRX.TabIndex = 7;
			numRX.Value = new decimal(new int[] { 180, 0, 0, 0 });
			// 
			// btnRotate
			// 
			btnRotate.Location = new System.Drawing.Point(11, 133);
			btnRotate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnRotate.Name = "btnRotate";
			btnRotate.Size = new System.Drawing.Size(115, 31);
			btnRotate.TabIndex = 6;
			btnRotate.Text = "Применить";
			btnRotate.UseVisualStyleBackColor = true;
			btnRotate.Click += BtnRotate_Click;
			// 
			// lblRotate
			// 
			lblRotate.AutoSize = true;
			lblRotate.Location = new System.Drawing.Point(11, 100);
			lblRotate.Name = "lblRotate";
			lblRotate.Size = new System.Drawing.Size(58, 15);
			lblRotate.TabIndex = 5;
			lblRotate.Text = "Поворот:";
			// 
			// btnTranslate
			// 
			btnTranslate.Location = new System.Drawing.Point(11, 60);
			btnTranslate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnTranslate.Name = "btnTranslate";
			btnTranslate.Size = new System.Drawing.Size(115, 31);
			btnTranslate.TabIndex = 4;
			btnTranslate.Text = "Применить";
			btnTranslate.UseVisualStyleBackColor = true;
			btnTranslate.Click += BtnTranslate_Click;
			// 
			// numTZ
			// 
			numTZ.Location = new System.Drawing.Point(183, 24);
			numTZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numTZ.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
			numTZ.Name = "numTZ";
			numTZ.Size = new System.Drawing.Size(46, 23);
			numTZ.TabIndex = 3;
			numTZ.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// numTY
			// 
			numTY.Location = new System.Drawing.Point(131, 24);
			numTY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numTY.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
			numTY.Name = "numTY";
			numTY.Size = new System.Drawing.Size(46, 23);
			numTY.TabIndex = 2;
			numTY.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// numTX
			// 
			numTX.Location = new System.Drawing.Point(80, 24);
			numTX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numTX.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
			numTX.Name = "numTX";
			numTX.Size = new System.Drawing.Size(46, 23);
			numTX.TabIndex = 1;
			numTX.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// lblTranslate
			// 
			lblTranslate.AutoSize = true;
			lblTranslate.Location = new System.Drawing.Point(11, 27);
			lblTranslate.Name = "lblTranslate";
			lblTranslate.Size = new System.Drawing.Size(70, 15);
			lblTranslate.TabIndex = 0;
			lblTranslate.Text = "Смещение:";
			// 
			// grpReflection
			// 
			grpReflection.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			grpReflection.Controls.Add(btnReflectYZ);
			grpReflection.Controls.Add(btnReflectXZ);
			grpReflection.Controls.Add(btnReflectXY);
			grpReflection.Location = new System.Drawing.Point(245, 15);
			grpReflection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			grpReflection.Name = "grpReflection";
			grpReflection.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			grpReflection.Size = new System.Drawing.Size(146, 240);
			grpReflection.TabIndex = 13;
			grpReflection.TabStop = false;
			grpReflection.Text = "Отражение";
			// 
			// btnReflectYZ
			// 
			btnReflectYZ.Location = new System.Drawing.Point(11, 93);
			btnReflectYZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnReflectYZ.Name = "btnReflectYZ";
			btnReflectYZ.Size = new System.Drawing.Size(91, 31);
			btnReflectYZ.TabIndex = 2;
			btnReflectYZ.Text = "YZ";
			btnReflectYZ.UseVisualStyleBackColor = true;
			btnReflectYZ.Click += BtnReflectYZ_Click;
			// 
			// btnReflectXZ
			// 
			btnReflectXZ.Location = new System.Drawing.Point(11, 60);
			btnReflectXZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnReflectXZ.Name = "btnReflectXZ";
			btnReflectXZ.Size = new System.Drawing.Size(91, 31);
			btnReflectXZ.TabIndex = 1;
			btnReflectXZ.Text = "XZ";
			btnReflectXZ.UseVisualStyleBackColor = true;
			btnReflectXZ.Click += BtnReflectXZ_Click;
			// 
			// btnReflectXY
			// 
			btnReflectXY.Location = new System.Drawing.Point(11, 27);
			btnReflectXY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnReflectXY.Name = "btnReflectXY";
			btnReflectXY.Size = new System.Drawing.Size(91, 31);
			btnReflectXY.TabIndex = 0;
			btnReflectXY.Text = "XY";
			btnReflectXY.UseVisualStyleBackColor = true;
			btnReflectXY.Click += BtnReflectXY_Click;
			// 
			// grpRotationAdvanced
			// 
			grpRotationAdvanced.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			grpRotationAdvanced.Controls.Add(btnRotateArbitraryAxis);
			grpRotationAdvanced.Controls.Add(lblArbitraryAxis);
			grpRotationAdvanced.Controls.Add(numAxisX2);
			grpRotationAdvanced.Controls.Add(numAxisY2);
			grpRotationAdvanced.Controls.Add(numAxisZ2);
			grpRotationAdvanced.Controls.Add(numAxisX1);
			grpRotationAdvanced.Controls.Add(numAxisY1);
			grpRotationAdvanced.Controls.Add(numAxisZ1);
			grpRotationAdvanced.Controls.Add(lblAxisPoint2);
			grpRotationAdvanced.Controls.Add(lblAxisPoint1);
			grpRotationAdvanced.Controls.Add(numArbitraryAngle);
			grpRotationAdvanced.Controls.Add(lblArbitraryAngle);
			grpRotationAdvanced.Controls.Add(btnRotateParallelAxis);
			grpRotationAdvanced.Controls.Add(cmbAxis);
			grpRotationAdvanced.Controls.Add(numParallelAngle);
			grpRotationAdvanced.Controls.Add(lblParallelAngle);
			grpRotationAdvanced.Controls.Add(lblParallelAxis);
			grpRotationAdvanced.Location = new System.Drawing.Point(0, 263);
			grpRotationAdvanced.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			grpRotationAdvanced.Name = "grpRotationAdvanced";
			grpRotationAdvanced.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			grpRotationAdvanced.Size = new System.Drawing.Size(393, 213);
			grpRotationAdvanced.TabIndex = 14;
			grpRotationAdvanced.TabStop = false;
			grpRotationAdvanced.Text = "Специальные вращения";
			// 
			// btnRotateArbitraryAxis
			// 
			btnRotateArbitraryAxis.Location = new System.Drawing.Point(286, 173);
			btnRotateArbitraryAxis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnRotateArbitraryAxis.Name = "btnRotateArbitraryAxis";
			btnRotateArbitraryAxis.Size = new System.Drawing.Size(91, 31);
			btnRotateArbitraryAxis.TabIndex = 16;
			btnRotateArbitraryAxis.Text = "Применить";
			btnRotateArbitraryAxis.UseVisualStyleBackColor = true;
			btnRotateArbitraryAxis.Click += BtnRotateArbitraryAxis_Click;
			// 
			// lblArbitraryAxis
			// 
			lblArbitraryAxis.AutoSize = true;
			lblArbitraryAxis.Location = new System.Drawing.Point(6, 113);
			lblArbitraryAxis.Name = "lblArbitraryAxis";
			lblArbitraryAxis.Size = new System.Drawing.Size(150, 15);
			lblArbitraryAxis.TabIndex = 15;
			lblArbitraryAxis.Text = "Произвольная ось (X,Y,Z):";
			// 
			// numAxisX2
			// 
			numAxisX2.Location = new System.Drawing.Point(80, 173);
			numAxisX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numAxisX2.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
			numAxisX2.Name = "numAxisX2";
			numAxisX2.Size = new System.Drawing.Size(46, 23);
			numAxisX2.TabIndex = 14;
			numAxisX2.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// numAxisY2
			// 
			numAxisY2.Location = new System.Drawing.Point(132, 173);
			numAxisY2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numAxisY2.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
			numAxisY2.Name = "numAxisY2";
			numAxisY2.Size = new System.Drawing.Size(46, 23);
			numAxisY2.TabIndex = 13;
			numAxisY2.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// numAxisZ2
			// 
			numAxisZ2.Location = new System.Drawing.Point(187, 173);
			numAxisZ2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numAxisZ2.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
			numAxisZ2.Name = "numAxisZ2";
			numAxisZ2.Size = new System.Drawing.Size(46, 23);
			numAxisZ2.TabIndex = 12;
			numAxisZ2.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// numAxisX1
			// 
			numAxisX1.Location = new System.Drawing.Point(83, 138);
			numAxisX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numAxisX1.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
			numAxisX1.Name = "numAxisX1";
			numAxisX1.Size = new System.Drawing.Size(46, 23);
			numAxisX1.TabIndex = 11;
			numAxisX1.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// numAxisY1
			// 
			numAxisY1.Location = new System.Drawing.Point(135, 138);
			numAxisY1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numAxisY1.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
			numAxisY1.Name = "numAxisY1";
			numAxisY1.Size = new System.Drawing.Size(46, 23);
			numAxisY1.TabIndex = 10;
			numAxisY1.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// numAxisZ1
			// 
			numAxisZ1.Location = new System.Drawing.Point(187, 138);
			numAxisZ1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numAxisZ1.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
			numAxisZ1.Name = "numAxisZ1";
			numAxisZ1.Size = new System.Drawing.Size(46, 23);
			numAxisZ1.TabIndex = 9;
			numAxisZ1.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// lblAxisPoint2
			// 
			lblAxisPoint2.AutoSize = true;
			lblAxisPoint2.Location = new System.Drawing.Point(11, 177);
			lblAxisPoint2.Name = "lblAxisPoint2";
			lblAxisPoint2.Size = new System.Drawing.Size(52, 15);
			lblAxisPoint2.TabIndex = 8;
			lblAxisPoint2.Text = "Точка 2:";
			// 
			// lblAxisPoint1
			// 
			lblAxisPoint1.AutoSize = true;
			lblAxisPoint1.Location = new System.Drawing.Point(11, 138);
			lblAxisPoint1.Name = "lblAxisPoint1";
			lblAxisPoint1.Size = new System.Drawing.Size(52, 15);
			lblAxisPoint1.TabIndex = 7;
			lblAxisPoint1.Text = "Точка 1:";
			// 
			// numArbitraryAngle
			// 
			numArbitraryAngle.Location = new System.Drawing.Point(308, 138);
			numArbitraryAngle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numArbitraryAngle.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
			numArbitraryAngle.Minimum = new decimal(new int[] { 180, 0, 0, -2147483648 });
			numArbitraryAngle.Name = "numArbitraryAngle";
			numArbitraryAngle.Size = new System.Drawing.Size(46, 23);
			numArbitraryAngle.TabIndex = 6;
			numArbitraryAngle.Value = new decimal(new int[] { 180, 0, 0, 0 });
			// 
			// lblArbitraryAngle
			// 
			lblArbitraryAngle.AutoSize = true;
			lblArbitraryAngle.Location = new System.Drawing.Point(258, 138);
			lblArbitraryAngle.Name = "lblArbitraryAngle";
			lblArbitraryAngle.Size = new System.Drawing.Size(36, 15);
			lblArbitraryAngle.TabIndex = 5;
			lblArbitraryAngle.Text = "Угол:";
			// 
			// btnRotateParallelAxis
			// 
			btnRotateParallelAxis.Location = new System.Drawing.Point(263, 36);
			btnRotateParallelAxis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnRotateParallelAxis.Name = "btnRotateParallelAxis";
			btnRotateParallelAxis.Size = new System.Drawing.Size(91, 31);
			btnRotateParallelAxis.TabIndex = 4;
			btnRotateParallelAxis.Text = "Применить";
			btnRotateParallelAxis.UseVisualStyleBackColor = true;
			btnRotateParallelAxis.Click += BtnRotateParallelAxis_Click;
			// 
			// cmbAxis
			// 
			cmbAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmbAxis.FormattingEnabled = true;
			cmbAxis.Items.AddRange(new object[] { "X", "Y", "Z" });
			cmbAxis.Location = new System.Drawing.Point(188, 33);
			cmbAxis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			cmbAxis.Name = "cmbAxis";
			cmbAxis.Size = new System.Drawing.Size(45, 23);
			cmbAxis.TabIndex = 3;
			// 
			// numParallelAngle
			// 
			numParallelAngle.Location = new System.Drawing.Point(83, 64);
			numParallelAngle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numParallelAngle.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
			numParallelAngle.Minimum = new decimal(new int[] { 180, 0, 0, -2147483648 });
			numParallelAngle.Name = "numParallelAngle";
			numParallelAngle.Size = new System.Drawing.Size(46, 23);
			numParallelAngle.TabIndex = 2;
			numParallelAngle.Value = new decimal(new int[] { 180, 0, 0, 0 });
			// 
			// lblParallelAngle
			// 
			lblParallelAngle.AutoSize = true;
			lblParallelAngle.Location = new System.Drawing.Point(29, 71);
			lblParallelAngle.Name = "lblParallelAngle";
			lblParallelAngle.Size = new System.Drawing.Size(36, 15);
			lblParallelAngle.TabIndex = 1;
			lblParallelAngle.Text = "Угол:";
			// 
			// lblParallelAxis
			// 
			lblParallelAxis.AutoSize = true;
			lblParallelAxis.Location = new System.Drawing.Point(18, 36);
			lblParallelAxis.Name = "lblParallelAxis";
			lblParallelAxis.Size = new System.Drawing.Size(128, 15);
			lblParallelAxis.TabIndex = 0;
			lblParallelAxis.Text = "Ось через центр || OX:";
			// 
			// gb_lab6
			// 
			gb_lab6.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			gb_lab6.Controls.Add(grpTransform);
			gb_lab6.Controls.Add(grpReflection);
			gb_lab6.Controls.Add(grpRotationAdvanced);
			gb_lab6.Location = new System.Drawing.Point(777, 268);
			gb_lab6.Name = "gb_lab6";
			gb_lab6.Size = new System.Drawing.Size(391, 476);
			gb_lab6.TabIndex = 15;
			gb_lab6.TabStop = false;
			gb_lab6.Visible = false;
			// 
			// gb_lab7
			// 
			gb_lab7.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			gb_lab7.Controls.Add(btn_modelSave);
			gb_lab7.Controls.Add(btn_modelLoad);
			gb_lab7.Location = new System.Drawing.Point(777, 268);
			gb_lab7.Name = "gb_lab7";
			gb_lab7.Size = new System.Drawing.Size(391, 476);
			gb_lab7.TabIndex = 16;
			gb_lab7.TabStop = false;
			gb_lab7.Visible = false;
			// 
			// btn_modelSave
			// 
			btn_modelSave.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btn_modelSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btn_modelSave.Enabled = false;
			btn_modelSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btn_modelSave.Location = new System.Drawing.Point(196, 15);
			btn_modelSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_modelSave.Name = "btn_modelSave";
			btn_modelSave.Size = new System.Drawing.Size(189, 44);
			btn_modelSave.TabIndex = 20;
			btn_modelSave.Text = "Save";
			btn_modelSave.UseVisualStyleBackColor = false;
			btn_modelSave.Click += btn_modelSave_Click;
			// 
			// btn_modelLoad
			// 
			btn_modelLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btn_modelLoad.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btn_modelLoad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btn_modelLoad.Location = new System.Drawing.Point(6, 15);
			btn_modelLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_modelLoad.Name = "btn_modelLoad";
			btn_modelLoad.Size = new System.Drawing.Size(189, 44);
			btn_modelLoad.TabIndex = 19;
			btn_modelLoad.Text = "Load";
			btn_modelLoad.UseVisualStyleBackColor = false;
			btn_modelLoad.Click += btn_modelLoad_Click;
			// 
			// btn_lab6
			// 
			btn_lab6.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btn_lab6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btn_lab6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btn_lab6.Location = new System.Drawing.Point(814, 221);
			btn_lab6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_lab6.Name = "btn_lab6";
			btn_lab6.Size = new System.Drawing.Size(153, 44);
			btn_lab6.TabIndex = 17;
			btn_lab6.Text = "Lab6";
			btn_lab6.UseVisualStyleBackColor = false;
			btn_lab6.Click += btn_lab6_Click;
			// 
			// btn_lab7
			// 
			btn_lab7.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			btn_lab7.BackColor = System.Drawing.SystemColors.ControlLightLight;
			btn_lab7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			btn_lab7.Location = new System.Drawing.Point(973, 221);
			btn_lab7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btn_lab7.Name = "btn_lab7";
			btn_lab7.Size = new System.Drawing.Size(151, 44);
			btn_lab7.TabIndex = 18;
			btn_lab7.Text = "Lab7";
			btn_lab7.UseVisualStyleBackColor = false;
			btn_lab7.Click += btn_lab7_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1184, 761);
			Controls.Add(btn_lab7);
			Controls.Add(btn_lab6);
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
			Controls.Add(gb_lab6);
			Controls.Add(gb_lab7);
			Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			MinimumSize = new System.Drawing.Size(1000, 800);
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			((System.ComponentModel.ISupportInitialize)tb_FOV).EndInit();
			((System.ComponentModel.ISupportInitialize)tb_Distance).EndInit();
			grpTransform.ResumeLayout(false);
			grpTransform.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numSZ).EndInit();
			((System.ComponentModel.ISupportInitialize)numSY).EndInit();
			((System.ComponentModel.ISupportInitialize)numSX).EndInit();
			((System.ComponentModel.ISupportInitialize)numRZ).EndInit();
			((System.ComponentModel.ISupportInitialize)numRY).EndInit();
			((System.ComponentModel.ISupportInitialize)numRX).EndInit();
			((System.ComponentModel.ISupportInitialize)numTZ).EndInit();
			((System.ComponentModel.ISupportInitialize)numTY).EndInit();
			((System.ComponentModel.ISupportInitialize)numTX).EndInit();
			grpReflection.ResumeLayout(false);
			grpRotationAdvanced.ResumeLayout(false);
			grpRotationAdvanced.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numAxisX2).EndInit();
			((System.ComponentModel.ISupportInitialize)numAxisY2).EndInit();
			((System.ComponentModel.ISupportInitialize)numAxisZ2).EndInit();
			((System.ComponentModel.ISupportInitialize)numAxisX1).EndInit();
			((System.ComponentModel.ISupportInitialize)numAxisY1).EndInit();
			((System.ComponentModel.ISupportInitialize)numAxisZ1).EndInit();
			((System.ComponentModel.ISupportInitialize)numArbitraryAngle).EndInit();
			((System.ComponentModel.ISupportInitialize)numParallelAngle).EndInit();
			gb_lab6.ResumeLayout(false);
			gb_lab7.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		private System.Windows.Forms.Button btn_modelSave;

		private System.Windows.Forms.Button btn_modelLoad;

		private System.Windows.Forms.GroupBox gb_lab7;
		private System.Windows.Forms.Button btn_lab6;
		private System.Windows.Forms.Button btn_lab7;

		private System.Windows.Forms.GroupBox gb_lab6;

		#endregion
    }
}