using Microsoft.EntityFrameworkCore;
using NurBNB.Usuario.Domain.Model.Users;
using NurBNB.Usuario.Infrastructure.EF.Config;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.EF.Contexts
{
    internal class WriteDBContext : DbContext
    {
        public virtual DbSet<User> User { set; get; }
        public virtual DbSet<Guest> Guest { set; get; }

        public WriteDBContext(DbContextOptions<WriteDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var usuarioConfig = new UsuarioConfig();
            modelBuilder.ApplyConfiguration<User>(usuarioConfig);

            modelBuilder.Ignore<DomainEvent>();
            //modelBuilder.Ignore<TransaccionConfirmada>();
        }
    }
}
