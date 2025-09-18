namespace CG_Lab2
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
            tbHue = new TrackBar();
            lblHue = new Label();
            lblSat = new Label();
            tbSat = new TrackBar();
            lblVal = new Label();
            tbVal = new TrackBar();
            pb = new PictureBox();
            btnOpen = new Button();
            btnSave = new Button();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)tbHue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            SuspendLayout();
            // 
            // tbHue
            // 
            tbHue.Location = new Point(497, 84);
            tbHue.Name = "tbHue";
            tbHue.Size = new Size(270, 45);
            tbHue.TabIndex = 3;
            tbHue.TickStyle = TickStyle.None;
            tbHue.Scroll += tbHue_Scroll;
            // 
            // lblHue
            // 
            lblHue.BorderStyle = BorderStyle.FixedSingle;
            lblHue.Font = new Font("Segoe UI", 12F);
            lblHue.Location = new Point(587, 57);
            lblHue.Name = "lblHue";
            lblHue.Size = new Size(93, 23);
            lblHue.TabIndex = 4;
            lblHue.Text = "Hue:";
            lblHue.Click += lblHue_Click;
            // 
            // lblSat
            // 
            lblSat.BorderStyle = BorderStyle.FixedSingle;
            lblSat.Font = new Font("Segoe UI", 12F);
            lblSat.Location = new Point(587, 131);
            lblSat.Name = "lblSat";
            lblSat.Size = new Size(93, 23);
            lblSat.TabIndex = 6;
            lblSat.Text = "Sat:";
            // 
            // tbSat
            // 
            tbSat.Location = new Point(497, 161);
            tbSat.Name = "tbSat";
            tbSat.Size = new Size(270, 45);
            tbSat.TabIndex = 5;
            tbSat.TickStyle = TickStyle.None;
            tbSat.Scroll += tbSat_Scroll;
            // 
            // lblVal
            // 
            lblVal.BorderStyle = BorderStyle.FixedSingle;
            lblVal.Font = new Font("Segoe UI", 12F);
            lblVal.Location = new Point(587, 208);
            lblVal.Name = "lblVal";
            lblVal.Size = new Size(93, 23);
            lblVal.TabIndex = 8;
            lblVal.Text = "Val:";
            lblVal.Click += lblVal_Click;
            // 
            // tbVal
            // 
            tbVal.Location = new Point(497, 235);
            tbVal.Name = "tbVal";
            tbVal.Size = new Size(270, 45);
            tbVal.TabIndex = 7;
            tbVal.TickStyle = TickStyle.None;
            tbVal.Scroll += tbVal_Scroll;
            // 
            // pb
            // 
            pb.Location = new Point(12, 58);
            pb.Name = "pb";
            pb.Size = new Size(456, 380);
            pb.TabIndex = 9;
            pb.TabStop = false;
            // 
            // btnOpen
            // 
            btnOpen.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOpen.Location = new Point(497, 322);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(80, 61);
            btnOpen.TabIndex = 10;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.Location = new Point(592, 322);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 61);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReset.Location = new Point(687, 322);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(80, 61);
            btnReset.TabIndex = 12;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(btnOpen);
            Controls.Add(pb);
            Controls.Add(lblVal);
            Controls.Add(tbVal);
            Controls.Add(lblSat);
            Controls.Add(tbSat);
            Controls.Add(lblHue);
            Controls.Add(tbHue);
            Name = "Form3";
            Text = "Form3";
            Controls.SetChildIndex(tbHue, 0);
            Controls.SetChildIndex(lblHue, 0);
            Controls.SetChildIndex(tbSat, 0);
            Controls.SetChildIndex(lblSat, 0);
            Controls.SetChildIndex(tbVal, 0);
            Controls.SetChildIndex(lblVal, 0);
            Controls.SetChildIndex(pb, 0);
            Controls.SetChildIndex(btnOpen, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnReset, 0);
            ((System.ComponentModel.ISupportInitialize)tbHue).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSat).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbVal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar tbHue;
        private Label lblHue;
        private Label lblSat;
        private TrackBar tbSat;
        private Label lblVal;
        private TrackBar tbVal;
        private PictureBox pb;
        private Button btnOpen;
        private Button btnSave;
        private Button btnReset;
    }
}