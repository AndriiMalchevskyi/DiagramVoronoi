using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DiagramVoronoi
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private List<PointF> PointFs;
        private List<Pair<Triangle, Circle>> triangulation;
        private List<Line> voronoi;
        private Pen penV = new Pen(Brushes.Black, 2);
        private Pen penPoint = new Pen(Brushes.Green, 2);
        private PointF PointForChange;
        public Form1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
            PointFs = new List<PointF>();
            listBox1.SelectionMode = SelectionMode.MultiExtended;

        }

        private void GeneratePoints(int count )
        {
            graphics.Clear(Color.White);
            PointFs = GeneratePoints(pictureBox1.Size.Width, pictureBox1.Size.Height, count);
            UpdateListBox();
            PointsStatusLabel.Text = "Points: " + PointFs.Count.ToString();

            Stopwatch timer = Stopwatch.StartNew();
            triangulation = TriangulationDelaunay.Triangulation(PointFs);
            voronoi = VoronoiDiagram.Voronoi(triangulation);
            timer.Stop();

            TimeStatusLabel.Text = "Generation time " + timer.ElapsedMilliseconds + "ms";
            DrawPoints();
            Draw(penV, voronoi);
        }
        private void Draw(Pen pen,List<Line> lines)
        {
            if(lines!=null)
            foreach (Line l in lines)
            {
                graphics.DrawLine(pen, l.A, l.B);
            }
        }
        private void Draw(Pen penT, Pen penC, List<Pair<Triangle, Circle>> tr, int draw=0)
        {

            if (tr!=null&&(draw == 0 || draw == 1))
            {
                foreach (var t in tr)
                {
                    
                        graphics.DrawLine(penT, t.First.A, t.First.B);
                        graphics.DrawLine(penT, t.First.B, t.First.C);
                        graphics.DrawLine(penT, t.First.C, t.First.A);
                }
            }
            else if (tr != null && (draw == 0 || draw == 2))
                {
                    foreach (var t in tr)
                    {
                        graphics.DrawEllipse(penC, (float)(t.Second.O.X - t.Second.R), (float)(t.Second.O.Y - t.Second.R),
                            (float)t.Second.R * 2, (float)t.Second.R * 2);
                        graphics.DrawEllipse(penC, (float)(t.Second.O.X), (float)(t.Second.O.Y),
                            5, 5);
                    }
                }
        }
        private void DrawPoints()
        {
            foreach (PointF a in PointFs)
            {
                graphics.DrawEllipse(penPoint, a.X, a.Y, 2, 2);
            }
        }
        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            List<string> PointFsC = new List<string>();
            foreach (PointF a in PointFs)
            {
                PointFsC.Add(a.ToString());
                graphics.DrawEllipse(penPoint, a.X, a.Y, 2, 2);
            };
            listBox1.Items.AddRange(PointFsC.ToArray());
        }
        private List<PointF> GeneratePoints(int maxX,int maxY, int count)
        {
            List<PointF> p = new List<PointF>();
            Random ran = new Random((int)DateTime.Now.ToBinary());
            for (int i=0;i<count;++i)
            {
                p.Add(new PointF(ran.Next(maxX),ran.Next(maxY)));
            }
            p.Sort((PointF a, PointF b) =>
            {
                return a.X.CompareTo(b.X);
            });
            return p;
        }
        private void picture1_MouseClick(object sender, MouseEventArgs e)
        {
            if (PointForChange != PointF.Empty)
            {
                int index = PointFs.FindIndex((PointF a) => { return a == PointForChange; });
                PointFs[index] = new PointF(e.X, e.Y);
                PointForChange = PointF.Empty;
            }
            else
            {

                PointFs.Add(new PointF(e.X, e.Y));
            }
            graphics.Clear(Color.White);
            PointFs.Sort((PointF a, PointF b) =>
            {
                return a.X.CompareTo(b.X);
            });
            PointsStatusLabel.Text = "Points: " + PointFs.Count.ToString();

            UpdateListBox();
            DrawPoints();

            Stopwatch timer = Stopwatch.StartNew();
            triangulation = TriangulationDelaunay.Triangulation(PointFs);
            voronoi = VoronoiDiagram.Voronoi(triangulation);
            timer.Stop();

            TimeStatusLabel.Text = "Generation time " + timer.ElapsedMilliseconds + "ms";

            Draw(penV, voronoi);
        }

        private void picture1_MouseMove(object sender, MouseEventArgs e)
        {
            coordinatesStatusLabel.Text = "Coordinates: "+e.X.ToString() + ", " + e.Y.ToString();
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            graphics = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);
            DrawPoints();
            Draw(penV, voronoi);
        }

        private void deletePointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection c = listBox1.SelectedIndices;
            List<PointF> temp=new List<PointF>(PointFs);
            if (c.Count>0)
            {
                for (int i= 0; i<c.Count;++i) {
                    PointFs.Remove(temp[c[i]]);
                }
            }
            triangulation = TriangulationDelaunay.Triangulation(PointFs);
            voronoi = VoronoiDiagram.Voronoi(triangulation);
            graphics.Clear(Color.White);
            UpdateListBox();
            DrawPoints();
            Draw(penV, voronoi);
        }

        private void drawTriangulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen penT = new Pen(Brushes.Blue, 2);
            Draw(penT,null, triangulation, 1);
        }

        private void drawCirclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen penC = new Pen(Brushes.Red, 2);
            Draw(null, penC, triangulation, 2);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            Draw(penV, voronoi);
            Pen penP = new Pen(Brushes.DarkRed, 3);
            foreach (int i in listBox1.SelectedIndices)
            {
                graphics.DrawEllipse(penP, PointFs[i].X, PointFs[i].Y, 3,3);
            }
        }

        private void changePointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count==1)
            {
                PointForChange = PointFs[listBox1.SelectedIndex];
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointFs.Clear();
            UpdateListBox();
            graphics.Clear(Color.White);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GeneratePoints(25);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GeneratePoints(50);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            GeneratePoints(100);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            GeneratePoints(125);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            GeneratePoints(150);
        }
    }
}
