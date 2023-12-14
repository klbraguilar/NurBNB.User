using MediatR;
using Microsoft.EntityFrameworkCore;
using NurBNB.Usuario.Appplication.DTO.Usuarios;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Query.ListarUsuario;
using NurBNB.Usuario.Infrastructure.EF.Contexts;
using NurBNB.Usuario.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.UseCases.Usuario.Query
{
    public class GetStaffListHandler : IRequestHandler<GetStaffListQuery, ICollection<StaffDto>>
    {
        private readonly DbSet<StaffReadModel> _staff;

        public GetStaffListHandler(ReadDbContext staff)
        {
            _staff = staff.Staff;
        }

        public async Task<ICollection<StaffDto>> Handle(GetStaffListQuery request, CancellationToken cancellationToken)
        {
            var query = _staff.AsNoTracking();

            if (Guid.Empty != request.Id)
            {
                query = query.Where(x => x.Id == request.Id);
            }

            return await query.Select(staff =>
                new StaffDto
                {
                    Name = staff.Name,
                    LastName = staff.LastName,
                    PhoneNumber = staff.PhoneNumber,
                }).ToListAsync(cancellationToken);
        }
    }
}
