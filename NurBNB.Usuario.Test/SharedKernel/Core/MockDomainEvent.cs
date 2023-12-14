using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.SharedKernel.Core
{
    public record MockDomainEvent : DomainEvent
    {
        public MockDomainEvent(DateTime occurredOn) : base(occurredOn) { }

        public MockDomainEvent() : base(DateTime.UtcNow)
        {
        }

    }
}
