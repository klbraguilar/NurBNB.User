using Microsoft.EntityFrameworkCore;
using NurBNB.Usuario.Domain.Model.Users;
using NurBNB.Usuario.Domain.Repositories;
using NurBNB.Usuario.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.EF.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly WriteDBContext _dbContext;

        public UsuarioRepository(WriteDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(User obj)
        {
            await _dbContext.User.AddAsync(obj);
        }

        public async Task<User?> FindByIdAsync(Guid id)
        {
            return await _dbContext.User.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(User user)
        {
            _dbContext.User.Update(user);
            return Task.CompletedTask;
        }
    }
}
