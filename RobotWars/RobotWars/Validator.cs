using System.Collections.Generic;
using System.Linq;

namespace RobotWars
{
    public class Validator : IValidator
    {
        public (List<string> errors, int initX, int initY, string direction) ValidateInitialState(string initialPosition, int gridHeight, int gridWidth)
        {
            var result = (new List<string>(), -1, -1, string.Empty);

            var initialPositionArray = initialPosition.Split(',');

            if (initialPositionArray.Length != 3)
            {
                result.Item1.Add("Input is invalid. Three values are expected separated by comma: Two co-ordinates (x and y) and one initial direction");
                return result;
            }

            int x, y;
            if (!int.TryParse(initialPositionArray[0].Trim(), out x))
            {
                result.Item1.Add("The intial X position of the robot is invalid. The X should be an integer.");
                return result;
            }

            if (!int.TryParse(initialPositionArray[1].Trim(), out y))
            {
                result.Item1.Add("The intial Y position of the robot is invalid. The Y should be an integer.");
                return result;
            }

            var intialDirection = initialPositionArray[2].Trim();
            if (intialDirection != "N" && intialDirection != "E" && intialDirection != "S" && intialDirection != "W")
            {
                result.Item1.Add("The intial direction of the robot is invalid. The direction should be one of the following char: N, E, S, W");
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
            // It is allowed to have empty spaces in moves string. They will be ignored
            int tot = CountChars(moves, 'L') + CountChars(moves, 'R') + CountChars(moves, 'M') + CountChars(moves, ' '); 
            if (tot != moves.Length)
            {
                validations.Add("There are Invalid characters in moves input.");
            }
            return validations;
        }

        private int CountChars(string moves, char move)
        {
            return moves.ToUpper().Count(m => m == move);
        }
    }
}
