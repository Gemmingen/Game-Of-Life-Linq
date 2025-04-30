using GOL.Business;
using GOL.Contract;
using System; 

namespace GOL
{
    public class GameOfLife
    {
        private IGameEngine _engine;
        private int _width;
        private int _height;
        public GameOfLife(IGameEngine engine)
        {
            _engine = engine;
        }

        public void SetDimensions(int width, int height)
        {
            _width = width;
            _height = height;
        }

        //Start der Simulation
        public void Start()
        {
            //Grid Initialisierung
            var grid = new List<Cell>();

            grid = ExampleGrid(grid);

            // Hauptschleife zur Simulation

            while (true)
            {
                Render(grid);
                grid = _engine.NextGeneration(grid, _width, _height);
                Thread.Sleep(500); // 500ms Pause für Geschwindigkeit
            }
        }
        private void Render(List<Cell> grid)
        {
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
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
