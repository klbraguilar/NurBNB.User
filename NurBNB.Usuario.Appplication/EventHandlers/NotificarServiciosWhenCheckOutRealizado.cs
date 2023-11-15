using MediatR;
using NurBNB.Usuario.Appplication.Services;
using NurBNB.Usuario.Domain.Model.CheckInOut.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.EventHandlers
{
    internal class NotificarServiciosWhenCheckOutRealizado : INotificationHandler<CheckOutRealizado>
    {
        private readonly IBusService _busService;

        public NotificarServiciosWhenCheckOutRealizado(IBusService busService)
        {
            _busService = busService;
        }

        public Task Handle(CheckOutRealizado notification, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }
    }
}
