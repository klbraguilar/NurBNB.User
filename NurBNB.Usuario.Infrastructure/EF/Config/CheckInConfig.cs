using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NurBNB.Usuario.Domain.Model.CheckInOut;
using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.EF.Config
{
    public class CheckInConfig : IEntityTypeConfiguration<CheckIn>
    {
        public void Configure(EntityTypeBuilder<CheckIn> builder)
        {
            builder.ToTable("checkin");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("inId");

            builder.Property(x => x.Contacto)
                .HasColumnName("contacto");

            builder.Property(x => x.FechaLlegada)
                .HasColumnName("fechaLlegada");

            builder.Property(x => x.ReservaId)
                .HasColumnName("reservaId");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
