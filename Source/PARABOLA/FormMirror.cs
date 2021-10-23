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
    public partial class FormMirror : Form
    {
        public FormMirror()
        {
            InitializeComponent();
        }
       double alpha; // угол поворота в радианах
       int alphaSt; // градусная мера угла поворота зеракала
       Graphics g;
       int x0, y0; // точка пересечения
       double x1, y1; // точка правого края прямой
       double x2, y2; // точка левого края прямой
       double x3, y3; // точка верхнего края перпендикуляра
       int x4, y4; // точка из которой падает луч
       double x5, y5; // точка в которую приходит отраженный луч 

        private void Form2_Load(object sender, EventArgs e)
        {          
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.Transparent);
            alpha = trackBar1.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Pen myPen = new Pen(Color.ForestGreen, 1.0F);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            g = pictureBox1.CreateGraphics();
            g.DrawLine(myPen, 110, y0, 510, y0);
            g.DrawArc(Pens.White, (x0-20), (y0-20), 40, 40, 0, alphaSt);
            if (alphaSt == 45)
            {
                g.DrawLine(Pens.White, x0 + 20, y0 - 20, x0, y0 - 40);
                g.DrawLine(Pens.White, x0 - 20, y0 - 20, x0, y0 - 40);
            }
            else
            {
                g.DrawArc(Pens.White, (x0 - 30), (y0 - 30), 60, 60, -135, (45 + alphaSt));
            }
            alphaSt = trackBar1.Value;
            g.DrawLine(Pens.White, x0, y0, (int)x1, (int)y1);
            g.DrawLine(Pens.White, x0, y0, (int)x2, (int)y2);
            g.DrawLine(Pens.White, x0, y0, (int)x3, (int)y3);
            g.DrawLine(Pens.White, x0, y0, (int)x5, (int)y5);
            labelL.Text = (trackBar1.Value).ToString() + "°";
            alpha = (trackBar1.Value * (Math.PI)) / 180;
            //for (int i = 0; i < pictureBox1.Width; i += 10)
            //{
            //    g.DrawLine(Pens.Gainsboro, i, 0, i, pictureBox1.Height);
            //}
            //for (int i = 0; i < pictureBox1.Height; i += 10)
            //{
            //    g.DrawLine(Pens.Gainsboro, 0, i, pictureBox1.Width, i);
            //}
            //x1 = ((x0 + 200) * Math.Cos(alpha))+(y0 * Math.Sin(alpha));
            //y1 = -((x0 + 200) * Math.Sin(alpha))+(y0 * Math.Cos(alpha));
            //x2 = (x0 * Math.Cos(alpha)) + ((y0 - 200) * Math.Sin(alpha));
            //y2 = -((x0) * Math.Sin(alpha)) + ((y0 - 200) * Math.Cos(alpha));
            //x3 = ((x0 - 200) * Math.Cos(alpha)) + (y0 * Math.Sin(alpha));
            //y3 = -((x0 - 200) * Math.Sin(alpha)) + (y0 * Math.Cos(alpha));
            x1 = x0 + 200 * Math.Cos(alpha);
            y1 = y0 + 200 * Math.Sin(alpha);
            x2 = x0 + 200 * Math.Cos(alpha - Math.PI);
            y2 = y0 + 200 * Math.Sin(alpha - Math.PI);
            x3 = x0 + 200 * Math.Cos(alpha - (Math.PI / 2));
            y3 = y0 + 200 * Math.Sin(alpha - (Math.PI / 2));
            x5 = x0 + (200 * 1.4) * Math.Cos(2 * alpha - (Math.PI / 4));
            y5 = y0 + (200 * 1.4) * Math.Sin(2 * alpha - (Math.PI / 4));
            g.DrawLine(Pens.Orange, x0, y0, x4, y4); // падающий луч
            g.DrawLine(Pens.Orange, x0, y0, (int)x5, (int)y5); // отраженный луч
            g.DrawLine(Pens.Black, x0, y0, (int)x1, (int)y1); // поворот правой части зеракала
            g.DrawLine(Pens.Black, x0, y0, (int)x2, (int)y2); // поворот левой части 
            g.DrawLine(Pens.Red, x0, y0, (int)x3, (int)y3); // перпендикуляр
            g.DrawArc(Pens.Black, (x0 - 20), (y0 - 20), 40, 40, 0, alphaSt); // угол поворота зеркала
            if (alphaSt > 0)
            {
                label7.Visible = true;
                label6.Visible = false;
                labelB.Text = (alphaSt + 45).ToString() + "°";
            }
            else
            {
                label7.Visible = false;
                if (alphaSt < 0)
                {
                    label6.Visible = true;
                    labelB.Text = (alphaSt - 45).ToString() + "°";
                }
                else
                {
                    label6.Visible = false;
                    labelB.Text = "45" + "°";
                }
            }
            if (alphaSt == 45)
            {
                g.DrawLine(Pens.Blue, x0+20, y0-20, x0, y0 - 40);
                g.DrawLine(Pens.Blue, x0-20, y0-20, x0, y0 - 40);
            }
            else
            {
                g.DrawArc(Pens.Blue, (x0 - 30), (y0 - 30), 60, 60, -135, (45 + alphaSt));
            }
            g.Dispose();
        }

        private void button1_Click(object sender, EventArgs e) // Рисуем начальное не повернутое зеркало.
        {
            trackBar1.Enabled = true;
            trackBar1.Value = 0;
            label6.Visible = false;
            label7.Visible = false;
            labelL.Text = "0" + "°";
            labelB.Text = "45" + "°";
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            alphaSt = trackBar1.Value;
            //for (int i = 0; i < pictureBox1.Width; i += 10)
            //{
            //    g2.DrawLine(Pens.Gainsboro, i, 0, i, pictureBox1.Height);
            //}
            //for (int i = 0; i < pictureBox1.Height; i += 10)
            //{
            //    g2.DrawLine(Pens.Gainsboro, 0, i, pictureBox1.Width, i);
            //}
            x0 = pictureBox1.Width / 2;
            y0 = pictureBox1.Height - 200;
            x1 = x0+200;
            y1 = y0;
            x2 = x0 - 200;
            y2 = y0;
            x3 = x0;
            y3 = y0 - 200;
            x4 = x0 - 200;
            y4 = y0 - 200;
            x5 = x0 + 200;
            y5 = y0 - 200;
            g.DrawLine(Pens.Black, x0, y0, (int)x1, (int)y1);
            g.DrawLine(Pens.Black, x0, y0, (int)x2, (int)y2);
            g.DrawLine(Pens.Red, x0, y0, (int)x3, (int)y3);
            g.DrawLine(Pens.Orange, x0, y0, (int)x4, (int)y4);
            g.DrawLine(Pens.Orange, x0, y0, (int)x5, (int)y5);
            g.DrawArc(Pens.Blue, (x0 - 30), (y0 - 30), 60, 60, -135, 45);
            labelL.Text = "0" + "°";
            label9.Visible = true;
            g.Dispose();
        }

        private void FormMirror_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            FormMenu frmMenu = new FormMenu();
            frmMenu.Show();
            this.Hide();
        }
    }
}
