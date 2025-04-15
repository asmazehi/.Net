using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using AM.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        public DbSet<Compteur> Compteurs { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Periode> Periodes { get; set; }
        public DbSet<Abonne> Abonnes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=STEGAsmaZehi;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Appliquer configuration Fluent API
            modelBuilder.ApplyConfiguration(new FactureConfiguration());

            // Max length pour toutes les strings
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var prop in entity.GetProperties())
                {
                    if (prop.ClrType == typeof(string))
                        prop.SetMaxLength(200);
                }
            }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }
    }
}