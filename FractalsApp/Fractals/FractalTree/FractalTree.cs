using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FractalsApp.Fractals.FractalTree
{
    /// <summary>
    /// Definition of Fractal tree
    /// </summary>
    public class FractalTree : Fractal
    {
        // Constants
        private const int MaxSize = 15;
        private const FractalEnum FractalType = FractalEnum.FractalTree;

        // Variables
        Graphics g;
        private int firstStepLength;
        private int firstAngle;
        private int secondAngle;
        private double ratio;
        private int size;

        /// <summary>
        /// Fractal tree constructor
        /// </summary>
        public FractalTree(
            PaintEventArgs e, 
            int panelWidht, 
            int panelHeight,
            int firstStepLength, 
            int firstAngle, 
            int secondAngle, 
            double ratio, 
            int size
            ) : base(e, panelWidht, panelHeight)
        {
            g = e.Graphics;
            this.firstStepLength = firstStepLength;
            this.firstAngle = firstAngle;
            this.secondAngle = secondAngle;
            this.ratio = ratio;
            this.size = size;

        }
        /// <summary>
        /// Recursive draw
        /// </summary>
        /// <param name="x">Left X coordinate</param>
        /// <param name="y">Left Y coordinate</param>
        /// <param name="length">Line length</param>
        /// <param name="angle">Current angle</param>
        /// <param name="currentSize">Current iteration</param>
        private void DrawTree(int x, int y, int length, int angle, PaintEventArgs e, int currentSize)
        {
            // Gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, panelWidht, panelHeight),
                Color.Purple,
                Color.Red,
                LinearGradientMode.ForwardDiagonal
                ))
            {
                brush.InterpolationColors = CreateColorBlend();
                using (Pen pen = new Pen(brush, 2))
                {
                    double x1, y1;
                    // Find the next point
                    x1 = x + length * Math.Sin(angle * Math.PI * 2 / 360.0);
                    y1 = y + length * Math.Cos(angle * Math.PI * 2 / 360.0);
                    // Draw the line
                    g.DrawLine(pen, x, panelHeight - y, (int)x1, panelHeight - (int)y1);
                    if (currentSize < size && currentSize < MaxSize)
                    {
                        // Recursively call draw for two child leaves
                        DrawTree((int)x1, (int)y1, (int)(length / ratio), angle + firstAngle, e, currentSize + 1);
                        DrawTree((int)x1, (int)y1, (int)(length / ratio), angle - secondAngle, e, currentSize + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Create gradient
        /// </summary>
        private ColorBlend CreateColorBlend()
        {
            // Create a color blend with multiple colors
            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Colors = new Color[] { Color.Purple, Color.BlueViolet, Color.Orange, Color.Red };
            colorBlend.Positions = new float[] { 0.0f, 0.3f, 0.6f, 1.0f };

            return colorBlend;
        }

        /// <summary>
        /// Draw the fractal
        /// </summary>
        public override void Draw()
        {
            try
            {
                DrawTree(panelWidht / 2, 0, firstStepLength, 0, e, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured: {ex.Message}");
            }
        }
    }
}
