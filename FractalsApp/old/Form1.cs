using System;
using System.Drawing;
using System.Windows.Forms;
using FractalsApp.Fractals;
using FractalsApp.Fractals.FractalTree;
using FractalsApp.Fractals.CantorsSet;
using FractalsApp.Fractals.SierpinskiCarpet;
using FractalsApp.Fractals.SierpinskiTriangle;
using FractalsApp.Fractals.KochCurve;

namespace FractalsApp
{
    public partial class FractalsMainForm : Form
    {
        private int flag = -1;
        // Какие меню открыты, а какие нет.
        private bool flagForTree = false;
        private bool flagForKoch = false;
        private bool flagForCarpetAndTriangle = false;
        private bool flagForCantor = false;
        private double treeRatio;
        public FractalsMainForm()
        {
            InitializeComponent();
            // Минимальный размер - половина от максимального.
            Size maxSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            Size minSize = new Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);
            MaximumSize = maxSize;
            MinimumSize = minSize;
            Size = minSize;
            ShowButtonsForTree(false);
            ShowButtonsForKoch(false);
            ShowButtonsForCarpetAndTriangle(false);
            ShowButtonsForCantor(false);
            ShowMainScreen(true);
            // Установка значений по умолчанию.
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox4.Text = "1";
            textBox3.Text = "30";
            MessageBox.Show("Прочти сначала инфо плиз");
        }
        /// <summary>
        /// Кнопка выхода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите выйти из программы?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Выход из программы.
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Кнопка информации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Привет\n" +
                "Я очень старался, не вали пожалуйста!\n" +
                "Чтобы найти информацию, как вводить данные, есть подсказки help me\n" +
                "Из доп функционала есть возможность масштабирования,\n" +
                "А также возмоность снимка фрактала.\n" +
                "Снимки будут сохраняться в папку с испольняемым EXE-объектом.\n" +
                "Хорошего тебе дня, уважаемый инспектор <3\n" +
                "P.S. Пожалуйста, при выборе фрактала, перед выбором другого \n" +
                "Закрывай изначальный фрактал, нажав на его имя в списке еще раз,\n" +
                "Я что-то не смог пофиксить, буду очень рад советам!");
        }
        /// <summary>
        /// Кнопка, которая возвращает в меню после отрисовки фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox2.Controls.Clear();
            ShowMainScreen(true);

        }
        /// <summary>
        /// Делает кнопки для Кантора видимыми.
        /// </summary>
        /// <param name="show"></param>
        private void ShowButtonsForCantor(bool show)
        {
            textBox2.Visible = show;
            button12.Visible = show;
            trackBar5.Visible = show;
            trackBar6.Visible = show;
            textBox3.Visible = show;
            button13.Visible = show;
        }
        /// <summary>
        /// Делает кнопки для ковра Серпинского видимыми.
        /// </summary>
        /// <param name="show"></param>
        private void ShowButtonsForCarpetAndTriangle(bool show)
        {
            button11.Visible = show;
            trackBar5.Visible = show;
            textBox4.Visible = show;
            button13.Visible = show;
        }
        /// <summary>
        /// Делает кнопки для кривой Коха видимыми.
        /// </summary>
        /// <param name="show"></param>
        private void ShowButtonsForKoch(bool show)
        {
            textBox2.Visible = show;
            trackBar4.Visible = show;
            button10.Visible = show;
            button13.Visible = show;
        }
        /// <summary>
        /// Делает кнопки для фрактального дерева видимыми.
        /// </summary>
        /// <param name="show"></param>
        private void ShowButtonsForTree(bool show)
        {
            textBox1.Visible = show;
            textBox2.Visible = show;
            textBox5.Visible = show;
            trackBar1.Visible = show;
            trackBar2.Visible = show;
            button9.Visible = show;
            textBox4.Visible = show;
            trackBar3.Visible = show;
            button13.Visible = show;
        }
        /// <summary>
        /// показывает или скрывает кнопки меню.
        /// </summary>
        /// <param name="show"></param>
        private void ShowMainScreen(bool show)
        {
            button8.Visible = !show;
            button1.Visible = show;
            button2.Visible = show;
            button3.Visible = show;
            button4.Visible = show;
            button5.Visible = show;
            button6.Visible = show;
            button7.Visible = show;
            pictureBox1.Visible = show;
            pictureBox2.Visible = !show;
            button13.Visible = !show;
            button14.Visible = !show;
        }
        /// <summary>
        /// Выбор фрактала для отрисовки.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="flag">Показывает id фрактала который будем рисовать.</param>
        private void Draw(PaintEventArgs e, int flag)
        {
            // Создает фракталы, в зависимости от выбора.
            // Далее рисует их.
            Fractal newFrac;
            if (flag == 0)
            {
                newFrac = new FractalTree(e, pictureBox2.Width, pictureBox2.Height, pictureBox2.Height / 4, trackBar1.Value, trackBar2.Value, treeRatio, trackBar3.Value);
                newFrac.Draw();
            }
            else if (flag == 1)
            {
                newFrac = new KochCurve(e, pictureBox2.Width, pictureBox2.Height, trackBar4.Value);
                newFrac.Draw();
            }
            else if (flag == 2)
            {
                newFrac = new SierpinskiCarpet(e, pictureBox2.Width, pictureBox2.Height, trackBar5.Value);
                newFrac.Draw();
            }
            else if (flag == 3)
            {
                newFrac = new SierpinskiTriangle(e, pictureBox2.Width, pictureBox2.Height, trackBar5.Value);
                newFrac.Draw();
            }
            else if (flag == 4)
            {
                newFrac = new CantorsSet(e, pictureBox2.Width, pictureBox2.Height, trackBar5.Value, trackBar6.Value);
                newFrac.Draw();
            }
        }
        /// <summary>
        /// Показывает меню для фрактального дерева.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            ShowButtonsForTree(!flagForTree);
            flagForTree = !flagForTree;
            flag = 0;
        }
        /// <summary>
        /// Показывает меню для кривой Коха.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            ShowButtonsForKoch(!flagForKoch);
            flagForKoch = !flagForKoch;
            flag = 1;
        }
        /// <summary>
        /// Показывает меню для ковра Серпинского.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            ShowButtonsForCarpetAndTriangle(!flagForCarpetAndTriangle);
            flagForCarpetAndTriangle = !flagForCarpetAndTriangle;
            flag = 2;
        }
        /// <summary>
        /// Показывает меню для треугольника Серпинского.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            ShowButtonsForCarpetAndTriangle(!flagForCarpetAndTriangle);
            flagForCarpetAndTriangle = !flagForCarpetAndTriangle;
            flag = 3;
        }
        /// <summary>
        /// Показывает кнопки для множества Кантора.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            ShowButtonsForCantor(!flagForCantor);
            flagForCantor = !flagForCantor;
            flag = 4;
        }
        /// <summary>
        /// Рисует фракталы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Draw(e, flag);
        }
        /// <summary>
        /// Обновляет фрактал, если изменили размер окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_SizeChanged(object sender, EventArgs e)
        {
            pictureBox2.Refresh();
        }
        /// <summary>
        /// Обновляет фрактал, если изменили размер окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FractalsMainForm_SizeChanged(object sender, EventArgs e)
        {
            pictureBox2.Refresh();
        }
        /// <summary>
        /// Рисует дерево после проверки параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            // Преобразование из string в double/
            if (!double.TryParse(textBox5.Text, out treeRatio))
            {
                return;
            }
            // Проверка на правильность Данных.
            if (treeRatio < 1.3 || treeRatio > 3)
            {
                MessageBox.Show("Отношение должно быть от 1,3 до 3 включительно, введите значение еще раз!");
                return;
            }
            ShowMainScreen(false);
            ShowButtonsForTree(false);
            flagForTree = false;
            pictureBox2.Refresh();
        }
        /// <summary>
        /// Показатель выбраного значение на трек баре.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }
        /// <summary>
        /// Показатель выбраного значение на трек баре.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
        }
        /// <summary>
        /// Показатель выбраного значение на трек баре.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            textBox4.Text = trackBar3.Value.ToString();
        }
        /// <summary>
        /// Показатель выбраного значение на трек баре.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar4.Value.ToString();
        }
        /// <summary>
        /// Рисует кривую Коха просле проверки параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            ShowMainScreen(false);
            ShowButtonsForKoch(false);
            flagForKoch = false;
            pictureBox2.Refresh();
        }
        /// <summary>
        /// Показатель выбраного значение на трек баре.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar5.Value.ToString();
        }
        /// <summary>
        /// Рисует ковер Серпинского после ввода параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            ShowMainScreen(false);
            ShowButtonsForCarpetAndTriangle(false);
            flagForCarpetAndTriangle = false;
            pictureBox2.Refresh();
        }
        /// <summary>
        /// Рисует множество Кантера после ввода параметров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            ShowMainScreen(false);
            ShowButtonsForCantor(false);
            flagForCantor = false;
            pictureBox2.Refresh();

        }
        /// <summary>
        /// Показатель выбраного значение на трек баре.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            textBox3.Text = trackBar6.Value.ToString();
        }
        /// <summary>
        /// Показывает помощь.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" +
                "\tДля дерева:\n" +
                "Сначала ввод правого угла\n" +
               "Потом ввод левого угла\n" +
               "Потом ввод количества итераций\n" +
               "Потом ввод во сколько раз следующий кусок меньше предыдущего\n" +
               "(число от 1,3 до 3, вместо точки вводить запятую!)\n" +
               "\tДля Коха, ковра и треугольника Серпинского:\n" +
               "Количество итераций\n" +
               "\tДля Кантора:\n" +
               "Количество итераций и второе - расстояние между ними");
        }
        /// <summary>
        /// Делает скриншот.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    Size size = new Size(pictureBox2.Width, pictureBox2.Height - 100);
                    Bitmap img = new Bitmap(pictureBox2.Width, pictureBox2.Height - 100);
                    using (Graphics g = Graphics.FromImage(img))
                    {
                        g.CopyFromScreen(new Point(0, 100), Point.Empty, size);
                    }
                    img.Save("img.png");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить, возникла ошибка: {ex.Message}");
            }
        }
    }
}