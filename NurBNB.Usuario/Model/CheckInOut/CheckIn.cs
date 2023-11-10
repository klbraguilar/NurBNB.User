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

        public CheckIn(Guid guestId, string contacto)
        {
            Id = Guid.NewGuid();
            GuestId = guestId;
            Contacto = contacto;
            FechaLlegada = DateTime.Now;
        }

        public CheckIn()
        {
        }
    }
}
