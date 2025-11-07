using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using mso_3;

namespace mso_2.Commands
{
    public interface ICommand
    {
        string Execute(MoveEntity entity);
    }

    internal class MoveCommand : ICommand
    {
        private int _steps;
        public MoveCommand(int steps) => _steps = steps;
        public string Execute(MoveEntity entity) => entity.Move(_steps);
    }
    
    // New command: move until a condition is met (hit a wall or hit the edge)
    public enum UntilCondition
    {
        HitWall,
        HitEdge
    }

    internal class DoUntilCommand : ICommand
    {
        private readonly UntilCondition _condition;
        public readonly List<ICommand> _commands = new List<ICommand>();

        public DoUntilCommand(UntilCondition condition) => _condition = condition;

        public void Add(ICommand command) => _commands.Add(command);

        public string Execute(MoveEntity entity)
        {
            // Ensure path recording starts from current position
            entity.ResetLastPositions();

            string result = "";
            int runs = 0;

            // Run the contained commands repeatedly until the condition is met.
            while (runs < 1000)
            {
                runs++;
                bool stop = _condition switch
                {
                    UntilCondition.HitWall => !entity.CanMoveAhead(),
                    UntilCondition.HitEdge => !entity.IsNextInBounds(),
                    _ => throw new ArgumentOutOfRangeException(nameof(_condition), _condition, "Unknown until condition")
                };

                if (stop) break;

                foreach (var cmd in _commands)
                {
                    result += cmd.Execute(entity) + ", ";
                }
            }

            return result.TrimEnd(',', ' ');
        }
    }
    public enum TurnDirection
    {
        Left,
        Right
    }
    internal class TurnCommand : ICommand
    {
        private TurnDirection _turnDirection;
        public TurnCommand(TurnDirection turnDirection) => _turnDirection = turnDirection;
        public string Execute(MoveEntity entity) => entity.Turn(_turnDirection);
    }

    internal class CompositeCommand : ICommand
    {
        public readonly List<ICommand> _commands = new List<ICommand>();

        public void Add(ICommand command) => _commands.Add(command);

        public string Execute(MoveEntity entity)
        {
            entity.ResetLastPositions();

            string result = "";

            foreach (var command in _commands)
                result += command.Execute(entity) + ", ";

            return result.TrimEnd(',', ' ') + ".";
        }
    }
    internal class RepeatCommand : ICommand
    {
        public readonly List<ICommand> _commands = new List<ICommand>();
        public readonly int _times;

        public RepeatCommand(int times) => _times = times;

        public void Add(ICommand command) => _commands.Add(command);

        public string Execute(MoveEntity entity)
        {
            string result = "";

            for (int i = 0; i < _times; i++)
            {
                foreach (var command in _commands)
                    result += command.Execute(entity) + ", ";
            }

            return result.TrimEnd(',', ' ');
        }
    }
}
