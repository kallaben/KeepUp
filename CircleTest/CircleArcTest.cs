using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CircleGame;

namespace CircleTest
{
    [TestClass]
    public class CircleArcTest
    {
        [TestMethod]
        public void BeginsAtTopOfCircle()
        {
            CircleArc arc = new CircleArc(0, Math.PI / 2);

            Assert.AreEqual(Math.PI / 2, arc.GetRadianInterval().Item1);
            Assert.AreEqual(Math.PI / 2, arc.GetRadianInterval().Item2);
        }

        [TestMethod]
        public void TopOfCirclePiWidth()
        {
            CircleArc arc = new CircleArc(Math.PI, Math.PI / 2);

            Assert.AreEqual(Math.PI, arc.GetRadianInterval().Item1);
            Assert.AreEqual(0, arc.GetRadianInterval().Item2);
        }

        [TestMethod]
        public void GetWidth()
        {
            double width = 2;
            CircleArc arc = new CircleArc(width, Math.PI / 2);

            Assert.AreEqual(width, arc.GetArcWidth());
        }

        [TestMethod]
        public void MoveClockwisePI()
        {
            CircleArc arc = new CircleArc(Math.PI / 2, Math.PI / 2);
            double pi = Math.PI;
            double startRadian = 2 * pi + (pi / 2 + (pi / 2) / 2) - pi;
            double endRadian = 2 * pi + (pi / 2 - (pi / 2) / 2) - pi;

            arc.MoveClockwise(Math.PI);

            Assert.AreEqual(startRadian, arc.GetRadianInterval().Item1, 0.01);
            Assert.AreEqual(endRadian, arc.GetRadianInterval().Item2, 0.01);
        }

        [TestMethod]
        public void MoveCounterClockwisePI()
        {
            CircleArc arc = new CircleArc(Math.PI / 2, Math.PI / 2);
            double pi = Math.PI;
            double startRadian = (pi / 2 + (pi / 2) / 2) + pi;
            double endRadian = (pi / 2 - (pi / 2) / 2) + pi;

            arc.MoveCounterClockwise(Math.PI);

            Assert.AreEqual(startRadian, arc.GetRadianInterval().Item1, 0.01);
            Assert.AreEqual(endRadian, arc.GetRadianInterval().Item2, 0.01);
        }

        [TestMethod]
        public void MoveClockwise5PI()
        {
            CircleArc arc = new CircleArc(Math.PI / 2, Math.PI / 2);
            double pi = Math.PI;
            double startRadian = 2 * pi + (pi / 2 + (pi / 2) / 2) - pi;
            double endRadian = 2 * pi + (pi / 2 - (pi / 2) / 2) - pi;

            arc.MoveClockwise(Math.PI * 5);

            Assert.AreEqual(startRadian, arc.GetRadianInterval().Item1, 0.01);
            Assert.AreEqual(endRadian, arc.GetRadianInterval().Item2, 0.01);
        }

        [TestMethod]
        public void MoveCounterClockwise5PI()
        {
            CircleArc arc = new CircleArc(Math.PI / 2, Math.PI / 2);
            double pi = Math.PI;
            double startRadian = (pi / 2 + (pi / 2) / 2) + pi;
            double endRadian = (pi / 2 - (pi / 2) / 2) + pi;

            arc.MoveCounterClockwise(Math.PI * 5);

            Assert.AreEqual(startRadian, arc.GetRadianInterval().Item1, 0.01);
            Assert.AreEqual(endRadian, arc.GetRadianInterval().Item2, 0.01);
        }
    }
}
