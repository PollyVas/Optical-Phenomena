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
    public partial class FormParabola : Form
    {
        public FormParabola()
        {
            InitializeComponent();
        }
        double x, y;

        private void button1_Click(object sender, EventArgs e)
        {
            chart2.Series[0].Points.Clear();
            //x = -10;
            //for (int i = 0; x <= 10; i++)
            //{ 
            //y = Math.Pow(x, 2);
            //chart2.Series[0].Points.AddXY(Math.Round(x, 2), Math.Round(y, 2));
            //x++;
            //}
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);
            double c = double.Parse(textBox3.Text);
            int xMin = int.Parse(textBox4.Text);
            int xMax = int.Parse(textBox5.Text);
            double P = int.Parse(textBox6.Text);

            chart2.ChartAreas[0].AxisX.Maximum = xMax;
            chart2.ChartAreas[0].AxisX.Minimum = xMin;
            chart2.ChartAreas[0].AxisY.Maximum = xMax;
            chart2.ChartAreas[0].AxisY.Minimum = xMin;

            basicLine bL = new basicLine(a,b,c);
            double[][] parab = bL.Parabl(xMin, xMax);

            basicLine cosL = bL.cos(P);
            double[][] cos = cosL.Parabl(xMin, xMax);

            basicLine perpend = bL.perpendic(cosL.getB(), P, cosL.yFromX(P));
            double[][] perpen = perpend.Parabl(xMin, xMax);
            int o = 0;

            basicLine pre = bL.prelom(perpend.getB(), P, perpend.yFromX(P));

            double[][] prel = pre.Parabl(xMin, xMax);

            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();
            chart2.Series[3].Points.Clear();
            chart2.Series[4].Points.Clear();
            for (int i = 0; i < parab[0].Length; i++)
            {
                chart2.Series[0].Points.AddXY(parab[0][i], parab[1][i]);
                chart2.Series[1].Points.AddXY(cos[0][i], cos[1][i]);
                chart2.Series[2].Points.AddXY(prel[0][i], prel[1][i]);
                chart2.Series[4].Points.AddXY(perpen[0][i], perpen[1][i]);
                if (parab[0][i] > P && o == 0)
                {
                    vertical(parab[0][i], parab[1][i], (parab[1].Length - 1));                   
                    o++;
                }
            }
        }
            void vertical(double x, double y, int len)
            {
            for (double j = y; j <= len; j++)
                    {
                        chart2.Series[3].Points.AddXY(x, j);
                    }
            }
            private void FormParabola_FormClosed(object sender, FormClosedEventArgs e)
            {
                Application.Exit();
            }
          }
        }

