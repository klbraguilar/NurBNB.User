using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Model.CheckInOut
{
    public class CheckIn : Entity
    {
        public Guid GuestId { get; private set; }
        public Guid ReservaId { get; private set; }
        public string Contacto{ get; private set; }
        public DateTime FechaLlegada { get; private set; }

        public CheckIn(Guid guestId, Guid reservaId, string contacto, DateTime fechaLlegada)
        {
            Id = Guid.NewGuid();
            GuestId = guestId;
            ReservaId= reservaId;
            Contacto = contacto;
            FechaLlegada = fechaLlegada;
        }

        public CheckIn()
        {
        }
    }
}
