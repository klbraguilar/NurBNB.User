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
    public class GetGuestListHandler : IRequestHandler<GetGuestListQuery, ICollection<GuestDto>>
    {
        private readonly DbSet<HuespedReadModel> _huesped;

        public GetGuestListHandler(ReadDbContext huesped)
        {
            _huesped = huesped.Huesped;
        }

        public async Task<ICollection<GuestDto>> Handle(GetGuestListQuery request, CancellationToken cancellationToken)
        {
            var query = _huesped.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(x => x.Name.Contains(request.SearchTerm));
            }

            return await query.Select(guest =>
                new GuestDto
                {
                    Id = guest.Id,
                    Name = guest.Name,
                    LastName = guest.LastName,
                    PhoneNumber = guest.PhoneNumber,
                    UserName = guest.Usuario.UserName
                }).ToListAsync(cancellationToken);
        }
    }
}
