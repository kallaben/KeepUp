using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CircleGame
{
    class TestForm : Form
    {
        private PictureBox pictureBox1 = new PictureBox();
        private PlayerDot playerDot = new PlayerDot(100);
        private Circle circle = new Circle(100);

        public TestForm()
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(inputHandler);

            this.Width = 500;
            this.Height = 500;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
            pictureBox1.Paint += new PaintEventHandler(this.updateGraphics);
            this.Load += new EventHandler(this.TestForm_Load);
            this.Controls.Add(pictureBox1);
        }

        private void inputHandler(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Input Detected");
            /*if (e.KeyChar == 37)
            {
                playerDot.MoveCounterClockwise(0.3);
            }
            else if (e.KeyChar == 39)
            {
                playerDot.MoveClockwise(0.3);
            }
            */
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            int refreshRate = 1000 / 60;
            setupGameLoop(refreshRate);
        }

        private void setupGameLoop(int msRefreshRate)
        { 
            Timer timer = new Timer();
            timer.Interval = (msRefreshRate);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void updateGraphics(object sender, PaintEventArgs e)
        {
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
            drawCircle(e);
        }

        private void drawCircle(PaintEventArgs e)
        { 
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));

            e.Graphics.DrawEllipse(pen,
                this.Width / 2 - circle.GetRadius(),
                this.Height / 2 - circle.GetRadius(),
                circle.GetDiameter(),
                circle.GetDiameter());

            var pdPos = playerDot.GetPosition();
            e.Graphics.DrawEllipse(pen,
                this.Width / 2 - circle.GetRadius() - 5 + pdPos.X,
                this.Height / 2 - circle.GetRadius() - 5 + pdPos.Y,
                10, 10);
        }
    }
}
