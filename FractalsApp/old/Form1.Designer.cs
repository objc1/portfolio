using System.Windows.Forms;

namespace FractalsApp
{
    partial class FractalsMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FractalsMainForm));
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            pictureBox2 = new PictureBox();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button9 = new Button();
            trackBar3 = new TrackBar();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            trackBar4 = new TrackBar();
            button10 = new Button();
            trackBar5 = new TrackBar();
            button11 = new Button();
            button12 = new Button();
            trackBar6 = new TrackBar();
            textBox3 = new TextBox();
            button13 = new Button();
            button14 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            button1.Location = new System.Drawing.Point(457, 399);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(269, 41);
            button1.TabIndex = 0;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button2.ForeColor = System.Drawing.SystemColors.HighlightText;
            button2.Location = new System.Drawing.Point(146, 399);
            button2.Margin = new Padding(2, 1, 2, 1);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(269, 41);
            button2.TabIndex = 1;
            button2.Text = "Info";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(241, 120);
            pictureBox1.Margin = new Padding(2, 1, 2, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(344, 54);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            button3.Location = new System.Drawing.Point(198, 200);
            button3.Margin = new Padding(2, 1, 2, 1);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(169, 22);
            button3.TabIndex = 3;
            button3.Text = "Fractal tree";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.None;
            button4.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            button4.Location = new System.Drawing.Point(198, 237);
            button4.Margin = new Padding(2, 1, 2, 1);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(169, 22);
            button4.TabIndex = 4;
            button4.Text = "Koch curve";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.None;
            button5.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            button5.Location = new System.Drawing.Point(198, 278);
            button5.Margin = new Padding(2, 1, 2, 1);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(169, 22);
            button5.TabIndex = 5;
            button5.Text = "Sierpinski carpet";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.None;
            button6.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            button6.Location = new System.Drawing.Point(198, 317);
            button6.Margin = new Padding(2, 1, 2, 1);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(169, 22);
            button6.TabIndex = 6;
            button6.Text = "Sierpinski triangle\r\n";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.None;
            button7.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            button7.Location = new System.Drawing.Point(198, 357);
            button7.Margin = new Padding(2, 1, 2, 1);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(169, 22);
            button7.TabIndex = 7;
            button7.Text = "Cantor set";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            button8.Location = new System.Drawing.Point(1, 0);
            button8.Margin = new Padding(2, 1, 2, 1);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(81, 22);
            button8.TabIndex = 0;
            button8.Text = "Menu";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Location = new System.Drawing.Point(0, 0);
            pictureBox2.Margin = new Padding(2, 1, 2, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(876, 562);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            pictureBox2.SizeChanged += pictureBox2_SizeChanged;
            pictureBox2.Paint += pictureBox2_Paint;
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.None;
            trackBar1.Location = new System.Drawing.Point(382, 179);
            trackBar1.Margin = new Padding(2, 1, 2, 1);
            trackBar1.Maximum = 90;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new System.Drawing.Size(269, 45);
            trackBar1.TabIndex = 9;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.Anchor = AnchorStyles.None;
            trackBar2.Location = new System.Drawing.Point(382, 229);
            trackBar2.Margin = new Padding(2, 1, 2, 1);
            trackBar2.Maximum = 90;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new System.Drawing.Size(269, 45);
            trackBar2.TabIndex = 10;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            textBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            textBox1.Location = new System.Drawing.Point(654, 179);
            textBox1.Margin = new Padding(2, 1, 2, 1);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(110, 23);
            textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.None;
            textBox2.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            textBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            textBox2.Location = new System.Drawing.Point(654, 229);
            textBox2.Margin = new Padding(2, 1, 2, 1);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(110, 23);
            textBox2.TabIndex = 12;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.None;
            button9.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            button9.Location = new System.Drawing.Point(543, 357);
            button9.Margin = new Padding(2, 1, 2, 1);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(108, 22);
            button9.TabIndex = 14;
            button9.Text = "Нарисовать";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // trackBar3
            // 
            trackBar3.Anchor = AnchorStyles.None;
            trackBar3.Location = new System.Drawing.Point(382, 278);
            trackBar3.Margin = new Padding(2, 1, 2, 1);
            trackBar3.Maximum = 15;
            trackBar3.Minimum = 1;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new System.Drawing.Size(269, 45);
            trackBar3.TabIndex = 15;
            trackBar3.Value = 1;
            trackBar3.Scroll += trackBar3_Scroll;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.None;
            textBox4.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            textBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            textBox4.Location = new System.Drawing.Point(655, 278);
            textBox4.Margin = new Padding(2, 1, 2, 1);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new System.Drawing.Size(110, 23);
            textBox4.TabIndex = 16;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.None;
            textBox5.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            textBox5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            textBox5.Location = new System.Drawing.Point(382, 330);
            textBox5.Margin = new Padding(2, 1, 2, 1);
            textBox5.Name = "textBox5";
            textBox5.Size = new System.Drawing.Size(271, 23);
            textBox5.TabIndex = 17;
            // 
            // trackBar4
            // 
            trackBar4.Anchor = AnchorStyles.None;
            trackBar4.Location = new System.Drawing.Point(382, 179);
            trackBar4.Margin = new Padding(2, 1, 2, 1);
            trackBar4.Maximum = 5;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new System.Drawing.Size(269, 45);
            trackBar4.TabIndex = 18;
            trackBar4.Value = 1;
            trackBar4.Scroll += trackBar4_Scroll;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.None;
            button10.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            button10.Location = new System.Drawing.Point(543, 229);
            button10.Margin = new Padding(2, 1, 2, 1);
            button10.Name = "button10";
            button10.Size = new System.Drawing.Size(108, 22);
            button10.TabIndex = 19;
            button10.Text = "Нарисовать";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // trackBar5
            // 
            trackBar5.Anchor = AnchorStyles.None;
            trackBar5.Location = new System.Drawing.Point(381, 224);
            trackBar5.Margin = new Padding(2, 1, 2, 1);
            trackBar5.Maximum = 7;
            trackBar5.Name = "trackBar5";
            trackBar5.Size = new System.Drawing.Size(269, 45);
            trackBar5.TabIndex = 20;
            trackBar5.Scroll += trackBar5_Scroll;
            // 
            // button11
            // 
            button11.Anchor = AnchorStyles.None;
            button11.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            button11.Location = new System.Drawing.Point(543, 274);
            button11.Margin = new Padding(2, 1, 2, 1);
            button11.Name = "button11";
            button11.Size = new System.Drawing.Size(107, 22);
            button11.TabIndex = 21;
            button11.Text = "Draw";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Anchor = AnchorStyles.None;
            button12.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            button12.Location = new System.Drawing.Point(543, 362);
            button12.Margin = new Padding(2, 1, 2, 1);
            button12.Name = "button12";
            button12.Size = new System.Drawing.Size(107, 22);
            button12.TabIndex = 22;
            button12.Text = "Draw";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // trackBar6
            // 
            trackBar6.Anchor = AnchorStyles.None;
            trackBar6.LargeChange = 10;
            trackBar6.Location = new System.Drawing.Point(382, 317);
            trackBar6.Margin = new Padding(2, 1, 2, 1);
            trackBar6.Maximum = 200;
            trackBar6.Minimum = 30;
            trackBar6.Name = "trackBar6";
            trackBar6.Size = new System.Drawing.Size(269, 45);
            trackBar6.SmallChange = 10;
            trackBar6.TabIndex = 23;
            trackBar6.Value = 30;
            trackBar6.Scroll += trackBar6_Scroll;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.None;
            textBox3.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            textBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            textBox3.Location = new System.Drawing.Point(655, 317);
            textBox3.Margin = new Padding(2, 1, 2, 1);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new System.Drawing.Size(110, 23);
            textBox3.TabIndex = 24;
            // 
            // button13
            // 
            button13.Anchor = AnchorStyles.None;
            button13.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            button13.Location = new System.Drawing.Point(457, 362);
            button13.Margin = new Padding(2, 1, 2, 1);
            button13.Name = "button13";
            button13.Size = new System.Drawing.Size(81, 22);
            button13.TabIndex = 25;
            button13.Text = "Help me";
            button13.UseVisualStyleBackColor = false;
            button13.Click += button13_Click;
            // 
            // button14
            // 
            button14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button14.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            button14.Location = new System.Drawing.Point(736, 0);
            button14.Margin = new Padding(2, 1, 2, 1);
            button14.Name = "button14";
            button14.Size = new System.Drawing.Size(141, 22);
            button14.TabIndex = 26;
            button14.Text = "Screenshot";
            button14.UseVisualStyleBackColor = false;
            button14.Click += button14_Click;
            // 
            // FractalsMainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(876, 562);
            Controls.Add(button14);
            Controls.Add(button13);
            Controls.Add(textBox3);
            Controls.Add(trackBar6);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(trackBar5);
            Controls.Add(button10);
            Controls.Add(trackBar4);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(trackBar3);
            Controls.Add(button9);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 1, 2, 1);
            Name = "FractalsMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fractals";
            WindowState = FormWindowState.Maximized;
            SizeChanged += FractalsMainForm_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private PictureBox pictureBox2;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button9;
        private TrackBar trackBar3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TrackBar trackBar4;
        private Button button10;
        private TrackBar trackBar5;
        private Button button11;
        private Button button12;
        private TrackBar trackBar6;
        private TextBox textBox3;
        private Button button13;
        private Button button14;
    }
}

