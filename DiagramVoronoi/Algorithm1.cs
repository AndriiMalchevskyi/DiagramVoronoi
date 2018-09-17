using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DiagramVoronoi
{
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };

    

    //Represents kline equation in the following form: Ax + By + C = 0
    public struct LineEquation
    {
        private static bool AreEqual(float left, float right)
    {
        return Math.Abs(left - right) < (float)0.000001;
    }
        //Ax + By + C = 0
        public float A { get; set; }
        //Ax + By + C = 0
        public float B { get; set; }
        //Ax + By + C = 0
        public float C { get; set; }

        public LineEquation(float A, float B, float C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public LineEquation(PointF p1, PointF p2)
        {
            A = p2.Y - p1.Y;
            B = p1.X - p2.X;
            C = -(p1.Y * B + p1.X * A);
        }

        public static LineEquation CreateFromParallelVector(float vectorX, float vectorY, PointF point)
        {
            return CreateFromPerpendicullarVector(vectorY, -vectorX, point);
        }

        public static LineEquation CreateFromParallelVector(PointF vector, PointF point)
        {
            return CreateFromParallelVector(vector.X, vector.Y, point);
        }

        public static LineEquation CreateFromPerpendicullarVector(float vectorX, float vectorY, PointF point)
        {
            return new LineEquation(vectorX, vectorY, -(vectorX * point.X + vectorY * point.Y));
        }

        public static LineEquation CreateFromPerpendicullarVector(PointF vector, PointF point)
        {
            return CreateFromPerpendicullarVector(vector.X, vector.Y, point);
        }

        public LineEquation GetPerpendicullarLine(PointF point)
        {
            return CreateFromPerpendicullarVector(GetParallelVector(), point);
        }

        public LineEquation GetParallelLine(PointF point)
        {
            return CreateFromParallelVector(GetPerpendicullarVector(), point);
        }

        public PointF GetPerpendicullarVector()
        {
            return new PointF(A, B);
        }

        public PointF GetParallelVector()
        {
            return new PointF(B, -A);
        }

        public static PointF Intersect(LineEquation first, LineEquation second)
        {
            PointF toret = new PointF();
            if (AreEqual(first.A, 0))
            {
                toret.Y = -first.C / first.B;
                toret.X = -(second.B * toret.Y + second.C) / second.A;
            }
            else if (AreEqual(second.A, 0))
            {
                toret.Y = -second.C / second.B;
                toret.X = -(first.B * toret.Y + first.C) / first.A;
            }
            else if (AreEqual(first.B, 0))
            {
                toret.X = -first.C / first.A;
                toret.Y = -(second.A * toret.X + second.C) / second.B;
            }
            else if (AreEqual(first.B, 0))
            {
                toret.X = -second.C / second.A;
                toret.Y = -(first.A * toret.X + first.C) / first.B;
            }
            else
            {
                toret.Y = -(first.C * second.A - second.C * first.A) / (first.B * second.A - second.B * first.A);
                toret.X = -(second.B * toret.Y + second.C) / second.A;
            }
            return toret;
        }

        public static PointF IntersectChecked(LineEquation first, LineEquation second)
        {
            if (!(first.IsSingular() || second.IsSingular()))
            {
                if (AreParallel(first, second))
                {
                    throw new ArgumentException("Can't intersect parallel lines");
                }
                else
                {
                    return Intersect(first, second);
                }
            }
            else
            {
                throw new ArgumentException("Singular lines are not allowed");
            }
        }

        public bool IsSingular()
        {
            return AreEqual(A, 0) && AreEqual(B, 0);
        }

        public static bool AreParallel(LineEquation first, LineEquation second)
        {
            bool isZeroFA = AreEqual(first.A, 0);
            bool isZeroFB = AreEqual(first.B, 0);
            bool isZeroSA = AreEqual(second.A, 0);
            bool isZeroSB = AreEqual(second.B, 0);
            if (!(isZeroFA || isZeroFB || isZeroSA || isZeroSB))
            {
                return AreEqual(first.A * second.B, first.B * second.A);
            }
            else if ((isZeroFA && isZeroSA) || (isZeroFB && isZeroSB))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Line GetLine()
        {
            return new Line(new PointF(0,-C/B),new PointF(-C/A,0));
        }
    }

    public struct Line
    {
        public PointF A { get; set; }
        public PointF B { get; set; }

        public Line(PointF a, PointF b)
        {
            A = a;
            B = b;
        }
        public static bool operator ==(Line l1, Line l2)
        {
            return (l1.A == l2.A && l1.B == l2.B) || (l1.A == l2.B && l1.B == l2.A);
        }
        public static bool operator !=(Line l1, Line l2)
        {
            return !(l1==l2);
        }

        public static PointF GetMiddlePointF(PointF a, PointF b)
        {
            return new PointF((a.X + b.X) / 2, (a.Y + b.Y) / 2);
        }
        public static double Distance(PointF a, PointF b)
        {
            return System.Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        public PointF GetMiddlePointF()
        {
            return GetMiddlePointF(A, B);
        }
        public double Distance()
        {
            return Distance(A,B);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
    public struct Circle
    {
        public PointF O { get; private set; }
        public double R { get; private set; }

        public Circle(PointF o, double r)
        {
            O = o;
            R = r;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns>1-точка поза колом 0-точка на колі -1-точка в середині кола</returns>
        public int IsPointInCircle(PointF p)
        {
            double res = (p.X-O.X)* (p.X - O.X) + (p.Y-O.Y)* (p.Y - O.Y);
            double r2 = R * R;
            if (res>r2)
            {
                return 1;
            }
            else if (res== r2)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
    public struct Triangle
    {
        public PointF A { get; private set; }
        public PointF B { get; private set; }
        public PointF C { get; private set; }
        
        public Triangle(PointF a, PointF b, PointF c)
        {
            A = a;
            B = b;
            C = c;
        }
        
        public Circle GetDescribedCircle()
        {
            double ab = Line.Distance(A,B);
            double bc = Line.Distance(B,C);
            double ca = Line.Distance(C,A);
            double p = (ab + bc + ca) / 2.0;

            LineEquation line1 = new LineEquation(A, B);
            line1 = line1.GetPerpendicullarLine(Line.GetMiddlePointF(A,B));

            LineEquation line2 = new LineEquation(B, C);
            line2 = line2.GetPerpendicullarLine(Line.GetMiddlePointF(B,C));

            Circle c = new Circle(LineEquation.IntersectChecked(line1, line2),
                (ab * bc * ca) / (4 * (Math.Sqrt(p * (p - ab) * (p - bc) * (p - ca)))));

            return c;

        }

        public double Square()
        {
            double ab = Line.Distance(A, B);
            double bc = Line.Distance(B, C);
            double ca = Line.Distance(C, A);
            double p = (ab + bc + ca) / 2.0;
            return Math.Sqrt(p * (p - ab) * (p - bc) * (p - ca));
        }
        public double Perimeter()
        {
            return Line.Distance(A,B) + Line.Distance(B,C) + Line.Distance(C,A);
        }
        public static bool HasCommonSide(Triangle t1, Triangle t2)
        {
            return ((t1.A != t2.A && t1.B == t2.B && t1.C == t2.C) ||
                    (t1.A != t2.A && t1.B == t2.C && t1.C == t2.B) ||
                    (t1.A != t2.B && t1.B == t2.C && t1.C == t2.A) ||
                    (t1.A != t2.B && t1.B == t2.A && t1.C == t2.C) ||
                    (t1.A != t2.C && t1.B == t2.A && t1.C == t2.B) ||
                    (t1.A != t2.C && t1.B == t2.B && t1.C == t2.C) ||
                    (t1.A == t2.A && t1.B != t2.B && t1.C == t2.C) ||
                    (t1.A == t2.A && t1.B != t2.C && t1.C == t2.B) ||
                    (t1.A == t2.B && t1.B != t2.C && t1.C == t2.A) ||
                    (t1.A == t2.B && t1.B != t2.A && t1.C == t2.C) ||
                    (t1.A == t2.C && t1.B != t2.A && t1.C == t2.B) ||
                    (t1.A == t2.C && t1.B != t2.B && t1.C == t2.A) ||
                    (t1.A == t2.A && t1.B == t2.B && t1.C != t2.C) ||
                    (t1.A == t2.A && t1.B == t2.C && t1.C != t2.B) ||
                    (t1.A == t2.B && t1.B == t2.C && t1.C != t2.A) ||
                    (t1.A == t2.B && t1.B == t2.A && t1.C != t2.C) ||
                    (t1.A == t2.C && t1.B == t2.A && t1.C != t2.B) ||
                    (t1.A == t2.C && t1.B == t2.B && t1.C != t2.A)
                    );
        }

        public static bool operator ==(Triangle t1, Triangle t2)
        {
                return ((t1.A == t2.A && t1.B == t2.B && t1.C == t2.C) ||
                        (t1.A == t2.A && t1.B == t2.C && t1.C == t2.B) ||
                        (t1.A == t2.B && t1.B == t2.A && t1.C == t2.C) ||
                        (t1.A == t2.B && t1.B == t2.C && t1.C == t2.A) ||
                        (t1.A == t2.C && t1.B == t2.A && t1.C == t2.B) ||
                        (t1.A == t2.C && t1.B == t2.B && t1.C == t2.A)
                        );
        }
        public static bool operator !=(Triangle t1, Triangle t2)
        {
            return !(t1==t2);
        }
    }
    public class TriangulationDelaunay
    {
        public static List<Pair<Triangle,Circle>> Triangulation(List<PointF> points)
        {
            List<Pair<Triangle, Circle>> trianglesAndCircles = new List<Pair<Triangle, Circle>>();
            for (int i=0;i<points.Count-2;++i)
            {
                for (int j=i+1;j<points.Count-1;++j)
                {
                    for (int e=j+1;e<points.Count;++e)
                    {
                        if (points[i]!=points[j]&&points[i]!=points[e]&&points[j]!=points[e])
                        {
                            Triangle tr = new Triangle(points[i],points[j],points[e]);
                            Circle dc;
                            try
                            {
                                dc = tr.GetDescribedCircle();
                            }
                            catch
                            {
                                continue;
                            }
                            bool findPointInCircle = false;
                            for (int i1=0;i1<points.Count;++i1)
                            {
                                if (points[i] != points[i1] && points[j] != points[i1] && points[e] != points[i1])
                                {
                                    if(dc.IsPointInCircle(points[i1])==-1)
                                    {
                                        findPointInCircle = true;
                                    }
                                }

                            }
                            if (!findPointInCircle)
                            {
                                Pair<Triangle,Circle> searchedTr=trianglesAndCircles.Find((Pair<Triangle, Circle> a) =>
                                {
                                    return a.First == tr;
                                });
                                if(searchedTr==null)
                                    trianglesAndCircles.Add(new Pair<Triangle, Circle>(tr, dc));
                            }
                        }
                    }
                }
            }
            return trianglesAndCircles;
        }
    }
    public class VoronoiDiagram
    {
        public static List<Line> Voronoi(List<Pair<Triangle, Circle>> pairs)
        {
            List<Line> voronoi = new List<Line>();
            /*foreach (Pair<Triangle, Circle> tr1 in pairs)
            {
                foreach (Pair<Triangle, Circle> tr2 in pairs)
                {
                    if (tr1.First == tr2.First)
                    {
                        continue;
                    }
                    else if (Triangle.HasCommonSide(tr1.First, tr2.First))
                    {
                        
                        voronoi.Add(new Line(tr1.Second.O, tr2.Second.O));
                    }
                }
            }*/
            ///////////
            for (int i=0;i<pairs.Count-1;++i)
            {
                for (int j=i+1;j<pairs.Count;++j)
                {
                    if (Triangle.HasCommonSide(pairs[i].First, pairs[j].First))
                    {
                        voronoi.Add(new Line(pairs[i].Second.O, pairs[j].Second.O));
                    }
                }
            }
            return voronoi;
        }
    }

    
    ///////////////////////////////////////////////////////////////
    public class AlgoSimple
    {
        private List<PointF> points;
        public AlgoSimple()
        {
            points = new List<PointF>();
        }
        public void Add(PointF a)
        {
            points.Add(a);
        }
        public List<LineEquation> GetPerpendicullarLines()
        {
            points.Sort((PointF a, PointF b) => {
                return a.X.CompareTo( b.X);
            });

            List<LineEquation> lines = new List<LineEquation>();
            for (int i = 0; i < points.Count-1; i++)
            {
                for (int j = i+1; j < points.Count; j++)
                {
                    LineEquation a=new LineEquation(points[i],points[j]);
                    LineEquation perLine = a.GetPerpendicullarLine(Line.GetMiddlePointF(points[i], points[j]));
                    lines.Add(perLine);
                }
            }
            return lines;
        }
        public List<Line> GetVoronoiLines(List<LineEquation> lineEquations)
        {
            List<Line> lines = new List<Line>();
            List<PointF> points = new List<PointF>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = i+1; j < points.Count; i++)
                {
                    try
                    {
                        PointF a=LineEquation.IntersectChecked(lineEquations[i], lineEquations[j]);
                        if (a != PointF.Empty)
                            points.Add(a);
                    }
                    catch
                    {
                        continue;
                    }
                }
                for (int j = 0; j < points.Count; j+=2)
                {
                    lines.Add(new Line(points[j],points[j+1]));
                }
            }
            return lines;
        }
    }
}
