using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CircleGame;

namespace CircleTest
{
    [TestClass]
    public class CollisionDetectorTest
    {
        [TestMethod]
        public void AreColliding()
        {
            PlayerDot playerDot = new PlayerDot(200);
            CircleArc circleArc = new CircleArc(Math.PI / 2, Math.PI / 2);

            Assert.IsTrue(CollisionDetector.AreColliding(playerDot, circleArc));
            
        }

        [TestMethod]
        public void AreNotColliding()
        {
            PlayerDot playerDot = new PlayerDot(200);
            CircleArc circleArc = new CircleArc(Math.PI / 2, Math.PI * 3.2);

            Assert.IsFalse(CollisionDetector.AreColliding(playerDot, circleArc));
        }

        [TestMethod]
        public void AreCollidingAt0()
        {
            PlayerDot playerDot = new PlayerDot(200);
            playerDot.MoveClockwise(Math.PI / 2);
            CircleArc circleArc = new CircleArc(Math.PI / 2, 0);

            Assert.IsTrue(CollisionDetector.AreColliding(playerDot, circleArc));
        }

        [TestMethod]
        public void AreNotCollidingAt0()
        {
            PlayerDot playerDot = new PlayerDot(200);
            playerDot.MoveCounterClockwise(Math.PI / 2);
            CircleArc circleArc = new CircleArc(Math.PI / 2, 0);

            Assert.IsFalse(CollisionDetector.AreColliding(playerDot, circleArc));
        }

        [TestMethod]
        public void AreCollidingAtNear2Pi()
        {
            PlayerDot playerDot = new PlayerDot(200);
            playerDot.MoveCounterClockwise(Math.PI * 2.1);
            CircleArc circleArc = new CircleArc(0.5, Math.PI * 1.9);

            Assert.IsFalse(CollisionDetector.AreColliding(playerDot, circleArc));
        }
    }
}
