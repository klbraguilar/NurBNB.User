using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NurBNB.Usuario.Infrastructure.EF.ReadModel;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.EF.Contexts;

public class ReadDbContext : DbContext
{
    public virtual DbSet<UsuarioReadModel>? Usuario { set; get; }
    public virtual DbSet<HuespedReadModel>? Huesped { set; get; }
    public virtual DbSet<StaffReadModel>? Staff { set; get; }

    public virtual DbSet<CheckInReadModel>? CheckIn { set; get; }

    public virtual DbSet<CheckOutReadModel>? CheckOut { set; get; }
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    public ReadDbContext()
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        
    }
}
