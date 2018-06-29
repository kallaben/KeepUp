using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CircleGame;

namespace CircleTest
{
    [TestClass]
    public class PlayerPhysicsTest
    {
        [TestMethod]
        public void Tick7Left2Right()
        {
            PlayerPhysics playerPhysics = new PlayerPhysics();
            var acceleration = playerPhysics.GetAcceleration();
            var resistance = playerPhysics.GetResistance();
            double expectedVelocity;

            playerPhysics.AccelerateLeft();
            playerPhysics.CalculateVelocityThisTick();
            expectedVelocity = acceleration - resistance;
            playerPhysics.CalculateVelocityThisTick();
            expectedVelocity += acceleration - resistance;
            playerPhysics.CalculateVelocityThisTick();
            expectedVelocity += acceleration - resistance;
            playerPhysics.CalculateVelocityThisTick();
            expectedVelocity += acceleration - resistance;
            playerPhysics.CalculateVelocityThisTick();
            expectedVelocity += acceleration - resistance;
            playerPhysics.CalculateVelocityThisTick();
            expectedVelocity += acceleration - resistance;
            playerPhysics.CalculateVelocityThisTick();
            expectedVelocity += acceleration - resistance;
            playerPhysics.StopAccelerateLeft();

            playerPhysics.AccelerateRight();
            playerPhysics.CalculateVelocityThisTick();
            expectedVelocity += -acceleration - resistance;
            playerPhysics.CalculateVelocityThisTick();
            expectedVelocity += -acceleration - resistance;

            Assert.AreEqual(expectedVelocity, playerPhysics.GetVelocity());

        }

        [TestMethod]
        public void StopsWhenNoAcceleration()
        {
            PlayerPhysics playerPhysics = new PlayerPhysics();

            playerPhysics.AccelerateLeft();
            playerPhysics.CalculateVelocityThisTick();
            playerPhysics.CalculateVelocityThisTick();

            playerPhysics.StopAccelerateLeft();
            playerPhysics.CalculateVelocityThisTick();
            playerPhysics.CalculateVelocityThisTick();
            playerPhysics.CalculateVelocityThisTick();
            playerPhysics.CalculateVelocityThisTick();
            playerPhysics.CalculateVelocityThisTick();
            playerPhysics.CalculateVelocityThisTick();
            playerPhysics.CalculateVelocityThisTick();

            Assert.AreEqual(0, playerPhysics.GetVelocity());
        }
    }
}
