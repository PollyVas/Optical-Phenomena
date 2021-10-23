using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parabola
{
    public partial class FormCaysticaCaystica : Form
    {
        public FormCaysticaCaystica()
        {
            InitializeComponent();
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
            double yDge = double.Parse(textBox6.Text);
            double xDge = double.Parse(textBox4.Text);

            if (a <= 0)
            {
                MessageBox.Show("Неправильне введення  а, введіть а > 0");
            }
            else
            {
                int xMin = int.Parse(TBxMin.Text);
                int xMax = int.Parse(TBxMax.Text);
                x1 = xMin;
                x2 = xMax;
                y1 = int.Parse(TByMax.Text);
                y2 = int.Parse(TByMin.Text);


                SK();
                List<Point> list1;
                Point pt1, pt2;
                basicLine bL = new basicLine(a, b, c);
                double[][] parab = bL.Parabl(xMin, xMax); // массив точек параболы
                if (yDge < bL.yFromX(xDge))
                {
                    MessageBox.Show("Неправильне введення координат джерела");
                }
                else
                {
                    for (int i = 1; i < parab[0].Length; i++) // цикл выводит параболу на экран
                    {
                        g.DrawLine(Pens.Black, XtoI(parab[0][i - 1]), YtoJ(parab[1][i - 1]), XtoI(parab[0][i]), YtoJ(parab[1][i]));
                    }
                    for (double coef = 0; coef < 4; coef += 0.05)
                    {
                        Ray.borders(ItoX(pictureBox1.Width), JtoY(0), ItoX(0), JtoY(pictureBox1.Height));
                        list1 = Ray.mainReflect(xDge, yDge, ((coef * Math.PI) / 2), a, b, c);
                        for (int i = 0; i < list1.Count - 1; i++)
                        {
                            pt1 = list1[i];
                            pt2 = list1[i + 1];
                            g.DrawLine(Pens.Green, XtoI(pt1.x), YtoJ(pt1.y), XtoI(pt2.x), YtoJ(pt2.y));
                        }
                    }
                    g.Dispose();
                }
            }
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
        double ItoX(double i)
        {
            return x1 + (((i - i1) * (x2 - x1)) / (i2 - i1));
        }
        double JtoY(double j)
        {
            return y1 + (((j - j1) * (y2 - y1)) / (j2 - j1));
        }

        private void FormCaysticaCaystica_Load(object sender, EventArgs e)
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

        private void FormCaysticaCaystica_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
     
    }
}
