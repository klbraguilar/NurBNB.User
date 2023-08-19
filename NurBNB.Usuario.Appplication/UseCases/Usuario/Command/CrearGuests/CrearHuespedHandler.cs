using MediatR;

using NurBNB.Usuario.Domain.Factories;
using NurBNB.Usuario.Domain.Model.Users;
using NurBNB.Usuario.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearGuests
{
    internal class CrearHuespedHandler : IRequestHandler<CrearHuespedCommand, Guid>
    {
        private IHuespedRepository _huespedRepository;
        private IGuestsFactory _huespedFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearHuespedHandler(IHuespedRepository usuarioRepository,
            IGuestsFactory usuarioFactory, IUnitOfWork unitOfWork)
        {
            _huespedRepository = usuarioRepository;
            _huespedFactory = usuarioFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearHuespedCommand request, CancellationToken cancellationToken)
        {

            Guest huespedCreado = _huespedFactory.Crear(request.Name, request.LastName, request.PhoneNumber, request.userId);
            await _huespedRepository.CreateAsync(huespedCreado);
            await _unitOfWork.Commit();
            return huespedCreado.Id;
        }
    }
}
