using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompte.Core
{
    public class CompteCourant : Compte
    {
        private decimal decouvertAutorise;
        public decimal DecouvertAutorise { get { return decouvertAutorise; } }

        public CompteCourant(string proprietaire, decimal decouvertAutorise)
            : base(proprietaire)
        {
            this.decouvertAutorise = decouvertAutorise;
        }

        public override decimal CalculBenefice()
        {
            return 0;
        }

        public override void Information()
        {
            Console.WriteLine("Résumé du compte courant de : {0}", Proprietaire);
            Console.WriteLine("*******************************************");
            Console.WriteLine("Découvert autorisé : {0}", decouvertAutorise);
            base.Information();
            Console.WriteLine("*******************************************");
            Console.WriteLine("");
        }
    }
}
