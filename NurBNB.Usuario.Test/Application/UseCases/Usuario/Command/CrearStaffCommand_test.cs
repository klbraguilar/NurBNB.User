using Moq;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearEncargados;
using NurBNB.Usuario.Domain.Factories;
using NurBNB.Usuario.Domain.Model.Users;
using NurBNB.Usuario.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Application.UseCases.Usuario.Command
{
    public class CrearStaffCommand_test
    {
        private readonly Mock<IStaffRepository> _staffRepository;
        private readonly Mock<IStaffFactory> _staffFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CrearStaffCommand_test()
        {
            _staffRepository = new Mock<IStaffRepository>();
            _staffFactory = new Mock<IStaffFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsStaffId()
        {
            // Arrange
            var usuarioId = Guid.NewGuid();
            var request = new CrearStaffCommand
            {
                Name = "StaffT",
                LastName = "testLastName",
                PhoneNumber = "123456789",
                usuarioId = Guid.NewGuid()
            };

            var staffCreado = new Staff("UsuarioTest", "correo_test@gmail.com", "123456", usuarioId);

            _staffFactory
                .Setup(factory => factory.Crear(request.Name, request.LastName, request.PhoneNumber, request.usuarioId))
                .Returns(staffCreado);

            var handler = new CrearStaffHandler(
                _staffRepository.Object,
                _staffFactory.Object,
                _unitOfWork.Object
            );

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(staffCreado.Id, result);
            _staffRepository.Verify(repo => repo.CreateAsync(staffCreado), Times.Once);
            _unitOfWork.Verify(unitOfWork => unitOfWork.Commit(), Times.Once);
        }

        [Fact]
        public void Handle_InvalidName_ThrowsException()
        {
            var request = new CrearStaffCommand
            {
                Name = "",
                LastName = "testLastName",
                PhoneNumber = "123456789",
                usuarioId = Guid.NewGuid()
            };

            var handler = new CrearStaffHandler(
                _staffRepository.Object,
                _staffFactory.Object,
                _unitOfWork.Object
            );

            Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_RepositoryError_ThrowsException()
        {
            // Arrange
            var request = new CrearStaffCommand
            {
                Name = "StaffT",
                LastName = "testLastName",
                PhoneNumber = "123456789",
                usuarioId = Guid.NewGuid()
            };

            var staffCreado = new Staff("UsuarioTest", "correo_test@gmail.com", "123456", request.usuarioId);
            _staffFactory
                .Setup(factory => factory.Crear(request.Name, request.LastName, request.PhoneNumber, request.usuarioId))
                .Returns(staffCreado);

            _staffRepository
                .Setup(repo => repo.CreateAsync(staffCreado))
                .ThrowsAsync(new Exception("Simulated error"));

            var handler = new CrearStaffHandler(
                _staffRepository.Object,
                _staffFactory.Object,
                _unitOfWork.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
