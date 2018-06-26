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

            Console.WriteLine(playerDot.GetPosition());

            playerDot.MoveClockwise(Math.PI);

            Console.WriteLine(playerDot.GetPosition());

            Point expectedPosition = new Point(200, 400);
            Assert.AreEqual(expectedPosition, playerDot.GetPosition());
        }

        [TestMethod]
        public void MoveCounterClockwisePI()
        {
            PlayerDot playerDot = new PlayerDot(200);

            Console.WriteLine(playerDot.GetPosition());

            playerDot.MoveCounterClockwise(Math.PI);

            Console.WriteLine(playerDot.GetPosition());

            Point expectedPosition = new Point(200, 400);
            Assert.AreEqual(expectedPosition, playerDot.GetPosition());
        }
    }
}
