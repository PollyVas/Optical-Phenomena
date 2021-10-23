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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormParabola frmPar = new FormParabola();
            frmPar.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMirror frmMir = new FormMirror();
            frmMir.Show();
            this.Hide();
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRealCays frmCay = new FormRealCays();
            frmCay.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormCaysticaCaystica frmRe = new FormCaysticaCaystica();
            frmRe.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }
    }
}
