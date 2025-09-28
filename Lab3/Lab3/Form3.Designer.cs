namespace Lab3
{
    partial class Form3
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            BtnColor1 = new Button();
            BtnColor2 = new Button();
            BtnColor3 = new Button();
            BtnSwitchColorScheme = new Button();
            labelColorScheme = new Label();
            SuspendLayout();
            // 
            // lblTask
            // 
            lblTask.Text = "Задание 3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(559, 281);
            label1.Name = "label1";
            label1.Size = new Size(101, 21);
            label1.TabIndex = 6;
            label1.Text = "Вершина A:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(559, 328);
            label2.Name = "label2";
            label2.Size = new Size(100, 21);
            label2.TabIndex = 7;
            label2.Text = "Вершина B:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(559, 372);
            label3.Name = "label3";
            label3.Size = new Size(100, 21);
            label3.TabIndex = 8;
            label3.Text = "Вершина C:";
            // 
            // BtnColor1
            // 
            BtnColor1.Font = new Font("Segoe UI", 12F);
            BtnColor1.Location = new Point(674, 275);
            BtnColor1.Name = "BtnColor1";
            BtnColor1.Size = new Size(114, 33);
            BtnColor1.TabIndex = 9;
            BtnColor1.Text = "Задать цвет";
            BtnColor1.UseVisualStyleBackColor = true;
            BtnColor1.Click += BtnColor1_Click;
            // 
            // BtnColor2
            // 
            BtnColor2.Font = new Font("Segoe UI", 12F);
            BtnColor2.Location = new Point(674, 322);
            BtnColor2.Name = "BtnColor2";
            BtnColor2.Size = new Size(114, 33);
            BtnColor2.TabIndex = 10;
            BtnColor2.Text = "Задать цвет";
            BtnColor2.UseVisualStyleBackColor = true;
            BtnColor2.Click += BtnColor2_Click;
            // 
            // BtnColor3
            // 
            BtnColor3.Font = new Font("Segoe UI", 12F);
            BtnColor3.Location = new Point(674, 366);
            BtnColor3.Name = "BtnColor3";
            BtnColor3.Size = new Size(114, 33);
            BtnColor3.TabIndex = 11;
            BtnColor3.Text = "Задать цвет";
            BtnColor3.UseVisualStyleBackColor = true;
            BtnColor3.Click += BtnColor3_Click;
            // 
            // BtnSwitchColorScheme
            // 
            BtnSwitchColorScheme.Font = new Font("Segoe UI", 12F);
            BtnSwitchColorScheme.Location = new Point(559, 199);
            BtnSwitchColorScheme.Name = "BtnSwitchColorScheme";
            BtnSwitchColorScheme.Size = new Size(229, 33);
            BtnSwitchColorScheme.TabIndex = 12;
            BtnSwitchColorScheme.Text = "Поменять цветовую схему";
            BtnSwitchColorScheme.UseVisualStyleBackColor = true;
            BtnSwitchColorScheme.Click += BtnSwitchColorScheme_Click;
            // 
            // labelColorScheme
            // 
            labelColorScheme.AutoSize = true;
            labelColorScheme.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelColorScheme.Location = new Point(640, 235);
            labelColorScheme.Name = "labelColorScheme";
            labelColorScheme.Size = new Size(62, 32);
            labelColorScheme.TabIndex = 13;
            labelColorScheme.Text = "RGB";
            labelColorScheme.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelColorScheme);
            Controls.Add(BtnSwitchColorScheme);
            Controls.Add(BtnColor3);
            Controls.Add(BtnColor2);
            Controls.Add(BtnColor1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            MouseDown += Form3_MouseDown;
            MouseMove += Form3_MouseMove;
            MouseUp += Form3_MouseUp;
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(lblTask, 0);
            Controls.SetChildIndex(BtnColor1, 0);
            Controls.SetChildIndex(BtnColor2, 0);
            Controls.SetChildIndex(BtnColor3, 0);
            Controls.SetChildIndex(BtnSwitchColorScheme, 0);
            Controls.SetChildIndex(labelColorScheme, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Button BtnColor1;
        private Button BtnColor2;
        private Button BtnColor3;
        private Button BtnSwitchColorScheme;
        private Label labelColorScheme;
    }
}