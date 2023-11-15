using NurBNB.Usuario.Domain.Model.CheckInOut;
using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NurBNB.Usuario.Domain.Factories
{
    public class CheckInFactory : ICheckInFactory
    {
        public CheckIn Crear(Guid guestId, Guid reservaId, string contacto)
        {
            return new CheckIn(guestId, reservaId, contacto);
        }
    }
}
