using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CircleGame
{
    class Game : Form
    {
        private PictureBox canvas = new PictureBox();
        private Circle circle = new Circle(100);
        private double playerSpeed = 0.05;
        private bool isLeftPressed;
        private bool isRightPressed;
        private ArcMover arcMover = new ArcMover();
        private PlayerPhysics playerPhysics = new PlayerPhysics();
        Timer timer = new Timer();

        public Game(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            setupInputListeners();
            setupCanvas();

            this.Load += new EventHandler(this.TestForm_Load);
        }

        private void setupInputListeners()
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(inputDownHandler);
            this.KeyUp += new KeyEventHandler(inputUpHandler);
        }

        private void setupCanvas()
        {
            canvas.Location = new Point(0, 0);
            canvas.Paint += new PaintEventHandler(this.updateGraphics);
            this.Controls.Add(canvas);
        }

        private void inputDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                playerPhysics.AccelerateLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                playerPhysics.AccelerateRight();
            }
        }

        private void inputUpHandler(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.Left)
            {
                playerPhysics.StopAccelerateLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                playerPhysics.StopAccelerateRight();
            }
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            int refreshRate = 1000 / 60;
            setupGameLoop(refreshRate);
        }

        private void setupGameLoop(int msRefreshRate)
        { 
            timer.Interval = (msRefreshRate);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        // Gets called every tick
        private void timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            this.UpdateGameLogic();
        }

        private void UpdateGameLogic()
        {
            double speed = arcMover.getSpeed();
            circle.GetArc().MoveClockwise(speed);

            playerPhysics.CalculateVelocityThisTick();
            circle.GetPlayerDot().MoveCounterClockwise(playerPhysics.GetVelocity());

            if (isLeftPressed)
            {
                circle.GetPlayerDot().MoveCounterClockwise(playerSpeed);
            }
            if (isRightPressed)
            {
                circle.GetPlayerDot().MoveClockwise(playerSpeed);
            }
        }

        private void updateGraphics(object sender, PaintEventArgs e)
        {
            canvas.Width = this.Width;
            canvas.Height = this.Height;
            drawCircle(e);
        }

        private void drawCircle(PaintEventArgs e)
        { 
            drawEllipse(e);
            drawPlayerDot(e);
            drawArc(e);
        }

        private void drawPlayerDot(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));

            var pdPos = circle.GetPlayerDot().GetPosition();
            e.Graphics.DrawEllipse(pen,
                this.Width / 2 - circle.GetRadius() - 5 + pdPos.X,
                this.Height / 2 - circle.GetRadius() - 5 + pdPos.Y,
                10, 10);
        }

        private void drawEllipse(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawEllipse(pen,
                this.Width / 2 - circle.GetRadius(),
                this.Height / 2 - circle.GetRadius(),
                circle.GetDiameter(),
                circle.GetDiameter());
        }

        private void drawArc(PaintEventArgs e)
        {
            CircleArc arc = circle.GetArc();
            float startRadian = (float)arc.GetRadianInterval().Item1;
            float radianWidth = (float)arc.GetArcWidth();

            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 5f);
            e.Graphics.DrawArc(pen,
                    new Rectangle(
                        this.Width / 2 - circle.GetRadius(),
                        this.Height / 2 - circle.GetRadius(),
                        circle.GetDiameter(),
                        circle.GetDiameter()
                    ),
                    360 - (float)(startRadian) * 180f / (float)Math.PI,
                    (float)(radianWidth) * 180f / (float)Math.PI
                );
        }
    }
}
