using Consul;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NurBNB.Usuario.Appplication;
using NurBNB.Usuario.Appplication.Services;
using NurBNB.Usuario.Domain.Repositories;
using NurBNB.Usuario.Infrastructure.Consul;
using NurBNB.Usuario.Infrastructure.EF;
using NurBNB.Usuario.Infrastructure.EF.Contexts;
using NurBNB.Usuario.Infrastructure.EF.Repositories;
using NurBNB.Usuario.Infrastructure.MassTransit;
using NurBNB.Usuario.Infrastructure.MassTransit.Consumers;
using NURBNB.IntegrationEvents;
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
            services.AddConsulConfig(configuration);
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
                configure.AddConsumer<ReservaRegistradaConsumer>();
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
        public static IServiceCollection AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var configSettings = configuration.GetSection(nameof(ConfigurationSetting)).Get<ConfigurationSetting>();
                var address = configSettings.ConsulAddresss;
                consulConfig.Address = new Uri(address);
            }));
            return services;
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtensions");
            var lifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();

            //var uri = new Uri(address);
            var configSettings = configuration.GetSection(nameof(ConfigurationSetting)).Get<ConfigurationSetting>();
            var serviceName = configSettings.ServiceName;
            var serviceHost = configSettings.ServiceHost;
            var servicePort = configSettings.ServicePort;
            var registration = new AgentServiceRegistration()
            {
                ID = serviceName, //{uri.Port}",
                // servie name  
                Name = serviceName,
                Address = serviceHost, //$"{uri.Host}",
                Port = servicePort  // uri.Port
            };

            logger.LogInformation("Registering with Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            lifetime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation("Unregistering from Consul");
            });

            return app;
        }
    }
}
