using System.Collections.Generic;

namespace GOL.Contract
{
    /// <summary>
    /// Repräsentiert eine einzelne Zelle im Game of Life.
    /// </summary>
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set; }
    }

    /// <summary>
    /// Definiert das Contract für die Kernlogik des Game of Life.
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Berechnet die nächste Generation basierend auf dem aktuellen Grid.
        /// </summary>
        List<Cell> NextGeneration(List<Cell> grid, int width, int height);

        /// <summary>
        /// Zählt die lebenden Nachbarn einer Zelle.
        /// </summary>
        int CountNeighbors(List<Cell> grid, Cell cell, int width, int height);

        /// <summary>
        /// Überprüft, ob eine Zelle in der nächsten Generation lebt.
        /// </summary>
        bool ValidateExistence(List<Cell> grid, Cell cell, int width, int height);
    }
}