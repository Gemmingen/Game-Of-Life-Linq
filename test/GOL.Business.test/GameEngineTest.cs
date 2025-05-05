using System.Collections.Generic;
using GOL.Business;
using GOL.Contract;
using Xunit;

namespace GOL.Tests
{
    public class GameEngineTests
    {
        private readonly GameEngine _engine;

        public GameEngineTests()
        {
            _engine = new GameEngine();
        }

        [Fact]
        public void CountNeighbors_ShouldReturnCorrectNumber()
        {
            var grid = new List<Cell>
            {
                new Cell { X = 1, Y = 1, IsAlive = true },
                new Cell { X = 2, Y = 1, IsAlive = true },
                new Cell { X = 1, Y = 2, IsAlive = true }
            };

       
            int count = _engine.CountNeighbors(grid, grid[0], 5, 5);

            Assert.Equal(2, count); // 2 lebendige Nachbarn
        }

        [Theory]
        [InlineData(2, true, true)]
        [InlineData(3, false, true)]
        [InlineData(1, true, false)]
        [InlineData(4, true, false)]
        public void ValidateExistence_ShouldFollowGameOfLifeRules(int neighbors, bool isAlive, bool expected)
        {
            // Arrange
            var cell = new Cell { X = 5, Y = 5, IsAlive = isAlive };
            var grid = new List<Cell> { cell };

            var directions = new (int dx, int dy)[]
            {
               (-1, -1), (0, -1), (1, -1),
               (-1,  0),          (1,  0),
               (-1,  1), (0,  1), (1,  1)
            };


            for (int i = 0; i < neighbors; i++)
            {
                var pos = directions[i];
                grid.Add(new Cell { X = cell.X + pos.dx, Y = cell.Y + pos.dy, IsAlive = true });
            }

            // Act
            bool result = _engine.ValidateExistence(grid, cell, 10, 10);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void NextGeneration_ShouldUpdateGridCorrectly()
        {
            var grid = new List<Cell>
            {
                new Cell { X = 1, Y = 0, IsAlive = true },
                new Cell { X = 1, Y = 1, IsAlive = true },
                new Cell { X = 1, Y = 2, IsAlive = true }
            };

            var nextGen = _engine.NextGeneration(grid, 5, 5);

            Assert.Contains(nextGen, c => c.X == 0 && c.Y == 1); // sollte leben
            Assert.Contains(nextGen, c => c.X == 1 && c.Y == 1); // sollte leben
            Assert.Contains(nextGen, c => c.X == 2 && c.Y == 1); // sollte leben
            Assert.Equal(3, nextGen.Count);                      // nur drei Zellen leben
        }
    }
}