using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Circle
{
    class TestForm : Form
    {
        private PictureBox pictureBox1 = new PictureBox();

        public TestForm()
        {
            this.Width = 500;
            this.Height = 500;
            pictureBox1.Width = 200;
            pictureBox1.Height = 200;
            this.Controls.Add(pictureBox1);
            pictureBox1.Click += new EventHandler(pictureBox1Click);
        }

        private void pictureBox1Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello");
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            pictureBox1.CreateGraphics().DrawLine(pen, 20, 10, 300, 100);
        }
    }
}
