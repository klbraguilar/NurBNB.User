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
    public class StaffRepository : IStaffRepository
    {
        private readonly WriteDBContext _dbContext;

        public StaffRepository(WriteDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Staff staff)
        {
            await _dbContext.Staff.AddAsync(staff);
        }

        public async Task<Staff?> FindByIdAsync(Guid id)
        {
            return await _dbContext.Staff.FindAsync(id);
        }

        public Task UpdateAsync(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
