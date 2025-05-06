using Microsoft.Extensions.DependencyInjection;
using GOL.Business;

namespace GOL.Forms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var serviceProvider = new ServiceCollection() //Initialisierung des ServiceProviders für Dependency Injection
            .AddGameOfLife()
             .AddSingleton<GameEngine>()
             .BuildServiceProvider();
            var game = serviceProvider.GetRequiredService<GameEngine>();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(game));
        }
    }
}