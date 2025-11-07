using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using mso_3;

namespace mso_2
{
    public class Grid
    {
        public int _width { get; private set; }
        public int _height { get; private set; }
        public bool[,] _occupied { get; set; }

        public Vector2 goal;

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
            _occupied = new bool[width, height];
            goal = new Vector2(-1, -1);
        }
        public void SwitchOccupied(int x, int y) 
        {
            //switch the boolean value in the occupied grid at the location xy
            this._occupied[x, y] = !this._occupied[x, y];
        }

        public void ImportOccupied(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            _width = lines[0].Length;
            _height = lines.Length;
            bool[,] occupied = new bool[_width, _height];
            goal = new Vector2(0, 0);

            //parse the lines into the occupied grid
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    switch (lines[y][x])
                    {
                        case '+':
                            _occupied[x, y] = true;
                            break;
                        case 'o':
                            _occupied[x, y] = false;
                            break;
                        case 'x':
                            goal = new Vector2(x, y);
                            _occupied[x, y] = false;
                            break;
                        default:
                            throw new ArgumentException("Invalid character in input file");
                    }
                }
            }
        }


        //find the position ahead of the moveentity, and see if it is occupied
        public bool CheckAhead(MoveEntity entity)
        {
            Vector2 ahead = entity.position + entity.direction;
            //we want it to return true if the position ahead is unoccupied (occupied is false) and within bounds
            return (!_occupied[(int)ahead.X, (int)ahead.Y] && CheckBounds(ahead));
        }
        public bool CheckPositionFree(Vector2 position)
        {
            return !_occupied[(int)position.X, (int)position.Y];
        }
        //check if the given position is within the grid bounds

        public bool CheckBounds(Vector2 position)
        {
            if (position.X < 0 || position.Y < 0)
                return false;
            return (position.X < _width && position.Y < _height);
        }
    }
}