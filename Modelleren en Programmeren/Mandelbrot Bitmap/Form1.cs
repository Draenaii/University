using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot_Bitmap
{
    public partial class Mandelbrot : Form
    {
        double xMidden = 0, yMidden = 0, xcoord = 0, ycoord = 0;
        double schaal = 100;
        int optie = 1, maxMandelNummer = 100;
        int r = 0, g = 0, b = 0;
        public Mandelbrot()
        {
            InitializeComponent();
        }
        private static int CalcMandel(double x, double y, int max)
        {
            double a = 0, b = 0, fa, fb, distance;
            int count = 0;

            fa = (a * a - b * b + x);
            fb = (2 * a * b + y);
            distance = Math.Sqrt(fa * fa + fb * fb);

            while (distance < 2 && count < max)
            {   // Calculate f(a,b)
                fa = (a * a - b * b + x);
                fb = (2 * a * b + y);
                // Calculate distance f(a,b) to f(0,0)
                distance = Math.Sqrt(fa * fa + fb * fb);
                // Mandelbrotgetal
                count++;
                // New a and b to calculate f(a,b)
                a = fa;
                b = fb;
            }
            return count;
        }

        // Calculate X-Coordinate Axis in Panel
        private double CalcXCoords(int x, double xMidden)
        {
            xcoord = (x - 200) / schaal;
            double xcoord2 = xcoord + xMidden;
            return xcoord2;
        }

        // Calculate Y-Coordinate Axis in Panel
        private double CalcYCoords(int y, double yMidden)
        {
            ycoord = ((200 - y) / schaal);
            double ycoord2 = ycoord + yMidden;
            return ycoord2;
        }

        // Electric screenshot button
        private void buttonSSElectric_Click(object sender, EventArgs e)
        {
            MandelbrotPanel.Invalidate();
            optie = 3;
            xMidden = -0.721139945983887;
            yMidden = 0.364983291625976;
            schaal = 52428800;

            textBoxXCoord.Text = xMidden.ToString();
            textBoxYCoord.Text = yMidden.ToString();
            textBoxScale.Text = schaal.ToString();
            textBoxMaxMandelbrot.Text = maxMandelNummer.ToString();
        }

        // Solar flare screenshot button
        private void buttonSSSolar_Click(object sender, EventArgs e)
        {
            MandelbrotPanel.Invalidate();
            optie = 5;
            xMidden = -0.03125;
            yMidden = 0.793125;
            schaal = 3200;

            textBoxXCoord.Text = xMidden.ToString();
            textBoxYCoord.Text = yMidden.ToString();
            textBoxScale.Text = schaal.ToString();
            textBoxMaxMandelbrot.Text = maxMandelNummer.ToString();
        }

        // Hallucination screenshot button
        private void buttonSSBW_Click(object sender, EventArgs e)
        {
            MandelbrotPanel.Invalidate();
            optie = 1;
            xMidden = 0.4246484375;
            yMidden = 0.207578125;
            schaal = 51200;

            textBoxXCoord.Text = xMidden.ToString();
            textBoxYCoord.Text = yMidden.ToString();
            textBoxScale.Text = schaal.ToString();
            textBoxMaxMandelbrot.Text = maxMandelNummer.ToString();
        }

        // Crazy screenshot button
        private void buttonSSCrazy_Click(object sender, EventArgs e)
        {
            MandelbrotPanel.Invalidate();
            optie = 2;
            xMidden = -1.416953125;
            yMidden = 7.81249999999986E-05;
            schaal = 25600;

            textBoxXCoord.Text = xMidden.ToString();
            textBoxYCoord.Text = yMidden.ToString();
            textBoxScale.Text = schaal.ToString();
            textBoxMaxMandelbrot.Text = maxMandelNummer.ToString();
        }

        // Matrix screenshot button
        private void buttonSSMatrix_Click(object sender, EventArgs e)
        {
            MandelbrotPanel.Invalidate();
            optie = 4;
            xMidden = -1.4475;
            yMidden = 3.90625000000352E-05;
            schaal = 102400;

            textBoxXCoord.Text = xMidden.ToString();
            textBoxYCoord.Text = yMidden.ToString();
            textBoxScale.Text = schaal.ToString();
            textBoxMaxMandelbrot.Text = maxMandelNummer.ToString();
        }

        // Electric colour button
        private void buttonCOEelectric_Click(object sender, EventArgs e)
        {
            MandelbrotPanel.Invalidate();
            optie = 3;
        }

        // Solar colour button
        private void buttonCOSolar_Click(object sender, EventArgs e)
        {
            MandelbrotPanel.Invalidate();
            optie = 5;
        }

        // BW colour button
        private void buttonCOBW_Click(object sender, EventArgs e)
        {
            MandelbrotPanel.Invalidate();
            optie = 1;
        }

        // Crazy colour button
        private void buttonCOCrazy_Click(object sender, EventArgs e)
        {
            MandelbrotPanel.Invalidate();
            optie = 2;
        }

        // Matrix colour button
        private void buttonCOMatrix_Click(object sender, EventArgs e)
        {
            MandelbrotPanel.Invalidate();
            optie = 4;
        }



        // Paint bitmap in the panel
        private void BitmapPaint(object sender, PaintEventArgs pea)
        {
            this.DrawMandelbrot(pea.Graphics, optie);
        }

        // Zoom in by clicking
        private void MandelbrotPanel_MouseClick(object sender, MouseEventArgs e)
        {
            MandelbrotPanel.Invalidate();
            xMidden += (e.X - 200) / schaal;
            yMidden += (200 - e.Y) / schaal;

            // Linkermuisknop inzoomen en rechtermuisknop uitzoomen
            if (e.Button == MouseButtons.Left)
                schaal = schaal * 2;
            else
                schaal = schaal / 2;

            textBoxXCoord.Text = xMidden.ToString();
            textBoxYCoord.Text = yMidden.ToString();
            textBoxScale.Text = schaal.ToString();
            textBoxMaxMandelbrot.Text = maxMandelNummer.ToString();
        }
        
        // Startbutton event
        private void buttonStart_Click(object sender, EventArgs e)
        {
            MandelbrotPanel.Invalidate();
            xMidden = double.Parse(textBoxXCoord.Text);
            yMidden = double.Parse(textBoxYCoord.Text);
            schaal = double.Parse(textBoxScale.Text);
            maxMandelNummer = int.Parse(textBoxMaxMandelbrot.Text);

            // Custom RGB waarde
            if (comboBoxRed.SelectedIndex >= 0 && comboBoxGreen.SelectedIndex >= 0 && comboBoxBlue.SelectedIndex >= 0)
            {
                optie = 6;
                r = comboBoxRed.SelectedIndex;
                g = comboBoxGreen.SelectedIndex;
                b = comboBoxBlue.SelectedIndex;
            }
        }

        // Resetbutton event
        private void buttonReset_Click(object sender, EventArgs e)
        {
            MandelbrotPanel.Invalidate();
            xMidden = 0;
            yMidden = 0;
            optie = 1;
            schaal = 100;
            maxMandelNummer = 100;

            textBoxXCoord.Text = "0.000";
            textBoxYCoord.Text = "0.000";
            textBoxScale.Text = "100";
            textBoxMaxMandelbrot.Text = "100";

            comboBoxRed.SelectedIndex = -1;
            comboBoxGreen.SelectedIndex = -1;
            comboBoxBlue.SelectedIndex = -1;
        }

        // Bitmap tekenen
        void DrawMandelbrot(Graphics gr, int kleuren)
        {
            int x, y, mandelbrot_output;
            double x_in, y_in;

            Bitmap bm = new Bitmap(400, 400);
            {
                // Assenstelsel in de panel tekenen met goede kleur voor mandelgetal
                for (y = 0; y < 400; y++)
                    for (x = 0; x < 400; x++)
                    {
                        x_in = CalcXCoords(x, xMidden);
                        y_in = CalcYCoords(y, yMidden);
                        mandelbrot_output = CalcMandel(x_in, y_in, maxMandelNummer);

                        if (optie == 1)
                        {
                            if (mandelbrot_output % 2 == 0)
                                bm.SetPixel(x, y, Color.Black);
                            else
                                bm.SetPixel(x, y, Color.White);
                        }
                        else if (optie == 2)
                        {
                            if (mandelbrot_output % 2 == 0 && mandelbrot_output % 3 == 0)
                                bm.SetPixel(x, y, Color.FromArgb(0, 234, 255));
                            else if (mandelbrot_output % 2 == 0)
                                bm.SetPixel(x, y, Color.FromArgb(52, 235, 189));
                            else if (mandelbrot_output % 3 == 0)
                                bm.SetPixel(x, y, Color.FromArgb(140, 159, 255));
                            else
                                bm.SetPixel(x, y, Color.FromArgb(113, 50, 191));

                        }
                        else if (optie == 3)
                        {
                            bm.SetPixel(x, y, Color.FromArgb(mandelbrot_output % 25 * 2, mandelbrot_output % 25 * 5, mandelbrot_output % 25 * 10));
                        }
                        else if (optie == 4)
                        {
                            bm.SetPixel(x, y, Color.FromArgb(mandelbrot_output % 25 * 5, mandelbrot_output % 25 * 10, mandelbrot_output % 25 * 2));
                        }
                        else if (optie == 5)
                        {
                            if (mandelbrot_output % 25 == 0)
                                bm.SetPixel(x, y, Color.FromArgb(224, 161, 0));
                            else
                                bm.SetPixel(x, y, Color.FromArgb(mandelbrot_output % 25 * 10, mandelbrot_output % 25 * 5, mandelbrot_output % 25 * 2));

                        }
                        else if (optie == 6)
                        {
                            bm.SetPixel(x, y, Color.FromArgb(mandelbrot_output % 25 * r, mandelbrot_output % 25 * g, mandelbrot_output % 25 * b));
                        }
                    }
            }

            gr.DrawImage(bm, 0, 0);

        }

    }
}
