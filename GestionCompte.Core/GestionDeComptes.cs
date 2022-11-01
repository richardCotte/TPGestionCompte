using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompte.Core
{
    public class GestionDeComptes
    {
        private List<Compte> compteList = new List<Compte>();
        public List<Compte> CompteList { get { return compteList; } }

        public GestionDeComptes()
        {
        }

        public void AjouterCompte(Compte compte)
        {
            compteList.Add(compte);
        }

        public void AfficherComptesCourant()
        {
            Console.WriteLine("Compte courants et leurs informations : ");
            foreach (Compte compte in compteList)
            {
                if (compte is CompteCourant)
                {
                    compte.Information();
                    Console.WriteLine("");
                }
            }
        }

        public void AfficherComptesEparne()
        {
            Console.WriteLine("Compte épargne et leurs informations : ");
            foreach (Compte compte in compteList)
            {
                if (compte is CompteEpargne)
                {
                    compte.Information();
                    Console.WriteLine("");
                }
            }
        }

        public void AfficherComptes()
        {
            Console.WriteLine("Tout les comptes et leurs informations : ");
            foreach(Compte compte in compteList)
            {
                compte.Information();
            }
        }
    }
}
