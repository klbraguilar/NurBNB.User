using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Domain.Model.Users
{
    public class Staff_test
    {
        [Fact]
        public void Staff_Creation_SetsPropertiesCorrectly()
        {
            // Arrange
            var name = "staff";
            var lastName = "test";
            var phoneNumber = "123456789";
            var usuarioId = Guid.NewGuid();

            // Act
            var staff = new Staff(name, lastName, phoneNumber, usuarioId);

            // Assert
            Assert.Equal(name, staff.Name);
            Assert.Equal(lastName, staff.LastName);
            Assert.Equal(phoneNumber, staff.PhoneNumber);
            Assert.Equal(usuarioId, staff.UsuarioId);
        }

        [Fact]
        public void Staff_Creation_SetsIdToNotEmptyGuid()
        {
            // Arrange
            var name = "staff";
            var lastName = "test";
            var phoneNumber = "123456789";
            var usuarioId = Guid.NewGuid();

            // Act
            var staff = new Staff(name, lastName, phoneNumber, usuarioId);

            // Assert
            Assert.NotEqual(Guid.Empty, staff.Id);
        }
    }
}
