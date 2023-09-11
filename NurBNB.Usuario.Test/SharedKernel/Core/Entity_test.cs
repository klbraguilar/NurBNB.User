using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.SharedKernel.Core
{
    public class Entity_test
    {
        [Fact]
        public void Entity_AddDomainEvent_AddsEventToList()
        {
            // Arrange
            var entity = new MockEntity();
            var domainEvent = new MockDomainEvent();

            // Act
            entity.AddDomainEvent(domainEvent);

            // Assert
            Assert.Contains(domainEvent, entity.DomainEvents);
        }

        [Fact]
        public void Entity_ClearDomainEvents_RemovesAllEvents()
        {
            // Arrange
            var entity = new MockEntity();
            var domainEvent1 = new MockDomainEvent();
            var domainEvent2 = new MockDomainEvent();

            entity.AddDomainEvent(domainEvent1);
            entity.AddDomainEvent(domainEvent2);

            // Act
            entity.ClearDomainEvents();

            // Assert
            Assert.Empty(entity.DomainEvents);
        }

        //[Fact]
        //public void Entity_CheckRule_ThrowsExceptionForInvalidRule()
        //{
        //    // Arrange
        //    var entity = new MockEntity();
        //    var invalidRule = new MockInvalidRule();

        //    // Act & Assert
        //    Assert.Throws<BussinessRuleValidationException>(() => entity.CheckRule(invalidRule));
        //}

        //[Fact]
        //public void Entity_CheckRule_DoesNotThrowExceptionForValidRule()
        //{
        //    // Arrange
        //    var entity = new MockEntity();
        //    var validRule = new MockValidRule();

        //    // Act & Assert
        //    entity.CheckRule(validRule); // No debe arrojar excepción
        //}
    }
}
