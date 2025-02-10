using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FractalsApp.Fractals;

namespace FractalsApp.Fractals.SierpinskiTriangle
{
    public class SierpinskiTriangle : Fractal
    {
        private const int MaxSize = 7;
        private int size;
        Graphics g;
        public SierpinskiTriangle(PaintEventArgs e, int panelWidht, int panelHeight, int size)
            : base(e, panelWidht, panelHeight)
        {
            g = e.Graphics;
            this.size = size;
        }
        private void DrawTriangle(int level, PointF top, PointF left, PointF right)
        {
            //проверяем, закончили ли мы построение
            if (level == 0)
            {
                PointF[] points = new PointF[3]
                {
                    top, right, left
                };
                //рисуем фиолетовый треугольник
                g.FillPolygon(Brushes.DarkOrange, points);
            }
            else
            {
                //вычисляем среднюю точку
                var leftMid = MidPoint(top, left); //левая сторона
                var rightMid = MidPoint(top, right); //правая сторона
                var topMid = MidPoint(left, right); // основание
                //рекурсивно вызываем функцию для каждого и 3 треугольников
                DrawTriangle(level - 1, top, leftMid, rightMid);
                DrawTriangle(level - 1, leftMid, left, topMid);
                DrawTriangle(level - 1, rightMid, topMid, right);
            }
        }
        /// <summary>
        /// Вычисление координат средней точки.
        /// </summary>
        /// <param name="p1"> Левая точка.</param>
        /// <param name="p2"> Правая точка.</param>
        /// <returns>Средняя точка.</returns>
        private PointF MidPoint(PointF p1, PointF p2)
        {
            return new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
        }
        /// <summary>
        /// Вызов отрисовки фрактала.
        /// </summary>
        public override void Draw()
        {
            try
            {
                DrawTriangle(size, new PointF(panelWidht / 2, 100),
                new PointF(400, panelHeight - 100),
                new PointF(panelWidht - 400, panelHeight - 100));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex.Message}");
            }
        }
    }
}
