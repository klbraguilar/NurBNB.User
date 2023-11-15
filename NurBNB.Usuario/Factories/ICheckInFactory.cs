using NurBNB.Usuario.Domain.Model.CheckInOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Factories
{
    public interface ICheckInFactory
    {
        CheckIn Crear(Guid guestId, Guid reservaId, string contacto);
    }
}
