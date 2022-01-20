using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWars.Model
{
    public class Robot
    {
        public Robot(RobotState robotState)
        {
            RobotState = robotState;
        }
        public RobotState RobotState { get; set; }

        public void ExecuteMoveInstructions(string moves)
        {
            foreach (var move in moves)
            {
                ExecuteMove(move);
            }
        }

        private void ExecuteMove(char move)
        {
            switch (move)
            {
                case 'R':
                    TurnRight();
                    break;
                case 'L':
                    TurnLeft();
                    break;
                case 'M':
                    MoveForward();
                    break;
            }
        }

        public void TurnLeft()
        {
            var newPosition = new Point(this.RobotState.Position.X, this.RobotState.Position.Y);
            RoverState.RoverDirection = RoverState.RoverDirection == Direction.N ? Direction.W : RoverState.RoverDirection - 1;
            return RoverState;
        }

        public void TurnRight()
        {

            RoverState.RoverDirection = RoverState.RoverDirection == Direction.W ? Direction.N : RoverState.RoverDirection + 1;
            return RoverState;

        }
    }

    public class RobotState
    {
        public Point Position { get; set; }
        public Direction Direction { get; set; }
    }

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
    public enum Direction
    {
        North,
        East,
        South,
        West
    }
}
