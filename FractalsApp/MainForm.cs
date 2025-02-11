using FractalsApp.Fractals;
using System.Windows.Forms;

namespace FractalsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetupUI();
        }

        /// <summary>
        /// Set up the UI
        /// </summary>
        private void SetupUI()
        {
            listBox.Items.Clear();
            listBox.Items.Add("Fractal Tree");
            listBox.Items.Add("Your ad here");

            // Default fractal
            drawFractal(FractalEnum.FractalTree);
        }

        /// <summary>
        /// Chooses which fractal to draw
        /// </summary>
        /// <param name="fractalType">Type of the fractal the user wants to draw</param>
        private void drawFractal(FractalEnum fractalType)
        {
            if (fractalType == FractalEnum.KochCurve)
            {
                // TODO: add more fractal variations
            }
            // Default fractal is Fractal Tree
            else
            {
                FractalTreeView fractalView = new FractalTreeView();
                panel1.Controls.Add(fractalView);
                fractalView.Dock = DockStyle.Fill;
            }
        }
    }
}
