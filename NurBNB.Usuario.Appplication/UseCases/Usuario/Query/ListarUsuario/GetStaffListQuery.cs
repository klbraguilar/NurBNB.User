using MediatR;
using NurBNB.Usuario.Appplication.DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.UseCases.Usuario.Query.ListarUsuario
{
    public class GetStaffListQuery : IRequest<ICollection<StaffDto>>
    {
        public Guid Id { get; set; }
    }
}
