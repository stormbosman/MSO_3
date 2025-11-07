using mso_2.Commands;
using mso_2.Input;
using mso_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace mso_2
{
    public class Tester
    {

        private readonly MoveEntity entity;
        private readonly Grid grid;
        public Tester()
        {
            grid = new Grid(10, 10);
            //set it north and at 00
            entity = new MoveEntity(new Vector2(1, 0), new Vector2(0, 0), grid);
        }



        [Fact]
        public void IntermediateProgram_MetricsAreCorrect()
        {
            // Arrange
            IntermediateProgram program = new IntermediateProgram();
            ICommand command = program.GetCommand();
            Metrics metrics = new Metrics(command);

            // Act
            metrics.Analyze();
            string result = metrics.getStringData();

            // Assert
            Assert.Contains("No. of commands: 3", result);
            Assert.Contains("Max nesting: 1", result);
            Assert.Contains("No. of repeats: 1", result);
        }





        [Fact]
        public void GetStatusString_ShouldIncludePositionAndDirection()
        {
            string status = entity.GetStatusString();
            Assert.Contains("End state <0, 0> facing east.", status);
        }

        [Fact]
        public void CompositeCommand_ShouldExecuteAllSubcommands()
        {
            var comp = new CompositeCommand();
            comp.Add(new MoveCommand(2));
            comp.Add(new TurnCommand(TurnDirection.Right));
            string result = comp.Execute(entity);

            Assert.Contains("Turn right.", result);
            Assert.Contains("Move 2", result);
        }
        [Fact]
        public void Create_ShouldThrowException_ForUnknownType()
        {
            Assert.Throws<ArgumentException>(() => InputFactory.Create("invalid", []));
        }


    }
}
