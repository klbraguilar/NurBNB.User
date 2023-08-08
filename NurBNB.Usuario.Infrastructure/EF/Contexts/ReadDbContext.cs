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

internal class ReadDbContext : DbContext
{
    public virtual DbSet<UsuarioReadModel> Usuario { set; get; }
    public virtual DbSet<HuespedReadModel> Huesped { set; get; }
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        
    }
}
