using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.EF.ReadModel
{
    [Table("checkout")]
    public class CheckOutReadModel
    {
        [Key]
        [Column("outId")]
        public Guid Id { get; set; }

        [Column("comentario")]
        [StringLength(250)]
        public string? ComentarioHuesped { get; set; }

        [Column("fechaSalida")]
        [DataType(DataType.DateTime)]
        public DateTime FechaSalida { get; set; }

        [Column("calificacion")]
        [StringLength(250)]
        public string? Calificacion { get; set; }

        [Column("guestId")]
        public Guid GuestId { get; set; }
        public HuespedReadModel Guest { get; set; }

        [Column("reservaId")]
        public Guid ReservaId { get; set; }
    }
}
