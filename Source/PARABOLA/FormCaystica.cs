using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Parabola
{
    public partial class FormCaystica : Form
    {
        public FormCaystica()
        {
            InitializeComponent();
        }

        private void FormCaystica_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        int i1, i2, j1, j2, x1, x2, y1, y2;
        Graphics g;
        private void button1_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);
            double c = double.Parse(textBox3.Text);
            int xMin = -10;
            int xMax = 10;
            double p = int.Parse(textBox6.Text);
                SK();

                basicLine bL = new basicLine(a, b, c);
                double[][] parab = bL.Parabl(xMin, xMax); // массив точек параболы

                for (int i = 1; i < parab[0].Length; i++) // цикл выводит параболу на экран
                {
                    g.DrawLine(Pens.Black, XtoI(parab[0][i - 1]), YtoJ(parab[1][i - 1]), XtoI(parab[0][i]), YtoJ(parab[1][i]));
                }

                if (p == 0)
                {
                    g.DrawLine(Pens.Blue, XtoI(0), YtoJ(0), XtoI(0), 0);
                }
                else
                {
                    basicLine cosL = bL.cos(p);
                    double[][] cos = cosL.Parabl(xMin, xMax); // массив точек касательной

                    basicLine perpend = bL.perpendic(cosL.getB(), p, cosL.yFromX(p));
                    double[][] perpen = perpend.Parabl(xMin, xMax); // массив точек перпендикуляра к касательной

                    basicLine pre = bL.prelom(perpend.getB(), p, perpend.yFromX(p));
                    double[][] prel = pre.Parabl(xMin, xMax); // массив точек преломленного луча 


                    g.DrawLine(Pens.Red, XtoI(cos[0][0]), YtoJ(cos[1][0]), XtoI(cos[0][cos[0].Length - 1]), YtoJ(cos[1][cos[1].Length - 1]));
                    g.DrawLine(Pens.Red, XtoI(perpen[0][0]), YtoJ(perpen[1][0]), XtoI(perpen[0][perpen[0].Length - 1]), YtoJ(perpen[1][perpen[1].Length - 1]));
                    g.DrawLine(Pens.Blue, XtoI(p), YtoJ(cosL.yFromX(p)), XtoI(p), 0);
                    g.DrawLine(Pens.Blue, XtoI(p), YtoJ(cosL.yFromX(p)), XtoI(0), YtoJ(yCay(p, bL.yFromX(p), perpend.getB()))); // Строит отраженный луч
                    g.Dispose();
                }
            
        }
        double yCay(double p, double yp, double k)
        {
            double alpha = Math.Atan(k);
            return yp - Math.Abs(p)*Math.Tan((Math.PI/2)-(2*Math.Abs(alpha)));
        }
        void SK()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.DrawLine(Pens.Black, XtoI(x1), YtoJ(0), XtoI(x2), YtoJ(0));
            g.DrawLine(Pens.Black, XtoI(0), YtoJ(y1), XtoI(0), YtoJ(y2));
            for (int i = (int)x1; i < x2; i++)
            {
                g.DrawLine(Pens.Black, XtoI(i), YtoJ(-0.1), XtoI(i), YtoJ(0.1));
                if (i != 0)
                    g.DrawString(i.ToString(), this.Font, Brushes.Black, XtoI(i) - 8, YtoJ(0) + 10);
            }
            for (int j = (int)y2; j < y1; j++)
            {
                g.DrawLine(Pens.Black, XtoI(-0.1), YtoJ(j), XtoI(0.1), YtoJ(j));
                if (j != 0)
                    g.DrawString(j.ToString(), this.Font, Brushes.Black, XtoI(0) - 25, YtoJ(j) - 7);
            }
            g.DrawString("x", this.Font, Brushes.Black, XtoI(x2) - 12, YtoJ(0) - 15);
            g.DrawString("y", this.Font, Brushes.Black, XtoI(0) + 5, YtoJ(y1) + 5);
        }
        int XtoI(double x)
        {
            return i1 + (int)(((x - x1) * (i2 - i1)) / (x2 - x1));
        }
        int YtoJ(double y)
        {
            return j1 + (int)(((y - y1) * (j2 - j1)) / (y2 - y1));
        }

        private void FormCaystica_Load(object sender, EventArgs e)
        {
            i1 = 0;
            i2 = pictureBox1.Width;
            j1 = 0;
            j2 = pictureBox1.Height;
            x1 = -10;
            x2 = 10;
            y1 = 15;
            y2 = -5;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FormMenu frmMenu = new FormMenu();
            frmMenu.Show();
            this.Hide();

        }
    }
}
