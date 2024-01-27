using NurBNB.Usuario.Domain.Factories;
using NurBNB.Usuario.Domain.Model.CheckInOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Domain.Factory
{
    public class CheckInFactory_test
    {
        [Fact]
        public void CheckInFactory_Crear_ReturnsCheckInWithCorrectProperties()
        {
            // Arrange
            var factory = new CheckInFactory();
            var guestId = Guid.NewGuid();
            var reservaId = Guid.NewGuid();
            var contacto = "John Doe";
            var fechaLlegada = DateTime.Now;

            // Act
            var checkIn = factory.Crear(guestId, reservaId, contacto, fechaLlegada);

            // Assert
            Assert.NotNull(checkIn);
            Assert.IsType<CheckIn>(checkIn);
            Assert.Equal(guestId, checkIn.GuestId);
            Assert.Equal(reservaId, checkIn.ReservaId);
            Assert.Equal(contacto, checkIn.Contacto);
            Assert.Equal(fechaLlegada, checkIn.FechaLlegada);
        }

        // Puedes agregar más pruebas según los requisitos específicos de tu aplicación

        [Fact]
        public void CheckInFactory_Crear_ReturnsUniqueCheckInInstances()
        {
            // Arrange
            var factory = new CheckInFactory();
            var guestId = Guid.NewGuid();
            var reservaId = Guid.NewGuid();
            var contacto = "Jane Doe";
            var fechaLlegada = DateTime.Now;

            // Act
            var checkIn1 = factory.Crear(guestId, reservaId, contacto, fechaLlegada);
            var checkIn2 = factory.Crear(guestId, reservaId, contacto, fechaLlegada);

            // Assert
            Assert.NotEqual(checkIn1, checkIn2);
        }
    }
}
