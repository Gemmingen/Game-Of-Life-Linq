using System.Collections.Generic;
using System.Linq;
using GOL.Contract;

namespace GOL
{
    /// <summary>
    /// Kernlogik des Game of Life implementiert das IGameEngine-Contract.
    /// </summary>
    public class GameEngine : IGameEngine
    {
        public List<Cell> NextGeneration(List<Cell> grid, int width, int height)
        {
            return Enumerable.Range(0, width)
                             .SelectMany(x => Enumerable.Range(0, height)
                                                        .Select(y =>
                                                        {
                                                            var current = grid.FirstOrDefault(c => c.X == x && c.Y == y)
                                                                          ?? new Cell { X = x, Y = y, IsAlive = false };
                                                            int aliveNeighbors = CountNeighbors(grid, current, width, height);
                                                            bool nextAlive = aliveNeighbors == 3
                                                                             || (aliveNeighbors == 2 && current.IsAlive);
                                                            return new { current, nextAlive };
                                                        }))
                             .Where(t => t.nextAlive)
                             .Select(t => new Cell
                             {
                                 X = t.current.X,
                                 Y = t.current.Y,
                                 IsAlive = true
                             })
                             .ToList();
        }

        public int CountNeighbors(List<Cell> grid, Cell cell, int width, int height)
        {
            return Enumerable.Range(-1, 3)
                             .SelectMany(dx => Enumerable.Range(-1, 3), (dx, dy) => (dx, dy))
                             .Where(d => d.dx != 0 || d.dy != 0)
                             .Select(d =>
                             {
                                 int nx = (cell.X + d.dx + width) % width;
                                 int ny = (cell.Y + d.dy + height) % height;
                                 return grid.FirstOrDefault(n => n.X == nx && n.Y == ny);
                             })
                             .Count(n => n != null && n.IsAlive);
        }

        public bool ValidateExistence(List<Cell> grid, Cell cell, int width, int height)
        {
            int neighbors = CountNeighbors(grid, cell, width, height);
            return neighbors == 3 || (neighbors == 2 && cell.IsAlive);
        }
    }
}