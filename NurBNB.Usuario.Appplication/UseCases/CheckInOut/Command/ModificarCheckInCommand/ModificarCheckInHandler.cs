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

namespace NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.ModificarCheckInCommand
{
    public class ModificarCheckInHandler : IRequestHandler<ModificarCheckInCommand, Guid>
    {
        private ICheckInRepository _checkInRepository;
        private ICheckInFactory _checkInFactory;
        private readonly IUnitOfWork _unitOfWork;

        public ModificarCheckInHandler(ICheckInRepository checkInRepository, IUnitOfWork unitOfWork)
        {
            _checkInRepository = checkInRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(ModificarCheckInCommand request, CancellationToken cancellationToken)
        {
            CheckIn recordToUpdate = await _checkInRepository.FindByIdAsync(request.Id);
            if (recordToUpdate == null)
            {
                return default;
            }
            else
            {
                recordToUpdate.GetType().GetProperty("Contacto").SetValue(recordToUpdate, request.contacto, null);
                await _checkInRepository.UpdateAsync(recordToUpdate);
                _unitOfWork.Commit();
                return  recordToUpdate.Id;
            }

        }
    }
}
