using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGame
{
    public class PlayerPhysics
    {
        private double resistance = 0.001;
        private double acceleration = 0.002;
        private double delta = 0.00005;
        private double velocity;
        private bool accelerateLeft;
        private bool accelerateRight;

        public double GetVelocity()
        {
            return velocity;
        }

        public void CalculateVelocityThisTick()
        {
            if (accelerateLeft)
            {
                velocity += acceleration;
            }
            if (accelerateRight)
            {
                velocity -= acceleration;
            }

            if (!(velocity < delta && velocity > -delta))
            {
                if (velocity < 0)
                {
                    velocity += resistance;
                }
                else
                {
                    velocity -= resistance;
                }
            }
        }

        public void AccelerateLeft()
        {
            accelerateLeft = true;
        }

        public void AccelerateRight()
        {
            accelerateRight = true;
        }

        public void StopAccelerateLeft()
        {
            accelerateLeft = false;
        }

        public void StopAccelerateRight()
        {
            accelerateRight = false;
        }

        public void ResetVelocity()
        {
            velocity = 0;
        }

        public double GetAcceleration()
        {
            return acceleration;
        }

        public double GetResistance()
        {
            return resistance;
        }
    }
}
