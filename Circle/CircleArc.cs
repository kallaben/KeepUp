using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGame
{
    public class CircleArc
    {
        double leftRadian;
        double rightRadian;
        double middleRadian;
        double arcWidth;

        public CircleArc(double arcWidth, double middleRadian)
        {
            this.middleRadian = middleRadian;
            this.arcWidth = arcWidth;
            calculateRadians();
        }

        private void calculateRadians()
        {
            leftRadian = (middleRadian + arcWidth / 2) % (2 * Math.PI);
            rightRadian = (middleRadian - arcWidth / 2) % (2 * Math.PI);
        }

        public void MoveClockwise(double radians)
        {
            if (middleRadian - (radians % (2 * Math.PI)) <= 0)
            {
                this.middleRadian -= (radians % (2 * Math.PI)) - (Math.PI * 2);
            }
            else
            {
                this.middleRadian -= radians % (2 * Math.PI);
            }
            middleRadian = middleRadian % (2 * Math.PI);
            calculateRadians();
        }

        public void MoveCounterClockwise(double radians)
        {
            this.middleRadian += radians % (2 * Math.PI);
            middleRadian = middleRadian % (2 * Math.PI);
            calculateRadians();
        }

        public Tuple<double, double> GetRadianInterval()
        {
            return new Tuple<double, double>(leftRadian, rightRadian);
        }

        public double GetArcWidth()
        {
            return arcWidth;
        }
    }
}