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
            pictureBox = new PictureBox();
            roughnessTrackBar = new TrackBar();
            snowLevelTrackBar = new TrackBar();
            sizeTrackBar = new TrackBar();
            seedNumeric = new NumericUpDown();
            generateButton = new Button();
            roughnessLabel = new Label();
            snowLevelLabel = new Label();
            sizeLabel = new Label();
            seedLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roughnessTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)snowLevelTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sizeTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seedNumeric).BeginInit();
            SuspendLayout();
            // 
            // lblTask
            // 
            lblTask.Text = "Задание 2";
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(12, 80);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(500, 400);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // roughnessTrackBar
            // 
            roughnessTrackBar.Location = new Point(530, 105);
            roughnessTrackBar.Maximum = 100;
            roughnessTrackBar.Minimum = 1;
            roughnessTrackBar.Name = "roughnessTrackBar";
            roughnessTrackBar.Size = new Size(250, 56);
            roughnessTrackBar.TabIndex = 1;
            roughnessTrackBar.TickFrequency = 10;
            roughnessTrackBar.Value = 50;
            // 
            // snowLevelTrackBar
            // 
            snowLevelTrackBar.Location = new Point(530, 200);
            snowLevelTrackBar.Maximum = 100;
            snowLevelTrackBar.Name = "snowLevelTrackBar";
            snowLevelTrackBar.Size = new Size(250, 56);
            snowLevelTrackBar.TabIndex = 2;
            snowLevelTrackBar.TickFrequency = 10;
            snowLevelTrackBar.Value = 70;
            // 
            // sizeTrackBar
            // 
            sizeTrackBar.Location = new Point(530, 295);
            sizeTrackBar.Minimum = 5;
            sizeTrackBar.Name = "sizeTrackBar";
            sizeTrackBar.Size = new Size(250, 56);
            sizeTrackBar.TabIndex = 3;
            sizeTrackBar.Value = 7;
            // 
            // seedNumeric
            // 
            seedNumeric.Location = new Point(530, 375);
            seedNumeric.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            seedNumeric.Name = "seedNumeric";
            seedNumeric.Size = new Size(120, 27);
            seedNumeric.TabIndex = 4;
            // 
            // generateButton
            // 
            generateButton.BackColor = Color.LightBlue;
            generateButton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            generateButton.Location = new Point(530, 465);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(250, 35);
            generateButton.TabIndex = 6;
            generateButton.Text = "Сгенерировать горный массив";
            generateButton.UseVisualStyleBackColor = false;
            // 
            // roughnessLabel
            // 
            roughnessLabel.AutoSize = true;
            roughnessLabel.Location = new Point(527, 80);
            roughnessLabel.Name = "roughnessLabel";
            roughnessLabel.Size = new Size(151, 20);
            roughnessLabel.TabIndex = 7;
            roughnessLabel.Text = "Шероховатость: 0.50";
            // 
            // snowLevelLabel
            // 
            snowLevelLabel.AutoSize = true;
            snowLevelLabel.Location = new Point(527, 175);
            snowLevelLabel.Name = "snowLevelLabel";
            snowLevelLabel.Size = new Size(145, 20);
            snowLevelLabel.TabIndex = 8;
            snowLevelLabel.Text = "Уровень снега: 0.70";
            // 
            // sizeLabel
            // 
            sizeLabel.AutoSize = true;
            sizeLabel.Location = new Point(527, 270);
            sizeLabel.Name = "sizeLabel";
            sizeLabel.Size = new Size(122, 20);
            sizeLabel.TabIndex = 9;
            sizeLabel.Text = "Размер: 129x129";
            // 
            // seedLabel
            // 
            seedLabel.AutoSize = true;
            seedLabel.Location = new Point(527, 355);
            seedLabel.Name = "seedLabel";
            seedLabel.Size = new Size(45, 20);
            seedLabel.TabIndex = 10;
            seedLabel.Text = "Seed:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            ClientSize = new Size(800, 520);
            Controls.Add(seedLabel);
            Controls.Add(sizeLabel);
            Controls.Add(snowLevelLabel);
            Controls.Add(roughnessLabel);
            Controls.Add(generateButton);
            Controls.Add(seedNumeric);
            Controls.Add(sizeTrackBar);
            Controls.Add(snowLevelTrackBar);
            Controls.Add(roughnessTrackBar);
            Controls.Add(pictureBox);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Задание 2 - Генерация горного массива";
            Controls.SetChildIndex(pictureBox, 0);
            Controls.SetChildIndex(roughnessTrackBar, 0);
            Controls.SetChildIndex(snowLevelTrackBar, 0);
            Controls.SetChildIndex(sizeTrackBar, 0);
            Controls.SetChildIndex(seedNumeric, 0);
            Controls.SetChildIndex(generateButton, 0);
            Controls.SetChildIndex(roughnessLabel, 0);
            Controls.SetChildIndex(snowLevelLabel, 0);
            Controls.SetChildIndex(sizeLabel, 0);
            Controls.SetChildIndex(seedLabel, 0);
            Controls.SetChildIndex(lblTask, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)roughnessTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)snowLevelTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)sizeTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)seedNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar roughnessTrackBar;
        private System.Windows.Forms.TrackBar snowLevelTrackBar;
        private System.Windows.Forms.TrackBar sizeTrackBar;
        private System.Windows.Forms.NumericUpDown seedNumeric;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label roughnessLabel;
        private System.Windows.Forms.Label snowLevelLabel;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label seedLabel;
    }
}