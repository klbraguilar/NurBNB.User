using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.SharedKernel.Rules
{
    public class NotNegativeRule_test
    {
        [Theory]
        [InlineData(0)]
        [InlineData(10.5)]
        [InlineData(1000)]
        public void NotNegativeRule_ValidValues_ReturnsTrue(decimal validValue)
        {
            // Act
            var notNegativeRule = new NotNegativeRule(validValue);

            // Assert
            Assert.True(notNegativeRule.IsValid());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10.5)]
        [InlineData(-1000)]
        public void NotNegativeRule_NegativeValues_ReturnsFalse(decimal invalidValue)
        {
            // Act
            var notNegativeRule = new NotNegativeRule(invalidValue);

            // Assert
            Assert.False(notNegativeRule.IsValid());
        }

        [Fact]
        public void NotNegativeRule_Message_ReturnsCorrectMessage()
        {
            // Arrange
            var value = -1;
            var notNegativeRule = new NotNegativeRule(value);

            // Act
            var message = notNegativeRule.Message;

            // Assert
            Assert.Equal("Value cannot be negative", message);
        }
    }
}
