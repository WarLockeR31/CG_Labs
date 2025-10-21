namespace Lab5
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.roughnessTrackBar = new System.Windows.Forms.TrackBar();
            this.snowLevelTrackBar = new System.Windows.Forms.TrackBar();
            this.sizeTrackBar = new System.Windows.Forms.TrackBar();
            this.seedNumeric = new System.Windows.Forms.NumericUpDown();
            this.stepComboBox = new System.Windows.Forms.ComboBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.roughnessLabel = new System.Windows.Forms.Label();
            this.snowLevelLabel = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.seedLabel = new System.Windows.Forms.Label();
            this.stepLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roughnessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snowLevelTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seedNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 80);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(500, 400);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // roughnessTrackBar
            // 
            this.roughnessTrackBar.Location = new System.Drawing.Point(530, 105);
            this.roughnessTrackBar.Maximum = 100;
            this.roughnessTrackBar.Minimum = 1;
            this.roughnessTrackBar.Name = "roughnessTrackBar";
            this.roughnessTrackBar.Size = new System.Drawing.Size(250, 45);
            this.roughnessTrackBar.TabIndex = 1;
            this.roughnessTrackBar.TickFrequency = 10;
            this.roughnessTrackBar.Value = 50;
            // 
            // snowLevelTrackBar
            // 
            this.snowLevelTrackBar.Location = new System.Drawing.Point(530, 200);
            this.snowLevelTrackBar.Maximum = 100;
            this.snowLevelTrackBar.Name = "snowLevelTrackBar";
            this.snowLevelTrackBar.Size = new System.Drawing.Size(250, 45);
            this.snowLevelTrackBar.TabIndex = 2;
            this.snowLevelTrackBar.TickFrequency = 10;
            this.snowLevelTrackBar.Value = 70;
            // 
            // sizeTrackBar
            // 
            this.sizeTrackBar.Location = new System.Drawing.Point(530, 295);
            this.sizeTrackBar.Maximum = 10;
            this.sizeTrackBar.Minimum = 5;
            this.sizeTrackBar.Name = "sizeTrackBar";
            this.sizeTrackBar.Size = new System.Drawing.Size(250, 45);
            this.sizeTrackBar.TabIndex = 3;
            this.sizeTrackBar.TickFrequency = 1;
            this.sizeTrackBar.Value = 7;
            // 
            // seedNumeric
            // 
            this.seedNumeric.Location = new System.Drawing.Point(530, 375);
            this.seedNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.seedNumeric.Name = "seedNumeric";
            this.seedNumeric.Size = new System.Drawing.Size(120, 22);
            this.seedNumeric.TabIndex = 4;
            // 
            // stepComboBox
            // 
            this.stepComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stepComboBox.FormattingEnabled = true;
            this.stepComboBox.Location = new System.Drawing.Point(530, 420);
            this.stepComboBox.Name = "stepComboBox";
            this.stepComboBox.Size = new System.Drawing.Size(250, 24);
            this.stepComboBox.TabIndex = 5;
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.Color.LightBlue;
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateButton.Location = new System.Drawing.Point(530, 465);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(250, 35);
            this.generateButton.TabIndex = 6;
            this.generateButton.Text = "Сгенерировать горный массив";
            this.generateButton.UseVisualStyleBackColor = false;
            // 
            // roughnessLabel
            // 
            this.roughnessLabel.AutoSize = true;
            this.roughnessLabel.Location = new System.Drawing.Point(527, 80);
            this.roughnessLabel.Name = "roughnessLabel";
            this.roughnessLabel.Size = new System.Drawing.Size(137, 16);
            this.roughnessLabel.TabIndex = 7;
            this.roughnessLabel.Text = "Шероховатость: 0.50";
            // 
            // snowLevelLabel
            // 
            this.snowLevelLabel.AutoSize = true;
            this.snowLevelLabel.Location = new System.Drawing.Point(527, 175);
            this.snowLevelLabel.Name = "snowLevelLabel";
            this.snowLevelLabel.Size = new System.Drawing.Size(125, 16);
            this.snowLevelLabel.TabIndex = 8;
            this.snowLevelLabel.Text = "Уровень снега: 0.70";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(527, 270);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(102, 16);
            this.sizeLabel.TabIndex = 9;
            this.sizeLabel.Text = "Размер: 129x129";
            // 
            // seedLabel
            // 
            this.seedLabel.AutoSize = true;
            this.seedLabel.Location = new System.Drawing.Point(527, 355);
            this.seedLabel.Name = "seedLabel";
            this.seedLabel.Size = new System.Drawing.Size(42, 16);
            this.seedLabel.TabIndex = 10;
            this.seedLabel.Text = "Seed:";
            // 
            // stepLabel
            // 
            this.stepLabel.AutoSize = true;
            this.stepLabel.Location = new System.Drawing.Point(527, 400);
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(104, 16);
            this.stepLabel.TabIndex = 11;
            this.stepLabel.Text = "Шаг алгоритма:";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.titleLabel.Location = new System.Drawing.Point(12, 45);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(428, 25);
            this.titleLabel.TabIndex = 12;
            this.titleLabel.Text = "Задание 2 - Генерация горного массива";
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.stepLabel);
            this.Controls.Add(this.seedLabel);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.snowLevelLabel);
            this.Controls.Add(this.roughnessLabel);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.stepComboBox);
            this.Controls.Add(this.seedNumeric);
            this.Controls.Add(this.sizeTrackBar);
            this.Controls.Add(this.snowLevelTrackBar);
            this.Controls.Add(this.roughnessTrackBar);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Задание 2 - Генерация горного массива";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roughnessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snowLevelTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seedNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar roughnessTrackBar;
        private System.Windows.Forms.TrackBar snowLevelTrackBar;
        private System.Windows.Forms.TrackBar sizeTrackBar;
        private System.Windows.Forms.NumericUpDown seedNumeric;
        private System.Windows.Forms.ComboBox stepComboBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label roughnessLabel;
        private System.Windows.Forms.Label snowLevelLabel;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label seedLabel;
        private System.Windows.Forms.Label stepLabel;
        private System.Windows.Forms.Label titleLabel;
    }
}