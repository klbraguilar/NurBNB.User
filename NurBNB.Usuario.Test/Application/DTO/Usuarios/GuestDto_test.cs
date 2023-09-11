using NurBNB.Usuario.Appplication.DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Application.DTO.Usuarios
{
    public class GuestDto_test
    {
        [Fact]
        public void GuestDto_PropertiesAreSetCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Guest";
            var lastName = "Test";
            var phoneNumber = "*78945*";
            var userName = "guest@gmail.com";

            // Act
            var guestDto = new GuestDto
            {
                Id = id,
                Name = name,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                UserName = userName
            };

            // Assert
            Assert.Equal(id, guestDto.Id);
            Assert.Equal(name, guestDto.Name);
            Assert.Equal(lastName, guestDto.LastName);
            Assert.Equal(phoneNumber, guestDto.PhoneNumber);
            Assert.Equal(userName, guestDto.UserName);
        }

        [Fact]
        public void GuestDto_PropertiesAreNotNull()
        {
            // Arrange
            var guestDto = new GuestDto();

            // Act & Assert
            Assert.Null(guestDto.Name);
            Assert.Null(guestDto.LastName);
            Assert.Null(guestDto.PhoneNumber);
            Assert.Null(guestDto.UserName);
        }
    }
}
