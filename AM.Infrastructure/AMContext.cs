using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using AM.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using TicketConfiguration = AM.Infrastructure.Configurations.TicketConfiguration;

namespace AM.Infrastructure
{
    public class AMContext: DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                Initial Catalog=AsmaZehiDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        //question8
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //first method
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            ////second method
            //modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName, Full => { 
            //Full.Property(f => f.FirstName)
            //    .HasColumnName("PassFirstName")
            //    .HasMaxLength(30);
            //    Full.Property(f => f.LastName)
            //    .HasColumnName("PassLastName")
            //    .IsRequired();
            //});
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.Entity<Traveller>().ToTable("Travellers");
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.ApplyConfiguration(new TicketConfiguration());


        }
        //question9
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                .HaveColumnType("date");
        }
    }
}
