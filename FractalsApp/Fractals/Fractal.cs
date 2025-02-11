using System.Windows.Forms;

namespace FractalsApp.Fractals
{
    /// <summary>
    /// Abstract class - determines all minimum necessary elemtn of a fractal
    /// </summary>
    public abstract class Fractal
    {
        protected PaintEventArgs e;
        protected int panelWidht;
        protected int panelHeight;

        public Fractal(PaintEventArgs e, int panelWidht, int panelHeight)
        {
            this.e = e;
            this.panelWidht = panelWidht;
            this.panelHeight = panelHeight;

        }
        /// <summary>
        /// Draws the fractal
        /// </summary>
        public virtual void Draw() { }
    }
}
