﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.EF.ReadModel
{
    [Table("huesped")]
    public class HuespedReadModel
    {
        [Key]
        [Column("guestId")]
        public Guid Id { get; set; }

        [Column("name")]
        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        [Column("lastName")]
        [StringLength(250)]
        [Required]
        public string LastName { get; set; }

        [Column("phoneNumber")]
        [StringLength(250)]
        [Required]
        public string PhoneNumber { get; set; }

        [Column("usuarioId")]
        public Guid UsuarioId { get; set; }
        public UsuarioReadModel Usuario { get; set; }
    }
}
