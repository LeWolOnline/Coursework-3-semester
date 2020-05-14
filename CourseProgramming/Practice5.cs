using System;
using System.Drawing;
using System.Windows.Forms;

//5.4
//Куб состоит из n^3 прозрачных и непрозрачных элементарных кубиков.
//Имеется ли хотя бы один просвет по каждому из трех измерений?
//Если это так, то вывести координаты каждого просвета.

namespace CourseProgramming
{
    public partial class Practice5 : Form
    {
        int[,,] A = new int[10, 10, 10];
        int n = 0;
        Point Start = new Point(150, 250);
        int a = 40;
        int a1;
        public Practice5()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            int chance = 0;
            n = (int)numericUpDown1.Value;
            chance = (int)numericUpDown2.Value / 10;
            a = 150/n ;
            int random;
            Random rand = new Random();
            textBox1.Text = "Слои куба:" + Environment.NewLine + Environment.NewLine;
            //X=i, Y=j, Z=k
            //Заполняем куб значениями
            for (int k = 0; k < n; k++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        random = rand.Next(1, 11);
                        if (random > chance)
                        {
                            A[i, j, k] = 0;
                        }
                        else
                        {
                            A[i, j, k] = 1;
                        }
                        textBox1.Text += A[i, j, k] + "  ";
                    }
                    textBox1.Text += Environment.NewLine;

                }
                textBox1.Text += Environment.NewLine;
            }
            Cube();
            //Если просветы найдены - вывести их
            if (Clearance(1)) 
            {
                Clearance(2);
            }
            //if 
        }

        private bool Clearance(int mode) //Ищем просветы. Мод 1 = проверка, есть ли просветы по каждому из 3 направлений, Мод 2 = вывод просветов
        {
            //Выводим координаты горизонтальных просветов
            if (mode == 2)
            {
                textBox4.Text += "Горизонтальные:" + Environment.NewLine;
            }
            
            int count = 0;
            int c1 = 0, c2 = 0, c3 = 0;
            for (int k = 0; k < n; k++) //Двигаемся по матрице k*j
            {
                for (int j = 0; j < n; j++)
                {
                    int summ = 0;
                    for (int i = 0; i < n; i++)
                    {
                        summ += A[i, j, k];
                    }
                    if (summ == 0)
                    {
                        if (mode == 1)
                        {
                            c1++;
                        }
                        if (mode == 2)
                        {
                            textBox4.Text += (k + 1) + " квадрат, " + (j + 1) + " строка" + Environment.NewLine;
                            count++;
                        }
                    }
                }
            }
            if (mode == 2)
            {
                if (count == 0)
                {
                    textBox4.Text += " - " + Environment.NewLine;
                }
                //Выводим координаты сквозных просветов
                count = 0;
                textBox4.Text += "Сквозные(для слоев):" + Environment.NewLine;
            }
            for (int j = 0; j < n; j++) //Двигаемся по матрице j*i
            {
                for (int i = 0; i < n; i++)
                {
                    int summ = 0;
                    for (int k = 0; k < n; k++)
                    {
                        summ += A[i, j, k];
                    }
                    if (summ == 0)
                    {
                        if (mode == 1)
                        {
                            c2++;
                        }
                        if (mode == 2)
                        {
                            textBox4.Text += (i + 1) + " столбец, " + (j + 1) + " строка" + Environment.NewLine;
                            count++;
                        }
                    }
                }
            }
            if (mode == 2)
            {
                if (count == 0)
                {
                    textBox4.Text += " - " + Environment.NewLine;
                }
                //Выводим координаты вертикальных просветов
                count = 0;
                textBox4.Text += "Вертикальные(для слоев):" + Environment.NewLine;
            }
            for (int i = 0; i < n; i++) //Двигаемся по матрице i*k
            {
                for (int k = 0; k < n; k++)
                {
                    int summ = 0;
                    for (int j = 0; j < n; j++)
                    {
                        summ += A[i, j, k];
                    }
                    if (summ == 0)
                    {
                        if (mode == 1)
                        {
                            c3++;
                        }
                        if (mode == 2)
                        {
                            textBox4.Text += (k + 1) + " квадрат, " + (i + 1) + " столбец" + Environment.NewLine;
                            count++;
                        }
                    }
                }
            }
            if (mode == 2)
            {
                if (count == 0)
                {
                    textBox4.Text += " - " + Environment.NewLine;
                }
            }
            if (c1!=0 & c2!=0 & c3!=0)
            {
                textBox4.Text +="Есть просвет по каждому из направлений" + Environment.NewLine + "------------------------" + Environment.NewLine;
                return true;
            }
            if (mode == 1)
            {
                textBox4.Text += "Нет просветов по трем направлениям сразу" + Environment.NewLine;
            }
            return false;
        }

        private void Cube() //Рисуем куб
        {
            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush mySolidBrush = new SolidBrush(Color.Black);
            Pen grayPen = new Pen(Color.Gray, 1);
            Point StartNew;
            g.Clear(Color.White);
            a1 = a / 2;
            int k1 = 0;
            for (int k = n - 1; k > -1; k--)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        StartNew = new Point(Start.X + a * i - a1 * j, Start.Y - a * k1 + a1 * j);
                        int value = A[i, j, k];
                        //Формируем список точек
                        Point point1 = new Point(StartNew.X, StartNew.Y);
                        Point point2 = new Point(StartNew.X + a, StartNew.Y);
                        Point point3 = new Point(StartNew.X + a + a1, StartNew.Y - a1);
                        Point point4 = new Point(StartNew.X + a + a1, StartNew.Y - a - a1);
                        Point point5 = new Point(StartNew.X + a1, StartNew.Y - a - a1);
                        Point point6 = new Point(StartNew.X, StartNew.Y - a);
                        Point pointCenter1 = new Point(StartNew.X + a1, StartNew.Y - a1);
                        Point pointCenter2 = new Point(StartNew.X + a, StartNew.Y - a);
                        Point[] curvePoints =
                                 {
                                point1,
                                point2,
                                point3,
                                point4,
                                point5,
                                point6
                                };
                        //Прорисовка 
                        if (value == 1)
                        {
                            g.FillPolygon(mySolidBrush, curvePoints);
                        }
                        else
                        {
                            g.DrawLine(grayPen, pointCenter1, point1);
                            g.DrawLine(grayPen, pointCenter1, point3);
                            g.DrawLine(grayPen, pointCenter1, point5);
                        }
                        g.DrawPolygon(grayPen, curvePoints);
                        g.DrawLine(grayPen, pointCenter2, point2);
                        g.DrawLine(grayPen, pointCenter2, point4);
                        g.DrawLine(grayPen, pointCenter2, point6);
                    }
                }
                k1++;
            }
        }

        private void Practice5_FormClosed(object sender, FormClosedEventArgs e) //При закрытии формы открываем меню задач
        {
            Form fr1 = Application.OpenForms[0];
            fr1.Show();
        }
    }
}
