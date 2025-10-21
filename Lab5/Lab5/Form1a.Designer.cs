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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			_canvas = new System.Windows.Forms.PictureBox();
			_btnOpen = new System.Windows.Forms.Button();
			_btnRender = new System.Windows.Forms.Button();
			_btnRandomizeSeed = new System.Windows.Forms.Button();
			_numIter = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			_numJitter = new System.Windows.Forms.NumericUpDown();
			_btnRenderTree = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)_canvas).BeginInit();
			((System.ComponentModel.ISupportInitialize)_numIter).BeginInit();
			((System.ComponentModel.ISupportInitialize)_numJitter).BeginInit();
			SuspendLayout();
			// 
			// lblTask
			// 
			lblTask.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			lblTask.Location = new System.Drawing.Point(643, 17);
			lblTask.Size = new System.Drawing.Size(117, 27);
			lblTask.Text = "Задание 1а";
			// 
			// _canvas
			// 
			_canvas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
			_canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_canvas.Location = new System.Drawing.Point(12, 58);
			_canvas.Name = "_canvas";
			_canvas.Size = new System.Drawing.Size(605, 380);
			_canvas.TabIndex = 5;
			_canvas.TabStop = false;
			// 
			// _btnOpen
			// 
			_btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			_btnOpen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			_btnOpen.Location = new System.Drawing.Point(623, 53);
			_btnOpen.Name = "_btnOpen";
			_btnOpen.Size = new System.Drawing.Size(79, 30);
			_btnOpen.TabIndex = 6;
			_btnOpen.Text = "Open";
			_btnOpen.UseVisualStyleBackColor = true;
			_btnOpen.Click += OnOpenClick;
			// 
			// _btnRender
			// 
			_btnRender.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			_btnRender.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			_btnRender.Location = new System.Drawing.Point(708, 53);
			_btnRender.Name = "_btnRender";
			_btnRender.Size = new System.Drawing.Size(79, 30);
			_btnRender.TabIndex = 7;
			_btnRender.Text = "Render";
			_btnRender.UseVisualStyleBackColor = true;
			_btnRender.Click += OnRenderClick;
			// 
			// _btnRandomizeSeed
			// 
			_btnRandomizeSeed.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			_btnRandomizeSeed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			_btnRandomizeSeed.Location = new System.Drawing.Point(623, 89);
			_btnRandomizeSeed.Name = "_btnRandomizeSeed";
			_btnRandomizeSeed.Size = new System.Drawing.Size(164, 30);
			_btnRandomizeSeed.TabIndex = 8;
			_btnRandomizeSeed.Text = "Random seed";
			_btnRandomizeSeed.UseVisualStyleBackColor = true;
			_btnRandomizeSeed.Click += _btnRandomizeSeed_Click;
			// 
			// _numIter
			// 
			_numIter.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			_numIter.Location = new System.Drawing.Point(737, 130);
			_numIter.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
			_numIter.Name = "_numIter";
			_numIter.Size = new System.Drawing.Size(52, 23);
			_numIter.TabIndex = 9;
			_numIter.Value = new decimal(new int[] { 5, 0, 0, 0 });
			// 
			// label1
			// 
			label1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			label1.Location = new System.Drawing.Point(625, 132);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(87, 21);
			label1.TabIndex = 10;
			label1.Text = "Iterations:";
			// 
			// label2
			// 
			label2.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			label2.Location = new System.Drawing.Point(625, 167);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(101, 21);
			label2.TabIndex = 12;
			label2.Text = "Angle jitter:";
			// 
			// _numJitter
			// 
			_numJitter.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			_numJitter.Location = new System.Drawing.Point(737, 165);
			_numJitter.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
			_numJitter.Name = "_numJitter";
			_numJitter.Size = new System.Drawing.Size(52, 23);
			_numJitter.TabIndex = 11;
			// 
			// _btnRenderTree
			// 
			_btnRenderTree.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			_btnRenderTree.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			_btnRenderTree.Location = new System.Drawing.Point(625, 201);
			_btnRenderTree.Name = "_btnRenderTree";
			_btnRenderTree.Size = new System.Drawing.Size(162, 30);
			_btnRenderTree.TabIndex = 13;
			_btnRenderTree.Text = "RenderTree";
			_btnRenderTree.UseVisualStyleBackColor = true;
			_btnRenderTree.Click += OnRenderTreeClick;
			// 
			// Form1a
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(799, 450);
			Controls.Add(_btnRenderTree);
			Controls.Add(label2);
			Controls.Add(_numJitter);
			Controls.Add(label1);
			Controls.Add(_numIter);
			Controls.Add(_btnRandomizeSeed);
			Controls.Add(_btnRender);
			Controls.Add(_btnOpen);
			Controls.Add(_canvas);
			DoubleBuffered = true;
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
			Controls.SetChildIndex(_btnRenderTree, 0);
			((System.ComponentModel.ISupportInitialize)_canvas).EndInit();
			((System.ComponentModel.ISupportInitialize)_numIter).EndInit();
			((System.ComponentModel.ISupportInitialize)_numJitter).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		private System.Windows.Forms.Button _btnRenderTree;

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
