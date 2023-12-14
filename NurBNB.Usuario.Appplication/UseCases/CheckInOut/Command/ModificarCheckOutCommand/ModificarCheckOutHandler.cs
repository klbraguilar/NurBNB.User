using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Primitives;
using NurBNB.Usuario.Appplication.Services;
using NurBNB.Usuario.Domain.Factories;
using NurBNB.Usuario.Domain.Model.CheckInOut;
using NurBNB.Usuario.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.ModificarCheckOutCommand
{
    public class ModificarCheckOutHandler : IRequestHandler<ModificarCheckOutCommand, Guid>
    {
        private ICheckOutRepository _checkOutRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ModificarCheckOutHandler(ICheckOutRepository checkOutRepository, ICheckOutFactory checkOutFactory, IUnitOfWork unitOfWork)
        {
            _checkOutRepository = checkOutRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(ModificarCheckOutCommand request, CancellationToken cancellationToken)
        {
            CheckOut recordToUpdate = await _checkOutRepository.FindByIdAsync(request.Id);
            Calificacion VariableName = (Calificacion)Enum.Parse(typeof(Calificacion), request.calificacion);
            if (recordToUpdate == null)
            {
                return default;
            }
            else
            {
                recordToUpdate.Editar(recordToUpdate.Id,
                    recordToUpdate.GuestId,
                    recordToUpdate.ReservaId,
                    VariableName,
                    recordToUpdate.FechaSalida,
                    request.comentario);
                await _checkOutRepository.UpdateAsync(recordToUpdate);
                await _unitOfWork.Commit();
                return recordToUpdate.Id;
            }
        }
    }
}
