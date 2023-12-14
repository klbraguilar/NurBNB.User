using NurBNB.Usuario.Appplication.DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Application.DTO.Usuarios
{
    public class UserDto_test
    {
        [Fact]
        public void UserDto_PropertiesAreSetCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var username = "john_doe";
            var email = "john.doe@example.com";
            var password = "password123";

            // Act
            var userDto = new UserDto
            {
                Id = id,
                Username = username,
                Email = email,
                Password = password
            };

            // Assert
            Assert.Equal(id, userDto.Id);
            Assert.Equal(username, userDto.Username);
            Assert.Equal(email, userDto.Email);
            Assert.Equal(password, userDto.Password);
            Assert.NotNull(userDto.Username);
            Assert.NotNull(userDto.Email);
            Assert.NotNull(userDto.Password);
            Assert.Equal(8, userDto.Username.Length);
        }
    }
}
