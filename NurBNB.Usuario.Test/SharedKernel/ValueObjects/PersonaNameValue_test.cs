using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.SharedKernel.ValueObjects
{
    public class PersonaNameValue_test
    {
        [Theory]
        [InlineData("John")]
        [InlineData("Alice Smith")]
        [InlineData("Jane Doe")]
        public void PersonNameValue_CreationWithValidName_SetsNameCorrectly(string validName)
        {
            // Act
            var personNameValue = new PersonNameValue(validName);

            // Assert
            Assert.Equal(validName, personNameValue.Name);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("B")]
        public void PersonNameValue_CreationWithTooLongName_ThrowsException(string baseName)
        {
            // Construye una cadena de caracteres que excede el límite de longitud
            string longName = baseName.PadRight(501, 'A');

            // Act & Assert
            Assert.Throws<BussinessRuleValidationException>(() => new PersonNameValue(longName));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void PersonNameValue_CreationWithNullOrEmptyName_ThrowsException(string invalidName)
        {
            // Act & Assert
            Assert.Throws<BussinessRuleValidationException>(() => new PersonNameValue(invalidName));
        }


        [Theory]
        [InlineData("John")]
        [InlineData("Alice Smith")]
        [InlineData("Jane Doe")]
        public void PersonNameValue_ImplicitConversionToString_ReturnsName(string validName)
        {
            // Arrange
            var personNameValue = new PersonNameValue(validName);

            // Act
            string result = personNameValue;

            // Assert
            Assert.Equal(validName, result);
        }

        [Theory]
        [InlineData("John")]
        [InlineData("Alice Smith")]
        [InlineData("Jane Doe")]
        public void PersonNameValue_ImplicitConversionFromString_CreatesValue(string validName)
        {
            // Act
            PersonNameValue personNameValue = validName;

            // Assert
            Assert.Equal(validName, personNameValue.Name);
        }
    }
}
