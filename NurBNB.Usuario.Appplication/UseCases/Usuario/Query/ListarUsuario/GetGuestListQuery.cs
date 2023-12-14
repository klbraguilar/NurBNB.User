using MediatR;
using NurBNB.Usuario.Appplication.DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.UseCases.Usuario.Query.ListarUsuario
{
    public class GetGuestListQuery : IRequest<ICollection<GuestDto>>
    {
        public string SearchTerm { get; set; }
    }
}
