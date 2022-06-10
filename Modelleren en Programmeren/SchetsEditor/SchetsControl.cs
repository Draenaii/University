using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SchetsEditor
{   public class SchetsControl : UserControl
    {   private Schets schets;
        private Color penkleur;

        public Color PenKleur
        { get { return penkleur; }
        }
        public Schets Schets
        { get { return schets;   }
        }
        public SchetsControl()
        {   this.BorderStyle = BorderStyle.Fixed3D;
            this.schets = new Schets();
            this.Paint += this.teken;
            this.Resize += this.veranderAfmeting;
            this.veranderAfmeting(null, null);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
        public void teken(object o, PaintEventArgs pea)
        {   schets.Teken(pea.Graphics);
        }
        private void veranderAfmeting(object o, EventArgs ea)
        {   schets.VeranderAfmeting(this.ClientSize);
            this.Invalidate();
        }
        public Graphics MaakBitmapGraphics()
        {   Graphics g = schets.BitmapGraphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            return g;
        }
        public void Schoon(object o, EventArgs ea)
        {   schets.Schoon();
            this.Invalidate();
        }
        public void Roteer(object o, EventArgs ea)
        {   //schets.VeranderAfmeting(new Size(this.ClientSize.Height, this.ClientSize.Width));
            schets.Roteer();
            this.Invalidate();
        }
        public void Undo(object o, EventArgs ea)
        {
            schets.Undo();
            this.Invalidate();
        }
        public void Redo(object o, EventArgs ea)
        {
            schets.Redo();
            this.Invalidate();
        }
        public void VeranderKleur(object obj, EventArgs ea)
        {   string kleurNaam = ((ComboBox)obj).Text;
            penkleur = Color.FromName(kleurNaam);
        }
        public void VeranderKleurViaMenu(object obj, EventArgs ea)
        {   string kleurNaam = ((ToolStripMenuItem)obj).Text;
            penkleur = Color.FromName(kleurNaam);
        }
        public List<List<String>> MaaklijstString()
        {
            List<List<String>> GroteLijst = new List<List<String>>();
            //Schets schets = new Schets();
            foreach (Element e in Schets.elements)
            {
                List<String> list = new List<String>();
                list.Add(e.tool + " ");

                list.Add(e.pos1.X.ToString() + " ");
                list.Add(e.pos1.Y.ToString() + " ");

                list.Add(e.pos2.X.ToString() + " ");
                list.Add(e.pos2.Y.ToString() + " ");

                list.Add(e.kleur.R.ToString() + " ");
                list.Add(e.kleur.G.ToString() + " ");
                list.Add(e.kleur.B.ToString() + " ");

                list.Add(e.tekst);

                GroteLijst.Add(list);
            }
            return GroteLijst;
        }
    }
}
