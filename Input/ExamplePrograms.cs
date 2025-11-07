using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mso_2.Commands;

namespace mso_2.Input
{
    internal interface ExamplePrograms
    {
        ICommand GetCommand();
    }

    internal class BasicProgram()
    {
        public ICommand GetCommand()
        {
            CompositeCommand compCommand = new CompositeCommand();
            compCommand.Add(new MoveCommand(10));
            compCommand.Add(new TurnCommand(TurnDirection.Right));
            compCommand.Add(new MoveCommand(10));

            return compCommand;
        }
    }

    internal class IntermediateProgram()
    {
        public ICommand GetCommand()
        {
            CompositeCommand compCommand = new CompositeCommand();

            RepeatCommand repeatCommand = new RepeatCommand(3);
            repeatCommand.Add(new MoveCommand(5));
            repeatCommand.Add(new TurnCommand(TurnDirection.Left));
            compCommand.Add(repeatCommand);

            return compCommand;
        }
    }
    internal class AdvancedProgram()
    {
        public ICommand GetCommand()
        {
            CompositeCommand compCommand = new CompositeCommand();
            compCommand.Add(new MoveCommand(5));
            compCommand.Add(new TurnCommand(TurnDirection.Left));
            compCommand.Add(new TurnCommand(TurnDirection.Left));
            compCommand.Add(new MoveCommand(3));
            compCommand.Add(new TurnCommand(TurnDirection.Right));

            RepeatCommand repeatCommand = new RepeatCommand(3);
            compCommand.Add(new MoveCommand(1));
            compCommand.Add(new TurnCommand(TurnDirection.Right));
            compCommand.Add(repeatCommand);

            RepeatCommand repeatCommand2 = new RepeatCommand(5);
            repeatCommand2.Add(new MoveCommand(2));
            repeatCommand.Add(repeatCommand2);
            compCommand.Add(new TurnCommand(TurnDirection.Left));

            return compCommand;
        }
    }
}
