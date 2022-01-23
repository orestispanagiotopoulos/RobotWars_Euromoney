using NUnit.Framework;

namespace RobotWars.Test
{
    public class ValidatorTest
    {
        private IValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new Validator();
        }

        [Test]
        public void ValidateInitialState_WhenInvalidInitialPosition1_FailValidation()
        {
            // Arrange

            var initialPositin = "1, 2, 3, 4";

            // Act
            var resut = _validator.ValidateInitialState(initialPositin, 5, 5);

            // Assert
            Assert.AreEqual(1, resut.errors.Count);
            Assert.AreEqual("Input is invalid. Three values are expected separated by comma: Two co-ordinates (x and y) and one initial direction", resut.errors[0]);
        }

        [Test]
        public void ValidateInitialState_WhenInvalidInitialPosition2_FailValidation()
        {
            // Arrange

            var initialPositin = "A, 2, E";

            // Act
            var resut = _validator.ValidateInitialState(initialPositin, 5, 5);

            // Assert
            Assert.AreEqual(1, resut.errors.Count);
            Assert.AreEqual("The intial X position of the robot is invalid. The X should be an integer.", resut.errors[0]);
        }

        [Test]
        public void ValidateInitialState_WhenInvalidInitialPosition3_FailValidation()
        {
            // Arrange

            var initialPositin = "1, D, E";

            // Act
            var resut = _validator.ValidateInitialState(initialPositin, 5, 5);

            // Assert
            Assert.AreEqual(1, resut.errors.Count);
            Assert.AreEqual("The intial Y position of the robot is invalid. The Y should be an integer.", resut.errors[0]);
        }

        [Test]
        public void ValidateInitialState_WhenInvalidInitialPosition4_FailValidation()
        {
            // Arrange

            var initialPositin = "1, 2, Hello";

            // Act
            var resut = _validator.ValidateInitialState(initialPositin, 5, 5);

            // Assert
            Assert.AreEqual(1, resut.errors.Count);
            Assert.AreEqual("The intial direction of the robot is invalid. The direction should be one of the following char: N, E, S, W", resut.errors[0]);
        }

        [Test]
        public void ValidateInitialState_WhenInvalidInitialPosition5_FailValidation()
        {
            // Arrange

            var initialPositin = "100, 2, E";
            var gridHeight = 5;
            var gridWidth = 5;

            // Act
            var resut = _validator.ValidateInitialState(initialPositin, gridHeight, gridWidth);

            // Assert
            Assert.AreEqual(1, resut.errors.Count);
            Assert.AreEqual($"The intial X position of the robot is invalid because it is outside of the grid. The Height of the grid is: {gridHeight}", resut.errors[0]);
        }

        [Test]
        public void ValidateInitialState_WhenInvalidInitialPosition6_FailValidation()
        {
            // Arrange

            var initialPositin = "2, 100, E";
            var gridHeight = 5;
            var gridWidth = 5;

            // Act
            var resut = _validator.ValidateInitialState(initialPositin, gridHeight, gridWidth);

            // Assert
            Assert.AreEqual(1, resut.errors.Count);
            Assert.AreEqual($"The intial Y position of the robot is invalid because it is outside of the grid. The Width of the grid is: {gridWidth}", resut.errors[0]);
        }

        [Test]
        public void ValidateInitialState_WhenValidPosition_PassValidation()
        {
            // Arrange

            var initialPositin = "2, 3, E";
            var gridHeight = 5;
            var gridWidth = 5;

            // Act
            var resut = _validator.ValidateInitialState(initialPositin, gridHeight, gridWidth);

            // Assert
            Assert.AreEqual(0, resut.errors.Count);
            Assert.AreEqual(2, resut.initX);
            Assert.AreEqual(3, resut.initY);
            Assert.AreEqual("E", resut.direction);
        }

        [Test]
        public void ValidateInitialState_WhenInvalidMoves_FailValidation()
        {
            // Arrange

            var moves = "THIS IN INVALID";

            // Act
            var resut = _validator.ValidateMoves(moves);

            // Assert
            Assert.AreEqual(1, resut.Count);
            Assert.AreEqual("There are Invalid characters in moves input.", resut[0]);
        }

        [Test]
        public void ValidateInitialState_WhenValidMoves1_PassValidation()
        {
            // Arrange

            var moves = "MLMLMLM RMRMRMRM";

            // Act
            var resut = _validator.ValidateMoves(moves);

            // Assert
            Assert.AreEqual(0, resut.Count);
        }

        [Test]
        public void ValidateInitialState_WhenValidMoves2_PassValidation()
        {
            // Arrange

            var moves = "MLMLMLMRMRMRMRM";

            // Act
            var resut = _validator.ValidateMoves(moves);

            // Assert
            Assert.AreEqual(0, resut.Count);
        }

        [Test]
        public void ValidateInitialState_WhenValidMoves3_PassValidation()
        {
            // Arrange

            var moves = "";

            // Act
            var resut = _validator.ValidateMoves(moves);

            // Assert
            Assert.AreEqual(0, resut.Count);
        }
    }
}
