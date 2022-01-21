using RobotWars.Model;
using System;
using System.Collections.Generic;

namespace RobotWars
{
    public class Manager
    {
        private const int GridHeight = 5;
        private const int GridWidth = 5;

        private readonly IValidator _validator;
        public Manager(IValidator vallidator)
        {
            _validator = vallidator;
        }

        public RobotState ExecuteRobotMoves(int intialX, int initialY, string initialDirection, string robotInstuctions)
        {
            var grid = new Grid(GridWidth, GridHeight); 
            var robot = InitialiseRobot(intialX, initialY, initialDirection);
            return ExecuteMoveInstructions(robotInstuctions, grid, robot);
        }

        public string GetRobotResult(int intialX, int initialY, string initialDirection, string robotInstuctions)
        {
            var robotState = ExecuteRobotMoves(intialX, initialY, initialDirection, robotInstuctions);
            var result = $"Position: {robotState.Position.X}, {robotState.Position.Y}, {robotState.Direction}, Penalties: {robotState.PenaltyCount}";
            return result;
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
            foreach (var move in moves)
            {
                Enum.TryParse(move.ToString(), out MoveTo moveToEnum);

                robot.Move(moveToEnum, grid);
            }
            return robot.RobotState;
        }

        private Robot InitialiseRobot(int intialX, int initialY, string direction)
        {
            Enum.TryParse(direction, out Direction directionEnum); 

            return new Robot(new RobotState
            {
                Position =  new Point(intialX, initialY),
                Direction = directionEnum
            });
        }
    }
}
