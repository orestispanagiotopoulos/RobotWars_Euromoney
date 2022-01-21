using NUnit.Framework;
using RobotWars.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWars.Test
{
    public class ManagerTest
    {
        [Test]
        public void ExecuteRobotMoves_When_Senario2_Success()
        {
            // Arrange
            var manager = new Manager(new Validator());

            // Act
            var result = manager.ExecuteRobotMoves(4, 4, "S", "LMLLMMLMMMRMM");

            // Assert
            Assert.AreEqual(0, result.Position.X);
            Assert.AreEqual(1, result.Position.Y);
            Assert.AreEqual(Direction.W, result.Direction);
            Assert.AreEqual(1, result.PenaltyCount);
        }
    }
}
