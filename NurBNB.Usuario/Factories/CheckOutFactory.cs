using NurBNB.Usuario.Domain.Model.CheckInOut;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Factories
{
    public class CheckOutFactory : ICheckOutFactory
    {
        public CheckOut Crear(Guid guestId, Guid reservaId, Calificacion calificacion, DateTime fechaSalida, string comentario)
        {
            return new CheckOut(guestId, reservaId, calificacion, fechaSalida, comentario);
        }
    }
}
