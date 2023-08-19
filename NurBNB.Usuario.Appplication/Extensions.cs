using Microsoft.Extensions.DependencyInjection;
using NurBNB.Usuario.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton<IUsuarioFactory, UsuarioFactory>();
            services.AddSingleton<IGuestsFactory, GuestsFactoty>();
            return services;
        }
    }
}
