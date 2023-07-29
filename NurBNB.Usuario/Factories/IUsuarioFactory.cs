using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Factories
{
    public interface IUsuarioFactory
    {
        User Crear(string usuario, string correo, string contrasenha);
    }
}
