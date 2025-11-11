namespace Lab8
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

        private System.Windows.Forms.GroupBox gb_lab6;
        private System.Windows.Forms.GroupBox gb_lab7;
        private System.Windows.Forms.Button btn_Surface;
        private System.Windows.Forms.NumericUpDown numNY;
        private System.Windows.Forms.NumericUpDown numNX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numY1;
        private System.Windows.Forms.NumericUpDown numY0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numX1;
        private System.Windows.Forms.NumericUpDown numX0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFunction;
        private System.Windows.Forms.Button btn_modelSave;
        private System.Windows.Forms.Button btn_modelLoad;
        private System.Windows.Forms.Button btn_lab6;
        private System.Windows.Forms.Button btn_lab7;

        // Новые элементы для фигуры вращения
        private System.Windows.Forms.DataGridView dgvProfile;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.Button btnClearPoints;
        private System.Windows.Forms.ComboBox cmbRotationAxis;
        private System.Windows.Forms.Label lblAxis;
        private System.Windows.Forms.NumericUpDown numSegments;
        private System.Windows.Forms.Label lblSegments;
        private System.Windows.Forms.Button btnBuildRotation;
        private System.Windows.Forms.Button btnAddSample;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pb = new PictureBox();
            btn_Projection = new Button();
            tb_FOV = new TrackBar();
            lbl_FOV = new Label();
            lbl_Distance = new Label();
            tb_Distance = new TrackBar();
            btn_Tetra = new Button();
            btn_Octa = new Button();
            btn_Hexa = new Button();
            btn_Ico = new Button();
            btn_Dode = new Button();
            btn_Reset = new Button();
            grpTransform = new GroupBox();
            numSZ = new NumericUpDown();
            numSY = new NumericUpDown();
            numSX = new NumericUpDown();
            btnScale = new Button();
            lblScale = new Label();
            numRZ = new NumericUpDown();
            numRY = new NumericUpDown();
            numRX = new NumericUpDown();
            btnRotate = new Button();
            lblRotate = new Label();
            btnTranslate = new Button();
            numTZ = new NumericUpDown();
            numTY = new NumericUpDown();
            numTX = new NumericUpDown();
            lblTranslate = new Label();
            grpReflection = new GroupBox();
            btnReflectYZ = new Button();
            btnReflectXZ = new Button();
            btnReflectXY = new Button();
            grpRotationAdvanced = new GroupBox();
            btnRotateArbitraryAxis = new Button();
            lblArbitraryAxis = new Label();
            numAxisX2 = new NumericUpDown();
            numAxisY2 = new NumericUpDown();
            numAxisZ2 = new NumericUpDown();
            numAxisX1 = new NumericUpDown();
            numAxisY1 = new NumericUpDown();
            numAxisZ1 = new NumericUpDown();
            lblAxisPoint2 = new Label();
            lblAxisPoint1 = new Label();
            numArbitraryAngle = new NumericUpDown();
            lblArbitraryAngle = new Label();
            btnRotateParallelAxis = new Button();
            cmbAxis = new ComboBox();
            numParallelAngle = new NumericUpDown();
            lblParallelAngle = new Label();
            lblParallelAxis = new Label();
            gb_lab6 = new GroupBox();
            gb_lab7 = new GroupBox();
            btnAddSample = new Button();
            btnBuildRotation = new Button();
            numSegments = new NumericUpDown();
            lblSegments = new Label();
            cmbRotationAxis = new ComboBox();
            lblAxis = new Label();
            btnClearPoints = new Button();
            btnAddPoint = new Button();
            dgvProfile = new DataGridView();
            btn_Surface = new Button();
            numNY = new NumericUpDown();
            numNX = new NumericUpDown();
            label4 = new Label();
            numY1 = new NumericUpDown();
            numY0 = new NumericUpDown();
            label3 = new Label();
            numX1 = new NumericUpDown();
            numX0 = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            cmbFunction = new ComboBox();
            btn_modelSave = new Button();
            btn_modelLoad = new Button();
            btn_lab6 = new Button();
            btn_lab7 = new Button();
            gb_lab8 = new GroupBox();
            btn_normalsDisplay = new Button();
            btn_cullBackfaces = new Button();
            lbl_camYaw = new Label();
            tb_camYaw = new TrackBar();
            lbl_camPitch = new Label();
            tb_camPitch = new TrackBar();
            btn_lab8 = new Button();
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
            ((System.ComponentModel.ISupportInitialize)numSegments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numY1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numY0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numX1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numX0).BeginInit();
            gb_lab8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tb_camYaw).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_camPitch).BeginInit();
            SuspendLayout();
            // 
            // pb
            // 
            pb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pb.BackColor = SystemColors.ControlLight;
            pb.BorderStyle = BorderStyle.FixedSingle;
            pb.Location = new Point(14, 16);
            pb.Margin = new Padding(3, 4, 3, 4);
            pb.Name = "pb";
            pb.Size = new Size(557, 736);
            pb.TabIndex = 0;
            pb.TabStop = false;
            pb.Paint += pb_Paint;
            // 
            // btn_Projection
            // 
            btn_Projection.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Projection.BackColor = SystemColors.ControlLightLight;
            btn_Projection.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            btn_Projection.Location = new Point(577, 16);
            btn_Projection.Margin = new Padding(3, 4, 3, 4);
            btn_Projection.Name = "btn_Projection";
            btn_Projection.Size = new Size(270, 44);
            btn_Projection.TabIndex = 1;
            btn_Projection.Text = "Projection: Perspective";
            btn_Projection.UseVisualStyleBackColor = false;
            btn_Projection.Click += btnProjection_Click;
            // 
            // tb_FOV
            // 
            tb_FOV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_FOV.CausesValidation = false;
            tb_FOV.LargeChange = 10;
            tb_FOV.Location = new Point(577, 64);
            tb_FOV.Margin = new Padding(3, 4, 3, 4);
            tb_FOV.Maximum = 180;
            tb_FOV.Minimum = 1;
            tb_FOV.Name = "tb_FOV";
            tb_FOV.Size = new Size(226, 56);
            tb_FOV.TabIndex = 2;
            tb_FOV.TickStyle = TickStyle.None;
            tb_FOV.Value = 70;
            tb_FOV.Scroll += tb_FOV_Scroll;
            // 
            // lbl_FOV
            // 
            lbl_FOV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_FOV.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbl_FOV.Location = new Point(811, 64);
            lbl_FOV.Name = "lbl_FOV";
            lbl_FOV.Size = new Size(160, 51);
            lbl_FOV.TabIndex = 3;
            lbl_FOV.Text = "FOV: 70";
            lbl_FOV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Distance
            // 
            lbl_Distance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_Distance.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbl_Distance.Location = new Point(808, 115);
            lbl_Distance.Name = "lbl_Distance";
            lbl_Distance.Size = new Size(160, 51);
            lbl_Distance.TabIndex = 5;
            lbl_Distance.Text = "Distance: 200";
            lbl_Distance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_Distance
            // 
            tb_Distance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_Distance.CausesValidation = false;
            tb_Distance.LargeChange = 10;
            tb_Distance.Location = new Point(577, 115);
            tb_Distance.Margin = new Padding(3, 4, 3, 4);
            tb_Distance.Maximum = 500;
            tb_Distance.Minimum = 1;
            tb_Distance.Name = "tb_Distance";
            tb_Distance.Size = new Size(226, 56);
            tb_Distance.TabIndex = 4;
            tb_Distance.TickStyle = TickStyle.None;
            tb_Distance.Value = 200;
            tb_Distance.Scroll += tb_Distance_Scroll;
            // 
            // btn_Tetra
            // 
            btn_Tetra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Tetra.BackColor = SystemColors.ControlLightLight;
            btn_Tetra.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            btn_Tetra.Location = new Point(577, 169);
            btn_Tetra.Margin = new Padding(3, 4, 3, 4);
            btn_Tetra.Name = "btn_Tetra";
            btn_Tetra.Size = new Size(73, 44);
            btn_Tetra.TabIndex = 6;
            btn_Tetra.Text = "Tetra";
            btn_Tetra.UseVisualStyleBackColor = false;
            btn_Tetra.Click += btn_Tetra_Click;
            // 
            // btn_Octa
            // 
            btn_Octa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Octa.BackColor = SystemColors.ControlLightLight;
            btn_Octa.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            btn_Octa.Location = new Point(737, 169);
            btn_Octa.Margin = new Padding(3, 4, 3, 4);
            btn_Octa.Name = "btn_Octa";
            btn_Octa.Size = new Size(73, 44);
            btn_Octa.TabIndex = 7;
            btn_Octa.Text = "Octa";
            btn_Octa.UseVisualStyleBackColor = false;
            btn_Octa.Click += btn_Octa_Click;
            // 
            // btn_Hexa
            // 
            btn_Hexa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Hexa.BackColor = SystemColors.ControlLightLight;
            btn_Hexa.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            btn_Hexa.Location = new Point(657, 169);
            btn_Hexa.Margin = new Padding(3, 4, 3, 4);
            btn_Hexa.Name = "btn_Hexa";
            btn_Hexa.Size = new Size(73, 44);
            btn_Hexa.TabIndex = 8;
            btn_Hexa.Text = "Hexa";
            btn_Hexa.UseVisualStyleBackColor = false;
            btn_Hexa.Click += btn_Hexa_Click;
            // 
            // btn_Ico
            // 
            btn_Ico.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Ico.BackColor = SystemColors.ControlLightLight;
            btn_Ico.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            btn_Ico.Location = new Point(817, 169);
            btn_Ico.Margin = new Padding(3, 4, 3, 4);
            btn_Ico.Name = "btn_Ico";
            btn_Ico.Size = new Size(73, 44);
            btn_Ico.TabIndex = 9;
            btn_Ico.Text = "Ico";
            btn_Ico.UseVisualStyleBackColor = false;
            btn_Ico.Click += btn_Ico_Click;
            // 
            // btn_Dode
            // 
            btn_Dode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Dode.BackColor = SystemColors.ControlLightLight;
            btn_Dode.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            btn_Dode.Location = new Point(897, 169);
            btn_Dode.Margin = new Padding(3, 4, 3, 4);
            btn_Dode.Name = "btn_Dode";
            btn_Dode.Size = new Size(73, 44);
            btn_Dode.TabIndex = 10;
            btn_Dode.Text = "Dode";
            btn_Dode.UseVisualStyleBackColor = false;
            btn_Dode.Click += btn_Dode_Click;
            // 
            // btn_Reset
            // 
            btn_Reset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Reset.BackColor = SystemColors.ControlLightLight;
            btn_Reset.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            btn_Reset.Location = new Point(853, 16);
            btn_Reset.Margin = new Padding(3, 4, 3, 4);
            btn_Reset.Name = "btn_Reset";
            btn_Reset.Size = new Size(117, 44);
            btn_Reset.TabIndex = 11;
            btn_Reset.Text = "Reset";
            btn_Reset.UseVisualStyleBackColor = false;
            btn_Reset.Click += btn_Reset_Click;
            // 
            // grpTransform
            // 
            grpTransform.Anchor = AnchorStyles.Bottom;
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
            grpTransform.Location = new Point(0, 15);
            grpTransform.Margin = new Padding(3, 4, 3, 4);
            grpTransform.Name = "grpTransform";
            grpTransform.Padding = new Padding(3, 4, 3, 4);
            grpTransform.Size = new Size(240, 240);
            grpTransform.TabIndex = 12;
            grpTransform.TabStop = false;
            grpTransform.Text = "Аффинные преобразования";
            // 
            // numSZ
            // 
            numSZ.DecimalPlaces = 1;
            numSZ.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numSZ.Location = new Point(183, 171);
            numSZ.Margin = new Padding(3, 4, 3, 4);
            numSZ.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numSZ.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numSZ.Name = "numSZ";
            numSZ.Size = new Size(46, 27);
            numSZ.TabIndex = 14;
            numSZ.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numSY
            // 
            numSY.DecimalPlaces = 1;
            numSY.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numSY.Location = new Point(131, 171);
            numSY.Margin = new Padding(3, 4, 3, 4);
            numSY.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numSY.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numSY.Name = "numSY";
            numSY.Size = new Size(46, 27);
            numSY.TabIndex = 13;
            numSY.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numSX
            // 
            numSX.DecimalPlaces = 1;
            numSX.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numSX.Location = new Point(80, 171);
            numSX.Margin = new Padding(3, 4, 3, 4);
            numSX.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numSX.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numSX.Name = "numSX";
            numSX.Size = new Size(46, 27);
            numSX.TabIndex = 12;
            numSX.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnScale
            // 
            btnScale.Location = new Point(11, 204);
            btnScale.Margin = new Padding(3, 4, 3, 4);
            btnScale.Name = "btnScale";
            btnScale.Size = new Size(115, 31);
            btnScale.TabIndex = 11;
            btnScale.Text = "От центра";
            btnScale.UseVisualStyleBackColor = true;
            btnScale.Click += BtnScale_Click;
            // 
            // lblScale
            // 
            lblScale.AutoSize = true;
            lblScale.Location = new Point(11, 173);
            lblScale.Name = "lblScale";
            lblScale.Size = new Size(75, 20);
            lblScale.TabIndex = 10;
            lblScale.Text = "Масштаб:";
            // 
            // numRZ
            // 
            numRZ.Location = new Point(183, 97);
            numRZ.Margin = new Padding(3, 4, 3, 4);
            numRZ.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numRZ.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            numRZ.Name = "numRZ";
            numRZ.Size = new Size(46, 27);
            numRZ.TabIndex = 9;
            numRZ.Value = new decimal(new int[] { 180, 0, 0, 0 });
            // 
            // numRY
            // 
            numRY.Location = new Point(131, 97);
            numRY.Margin = new Padding(3, 4, 3, 4);
            numRY.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numRY.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            numRY.Name = "numRY";
            numRY.Size = new Size(46, 27);
            numRY.TabIndex = 8;
            numRY.Value = new decimal(new int[] { 180, 0, 0, 0 });
            // 
            // numRX
            // 
            numRX.Location = new Point(80, 97);
            numRX.Margin = new Padding(3, 4, 3, 4);
            numRX.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numRX.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            numRX.Name = "numRX";
            numRX.Size = new Size(46, 27);
            numRX.TabIndex = 7;
            numRX.Value = new decimal(new int[] { 180, 0, 0, 0 });
            // 
            // btnRotate
            // 
            btnRotate.Location = new Point(11, 133);
            btnRotate.Margin = new Padding(3, 4, 3, 4);
            btnRotate.Name = "btnRotate";
            btnRotate.Size = new Size(115, 31);
            btnRotate.TabIndex = 6;
            btnRotate.Text = "Применить";
            btnRotate.UseVisualStyleBackColor = true;
            btnRotate.Click += BtnRotate_Click;
            // 
            // lblRotate
            // 
            lblRotate.AutoSize = true;
            lblRotate.Location = new Point(11, 100);
            lblRotate.Name = "lblRotate";
            lblRotate.Size = new Size(73, 20);
            lblRotate.TabIndex = 5;
            lblRotate.Text = "Поворот:";
            // 
            // btnTranslate
            // 
            btnTranslate.Location = new Point(11, 60);
            btnTranslate.Margin = new Padding(3, 4, 3, 4);
            btnTranslate.Name = "btnTranslate";
            btnTranslate.Size = new Size(115, 31);
            btnTranslate.TabIndex = 4;
            btnTranslate.Text = "Применить";
            btnTranslate.UseVisualStyleBackColor = true;
            btnTranslate.Click += BtnTranslate_Click;
            // 
            // numTZ
            // 
            numTZ.Location = new Point(183, 24);
            numTZ.Margin = new Padding(3, 4, 3, 4);
            numTZ.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numTZ.Name = "numTZ";
            numTZ.Size = new Size(46, 27);
            numTZ.TabIndex = 3;
            numTZ.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numTY
            // 
            numTY.Location = new Point(131, 24);
            numTY.Margin = new Padding(3, 4, 3, 4);
            numTY.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numTY.Name = "numTY";
            numTY.Size = new Size(46, 27);
            numTY.TabIndex = 2;
            numTY.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numTX
            // 
            numTX.Location = new Point(80, 24);
            numTX.Margin = new Padding(3, 4, 3, 4);
            numTX.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numTX.Name = "numTX";
            numTX.Size = new Size(46, 27);
            numTX.TabIndex = 1;
            numTX.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblTranslate
            // 
            lblTranslate.AutoSize = true;
            lblTranslate.Location = new Point(11, 27);
            lblTranslate.Name = "lblTranslate";
            lblTranslate.Size = new Size(86, 20);
            lblTranslate.TabIndex = 0;
            lblTranslate.Text = "Смещение:";
            // 
            // grpReflection
            // 
            grpReflection.Anchor = AnchorStyles.Bottom;
            grpReflection.Controls.Add(btnReflectYZ);
            grpReflection.Controls.Add(btnReflectXZ);
            grpReflection.Controls.Add(btnReflectXY);
            grpReflection.Location = new Point(245, 15);
            grpReflection.Margin = new Padding(3, 4, 3, 4);
            grpReflection.Name = "grpReflection";
            grpReflection.Padding = new Padding(3, 4, 3, 4);
            grpReflection.Size = new Size(146, 240);
            grpReflection.TabIndex = 13;
            grpReflection.TabStop = false;
            grpReflection.Text = "Отражение";
            // 
            // btnReflectYZ
            // 
            btnReflectYZ.Location = new Point(11, 93);
            btnReflectYZ.Margin = new Padding(3, 4, 3, 4);
            btnReflectYZ.Name = "btnReflectYZ";
            btnReflectYZ.Size = new Size(91, 31);
            btnReflectYZ.TabIndex = 2;
            btnReflectYZ.Text = "YZ";
            btnReflectYZ.UseVisualStyleBackColor = true;
            btnReflectYZ.Click += BtnReflectYZ_Click;
            // 
            // btnReflectXZ
            // 
            btnReflectXZ.Location = new Point(11, 60);
            btnReflectXZ.Margin = new Padding(3, 4, 3, 4);
            btnReflectXZ.Name = "btnReflectXZ";
            btnReflectXZ.Size = new Size(91, 31);
            btnReflectXZ.TabIndex = 1;
            btnReflectXZ.Text = "XZ";
            btnReflectXZ.UseVisualStyleBackColor = true;
            btnReflectXZ.Click += BtnReflectXZ_Click;
            // 
            // btnReflectXY
            // 
            btnReflectXY.Location = new Point(11, 27);
            btnReflectXY.Margin = new Padding(3, 4, 3, 4);
            btnReflectXY.Name = "btnReflectXY";
            btnReflectXY.Size = new Size(91, 31);
            btnReflectXY.TabIndex = 0;
            btnReflectXY.Text = "XY";
            btnReflectXY.UseVisualStyleBackColor = true;
            btnReflectXY.Click += BtnReflectXY_Click;
            // 
            // grpRotationAdvanced
            // 
            grpRotationAdvanced.Anchor = AnchorStyles.Bottom;
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
            grpRotationAdvanced.Location = new Point(0, 263);
            grpRotationAdvanced.Margin = new Padding(3, 4, 3, 4);
            grpRotationAdvanced.Name = "grpRotationAdvanced";
            grpRotationAdvanced.Padding = new Padding(3, 4, 3, 4);
            grpRotationAdvanced.Size = new Size(393, 213);
            grpRotationAdvanced.TabIndex = 14;
            grpRotationAdvanced.TabStop = false;
            grpRotationAdvanced.Text = "Специальные вращения";
            // 
            // btnRotateArbitraryAxis
            // 
            btnRotateArbitraryAxis.Location = new Point(286, 173);
            btnRotateArbitraryAxis.Margin = new Padding(3, 4, 3, 4);
            btnRotateArbitraryAxis.Name = "btnRotateArbitraryAxis";
            btnRotateArbitraryAxis.Size = new Size(91, 31);
            btnRotateArbitraryAxis.TabIndex = 16;
            btnRotateArbitraryAxis.Text = "Применить";
            btnRotateArbitraryAxis.UseVisualStyleBackColor = true;
            btnRotateArbitraryAxis.Click += BtnRotateArbitraryAxis_Click;
            // 
            // lblArbitraryAxis
            // 
            lblArbitraryAxis.AutoSize = true;
            lblArbitraryAxis.Location = new Point(6, 113);
            lblArbitraryAxis.Name = "lblArbitraryAxis";
            lblArbitraryAxis.Size = new Size(189, 20);
            lblArbitraryAxis.TabIndex = 15;
            lblArbitraryAxis.Text = "Произвольная ось (X,Y,Z):";
            // 
            // numAxisX2
            // 
            numAxisX2.Location = new Point(80, 173);
            numAxisX2.Margin = new Padding(3, 4, 3, 4);
            numAxisX2.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numAxisX2.Name = "numAxisX2";
            numAxisX2.Size = new Size(46, 27);
            numAxisX2.TabIndex = 14;
            numAxisX2.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numAxisY2
            // 
            numAxisY2.Location = new Point(132, 173);
            numAxisY2.Margin = new Padding(3, 4, 3, 4);
            numAxisY2.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numAxisY2.Name = "numAxisY2";
            numAxisY2.Size = new Size(46, 27);
            numAxisY2.TabIndex = 13;
            numAxisY2.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numAxisZ2
            // 
            numAxisZ2.Location = new Point(187, 173);
            numAxisZ2.Margin = new Padding(3, 4, 3, 4);
            numAxisZ2.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numAxisZ2.Name = "numAxisZ2";
            numAxisZ2.Size = new Size(46, 27);
            numAxisZ2.TabIndex = 12;
            numAxisZ2.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numAxisX1
            // 
            numAxisX1.Location = new Point(83, 138);
            numAxisX1.Margin = new Padding(3, 4, 3, 4);
            numAxisX1.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numAxisX1.Name = "numAxisX1";
            numAxisX1.Size = new Size(46, 27);
            numAxisX1.TabIndex = 11;
            numAxisX1.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numAxisY1
            // 
            numAxisY1.Location = new Point(135, 138);
            numAxisY1.Margin = new Padding(3, 4, 3, 4);
            numAxisY1.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numAxisY1.Name = "numAxisY1";
            numAxisY1.Size = new Size(46, 27);
            numAxisY1.TabIndex = 10;
            numAxisY1.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numAxisZ1
            // 
            numAxisZ1.Location = new Point(187, 138);
            numAxisZ1.Margin = new Padding(3, 4, 3, 4);
            numAxisZ1.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numAxisZ1.Name = "numAxisZ1";
            numAxisZ1.Size = new Size(46, 27);
            numAxisZ1.TabIndex = 9;
            numAxisZ1.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblAxisPoint2
            // 
            lblAxisPoint2.AutoSize = true;
            lblAxisPoint2.Location = new Point(11, 177);
            lblAxisPoint2.Name = "lblAxisPoint2";
            lblAxisPoint2.Size = new Size(64, 20);
            lblAxisPoint2.TabIndex = 8;
            lblAxisPoint2.Text = "Точка 2:";
            // 
            // lblAxisPoint1
            // 
            lblAxisPoint1.AutoSize = true;
            lblAxisPoint1.Location = new Point(11, 138);
            lblAxisPoint1.Name = "lblAxisPoint1";
            lblAxisPoint1.Size = new Size(64, 20);
            lblAxisPoint1.TabIndex = 7;
            lblAxisPoint1.Text = "Точка 1:";
            // 
            // numArbitraryAngle
            // 
            numArbitraryAngle.Location = new Point(308, 138);
            numArbitraryAngle.Margin = new Padding(3, 4, 3, 4);
            numArbitraryAngle.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numArbitraryAngle.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            numArbitraryAngle.Name = "numArbitraryAngle";
            numArbitraryAngle.Size = new Size(46, 27);
            numArbitraryAngle.TabIndex = 6;
            numArbitraryAngle.Value = new decimal(new int[] { 180, 0, 0, 0 });
            // 
            // lblArbitraryAngle
            // 
            lblArbitraryAngle.AutoSize = true;
            lblArbitraryAngle.Location = new Point(258, 138);
            lblArbitraryAngle.Name = "lblArbitraryAngle";
            lblArbitraryAngle.Size = new Size(44, 20);
            lblArbitraryAngle.TabIndex = 5;
            lblArbitraryAngle.Text = "Угол:";
            // 
            // btnRotateParallelAxis
            // 
            btnRotateParallelAxis.Location = new Point(263, 36);
            btnRotateParallelAxis.Margin = new Padding(3, 4, 3, 4);
            btnRotateParallelAxis.Name = "btnRotateParallelAxis";
            btnRotateParallelAxis.Size = new Size(91, 31);
            btnRotateParallelAxis.TabIndex = 4;
            btnRotateParallelAxis.Text = "Применить";
            btnRotateParallelAxis.UseVisualStyleBackColor = true;
            btnRotateParallelAxis.Click += BtnRotateParallelAxis_Click;
            // 
            // cmbAxis
            // 
            cmbAxis.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAxis.FormattingEnabled = true;
            cmbAxis.Items.AddRange(new object[] { "X", "Y", "Z" });
            cmbAxis.Location = new Point(188, 33);
            cmbAxis.Margin = new Padding(3, 4, 3, 4);
            cmbAxis.Name = "cmbAxis";
            cmbAxis.Size = new Size(45, 28);
            cmbAxis.TabIndex = 3;
            // 
            // numParallelAngle
            // 
            numParallelAngle.Location = new Point(83, 64);
            numParallelAngle.Margin = new Padding(3, 4, 3, 4);
            numParallelAngle.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numParallelAngle.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            numParallelAngle.Name = "numParallelAngle";
            numParallelAngle.Size = new Size(46, 27);
            numParallelAngle.TabIndex = 2;
            numParallelAngle.Value = new decimal(new int[] { 180, 0, 0, 0 });
            // 
            // lblParallelAngle
            // 
            lblParallelAngle.AutoSize = true;
            lblParallelAngle.Location = new Point(29, 71);
            lblParallelAngle.Name = "lblParallelAngle";
            lblParallelAngle.Size = new Size(44, 20);
            lblParallelAngle.TabIndex = 1;
            lblParallelAngle.Text = "Угол:";
            // 
            // lblParallelAxis
            // 
            lblParallelAxis.AutoSize = true;
            lblParallelAxis.Location = new Point(18, 36);
            lblParallelAxis.Name = "lblParallelAxis";
            lblParallelAxis.Size = new Size(163, 20);
            lblParallelAxis.TabIndex = 0;
            lblParallelAxis.Text = "Ось через центр || OX:";
            // 
            // gb_lab6
            // 
            gb_lab6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gb_lab6.Controls.Add(grpReflection);
            gb_lab6.Controls.Add(grpTransform);
            gb_lab6.Controls.Add(grpRotationAdvanced);
            gb_lab6.Location = new Point(577, 268);
            gb_lab6.Name = "gb_lab6";
            gb_lab6.Size = new Size(391, 476);
            gb_lab6.TabIndex = 15;
            gb_lab6.TabStop = false;
            gb_lab6.Visible = false;
            // 
            // gb_lab7
            // 
            gb_lab7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gb_lab7.Controls.Add(btnAddSample);
            gb_lab7.Controls.Add(btnBuildRotation);
            gb_lab7.Controls.Add(numSegments);
            gb_lab7.Controls.Add(lblSegments);
            gb_lab7.Controls.Add(cmbRotationAxis);
            gb_lab7.Controls.Add(lblAxis);
            gb_lab7.Controls.Add(btnClearPoints);
            gb_lab7.Controls.Add(btnAddPoint);
            gb_lab7.Controls.Add(dgvProfile);
            gb_lab7.Controls.Add(btn_Surface);
            gb_lab7.Controls.Add(numNY);
            gb_lab7.Controls.Add(numNX);
            gb_lab7.Controls.Add(label4);
            gb_lab7.Controls.Add(numY1);
            gb_lab7.Controls.Add(numY0);
            gb_lab7.Controls.Add(label3);
            gb_lab7.Controls.Add(numX1);
            gb_lab7.Controls.Add(numX0);
            gb_lab7.Controls.Add(label2);
            gb_lab7.Controls.Add(label1);
            gb_lab7.Controls.Add(cmbFunction);
            gb_lab7.Controls.Add(btn_modelSave);
            gb_lab7.Controls.Add(btn_modelLoad);
            gb_lab7.Location = new Point(577, 268);
            gb_lab7.Name = "gb_lab7";
            gb_lab7.Size = new Size(391, 476);
            gb_lab7.TabIndex = 16;
            gb_lab7.TabStop = false;
            gb_lab7.Visible = false;
            // 
            // btnAddSample
            // 
            btnAddSample.Location = new Point(200, 350);
            btnAddSample.Name = "btnAddSample";
            btnAddSample.Size = new Size(180, 30);
            btnAddSample.TabIndex = 42;
            btnAddSample.Text = "Пример профиля (тор)";
            btnAddSample.UseVisualStyleBackColor = true;
            btnAddSample.Click += btnAddSample_Click;
            // 
            // btnBuildRotation
            // 
            btnBuildRotation.Location = new Point(200, 310);
            btnBuildRotation.Name = "btnBuildRotation";
            btnBuildRotation.Size = new Size(180, 30);
            btnBuildRotation.TabIndex = 41;
            btnBuildRotation.Text = "Построить фигуру вращения";
            btnBuildRotation.UseVisualStyleBackColor = true;
            btnBuildRotation.Click += btnBuildRotation_Click;
            // 
            // numSegments
            // 
            numSegments.Location = new Point(320, 270);
            numSegments.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numSegments.Name = "numSegments";
            numSegments.Size = new Size(60, 27);
            numSegments.TabIndex = 39;
            numSegments.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // lblSegments
            // 
            lblSegments.AutoSize = true;
            lblSegments.Location = new Point(290, 269);
            lblSegments.Name = "lblSegments";
            lblSegments.Size = new Size(39, 20);
            lblSegments.TabIndex = 40;
            lblSegments.Text = "Дол:";
            // 
            // cmbRotationAxis
            // 
            cmbRotationAxis.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRotationAxis.FormattingEnabled = true;
            cmbRotationAxis.Items.AddRange(new object[] { "X", "Y", "Z" });
            cmbRotationAxis.Location = new Point(235, 270);
            cmbRotationAxis.Name = "cmbRotationAxis";
            cmbRotationAxis.Size = new Size(50, 28);
            cmbRotationAxis.TabIndex = 38;
            // 
            // lblAxis
            // 
            lblAxis.AutoSize = true;
            lblAxis.Location = new Point(200, 269);
            lblAxis.Name = "lblAxis";
            lblAxis.Size = new Size(38, 20);
            lblAxis.TabIndex = 37;
            lblAxis.Text = "Ось:";
            // 
            // btnClearPoints
            // 
            btnClearPoints.Location = new Point(295, 230);
            btnClearPoints.Name = "btnClearPoints";
            btnClearPoints.Size = new Size(85, 30);
            btnClearPoints.TabIndex = 36;
            btnClearPoints.Text = "Очистить";
            btnClearPoints.UseVisualStyleBackColor = true;
            btnClearPoints.Click += btnClearPoints_Click;
            // 
            // btnAddPoint
            // 
            btnAddPoint.Location = new Point(200, 230);
            btnAddPoint.Name = "btnAddPoint";
            btnAddPoint.Size = new Size(85, 30);
            btnAddPoint.TabIndex = 35;
            btnAddPoint.Text = "Добавить";
            btnAddPoint.UseVisualStyleBackColor = true;
            btnAddPoint.Click += btnAddPoint_Click;
            // 
            // dgvProfile
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProfile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProfile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProfile.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProfile.Location = new Point(200, 70);
            dgvProfile.Name = "dgvProfile";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvProfile.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvProfile.RowHeadersWidth = 51;
            dgvProfile.Size = new Size(180, 150);
            dgvProfile.TabIndex = 34;
            // 
            // btn_Surface
            // 
            btn_Surface.Location = new Point(12, 299);
            btn_Surface.Name = "btn_Surface";
            btn_Surface.Size = new Size(118, 23);
            btn_Surface.TabIndex = 33;
            btn_Surface.Text = "Построить поверхность";
            btn_Surface.UseVisualStyleBackColor = true;
            btn_Surface.Click += btn_Surface_Click;
            // 
            // numNY
            // 
            numNY.Location = new Point(76, 263);
            numNY.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numNY.Name = "numNY";
            numNY.Size = new Size(53, 27);
            numNY.TabIndex = 32;
            numNY.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // numNX
            // 
            numNX.Location = new Point(12, 263);
            numNX.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numNX.Name = "numNX";
            numNX.Size = new Size(57, 27);
            numNX.TabIndex = 31;
            numNX.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 240);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 30;
            label4.Text = "Разбиения:";
            // 
            // numY1
            // 
            numY1.DecimalPlaces = 2;
            numY1.Location = new Point(76, 212);
            numY1.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numY1.Name = "numY1";
            numY1.Size = new Size(54, 27);
            numY1.TabIndex = 29;
            numY1.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // numY0
            // 
            numY0.DecimalPlaces = 2;
            numY0.Location = new Point(12, 212);
            numY0.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numY0.Name = "numY0";
            numY0.Size = new Size(58, 27);
            numY0.TabIndex = 28;
            numY0.Value = new decimal(new int[] { 10, 0, 0, int.MinValue });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 190);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 27;
            label3.Text = "y ∈ [y₀, y₁]:";
            // 
            // numX1
            // 
            numX1.DecimalPlaces = 2;
            numX1.Location = new Point(75, 166);
            numX1.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numX1.Name = "numX1";
            numX1.Size = new Size(54, 27);
            numX1.TabIndex = 26;
            numX1.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // numX0
            // 
            numX0.DecimalPlaces = 2;
            numX0.Location = new Point(11, 166);
            numX0.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numX0.Name = "numX0";
            numX0.Size = new Size(58, 27);
            numX0.TabIndex = 25;
            numX0.Value = new decimal(new int[] { 10, 0, 0, int.MinValue });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 144);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 24;
            label2.Text = "x ∈ [x₀, x₁]:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 79);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 23;
            label1.Text = "Функция:";
            // 
            // cmbFunction
            // 
            cmbFunction.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFunction.FormattingEnabled = true;
            cmbFunction.Location = new Point(11, 107);
            cmbFunction.Name = "cmbFunction";
            cmbFunction.Size = new Size(118, 28);
            cmbFunction.TabIndex = 22;
            // 
            // btn_modelSave
            // 
            btn_modelSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_modelSave.BackColor = SystemColors.ControlLightLight;
            btn_modelSave.Enabled = false;
            btn_modelSave.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            btn_modelSave.Location = new Point(196, 11);
            btn_modelSave.Margin = new Padding(3, 4, 3, 4);
            btn_modelSave.Name = "btn_modelSave";
            btn_modelSave.Size = new Size(189, 44);
            btn_modelSave.TabIndex = 20;
            btn_modelSave.Text = "Save";
            btn_modelSave.UseVisualStyleBackColor = false;
            btn_modelSave.Click += btn_modelSave_Click;
            // 
            // btn_modelLoad
            // 
            btn_modelLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_modelLoad.BackColor = SystemColors.ControlLightLight;
            btn_modelLoad.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            btn_modelLoad.Location = new Point(6, 11);
            btn_modelLoad.Margin = new Padding(3, 4, 3, 4);
            btn_modelLoad.Name = "btn_modelLoad";
            btn_modelLoad.Size = new Size(189, 44);
            btn_modelLoad.TabIndex = 19;
            btn_modelLoad.Text = "Load";
            btn_modelLoad.UseVisualStyleBackColor = false;
            btn_modelLoad.Click += btn_modelLoad_Click;
            // 
            // btn_lab6
            // 
            btn_lab6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_lab6.BackColor = SystemColors.ControlLightLight;
            btn_lab6.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            btn_lab6.Location = new Point(577, 221);
            btn_lab6.Margin = new Padding(3, 4, 3, 4);
            btn_lab6.Name = "btn_lab6";
            btn_lab6.Size = new Size(126, 44);
            btn_lab6.TabIndex = 17;
            btn_lab6.Text = "Lab6";
            btn_lab6.UseVisualStyleBackColor = false;
            btn_lab6.Click += btn_lab6_Click;
            // 
            // btn_lab7
            // 
            btn_lab7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_lab7.BackColor = SystemColors.ControlLightLight;
            btn_lab7.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            btn_lab7.Location = new Point(721, 221);
            btn_lab7.Margin = new Padding(3, 4, 3, 4);
            btn_lab7.Name = "btn_lab7";
            btn_lab7.Size = new Size(111, 44);
            btn_lab7.TabIndex = 18;
            btn_lab7.Text = "Lab7";
            btn_lab7.UseVisualStyleBackColor = false;
            btn_lab7.Click += btn_lab7_Click;
            // 
            // gb_lab8
            // 

            btn_renderMode = new Button();
            btn_renderMode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_renderMode.Location = new Point(6, 185);  
            btn_renderMode.Name = "btn_renderMode";
            btn_renderMode.Size = new Size(379, 54);
            btn_renderMode.TabIndex = 26;
            btn_renderMode.Text = "Render Mode: Wireframe";
            btn_renderMode.UseVisualStyleBackColor = true;
            btn_renderMode.Click += btn_renderMode_Click;

            gb_lab8.Controls.Add(btn_normalsDisplay);
            gb_lab8.Controls.Add(btn_cullBackfaces);
            gb_lab8.Controls.Add(lbl_camYaw);
            gb_lab8.Controls.Add(tb_camYaw);
            gb_lab8.Controls.Add(lbl_camPitch);
            gb_lab8.Controls.Add(tb_camPitch);
            gb_lab8.Controls.Add(btn_renderMode);
            gb_lab8.Location = new Point(577, 268);
            gb_lab8.Name = "gb_lab8";
            gb_lab8.Size = new Size(391, 476);
            gb_lab8.TabIndex = 19;
            gb_lab8.TabStop = false;


           
            // 
            // btn_normalsDisplay
            // 
            btn_normalsDisplay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_normalsDisplay.Location = new Point(200, 126);
            btn_normalsDisplay.Name = "btn_normalsDisplay";
            btn_normalsDisplay.Size = new Size(185, 54);
            btn_normalsDisplay.TabIndex = 25;
            btn_normalsDisplay.Text = "Face Normals: Off";
            btn_normalsDisplay.UseVisualStyleBackColor = true;
            btn_normalsDisplay.Click += btn_normalsDisplay_Click;
            // 
            // btn_cullBackfaces
            // 
            btn_cullBackfaces.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_cullBackfaces.Location = new Point(0, 125);
            btn_cullBackfaces.Name = "btn_cullBackfaces";
            btn_cullBackfaces.Size = new Size(194, 54);
            btn_cullBackfaces.TabIndex = 24;
            btn_cullBackfaces.Text = "Backface Culling: On";
            btn_cullBackfaces.UseVisualStyleBackColor = true;
            btn_cullBackfaces.Click += btn_cullBackfaces_Click;
            // 
            // lbl_camYaw
            // 
            lbl_camYaw.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_camYaw.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbl_camYaw.Location = new Point(231, 75);
            lbl_camYaw.Name = "lbl_camYaw";
            lbl_camYaw.Size = new Size(129, 51);
            lbl_camYaw.TabIndex = 23;
            lbl_camYaw.Text = "Yaw: 70";
            lbl_camYaw.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_camYaw
            // 
            tb_camYaw.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_camYaw.CausesValidation = false;
            tb_camYaw.LargeChange = 10;
            tb_camYaw.Location = new Point(0, 75);
            tb_camYaw.Margin = new Padding(3, 4, 3, 4);
            tb_camYaw.Maximum = 180;
            tb_camYaw.Minimum = -180;
            tb_camYaw.Name = "tb_camYaw";
            tb_camYaw.Size = new Size(226, 56);
            tb_camYaw.TabIndex = 22;
            tb_camYaw.TickStyle = TickStyle.None;
            tb_camYaw.Value = 70;
            tb_camYaw.Scroll += tb_camYaw_Scroll;
            // 
            // lbl_camPitch
            // 
            lbl_camPitch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_camPitch.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbl_camPitch.Location = new Point(231, 19);
            lbl_camPitch.Name = "lbl_camPitch";
            lbl_camPitch.Size = new Size(129, 51);
            lbl_camPitch.TabIndex = 21;
            lbl_camPitch.Text = "Pitch: 70";
            lbl_camPitch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_camPitch
            // 
            tb_camPitch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_camPitch.CausesValidation = false;
            tb_camPitch.LargeChange = 10;
            tb_camPitch.Location = new Point(0, 19);
            tb_camPitch.Margin = new Padding(3, 4, 3, 4);
            tb_camPitch.Maximum = 180;
            tb_camPitch.Minimum = -180;
            tb_camPitch.Name = "tb_camPitch";
            tb_camPitch.Size = new Size(226, 56);
            tb_camPitch.TabIndex = 21;
            tb_camPitch.TickStyle = TickStyle.None;
            tb_camPitch.Value = 70;
            tb_camPitch.Scroll += tb_camPitch_Scroll;
            // 
            // btn_lab8
            // 
            btn_lab8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_lab8.BackColor = SystemColors.ControlLightLight;
            btn_lab8.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            btn_lab8.Location = new Point(857, 221);
            btn_lab8.Margin = new Padding(3, 4, 3, 4);
            btn_lab8.Name = "btn_lab8";
            btn_lab8.Size = new Size(111, 44);
            btn_lab8.TabIndex = 20;
            btn_lab8.Text = "Lab8";
            btn_lab8.UseVisualStyleBackColor = false;
            btn_lab8.Click += btn_lab8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 769);
            Controls.Add(btn_lab8);
            Controls.Add(gb_lab8);
            Controls.Add(pb);
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
            Controls.Add(gb_lab7);
            Controls.Add(gb_lab6);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1000, 800);
            Name = "Form1";
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
            gb_lab7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSegments).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numY1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numY0).EndInit();
            ((System.ComponentModel.ISupportInitialize)numX1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numX0).EndInit();
            gb_lab8.ResumeLayout(false);
            gb_lab8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tb_camYaw).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_camPitch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.GroupBox gb_lab8;

        #endregion

        private Button btn_lab8;
        private Label lbl_camPitch;
        private TrackBar tb_camPitch;
        private Label lbl_camYaw;
        private TrackBar tb_camYaw;
        private Button btn_cullBackfaces;
        private Button btn_normalsDisplay;
        private Button btn_renderMode;
    }
}