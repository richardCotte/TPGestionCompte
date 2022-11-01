using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompte.Core
{
    public abstract class Compte : IComparable
    {
        private List<Operation> operations = new List<Operation>();
        public List<Operation> Operations { get { return operations; } }

        private string proprietaire;
        public string Proprietaire { get => proprietaire; set { proprietaire = value; } }

        private decimal solde;
        public decimal Solde { get { return solde; } }

        public Compte(string proprietaire)
        {
            this.proprietaire = proprietaire;
            solde = 0;
        }

        public Compte()
        {
        }

        public void Crediter(decimal montant)
        {
            operations.Add(new Operation(montant, Mouvement.Credit));
            solde += montant;
        }

        public void Debiter(decimal montant)
        {
            operations.Add(new Operation(montant, Mouvement.Debit));
            solde -= montant;
        }

        public void Crediter(decimal montant, Compte compteADebiter)
        {
            Crediter(montant);
            compteADebiter.Debiter(montant);
        }

        public void Debiter(decimal montant, Compte compteACrediter)
        {
            Debiter(montant);
            compteACrediter.Crediter(montant);
        }

        public abstract decimal CalculBenefice();

        public decimal SoldeFinal()
        {
            return solde + CalculBenefice();
        }

        public virtual void Information()
        {
            Console.WriteLine("Solde du compte : {0}", solde);
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
