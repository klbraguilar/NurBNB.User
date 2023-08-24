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

namespace NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearUsuario
{
    public class CrearUsuarioHandler : IRequestHandler<CrearUsuarioCommand, Guid>
    {
        private IUsuarioRepository _usuarioRepository;
        private IUsuarioFactory _usuarioFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearUsuarioHandler(IUsuarioRepository usuarioRepository, 
            IUsuarioFactory usuarioFactory, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioFactory = usuarioFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            User usuarioCreado = _usuarioFactory.Crear(request.UserName, request.Email, request.Password);
            await _usuarioRepository.CreateAsync(usuarioCreado);
            await _unitOfWork.Commit();
            return usuarioCreado.Id;
        }
    }
}
