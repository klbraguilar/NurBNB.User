using NurBNB.Usuario.Domain.Exceptions;
using NurBNB.Usuario.Domain.Model.Users;
using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace NurBNB.Usuario.Test.Domain.Model.Users
{
    public class Guest_test
    {
        [Fact]
        public void Guest_Creation_SetsPropertiesCorrectly()
        {
            // Arrange
            var name = "guest";
            var lastName = "test";
            var phoneNumber = "123456789";
            var usuarioId = Guid.NewGuid();

            // Act
            var guest = new Guest(name, lastName, phoneNumber, usuarioId);

            // Assert
            Assert.Equal(name, guest.Name);
            Assert.Equal(lastName, guest.LastName);
            Assert.Equal(phoneNumber, guest.PhoneNumber);
            Assert.Equal(usuarioId, guest.UsuarioId);
        }

        [Fact]
        public void Guest_Creation_SetsIdToNotEmptyGuid()
        {
            // Arrange
            var name = "guest";
            var lastName = "test";
            var phoneNumber = "123456789";
            var usuarioId = Guid.NewGuid();

            // Act
            var guest = new Guest(name, lastName, phoneNumber, usuarioId);

            // Assert
            Assert.NotEqual(Guid.Empty, guest.Id);
        }

    }
}
