using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Model.Users
{
    public class Staff : Entity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Staff(string name, string lastName, string phoneNumber, Guid usuarioId)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            UsuarioId = usuarioId;
        }
    }
}
