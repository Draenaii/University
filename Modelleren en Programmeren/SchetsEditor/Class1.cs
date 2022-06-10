using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SchetsEditor
{
    public class Element
    {
        public string tool; 
        public Point pos1, pos2; 
        public Color kleur; 
        public String tekst;

        public Element(string tool, Point pos1, Point pos2, Color kleur, String tekst="")
        {
            this.tool = tool;
            this.pos1 = pos1;
            this.pos2 = pos2;
            this.kleur = kleur;
            this.tekst = tekst;
        }
    }
}

// Gemaakt door Sam Groen & Thijmen van der Meijden
