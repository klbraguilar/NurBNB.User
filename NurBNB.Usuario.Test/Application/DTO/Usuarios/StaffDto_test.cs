using NurBNB.Usuario.Appplication.DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Application.DTO.Usuarios
{
    public class StaffDto_test
    {
        [Fact]
        public void StaffDto_Creation_SetsPropertiesCorrectly()
        {
            // Arrange
            var name = "John";
            var lastName = "Doe";
            var phoneNumber = "123-456-7890";

            // Act
            var staffDto = new StaffDto
            {
                Name = name,
                LastName = lastName,
                PhoneNumber = phoneNumber
            };

            // Assert
            Assert.NotNull(staffDto);
            Assert.IsType<StaffDto>(staffDto);
            Assert.Equal(name, staffDto.Name);
            Assert.Equal(lastName, staffDto.LastName);
            Assert.Equal(phoneNumber, staffDto.PhoneNumber);
        }
    }
}
