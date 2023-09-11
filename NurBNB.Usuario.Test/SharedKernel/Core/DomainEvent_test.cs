using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.SharedKernel.Core
{
    public class DomainEvent_test
    {
        [Fact]
        public void DomainEvent_Creation_SetsPropertiesCorrectly()
        {
            // Arrange
            var occurredOn = DateTime.UtcNow;

            // Act
            var domainEvent = new MockDomainEvent(occurredOn);

            // Assert
            Assert.Equal(occurredOn, domainEvent.OccuredOn);
            Assert.NotEqual(Guid.Empty, domainEvent.Id);
            Assert.False(domainEvent.Consumed);
        }

        [Fact]
        public void MarkAsConsumed_SetsConsumedFlagToTrue()
        {
            // Arrange
            MockDomainEvent domainEvent = new MockDomainEvent(DateTime.UtcNow);

            // Act
            domainEvent.MarkAsConsumed();

            // Assert
            Assert.True(domainEvent.Consumed);
        }

    }
}
