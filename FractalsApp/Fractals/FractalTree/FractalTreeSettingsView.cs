using System;
using System.Windows.Forms;

namespace FractalsApp.Fractals
{
    // Callback onPaint
    public delegate void DrawHandler();

    /// <summary>
    /// View with setting for fractal tree
    /// </summary>
    public partial class FractalTreeSettingsView : UserControl
    {
        // Variables
        public TrackBar GetLeftAngleTrackBar => trackBar4;
        public TrackBar GetRightAngleTrackBar => trackBar1;
        public TrackBar GetIterationsControl => trackBar5;
        public TrackBar GetRationControl => trackBar2;

        public DrawHandler drawHandler { get; set; }

        public FractalTreeSettingsView()
        {
            InitializeComponent();
            SetupUI();
        }

        /// <summary>
        /// Setup UI
        /// </summary>
        private void SetupUI()
        {
            // Default values
            trackBar5.Value = 8;
            trackBar4.Value = 45;
            trackBar1.Value = 45;
            trackBar2.Value = 15;

            // Update UI
            trackBar5_ValueChanged(null, null);
            trackBar4_ValueChanged(null, null);
            trackBar1_ValueChanged(null, null);
            trackBar2_ValueChanged(null, null);
        }

        private void drawFractalButton_Click(object sender, EventArgs e) => Redraw();

        /// <summary>
        /// Ggraohics update
        /// </summary>
        private void Redraw()
        {
            if (drawHandler is null)
                return;

            drawHandler();
        }

        /// <summary>
        /// Redraw the fractal on settings change
        /// </summary>
        private void trackBar5_ValueChanged(object sender, EventArgs e) 
        {
            textBox1.Text = trackBar5.Value.ToString();
            Redraw();
        }

        /// <summary>
        /// Redraw the fractal on settings change
        /// </summary>
        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = trackBar4.Value.ToString();
            Redraw();
        }
        /// <summary>
        /// Redraw the fractal on settings change
        /// </summary>

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = trackBar1.Value.ToString();
            Redraw();
        }

        /// <summary>
        /// Redraw the fractal on settings change
        /// </summary>
        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = (trackBar2.Value / 10.0).ToString();
            Redraw();
        }
    }
}
