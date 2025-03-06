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
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //conguration many to many
            builder.HasMany(f => f.ListPassengers)
                .WithMany(p => p.MyFlightss)
                .UsingEntity(j => j.ToTable("ReservationFlightPassenger"));
            //configuration one to many
            builder.HasOne(f => f.MyPlane)
                .WithMany(p => p.ListFlights)
                .HasForeignKey(f => f.PlaneId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
