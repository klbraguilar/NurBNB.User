using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.SharedKernel.Core
{
    public class BusinessRuleValidationException_test
    {
        [Fact]
        public void BussinessRuleValidationException_WithIBussinessRule_SetsPropertiesCorrectly()
        {
            // Arrange
            var brokenRule = new SomeBussinessRuleImplementation();

            // Act
            var exception = new BussinessRuleValidationException(brokenRule);

            // Assert
            Assert.Equal(brokenRule, exception.BrokenRule);
            Assert.Equal(brokenRule.Message, exception.Details);
        }

        [Fact]
        public void BussinessRuleValidationException_WithMessage_SetsPropertiesCorrectly()
        {
            // Arrange
            var message = "Some error message";

            // Act
            var exception = new BussinessRuleValidationException(message);

            // Assert
            Assert.Null(exception.BrokenRule);
            Assert.Equal(message, exception.Details);
        }

        public class SomeBussinessRuleImplementation : IBussinessRule
        {
            public string Message => "Some rule message";

            public bool IsBroken() => true;

            public bool IsValid()
            {
                return true;
            }
        }
    }
}
