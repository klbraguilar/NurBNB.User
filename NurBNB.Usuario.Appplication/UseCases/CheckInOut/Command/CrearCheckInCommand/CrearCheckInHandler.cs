using MediatR;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearGuests;
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

namespace NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.CrearCheckInCommand
{
    public class CrearCheckInHandler : IRequestHandler<CrearCheckInCommand, Guid>
    {
        private ICheckInRepository _checkInRepository;
        private ICheckInFactory _checkInFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearCheckInHandler(ICheckInRepository checkInRepository, ICheckInFactory checkInFactory, IUnitOfWork unitOfWork)
        {
            _checkInRepository = checkInRepository;
            _checkInFactory = checkInFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearCheckInCommand request, CancellationToken cancellationToken)
        {
            CheckIn checkInCreado = _checkInFactory.Crear(request.guestId, request.reservaId, request.contacto);
            await _checkInRepository.CreateAsync(checkInCreado);
            await _unitOfWork.Commit();
            return checkInCreado.Id;
        }
    }
}
