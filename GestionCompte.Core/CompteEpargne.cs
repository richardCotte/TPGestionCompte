using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompte.Core
{
    public class CompteEpargne : Compte
    {
        private decimal tauxAbondement;
        public decimal TauxAbondement { get => tauxAbondement; set => tauxAbondement = value; }

        public CompteEpargne(string proprietaire, decimal tauxAbondement)
            : base(proprietaire)
        {
            this.tauxAbondement = tauxAbondement;
        }

        public override decimal CalculBenefice()
        {
            return Solde * tauxAbondement - Solde;
        }

        public override void Information()
        {
            Console.WriteLine("Résumé du compte épargne de : {0}", Proprietaire);
            Console.WriteLine("*******************************************");
            Console.WriteLine("Taux d'abondement : {0}", TauxAbondement);
            base.Information();
            Console.WriteLine("*******************************************");
        }
    }
}
