
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Model.CheckInOut
{
    public class CheckOut : Entity
    {
        public Guid GuestId { get; private set; }
        public string ComentarioHuesped { get; private set; }
        public DateTime FechaSalida { get; private set; }
        public Calificacion Calificacion { get; private set; }

        public CheckOut(Guid guestId, Calificacion calificacion, String comentario)
        {
            Id = Guid.NewGuid();
            GuestId = guestId;
            Calificacion= calificacion;
            FechaSalida = DateTime.Now;
            ComentarioHuesped= comentario;
        }

        public CheckOut()
        {

        }
    }
}
