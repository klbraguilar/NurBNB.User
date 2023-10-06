using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Repositories
{
    public interface IStaffRepository : IRepositoryEntity<Staff, Guid>
    {
        Task UpdateAsync(Guest guest);
    }
}
