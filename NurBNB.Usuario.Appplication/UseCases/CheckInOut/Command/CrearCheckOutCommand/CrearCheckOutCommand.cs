using MediatR;
using NurBNB.Usuario.Domain.Model.CheckInOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.CrearCheckOutCommand
{
    public class CrearCheckOutCommand : IRequest<Guid>
    {
        public Guid guestId { get; set; }
        public Guid reservaId { get; set; }
        public DateTime fechaSalida { get; set; }
        public Calificacion calificacion { get; set; }
        public string comentario { get; set; }
    }
}
