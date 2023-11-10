using MassTransit;
using NurBNB.Usuario.Appplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.MassTransit
{
    internal class MassTransitBusService : IBusService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public MassTransitBusService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishAsync(object message)
        {
            await _publishEndpoint.Publish(message);
        }
    }
}
