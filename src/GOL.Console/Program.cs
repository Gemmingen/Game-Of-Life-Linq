
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GOL.Business;
using GOL.Contract;

namespace GOL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new GameOfLife();
            const int width = 50;
            const int height = 50;
            game.Start(width, height);
        }
    }
}