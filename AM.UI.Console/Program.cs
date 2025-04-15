using System.ComponentModel.DataAnnotations;
using AM.ApplicationCore.Domain;
using AM.Infrastructure;


var context = new AMContext();

//context.Database.EnsureDeleted();
//context.Database.EnsureCreated();

var abonne = new Abonne
{
    CIN = "12345678",
    Nom = "Zehi",
    Prenom = "Asma"
};
context.Abonnes.Add(abonne);

var compteur = new Compteur
{
    Reference = "CMP001",
    type = TypeCompteur.Industriel,
    Voltage = 220,
    Index = 1500,
    CIN = abonne.CIN
};
context.Compteurs.Add(compteur);

var periode = new Periode
{
    Debut = new DateTime(2025, 1, 1),
    Fin = new DateTime(2025, 1, 31)
};
context.Periodes.Add(periode);
context.SaveChanges(); // ythabet periode.Id mawjouda

var facture = new Facture
{
    CompteurReference = compteur.Reference,
    PeriodeId = periode.Id,
    Date = new DateTime(2025, 1, 15),
    Montant = 100.5,
    ConsommationKWH = 50,
    Payement = false
};
context.Factures.Add(facture);

context.SaveChanges();

Console.WriteLine("Données enregistrées.");