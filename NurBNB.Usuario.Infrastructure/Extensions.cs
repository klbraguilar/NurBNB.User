using Microsoft.Extensions.DependencyInjection;
using NurBNB.Usuario.Appplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddApplication();
            return services;
        }
    }
}
