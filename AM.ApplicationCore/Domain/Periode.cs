using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Periode
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Debut { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fin { get; set; }

        public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();
    }

}
