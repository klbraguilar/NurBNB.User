using NurBNB.Usuario.Domain.Model.Users;
using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace NurBNB.Usuario.Test.Domain.Model.Users
{
    public class Email_test
    {
        [Fact]
        public void Email_CreationWithValidValue_SetsValueCorrectly()
        {
            // Arrange
            var validEmail = "test@example.com";

            // Act
            var email = new Email(validEmail);

            // Assert
            Assert.Equal(validEmail, email.Value);
        }

        [Fact]
        public void Email_CreationWithNullOrEmptyValue_ThrowsException()
        {
            // Act & Assert
            Assert.Throws<BussinessRuleValidationException>(() => new Email(null)); // Ajusta la excepción según tu implementación
            Assert.Throws<BussinessRuleValidationException>(() => new Email("")); // Ajusta la excepción según tu implementación
        }

        [Fact]
        public void Email_ImplicitConversionToString_ReturnsValue()
        {
            // Arrange
            var validEmail = "test@example.com";
            var email = new Email(validEmail);

            // Act
            string emailString = email;

            // Assert
            Assert.Equal(validEmail, emailString);
        }

        [Fact]
        public void Email_ImplicitConversionFromToString_CreatesEmailObject()
        {
            // Arrange
            var validEmail = "test@example.com";

            // Act
            Email email = validEmail;

            // Assert
            Assert.Equal(validEmail, email.Value);
        }
    }
}
