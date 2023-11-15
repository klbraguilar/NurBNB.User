using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.ModificarCheckInCommand
{
    public class ModificarCheckInCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        //public Guid GuestId { get; set; }
        //public Guid ReservaId { get; set; }
        public string contacto { get; set; }
    }
}
