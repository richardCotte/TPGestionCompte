using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using GestionCompte.Core;

namespace TPGestionCompte
{
    internal class Program
    {
        static private GestionDeComptes gestionDeComptes = new GestionDeComptes();

        static void Main(string[] args)
        {
            bool usingApp = true;
            while (usingApp)
            {
                Console.Clear();

                Console.WriteLine("Bienvenue dans le menu de l'application console de gestion de compte banquaire.");
                Console.WriteLine("");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("");
                Console.WriteLine("Veuillez choisir une action parmis celles ci dessous ou appuyez sur entrer pour sortir :");
                Console.WriteLine("1. Créer un compte courant");
                Console.WriteLine("2. Créer un compte épargne");
                Console.WriteLine("3. Créditer un compte");
                Console.WriteLine("4. Débiter un compte");
                Console.WriteLine("5. Effectuer un virement");
                Console.WriteLine("6. Afficher la liste des comptes ");
                Console.WriteLine("7. Quitter ");

                int userChoice = 0;
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                } catch (FormatException)
                {
                    Console.WriteLine("La saisie n'est pas valide.");
                }
                try
                {
                    switch (userChoice)
                    {
                        case 1:
                            CreerCompteCourant();
                            break;
                        case 2:
                            CreerCompteEpargne();
                            break;
                        case 3:
                            CrediterUnCompte();
                            break;
                        case 4:
                            DebiterUnCompte();
                            break;
                        case 5:
                            EffectuerUnVirement();
                            break;
                        case 6:
                            AfficherComptes();
                            break;
                        case 7:
                            usingApp = false;
                            break;
                        default:
                            Console.WriteLine("Le chiffre utilisé n'est pas valide, veuillez réessayer.");
                            Console.ReadKey();
                            break;
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
            Console.Clear();
            Console.WriteLine("Merci d'avoir utilisé l'application de gestion de compte");
            Console.ReadKey();
        }

        static public void CreerCompteCourant()
        {
            Console.Clear();

            Console.WriteLine("Entrez le nom du propriétaire du compte : ");
            string proprietaire = Console.ReadLine();

            Console.WriteLine("Entrez le découvert autorisé du compte : ");
            decimal decouvertAutorise = 0;
            try
            {
                decouvertAutorise = Convert.ToDecimal(Console.ReadLine());
            } catch (FormatException e)
            {
                throw new FormatException("Le nombre rentré n'est pas valide", e);
            }

            gestionDeComptes.AjouterCompte(new CompteCourant(proprietaire, decouvertAutorise));
            Console.WriteLine("Le compte courant a bien été ajouté");
            Console.WriteLine("Appuyez sur n'importe quel touche pour terminer l'opération et revenir au menu");
            Console.ReadKey();
        }

        static public void CreerCompteEpargne()
        {
            Console.Clear();

            Console.WriteLine("Entrez le nom du propriétaire du compte : ");
            string proprietaire = Console.ReadLine();

            Console.WriteLine("Entrez le taux d'abondement du compte : ");
            decimal tauxAbondement = 0;
            try
            {
                tauxAbondement = Convert.ToDecimal(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw new FormatException("La donnée rentré n'est pas valide", e);
            }

            gestionDeComptes.AjouterCompte(new CompteEpargne(proprietaire, tauxAbondement));
            Console.WriteLine("Le compte épargne a bien été ajouté");
            Console.WriteLine("Appuyez sur n'importe quel touche pour terminer l'opération et revenir au menu");
            Console.ReadKey();
        }

        static public void AfficherComptes()
        {
            Console.Clear();
            gestionDeComptes.AfficherComptes();
            Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu.");
            Console.ReadKey();
        }

        static public void CrediterUnCompte()
        {
            Console.Clear();
            Console.WriteLine("Choisissez un compte à crediter parmis la liste ci dessous : ");
            for (int i = 0; i < gestionDeComptes.CompteList.Count(); i++)
            {
                Console.WriteLine("{0}. Compte de : {1}", i + 1, gestionDeComptes.CompteList[i].Proprietaire);
            }

            int choosenAccount = 0;
            try
            {
                choosenAccount = Convert.ToInt32(Console.ReadLine());
            } catch (FormatException e)
            {
                throw new FormatException("La donnée rentrée n'est pas valide", e);
            }

            Console.Clear();

            Compte compte;
            try
            {
                compte = gestionDeComptes.CompteList[choosenAccount - 1];
            } catch (Exception e)
            {
                throw new Exception("Le compte n'existe pas", e);
            }

            Console.WriteLine("Veuillez saisir un montant à créditer sur le compte : {0}", compte.Proprietaire);
            decimal credAmount = 0;
            try
            {
                credAmount = Convert.ToDecimal(Console.ReadLine());
            } catch (FormatException e)
            {
                throw new Exception("La donnée rentrée n'est pas valide", e);
            }

            compte.Crediter(credAmount);

            Console.Clear();

            Console.WriteLine("Le compte a correctement été crédité de {0}.", credAmount);
            Console.WriteLine("Nouveau solde du compte créditer : {0}", compte.Solde);
            Console.WriteLine("Apppuyez sur n'importe quelle touche pour terminer l'opération et revenir au menu principale.");
            Console.ReadKey();
        }

        static public void DebiterUnCompte()
        {
            Console.Clear();

            Console.WriteLine("Choisissez un compte à débiter parmis la liste ci dessous : ");
            for (int i = 0; i < gestionDeComptes.CompteList.Count(); i++)
            {
                Console.WriteLine("{0}. Compte de : {1}", i + 1, gestionDeComptes.CompteList[i].Proprietaire);
            }

            int choosenAccount = 0;
            try
            {
                choosenAccount = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw new FormatException("La donnée rentrée n'est pas valide", e);
            }

            Console.Clear();

            Compte compte;
            try
            {
                compte = gestionDeComptes.CompteList[choosenAccount - 1];
            }
            catch (Exception e)
            {
                throw new Exception("Le compte n'existe pas", e);
            }

            Console.WriteLine("Veuillez saisir un montant à débité sur le compte : {0}", compte.Proprietaire);
            decimal credAmount = 0;
            try
            {
                credAmount = Convert.ToDecimal(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw new Exception("La donnée rentrée n'est pas valide", e);
            }

            compte.Debiter(credAmount);

            Console.Clear();

            Console.WriteLine("Le compte a correctement été débité de {0}.", credAmount);
            Console.WriteLine("Nouveau solde du compte débité : {0}", compte.Solde);
            Console.WriteLine("Apppuyez sur n'importe quelle touche pour terminer l'opération et revenir au menu principale.");
            Console.ReadKey();
        }

        static public void EffectuerUnVirement()
        {
            Console.Clear();
            Console.WriteLine("Choisissez le compte débité parmis la liste ci dessous : ");
            for (int i = 0; i < gestionDeComptes.CompteList.Count(); i++)
            {
                Console.WriteLine("{0}. Compte de : {1}", i + 1, gestionDeComptes.CompteList[i].Proprietaire);
            }

            int choosenSourceAccount = 0;
            try
            {
                choosenSourceAccount = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw new FormatException("La donnée rentrée n'est pas valide", e);
            }

            Console.WriteLine("Choisissez maintenant le compte crédité parmis la liste ci dessus : ");

            int choosenTargetAccount = 0;
            try
            {
                choosenTargetAccount = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw new FormatException("La donnée rentrée n'est pas valide", e);
            }

            Console.Clear();

            Compte compteDebite;
            try
            {
                compteDebite = gestionDeComptes.CompteList[choosenSourceAccount - 1];
            }
            catch (Exception e)
            {
                throw new Exception("Le compte source n'existe pas", e);
            }

            Compte compteCredite;
            try
            {
                compteCredite = gestionDeComptes.CompteList[choosenTargetAccount - 1];
            }
            catch (Exception e)
            {
                throw new Exception("Le compte cible n'existe pas", e);
            }

            Console.WriteLine("Veuillez saisir un montant à virer du compte de {0} vers le compte de {1}", compteDebite.Proprietaire, compteCredite.Proprietaire);
            decimal credAmount = 0;
            try
            {
                credAmount = Convert.ToDecimal(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw new Exception("La donnée rentrée n'est pas valide", e);
            }

            compteDebite.Debiter(credAmount, compteCredite);

            Console.Clear();

            Console.WriteLine("Le virement du compte de {0} vers le compte de {1} a correctement été effectué.", compteDebite.Proprietaire, compteCredite.Proprietaire);
            Console.WriteLine("Nouveau solde du compte débité : {0}", compteDebite.Solde);
            Console.WriteLine("Nouveau solde du compte crédité : {0}", compteCredite.Solde);
            Console.WriteLine("Apppuyez sur n'importe quelle touche pour terminer l'opération et revenir au menu principale.");
            Console.ReadKey();
        }
    }
}
