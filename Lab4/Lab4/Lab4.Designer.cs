
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
            lbl_PolyCount = new Label();
            lbl_VertCount = new Label();
            btn_CheckPoint = new Button();
            numeric_dx = new NumericUpDown();
            numeric_dy = new NumericUpDown();
            lbl_dx = new Label();
            lbl_dy = new Label();
            btn_Shift = new Button();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numeric_dx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numeric_dy).BeginInit();
            SuspendLayout();
            // 
            // btnCreatePolygon
            // 
            btnCreatePolygon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreatePolygon.FlatAppearance.BorderColor = Color.Black;
            btnCreatePolygon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreatePolygon.Location = new Point(694, 9);
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
            pb.Size = new Size(678, 576);
            pb.TabIndex = 2;
            pb.TabStop = false;
            pb.Paint += pb_Paint;
            pb.MouseDown += pb_MouseDown;
            pb.MouseMove += pb_MouseMove;
            pb.MouseUp += pb_MouseUp;
            // 
            // btn_DeleteSelectedPolygon
            // 
            btn_DeleteSelectedPolygon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_DeleteSelectedPolygon.FlatAppearance.BorderColor = Color.Black;
            btn_DeleteSelectedPolygon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_DeleteSelectedPolygon.Location = new Point(694, 40);
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
            btn_DeleteSelectedVertex.Location = new Point(694, 71);
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
            btn_Clear.Location = new Point(694, 102);
            btn_Clear.Margin = new Padding(3, 2, 3, 2);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.Size = new Size(248, 27);
            btn_Clear.TabIndex = 5;
            btn_Clear.Text = "Очистить";
            btn_Clear.UseVisualStyleBackColor = true;
            btn_Clear.Click += btn_Clear_Click;
            // 
            // lbl_PolyCount
            // 
            lbl_PolyCount.AutoSize = true;
            lbl_PolyCount.Location = new Point(12, 16);
            lbl_PolyCount.Name = "lbl_PolyCount";
            lbl_PolyCount.Size = new Size(59, 15);
            lbl_PolyCount.TabIndex = 6;
            lbl_PolyCount.Text = "Polygons:";
            // 
            // lbl_VertCount
            // 
            lbl_VertCount.AutoSize = true;
            lbl_VertCount.ImageAlign = ContentAlignment.TopLeft;
            lbl_VertCount.Location = new Point(12, 35);
            lbl_VertCount.Name = "lbl_VertCount";
            lbl_VertCount.Size = new Size(50, 15);
            lbl_VertCount.TabIndex = 7;
            lbl_VertCount.Text = "Vertices:";
            // 
            // btn_CheckPoint
            // 
            btn_CheckPoint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_CheckPoint.FlatAppearance.BorderColor = Color.Black;
            btn_CheckPoint.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_CheckPoint.Location = new Point(694, 529);
            btn_CheckPoint.Margin = new Padding(3, 2, 3, 2);
            btn_CheckPoint.Name = "btn_CheckPoint";
            btn_CheckPoint.Size = new Size(248, 27);
            btn_CheckPoint.TabIndex = 8;
            btn_CheckPoint.Text = "Принадлежность точки";
            btn_CheckPoint.UseVisualStyleBackColor = true;
            btn_CheckPoint.Click += btn_CheckPoint_Click;
            // 
            // numeric_dx
            // 
            numeric_dx.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numeric_dx.Location = new Point(725, 134);
            numeric_dx.Name = "numeric_dx";
            numeric_dx.Size = new Size(95, 23);
            numeric_dx.TabIndex = 9;
            // 
            // numeric_dy
            // 
            numeric_dy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numeric_dy.Location = new Point(726, 163);
            numeric_dy.Name = "numeric_dy";
            numeric_dy.Size = new Size(95, 23);
            numeric_dy.TabIndex = 10;
            // 
            // lbl_dx
            // 
            lbl_dx.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_dx.AutoSize = true;
            lbl_dx.Location = new Point(697, 136);
            lbl_dx.Name = "lbl_dx";
            lbl_dx.Size = new Size(22, 15);
            lbl_dx.TabIndex = 11;
            lbl_dx.Text = "dx:";
            // 
            // lbl_dy
            // 
            lbl_dy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_dy.AutoSize = true;
            lbl_dy.Location = new Point(697, 165);
            lbl_dy.Name = "lbl_dy";
            lbl_dy.Size = new Size(23, 15);
            lbl_dy.TabIndex = 12;
            lbl_dy.Text = "dy:";
            // 
            // btn_Shift
            // 
            btn_Shift.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Shift.FlatAppearance.BorderColor = Color.Black;
            btn_Shift.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_Shift.Location = new Point(826, 133);
            btn_Shift.Margin = new Padding(3, 2, 3, 2);
            btn_Shift.Name = "btn_Shift";
            btn_Shift.Size = new Size(116, 53);
            btn_Shift.TabIndex = 13;
            btn_Shift.Text = "Применить сдвиг";
            btn_Shift.UseVisualStyleBackColor = true;
            btn_Shift.Click += btn_Shift_Click;
            // 
            // Lab4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 594);
            Controls.Add(btn_Shift);
            Controls.Add(lbl_dy);
            Controls.Add(lbl_dx);
            Controls.Add(numeric_dy);
            Controls.Add(numeric_dx);
            Controls.Add(btn_CheckPoint);
            Controls.Add(lbl_VertCount);
            Controls.Add(lbl_PolyCount);
            Controls.Add(btn_Clear);
            Controls.Add(btn_DeleteSelectedVertex);
            Controls.Add(btn_DeleteSelectedPolygon);
            Controls.Add(pb);
            Controls.Add(btnCreatePolygon);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Lab4";
            Text = "Lab4";
            ((System.ComponentModel.ISupportInitialize)pb).EndInit();
            ((System.ComponentModel.ISupportInitialize)numeric_dx).EndInit();
            ((System.ComponentModel.ISupportInitialize)numeric_dy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCreatePolygon;
        private PictureBox pb;
        private Button btn_DeleteSelectedPolygon;
        private Button btn_DeleteSelectedVertex;
        private Button btn_Clear;
        private Label lbl_PolyCount;
        private Label lbl_VertCount;
        private Button btn_CheckPoint;
        private NumericUpDown numeric_dx;
        private NumericUpDown numeric_dy;
        private Label lbl_dx;
        private Label lbl_dy;
        private Button btn_Shift;
    }
}
