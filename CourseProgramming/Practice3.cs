using System;
using System.Windows.Forms;

//675
//Даны действительные числа a1..an, действительная квадратная матрица 
//порядка n(n>=6). Получить действительную матрицу размера n*(n+1),
//вставив  в исходную матрицу между пятым и шестым столбцами
//новый столбик с элементами a1..an.

namespace CourseProgramming
{
    public partial class Practice3 : Form
    {
        int[,] A = new int[16, 16];
        int n;
        public Practice3()
        {
            InitializeComponent();
            n = (int)numericUpDown1.Value;
            label4.Text = String.Format("Ввести столбец \nдля добавления \nв таблицу \n({0} элементов): ", n);
        }

        private void Practice3_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < n; i++)
            {
                textBox4.Text += i + 1 + Environment.NewLine;
            }
            numericUpDown1_ValueChanged(sender, e);
        }

        private void Button4_Click(object sender, EventArgs e) //Добавление строки
        {
            dataGridView2.RowCount = n;
            dataGridView2.ColumnCount = n + 1;
            //Обновляем DataGridViev
            for (int i = 0; i < n; i++) 
            {
                dataGridView2.Rows[i].Height = (dataGridView2.Height - 5) / n;
                for (int j = 0; j < (n + 1); j++)
                {
                    dataGridView2.Columns[j].Width = (dataGridView2.Width - 5) / (n + 1);
                    dataGridView2.Rows[i].Cells[j].Value = Convert.ToString(A[i, j]);
                }
            }
            // Смещаем всё правее 5-го столбца
            for (int i = 0; i < n; i++) 
            {
                for (int j = 5; j < (n + 1); j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = Convert.ToString(A[i, j - 1]);
                }
            }
            //Страховка от недостаточного количества строк в текстбоксе
            string[] tempArray = new string[n];
            int nL;
            if (textBox4.Lines.Length > n) { nL = n; }
            else { nL = textBox4.Lines.Length; }
            for (int i = 0; i < n; i++)
            {
                tempArray[i] = "-";
            }
            // Читаем a1..an
            for (int i = 0; i < nL; i++)
            {
                tempArray[i] = textBox4.Lines[i];
            }
            // Добавляем столбец
            for (int i = 0; i < n; i++) 
            {
                int j = 5;
                dataGridView2.Rows[i].Cells[j].Value = tempArray[i];
                dataGridView2.Rows[i].Cells[j].Selected = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) //Изменение n
        {
            n = (int)numericUpDown1.Value;
            label4.Text = String.Format("Ввести столбец \nдля добавления \nв таблицу \n({0} элементов): ", n);
            Random rand = new Random();

            //Обновляем текстбокс
            textBox4.Text = "";
            for (int i = 0; i < n; i++)
            {
                textBox4.Text += i + 1 + Environment.NewLine;
            }
            //Создаем таблицу n*n
            dataGridView2.RowCount = n;
            dataGridView2.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                dataGridView2.Rows[i].Height = (dataGridView2.Height - 5) / n;
                for (int j = 0; j < n; j++)
                {
                    dataGridView2.Columns[j].Width = (dataGridView2.Width - 5) / n;

                    A[i, j] = rand.Next(0, 20);
                    dataGridView2.Rows[i].Cells[j].Value = Convert.ToString(A[i, j]);
                    dataGridView2.Rows[i].Cells[j].Selected = false;
                }
            }
        }

        private void Practice3_FormClosed(object sender, FormClosedEventArgs e) //Возвращение к окну выбора задачи
        {
            Form fr1 = Application.OpenForms[0];
            fr1.Show();
        }
    }
}
