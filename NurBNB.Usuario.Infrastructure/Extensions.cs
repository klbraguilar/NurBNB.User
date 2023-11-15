using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NurBNB.Usuario.Appplication;
using NurBNB.Usuario.Appplication.Services;
using NurBNB.Usuario.Domain.Repositories;
using NurBNB.Usuario.Infrastructure.EF;
using NurBNB.Usuario.Infrastructure.EF.Contexts;
using NurBNB.Usuario.Infrastructure.EF.Repositories;
using NurBNB.Usuario.Infrastructure.MassTransit;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            IConfiguration configuration, bool isDevelopment)
        {
            services.AddApplication();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            AddDatabase(services, configuration, isDevelopment);
            AddMassTransitWithRabbitMQ(services, configuration);
            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            var connectionString =
                    configuration.GetConnectionString("NurBNBDbConnectionString");
            services.AddDbContext<ReadDbContext>(context =>
                    context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDBContext>(context =>
                context.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IHuespedRepository, HuespedRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<ICheckInRepository, CheckInRepository>();
            services.AddScoped<ICheckOutRepository, CheckOutRepository>();

            using var scope = services.BuildServiceProvider().CreateScope();
            if (!isDevelopment)
            {
                var context = scope.ServiceProvider.GetRequiredService<ReadDbContext>();
                context.Database.Migrate();
            }
        }

        private static IServiceCollection AddMassTransitWithRabbitMQ(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBusService, MassTransitBusService>();
            var serviceName = configuration.GetValue<string>("ServiceName");
            var rabbitMQSettings = configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();

            services.AddMassTransit(configure =>
            {

                configure.UsingRabbitMq((context, configurator) =>
                {

                    configurator.Host(rabbitMQSettings.Host);
                    configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceName, false));
                    configurator.UseMessageRetry(retryConfigurator =>
                    {
                        retryConfigurator.Interval(3, TimeSpan.FromSeconds(5));
                    });
                });
            });
            return services;
        }
    }
}
