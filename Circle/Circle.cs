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

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public int GetDiameter()
        {
            return radius * 2;
        }

        public int GetRadius()
        {
            return radius;
        }
    }
}
