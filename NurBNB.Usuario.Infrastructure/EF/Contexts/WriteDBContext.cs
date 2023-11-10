using Microsoft.EntityFrameworkCore;
using NurBNB.Usuario.Domain.Model.CheckInOut;
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
    public class WriteDBContext : DbContext
    {
        public virtual DbSet<User> User { set; get; }
        public virtual DbSet<Guest> Guest { set; get; }

        public virtual DbSet<Staff> Staff { set; get; }
        public virtual DbSet<CheckIn> CheckIn { set; get; }
        public virtual DbSet<CheckOut> CheckOut { set; get; }

        public WriteDBContext(DbContextOptions<WriteDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var usuarioConfig = new UsuarioConfig();
            modelBuilder.ApplyConfiguration<User>(usuarioConfig);

            var huespedConfig = new HuespedConfig();
            modelBuilder.ApplyConfiguration<Guest>(huespedConfig);

            var staffConfig = new StaffConfig();
            modelBuilder.ApplyConfiguration<Staff>(staffConfig);

            var checkInConfig = new CheckInConfig();
            modelBuilder.ApplyConfiguration<CheckIn>(checkInConfig);

            var checkOutConfig = new CheckOutConfig();
            modelBuilder.ApplyConfiguration<CheckOut>(checkOutConfig);

            modelBuilder.Ignore<DomainEvent>();
            //modelBuilder.Ignore<TransaccionConfirmada>();
        }
    }
}
