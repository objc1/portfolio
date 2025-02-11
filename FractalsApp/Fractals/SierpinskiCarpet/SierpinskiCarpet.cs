using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FractalsApp.Fractals;

namespace FractalsApp.Fractals.SierpinskiCarpet
{
    public class SierpinskiCarpet : Fractal
    {
        private const int MaxSize = 7;
        private int size;
        Graphics g;
        public SierpinskiCarpet(PaintEventArgs e, int panelWidht, int panelHeight, int size)
            : base(e, panelWidht, panelHeight)
        {
            g = e.Graphics;
            this.size = size;
        }
        private void DrawCarpet(int level, RectangleF rect)
        {
            // Посмотрим, остановимся ли мы.
            if (level == 0)
            {
                // Заполните прямоугольник.
                g.FillRectangle(Brushes.DarkOrange, rect);
            }
            else
            {
                // Разделим прямоугольник на 9 частей.
                float wid = rect.Width / 3f;
                float x0 = rect.Left;
                float x1 = x0 + wid;
                float x2 = x0 + wid * 2f;

                float hgt = rect.Height / 3f;
                float y0 = rect.Top;
                float y1 = y0 + hgt;
                float y2 = y0 + hgt * 2f;

                // Рекурсивно рисуем меньшие ковры.
                level -= 1;
                DrawCarpet(level, new RectangleF(x0, y0, wid, hgt));
                DrawCarpet(level, new RectangleF(x1, y0, wid, hgt));
                DrawCarpet(level, new RectangleF(x2, y0, wid, hgt));
                DrawCarpet(level, new RectangleF(x0, y1, wid, hgt));
                DrawCarpet(level, new RectangleF(x2, y1, wid, hgt));
                DrawCarpet(level, new RectangleF(x0, y2, wid, hgt));
                DrawCarpet(level, new RectangleF(x1, y2, wid, hgt));
                DrawCarpet(level, new RectangleF(x2, y2, wid, hgt));
            }
        }
        /// <summary>
        /// Вызов отрисовки фрактала.
        /// </summary>
        public override void Draw()
        {
            try
            {
                DrawCarpet(size, new RectangleF((panelWidht - (panelHeight - 200)) / 2,
                (panelHeight - (panelHeight - 200)) / 2,
                panelHeight - 200, panelHeight - 200));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex.Message}");
            }
        }
    }
}
