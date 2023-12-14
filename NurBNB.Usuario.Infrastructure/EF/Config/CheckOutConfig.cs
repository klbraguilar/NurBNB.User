using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NurBNB.Usuario.Domain.Model.CheckInOut;
using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.EF.Config
{
    public class CheckOutConfig : IEntityTypeConfiguration<CheckOut>
    {
        public void Configure(EntityTypeBuilder<CheckOut> builder)
        {
            builder.ToTable("checkout");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("outId");

            builder.Property(x => x.ComentarioHuesped)
                .HasColumnName("comentario");

            builder.Property(x => x.FechaSalida)
                .HasColumnName("fechaSalida");

            var calificacionConverter = new ValueConverter<Calificacion, string>(
            califValue => califValue.ToString(),
            calif => new Calificacion()
            );

            builder.Property(x => x.Calificacion)
             .HasConversion(calificacionConverter)
             .HasColumnName("calificacion");

            builder.Property(x => x.ReservaId)
                .HasColumnName("reservaId");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
