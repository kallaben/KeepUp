using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGame
{
    class ArcMover
    {
        private double speed;
        private double interval = 0.01;
        private double counter;

        public double getSpeed()
        {
            calculateSpeed();
            return 0.02 * speed;
        }

        private void calculateSpeed()
        {
            speed = Math.Cos(counter);
            counter += interval;
            if (counter > 2 * Math.PI)
            {
                counter = 0;
            }
        }
    }
}
