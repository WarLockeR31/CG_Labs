namespace Lab5
{
    partial class Form1a
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _canvas = new PictureBox();
            _btnOpen = new Button();
            _btnRender = new Button();
            _btnRandomizeSeed = new Button();
            _numIter = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            _numJitter = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)_canvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_numIter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_numJitter).BeginInit();
            SuspendLayout();
            // 
            // lblTask
            // 
            lblTask.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTask.Location = new Point(644, 17);
            lblTask.Size = new Size(117, 27);
            lblTask.Text = "Задание 1а";
            // 
            // _canvas
            // 
            _canvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _canvas.BorderStyle = BorderStyle.FixedSingle;
            _canvas.Location = new Point(12, 58);
            _canvas.Name = "_canvas";
            _canvas.Size = new Size(605, 380);
            _canvas.TabIndex = 5;
            _canvas.TabStop = false;
            // 
            // _btnOpen
            // 
            _btnOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnOpen.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _btnOpen.Location = new Point(623, 53);
            _btnOpen.Name = "_btnOpen";
            _btnOpen.Size = new Size(79, 30);
            _btnOpen.TabIndex = 6;
            _btnOpen.Text = "Open";
            _btnOpen.UseVisualStyleBackColor = true;
            _btnOpen.Click += OnOpenClick;
            // 
            // _btnRender
            // 
            _btnRender.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnRender.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _btnRender.Location = new Point(708, 53);
            _btnRender.Name = "_btnRender";
            _btnRender.Size = new Size(79, 30);
            _btnRender.TabIndex = 7;
            _btnRender.Text = "Render";
            _btnRender.UseVisualStyleBackColor = true;
            _btnRender.Click += OnRenderClick;
            // 
            // _btnRandomizeSeed
            // 
            _btnRandomizeSeed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnRandomizeSeed.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            _btnRandomizeSeed.Location = new Point(623, 89);
            _btnRandomizeSeed.Name = "_btnRandomizeSeed";
            _btnRandomizeSeed.Size = new Size(164, 30);
            _btnRandomizeSeed.TabIndex = 8;
            _btnRandomizeSeed.Text = "Random seed";
            _btnRandomizeSeed.UseVisualStyleBackColor = true;
            _btnRandomizeSeed.Click += _btnRandomizeSeed_Click;
            // 
            // _numIter
            // 
            _numIter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _numIter.Location = new Point(737, 130);
            _numIter.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            _numIter.Name = "_numIter";
            _numIter.Size = new Size(52, 23);
            _numIter.TabIndex = 9;
            _numIter.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(625, 132);
            label1.Name = "label1";
            label1.Size = new Size(87, 21);
            label1.TabIndex = 10;
            label1.Text = "Iterations:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(625, 167);
            label2.Name = "label2";
            label2.Size = new Size(101, 21);
            label2.TabIndex = 12;
            label2.Text = "Angle jitter:";
            // 
            // _numJitter
            // 
            _numJitter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _numJitter.Location = new Point(737, 165);
            _numJitter.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            _numJitter.Name = "_numJitter";
            _numJitter.Size = new Size(52, 23);
            _numJitter.TabIndex = 11;
            // 
            // Form1a
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 450);
            Controls.Add(label2);
            Controls.Add(_numJitter);
            Controls.Add(label1);
            Controls.Add(_numIter);
            Controls.Add(_btnRandomizeSeed);
            Controls.Add(_btnRender);
            Controls.Add(_btnOpen);
            Controls.Add(_canvas);
            DoubleBuffered = true;
            Name = "Form1a";
            Text = "Form1";
            Controls.SetChildIndex(lblTask, 0);
            Controls.SetChildIndex(_canvas, 0);
            Controls.SetChildIndex(_btnOpen, 0);
            Controls.SetChildIndex(_btnRender, 0);
            Controls.SetChildIndex(_btnRandomizeSeed, 0);
            Controls.SetChildIndex(_numIter, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(_numJitter, 0);
            Controls.SetChildIndex(label2, 0);
            ((System.ComponentModel.ISupportInitialize)_canvas).EndInit();
            ((System.ComponentModel.ISupportInitialize)_numIter).EndInit();
            ((System.ComponentModel.ISupportInitialize)_numJitter).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox _canvas;
        private Button _btnOpen;
        private Button _btnRender;
        private Button _btnRandomizeSeed;
        private NumericUpDown _numIter;
        private Label label1;
        private Label label2;
        private NumericUpDown _numJitter;
    }
}
