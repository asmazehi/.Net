using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Compteur
    {
        [Key]
        public string Reference { get; set; }

        public TypeCompteur type { get; set; }

        public float Voltage { get; set; }

        public long Index { get; set; }

        public string? CIN { get; set; }

        [ForeignKey("AbonneCIN")]
        public virtual Abonne? Abonne { get; set; }

        public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();
    }

}
