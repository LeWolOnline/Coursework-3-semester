using System;
using System.Windows.Forms;

//6.1
//Седловой точкой в матрице называется элемент, являющийся одновременно
//наибольшим в столбце и наименьшем в строке: a[p,q] = max a[i,q] = max a[p,j].
//Седловых точек может быть несколько (в этом случае они имеют равные значения).
//В матрице А[m,n] найти седловую точку и ее координаты  p, q. 
//Либо установить что такой точки нет

namespace CourseProgramming
{
    public partial class Practice1 : Form
    {
        int[,] A = new int[20, 20];
        int m, n;

        public Practice1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) //Заполнение таблицы рандомом
        {
            textBox3.Text = "";
            Random rand = new Random();

            //Считываем значения
            m = (int)numericUpDown1.Value;
            n = (int)numericUpDown2.Value;

            //Заполняем таблицу
            dataGridView1.RowCount = m; 
            dataGridView1.ColumnCount = n;
            for (int i = 0; i < m; i++)
            {
                dataGridView1.Rows[i].Height = (dataGridView1.Height - 5) / m;
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Columns[j].Width = (dataGridView1.Width - 5) / n;
                    A[i, j] = rand.Next(0, 20);
                    dataGridView1.Rows[i].Cells[j].Selected = false;
                    dataGridView1.Rows[i].Cells[j].Value = Convert.ToString(A[i, j]);
                }
            }

        }

        private void Button2_Click(object sender, EventArgs e) //Ищем седловую точку
        {
            //Строки j=m=p; Столбцы i=n=q
            textBox3.Text = "Седловые точки:" + Environment.NewLine;
            int check = 0;
            //Проверяем введенные значения
            try
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        A[j, i] = Convert.ToInt32(dataGridView1.Rows[j].Cells[i].Value);
                        dataGridView1.Rows[j].Cells[i].Selected = false;
                    }
                }
            }
            catch
            {
                textBox3.Text = "Введены неверные значения в таблицу";
                check++;
            }
            //Ищем седловые точки и выводим их в текстбокс
            if (check == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    int k = -1, p = -1, q = -1;
                    for (int j = 0; j < m; j++)
                    {
                        if (A[j, i] > k)
                        {
                            k = A[j, i];
                            q = i;
                            p = j;
                        }
                    }

                    int min = A[p, q], k2 = -1;
                    for (int z = 0; z < n; z++)
                    {
                        if (A[p, z] < min)
                        {
                            k2++;
                        }
                    }
                    if (k2 == -1)
                    {
                        textBox3.Text += "[" + (p + 1) + "][" + (q + 1) + "]" + " - Подходит" + Environment.NewLine;
                        dataGridView1.Rows[p].Cells[q].Selected = true;
                        check++;
                    }
                }
            }
            //Если седловые точки отсутствуют
            if (check == 0)
            {
                textBox3.Text += "не найдены";
            }
        }

        private void Practice1_FormClosed (object sender, FormClosedEventArgs e) //Возвращение к окну выбора задачи
        {
            Form fr1 = Application.OpenForms[0];
            fr1.Show();
        }
    }
}
