using NUnit.Framework;
using RobotWars.Model;
using RobotWars.Model.Enums;

namespace RobotWars.Test.Model
{
    public class RobotTest
    {
        [Test]
        public void Move_WhenAllowedToMoveForward_ThenSuccesfullyMoveForward()
        {
            // Arrange
            var robot = new Robot(new RobotState 
            {
                Position =  new Point(0,0),
                Direction = Direction.N
            });

            // Act
            robot.Move(MoveTo.M, new Grid(5, 5));

            // Assert
            Assert.AreEqual(0, robot.RobotState.Position.X);
            Assert.AreEqual(1, robot.RobotState.Position.Y);
            Assert.AreEqual(Direction.N, robot.RobotState.Direction);
            Assert.AreEqual(0, robot.RobotState.PenaltyCount);
        }

        [Test]
        public void Move_WhenNotAllowedToMoveForward_ThenStayInTheSamePosition()
        {
            // Arrange
            var robot = new Robot(new RobotState
            {
                Position = new Point(0, 0),
                Direction = Direction.S
            });

            // Act
            robot.Move(MoveTo.M, new Grid(5, 5));

            // Assert
            Assert.AreEqual(0, robot.RobotState.Position.X);
            Assert.AreEqual(0, robot.RobotState.Position.Y);
            Assert.AreEqual(Direction.S, robot.RobotState.Direction);
            Assert.AreEqual(1, robot.RobotState.PenaltyCount);
        }

        [Test]
        public void Move_WhenCommandToTurningLeft_ThenTurnLeft()
        {
            // Arrange
            var robot = new Robot(new RobotState
            {
                Position = new Point(0, 0),
                Direction = Direction.N
            });

            // Act
            robot.Move(MoveTo.L, new Grid(5, 5));

            // Assert
            Assert.AreEqual(0, robot.RobotState.Position.X);
            Assert.AreEqual(0, robot.RobotState.Position.Y);
            Assert.AreEqual(Direction.W, robot.RobotState.Direction);
            Assert.AreEqual(0, robot.RobotState.PenaltyCount);
        }
    }
}
