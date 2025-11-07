using System.Numerics;
using Xunit;

namespace mso_2
{
    public class MoveEntityTests
    {
        [Fact]
        public void Move_StepsAdvancePositionAndRecordsPath()
        {
            var grid = new Grid(5, 5);
            var entity = new mso_3.MoveEntity(new Vector2(1, 0), new Vector2(0, 0), grid);

            entity.ResetLastPositions();
            string res = entity.Move(2);

            Assert.Equal("Move 2", res);
            Assert.Equal(new Vector2(2, 0), entity.position);
            Assert.Equal(3, entity.lastPositions.Count); // start + 2 steps
            Assert.Equal(new Vector2(0,0), entity.lastPositions[0]);
            Assert.Equal(new Vector2(1,0), entity.lastPositions[1]);
            Assert.Equal(new Vector2(2,0), entity.lastPositions[2]);
        }


        [Fact]
        public void Move_OutOfBounds_ThrowsOutOfBoundsException()
        {
            var grid = new Grid(2, 1);
            var entity = new mso_3.MoveEntity(new Vector2(1, 0), new Vector2(1, 0), grid);
            entity.ResetLastPositions();

            Assert.Throws<mso_2.OutOfBoundsException>(() => entity.Move(1));
        }

        [Fact]
        public void Turn_ChangesDirection()
        {
            var grid = new Grid(5,5);
            var entity = new mso_3.MoveEntity(new Vector2(1,0), new Vector2(0,0), grid);

            string res = entity.Turn(mso_2.Commands.TurnDirection.Right);
            Assert.Equal("Turn right", res);
            Assert.Equal(new Vector2(0,1), entity.direction);
        }

        [Fact]
        public void ResetPosition_SetsStartState()
        {
            var grid = new Grid(5,5);
            var entity = new mso_3.MoveEntity(new Vector2(0,1), new Vector2(2,2), grid);

            entity.ResetPosition();
            Assert.Equal(new Vector2(0,0), entity.position);
            Assert.Equal(new Vector2(1,0), entity.direction);
        }

    }
}
