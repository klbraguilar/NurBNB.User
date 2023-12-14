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
    public class StaffFactory_test
    {
        [Fact]
        public void Crear_ReturnsStaffWithCorrectProperties()
        {
            // Arrange
            var name = "staff";
            var lastName = "test";
            var phoneNumber = "123456789";
            var usuarioId = Guid.NewGuid();

            var factory = new StaffFactory();

            // Act
            var staff = factory.Crear(name, lastName, phoneNumber, usuarioId);

            // Assert
            Assert.Equal(name, staff.Name);
            Assert.Equal(lastName, staff.LastName);
            Assert.Equal(phoneNumber, staff.PhoneNumber);
            Assert.Equal(usuarioId, staff.UsuarioId);
        }

        [Fact]
        public void Crear_MockedFactory_ReturnsStaffWithCorrectProperties()
        {
            // Arrange
            var name = "staff";
            var lastName = "test";
            var phoneNumber = "123456789";
            var usuarioId = Guid.NewGuid();

            var mockFactory = new Mock<IStaffFactory>();
            mockFactory
                .Setup(factory => factory.Crear(name, lastName, phoneNumber, usuarioId))
                .Returns(new Staff(name, lastName, phoneNumber, usuarioId));

            var factory = mockFactory.Object;

            // Act
            var staff = factory.Crear(name, lastName, phoneNumber, usuarioId);

            // Assert
            Assert.Equal(name, staff.Name);
            Assert.Equal(lastName, staff.LastName);
            Assert.Equal(phoneNumber, staff.PhoneNumber);
            Assert.Equal(usuarioId, staff.UsuarioId);
        }
    }
}
