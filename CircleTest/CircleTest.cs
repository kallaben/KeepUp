using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CircleGame;

namespace CircleTest
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void GetDiameter200Radius()
        {
            Circle circle = new Circle(200);

            int diameter = 400;

            Assert.AreEqual(diameter, circle.GetDiameter());
        }

        [TestMethod]
        public void GetRadius200Radius()
        {
            Circle circle = new Circle(200);

            int radius = 200;

            Assert.AreEqual(radius, circle.GetRadius());
        }
    }
    }
