using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.EF.Config
{
    internal class HuespedConfig : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable("huesped");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("guestId");

            builder.Property(x => x.Name)
                .HasColumnName("name");

            builder.Property(x => x.Name)
                .HasColumnName("lastName");

            builder.Property(x => x.UserID)
                .HasColumnName("userId");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
