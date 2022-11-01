using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompte.Core
{
    public enum Mouvement
    {
        Credit,
        Debit
    }

    public class Operation
    {

        private decimal amount;
        public decimal Amount { get => amount; set => amount = value; }

        private Mouvement type;
        public Mouvement Type { get => type; set => type = value; }

        public Operation()
        {

        }

        public Operation(decimal amount, Mouvement type)
        {
            this.amount = amount;
            this.type = type;
        }

        public override string ToString()
        {
            if (type == Mouvement.Credit)
            {
                return "+" + amount;
            }
            return "-" + amount;
        }
    }
}
