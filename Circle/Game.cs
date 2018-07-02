using System;
using System.Drawing;
using System.Windows.Forms;

namespace CircleGame
{
    public class Game : Form
    {
        private PictureBox canvas = new PictureBox();
        private Circle circle = new Circle(100);
        private ArcMover arcMover = new ArcMover();
        private PlayerPhysics playerPhysics = new PlayerPhysics();
        private Timer timer = new Timer();
        private CircleDrawer circleDrawer;
        
        public Game(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            circleDrawer = new CircleDrawer(circle);

            setupInputListeners();
            setupCanvas();

            this.Load += new EventHandler(this.OnLoad);
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

        private void OnLoad(object sender, EventArgs e)
        {
            int refreshRate = 1000 / 60;
            setupGameLoop(refreshRate);
        }

        private void setupGameLoop(int msRefreshRate)
        {
            timer.Interval = (msRefreshRate);
            timer.Tick += new EventHandler(timer_Tick);
        }

        // Gets called every tick
        private void timer_Tick(object sender, EventArgs e)
        {
            this.Refresh(); // Will call updateGraphics()
            this.UpdateGameLogic();
        }

        private void updateGraphics(object sender, PaintEventArgs e)
        {
            canvas.Width = this.Width;
            canvas.Height = this.Height;
            circleDrawer.DrawCircle(e, this.Width, this.Height);
        }

        private void UpdateGameLogic()
        {
            // Moving the arc
            circle.GetArc().MoveClockwise(arcMover.getSpeed());

            // Moving the player
            playerPhysics.CalculateVelocityThisTick();
            circle.GetPlayerDot().MoveCounterClockwise(playerPhysics.GetVelocity());

            // Collision detection
            if (!(CollisionDetector.AreColliding(circle.GetPlayerDot(), circle.GetArc())))
            {
                resetGame();
            }
        }

        private void resetGame()
        {
            circle = new Circle(100);
            arcMover = new ArcMover();
            playerPhysics = new PlayerPhysics();
            circleDrawer = new CircleDrawer(circle);
            timer.Stop();
            this.Refresh();
        }

        private void inputDownHandler(object sender, KeyEventArgs e)
        {
            timer.Start();
            switch (e.KeyCode)
            {
                case Keys.Left:
                    playerPhysics.AccelerateLeft();
                    break;
                case Keys.Right:
                    playerPhysics.AccelerateRight();
                    break;
                case Keys.ShiftKey:
                    playerPhysics.ResetVelocity();
                    break;
            }
        }

        private void inputUpHandler(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    playerPhysics.StopAccelerateLeft();
                    break;
                case Keys.Right:
                    playerPhysics.StopAccelerateRight();
                    break;
            }
        }
    }
}
