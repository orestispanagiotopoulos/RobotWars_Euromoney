using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWars
{
    public interface IValidator 
    {
        (List<string> errors, int initX, int initY, string direction) ValidateInitialState(string initialPosition, int gridHeight, int gridWidth);
        List<string> ValidateMoves(string moves);
    }
}
