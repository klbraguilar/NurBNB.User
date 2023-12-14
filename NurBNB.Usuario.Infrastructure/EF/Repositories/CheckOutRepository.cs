using NurBNB.Usuario.Domain.Model.CheckInOut;
using NurBNB.Usuario.Domain.Repositories;
using NurBNB.Usuario.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.EF.Repositories
{
    public class CheckOutRepository : ICheckOutRepository
    {
        private readonly WriteDBContext _dbContext;

        public CheckOutRepository(WriteDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(CheckOut checkOut)
        {
            await _dbContext.CheckOut.AddAsync(checkOut);
        }

        public async Task<CheckOut?> FindByIdAsync(Guid id)
        {
            return await _dbContext.CheckOut.FindAsync(id);
        }

        public Task UpdateAsync(CheckOut checkOut)
        {
            _dbContext.CheckOut.Update(checkOut);
            return Task.CompletedTask;
        }
    }
}
