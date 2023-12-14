
using MassTransit;
using MediatR;
using NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.CrearCheckInCommand;
using NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.CrearCheckOutCommand;
using NurBNB.Usuario.Domain.Model.CheckInOut;
using NURBNB.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.MassTransit.Consumers
{
    public class ReservaRegistradaConsumer : IConsumer<ReservaRegistrada>
    {
        private readonly IMediator _mediator;

        public ReservaRegistradaConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ReservaRegistrada> context)
        {
            var message = context.Message;
            var incommand = new CrearCheckInCommand
            {
                guestId = message.GuestId,
                reservaId = message.reservaId,
                contacto = "",
                fechaLlegada = message.fechaLlegada,
            };

            var outcommand = new CrearCheckOutCommand
            {
                guestId = message.GuestId,
                reservaId = message.reservaId,
                calificacion = Calificacion.uno,
                comentario = "",
            };

            await _mediator.Send(incommand);
            await _mediator.Send(outcommand);

        }
    }
}
