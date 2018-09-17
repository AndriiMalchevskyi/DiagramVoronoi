namespace DiagramVoronoi
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictureBoxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.drawTriangulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawCirclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ListBoxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deletePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.coordinatesStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PointsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PictureBoxMenuStrip.SuspendLayout();
            this.ListBoxMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.ContextMenuStrip = this.PictureBoxMenuStrip;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 290);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picture1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture1_MouseMove);
            // 
            // PictureBoxMenuStrip
            // 
            this.PictureBoxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawTriangulationToolStripMenuItem,
            this.drawCirclesToolStripMenuItem,
            this.generatePointsToolStripMenuItem});
            this.PictureBoxMenuStrip.Name = "PictureBoxMenuStrip";
            this.PictureBoxMenuStrip.Size = new System.Drawing.Size(181, 92);
            // 
            // drawTriangulationToolStripMenuItem
            // 
            this.drawTriangulationToolStripMenuItem.Name = "drawTriangulationToolStripMenuItem";
            this.drawTriangulationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawTriangulationToolStripMenuItem.Text = "Draw triangulation";
            this.drawTriangulationToolStripMenuItem.Click += new System.EventHandler(this.drawTriangulationToolStripMenuItem_Click);
            // 
            // drawCirclesToolStripMenuItem
            // 
            this.drawCirclesToolStripMenuItem.Name = "drawCirclesToolStripMenuItem";
            this.drawCirclesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawCirclesToolStripMenuItem.Text = "Draw circles";
            this.drawCirclesToolStripMenuItem.Click += new System.EventHandler(this.drawCirclesToolStripMenuItem_Click);
            // 
            // generatePointsToolStripMenuItem
            // 
            this.generatePointsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.generatePointsToolStripMenuItem.Name = "generatePointsToolStripMenuItem";
            this.generatePointsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.generatePointsToolStripMenuItem.Text = "Generate points";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.ContextMenuStrip = this.ListBoxMenuStrip;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(598, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(186, 290);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ListBoxMenuStrip
            // 
            this.ListBoxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deletePointToolStripMenuItem,
            this.changePointToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.ListBoxMenuStrip.Name = "ListBoxMenuStrip";
            this.ListBoxMenuStrip.Size = new System.Drawing.Size(147, 70);
            // 
            // deletePointToolStripMenuItem
            // 
            this.deletePointToolStripMenuItem.Name = "deletePointToolStripMenuItem";
            this.deletePointToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.deletePointToolStripMenuItem.Text = "Delete point";
            this.deletePointToolStripMenuItem.Click += new System.EventHandler(this.deletePointToolStripMenuItem_Click);
            // 
            // changePointToolStripMenuItem
            // 
            this.changePointToolStripMenuItem.Name = "changePointToolStripMenuItem";
            this.changePointToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.changePointToolStripMenuItem.Text = "Change point";
            this.changePointToolStripMenuItem.Click += new System.EventHandler(this.changePointToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coordinatesStatusLabel,
            this.PointsStatusLabel,
            this.TimeStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 321);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(796, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // coordinatesStatusLabel
            // 
            this.coordinatesStatusLabel.Name = "coordinatesStatusLabel";
            this.coordinatesStatusLabel.Size = new System.Drawing.Size(74, 17);
            this.coordinatesStatusLabel.Text = "Coordinates:";
            // 
            // PointsStatusLabel
            // 
            this.PointsStatusLabel.Name = "PointsStatusLabel";
            this.PointsStatusLabel.Size = new System.Drawing.Size(43, 17);
            this.PointsStatusLabel.Text = "Points:";
            // 
            // TimeStatusLabel
            // 
            this.TimeStatusLabel.Name = "TimeStatusLabel";
            this.TimeStatusLabel.Size = new System.Drawing.Size(92, 17);
            this.TimeStatusLabel.Text = "Generation time";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "25";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "50";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "100";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = "125";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem6.Text = "150";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 343);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Voronoi";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PictureBoxMenuStrip.ResumeLayout(false);
            this.ListBoxMenuStrip.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel coordinatesStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel PointsStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel TimeStatusLabel;
        private System.Windows.Forms.ContextMenuStrip ListBoxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deletePointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip PictureBoxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem drawTriangulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawCirclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
    }
}

