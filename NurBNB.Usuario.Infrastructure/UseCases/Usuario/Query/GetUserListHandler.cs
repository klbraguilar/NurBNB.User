using MediatR;
using Microsoft.EntityFrameworkCore;
using NurBNB.Usuario.Appplication.DTO.Usuarios;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Query.ListarUsuario;
using NurBNB.Usuario.Domain.Model.Users;
using NurBNB.Usuario.Infrastructure.EF.Contexts;
using NurBNB.Usuario.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.UseCases.Usuario.Query
{
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, ICollection<UserDto>>
    {
        private readonly DbSet<UsuarioReadModel> _users;

        public GetUserListHandler(ReadDbContext users)
        {
            _users = users.Usuario;
        }

        public async Task<ICollection<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var query = _users.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(x => x.UserName.Contains(request.SearchTerm));
            }

            return await query.Select(user =>
                new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Password = user.Password
                }).ToListAsync(cancellationToken);
        }
    }
}
