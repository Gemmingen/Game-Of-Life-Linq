using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOL.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace GOL.Business
{
    public static class ServiceCollectionExtension 
    {
            public static IServiceCollection AddGameOfLife(this IServiceCollection services)
             {
              services.AddSingleton<IGameEngine, GameEngine>();
               return services;
           }
}
}
