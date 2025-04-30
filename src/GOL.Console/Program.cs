
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
            const int WIDTH = 50;
            const int HEIGHT = 50; //Definiere die Dimensionen des Spielfelds

            var serviceProvider = new ServiceCollection() //Initialisierung des ServiceProviders für Dependency Injection
            .AddGameOfLife()
            .AddSingleton<GameOfLife>()
            .BuildServiceProvider();

            var game = serviceProvider.GetRequiredService<GameOfLife>();
            game.SetDimensions(WIDTH, HEIGHT);
            game.Start();
        }
    }
}