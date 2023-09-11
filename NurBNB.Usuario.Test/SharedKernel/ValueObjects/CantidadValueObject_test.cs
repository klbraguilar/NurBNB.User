using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.SharedKernel.ValueObjects
{
    public class CantidadValueObject_test
    {
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(100)]
        public void CantidadValue_CreationWithValidValue_SetsValueCorrectly(int validValue)
        {
            // Act
            var cantidadValue = new CantidadValue(validValue);

            // Assert
            Assert.Equal(validValue, cantidadValue.Value);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        public void CantidadValue_CreationWithInvalidValue_ThrowsException(int invalidValue)
        {
            // Act & Assert
            Assert.Throws<BussinessRuleValidationException>(() => new CantidadValue(invalidValue));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(100)]
        public void CantidadValue_ImplicitConversionToInt_ReturnsValue(int validValue)
        {
            // Arrange
            var cantidadValue = new CantidadValue(validValue);

            // Act
            int result = cantidadValue;

            // Assert
            Assert.Equal(validValue, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(100)]
        public void CantidadValue_ImplicitConversionFromInt_CreatesValue(int validValue)
        {
            // Act
            CantidadValue cantidadValue = validValue;

            // Assert
            Assert.Equal(validValue, cantidadValue.Value);
        }
    }
}
