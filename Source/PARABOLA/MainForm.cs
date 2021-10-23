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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        int i1, i2, j1, j2, x1, x2, y1, y2;
        Graphics g;
        int deer;

        List<Point> listFoc1;
        basicLine foc1;
        Point ptFo11;
        Point ptFo12;
        Point tecPos1;
        Point prePos1;
        int counter1;
        Bitmap myBitmap;
        int aniTick;
        int aniTick2;
        int foto;

        private void timer1_Tick(object sender, EventArgs e)
        {
            deer++;
            if (deer == 30)
            {
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "/Images/Cute_deer.gif");
            }
            if (deer == 50)
            {
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "/Images/Cute_deer.png");
                deer = 0;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            deer = 0;
            timer1.Start();
            panel1.Left = -200;
            panel1.Top = 28;
            panelStart.Top = 0;
            panelStart.Left = 0;
            webBrowser1.Left = 20;
            webBrowser1.Top = 90;
            pictureBox1.Left = 20;
            pictureBox1.Top = 43;
            pictureBox17.Left = 20;
            pictureBox17.Top = 43;
            panelPara.Left = 730;
            panelPara.Top = 43;
            panelDge.Left = 730;
            panelDge.Top = 43;
            panelChose.Left = 20;
            panelChose.Top = 90;
            panelAni.Left = 730;
            panelAni.Top = 20;
            pictureBoxGal.Top = 87;
            pictureBoxGal.Left = 222;
            foto = 1;
            toolStripStatusLabel1.Text = "Оберіть потрібний пункт меню";

            i1 = 0;
            i2 = pictureBox1.Width;
            j1 = 0;
            j2 = pictureBox1.Height;
            

             x1 = -10;
             x2 = 10;
             y1 = 19;
             y2 = -1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Start();
           // timer5.Start();
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Left += 5;
            if(panel1.Left == 0)
            {
                timer2.Stop();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            panel1.Left -= 5;
            if (panel1.Left == -200)
            {
                timer3.Stop();
                pictureBox3.Visible = true;
                pictureBox3.Image = Image.FromFile("Images/Cute_deer.png");
                pictureBox4.Visible = false;
                timer1.Start();
            }
        }
      

        //private void pictureBoxMod_MouseEnter(object sender, EventArgs e)
        //{
        //    pictureBoxMod.BackColor = Color.FromArgb(200, 65, 131);
        //    labelMod.ForeColor = Color.FromArgb(252, 245, 252);
        //    labelMod.BackColor = Color.FromArgb(200, 65, 131);
        //}

        //private void pictureBoxMod_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBoxMod.BackColor = Color.FromArgb(236, 227, 230);
        //    labelMod.ForeColor = Color.FromArgb(80, 0, 17);
        //    labelMod.BackColor = Color.FromArgb(236, 227, 230);
        //}

        //private void labelMod_MouseEnter(object sender, EventArgs e)
        //{
        //    pictureBoxMod.BackColor = Color.FromArgb(200, 65, 131);
        //    labelMod.ForeColor = Color.FromArgb(252, 245, 252);
        //    labelMod.BackColor = Color.FromArgb(200, 65, 131);
        //}

        //private void pictureBoxDov_MouseEnter(object sender, EventArgs e)
        //{
        //    pictureBoxDov.BackColor = Color.FromArgb(200, 65, 131);
        //    labelDov.ForeColor = Color.FromArgb(252, 245, 252);
        //    labelDov.BackColor = Color.FromArgb(200, 65, 131);
        //}

        //private void pictureBoxDov_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBoxDov.BackColor = Color.FromArgb(236, 227, 230);
        //    labelDov.ForeColor = Color.FromArgb(80, 0, 17);
        //    labelDov.BackColor = Color.FromArgb(236, 227, 230);
        //}

        //private void labelDov_MouseEnter(object sender, EventArgs e)
        //{
        //    pictureBoxDov.BackColor = Color.FromArgb(200, 65, 131);
        //    labelDov.ForeColor = Color.FromArgb(252, 245, 252);
        //    labelDov.BackColor = Color.FromArgb(200, 65, 131);
        //}

        //private void labelMod_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBoxMod.BackColor = Color.FromArgb(236, 227, 230);
        //    labelMod.ForeColor = Color.FromArgb(80, 0, 17);
        //    labelMod.BackColor = Color.FromArgb(236, 227, 230);
        //}

        //private void labelDov_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBoxDov.BackColor = Color.FromArgb(236, 227, 230);
        //    labelDov.ForeColor = Color.FromArgb(80, 0, 17);
        //    labelDov.BackColor = Color.FromArgb(236, 227, 230);
        //}

        private void pictureBoxAni_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxAni.BackColor = Color.FromArgb(170, 179, 119);
            labelAni.BackColor = Color.FromArgb(170, 179, 119);
            labelAni.ForeColor = Color.FromArgb(250, 250, 250);
             toolStripStatusLabel1.Text = "Розділ з анімації";
        }

        private void labelAni_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxAni.BackColor = Color.FromArgb(170, 179, 119);
            labelAni.BackColor = Color.FromArgb(170, 179, 119);
            labelAni.ForeColor = Color.FromArgb(250, 250, 250);
             toolStripStatusLabel1.Text = "Розділ з анімації";
        }

        private void pictureBoxAni_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAni.BackColor = Color.FromArgb(213, 219, 188);
            labelAni.BackColor = Color.FromArgb(213, 219, 188);
            labelAni.ForeColor = Color.FromArgb(85, 88, 16);
             toolStripStatusLabel1.Text = "";
        }

        private void labelAni_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAni.BackColor = Color.FromArgb(213, 219, 188);
            labelAni.BackColor = Color.FromArgb(213, 219, 188);
            labelAni.ForeColor = Color.FromArgb(85, 88, 16);
             toolStripStatusLabel1.Text = "";
        }

        private void pictureBoxPob_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxPob.BackColor = Color.FromArgb(170, 179, 119);
            labelPob.BackColor = Color.FromArgb(170, 179, 119);
            labelPob.ForeColor = Color.FromArgb(250, 250, 250);
             toolStripStatusLabel1.Text = "Розділ з побудови оптичних явищ";
        }

        private void labelPob_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxPob.BackColor = Color.FromArgb(170, 179, 119);
            labelPob.BackColor = Color.FromArgb(170, 179, 119);
            labelPob.ForeColor = Color.FromArgb(250, 250, 250);
             toolStripStatusLabel1.Text = "Розділ з побудови оптичних явищ";
        }

        private void pictureBoxPob_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxPob.BackColor = Color.FromArgb(213, 219, 188);
            labelPob.BackColor = Color.FromArgb(213, 219, 188);
            labelPob.ForeColor = Color.FromArgb(85, 88, 16);
             toolStripStatusLabel1.Text = "";
        }

        private void labelPob_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxPob.BackColor = Color.FromArgb(213, 219, 188);
            labelPob.BackColor = Color.FromArgb(213, 219, 188);
            labelPob.ForeColor = Color.FromArgb(85, 88, 16);
             toolStripStatusLabel1.Text = "";
        }

        private void pictureBoxUse_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxUse.BackColor = Color.FromArgb(170, 179, 119);
            labelUse.BackColor = Color.FromArgb(170, 179, 119);
            labelUse.ForeColor = Color.FromArgb(250, 250, 250);
             toolStripStatusLabel1.Text = "Розділ з поясненням для користувача розділу побудови";
        }

        private void labelUse_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxUse.BackColor = Color.FromArgb(170, 179, 119);
            labelUse.BackColor = Color.FromArgb(170, 179, 119);
            labelUse.ForeColor = Color.FromArgb(250, 250, 250);
             toolStripStatusLabel1.Text = "Розділ з поясненням для користувача розділу побудови";
        }

        private void labelUse_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxUse.BackColor = Color.FromArgb(213, 219, 188);
            labelUse.BackColor = Color.FromArgb(213, 219, 188);
            labelUse.ForeColor = Color.FromArgb(85, 88, 16);
             toolStripStatusLabel1.Text = "";
        }

        private void pictureBoxUse_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxUse.BackColor = Color.FromArgb(213, 219, 188);
            labelUse.BackColor = Color.FromArgb(213, 219, 188);
            labelUse.ForeColor = Color.FromArgb(85, 88, 16);
             toolStripStatusLabel1.Text = "";
        }
        private void pictureBoxTeory_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxTeory.BackColor = Color.FromArgb(170, 179, 119);
            labelTeory.BackColor = Color.FromArgb(170, 179, 119);
            labelTeory.ForeColor = Color.FromArgb(250, 250, 250);
             toolStripStatusLabel1.Text = "Розділ з теоритичною частиною роботи";
        }

        private void labelTeory_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxTeory.BackColor = Color.FromArgb(170, 179, 119);
            labelTeory.BackColor = Color.FromArgb(170, 179, 119);
            labelTeory.ForeColor = Color.FromArgb(250, 250, 250);
             toolStripStatusLabel1.Text = "Розділ з теоритичною частиною роботи";
        }

        private void pictureBoxTeory_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxTeory.BackColor = Color.FromArgb(213, 219, 188);
            labelTeory.BackColor = Color.FromArgb(213, 219, 188);
            labelTeory.ForeColor = Color.FromArgb(85, 88, 16);
             toolStripStatusLabel1.Text = "";
        }

        private void labelTeory_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxTeory.BackColor = Color.FromArgb(213, 219, 188);
            labelTeory.BackColor = Color.FromArgb(213, 219, 188);
            labelTeory.ForeColor = Color.FromArgb(85, 88, 16);
             toolStripStatusLabel1.Text = "";
        }

        private void labelTeory_Click(object sender, EventArgs e)
        {
            panelStart.Visible = false;
            labelSign.Visible = false;
            label35.Visible = false;
            pictureBoxVpe.Visible = false;
            pictureBoxNaz.Visible = false;
            pictureBoxGal.Visible = false;
            panelChose.Visible = false;
            pictureBoxSign.Visible = false;
            pictureBox17.Visible = false;
            pictureBox1.Visible = false;
            panelDge.Visible = false;
            panelPara.Visible = false;
            panelAni.Visible = false;
            webBrowser1.Visible = true;
            webBrowser1.Navigate(Application.StartupPath + "/Teory/Teory.htm");
            labelHead.Visible = true;
            labelHead.Text = "Теоретичні основи";
            timer3.Start();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
            trackBar1.Enabled = true;
           // g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox3.Text);
            double c = double.Parse(textBox2.Text);
            double coef = double.Parse(textBox6.Text);
            

            if (a <= 0 || a>10)
            {
                MessageBox.Show("Неправильне введення а, введіть  10 > а >= 0");
            }
            else
            {
                if (coef <= 180 || coef >= 360)
                {
                    MessageBox.Show("Неправильне введення кута, введіть 180° < α < 360°");
                }
                else
                {
                    if (-10 > b || b > 10)
                    {
                        MessageBox.Show("Невірне значення В");
                    }
                    else
                    {
                        if (-10 > c || c > 10)
                        {
                            MessageBox.Show("Невірне значення C");
                        }
                        else
                        {
                            coef = ((coef * Math.PI) / 180) / (Math.PI / 2);
                            int xMin = int.Parse(TBxMin.Text);
                            int xMax = int.Parse(TBxMax.Text);
                            x1 = xMin;
                            x2 = xMax;
                            y1 = int.Parse(TByMax.Text);
                            y2 = int.Parse(TByMin.Text);
                            if (Math.Abs(x1) + Math.Abs(x2) != Math.Abs(y1) + Math.Abs(y2))
                            {
                                MessageBox.Show("Неправильне введення параметрів відображення");
                            }
                            else
                                {

                                if (x1 <= -60)
                                {
                                    MessageBox.Show("Занадто маленьке значення xMin");
                                }
                                else
                                {
                                    if (60 <= x2)
                                    {
                                        MessageBox.Show("Занадто велике значення xMax");
                                    }
                                    else
                                    {
                                        if (120 <= y1)
                                        {
                                            MessageBox.Show("Занадто велике значення yMax");
                                        }
                                        else
                                        {
                                            if (y2 <= -60)
                                            {
                                                MessageBox.Show("Занадто велике значення yMin");
                                            }
                                            else
                                            {

                                                if (x1 >= x2 || y1 <= y2)
                                                {
                                                    MessageBox.Show("Неправильне введення параметрів відображення");
                                                }
                                                else
                                                {

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
                                                    pictureBox1.Image = myBitmap;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        void SK()
        {
        //    Graphics g = pictureBox1.CreateGraphics();
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);

            g.Clear(Color.White);
            g.DrawLine(Pens.Black, XtoI(x1), YtoJ(0), XtoI(x2), YtoJ(0));
            g.DrawLine(Pens.Black, XtoI(0), YtoJ(y1), XtoI(0), YtoJ(y2));
            for (int i = (int)x1; i < x2; i++)
            {
                g.DrawLine(Pens.Black, XtoI(i), YtoJ(-0.1), XtoI(i), YtoJ(0.1));
                if (i != 0 && (Math.Abs(x1) + Math.Abs(x2) <= 20))
                {
                    g.DrawString(i.ToString(), this.Font, Brushes.Black, XtoI(i) - 8, YtoJ(0) + 10);
                }
                else
                {
                    if (i % 5 == 0)
                    {
                        g.DrawString(i.ToString(), this.Font, Brushes.Black, XtoI(i) - 8, YtoJ(0) + 10);
                    }
                }
            }
            for (int j = (int)y2; j < y1; j++)
            {
                g.DrawLine(Pens.Black, XtoI(-0.1), YtoJ(j), XtoI(0.1), YtoJ(j));
                if (j != 0 && (Math.Abs(y1) + Math.Abs(y2) <= 20))
                {
                    g.DrawString(j.ToString(), this.Font, Brushes.Black, XtoI(0) - 25, YtoJ(j) - 7);
                }
                else
                { 
                if( j % 5 == 0)
                { 
                    g.DrawString(j.ToString(), this.Font, Brushes.Black, XtoI(0) - 25, YtoJ(j) - 7); 
                }
                }
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

        private void labelPob_Click(object sender, EventArgs e)
        {
            panelChose.Visible = true;
            labelSign.Visible = false;
            pictureBoxVpe.Visible = false;
            label35.Visible = false;
            pictureBoxNaz.Visible = false;
            panelStart.Visible = false;
            pictureBoxGal.Visible = false;
            webBrowser1.Visible = false;
            pictureBox17.Visible = false;
            labelHead.Visible = false;
            panelAni.Visible = false;
            pictureBox1.Visible = false;
            panelPara.Visible = false;
            panelDge.Visible = false;
            timer3.Start();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panelPara.Visible = true;
            panelChose.Visible = false;
            pictureBox1.Visible = true;
            pictureBoxSign.Visible = true;
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
            g.Clear(Color.White);
            g.Dispose();
            pictureBox1.Image = myBitmap;
        }

        private void label18_Click(object sender, EventArgs e)
        {
            panelPara.Visible = true;
            panelChose.Visible = false;
            pictureBox1.Visible = true;
            pictureBoxSign.Visible = true;
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
            g.Clear(Color.White);
            g.Dispose();
            pictureBox1.Image = myBitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
            trackBar2.Enabled = true;
        //  g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            double a = double.Parse(textBoxA.Text);
            double b = double.Parse(textBoxB.Text);
            double c = double.Parse(textBoxC.Text);
            double yDge = double.Parse(textBoxYDge.Text);
            double xDge = double.Parse(textBoxXDge.Text);
            
            if (a <= 0 || a>10)
            {
                MessageBox.Show("Неправильне введення  а, введіть а > 0");
            }
            else
            {
                int xMin = int.Parse(textBoxXMin.Text);
                int xMax = int.Parse(textBoxXMax.Text);
                x1 = xMin;
                x2 = xMax;
                y1 = int.Parse(textBoxYMax.Text);
                y2 = int.Parse(textBoxYMin.Text);
                if (Math.Abs(x1) + Math.Abs(x2) != Math.Abs(y1) + Math.Abs(y2))
                {
                    MessageBox.Show("Неправильне введення параметрів відображення");
                }
                else
                {
                SK();
                List<Point> list1;
                Point pt1, pt2;
                basicLine bL = new basicLine(a, b, c);
                double[][] parab = bL.Parabl(xMin, xMax); // массив точек параболы
                for (int i = 1; i < parab[0].Length; i++) // цикл выводит параболу на экран
                {
                    g.DrawLine(Pens.Black, XtoI(parab[0][i - 1]), YtoJ(parab[1][i - 1]), XtoI(parab[0][i]), YtoJ(parab[1][i]));
                }

                if (yDge < bL.yFromX(xDge))
                {
                    MessageBox.Show("Неправильне введення координат джерела");
                }
                else
                {
                        if (x1 >= x2 || y1 <= y2)
                        {
                            MessageBox.Show("Неправильне введення параметрів відображення");
                        }
                        else
                        {
                            if ( -10 >= b || b >= 10 )
                            {
                                MessageBox.Show("Невірне значення В");
                            }
                            else
                            {
                                if (-10 >= c || c >= 10)
                                {
                                    MessageBox.Show("Невірне значення С");
                                }
                                else
                                {
                                    if (x1 <= -60)
                                    {
                                        MessageBox.Show("Занадто маленьке значення xMin");
                                    }
                                    else
                                    {
                                        if (60 <= x2)
                                        {
                                            MessageBox.Show("Занадто велике значення xMax");
                                        }
                                        else
                                        {
                                            if (120 <= y1)
                                            {
                                                MessageBox.Show("Занадто велике значення yMax");
                                            }
                                            else
                                            {
                                                if (y2 <= -60)
                                                {
                                                    MessageBox.Show("Занадто маленьке значення yMin");
                                                }
                                                else
                                                {
                                                    if (yDge >= y1 || yDge > y1 || yDge < y2)
                                                    {
                                                        MessageBox.Show("Неправильне введення у джерела");
                                                    }
                                                    else
                                                    {
                                                        if (xDge > x2 || xDge < x1)
                                                        {
                                                            MessageBox.Show("Неправильне введення x джерела");
                                                        }
                                                        else
                                                        {
                                                            //   DrawOnGraphics(xDge, yDge, a, b, c, 0.1F);
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
                                                            pictureBox1.Image = myBitmap;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        void DrawOnGraphics(double xDge, double yDge, double a, double b, double c, double part = 0.01)
        {
            if (part > 0.95)
            {
                part = 1;
            }

            var newBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var graphics = Graphics.FromImage(newBitmap);

            //  g = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);
            
            for (double coef = 0; coef < 4; coef += 0.05)
            {
                Ray.borders(ItoX(pictureBox1.Width), JtoY(0), ItoX(0), JtoY(pictureBox1.Height));
                var list1 = Ray.mainReflect(xDge, yDge, ((coef * Math.PI) / 2), a, b, c);
                
                float oneStepDrawingPart = 0.4F;
                for (int i = 0; (i < list1.Count - 1) && (part > i * oneStepDrawingPart); i++)
                {
                    float partBase = i * oneStepDrawingPart;
                    if (partBase > 1F)
                    {
                        partBase = 1F;
                    }
                    double partActual = (part - partBase) / oneStepDrawingPart;
                    if (partActual > 1F)
                    {
                        partActual = 1F;
                    }

                    Point pt1 = list1[i];
                    Point pt2 = list1[i + 1];

                    int i1 = XtoI(pt1.x);
                    int j1 = YtoJ(pt1.y);
                    int i2 = XtoI(pt2.x);
                    int j2 = YtoJ(pt2.y);

                    int i3Actual = (int)((double)i1 + ((double)(i2 - i1) * partActual));
                    int j3Actual = (int)((double)j1 + ((double)(j2 - j1) * partActual));

                    graphics.DrawLine(Pens.Green, i1, j1, i3Actual, j3Actual);
                }
            }
            
            pictureBox1.Image = newBitmap;
            graphics.Dispose();

            if (part < 0.95) { 
                System.Threading.Timer timer = null;
                timer = new System.Threading.Timer((obj) =>
                {
                    DrawOnGraphics(xDge, yDge, a, b, c, part + 0.01);
                    timer.Dispose();
                }, null, 50, System.Threading.Timeout.Infinite);
            }
            else
            {
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panelDge.Visible = true;
            panelChose.Visible = false;
            pictureBox1.Visible = true;
            pictureBoxSign.Visible = true;
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
            g.Clear(Color.White);
            g.Dispose();
            pictureBox1.Image = myBitmap;
        }

        private void label19_Click(object sender, EventArgs e)
        {
            panelDge.Visible = true;
            panelChose.Visible = false;
            pictureBox1.Visible = true;
            pictureBoxSign.Visible = true;
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
            g.Clear(Color.White);
            g.Dispose();
            pictureBox1.Image = myBitmap;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            panelDge.Visible = false;
            panelPara.Visible = false;
            pictureBox1.Visible = false;
            pictureBoxSign.Visible = false;
            panelChose.Visible = true;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox17.Visible = false;
            pictureBox1.Visible = true;
            aniTick = 0; 
            timerAniFo1.Start();
            
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
            g.Clear(Color.White);
            double a = 0.1;
            double b = 0;
            double c = 0;
            double coef = 3;

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
                    int xMin = -10;
                    int xMax = 10;
                    x1 = xMin;
                    x2 = xMax;
                    y1 = 19;
                    y2 = -1;

                  
                    List<Point> list1;
                    Point pt1, pt2;
                    basicLine bL = new basicLine(a, b, c);
                    double[][] parab = bL.Parabl(xMin, xMax); // массив точек параболы
                    

                    for (int i = 1; i < parab[0].Length; i++) // цикл выводит параболу на экран
                    {
                        g.DrawLine(Pens.Black, XtoI(parab[0][i - 1]), YtoJ(parab[1][i - 1]), XtoI(parab[0][i]), YtoJ(parab[1][i]));
                    }
                    SK();
                    DrawOnGraphicsPar(coef, parab, a, b, c, 0.01F);
                    //for (double p = -5; p < 5; p += 0.5)
                    //{
                    //    Ray.borders(ItoX(pictureBox1.Width), JtoY(0), ItoX(0), JtoY(pictureBox1.Height));
                    //    list1 = Ray.mainReflect(p, JtoY(0), ((coef * Math.PI) / 2), a, b, c);
                       
                        //for (int i = 0; i < list1.Count - 1; i++)
                        //{
                        //    pt1 = list1[i];
                        //    pt2 = list1[i + 1];
                        //    g.DrawLine(Pens.Green, XtoI(pt1.x), YtoJ(pt1.y), XtoI(pt2.x), YtoJ(pt2.y));
                        //}



                        //if (p == 1)
                        //{
                        //    listFoc1 = list1;
                        //}
                    //}
                    
                    g.Dispose();
                    pictureBox1.Image = myBitmap;
                }
            }
        }
        
        void DrawOnGraphicsPar(double coef, double[][] parab, double a, double b, double c, double part = 0.01)
        {
            if (part > 0.95)
            {
                part = 1;
            }

            Bitmap newBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(newBitmap);

           //  g = pictureBox1.CreateGraphics();
           // graphics.Clear(Color.White);

            for (double p = -5; p < 5; p += 0.5)
            {
                Ray.borders(ItoX(pictureBox1.Width), JtoY(0), ItoX(0), JtoY(pictureBox1.Height));
                List<Point> list1 = Ray.mainReflect(p, JtoY(0), ((coef * Math.PI) / 2), a, b, c);

                float oneStepDrawingPart = 0.2F;
                for (int i = 0; (i < list1.Count - 1) && (part > i * oneStepDrawingPart); i++)
                {
                    float partBase = i * oneStepDrawingPart;
                    if (partBase > 1F)
                    {
                        partBase = 1F;
                    }
                    double partActual = (part - partBase) / oneStepDrawingPart;
                    if (partActual > 1F)
                    {
                        partActual = 1F;
                    }

                    Point pt1 = list1[i];
                    Point pt2 = list1[i + 1];

                    int i1 = XtoI(pt1.x);
                    int j1 = YtoJ(pt1.y);
                    int i2 = XtoI(pt2.x);
                    int j2 = YtoJ(pt2.y);

                    int i3Actual = (int)((double)i1 + ((double)(i2 - i1) * partActual));
                    int j3Actual = (int)((double)j1 + ((double)(j2 - j1) * partActual));

                    graphics.DrawLine(Pens.Green, i1, j1, i3Actual, j3Actual);



                    graphics.DrawLine(Pens.Black, XtoI(x1), YtoJ(0), XtoI(x2), YtoJ(0));
                    graphics.DrawLine(Pens.Black, XtoI(0), YtoJ(y1), XtoI(0), YtoJ(y2));

                    for (int m = (int)x1; m < x2; m++)
                    {
                        graphics.DrawLine(Pens.Black, XtoI(m), YtoJ(-0.1), XtoI(m), YtoJ(0.1));
                        graphics.DrawString(m.ToString(), this.Font, Brushes.Black, XtoI(m) - 8, YtoJ(0) + 10);
                    }
                    for (int j = (int)y2; j < y1; j++)
                    {
                        graphics.DrawLine(Pens.Black, XtoI(-0.1), YtoJ(j), XtoI(0.1), YtoJ(j));
                        graphics.DrawString(j.ToString(), this.Font, Brushes.Black, XtoI(0) - 25, YtoJ(j) - 7);
                    }
                    graphics.DrawString("x", this.Font, Brushes.Black, XtoI(x2) - 12, YtoJ(0) - 15);
                    graphics.DrawString("y", this.Font, Brushes.Black, XtoI(0) + 5, YtoJ(y1) + 5);


                    for (int h = 1; h < parab[0].Length; h++) // цикл выводит параболу на экран
                    {
                        graphics.DrawLine(Pens.Black, XtoI(parab[0][h - 1]), YtoJ(parab[1][h - 1]), XtoI(parab[0][h]), YtoJ(parab[1][h]));
                    }
                    
                }
            }
            pictureBox1.Image = newBitmap;
            graphics.Dispose();

            if (part < 0.95)
            {
                System.Threading.Timer timer = null;

                timer = new System.Threading.Timer((obj) =>
                {
                    DrawOnGraphicsPar(coef, parab, a, b, c, part + 0.01);
                    timer.Dispose();
                }, null, 1, System.Threading.Timeout.Infinite);
            }
            else
            {

            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(pictureBox17.Width, pictureBox17.Height);
            g = Graphics.FromImage(myBitmap);
            g.Clear(Color.White);
            button4.Enabled = false;
            pictureBox3.Enabled = false;
            button3.Enabled = false;
            aniTick2 = 0;
            timerAniFo2.Start();
            
            pictureBox1.Visible = false;
            pictureBox17.Visible = true;

            //  g = pictureBox1.CreateGraphics();
            
            double a = 0.1;
            double b = 0;
            double c = 0;
            double yDge = 6;
            double xDge = 0;

            if (a <= 0)
            {
                MessageBox.Show("Неправильне введення  а, введіть а > 0");
            }
            else
            {
                int xMin = int.Parse(textBoxXMin.Text);
                int xMax = int.Parse(textBoxXMax.Text);
                x1 = -10;
                x2 = 10;
                y1 = 19;
                y2 = -1;


                SK();
                List<Point> list1;
                Point pt1, pt2;
                basicLine bL = new basicLine(a, b, c);
                double[][] parab = bL.Parabl(-10, 10); // массив точек параболы
                for (int i = 1; i < parab[0].Length; i++) // цикл выводит параболу на экран
                {
                    g.DrawLine(Pens.Black, XtoI(parab[0][i - 1]), YtoJ(parab[1][i - 1]), XtoI(parab[0][i]), YtoJ(parab[1][i]));
                }

                if (yDge < bL.yFromX(xDge))
                {
                    MessageBox.Show("Неправильне введення координат джерела");
                }
                else
                {
                      DrawOnGraphicsNorm(parab, a, b, c, 0.0001F);

                    //for (double p = -10; p < 10; p += 0.3)
                    //{
                    //    Func dot = Ray.cos(a, b, c, p);
                    //    Func perp = Ray.perpendic(dot.k, p, bL.yFromX(p));
                    //    double alpha = Math.Atan(perp.k);
                    //    Ray.borders(ItoX(pictureBox17.Width), JtoY(0), ItoX(0), JtoY(pictureBox17.Height));

                    //    if (alpha < 0)
                    //    {
                    //        alpha += Math.PI;
                    //    }
                    //    list1 = Ray.mainReflect(p, bL.yFromX(p), alpha, a, b, c);

                    //    for (int i = 0; i < list1.Count - 1; i++)
                    //    {
                    //        pt1 = list1[i];
                    //        pt2 = list1[i + 1];
                    //        g.DrawLine(Pens.Green, XtoI(pt1.x), YtoJ(pt1.y), XtoI(pt2.x), YtoJ(pt2.y));
                    //    }
                    //}



                   //    DrawOnGraphics(xDge, yDge, a, b, c, 0.1F);
                    //for (double coef = 0; coef < 4; coef += 0.05)
                    //{
                    //    Ray.borders(ItoX(pictureBox1.Width), JtoY(0), ItoX(0), JtoY(pictureBox1.Height));
                    //    list1 = Ray.mainReflect(xDge, yDge, ((coef * Math.PI) / 2), a, b, c);

                    //    for (int i = 0; i < list1.Count - 1; i++)
                    //    {
                    //        pt1 = list1[i];
                    //        pt2 = list1[i + 1];
                    //        g.DrawLine(Pens.Green, XtoI(pt1.x), YtoJ(pt1.y), XtoI(pt2.x), YtoJ(pt2.y));
                    //    }
                    //}
                    g.Dispose();
                    pictureBox17.Image = myBitmap;
                    
                }
            }
        }


        void DrawOnGraphicsNorm(double[][] parab, double a, double b, double c, double part = 0.001)
        {
            if (part > 0.95)
            {
                part = 1;
            }

            Bitmap newBitmap = new Bitmap(pictureBox17.Width, pictureBox17.Height);
            Graphics graphics = Graphics.FromImage(newBitmap);

            //  g = pictureBox1.CreateGraphics();
            // graphics.Clear(Color.White);

            for (double p = -10; p < 10; p += 0.3)
            {
                Func dot = Ray.cos(a, b, c, p);
                Func perp = Ray.perpendic(dot.k, p, Ray.yFromX(p, a, b, c)); 
                double alpha = Math.Atan(perp.k);

                Ray.borders(ItoX(pictureBox17.Width), JtoY(0), ItoX(0), JtoY(pictureBox17.Height));
                if (alpha < 0)
                {
                    alpha += Math.PI;
                }

                List<Point> list1 = Ray.mainReflect(p, Ray.yFromX(p, a, b, c), alpha, a, b, c);

                float oneStepDrawingPart = 0.2F;
                for (int i = 0; (i < list1.Count - 1) && (part > i * oneStepDrawingPart); i++)
                {
                    float partBase = i * oneStepDrawingPart;
                    if (partBase > 1F)
                    {
                        partBase = 1F;
                    }
                    double partActual = (part - partBase) / oneStepDrawingPart;
                    if (partActual > 1F)
                    {
                        partActual = 1F;
                    }

                    Point pt1 = list1[i];
                    Point pt2 = list1[i + 1];

                    int i1 = XtoI(pt1.x);
                    int j1 = YtoJ(pt1.y);
                    int i2 = XtoI(pt2.x);
                    int j2 = YtoJ(pt2.y);

                    int i3Actual = (int)((double)i1 + ((double)(i2 - i1) * partActual));
                    int j3Actual = (int)((double)j1 + ((double)(j2 - j1) * partActual));

                    graphics.DrawLine(Pens.Green, i1, j1, i3Actual, j3Actual);



                    graphics.DrawLine(Pens.Black, XtoI(x1), YtoJ(0), XtoI(x2), YtoJ(0));
                    graphics.DrawLine(Pens.Black, XtoI(0), YtoJ(y1), XtoI(0), YtoJ(y2));
                    for (int m = (int)x1; m < x2; m++)
                    {
                        graphics.DrawLine(Pens.Black, XtoI(m), YtoJ(-0.1), XtoI(m), YtoJ(0.1));
                        graphics.DrawString(m.ToString(), this.Font, Brushes.Black, XtoI(m) - 8, YtoJ(0) + 10);
                    }
                    for (int j = (int)y2; j < y1; j++)
                    {
                        graphics.DrawLine(Pens.Black, XtoI(-0.1), YtoJ(j), XtoI(0.1), YtoJ(j));
                        graphics.DrawString(j.ToString(), this.Font, Brushes.Black, XtoI(0) - 25, YtoJ(j) - 7);
                    }
                    graphics.DrawString("x", this.Font, Brushes.Black, XtoI(x2) - 12, YtoJ(0) - 15);
                    graphics.DrawString("y", this.Font, Brushes.Black, XtoI(0) + 5, YtoJ(y1) + 5);


                    for (int h = 1; h < parab[0].Length; h++) // цикл выводит параболу на экран
                    {
                        graphics.DrawLine(Pens.Black, XtoI(parab[0][h - 1]), YtoJ(parab[1][h - 1]), XtoI(parab[0][h]), YtoJ(parab[1][h]));
                    }

                }
            }
            pictureBox17.Image = newBitmap;
            graphics.Dispose();

            if (part < 0.95)
            {
                System.Threading.Timer timer = null;
                timer = new System.Threading.Timer((obj) =>
                {
                    DrawOnGraphicsNorm(parab, a, b, c, part + 0.01);
                    timer.Dispose();
                }, null, 1, System.Threading.Timeout.Infinite);
            }
            else
            {

            }
        }

        private void labelAni_Click(object sender, EventArgs e)
        {
            panelStart.Visible = false;
            label35.Visible = false;
            labelSign.Visible = false;
            panelPara.Visible = false;
            pictureBoxGal.Visible = false;
            panelDge.Visible = false;
            panelChose.Visible = false;
            pictureBoxVpe.Visible = false;
            pictureBoxNaz.Visible = false;
            pictureBox1.Visible = true;
            pictureBox17.Visible = false;
            pictureBoxSign.Visible = false;
            webBrowser1.Visible = false;
            labelHead.Visible = false;
            panelAni.Visible = true;
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
            g.Clear(Color.White);
            g.Dispose();
            pictureBox1.Image = myBitmap;
            timer3.Start();

        }

        private void timerAniFo1_Tick(object sender, EventArgs e)
        {
            aniTick++;
            if (aniTick == 70)
            {
                button3.Enabled = true;
                pictureBox3.Enabled = true;
                button4.Enabled = true;
                timerAniFo1.Stop();
                aniTick = 0;
            }
           
            //Graphics g = pictureBox1.CreateGraphics();
            //ptFo11 = listFoc1[0];
            //if (listFoc1.Count < 2)
            //{
            //    timerAniFo1.Stop();
            //}
            //ptFo12 = listFoc1[1];
            //if (ptFo11.x == ptFo12.x)
            //{
            //    if (counter1 == 0)
            //    {
            //        tecPos1.x = ptFo11.x;
            //        tecPos1.y = ptFo11.y - 0.1;
            //        g.DrawLine(Pens.Black, XtoI(ptFo11.x), YtoJ(ptFo11.y), XtoI(tecPos1.x), YtoJ(tecPos1.y));
            //    }
            //    else
            //    {
            //        tecPos1.y = prePos1.y - 0.1;
            //        if (tecPos1.y < ptFo12.y)
            //        {
            //            listFoc1.RemoveAt(0);
            //            counter1 = 0;
            //        }
            //        else
            //        {
            //            g.DrawLine(Pens.Black, XtoI(prePos1.x), YtoJ(prePos1.y), XtoI(tecPos1.x), YtoJ(tecPos1.y));
            //        }
            //    }
            //}
            //else
            //{
            //    if (counter1 == 1)
            //    {
            //        foc1 = basicLine.findUrav(ptFo11.x, ptFo11.y, ptFo12.x, ptFo12.y);
            //        tecPos1 = basicLine.nextPoint(foc1, ptFo11.x);
            //        g.DrawLine(Pens.Black, XtoI(ptFo11.x), YtoJ(ptFo11.y), XtoI(tecPos1.x), YtoJ(tecPos1.y));
            //    }
            //    else
            //    {
            //        tecPos1 = basicLine.nextPoint(foc1, prePos1.x);
            //        g.DrawLine(Pens.Black, XtoI(prePos1.x), YtoJ(prePos1.y), XtoI(tecPos1.x), YtoJ(tecPos1.y));
            //        if (foc1.getB() > 0)
            //        {
            //            tecPos1 = basicLine.nextPoint(foc1, prePos1.x + 0.1);

            //        }
            //    }

            //}



            //prePos1.x = tecPos1.x;
            //prePos1.y = tecPos1.y;
            //counter1++;
        }

        private void labelUse_Click(object sender, EventArgs e)
        {
            panelStart.Visible = false;
            labelSign.Visible = false;
            panelChose.Visible = false;
            label35.Visible = false;
            pictureBoxVpe.Visible = false;
            pictureBoxNaz.Visible = false;
            pictureBoxGal.Visible = false;
            pictureBoxSign.Visible = false;
            pictureBox17.Visible = false;
            pictureBox1.Visible = false;
            panelDge.Visible = false;
            panelPara.Visible = false;
            panelAni.Visible = false;
            webBrowser1.Visible = true;
            webBrowser1.Navigate(Application.StartupPath + "/Teory/Kory.htm");
            labelHead.Visible = true;
            labelHead.Text = "Як користуватися?";
            timer3.Start();
        }

        private void label18_MouseEnter(object sender, EventArgs e)
        {
            label18.ForeColor = Color.FromArgb(214, 72, 47);
             toolStripStatusLabel1.Text = "Перейти до розділу";
        }

        private void label18_MouseLeave(object sender, EventArgs e)
        {
            label18.ForeColor = Color.Black;
             toolStripStatusLabel1.Text = "";
        }

        private void label19_MouseEnter(object sender, EventArgs e)
        {
            label19.ForeColor = Color.FromArgb(214, 72, 47);
             toolStripStatusLabel1.Text = "Перейти до розділу";
        }

        private void label19_MouseLeave(object sender, EventArgs e)
        {
            label19.ForeColor = Color.Black;
             toolStripStatusLabel1.Text = "";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            panelStart.Visible = true;
            pictureBoxGal.Visible = false;
            labelSign.Visible = false;
            label35.Visible = false;
            pictureBoxVpe.Visible = false;
            pictureBoxNaz.Visible = false;
            panelChose.Visible = false;
            pictureBoxSign.Visible = false;
            pictureBox1.Visible = false;
            panelDge.Visible = false;
            panelPara.Visible = false;
            panelAni.Visible = false;
            webBrowser1.Visible = false;
            labelHead.Visible = false;
        }

        private void pictureBoxSign_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Повернутися";
        }

        private void pictureBoxSign_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void toolStripButton1_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Повернутися до початкової стрінки";
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Зображення побудови відбиття променів";
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void toolStripButton1_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void toolStripButton2_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Інформація";
        }

        private void toolStripButton2_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void panelStart_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Оберіть потрібний пункт меню";
        }

        private void panelStart_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Перейти до розділу";
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Перейти до розділу";
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Побудувати анімацію";
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Побудувати анімацію";
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Побудувати зображення";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Функція параболи";
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Коефіцієнт А параболи";
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Коефіцієнт B параболи";
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Коефіцієнт C параболи";
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void textBox6_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Значення кута α";
        }

        private void textBox6_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Побудувати зображення";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void textBoxA_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Коефіцієнт А параболи";
        }

        private void textBoxA_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void textBoxB_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Коефіцієнт B параболи";
        }

        private void textBoxB_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void textBoxC_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Коефіцієнт C параболи";
        }

        private void textBoxC_MouseLeave(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "";
        }

        private void textBoxXDge_MouseEnter(object sender, EventArgs e)
        {
             toolStripStatusLabel1.Text = "Координата Х джерела світла";
        }

        private void textBoxXDge_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void textBoxYDge_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Координата Y джерела світла";
        }

        private void textBoxYDge_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Функція параболи";
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Меню";
            label1.ForeColor = Color.FromArgb(214, 72, 47);
            pictureBox2.BackColor = Color.FromArgb(214, 72, 47);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            label1.ForeColor = Color.FromArgb(85, 88, 16);
            pictureBox2.BackColor = Color.FromArgb(85, 88, 16);
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Меню";
            label1.ForeColor = Color.FromArgb(214, 72, 47);
            pictureBox2.BackColor = Color.FromArgb(214, 72, 47);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            label1.ForeColor = Color.FromArgb(85, 88, 16);
            pictureBox2.BackColor = Color.FromArgb(85, 88, 16);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            x1 = int.Parse(TBxMin.Text);
            x2 = int.Parse(TBxMax.Text);
            y1 = int.Parse(TByMax.Text);
            y2 = int.Parse(TByMin.Text);


            x1 -= trackBar1.Value;
            x2 += trackBar1.Value;
            y1 += trackBar1.Value;
            y2 -= trackBar1.Value;

            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);

            // g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox3.Text);
            double c = double.Parse(textBox2.Text);
            double coef = double.Parse(textBox6.Text);

            if (a <= 0)
            {
                MessageBox.Show("Неправильне введення а, введіть а > 0");
            }
            else
            {
                if (coef <= 180 || coef >= 360)
                {
                    MessageBox.Show("Неправильне введення кута, введіть 180° < α < 360°");
                }
                else
                {
                    coef = ((coef * Math.PI) / 180) / (Math.PI / 2);
                    
                    SK();
                    List<Point> list1;
                    Point pt1, pt2;
                    basicLine bL = new basicLine(a, b, c);
                    double[][] parab = bL.Parabl(x1, x2); // массив точек параболы

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
                    pictureBox1.Image = myBitmap;
                }
            }
            x1 = int.Parse(TBxMin.Text);
            x2 = int.Parse(TBxMax.Text);
            y1 = int.Parse(TByMax.Text);
            y2 = int.Parse(TByMin.Text);
            }

        private void TBxMin_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Мінімальне значення по осі Х";
        }

        private void TBxMin_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void TBxMax_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Максимальне значення по осі Х";
        }

        private void TBxMax_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void TByMin_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Мінімальне значення по осі Y";
        }

        private void TByMin_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void TByMax_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Максимальне значення по осі Y";
        }

        private void TByMax_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            x1 = int.Parse(textBoxXMin.Text);
            x2 = int.Parse(textBoxXMax.Text);
            y1 = int.Parse(textBoxYMax.Text);
            y2 = int.Parse(textBoxYMin.Text);
            x1 -= trackBar2.Value;
            x2 += trackBar2.Value;
            y1 += trackBar2.Value;
            y2 -= trackBar2.Value;

            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);

            //  g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            double a = double.Parse(textBoxA.Text);
            double b = double.Parse(textBoxB.Text);
            double c = double.Parse(textBoxC.Text);
            double yDge = double.Parse(textBoxYDge.Text);
            double xDge = double.Parse(textBoxXDge.Text);

            if (a <= 0)
            {
                MessageBox.Show("Неправильне введення  а, введіть а > 0");
            }
            else
            {
                SK();
                List<Point> list1;
                Point pt1, pt2;
                basicLine bL = new basicLine(a, b, c);
                double[][] parab = bL.Parabl(x1, x2); // массив точек параболы
                for (int i = 1; i < parab[0].Length; i++) // цикл выводит параболу на экран
                {
                    g.DrawLine(Pens.Black, XtoI(parab[0][i - 1]), YtoJ(parab[1][i - 1]), XtoI(parab[0][i]), YtoJ(parab[1][i]));
                }

                if (yDge < bL.yFromX(xDge))
                {
                    MessageBox.Show("Неправильне введення координат джерела");
                }
                else
                {
                    //   DrawOnGraphics(xDge, yDge, a, b, c, 0.1F);
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
                    pictureBox1.Image = myBitmap;
                }
            }
            x1 = int.Parse(textBoxXMin.Text);
            x2 = int.Parse(textBoxXMax.Text);
            y1 = int.Parse(textBoxYMax.Text);
            y2 = int.Parse(textBoxYMin.Text);
        }
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBox3.Text;
            if (st.Length > 0)
            {
                for(int i = 0; i<st.Length; i++)
                {
                string s = st.Substring(i, 1);
                if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                {
                    MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    st = st.Remove(i, 1);
                    textBox3.Text = st;
                }
                }
            }
        }
      

       

        private void trackBar1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Рухайте повзунок для масштабування";
        }

        private void trackBar1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void trackBar2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Рухайте повзунок для масштабування";
        }

        private void trackBar2_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void textBoxXMin_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Мінімальне значення по осі Х";
        }

        private void textBoxXMin_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void textBoxXMax_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Максимальне значення по осі Х";
        }

        private void textBoxXMax_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void textBoxYMin_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Мінімальне значення по осі Y";
        }

        private void textBoxYMin_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void textBoxYMax_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Максимальне значення по осі Y";
        }

        private void textBoxYMax_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBox1.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        textBox1.Text = st;
                    }
                }
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBox2.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        textBox2.Text = st;
                    }
                }
            }
        }

        private void TBxMin_KeyUp(object sender, KeyEventArgs e)
        {
            string st = TBxMin.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        TBxMin.Text = st;
                    }
                }
            }
        }

        private void TBxMax_KeyUp(object sender, KeyEventArgs e)
        {
            string st = TBxMax.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        TBxMax.Text = st;
                    }
                }
            }
        }

        private void TByMin_KeyUp(object sender, KeyEventArgs e)
        {
            string st = TByMin.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        TByMin.Text = st;
                    }
                }
            }
        }

        private void TByMax_KeyUp(object sender, KeyEventArgs e)
        {
            string st = TByMax.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        TByMax.Text = st;
                    }
                }
            }
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBox6.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        textBox6.Text = st;
                    }
                }
            }
        }

        private void textBoxA_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBoxA.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        textBoxA.Text = st;
                    }
                }
            }
        }

        private void textBoxB_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBoxB.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        textBoxB.Text = st;
                    }
                }
            }
        }

        private void textBoxC_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBoxC.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        textBoxC.Text = st;
                    }
                }
            }
        }

        private void textBoxXMin_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBoxXMin.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        textBoxXMin.Text = st;
                    }
                }
            }
        }

        private void textBoxXMax_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBoxXMax.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        textBoxXMax.Text = st;
                    }
                }
            }
        }

        private void textBoxYMin_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBoxYMin.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        textBoxYMin.Text = st;
                    }
                }
            }
        }

        private void textBoxYMax_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBoxYMax.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        textBoxYMax.Text = st;
                    }
                }
            }
        }

        private void textBoxXDge_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBoxXDge.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        textBoxXDge.Text = st;
                    }
                }
            }
        }

        private void textBoxYDge_KeyUp(object sender, KeyEventArgs e)
        {
            string st = textBoxYDge.Text;
            if (st.Length > 0)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    string s = st.Substring(i, 1);
                    if (s.Equals("0") == false && s.Equals("1") == false && s.CompareTo("2") != 0 && s.CompareTo("3") != 0 && s.CompareTo("4") != 0 && s.CompareTo("5") != 0 && s.CompareTo("6") != 0 && s.CompareTo("7") != 0 && s.CompareTo("8") != 0 && s.CompareTo("9") != 0 && s.CompareTo(",") != 0 && s.CompareTo(".") != 0 && s.CompareTo("-") != 0)
                    {
                        MessageBox.Show("Неправильне введення символу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        st = st.Remove(i, 1);
                        textBoxYDge.Text = st;
                    }
                }
            }
        }

        private void timerAniFo2_Tick(object sender, EventArgs e)
        {
            aniTick2++;
            if (aniTick2 == 70)
            {
                button4.Enabled = true;
                button3.Enabled = true;
                pictureBox3.Enabled = true;
                timerAniFo2.Stop();
                aniTick2 = 0;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            panelStart.Visible = false;
            panelChose.Visible = false;
            labelSign.Visible = false;
            label35.Visible = false;
            pictureBoxVpe.Visible = false;
            pictureBoxNaz.Visible = false;
            pictureBoxGal.Visible = false;
            pictureBoxSign.Visible = false;
            pictureBox17.Visible = false;
            pictureBox1.Visible = false;
            panelDge.Visible = false;
            panelPara.Visible = false;
            panelAni.Visible = false;
            webBrowser1.Visible = true;
            webBrowser1.Navigate(Application.StartupPath + "/Teory/Info.htm");
            labelHead.Visible = true;
            labelHead.Text = "Інформація";
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            panelStart.Visible = false;
            labelSign.Visible = false;
            label35.Visible = false;
            panelPara.Visible = false;
            pictureBoxVpe.Visible = false;
            pictureBoxNaz.Visible = false;
            pictureBoxGal.Visible = false;
            panelDge.Visible = false;
            panelChose.Visible = false;
            pictureBox1.Visible = true;
            pictureBox17.Visible = false;
            pictureBoxSign.Visible = false;
            webBrowser1.Visible = false;
            labelHead.Visible = false;
            panelAni.Visible = true;
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
            g.Clear(Color.White);
            g.Dispose();
            pictureBox1.Image = myBitmap;
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            panelChose.Visible = true;
            labelSign.Visible = false;
            panelStart.Visible = false;
            label35.Visible = false;
            pictureBoxVpe.Visible = false;
            pictureBoxNaz.Visible = false;
            pictureBoxGal.Visible = false;
            webBrowser1.Visible = false;
            pictureBox17.Visible = false;
            labelHead.Visible = false;
            panelAni.Visible = false;
            pictureBox1.Visible = false;
            panelPara.Visible = false;
            panelDge.Visible = false;
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            panelStart.Visible = false;
            panelChose.Visible = false;
            labelSign.Visible = false;
            label35.Visible = false;
            pictureBoxVpe.Visible = false;
            pictureBoxNaz.Visible = false;
            pictureBoxGal.Visible = false;
            pictureBoxSign.Visible = false;
            pictureBox17.Visible = false;
            pictureBox1.Visible = false;
            panelDge.Visible = false;
            panelPara.Visible = false;
            panelAni.Visible = false;
            webBrowser1.Visible = true;
            webBrowser1.Navigate(Application.StartupPath + "/Teory/Teory.htm");
            labelHead.Visible = true;
            labelHead.Text = "Теоретичні основи";
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            panelStart.Visible = false;
            labelSign.Visible = false;
            panelChose.Visible = false;
            pictureBoxVpe.Visible = false;
            label35.Visible = false;
            pictureBoxNaz.Visible = false;
            pictureBoxGal.Visible = false;
            pictureBoxSign.Visible = false;
            pictureBox17.Visible = false;
            pictureBox1.Visible = false;
            panelDge.Visible = false;
            panelPara.Visible = false;
            panelAni.Visible = false;
            webBrowser1.Visible = true;
            webBrowser1.Navigate(Application.StartupPath + "/Teory/Kory.htm");
            labelHead.Visible = true;
            labelHead.Text = "Як користуватися?";
        }
        int ub = 0;
        private void timer5_Tick(object sender, EventArgs e)
        {
            ub++;
            if (ub == 40)
            {
                ub = 0;
                timer5.Stop();
                timer3.Start();
            }
        }

        private void statusStrip1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Рядок стану";
        }

        private void statusStrip1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void pictureBox18_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxGall.BackColor = Color.FromArgb(170, 179, 119);
            labelGal.BackColor = Color.FromArgb(170, 179, 119);
            labelGal.ForeColor = Color.FromArgb(250, 250, 250);
            toolStripStatusLabel1.Text = "Розділ з фотографіями каустики";
        }

        private void pictureBoxNaz_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Вперед";
        }

        private void pictureBoxGal_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Зображення каустики";
        }

        private void pictureBoxGal_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void pictureBoxNaz_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void pictureBoxVpe_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Вперед";
        }

        private void pictureBoxVpe_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void labelSign_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Підпис до зображення";
        }

        private void labelSign_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void pictureBoxGall_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxGall.BackColor = Color.FromArgb(213, 219, 188);
            labelGal.BackColor = Color.FromArgb(213, 219, 188);
            labelGal.ForeColor = Color.FromArgb(85, 88, 16);
            toolStripStatusLabel1.Text = "";
        }

        private void labelGal_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxGall.BackColor = Color.FromArgb(170, 179, 119);
            labelGal.BackColor = Color.FromArgb(170, 179, 119);
            labelGal.ForeColor = Color.FromArgb(250, 250, 250);
            toolStripStatusLabel1.Text = "Розділ з фотографіями каустики";
        }

        private void labelGal_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxGall.BackColor = Color.FromArgb(213, 219, 188);
            labelGal.BackColor = Color.FromArgb(213, 219, 188);
            labelGal.ForeColor = Color.FromArgb(85, 88, 16);
            toolStripStatusLabel1.Text = "";
        }

        private void labelGal_Click(object sender, EventArgs e)
        {
            string[] s = File.ReadAllLines("Sign.txt");
            panelStart.Visible = false;
            label35.Visible = true;
            labelSign.Visible = true;
            panelChose.Visible = false;
            pictureBoxSign.Visible = false;
            pictureBox17.Visible = false;
            pictureBox1.Visible = false;
            panelDge.Visible = false;
            panelPara.Visible = false;
            panelAni.Visible = false;
            webBrowser1.Visible = false;
            labelHead.Visible = false;
            pictureBoxGal.Visible = true;
            pictureBoxVpe.Visible = true;
            string st = "\\Foto\\" + foto.ToString() + ".jpg";
            pictureBoxGal.Image = Image.FromFile(Application.StartupPath + st);
            labelSign.Text = s[foto-1];
            timer3.Start();
        }

        private void pictureBoxVpe_Click(object sender, EventArgs e)
        {
            string[] s = File.ReadAllLines("Sign.txt");
            pictureBoxNaz.Visible = true;
            foto++;
            string st = "\\Foto\\" + foto.ToString() + ".jpg";
            pictureBoxGal.Image = Image.FromFile(Application.StartupPath + st);
           
            if (foto == 16)
            {
                pictureBoxVpe.Visible = false;
            }
            labelSign.Text = s[foto - 1];
        }

        private void pictureBoxNaz_Click(object sender, EventArgs e)
        {
            string[] s = File.ReadAllLines("Sign.txt");
            pictureBoxVpe.Visible = true; 
            foto--;
            string st = "\\Foto\\" + foto.ToString() + ".jpg";
            pictureBoxGal.Image = Image.FromFile(Application.StartupPath + st);
           
            if (foto-1 == 1)
            {
                pictureBoxNaz.Visible = false;
            }
            labelSign.Text = s[foto-1];

            
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            string[] s = File.ReadAllLines("Sign.txt");
            panelStart.Visible = false;
            labelSign.Visible = true;
            label35.Visible = true;
            panelChose.Visible = false;
            labelSign.Visible = false;
            pictureBoxSign.Visible = false;
            pictureBox17.Visible = false;
            pictureBox1.Visible = false;
            panelDge.Visible = false;
            panelPara.Visible = false;
            panelAni.Visible = false;
            webBrowser1.Visible = false;
            labelHead.Visible = false;
            pictureBoxGal.Visible = true;
            string st = "\\Foto\\" + foto.ToString() + ".jpg";
            pictureBoxGal.Image = Image.FromFile(Application.StartupPath + st);
            pictureBoxVpe.Visible = true;
            labelSign.Text = s[foto-1];
        }


      

      

        

        


        }
}
    

