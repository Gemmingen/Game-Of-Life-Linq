

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GOL.Business;
using GOL.Contract;

namespace GOL
{
       

     internal class GameOfLife
    {
        //Start der Simulation

        public void Start(int width, int height)
        {
            IGameEngine engine = new GameEngine();

            //Grid Initialisierung
            var grid = new List<Cell>();

            grid = ExampleGrid(grid);

            // Hauptschleife zur Simulation
            while (true)
            {
                Render(grid, width, height);
                grid = engine.NextGeneration(grid, width, height);
                Thread.Sleep(500); // 500ms Pause für Geschwindigkeit
            }
        }
        private static void Render(List<Cell> grid, int width, int height)
        {
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bool alive = grid.Any(c => c.X == x && c.Y == y && c.IsAlive);
                    Console.Write(alive ? "O " : ". ");
                }
                Console.WriteLine();
            }
        }
        
        private List<Cell> ExampleGrid(List<Cell> grid)
        {
            // Beispielgrid mit definierten lebenden Zellen
            grid.Add(new Cell { X = 1, Y = 1, IsAlive = true });
            grid.Add(new Cell { X = 2, Y = 1, IsAlive = true });
            grid.Add(new Cell { X = 4, Y = 1, IsAlive = true });
            grid.Add(new Cell { X = 5, Y = 1, IsAlive = true });
            grid.Add(new Cell { X = 6, Y = 1, IsAlive = true });
            grid.Add(new Cell { X = 7, Y = 1, IsAlive = true });
            grid.Add(new Cell { X = 8, Y = 1, IsAlive = true });
            grid.Add(new Cell { X = 3, Y = 1, IsAlive = true });
            return grid;
        }
    }
    
}
