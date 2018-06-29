using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CircleGame
{
    public class Circle
    {
        private int radius;
        private PlayerDot playerDot;
        private CircleArc circleArc;

        public Circle(int radius)
        {
            this.radius = radius;
            playerDot = new PlayerDot(radius);
            circleArc = new CircleArc(0.5, Math.PI / 2);
        }

        public int GetDiameter()
        {
            return radius * 2;
        }

        public int GetRadius()
        {
            return radius;
        }

        public PlayerDot GetPlayerDot()
        {
            return playerDot;
        }

        public CircleArc GetArc()
        {
            return circleArc;
        }
    }
}
