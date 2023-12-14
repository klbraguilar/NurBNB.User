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
    public class UsuarioFactory_test
    {
        [Fact]
        public void Crear_ReturnsUserWithCorrectProperties()
        {
            // Arrange
            var usuario = "UsuarioTest";
            var correo = "correo_test@gmail.com";
            var contrasenha = "123456";

            var factory = new UsuarioFactory();

            // Act
            var user = factory.Crear(usuario, correo, contrasenha);

            // Assert
            Assert.Equal(usuario, user.Username);
            Assert.Equal(correo, user.Email);
            Assert.Equal(contrasenha, user.Password);
        }

        [Fact]
        public void Crear_MockedFactory_ReturnsUserWithCorrectProperties()
        {
            // Arrange
            var usuario = "UsuarioTest";
            var correo = "correo_test@gmail.com";
            var contrasenha = "123456";

            var mockFactory = new Mock<IUsuarioFactory>();
            mockFactory
                .Setup(factory => factory.Crear(usuario, correo, contrasenha))
                .Returns(new User(usuario, correo, contrasenha));

            var factory = mockFactory.Object;

            // Act
            var user = factory.Crear(usuario, correo, contrasenha);

            // Assert
            Assert.Equal(usuario, user.Username);
            Assert.Equal(correo, user.Email);
            Assert.Equal(contrasenha, user.Password);
        }
    }
}
