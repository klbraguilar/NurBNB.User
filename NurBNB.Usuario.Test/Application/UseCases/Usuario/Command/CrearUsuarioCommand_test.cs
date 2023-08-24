using Moq;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearUsuario;
using NurBNB.Usuario.Domain.Factories;
using NurBNB.Usuario.Domain.Model.Users;
using NurBNB.Usuario.Domain.Repositories;
using Restaurant.SharedKernel.Core;

namespace NurBNB.Usuario.Test.Application.UseCases.Usuario.Command
{
    public class CrearUsuarioCommand_test 
    {
        Mock<IUsuarioRepository> _usuarioRepository;
        Mock<IUsuarioFactory> _usuarioFactory;
        Mock<IUnitOfWork> _unitOfWork;

        public CrearUsuarioCommand_test()
        {
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _usuarioFactory = new Mock<IUsuarioFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void CreacionValida()
        {

            User usuario = new User("UsuarioTest", "correo_test@gmail.com", "123456");
            _usuarioFactory.Setup(_usuarioFactory => _usuarioFactory.Crear("UsuarioTest", "correo_test@gmail.com", "123456"))
                .Returns(usuario);
            
            CrearUsuarioHandler crearUsuarioHandler = new CrearUsuarioHandler(
                    _usuarioRepository.Object,
                    _usuarioFactory.Object,
                    _unitOfWork.Object
                ) ;
            var tcs = new CancellationTokenSource(1000);
            CrearUsuarioCommand usuarioCommand = new CrearUsuarioCommand { 
                UserName=usuario.Username, 
                Email=usuario.Email, 
                Password=usuario.Password};
            var actionResult = crearUsuarioHandler.Handle(usuarioCommand, tcs.Token);
            Assert.NotNull(actionResult);
            Assert.True(actionResult.IsCompletedSuccessfully);
        }
    }
}