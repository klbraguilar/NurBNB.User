using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.SharedKernel.Rules
{
    public class NotNullRule_test
    {
        [Fact]
        public void NotNullRule_NotNullValue_ReturnsTrue()
        {
            // Arrange
            object validValue = new object();
            var notNullRule = new NotNullRule(validValue);

            // Act
            var isValid = notNullRule.IsValid();

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void NotNullRule_NullValue_ReturnsFalse()
        {
            // Arrange
            object invalidValue = null;
            var notNullRule = new NotNullRule(invalidValue);

            // Act
            var isValid = notNullRule.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void NotNullRule_Message_ReturnsCorrectMessage()
        {
            // Arrange
            object invalidValue = null;
            var notNullRule = new NotNullRule(invalidValue);

            // Act
            var message = notNullRule.Message;

            // Assert
            Assert.Equal("Object cannot be null", message);
        }
    }
}
