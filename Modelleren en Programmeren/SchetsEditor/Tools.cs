using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SchetsEditor
{
    public interface ISchetsTool
    {
        void MuisVast(SchetsControl s, Point p);
        void MuisDrag(SchetsControl s, Point p);
        void MuisLos(SchetsControl s, Point p);
        void Letter(SchetsControl s, char c);
    }

    public abstract class StartpuntTool : ISchetsTool
    {
        protected Point startpunt;
        protected Brush kwast;

        public virtual void MuisVast(SchetsControl s, Point p)
        {   startpunt = p;
        }
        public virtual void MuisLos(SchetsControl s, Point p)
        {   kwast = new SolidBrush(s.PenKleur);
        }
        public abstract void MuisDrag(SchetsControl s, Point p);
        public abstract void Letter(SchetsControl s, char c);
    }

    public class TekstTool : StartpuntTool
    {
        public override string ToString() { return "tekst"; }

        public override void MuisDrag(SchetsControl s, Point p) { }

        public override void Letter(SchetsControl s, char c)
        {
            if (c >= 32)
            {
                Graphics gr = s.MaakBitmapGraphics();
                Font font = new Font("Tahoma", 40);
                string tekst = c.ToString();
                SizeF sz = 
                gr.MeasureString(tekst, font, this.startpunt, StringFormat.GenericTypographic);
                gr.DrawString   (tekst, font, kwast, 
                                              this.startpunt, StringFormat.GenericTypographic);
                Element text = new Element("tekst", this.startpunt, new Point((int)(this.startpunt.X + sz.Width), (int)(this.startpunt.Y + sz.Height)),s.PenKleur, tekst);
                s.Schets.elements.Add(text);
                gr.DrawRectangle(Pens.Black, startpunt.X, startpunt.Y, sz.Width, sz.Height);
                startpunt.X += (int)sz.Width;
                s.Invalidate();
            }
        }
    }

    public abstract class TweepuntTool : StartpuntTool
    {
        public static Rectangle Punten2Rechthoek(Point p1, Point p2)
        {   return new Rectangle( new Point(Math.Min(p1.X,p2.X), Math.Min(p1.Y,p2.Y))
                                , new Size (Math.Abs(p1.X-p2.X), Math.Abs(p1.Y-p2.Y))
                                );
        }
        public static Pen MaakPen(Brush b, int dikte)
        {   Pen pen = new Pen(b, dikte);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            return pen;
        }
        public override void MuisVast(SchetsControl s, Point p)
        {   base.MuisVast(s, p);
            kwast = Brushes.Gray;
        }
        public override void MuisDrag(SchetsControl s, Point p)
        {   s.Refresh();
            this.Bezig(s.CreateGraphics(), this.startpunt, p);
        }
        public override void MuisLos(SchetsControl s, Point p)
        {   base.MuisLos(s, p);
            Element elem = new Element(this.ToString(), this.startpunt, p, s.PenKleur);
            s.Schets.elements.Add(elem);
            this.Compleet(s.MaakBitmapGraphics(), this.startpunt, p);
            s.Invalidate();
        }
        public override void Letter(SchetsControl s, char c)
        {
        }
        public abstract void Bezig(Graphics g, Point p1, Point p2);
        
        public virtual void Compleet(Graphics g, Point p1, Point p2)
        {   this.Bezig(g, p1, p2);
        }
    }

    public class RechthoekTool : TweepuntTool
    {
        public override string ToString() { return "kader"; }

        public override void Bezig(Graphics g, Point p1, Point p2)
        {   g.DrawRectangle(MaakPen(kwast,3), TweepuntTool.Punten2Rechthoek(p1, p2));
        }
    }
    
    public class VolRechthoekTool : RechthoekTool
    {
        public override string ToString() { return "vlak"; }

        public override void Compleet(Graphics g, Point p1, Point p2)
        {   g.FillRectangle(kwast, TweepuntTool.Punten2Rechthoek(p1, p2));
        }
    }

    public class LijnTool : TweepuntTool
    {
        public override string ToString() { return "lijn"; }

        public override void Bezig(Graphics g, Point p1, Point p2)
        {   g.DrawLine(MaakPen(this.kwast,3), p1, p2);
        }
    }

    public class PenTool : LijnTool
    {
        public override string ToString() { return "pen"; }

        public override void MuisDrag(SchetsControl s, Point p)
        {   this.MuisLos(s, p);
            this.MuisVast(s, p);
        }
    }
    
    public class GumTool : PenTool
    {
        public override string ToString() { return "gum"; }

        public override void Bezig(Graphics g, Point p1, Point p2)
        {   g.DrawLine(MaakPen(Brushes.White, 7), p1, p2);
        }
        public override void MuisLos(SchetsControl s, Point p)
        {
            for (int t = (s.Schets.elements.Count -1); t > -1; t--)
            {
                foreach (Element e in s.Schets.elements)
                {
                    double k = Math.Abs((s.Schets.elements[t].pos2.X - s.Schets.elements[t].pos1.X) * (s.Schets.elements[t].pos1.Y - p.Y) - (s.Schets.elements[t].pos1.X - p.X) * (s.Schets.elements[t].pos2.Y - s.Schets.elements[t].pos1.Y)) / Math.Sqrt((s.Schets.elements[t].pos2.X - s.Schets.elements[t].pos1.X) * (s.Schets.elements[t].pos2.X - s.Schets.elements[t].pos1.X) + (s.Schets.elements[t].pos2.Y - s.Schets.elements[t].pos1.Y) * (s.Schets.elements[t].pos2.Y - s.Schets.elements[t].pos1.Y));
                    if (s.Schets.elements[t].tool == "lijn")
                    {
                        if (-5 <= k && k <= 5)
                        {
                            s.Schets.prul.Add(s.Schets.elements[t]);
                            s.Schets.elements.RemoveAt(t);
                            s.Invalidate();
                            break;
                        }
                    }

                    if (s.Schets.elements[t].tool == "pen")
                    {
                        if (-1 <= k && k <= 1)
                        {
                            s.Schets.prul.Add(s.Schets.elements[t]);
                            s.Schets.elements.RemoveAt(t);
                            s.Invalidate();
                            break;
                        }
                    }

                    if (s.Schets.elements[t].tool == "kader")
                    {
                        if ((p.X > s.Schets.elements[t].pos1.X - 5 && p.X < s.Schets.elements[t].pos1.X + 5) || (p.X < s.Schets.elements[t].pos2.X + 5 && p.X > s.Schets.elements[t].pos2.X - 5) || (p.Y > s.Schets.elements[t].pos1.Y - 5 && p.Y < s.Schets.elements[t].pos1.Y + 5) || (p.Y < s.Schets.elements[t].pos2.Y + 5 && p.Y > s.Schets.elements[t].pos2.Y - 5))
                        {
                            s.Schets.prul.Add(s.Schets.elements[t]);
                            s.Schets.elements.RemoveAt(t);
                            s.Invalidate();
                            break;
                        }
                    }

                    if (s.Schets.elements[t].tool == "vlak")
                    {
                        if ((p.X > s.Schets.elements[t].pos1.X && p.X < s.Schets.elements[t].pos2.X) || (p.X > s.Schets.elements[t].pos2.X && p.X < s.Schets.elements[t].pos1.X))
                        {
                            if ((p.Y > s.Schets.elements[t].pos1.Y && p.Y < s.Schets.elements[t].pos2.Y) || (p.Y > s.Schets.elements[t].pos2.Y && p.Y < s.Schets.elements[t].pos1.Y))
                            {
                                s.Schets.prul.Add(s.Schets.elements[t]);
                                s.Schets.elements.RemoveAt(t);
                                s.Invalidate();
                                break;
                            }
                        }
                    }

                    if (s.Schets.elements[t].tool == "tekst")
                    {
                        if ((p.X > s.Schets.elements[t].pos1.X && p.X < s.Schets.elements[t].pos2.X) || (p.X > s.Schets.elements[t].pos2.X && p.X < s.Schets.elements[t].pos1.X))
                        {
                            if ((p.Y > s.Schets.elements[t].pos1.Y && p.Y < s.Schets.elements[t].pos2.Y) || (p.Y > s.Schets.elements[t].pos2.Y && p.Y < s.Schets.elements[t].pos1.Y))
                            {
                                s.Schets.prul.Add(s.Schets.elements[t]);
                                s.Schets.elements.RemoveAt(t);
                                s.Invalidate();
                                break;
                            }
                        }
                    }
                }
                break;
            }
        }
    }
}
