using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using mso_2;
using mso_2.Commands;

namespace mso_3
{
    public class MoveEntity
    {
        public Vector2 direction;
        public Vector2 position;
        private Grid grid;

        public List<Vector2> lastPositions { get; }

        public MoveEntity(Vector2 Direction, Vector2 Position, Grid _grid)
        {
            direction = Direction;
            position = Position;
            grid = _grid;
            lastPositions = new List<Vector2>();
        }

        public void ResetPosition() 
        {
            position = new Vector2(0, 0);
            direction = new Vector2(1, 0);
        }

        public string Turn(TurnDirection turnDirection)
        {
            if (turnDirection == TurnDirection.Right)
            {
                direction = new Vector2(-direction.Y, direction.X);
                return "Turn right";
            }

            else
            {
                direction = new Vector2(direction.Y, -direction.X);
                return "Turn left";
            }
        }

        public void ResetLastPositions() 
        { 
            lastPositions.Clear();
            lastPositions.Add(position);
        }


        public string Move(int steps)
        {
            // Move step-by-step, checking bounds and occupancy at each step.
            for (int i = 0; i < steps; i++)
            {
                Vector2 next = position + direction;
                
                // Check bounds first
                if (!grid.CheckBounds(next))
                    throw new mso_2.OutOfBoundsException($"Attempted to move outside grid to {next}.");

                // Check occupancy
                if (!grid.CheckPositionFree(next))
                    throw new mso_2.BlockedCellException($"Attempted to move into blocked cell at {next}.");
                
                // Valid move: update position and record path
                position = next;
                lastPositions.Add(position);
            }

            return "Move " + steps.ToString();
        }

        public string GetStatusString() 
        {
            return "End state " + position.ToString() + " facing "+ GetStringDirection() + ".";
        }

        // Return true when the next cell in the current direction is inside the grid
        public bool IsNextInBounds()
        {
            Vector2 next = position + direction;
            return grid.CheckBounds(next);
        }

        // Return true when the next cell is inside the grid and not occupied
        public bool CanMoveAhead()
        {
            Vector2 next = position + direction;
            if (!grid.CheckBounds(next)) return false;
            Console.WriteLine(next.X.ToString() + " " + next.Y.ToString());
            return !grid._occupied[(int)next.X, (int)next.Y];
        }

        private string GetStringDirection()
        {
            var key = (direction.X, direction.Y);
            switch (key)
            {
                case (1, 0): return "east";
                case (0, 1): return "south";
                case (-1, 0): return "west";
                case (0, -1): return "north";

                default: return "";
            }
        }
    }
}
