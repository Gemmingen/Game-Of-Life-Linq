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

}