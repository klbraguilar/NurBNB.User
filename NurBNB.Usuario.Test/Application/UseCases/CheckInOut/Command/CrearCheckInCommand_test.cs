using Moq;
using NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.CrearCheckInCommand;
using NurBNB.Usuario.Domain.Factories;
using NurBNB.Usuario.Domain.Model.CheckInOut;
using NurBNB.Usuario.Domain.Model.Users;
using NurBNB.Usuario.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Application.UseCases.CheckInOut.Command
{
    public class CrearCheckInCommand_test
    {
        [Fact]
        public async Task Handle_ValidRequest_CreatesCheckInAndReturnsId()
        {
            // Arrange
            var guestId = Guid.NewGuid();
            var reservaId = Guid.NewGuid();
            var contacto = "John Doe";
            var fechaLlegada = DateTime.Now;

            var crearCheckInCommand = new CrearCheckInCommand
            {
                guestId = guestId,
                reservaId = reservaId,
                contacto = contacto,
                fechaLlegada = fechaLlegada
            };

            var mockCheckInRepository = new Mock<ICheckInRepository>();
            var mockCheckInFactory = new Mock<ICheckInFactory>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var checkInId = Guid.NewGuid();
            var checkInCreado = new CheckIn(crearCheckInCommand.guestId, crearCheckInCommand.reservaId, crearCheckInCommand.contacto, crearCheckInCommand.fechaLlegada);


            mockCheckInFactory.Setup(factory => factory.Crear(guestId, reservaId, contacto, fechaLlegada))
                .Returns(checkInCreado);

            var crearCheckInHandler = new CrearCheckInHandler(
                mockCheckInRepository.Object,
                mockCheckInFactory.Object,
                mockUnitOfWork.Object
            );

            // Act
            var result = await crearCheckInHandler.Handle(crearCheckInCommand, CancellationToken.None);

            // Assert
            Assert.Equal(checkInCreado.Id, result);
            mockCheckInFactory.Verify(factory => factory.Crear(guestId, reservaId, contacto, fechaLlegada), Times.Once);
            mockCheckInRepository.Verify(repository => repository.CreateAsync(checkInCreado), Times.Once);
            mockUnitOfWork.Verify(unitOfWork => unitOfWork.Commit(), Times.Once);
        }
    }
}
