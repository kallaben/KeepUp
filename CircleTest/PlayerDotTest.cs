using System;
using System.Drawing;
using CircleGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircleTest
{
    [TestClass]
    public class PlayerDotTest
    {
        [TestMethod]
        public void StartingPos200Radius()
        {
            PlayerDot playerDot = new PlayerDot(200);

            Point expectedPosition = new Point(200, 0);

            Assert.AreEqual(expectedPosition, playerDot.GetPosition());
        }

        [TestMethod]
        public void MoveClockwisePI()
        {
            PlayerDot playerDot = new PlayerDot(200);

            playerDot.MoveClockwise(Math.PI);

            Point expectedPosition = new Point(200, 400);
            Assert.AreEqual(expectedPosition, playerDot.GetPosition());
        }

        [TestMethod]
        public void MoveCounterClockwisePI()
        {
            PlayerDot playerDot = new PlayerDot(200);

            playerDot.MoveCounterClockwise(Math.PI);

            Point expectedPosition = new Point(200, 400);
            Assert.AreEqual(expectedPosition, playerDot.GetPosition());
        }

        [TestMethod]
        public void MoveClockwiseGetRadian()
        {
            PlayerDot playerDot = new PlayerDot(200);
            double startRadian = playerDot.GetRadian();

            playerDot.MoveClockwise(1.2);

            double expectedRadian = startRadian - 1.2;
            Assert.AreEqual(expectedRadian, playerDot.GetRadian());
        }

        [TestMethod]
        public void MoveCounterClockwiseGetRadian()
        {
            PlayerDot playerDot = new PlayerDot(200);
            double startRadian = playerDot.GetRadian();

            playerDot.MoveCounterClockwise(0.6);

            double expectedRadian = startRadian + 0.6;
            Assert.AreEqual(expectedRadian, playerDot.GetRadian());
        }
    }
}
