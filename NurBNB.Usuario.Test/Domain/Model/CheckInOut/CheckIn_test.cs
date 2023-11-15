using NurBNB.Usuario.Domain.Model.CheckInOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Domain.Model.CheckInOut
{
    public class CheckIn_test
    {
        [Fact]
        public void CheckIn_Creation_SetsPropertiesCorrectly()
        {
            // Arrange
            var guestId = Guid.NewGuid();
            var contacto = "John Doe";
            var reservaId = Guid.NewGuid();

            // Act
            var checkIn = new CheckIn(guestId, reservaId, contacto);

            // Assert
            Assert.Equal(guestId, checkIn.GuestId);
            Assert.Equal(contacto, checkIn.Contacto);
            Assert.Equal(DateTime.Now.Date, checkIn.FechaLlegada.Date, TimeSpan.FromSeconds(1)); // Comprueba la fecha con un margen de 1 segundo
        }

        [Fact]
        public void CheckIn_Creation_SetsIdToNotEmptyGuid()
        {
            // Arrange
            var guestId = Guid.NewGuid();
            var contacto = "John Doe";
            var reservaId = Guid.NewGuid();

            // Act
            var checkIn = new CheckIn(guestId, reservaId, contacto);

            // Assert
            Assert.NotEqual(Guid.Empty, checkIn.Id);
        }

        public void CheckIn_Equals_SameValuesAreEqual()
        {
            // Arrange
            Guid guestId = Guid.NewGuid();
            string contacto = "Contacto válido";
            var reservaId = Guid.NewGuid();
            // Act
            var checkIn1 = new CheckIn(guestId, reservaId, contacto);
            var checkIn2 = new CheckIn(guestId, reservaId, contacto);

            // Assert
            Assert.Equal(checkIn1, checkIn2);
            Assert.Equal(checkIn1.GetHashCode(), checkIn2.GetHashCode());
        }

        [Fact]
        public void CheckIn_FechaLlegada_IsCurrentOrEarlier()
        {
            // Arrange
            Guid guestId = Guid.NewGuid();
            var reservaId = Guid.NewGuid();
            string contacto = "Contacto válido";

            // Act
            var checkIn = new CheckIn(guestId, reservaId, contacto);

            // Assert
            Assert.True(checkIn.FechaLlegada <= DateTime.Now);
        }

    }
}
