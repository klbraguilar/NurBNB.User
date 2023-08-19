﻿
using NurBNB.Usuario.Domain.Model.Users;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Repositories
{
    public interface IHuespedRepository : IRepositoryEntity<Guest, Guid>
    {
        Task UpdateAsync(Guest guest);
    }
}