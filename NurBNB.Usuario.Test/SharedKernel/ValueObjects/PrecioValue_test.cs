using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.SharedKernel.ValueObjects
{
    public class PrecioValue_test
    {
        [Theory]
        [InlineData(0)]
        [InlineData(10.5)]
        [InlineData(1000)]
        public void PrecioValue_CreationWithValidValue_SetsValueCorrectly(decimal validValue)
        {
            // Act
            var precioValue = new PrecioValue(validValue);

            // Assert
            Assert.Equal(validValue, precioValue.Value);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10.5)]
        [InlineData(-1000)]
        public void PrecioValue_CreationWithInvalidValue_ThrowsException(decimal invalidValue)
        {
            // Act & Assert
            Assert.Throws<BussinessRuleValidationException>(() => new PrecioValue(invalidValue));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10.5)]
        [InlineData(1000)]
        public void PrecioValue_ImplicitConversionToDecimal_ReturnsValue(decimal validValue)
        {
            // Arrange
            var precioValue = new PrecioValue(validValue);

            // Act
            decimal result = precioValue;

            // Assert
            Assert.Equal(validValue, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10.5)]
        [InlineData(1000)]
        public void PrecioValue_ImplicitConversionFromDecimal_CreatesValue(decimal validValue)
        {
            // Act
            PrecioValue precioValue = validValue;

            // Assert
            Assert.Equal(validValue, precioValue.Value);
        }
    }
}
