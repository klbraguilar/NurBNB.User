using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.EF.ReadModel
{
    [Table("usuario")]
    internal class UsuarioReadModel
    {
        [Key]
        [Column("userId")]
        public Guid Id { get; set; }

        [Column("userName")]
        [StringLength(250)]
        [Required]
        public string UserName { get; set; }

        [Column("email")]
        [StringLength(250)]
        [Required]
        public string Email { get; set; }

        [Column("password")]
        [StringLength(250)]
        [Required]
        public string Password { get; set; }
    }
}
