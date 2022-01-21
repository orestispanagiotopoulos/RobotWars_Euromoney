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

        public void Move(MoveTo move, Grid grid)
        {
            switch (move)
            {
                case MoveTo.L:
                    TurnLeft();
                    break;
                case MoveTo.R:
                    TurnRight();
                    break;
                case MoveTo.M:
                    MoveForward(grid);
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

        private void MoveForward(Grid grid)
        {
            var currentPosition = new Point(this.RobotState.Position.X, this.RobotState.Position.Y);
            if (RobotState.Direction == Direction.N)
            {
                currentPosition.Y++;
                TryMoveForward(grid, currentPosition);
            }
            else if (RobotState.Direction == Direction.E)
            {
                currentPosition.X++;
                TryMoveForward(grid, currentPosition);
            }
            else if (RobotState.Direction == Direction.S)
            {
                currentPosition.Y--;
                TryMoveForward(grid, currentPosition);
            }
            else if (RobotState.Direction == Direction.W)
            {
                currentPosition.X--;
                TryMoveForward(grid, currentPosition);
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

        private bool IsValidRobotPosition(Point position, Grid grid)
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

    public enum MoveTo
    {
        L, // left
        R, // right
        M  // Move foreward
    }
}
