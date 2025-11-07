using mso_3;
using System.Numerics;
using Xunit;

namespace mso_2
{
    public class GridTests
    {
        [Fact]
        public void CheckBoundsWorksInBounds()
        {
            // Given
            Grid grid = new Grid(5, 5);
            MoveEntity entity = new MoveEntity(new Vector2(1, 0), new Vector2(), grid);
            // When
            bool result = grid.CheckBounds(entity.position);            
            // Then
            Assert.True(result);
        }
        [Fact]
        public void CheckBoundsWorksOutBounds()
        {
            // Given
            Grid grid = new Grid(5, 5);
            MoveEntity entity = new MoveEntity(new Vector2(-1, 0), new Vector2(0,0), grid);
            // When
            bool result = grid.CheckBounds(new Vector2(6, 6));
            // Then
            Assert.False(result);
        }


        [Fact]
        public void CheckAheadWorksOccupied()
        {
            // Given
            Grid grid = new Grid(5, 5);
            MoveEntity entity = new MoveEntity(new Vector2(1, 0), new Vector2(2, 2), grid);
            grid._occupied[3, 2] = true;
            // When
            bool result = grid.CheckAhead(entity);
            // Then
            //changed it to check if we can walk there instaed of if it's occupied so changed that
            Assert.False(result);
        }
        [Fact]
        public void CheckAheadWorksUnoccupied()
        {
            // Given
            Grid grid = new Grid(5, 5);
            MoveEntity entity = new MoveEntity(new Vector2(1, 0), new Vector2(2, 2), grid);
            grid._occupied[3, 2] = false;
            // When
            bool result = grid.CheckAhead(entity);
            // Then
            Assert.True(result);
        }
        [Fact]
        public void SwitchOccupiedWorks()
        {
            // Given
            Grid grid = new Grid(5, 5);
            grid._occupied[2, 2] = false;
            // When
            grid.SwitchOccupied(2, 2);
            // Then
            Assert.True(grid._occupied[2, 2]);
        }
        [Fact]
        public void ImportOccupiedWorks()
        {
            // When
            Grid grid = new Grid(5, 5);
            grid.ImportOccupied(@"..\..\..\example.txt");
            // Then
            Assert.False(grid._occupied[0, 0]);
            Assert.True(grid._occupied[3, 0]);
            Assert.True(grid.goal.X == 4 && grid.goal.Y == 4);
        }
    }
}
