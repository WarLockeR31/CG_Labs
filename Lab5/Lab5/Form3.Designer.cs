namespace Lab5
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
            btnClearAll = new Button();
            SuspendLayout();
            // 
            // lblTask
            // 
            lblTask.Text = "Задание 3";
            // 
            // btnClearAll
            // 
            btnClearAll.Location = new Point(559, 47);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(107, 30);
            btnClearAll.TabIndex = 1;
            btnClearAll.Text = "Очистить все";
            btnClearAll.UseVisualStyleBackColor = true;
            btnClearAll.Click += btnClearAll_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClearAll);
            Name = "Form3";
            Text = "Кубические сплайны Безье";
            Controls.SetChildIndex(btnClearAll, 0);
            Controls.SetChildIndex(lblTask, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClearAll;
    }
}