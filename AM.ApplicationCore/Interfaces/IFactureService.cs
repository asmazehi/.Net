using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFactureService
    {    
        float GetMontantTotalFacturesNonPayees();
        IList<Facture> GetFacturesNonPayeesParAbonne(string abonneCIN);
        double GetMoyenneConsommationParType(TypeCompteur type);
        IList<Abonne> GetTop3ConsommateursParPeriode(int periodeId);
    }
}

