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
            textBox1.Text = "153735";
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
            for (int i = 0; i < len-2; i++)
            {
                int stop = 0; string palindrom = "", center = "";
                int now = 0, charge = 0;
                if (number[i] == number[i + 2])
                {
                    center = Convert.ToString(number[i + 1]);
                    palindrom += number[i + 2];
                    now = i + 3;
                    charge = 4;
                }
                else if (number[i] == number[i + 1])
                {
                    palindrom += number[i];
                    now = i + 2;
                    charge = 3;
                }

                if (charge != 0)
                {
                    if ((now - charge < 0) || (now >= len))
                    {
                        stop = 1;
                    }
                    while (stop == 0)
                    {
                        if (number[now] == number[now - charge])
                        {
                            palindrom += number[now];
                            now += 1;
                            charge += 2;
                        }
                        else
                        {
                            stop = 1;
                        }

                        if ((now - charge < 0) || (now >= len))
                        {
                            stop = 1;
                        }

                    }
                    char[] sReverse = palindrom.ToCharArray();
                    string Reverse = "";
                    Array.Reverse(sReverse);
                    Reverse = new string(sReverse);
                    textBox2.Text += Reverse + center + palindrom + Environment.NewLine;
                }
            }
        }
    }
}
