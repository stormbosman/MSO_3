using System.Numerics;
using Xunit;
using mso_2.Commands;
using mso_3;

namespace mso_2
{
    public class CommandsTests
    {
        [Fact]
        public void MoveCommand_MovesEntity()
        {
            var grid = new Grid(5, 5);
            var entity = new MoveEntity(new Vector2(1, 0), new Vector2(0, 0), grid);

            var cmd = new MoveCommand(2);
            string result = cmd.Execute(entity);

            Assert.Equal("Move 2", result);
            Assert.Equal(new Vector2(2, 0), entity.position);
        }

        [Fact]
        public void TurnCommand_TurnsEntity()
        {
            var grid = new Grid(5, 5);
            var entity = new MoveEntity(new Vector2(1, 0), new Vector2(0, 0), grid);

            var cmd = new TurnCommand(TurnDirection.Right);
            string result = cmd.Execute(entity);

            Assert.Equal("Turn right", result);
            Assert.Equal(new Vector2(0, 1), entity.direction);
        }

        [Fact]
        public void CompositeCommand_ExecutesSubcommands()
        {
            var grid = new Grid(5, 5);
            var entity = new MoveEntity(new Vector2(1, 0), new Vector2(0, 0), grid);

            var comp = new CompositeCommand();
            comp.Add(new MoveCommand(1));
            comp.Add(new TurnCommand(TurnDirection.Right));

            string result = comp.Execute(entity);

            Assert.Contains("Move 1", result);
            Assert.Contains("Turn right", result);
            Assert.Equal(new Vector2(1, 0), entity.position);
            Assert.Equal(new Vector2(0, 1), entity.direction);
        }

        [Fact]
        public void RepeatCommand_RepeatsBody()
        {
            var grid = new Grid(5, 5);
            var entity = new MoveEntity(new Vector2(1, 0), new Vector2(0, 0), grid);

            var repeat = new RepeatCommand(2);
            repeat.Add(new MoveCommand(1));

            string result = repeat.Execute(entity);

            Assert.Contains("Move 1", result);
            Assert.Equal(new Vector2(2, 0), entity.position);
        }

        [Fact]
        public void MoveUntil_HitWall_StopsBeforeBlockedCell()
        {
            var grid = new Grid(3, 1);
            // block cell at (2,0)
            grid._occupied[2, 0] = true;

            var entity = new MoveEntity(new Vector2(1, 0), new Vector2(0, 0), grid);

            var until = new DoUntilCommand(UntilCondition.HitWall);
            until.Add(new MoveCommand(1));

            string result = until.Execute(entity);

            Assert.Equal(new Vector2(1, 0), entity.position);
            Assert.Equal("Move 1", result);
        }

        [Fact]
        public void MoveUntil_HitEdge_RepeatsUntilEdge()
        {
            var grid = new Grid(3, 1);
            var entity = new MoveEntity(new Vector2(1, 0), new Vector2(0, 0), grid);

            var until = new DoUntilCommand(UntilCondition.HitEdge);
            until.Add(new MoveCommand(1));

            string result = until.Execute(entity);

            Assert.Equal(new Vector2(2, 0), entity.position);
            Assert.Equal("Move 1, Move 1", result);
        }
    }
}
