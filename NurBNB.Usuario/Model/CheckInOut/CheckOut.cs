
using NurBNB.Usuario.Domain.Model.CheckInOut.Events;
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
        public Guid ReservaId { get; private set; }
        public string ComentarioHuesped { get; private set; }
        public DateTime FechaSalida { get; private set; }
        public Calificacion Calificacion { get; private set; }

        internal CheckOut(Guid guestId, Guid reservaId, Calificacion calificacion, DateTime fechaSalida, String comentario)
        {
            Id = new Guid();
            GuestId = guestId;
            ReservaId= reservaId;
            Calificacion= calificacion;
            FechaSalida = fechaSalida;
            ComentarioHuesped= comentario;
        }

        public static CheckOut Create(Guid guestId, Guid reservaId, Calificacion calificacion, DateTime fechaSalida, String comentario)
        {
            var obj =  new CheckOut(guestId, reservaId, calificacion, fechaSalida, comentario);
            return obj;
        }

        public void Editar(Guid id, Guid guestId, Guid reservaId, Calificacion calificacion, DateTime fechaSalida, String comentario)
        {
            Id = id;
            GuestId = guestId;
            ReservaId = reservaId;
            Calificacion = calificacion;
            FechaSalida = fechaSalida;
            ComentarioHuesped = comentario;
            AddDomainEvent(new CheckOutRealizado(Id, GuestId, ReservaId, Calificacion, FechaSalida, ComentarioHuesped));
        }

        //public static CheckOut Update(Guid id, Guid guestId, Guid reservaId, Calificacion calificacion, DateTime fechaSalida, String comentario)
        //{
        //    obj.Editar(id, guestId, reservaId, calificacion, fechaSalida, comentario);
        //    AddDomainEvent(new CheckOutRealizado(
        //        obj.Id,
        //        obj.GuestId,
        //        obj.ReservaId,
        //        obj.Calificacion,
        //        obj.FechaSalida,
        //        obj.ComentarioHuesped));
        //    return obj;
        //}

        public CheckOut()
        {

        }
    }
}
