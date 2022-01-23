using RobotWars.Extentions;
using RobotWars.Factory;
using RobotWars.Model;
using System.Collections.Generic;

namespace RobotWars
{
    public class Manager
    {
        private const int GridHeight = 5;
        private const int GridWidth = 5;

        private readonly IValidator _validator;
        private readonly IRobotFactory _robotFactory;
        public Manager(IValidator vallidator, IRobotFactory robotFactory)
        {
            _validator = vallidator;
            _robotFactory = robotFactory;
        }

        public string GetRobotResult(int intialX, int initialY, string initialDirection, string robotInstuctions)
        {
            var robotState = ExecuteRobotMoves(intialX, initialY, initialDirection, robotInstuctions);
            var result = $"The Robot's position is: {robotState.Position.X}, {robotState.Position.Y}, {robotState.Direction}, Penalties: {robotState.PenaltyCount}";
            return result;
        }

        public RobotState ExecuteRobotMoves(int intialX, int initialY, string initialDirection, string robotInstuctions)
        {
            var grid = new Grid(GridWidth, GridHeight); 
            var robot = _robotFactory.CreateRobot(intialX, initialY, initialDirection);
            return ExecuteMoveInstructions(robotInstuctions, grid, robot);
        }

        public (List<string> errors, int initX, int initY, string direction) ValidateInitialState(string startingPosition)
        {
            return _validator.ValidateInitialState(startingPosition, GridHeight, GridWidth);
        }

        public List<string> ValidateMoves(string startingPosition)
        {
            return _validator.ValidateMoves(startingPosition);
        }

        private RobotState ExecuteMoveInstructions(string moves, Grid grid, Robot robot)
        {
            moves.GetDirection();

            foreach (var move in moves)
            {
                // Allow empty spaces in moves because it is in the requirements (see scenario 3)
                if (move == ' ')
                {
                    continue;
                }

                robot.Move(move.ToString().ToUpper().GetMove(), grid);
            }
            return robot.RobotState;
        }
    }
}
