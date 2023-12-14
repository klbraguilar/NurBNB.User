using MediatR;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearGuests;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.CrearCheckInCommand
{
    public class CrearCheckInCommand : IRequest<Guid>
    {
        public Guid guestId { get; set; }
        public Guid reservaId { get; set; }
        public string contacto { get; set; }
        public DateTime fechaLlegada { get; set; }
    }
}
