using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using mso_2.Commands;
using mso_2.Input;
using mso_3;

namespace mso_2
{
    public class ClientGUI
    {
        Grid grid;
        MoveEntity entity;

        public ClientGUI()
        {
            grid = new Grid(5, 5);
            entity = new MoveEntity(new Vector2(1, 0), new Vector2(0, 0), grid);
        }

        public ICommand BuildCommand(string type, string[] data)
        {
            var input = InputFactory.Create(type, data);
            return input.Read();
        }

        public string ExecuteCommand(string type, string[] data)
        {
            entity.ResetPosition();
            ICommand cmd = BuildCommand(type, data);

            return cmd.Execute(entity) + " " + entity.GetStatusString();
        }

        public string GetMetrics(string type, string[] data)
        {
            ICommand cmd = BuildCommand(type, data);

            Metrics metrics = new Metrics(cmd);
            metrics.Analyze();
            return metrics.getStringData();
        }

        public Vector2 GetGridSize()
        {
            return new Vector2(grid._width, grid._height);
        }

        public bool CheckGridOccupied(int col, int row)
        {
            return grid._occupied[col, row];
        }

        public Vector2 GetPlayerPos() 
        {
            return entity.position;
        }

        public List<Vector2> GetPlayerLastPositions()
        {
            return entity.lastPositions;
        }

        public Vector2 GetGridGoalPos()
        {
            return grid.goal;
        }

        public void LoadGridFromFile(string filePath)
        {
            grid.ImportOccupied(filePath);
        }
    }
}
