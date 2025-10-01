namespace Lab3
{
    partial class Form1b
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTask;
        private Button btnOpen;
        private Button btnPattern;
        private PictureBox pictureBox1;

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


        private void InitializeComponent()
        {
            this.lblTask = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPattern = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTask.Location = new System.Drawing.Point(12, 9);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(226, 21);
            this.lblTask.TabIndex = 0;
            this.lblTask.Text = "Задание 1б - Заливка паттерном";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 40);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(120, 30);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Открыть картинку";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnPattern
            // 
            this.btnPattern.Location = new System.Drawing.Point(150, 40);
            this.btnPattern.Name = "btnPattern";
            this.btnPattern.Size = new System.Drawing.Size(140, 30);
            this.btnPattern.TabIndex = 2;
            this.btnPattern.Text = "Открыть паттерн";
            this.btnPattern.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Location = new System.Drawing.Point(12, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 358);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form1b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPattern);
        }
    }
}
