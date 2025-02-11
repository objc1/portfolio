using FractalsApp.Fractals;
using FractalsApp.Fractals.FractalTree;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace FractalsApp
{
    /// <summary>
    /// Graphical interface for fractal tree
    /// </summary>
    public partial class FractalTreeView : UserControl
    {
        public FractalTreeView()
        {
            InitializeComponent();
            SetupUI();
        }

        /// <summary>
        /// Setup UI
        /// </summary>
        private void SetupUI()
        {
            // Add callback
            fractalTreeSettingsView1.drawHandler = () => pictureBox1.Refresh();
            // Configure picture box
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

        }

        /// <summary>
        /// Update the fractal
        /// </summary>
        private void Draw(PaintEventArgs e)
        {
            // Create a new fractal with new params
            Fractal newFrac = new FractalTree
            (
                e,
                pictureBox1.Width,
                pictureBox1.Height,
                pictureBox1.Height / 4,
                fractalTreeSettingsView1.GetRightAngleTrackBar.Value,
                fractalTreeSettingsView1.GetLeftAngleTrackBar.Value,
                fractalTreeSettingsView1.GetRationControl.Value / 10.0,
                fractalTreeSettingsView1.GetIterationsControl.Value
            );
            newFrac.Draw();
        }

        /// <summary>
        /// Handle UI update (called when the window is resized etc)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e);
        }
    }
}
