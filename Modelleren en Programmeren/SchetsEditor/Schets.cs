using System;
using System.Collections.Generic;
using System.Drawing;

namespace SchetsEditor
{
    public class Schets
    {
        private Bitmap bitmap;
        public List<Element> elements;
        public List<Element> prul;
        
        public Schets()
        {
            bitmap = new Bitmap(1, 1);
            elements = new List<Element>();
            prul = new List<Element>();
        }
        public Graphics BitmapGraphics
        {
            get { return Graphics.FromImage(bitmap); }
        }
        public void VeranderAfmeting(Size sz)
        {
            if (sz.Width > bitmap.Size.Width || sz.Height > bitmap.Size.Height)
            {
                Bitmap nieuw = new Bitmap( Math.Max(sz.Width,  bitmap.Size.Width)
                                         , Math.Max(sz.Height, bitmap.Size.Height)
                                         );
                Graphics gr = Graphics.FromImage(nieuw);
                gr.FillRectangle(Brushes.White, 0, 0, sz.Width, sz.Height);
                //gr.DrawImage(bitmap, 0, 0);
                bitmap = nieuw;
            }
        }
        public void Teken(Graphics gr)
        {
            gr.FillRectangle(Brushes.White, 0, 0, 10000, 10000);
            foreach (Element e in elements)
            {
                if (e.tool == "tekst")
                {
                    gr.DrawString(e.tekst, new Font("Tahoma", 40), new SolidBrush(e.kleur), e.pos1, StringFormat.GenericTypographic);
                }
                else if (e.tool == "kader")
                { 
                    gr.DrawRectangle(new Pen(e.kleur),
                        new Rectangle(new Point(Math.Min(e.pos1.X, e.pos2.X), Math.Min(e.pos1.Y, e.pos2.Y)), new Size(Math.Abs(e.pos1.X - e.pos2.X), Math.Abs(e.pos1.Y - e.pos2.Y))));
                }
                else if (e.tool == "vlak")
                {
                    gr.FillRectangle(new SolidBrush(e.kleur), new Rectangle(new Point(Math.Min(e.pos1.X, e.pos2.X), Math.Min(e.pos1.Y, e.pos2.Y)), new Size(Math.Abs(e.pos1.X - e.pos2.X), Math.Abs(e.pos1.Y - e.pos2.Y))));
                }
                else if (e.tool == "lijn")
                {
                    gr.DrawLine(TweepuntTool.MaakPen(new SolidBrush(e.kleur), 3), e.pos1, e.pos2);
                }
                else if (e.tool == "pen")
                {
                    gr.DrawLine(TweepuntTool.MaakPen(new SolidBrush(e.kleur), 3), e.pos1, e.pos2);
                }
            }
            
        }
        public void Schoon()
        {
            Graphics gr = Graphics.FromImage(bitmap);
            elements.Clear();
            gr.FillRectangle(Brushes.White, 0, 0, 10000, 10000);
        }
        public void Roteer()
        {
            Graphics gr = Graphics.FromImage(bitmap);
            foreach (Element e in elements)
            {
                int x1 = e.pos1.X - bitmap.Size.Width/2;
                int y1 = e.pos1.Y - bitmap.Size.Height/2;
                int x2 = e.pos2.X - bitmap.Size.Width/2;
                int y2 = e.pos2.Y - bitmap.Size.Height/2;

                x1 = y1;
                y1 = -x1;
                x2 = y2;
                y2 = -x2;

                e.pos1.X = x1 + bitmap.Size.Width/2;
                e.pos1.Y = y1 + bitmap.Size.Height/2;
                e.pos2.X = x2 + bitmap.Size.Width/2;
                e.pos2.Y = y2 + bitmap.Size.Height/2;

            }
        }
        public void Undo()
        {
            if (elements.Count > 0)
            {
                prul.Add(elements[elements.Count - 1]);
                elements.Remove(elements[elements.Count - 1]);
            }
        }
        public void Redo()
        {
            if (prul.Count > 0)
            {
                elements.Add(prul[prul.Count - 1]);
                prul.Remove(prul[prul.Count - 1]);
            }
        }

    }
}
