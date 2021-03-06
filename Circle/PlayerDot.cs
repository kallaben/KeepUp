﻿using System.Drawing;
using System;


namespace CircleGame
{
    public class PlayerDot
    {
        private Point position;
        private Point center;
        private int radius;
        private double radians;
        private double pi = Math.PI;

        public PlayerDot(int radius)
        {
            this.radius = radius;
            center = new Point(radius, radius);
            radians = pi / 2;
            position = new Point(
                Convert.ToInt32(center.X + radius*Math.Cos(radians)),
                Convert.ToInt32(center.Y - radius*Math.Sin(radians)));
        }

        public Point GetPosition()
        {
            return position;
        }

        public double GetRadian()
        {
            return radians;
        }

        public void MoveClockwise(double radians)
        {
            this.radians -= radians % (2*pi);
            if (this.radians < 0)
            {
                this.radians += 2 * Math.PI;
            }
            else if (this.radians > 2 * pi)
            {
                this.radians -= 2 * pi;
            }
            position.X = Convert.ToInt32(center.X + radius * Math.Cos(this.radians));
            position.Y = Convert.ToInt32(center.X - radius * Math.Sin(this.radians));
        }

        public void MoveCounterClockwise(double radians)
        {
            this.radians += radians % (2*pi);
            if (this.radians < 0)
            {
                this.radians += 2 * Math.PI;
            }
            else if (this.radians > 2*pi)
            {
                this.radians -= 2 * pi;
            }
            position.X = Convert.ToInt32(center.X + radius * Math.Cos(this.radians));
            position.Y = Convert.ToInt32(center.X - radius * Math.Sin(this.radians));
        }
    }
}