using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life_Linq
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set; }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            // Beispielgrid mit zufälligen Zellen
            int width = 50;
            int height = 50;
            List<Cell> grid = new List<Cell>
            {
                 new Cell { X = 1, Y = 1, IsAlive = true },
                 new Cell { X = 2, Y = 1, IsAlive = true },
                 new Cell { X = 4, Y = 1, IsAlive = true },
                 new Cell { X = 5, Y = 1, IsAlive = true },
                 new Cell { X = 6, Y = 1, IsAlive = true },
                 new Cell { X = 7, Y = 1, IsAlive = true },
                 new Cell { X = 8, Y = 1, IsAlive = true },
                 new Cell { X = 3, Y = 1, IsAlive = true }
            };

            while (true) //um Generationen zu wiederholen
            {
                
                PrintGrid(grid, width, height); //darstellung
           
                grid = NextGeneration(grid, width, height); //business

                System.Threading.Thread.Sleep(500); // 500ms, anpassen für Geschwindigkeit
            }
        }

        
        static void PrintGrid(List<Cell> grid, int width, int height)
        {
            Console.SetCursorPosition(0, 0); 
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var cell = grid.FirstOrDefault(c => c.X == x && c.Y == y);
                    Console.Write(cell != null && cell.IsAlive ? "O " : ". ");
                }
                Console.WriteLine();
            }
        }
        static List<Cell> NextGeneration(List<Cell> grid, int width, int height)
        {
            return (from x in Enumerable.Range(0, width)
                    from y in Enumerable.Range(0, height)
                    let current = grid.FirstOrDefault(cell => cell.X == x && cell.Y == y) ?? new Cell { X = x, Y = y, IsAlive = false }
                    let aliveNeighbors = CountNeighbors(grid, current, width, height)
                    let isAliveNext = aliveNeighbors == 3 || (aliveNeighbors == 2 && current.IsAlive)
                    where isAliveNext
                    select new Cell { X = x, Y = y, IsAlive = true })
                   .ToList();
        }

        static void FillList(List<Cell> grid, int Width, int Height)
        {
            grid = (
                from x in Enumerable.Range(0, Width)
                from y in Enumerable.Range(0, Height)
                select new Cell
                {
                    X = x,
                    Y = y,
                    IsAlive = false
                }
                ).ToList();
        }

        static int CountNeighbors(List<Cell> grid, Cell cell, int width, int height)
        {
            return (from dx in Enumerable.Range(-1, 3)
                    from dy in Enumerable.Range(-1, 3)
                    where dx != 0 || dy != 0
                    let nx = (cell.X + dx + width) % width
                    let ny = (cell.Y + dy + height) % height
                    let neighbor = grid.FirstOrDefault(cel => cel.X == nx && cel.Y == ny)
                    where neighbor != null && neighbor.IsAlive
                    select neighbor)
                   .Count();
        }

        static bool ValidateExistence(List<Cell> grid, Cell cell, int width, int height)
        {
            int neighbors = CountNeighbors(grid, cell, width, height);
            return neighbors == 3 || (neighbors == 2 && cell.IsAlive);
        }

        


    }
}