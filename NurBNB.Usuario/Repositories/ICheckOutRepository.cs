using NurBNB.Usuario.Domain.Model.CheckInOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Repositories
{
    public interface ICheckOutRepository : IRepositoryEntity<CheckOut, Guid>
    {
        Task UpdateAsync(CheckOut checkOut);
    }
}
