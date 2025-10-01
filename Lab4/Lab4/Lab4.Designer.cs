
namespace Lab4
{
    partial class Lab4
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
            btnCreatePolygon = new Button();
            pb = new PictureBox();
            btn_DeleteSelectedPolygon = new Button();
            btn_DeleteSelectedVertex = new Button();
            btn_Clear = new Button();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            SuspendLayout();
            // 
            // btnCreatePolygon
            // 
            btnCreatePolygon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreatePolygon.FlatAppearance.BorderColor = Color.Black;
            btnCreatePolygon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreatePolygon.Location = new Point(418, 9);
            btnCreatePolygon.Margin = new Padding(3, 2, 3, 2);
            btnCreatePolygon.Name = "btnCreatePolygon";
            btnCreatePolygon.Size = new Size(248, 27);
            btnCreatePolygon.TabIndex = 1;
            btnCreatePolygon.Text = "Создать полигон";
            btnCreatePolygon.UseVisualStyleBackColor = true;
            btnCreatePolygon.Click += btnCreatePolygon_Click;
            // 
            // pb
            // 
            pb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pb.BorderStyle = BorderStyle.FixedSingle;
            pb.Location = new Point(10, 9);
            pb.Margin = new Padding(3, 2, 3, 2);
            pb.Name = "pb";
            pb.Size = new Size(402, 320);
            pb.TabIndex = 2;
            pb.TabStop = false;
            pb.Paint += pb_Paint;
            pb.MouseClick += pb_MouseClick;
            pb.MouseDown += pb_MouseDown;
            pb.MouseMove += pb_MouseMove;
            pb.MouseUp += pb_MouseUp;
            // 
            // btn_DeleteSelectedPolygon
            // 
            btn_DeleteSelectedPolygon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_DeleteSelectedPolygon.FlatAppearance.BorderColor = Color.Black;
            btn_DeleteSelectedPolygon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_DeleteSelectedPolygon.Location = new Point(418, 40);
            btn_DeleteSelectedPolygon.Margin = new Padding(3, 2, 3, 2);
            btn_DeleteSelectedPolygon.Name = "btn_DeleteSelectedPolygon";
            btn_DeleteSelectedPolygon.Size = new Size(248, 27);
            btn_DeleteSelectedPolygon.TabIndex = 3;
            btn_DeleteSelectedPolygon.Text = "Удалить выбранный полигон";
            btn_DeleteSelectedPolygon.UseVisualStyleBackColor = true;
            btn_DeleteSelectedPolygon.Click += btn_DeleteSelectedPolygon_Click;
            // 
            // btn_DeleteSelectedVertex
            // 
            btn_DeleteSelectedVertex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_DeleteSelectedVertex.FlatAppearance.BorderColor = Color.Black;
            btn_DeleteSelectedVertex.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_DeleteSelectedVertex.Location = new Point(418, 71);
            btn_DeleteSelectedVertex.Margin = new Padding(3, 2, 3, 2);
            btn_DeleteSelectedVertex.Name = "btn_DeleteSelectedVertex";
            btn_DeleteSelectedVertex.Size = new Size(248, 27);
            btn_DeleteSelectedVertex.TabIndex = 4;
            btn_DeleteSelectedVertex.Text = "Удалить выбранную вершину";
            btn_DeleteSelectedVertex.UseVisualStyleBackColor = true;
            btn_DeleteSelectedVertex.Click += btn_DeleteSelectedVertex_Click;
            // 
            // btn_Clear
            // 
            btn_Clear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Clear.FlatAppearance.BorderColor = Color.Black;
            btn_Clear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_Clear.Location = new Point(418, 102);
            btn_Clear.Margin = new Padding(3, 2, 3, 2);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.Size = new Size(248, 27);
            btn_Clear.TabIndex = 5;
            btn_Clear.Text = "Очистить";
            btn_Clear.UseVisualStyleBackColor = true;
            btn_Clear.Click += btn_Clear_Click;
            // 
            // Lab4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 338);
            Controls.Add(btn_Clear);
            Controls.Add(btn_DeleteSelectedVertex);
            Controls.Add(btn_DeleteSelectedPolygon);
            Controls.Add(pb);
            Controls.Add(btnCreatePolygon);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Lab4";
            Text = "Lab4";
            ((System.ComponentModel.ISupportInitialize)pb).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnCreatePolygon;
        private PictureBox pb;
        private Button btn_DeleteSelectedPolygon;
        private Button btn_DeleteSelectedVertex;
        private Button btn_Clear;
    }
}
