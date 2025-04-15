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
    public class FactureConfiguration : IEntityTypeConfiguration<Facture>
    {
        public void Configure(EntityTypeBuilder<Facture> builder)
        {
            // Clé primaire composée
            builder.HasKey(f => new { f.CompteurReference, f.PeriodeId, f.Date });

            // Relation vers Compteur
            builder.HasOne(f => f.Compteur)
                   .WithMany(c => c.Factures)
                   .HasForeignKey(f => f.CompteurReference)
                   .HasConstraintName("FK_Factures_Compteurs_CompteurKey")
                   .OnDelete(DeleteBehavior.Cascade);

            // Relation vers Période
            builder.HasOne(f => f.Periode)
                   .WithMany(p => p.Factures)
                   .HasForeignKey(f => f.PeriodeId)
                   .HasConstraintName("FK_Factures_Periodes_PeriodeKey1")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
