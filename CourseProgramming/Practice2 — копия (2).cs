using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProgramming
{
    public partial class Practice2 : Form
    {
        public Practice2()
        {
            InitializeComponent();
        }

        private void Practice2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "53735";
        }

        private void Practice2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form fr1 = Application.OpenForms[0];
            fr1.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string number = textBox1.Text; 
            int len;
            len = textBox1.Text.Length;
            textBox2.Text = "Длина строки: " + len + Environment.NewLine;
            for (int i = 1; i < len; i++)
            {
                string palindrom = "", center = "";
                int now = 0, charge = 0, stop = 0, iStart = 0, iEnd = 2, trul = 0;

                if (number[0] == number[i])
                {
                    int End = i;
                    while (stop == 0)
                    {

                        if ((number[iStart] == number[iEnd])&&(iStart<iEnd))
                        {
                            iStart++; iEnd--;
                            trul = 1;
                        }
                        else
                        {
                            if (trul == 1)
                            {
                                for (int j = 0; j <= End; j++)
                                {
                                    textBox2.Text += number[j];
                                }
                            }
                            stop = 1;
                        }
                    }
                    textBox2.Text +=  Environment.NewLine;
                }
            }
        }
    }
}
