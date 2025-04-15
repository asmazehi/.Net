using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FactureService : IFactureService
    {
        public List<Facture> ListFactures { get; set; } = new List<Facture>();
        public List<Compteur> ListCompteurs { get; set; } = new List<Compteur>();
        public List<Abonne> ListAbonnes { get; set; } = new List<Abonne>();
        public List<Periode> ListPeriodes { get; set; } = new List<Periode>();

        public float GetMontantTotalFacturesNonPayees()
        {
            return ListFactures
                .Where(f => !f.Payement)
                .Sum(f => (float)f.Montant);
        }

        public IList<Facture> GetFacturesNonPayeesParAbonne(string abonneCIN)
        {
            if (string.IsNullOrEmpty(abonneCIN))
                return new List<Facture>();

            var compteursDict = ListCompteurs
                .Where(c => c.CIN == abonneCIN)
                .ToDictionary(c => c.Reference);

            return ListFactures
                .Where(f => !f.Payement && compteursDict.ContainsKey(f.CompteurReference))
                .ToList();
        }

        public double GetMoyenneConsommationParType(TypeCompteur type)
        {
            var compteursDict = ListCompteurs
                .Where(c => c.type == type)
                .ToDictionary(c => c.Reference);

            if (!compteursDict.Any())
                return 0;

            return ListFactures
                .Where(f => compteursDict.ContainsKey(f.CompteurReference))
                .Average(f => f.ConsommationKWH);
        }

        public IList<Abonne> GetTop3ConsommateursParPeriode(int periodeId)
        {
            var joinedData = ListFactures
                .Where(f => f.PeriodeId == periodeId)
                .Join(ListCompteurs,
                    facture => facture.CompteurReference,
                    compteur => compteur.Reference,
                    (facture, compteur) => new { facture.ConsommationKWH, compteur.CIN })
                .Join(ListAbonnes,
                    x => x.CIN,
                    abonne => abonne.CIN,
                    (x, abonne) => new { x.ConsommationKWH, Abonne = abonne })
                .ToList();

            if (!joinedData.Any())
                return new List<Abonne>();

            return joinedData
                .GroupBy(x => x.Abonne)
                .OrderByDescending(g => g.Sum(x => x.ConsommationKWH))
                .Take(3)
                .Select(g => g.Key)
                .ToList();
        }
    }
}
