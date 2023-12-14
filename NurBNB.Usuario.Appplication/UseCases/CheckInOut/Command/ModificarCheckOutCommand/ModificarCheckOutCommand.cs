using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.ModificarCheckOutCommand
{
    public class ModificarCheckOutCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string comentario { get; set; }
        public string calificacion { get; set; }
    }
}
