using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class FormRealCays : Form
    {
        public FormRealCays()
        {
            InitializeComponent();
        }

        private void FormRealCays_FormClosed(object sender, FormClosedEventArgs e)
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
            double coef = double.Parse(textBox6.Text);

            if (a <= 0)
            {
                MessageBox.Show("Неправильне введення а, введіть а > 0");
            }
            else
            {
                if (coef < 2 || coef > 4)
                {
                    MessageBox.Show("Неправильне введення coef, введіть 2 < coef < 4");
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

                    for (int i = 1; i < parab[0].Length; i++) // цикл выводит параболу на экран
                    {
                        g.DrawLine(Pens.Black, XtoI(parab[0][i - 1]), YtoJ(parab[1][i - 1]), XtoI(parab[0][i]), YtoJ(parab[1][i]));
                    }
                    for (double p = -5; p < 5; p += 0.5)
                    {
                        Ray.borders(ItoX(pictureBox1.Width), JtoY(0), ItoX(0), JtoY(pictureBox1.Height));
                        list1 = Ray.mainReflect(p, JtoY(0), ((coef * Math.PI) / 2), a, b, c);
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

        double yCay(double p, double yp, double k)
        {
            double alpha = Math.Atan(k);
            return yp - Math.Abs(p) * Math.Tan((Math.PI / 2) - (2 * Math.Abs(alpha)));
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
     
        private void label10_Click(object sender, EventArgs e)
        {
            FormMenu frmMenu = new FormMenu();
            frmMenu.Show();
            this.Hide();
        }

        private void FormRealCays_Load_1(object sender, EventArgs e)
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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void TByMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void TByMin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void TBxMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBxMin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
