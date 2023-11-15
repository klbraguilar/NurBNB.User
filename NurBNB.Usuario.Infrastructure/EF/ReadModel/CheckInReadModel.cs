using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.EF.ReadModel
{
    [Table("checkin")]
    public class CheckInReadModel
    {
        [Key]
        [Column("inId")]
        public Guid Id { get; set; }

        [Column("contacto")]
        [StringLength(250)]
        public string? Contacto { get; set; }

        [Column("fechaLlegada")]
        [DataType(DataType.DateTime)]
        public DateTime FechaLlegada { get; set; }

        [Column("guestId")]
        public Guid GuestId { get; set; }
        public HuespedReadModel Guest { get; set; }

        [Column("reservaId")]
        public Guid ReservaId { get; set; }
    }
}
