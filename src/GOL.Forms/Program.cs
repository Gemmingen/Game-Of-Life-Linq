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
            ApplicationConfiguration.Initialize();
            
            var serviceProvider = new ServiceCollection() //Initialisierung des ServiceProviders für Dependency Injection
              .AddGameOfLife()
              .AddSingleton<Form1>()
              .BuildServiceProvider();

            var form = serviceProvider.GetRequiredService<Form1>();
            Application.Run(form);
        }
    }
}