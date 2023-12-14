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

namespace NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearEncargados
{
    public class CrearStaffHandler : IRequestHandler<CrearStaffCommand, Guid>
    {
        private IStaffRepository _staffRepository;
        private IStaffFactory _staffFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearStaffHandler(IStaffRepository staffRepository,
            IStaffFactory staffFactory, IUnitOfWork unitOfWork)
        {
            _staffRepository = staffRepository;
            _staffFactory = staffFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearStaffCommand request, CancellationToken cancellationToken)
        {

            Staff staffCreado = _staffFactory.Crear(request.Name, request.LastName, request.PhoneNumber, request.usuarioId);
            await _staffRepository.CreateAsync(staffCreado);
            await _unitOfWork.Commit();
            return staffCreado.Id;
        }
    }
}
