using MediatR;
using NurBNB.Usuario.Domain.Factories;
using NurBNB.Usuario.Domain.Model.CheckInOut;
using NurBNB.Usuario.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.CrearCheckOutCommand
{
    public class CrearCheckOutHandler : IRequestHandler<CrearCheckOutCommand, Guid>
    {
        private ICheckOutRepository _checkOutRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearCheckOutHandler(ICheckOutRepository checkOutRepository, IUnitOfWork unitOfWork)
        {
            _checkOutRepository = checkOutRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearCheckOutCommand request, CancellationToken cancellationToken)
        {
            CheckOut checkOutCreado = CheckOut.Create(request.guestId, request.reservaId, request.calificacion, request.fechaSalida, request.comentario);
            await _checkOutRepository.CreateAsync(checkOutCreado);
            await _unitOfWork.Commit();
            return checkOutCreado.Id;
        }
    }
}
