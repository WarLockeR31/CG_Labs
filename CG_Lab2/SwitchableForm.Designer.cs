namespace CG_Lab2
{
    partial class SwitchableForm
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            lblTask = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.AllowDrop = true;
            button1.AutoEllipsis = true;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(77, 40);
            button1.TabIndex = 0;
            button1.Text = "Task1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.AllowDrop = true;
            button2.AutoEllipsis = true;
            button2.FlatAppearance.BorderColor = Color.Black;
            button2.Location = new Point(95, 12);
            button2.Name = "button2";
            button2.Size = new Size(77, 40);
            button2.TabIndex = 1;
            button2.Text = "Task2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.AllowDrop = true;
            button3.AutoEllipsis = true;
            button3.FlatAppearance.BorderColor = Color.Black;
            button3.Location = new Point(178, 12);
            button3.Name = "button3";
            button3.Size = new Size(77, 40);
            button3.TabIndex = 2;
            button3.Text = "Task3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // lblTask
            // 
            lblTask.Anchor = AnchorStyles.Top;
            lblTask.AutoEllipsis = true;
            lblTask.AutoSize = true;
            lblTask.BorderStyle = BorderStyle.FixedSingle;
            lblTask.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTask.Location = new Point(336, 17);
            lblTask.Name = "lblTask";
            lblTask.Size = new Size(107, 27);
            lblTask.TabIndex = 3;
            lblTask.Text = "Задание 1";
            lblTask.TextAlign = ContentAlignment.TopCenter;
            // 
            // SwitchableForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTask);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "SwitchableForm";
            Text = "SwitchableForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        protected Label lblTask;
    }
}