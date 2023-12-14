using MediatR;
using NurBNB.Usuario.Appplication.DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.UseCases.Usuario.Query.ListarUsuario
{
    public class GetUserListQuery : IRequest<ICollection<UserDto>>
    {
        public string SearchTerm { get; set; }
    }
}
