using NUnit.Framework;
using RobotWars.Model.Enums;
using RobotWars.Service;
using RobotWars.Service.Factory;

namespace RobotWars.Test.Service
{
    public class ManagerTest
    {
        [Test]
        public void ExecuteRobotMoves_WhenScenario1_ThenCorrectOutput()
        {
            // Arrange
            var manager = new Manager(new Validator(), new RobotFactory());

            // Act
            var result = manager.ExecuteRobotMoves(0, 2, "E", "MLMRMMMRMMRR");

            // Assert
            Assert.AreEqual(4, result.Position.X);
            Assert.AreEqual(1, result.Position.Y);
            Assert.AreEqual(Direction.N, result.Direction);
            Assert.AreEqual(0, result.PenaltyCount);
        }

        [Test]
        public void ExecuteRobotMoves_WhenSenario2_ThenCorrectOutput()
        {
            // Arrange
            var manager = new Manager(new Validator(), new RobotFactory());

            // Act
            var result = manager.ExecuteRobotMoves(4, 4, "S", "LMLLMMLMMMRMM");

            // Assert
            Assert.AreEqual(0, result.Position.X);
            Assert.AreEqual(1, result.Position.Y);
            Assert.AreEqual(Direction.W, result.Direction);
            Assert.AreEqual(1, result.PenaltyCount);
        }

        [Test]
        public void ExecuteRobotMoves_WhenScenario3_ThenCorrectOutput()
        {
            // Arrange
            var manager = new Manager(new Validator(), new RobotFactory());

            // Act
            var result = manager.ExecuteRobotMoves(2, 2, "W", "MLMLMLM RMRMRMRM");

            // Assert
            Assert.AreEqual(2, result.Position.X);
            Assert.AreEqual(2, result.Position.Y);
            Assert.AreEqual(Direction.N, result.Direction);
            Assert.AreEqual(0, result.PenaltyCount);
        }

        [Test]
        public void ExecuteRobotMoves_WhenScenario4_ThenCorrectOutput()
        {
            // Arrange
            var manager = new Manager(new Validator(), new RobotFactory());

            // Act
            var result = manager.ExecuteRobotMoves(1, 3, "N", "MMLMMLMMMMM");

            // Assert
            Assert.AreEqual(0, result.Position.X);
            Assert.AreEqual(0, result.Position.Y);
            Assert.AreEqual(Direction.S, result.Direction);
            Assert.AreEqual(3, result.PenaltyCount);
        }

        [Test]
        public void ExecuteRobotMoves_WhenNoInstructions_ThenCorrectOutput()
        {
            // Arrange
            var manager = new Manager(new Validator(), new RobotFactory());

            // Act
            var result = manager.ExecuteRobotMoves(1, 3, "N", "");

            // Assert
            Assert.AreEqual(1, result.Position.X);
            Assert.AreEqual(3, result.Position.Y);
            Assert.AreEqual(Direction.N, result.Direction);
            Assert.AreEqual(0, result.PenaltyCount);
        }
    }
}
