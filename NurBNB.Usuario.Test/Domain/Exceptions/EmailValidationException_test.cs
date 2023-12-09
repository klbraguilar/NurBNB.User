using NurBNB.Usuario.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Domain.Exceptions
{
    public class EmailValidationException_test
    {
        [Fact]
        public void EmailValidationException_Constructor_SetsMessageCorrectly()
        {
            // Arrange
            var reason = "no contiene un dominio válido";

            // Act
            var exception = new EmailValidationException(reason);

            // Assert
            Assert.Equal($"Debe verificar que el correo cuente con la siguiente caracteristica {reason}", exception.Message);
        }

        //[Fact]
        //public void EmailValidationException_Constructor_NullReason_ThrowsArgumentNullException()
        //{
        //    // Act & Assert
        //    Assert.Throws<ArgumentNullException>(() => new EmailValidationException(null));
        //}

        //[Fact]
        //public void EmailValidationException_Constructor_EmptyReason_ThrowsArgumentException()
        //{
        //    // Act & Assert
        //    Assert.Throws<ArgumentException>(() => new EmailValidationException(""));
        //}
    }
}
