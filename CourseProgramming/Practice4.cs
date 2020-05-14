using System;
using System.Windows.Forms;

//4.28
//Каждый из элементов xi массива X(n) 
//заменить средним значением первых i элементов этого массива.

namespace CourseProgramming
{
    public partial class Practice4 : Form
    {
        public Practice4()
        {
            InitializeComponent();
        }

        private void Practice4_Load(object sender, EventArgs e) //заполняем текстбокс
        {
            for (int i = 0; i < 5; i++)
            {
                textBox1.Text += Convert.ToString(i+1) + Environment.NewLine;
            }
            textBox1.Text += Convert.ToString(6);
        }


        private void Button1_Click(object sender, EventArgs e) 
        {
            string[] textBox = textBox1.Lines;
            int N = textBox.Length;
            int err1 = 0;
            double[] intBox = new double[N];
            double[] intBox2 = new double[N];
            textBox2.Clear();
            //Считываем массив
            try
            {
                for (int i = 0; i < N; i++)
                {
                    intBox[i] = Convert.ToDouble(textBox[i]);
                }
            }
            catch
            {
                textBox2.Text = "Неверный ввод" + Environment.NewLine;
                err1++;
            }
            //Заменяем элементы и выводим массив
            if (err1 == 0)
            {
                for (int i = 0; i < N; i++)
                {
                    double count = 0; int err = 0;
                    for (int j = 0; j <= i; j++)
                    {
                        count += intBox[j];
                        err++;
                    }
                    if (err != 0)
                    {
                        intBox2[i] = count / (i + 1);
                    }
                    textBox2.Text += Math.Round(intBox2[i], 2) + Environment.NewLine;
                }
            }
        }

        private void Practice4_FormClosed(object sender, FormClosedEventArgs e) //При закрытии формы открывать меню выбора задачи
        {
            Form fr1 = Application.OpenForms[0];
            fr1.Show();

        }
    }
}
