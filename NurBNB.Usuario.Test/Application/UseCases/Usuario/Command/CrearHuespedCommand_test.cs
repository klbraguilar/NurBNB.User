using Moq;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearGuests;
using NurBNB.Usuario.Domain.Factories;
using NurBNB.Usuario.Domain.Model.Users;
using NurBNB.Usuario.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Application.UseCases.Usuario.Command
{
    public class CrearHuespedCommand_test
    {
        public class CrearHuespedHandlerTests
        {
            private readonly Mock<IHuespedRepository> _huespedRepository;
            private readonly Mock<IGuestsFactory> _huespedFactory;
            private readonly Mock<IUnitOfWork> _unitOfWork;

            public CrearHuespedHandlerTests()
            {
                _huespedRepository = new Mock<IHuespedRepository>();
                _huespedFactory = new Mock<IGuestsFactory>();
                _unitOfWork = new Mock<IUnitOfWork>();
            }

            [Fact]
            public async Task Handle_ValidRequest_ReturnsHuespedId()
            {
                // Arrange
                var usuarioId = Guid.NewGuid(); 
                var request = new CrearHuespedCommand
                {
                    Name = "GuestT",
                    LastName = "huesped",
                    PhoneNumber = "123456789",
                    usuarioId = usuarioId
                };

                var huespedCreado = new Guest("UsuarioTest", "correo_test@gmail.com", "123456", usuarioId);

                _huespedFactory
                    .Setup(factory => factory.Crear(request.Name, request.LastName, request.PhoneNumber, request.usuarioId))
                    .Returns(huespedCreado);

                var handler = new CrearHuespedHandler(
                    _huespedRepository.Object,
                    _huespedFactory.Object,
                    _unitOfWork.Object
                );

                // Act
                var result = await handler.Handle(request, CancellationToken.None);

                // Assert
                Assert.Equal(huespedCreado.Id, result);
                _huespedRepository.Verify(repo => repo.CreateAsync(huespedCreado), Times.Once);
                _unitOfWork.Verify(unitOfWork => unitOfWork.Commit(), Times.Once);
            }
        }
    }
}
