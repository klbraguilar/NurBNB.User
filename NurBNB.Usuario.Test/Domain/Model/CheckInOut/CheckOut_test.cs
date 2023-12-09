using NurBNB.Usuario.Domain.Model.CheckInOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.Domain.Model.CheckInOut
{
    public class CheckOut_test
    {
        [Fact]
        public void CheckOut_Creation_SetsPropertiesCorrectly()
        {
            // Arrange
            var guestId = Guid.NewGuid();
            var reservaId = Guid.NewGuid();
            var calificacion = Calificacion.tres;
            var fecha = DateTime.Now;
            var comentario = "Comentario de prueba";

            // Act
            var checkOut = new CheckOut(guestId, reservaId, calificacion, fecha, comentario);

            // Assert
            Assert.Equal(guestId, checkOut.GuestId);
            Assert.Equal(calificacion, checkOut.Calificacion);
            Assert.Equal(DateTime.Now.Date, checkOut.FechaSalida.Date, TimeSpan.FromSeconds(1)); // Comprueba la fecha con un margen de 1 segundo
            Assert.Equal(comentario, checkOut.ComentarioHuesped);
        }

        //[Fact]
        //public void CheckOut_Creation_SetsIdToNotEmptyGuid()
        //{
        //    // Arrange
        //    var guestId = Guid.NewGuid();
        //    var reservaId = Guid.NewGuid();
        //    var calificacion = Calificacion.cinco;
        //    var comentario = "Otro comentario de prueba";
        //    var fecha = DateTime.Now;

        //    // Act
        //    var checkOut = new CheckOut(guestId, reservaId, calificacion, fecha, comentario);

        //    // Assert
        //    Assert.NotEqual(Guid.Empty, checkOut.Id);
        //}
    }
}
