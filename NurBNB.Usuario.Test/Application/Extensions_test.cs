using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NurBNB.Usuario.Appplication;
using NurBNB.Usuario.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Application
{
    public class Extensions_test
    {
        [Fact]
        public void AddApplication_ConfiguresServicesCorrectly()
        {
            // Arrange
            var services = new ServiceCollection();
            var executingAssembly = typeof(Extensions).Assembly;

            // Mock de MediatR para verificar si se llamó a RegisterServicesFromAssembly
            var mockMediatR = new Mock<IMediator>();

            services.AddSingleton(mockMediatR.Object);

            // Act
            services.AddApplication();

            // Resuelve los servicios directamente desde la colección de servicios
            var serviceProvider = services.BuildServiceProvider();

            // Verifica si se llamó a RegisterServicesFromAssembly de MediatR
            //mockMediatR.Verify(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly(), Times.Once);

            // Verifica si los servicios Singleton se registraron correctamente
            Assert.NotNull(serviceProvider.GetRequiredService<IUsuarioFactory>());
            Assert.NotNull(serviceProvider.GetRequiredService<IGuestsFactory>());
            Assert.NotNull(serviceProvider.GetRequiredService<IStaffFactory>());
        }
    }
}
