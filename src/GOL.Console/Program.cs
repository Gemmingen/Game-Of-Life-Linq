
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GOL.Business;
using GOL.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace GOL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddGameOfLife()
            .BuildServiceProvider();

          
            var engine = serviceProvider.GetRequiredService<IGameEngine>();

            const int WIDTH = 50;
            const int HEIGHT = 50;

            
            var game = new GameOfLife(engine, WIDTH, HEIGHT);
            game.Start();
        }
    }
}