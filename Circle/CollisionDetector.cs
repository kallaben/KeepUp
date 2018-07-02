using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleGame
{
    public static class CollisionDetector
    {
        public static bool AreColliding(PlayerDot playerDot, CircleArc circleArc)
        {
            double playerDotRadian = playerDot.GetRadian();
            double circleArcBeginRadian = circleArc.GetRadianInterval().Item1;
            double circleArcEndRadian = circleArc.GetRadianInterval().Item2;

            if (circleArcBeginRadian < circleArcEndRadian)
            {
                circleArcBeginRadian += 2 * Math.PI;
                if (playerDotRadian < circleArcEndRadian)
                {
                    playerDotRadian += 2 * Math.PI;
                }
            }

            return circleArcBeginRadian >= playerDotRadian && circleArcEndRadian <= playerDotRadian;
        }
    }
}
