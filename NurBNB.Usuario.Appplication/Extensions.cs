using Microsoft.Extensions.DependencyInjection;
using NurBNB.Usuario.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IUsuarioFactory, UsuarioFactory>();
            return services;
        }
    }
}
