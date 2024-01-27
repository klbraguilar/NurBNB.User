using NurBNB.Usuario.Domain.Factories;
using NurBNB.Usuario.Domain.Model.CheckInOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Domain.Factory
{
    public class CheckOutFactory_test
    {
        [Fact]
        public void CheckOutFactory_Crear_ReturnsCheckOutWithCorrectProperties()
        {
            // Arrange
            var factory = new CheckOutFactory();
            var guestId = Guid.NewGuid();
            var reservaId = Guid.NewGuid();
            var calificacion = Calificacion.cuatro;
            var fechaSalida = DateTime.Now;
            var comentario = "Comentario de prueba";

            // Act
            var checkOut = factory.Crear(guestId, reservaId, calificacion, fechaSalida, comentario);

            // Assert
            Assert.NotNull(checkOut);
            Assert.IsType<CheckOut>(checkOut);
            Assert.Equal(guestId, checkOut.GuestId);
            Assert.Equal(reservaId, checkOut.ReservaId);
            Assert.Equal(calificacion, checkOut.Calificacion);
            Assert.Equal(fechaSalida, checkOut.FechaSalida);
            Assert.Equal(comentario, checkOut.ComentarioHuesped);
        }

        // Puedes agregar más pruebas según los requisitos específicos de tu aplicación

        [Fact]
        public void CheckOutFactory_Crear_ReturnsUniqueCheckOutInstances()
        {
            // Arrange
            var factory = new CheckOutFactory();
            var guestId = Guid.NewGuid();
            var reservaId = Guid.NewGuid();
            var calificacion = Calificacion.cinco;
            var fechaSalida = DateTime.Now.AddDays(1); // Future date
            var comentario = "Otro comentario de prueba";

            // Act
            var checkOut1 = factory.Crear(guestId, reservaId, calificacion, fechaSalida, comentario);
            var checkOut2 = factory.Crear(guestId, reservaId, calificacion, fechaSalida, comentario);

            // Assert
            Assert.NotEqual(checkOut1, checkOut2);
        }
    }
}
