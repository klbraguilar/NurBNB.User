using Microsoft.EntityFrameworkCore;
using NurBNB.Usuario.Domain.Model.CheckInOut;
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
    public class CheckInRepository : ICheckInRepository
    {
        private readonly WriteDBContext _dbContext;

        public CheckInRepository(WriteDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(CheckIn checkIn)
        {
            await _dbContext.CheckIn.AddAsync(checkIn);
        }

        public async Task<CheckIn?> FindByIdAsync(Guid id)
        {
            return await _dbContext.CheckIn.FindAsync(id);
        }

        public Task UpdateAsync(CheckIn checkIn)
        {
            _dbContext.CheckIn.Update(checkIn);
            return Task.CompletedTask;
        }
    }
}
