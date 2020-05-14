using System;
using System.Windows.Forms;

//360
//Даны: натуральное число n, символы s1..sn. 
//Найти все палиндромические начальные отрезки последовательности s1..sn, 
//т.е такие отрезки s1..sk(k<=n), что s1=sk, s2=s(k-1).

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
            textBox1.Text = "15513731551";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string number = textBox1.Text; 
            int len; int err = 0;
            textBox2.Text = "";
            len = textBox1.Text.Length;
            
            for (int i = 0; i < len-2; i++)
            {
                int stop = 0; string palindrom = "", center = "";
                int now = 0, charge = 0;
                //Если нечетное кол-во чисел в палиндроме
                if (number[i] == number[i + 2]) 
                {
                    center = Convert.ToString(number[i + 1]);
                    palindrom += number[i + 2];
                    now = i + 3;
                    charge = 4;
                }
                //Если четное количество чисел в палиндроме
                else if (number[i] == number[i + 1]) 
                {
                    palindrom += number[i];
                    now = i + 2;
                    charge = 3;
                }
                //Если палиндром найден
                if (charge != 0)
                {
                    //Проверка на выход за границы
                    if ((now - charge < 0) || (now >= len)) 
                    {
                        stop = 1;
                    }
                    //Ищем конец палиндрома
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
                    string Reverse;
                    Array.Reverse(sReverse);
                    Reverse = new string(sReverse);
                    //Выводим палиндром
                    if (now - charge + 1 == 0)
                    {
                        textBox2.Text += Reverse + center + palindrom + Environment.NewLine;
                        err++;
                    }
                }
            }
            //Если палиндромы не найдены
            if (err == 0)
            {
                textBox2.Text += "Палиндромы не найдены" + Environment.NewLine;
            }
        }

        private void Practice2_FormClosed(object sender, FormClosedEventArgs e) //Возвращение к окну выбора задачи
        {
            Form fr1 = Application.OpenForms[0];
            fr1.Show();
        }
    }
}

