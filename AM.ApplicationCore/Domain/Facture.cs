using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Facture
    {
        [Column("CompteurKey")]
        public string CompteurReference { get; set; }

        [Column("PeriodeKey")]
        public int PeriodeId { get; set; }

        public DateTime Date { get; set; }

        public double Montant { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Consommation doit être positive")]
        public double ConsommationKWH { get; set; }

        public bool Payement { get; set; }

        public virtual Compteur Compteur { get; set; }

        public virtual Periode Periode { get; set; }
    }
}
