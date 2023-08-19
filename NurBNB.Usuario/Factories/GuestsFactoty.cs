using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Factories
{
    public class GuestsFactoty : IGuestsFactory
    {
        public Guest Crear(string name, string lastName, string phoneNumber, Guid userId)
        {
            return new Guest(name, lastName, phoneNumber, userId);
        }
    }
}
