using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Factories
{
    public class UsuarioFactory : IUsuarioFactory
    {
        public User Crear(string usuario, string correo, string contrasenha)
        {
            return new User(usuario, correo, contrasenha);
        }
    }
}
