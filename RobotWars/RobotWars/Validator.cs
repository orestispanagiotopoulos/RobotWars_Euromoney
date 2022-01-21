using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotWars
{
    public class Validator : IValidator
    {
        public (List<string> errors, int initX, int initY, string direction) ValidateInitialState(string initialPosition, int gridHeight, int gridWidth)
        {
            // _validator.ValidateInitialState
            var result = (new List<string>(), -1, -1, string.Empty);
            // var result = new Tuple<List<string>, int, int, string>(new List<string>(), -1, -1, string.Empty);

            var initialPositionArray = initialPosition.Split(',');

            if (initialPositionArray.Length != 3)
            {
                result.Item1.Add("Input is invalid. There should be 2 co-ordinates (x and y) and initial direction");
                return result;
            }

            int x, y;
            if (!int.TryParse(initialPositionArray[0].Trim(), out x))
            {
                result.Item1.Add("The intial X position of the robot is invalid. The X should be an integer.");
            }

            if (!int.TryParse(initialPositionArray[1].Trim(), out y))
            {
                result.Item1.Add("The intial Y position of the robot is invalid. The Y should be an integer.");
            }

            var intialDirection = initialPositionArray[2].Trim();
            if (intialDirection != "N" && intialDirection != "E" && intialDirection != "S" && intialDirection != "W")
            {
                result.Item1.Add("The intial direction of the robot is invalid. The direction should one of the following char: N, E, S, W");
            }
            result.Item4 = intialDirection;

            if( x < 0 || x > gridHeight - 1)
            {
                result.Item1.Add($"The intial X position of the robot is invalid because it is outside of the grid. The Height of the grid is: {gridHeight}");
            }
            result.Item2 = x;

            if (y < 0 || y > gridWidth - 1)
            {
                result.Item1.Add($"The intial Y position of the robot is invalid because it is outside of the grid. The Width of the grid is: {gridWidth}");
            }
            result.Item3 = y;

            return result;
        }

        public List<string> ValidateMoves(string moves)
        {
            var validations = new List<string>();

            moves = moves.Trim();
            int tot = CountMoves(moves, 'M') + CountMoves(moves, 'L') + CountMoves(moves, 'R');
            if (tot != moves.Length)
            {
                validations.Add("Invalid characters in moves input.");
            }
            return validations;
        }

        private int CountMoves(string moves, char move)
        {
            return moves.ToUpper().Count(m => m == move);
        }
    }
}
