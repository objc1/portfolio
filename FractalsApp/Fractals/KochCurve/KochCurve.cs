using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FractalsApp.Fractals;

namespace FractalsApp.Fractals.KochCurve
{
    public class KochCurve : Fractal
    {
        private const int MaxSize = 7;
        private int size;
        Graphics g;
        public KochCurve(PaintEventArgs e, int panelWidht, int panelHeight, int size)
            : base(e, panelWidht, panelHeight)
        {
            g = e.Graphics;
            this.size = size;
        }
        private void DrawKoch(ref int x, ref int y, int angle, int length, int n)
        {
            int x1, y1;
            x1 = x + (int)(length * Math.Cos(angle * Math.PI * 2 / 360.0));
            y1 = y + (int)(length * Math.Sin(angle * Math.PI * 2 / 360.0));
            if (n == 0)
            {
                g.DrawLine(new Pen(Color.White), x, panelHeight - y, x1, panelHeight - y1);
                x = x1;
                y = y1;
            }
            else
            {
                n--;
                length /= 3;
                // Отрисовываем следующие куски.
                DrawKoch(ref x, ref y, angle, length, n);
                angle += 60;
                DrawKoch(ref x, ref y, angle, length, n);
                angle -= 120;
                DrawKoch(ref x, ref y, angle, length, n);
                angle += 60;
                DrawKoch(ref x, ref y, angle, length, n);
            }
        }
        /// <summary>
        /// Вызов отрисовки фрактала.
        /// </summary>
        public override void Draw()
        {
            int num = 5;
            int length = (panelWidht - 150) * 1 / 7 * num;
            int m1 = (panelWidht - length) / 2;
            int m2 = panelHeight / 3;
            try
            {
                if (size < MaxSize)
                    DrawKoch(ref m1, ref m2, 0, length, size);
                else
                    DrawKoch(ref m1, ref m2, 0, length, MaxSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex.Message}");
            }
        }
    }
}
