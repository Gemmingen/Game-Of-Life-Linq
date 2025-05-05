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
            //arrange
            var grid = new List<Cell>
            {
                new Cell { X = 1, Y = 1, IsAlive = true },
                new Cell { X = 2, Y = 1, IsAlive = true },
                new Cell { X = 1, Y = 2, IsAlive = true }
            };
            //act
       
            int count = _engine.CountNeighbors(grid, grid[0], 5, 5);
            //assert
            Assert.Equal(2, count); // 2 lebendige Nachbarn
        }

        public void CountNeighbors_ShouldWrapAndReturnCorrectNumber()
        {
            //arrange
            var grid = new List<Cell>
            {
                new Cell { X = 0, Y = 0, IsAlive = true },
                new Cell { X = 4, Y = 4, IsAlive = true },
                new Cell { X = 0, Y = 4, IsAlive = true }
            };
            //act

            int count = _engine.CountNeighbors(grid, grid[0], 5, 5);
            //assert
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
        public void ValidateExistence_ShouldRecognizeWrappedNeighbors()
        {
            // Arrange
            var cell = new Cell { X = 0, Y = 0, IsAlive = false };
            var grid = new List<Cell>
                {
                  new Cell { X = 9, Y = 9, IsAlive = true },
                  new Cell { X = 9, Y = 0, IsAlive = true },
                  new Cell { X = 9, Y = 1, IsAlive = true }
                };

            var engine = new GameEngine();

            // Act
            bool result = engine.ValidateExistence(grid, cell, 10, 10);

            // Assert
            Assert.True(result); // Zelle sollte geboren werden
        }

        [Fact]
        public void NextGeneration_ShouldUpdateGridCorrectly()
        {
            // Arrange
            var grid = new List<Cell>
            {
                new Cell { X = 1, Y = 0, IsAlive = true },
                new Cell { X = 1, Y = 1, IsAlive = true },
                new Cell { X = 1, Y = 2, IsAlive = true }
            };
            //act
            var nextGen = _engine.NextGeneration(grid, 5, 5);
            //assert
            Assert.Contains(nextGen, c => c.X == 0 && c.Y == 1); // sollte leben
            Assert.Contains(nextGen, c => c.X == 1 && c.Y == 1); // sollte leben
            Assert.Contains(nextGen, c => c.X == 2 && c.Y == 1); // sollte leben
            Assert.Equal(3, nextGen.Count);                      // nur drei Zellen leben
        }
        [Fact]
        public void NextGeneration_ShouldUpdateAndWrapGridCorrectly()
        {
            // Arrange
            var grid = new List<Cell>
                {
                  new Cell { X = 9, Y = 9, IsAlive = true },
                  new Cell { X = 9, Y = 0, IsAlive = true },
                  new Cell { X = 9, Y = 1, IsAlive = true }
                };
            //act
            var nextGen = _engine.NextGeneration(grid, 10, 10);
            //assert
            Assert.Contains(nextGen, c => c.X == 9 && c.Y == 0); // sollte leben
            Assert.Contains(nextGen, c => c.X == 8 && c.Y == 0); // sollte leben
            Assert.Contains(nextGen, c => c.X == 0 && c.Y == 0); // sollte leben
            Assert.Equal(3, nextGen.Count);                      // nur drei Zellen leben
        }
    }
}