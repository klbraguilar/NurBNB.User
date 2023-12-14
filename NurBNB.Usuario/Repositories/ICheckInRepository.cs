using NurBNB.Usuario.Domain.Model.CheckInOut;
using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Repositories
{
    public interface ICheckInRepository : IRepositoryEntity<CheckIn, Guid>
    {
        Task UpdateAsync(CheckIn checkIn);
    }
}
