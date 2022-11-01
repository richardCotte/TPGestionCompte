using GestionCompte.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompte.Test
{
    public class GestionCompteTest
    {
        [Test]
        public void OperationCreationValidity()
        {
            decimal amount = 500;
            Mouvement mouvement = Mouvement.Debit;
            Operation operation = new Operation(amount, mouvement);
            Assert.IsNotNull(operation);
            Assert.AreEqual(amount, operation.Amount);
            Assert.AreEqual(mouvement, operation.Type);
        }

        [Test]
        public void CompteCourantCreationValidity()
        {
            string proprietaire = "Richard";
            decimal decouvertAutorise = 500;
            CompteCourant compte = new CompteCourant(proprietaire, decouvertAutorise);
            Assert.IsNotNull(compte);
            Assert.AreEqual(proprietaire, compte.Proprietaire);
            Assert.AreEqual(decouvertAutorise, compte.DecouvertAutorise);
        }

        [Test]
        public void CompteEpargneCreationValidity()
        {
            string proprietaire = "Richard";
            decimal tauxAbondement = 0.2m;
            CompteEpargne compte = new CompteEpargne(proprietaire, tauxAbondement);
            Assert.IsNotNull(compte);
            Assert.AreEqual(proprietaire, compte.Proprietaire);
            Assert.AreEqual(tauxAbondement, compte.TauxAbondement);
        }
    }
}
