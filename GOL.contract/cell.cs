using System.Collections.Generic;

namespace GOL.Contract
{
    /// <summary>
    /// Repr�sentiert eine einzelne Zelle im Game of Life.
    /// </summary>
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set; }
    }

    /// <summary>
    /// Definiert das Contract f�r die Kernlogik des Game of Life.
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Berechnet die n�chste Generation basierend auf dem aktuellen Grid.
        /// </summary>
        List<Cell> NextGeneration(List<Cell> grid, int width, int height);

        /// <summary>
        /// Z�hlt die lebenden Nachbarn einer Zelle.
        /// </summary>
        int CountNeighbors(List<Cell> grid, Cell cell, int width, int height);

        /// <summary>
        /// �berpr�ft, ob eine Zelle in der n�chsten Generation lebt.
        /// </summary>
        bool ValidateExistence(List<Cell> grid, Cell cell, int width, int height);
    }
}