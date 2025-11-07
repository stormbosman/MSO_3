using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mso_2.Commands;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace mso_2.Input
{
    internal interface IInputStrategy
    {
        ICommand Read();
    }

    internal class ExampleInput : IInputStrategy
    {
        string example;
        public ExampleInput(string[] input)
        {
            example = input[0];
        }
        public ICommand Read()
        {
            Console.WriteLine("Choose: beginner/intermediate/advanced");

            return example switch
            {
                "beginner" => new BasicProgram().GetCommand(),
                "intermediate" => new IntermediateProgram().GetCommand(),
                "advanced" => new AdvancedProgram().GetCommand(),
                _ => throw new ArgumentException("Unknown input type")
            };
        }
    }

    internal class StringInput : IInputStrategy
    {
        protected CompositeCommand command;
    // A stack of currently open container commands (RepeatCommand or DoUntilCommand)
    // Stored as object so we can support multiple container types without
    // modifying the Commands.cs file here. We call Add via dynamic dispatch.
    protected List<object> nestedCommands;

        string[] lines = null;
        public StringInput(string[] Lines)
        {
            lines = Lines;
            command = new CompositeCommand();
            nestedCommands = new List<object>();
        }
        public virtual ICommand Read()
        {
            if (lines != null)
                foreach (string line in lines)
                    ProcessLine(line);

            return command;
        }

        internal void ProcessLine(string line)
        {
            int lineIndenation = CountIndentation(line);
            int lineNestDepth = lineIndenation / 4;
            int nests = nestedCommands.Count;


            string[] lineArgs = line.Substring(lineIndenation).Split(" ");

            ICommand lineCommand;

            switch (lineArgs[0])
            {
                case "Move": lineCommand = ProcessMove(lineArgs[1]); break;
                case "DoUntil": lineCommand = ProcessDoUntil(lineArgs[1]); break;
                case "Repeat": lineCommand = ProcessRepeat(lineArgs[1]); break;
                case "Turn": lineCommand = ProcessTurn(lineArgs[1]); break;
                default: throw new ArgumentException("Unknown input command");
            }
            if (lineIndenation == 0)
                command.Add(lineCommand);

            else if (lineNestDepth < nests)
            {
                nestedCommands = nestedCommands[..^(nests - lineNestDepth)];
                ((dynamic)nestedCommands[^1]).Add(lineCommand);
            }


            else if (lineArgs[0] == "Repeat" || lineArgs[0] == "DoUntil")
            {
                // when a new container is created (Repeat or MoveUntil) we add it
                // to its parent container which is the previous item on the stack
                if (nestedCommands.Count >= 2)
                    ((dynamic)nestedCommands[^2]).Add(lineCommand);
                else
                    // no parent container -> add to root composite
                    command.Add(lineCommand);
            }
            else
            {
                if (nestedCommands.Count >= 1)
                    ((dynamic)nestedCommands[^1]).Add(lineCommand);
                else
                    command.Add(lineCommand);
            }
        }

        private ICommand ProcessMove(string steps)
        {
            try
            {
                return new MoveCommand(int.Parse(steps));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid amount of steps");
            }
        }

        private ICommand ProcessTurn(string direction)
        {
            if (direction == "left")
                return new TurnCommand(TurnDirection.Left);

            else if (direction == "right")
                return new TurnCommand(TurnDirection.Right);

            else
                throw new ArgumentException("Invalid direction");
        }

        private ICommand ProcessRepeat(string steps)
        {
            try
            {
                RepeatCommand repeat = new RepeatCommand(int.Parse(steps));
                nestedCommands.Add(repeat);
                return repeat;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid amount of steps");
            }
        }

        private ICommand ProcessDoUntil(string condition)
        {

            //should probably compare this to a stripped condition.lowercase or something
            if (string.Equals(condition, "HitWall", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(condition, "Hitwall", StringComparison.OrdinalIgnoreCase))
            {
                var cmd = new DoUntilCommand(UntilCondition.HitWall);
                nestedCommands.Add(cmd);
                return cmd;
            }

            if (string.Equals(condition, "HitEdge", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(condition, "Hitedge", StringComparison.OrdinalIgnoreCase))
            {
                var cmd = new DoUntilCommand(UntilCondition.HitEdge);
                nestedCommands.Add(cmd);
                return cmd;
            }

            throw new ArgumentException("Invalid MoveUntil condition");
        }

        private int CountIndentation(string text)
        {
            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                    count++;
                else
                    break;
            }

            return count;
        }
    }

    internal class FileInput : StringInput
    {
        string filePath = null;

        public FileInput(string[] Lines) : base(Lines)
        {
            filePath = Lines[0];
        }
        public override ICommand Read()
        {
            ReadFile(filePath);
            return command;
        }

        public void SetFilePath(string FilePath)
        {
            filePath = FilePath;
        }

        private void ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new ArgumentException("File does not exist");

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ProcessLine(line);
                }
            }
        }
    }
}
