using System.Collections.Generic;

namespace GOL.Contract
{
    public interface IGameEngine
    {
        List<Cell> NextGeneration(List<Cell> grid, int width, int height);
    }

}