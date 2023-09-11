using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Factories
{
    public class StaffFactory : IStaffFactory
    {
        public Staff Crear(string name, string lastName, string phoneNumber, Guid usuarioId)
        {
            return new Staff(name, lastName, phoneNumber, usuarioId);
        }
    }
}
