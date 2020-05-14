using System;
using System.Windows.Forms;

namespace CourseProgramming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Practice1 pr1 = new Practice1();
            pr1.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Practice2 pr2 = new Practice2();
            pr2.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Practice3 pr3 = new Practice3();
            pr3.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Practice4 pr4 = new Practice4();
            pr4.Show();
            this.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Practice5 pr5 = new Practice5();
            pr5.Show();
            this.Hide();
        }

    }
}
