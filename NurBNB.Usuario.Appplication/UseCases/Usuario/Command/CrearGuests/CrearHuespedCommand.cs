using MediatR;
using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearGuests
{
    public class CrearHuespedCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Guid userId { get; set; }

        public User user { get; set; }
    }
}
