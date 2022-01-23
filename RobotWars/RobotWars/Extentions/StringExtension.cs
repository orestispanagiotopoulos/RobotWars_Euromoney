using RobotWars.Model.Enums;
using System;

namespace RobotWars.Extentions
{
    public static class StringExtension
    {
        public static Direction GetDirection(this string direction)
        {
            Direction directionEnum;
            Enum.TryParse(direction, out directionEnum);

            return directionEnum;
        }

        public static MoveTo GetMove(this string move)
        {
            MoveTo moveEnum;
            Enum.TryParse(move, out moveEnum);

            return moveEnum;
        }
    }
}
