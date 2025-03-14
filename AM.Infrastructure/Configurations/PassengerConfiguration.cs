using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName, Full =>
            {
                Full.Property(f => f.FirstName)
                    .HasColumnName("PassFirstName");
                Full.Property(f => f.LastName)
                    .HasColumnName("PassLastName")
                    .IsRequired();
            });
        }
    }
}
