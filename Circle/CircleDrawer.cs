using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CircleGame
{
    public class CircleDrawer
    {
        private Circle circle;
        private Pen circlePen = new Pen(Color.FromArgb(255, 0, 0, 0));
        private Brush playerBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
        private Pen arcPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5f);

        public CircleDrawer(Circle circle)
        {
            this.circle = circle;
        }

        public void DrawCircle(PaintEventArgs e, int width, int height)
        {
            drawEllipse(e, width, height);
            drawArc(e, width, height);
            drawPlayerDot(e, width, height);
        }

        private void drawEllipse(PaintEventArgs e, int width, int height)
        {
            e.Graphics.DrawEllipse(circlePen,
                width / 2 - circle.GetRadius(),
                height / 2 - circle.GetRadius(),
                circle.GetDiameter(),
                circle.GetDiameter());
        }

        private void drawPlayerDot(PaintEventArgs e, int width, int height)
        {
            var pdPos = circle.GetPlayerDot().GetPosition();
            e.Graphics.FillEllipse(playerBrush,
                width / 2 - circle.GetRadius() - 5 + pdPos.X,
                height / 2 - circle.GetRadius() - 5 + pdPos.Y,
                10, 10);
        }

        private void drawArc(PaintEventArgs e, int width, int height)
        {
            CircleArc arc = circle.GetArc();
            float startRadian = (float)arc.GetRadianInterval().Item1;
            float radianWidth = (float)arc.GetArcWidth();

            e.Graphics.DrawArc(arcPen,
                    new Rectangle(
                        width / 2 - circle.GetRadius(),
                        height / 2 - circle.GetRadius(),
                        circle.GetDiameter(),
                        circle.GetDiameter()
                    ),
                    360 - (float)(startRadian) * 180f / (float)Math.PI,
                    (float)(radianWidth) * 180f / (float)Math.PI
                );
        }
    }
}
