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

        public RobotState ExecuteMoveInstructions(string moves, Grid grid)
        {
            foreach (var move in moves)
            {
                ExecuteMove(move, grid);
            }
            return RobotState;
        }

        public void GetPositionAndPenalty()
        {

        }

        private void ExecuteMove(char move, Grid grid)
        {
            switch (move)
            {
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'M':
                    TryMoveForward(grid);
                    break;
            }
        }

        private void TurnLeft()
        {
            RobotState.Direction = RobotState.Direction == Direction.N ? Direction.W : RobotState.Direction - 1;
        }

        private void TurnRight()
        {
            RobotState.Direction = RobotState.Direction == Direction.W ? Direction.N : RobotState.Direction + 1;
        }

        private void TryMoveForward(Grid grid)
        {
            var newPosition = new Point(this.RobotState.Position.X, this.RobotState.Position.Y);
            if (RobotState.Direction == Direction.N)
            {
                newPosition.Y++;
                TryMoveForward(grid, newPosition);
            }
            else if (RobotState.Direction == Direction.E)
            {
                RobotState.Position.X++;
                TryMoveForward(grid, newPosition);
            }
            else if (RobotState.Direction == Direction.S)
            {
                RobotState.Position.Y--;
                TryMoveForward(grid, newPosition);
            }
            else if (RobotState.Direction == Direction.W)
            {
                RobotState.Position.X--;
                TryMoveForward(grid, newPosition);
            }
        }

        private void TryMoveForward(Grid grid, Point newPosition)
        {
            if (IsValidRobotPosition(newPosition, grid))
            {
                this.RobotState.Position = newPosition;
            }
            else
            {
                this.RobotState.PenaltyCount++;
            }
        }

        bool IsValidRobotPosition(Point position, Grid grid)
        {
            return (position.X > -1 && position.X < grid.Width)
                && (position.Y > -1 && position.Y < grid.Height);
        }
    }

    public class RobotState
    {
        public Point Position { get; set; }
        public Direction Direction { get; set; }
        public int PenaltyCount { get; set; } = 0;
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
        N,
        E,
        S,
        W
    }
}
