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
    public class UsuarioConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("usuarioId");

            builder.Property(x => x.Username)
                .HasColumnName("Username");

            var emailConverter = new ValueConverter<Email, string>(
            emailValue => emailValue.Value,
            email => new Email(email)
            );

            builder.Property(x => x.Email)
            .HasConversion(emailConverter)
            .HasColumnName("Email");

            builder.Property(x => x.Password)
                    .HasColumnName("Password");


            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
