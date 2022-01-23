using System.Collections.Generic;

namespace RobotWars.Service
{
    public interface IValidator
    {
        (List<string> errors, int initX, int initY, string direction) ValidateInitialState(string initialPosition, int gridHeight, int gridWidth);
        List<string> ValidateMoves(string moves);
    }
}
