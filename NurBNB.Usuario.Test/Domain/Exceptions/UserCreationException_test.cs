using NurBNB.Usuario.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Domain.Exceptions
{
    public class UserCreationException_test
    {
        [Fact]
        public void UsersCreationException_Constructor_SetsMessageCorrectly()
        {
            // Arrange
            var reason = "el correo electrónico ya está en uso";

            // Act
            var exception = new UsersCreationException(reason);

            // Assert
            Assert.Equal($"El usuario no puede ser creado porque {reason}", exception.Message);
        }

        [Fact]
        public void UsersCreationException_Constructor_NullReason_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersCreationException(null));
        }

        [Fact]
        public void UsersCreationException_Constructor_EmptyReason_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new UsersCreationException(""));
        }
    }
}
