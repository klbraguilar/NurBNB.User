using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NurBNB.Usuario.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Infrastructure.EF.Config
{
    public class StaffConfig : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("staff");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("staffId");

            builder.Property(x => x.Name)
                .HasColumnName("name");

            builder.Property(x => x.LastName)
                .HasColumnName("lastName");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
