using Moq;
using NurBNB.Usuario.Domain.Factories;
using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Domain.Factory
{
    public class GuestFactory_test
    {
        [Fact]
        public void Crear_ReturnsGuestWithCorrectProperties()
        {
            // Arrange
            var name = "guest";
            var lastName = "test";
            var phoneNumber = "123456789";
            var usuarioId = Guid.NewGuid();

            var factory = new GuestsFactoty();

            // Act
            var guest = factory.Crear(name, lastName, phoneNumber, usuarioId);

            // Assert
            Assert.Equal(name, guest.Name);
            Assert.Equal(lastName, guest.LastName);
            Assert.Equal(phoneNumber, guest.PhoneNumber);
            Assert.Equal(usuarioId, guest.UsuarioId);
        }

        [Fact]
        public void Crear_MockedFactory_ReturnsGuestWithCorrectProperties()
        {
            // Arrange
            var name = "guest";
            var lastName = "test";
            var phoneNumber = "123456789";
            var usuarioId = Guid.NewGuid();

            var mockFactory = new Mock<IGuestsFactory>();
            mockFactory
                .Setup(factory => factory.Crear(name, lastName, phoneNumber, usuarioId))
                .Returns(new Guest(name, lastName, phoneNumber, usuarioId));

            var factory = mockFactory.Object;

            // Act
            var guest = factory.Crear(name, lastName, phoneNumber, usuarioId);

            // Assert
            Assert.Equal(name, guest.Name);
            Assert.Equal(lastName, guest.LastName);
            Assert.Equal(phoneNumber, guest.PhoneNumber);
            Assert.Equal(usuarioId, guest.UsuarioId);
        }
    }
}
