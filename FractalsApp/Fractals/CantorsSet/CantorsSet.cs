using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FractalsApp.Fractals;

namespace FractalsApp.Fractals.CantorsSet
{
    public class CantorsSet : Fractal
    {
        private const int MaxSize = 7;
        private int size;
        private int lengthBetweenLines;
        Graphics g;
        public CantorsSet(PaintEventArgs e, int panelWidht, int panelHeight, int size, int length)
            : base(e, panelWidht, panelHeight)
        {
            g = e.Graphics;
            this.size = size;
            lengthBetweenLines = length;
        }
        /// <summary>
        /// функция рекурсивного рисования.
        /// </summary>
        /// <param name="size"> Количество повторений</param>
        /// <param name="x"> Левая точка координата Х.</param>
        /// <param name="y"> Правая точка координата У.</param>
        /// <param name="length"> Длина линии.</param>
        private void DrawCantor(int size, int x, int y, int length)
        {
            if (size > 0)
            {
                Pen pen = new Pen(Color.White, 10);
                g.DrawLine(pen, x, y, x + length, y);
                length /= 3;
                size--;
                y += lengthBetweenLines;
                DrawCantor(size, x, y, length);
                DrawCantor(size, x + 2 * length, y, length);
            }
        }
        /// <summary>
        /// Вызов отрисовки фрактала.
        /// </summary>
        public override void Draw()
        {
            try
            {
                DrawCantor(size, 200, 200, panelWidht - 400);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex.Message}");
            }
        }
    }
}
