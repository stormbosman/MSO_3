using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mso_2.Commands
{
    internal class Metrics
    {
        ICommand command;

        int totalCommands = 0;
        int nests = 0;
        int repeats = 0;
        public Metrics(ICommand Command)
        {
            command = Command;
        }

        public void Analyze()
        {
            Travel(command, 0);
        }
        public void Travel(ICommand command, int depth)
        {
            switch (command)
            {
                case RepeatCommand repeatCommand:
                    repeats++;
                    totalCommands++;
                    nests = Math.Max(nests, depth + 1);
                    foreach (var cmd in repeatCommand._commands)
                        Travel(cmd, depth + 1);
                    break;
                
                case DoUntilCommand DoUntilCommand:
                    repeats++;
                    totalCommands++;
                    nests = Math.Max(nests, depth + 1);
                    foreach (var cmd in DoUntilCommand._commands)
                        Travel(cmd, depth + 1);
                    break;

                case CompositeCommand compositeCommand:
                    foreach (var cmd in compositeCommand._commands)
                        Travel(cmd, depth);
                    break;

                case MoveCommand moveCommand:
                    totalCommands++ ;
                    break;



                case TurnCommand turnCommand:
                    totalCommands++;
                    break;
            }
        }

        public string getStringData()
        {
            string data = "";
            data += "No. of commands: " + totalCommands + "\n";
            data += "Max nesting: " + nests + "\n";
            data += "No. of repeats: " + repeats + "\n";
            return data;
        }
    }
}
