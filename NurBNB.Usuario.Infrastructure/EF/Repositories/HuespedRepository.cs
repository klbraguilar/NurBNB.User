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
    internal class HuespedRepository : IHuespedRepository
    {
        private readonly WriteDBContext _dbContext;

        public HuespedRepository(WriteDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Guest guest)
        {
            await _dbContext.Guest.AddAsync(guest);
        }

        public Task<Guest?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
