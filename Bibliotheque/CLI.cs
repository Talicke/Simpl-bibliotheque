using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bibliotheque
{
    internal class CLI
    {
        /// <summary>
        /// Créer un objet de type Auteur
        /// </summary>
        /// <returns>Auteur</returns>
        public Auteur creerAuteur()
        {
            Console.Write("nom : ");
            string nomAut = Console.ReadLine();
            Console.Write("prenom : ");
            string prenomAut = Console.ReadLine();
            Auteur aut = new Auteur(nomAut, prenomAut);

            return aut;
        }

        /// <summary>
        /// Créer un objet de type Emprunteur
        /// </summary>
        /// <returns>Emprunteur</returns>
        public Emprunteur creerEmprunteur()
        {
            Console.Write("nom : ");
            string nom = Console.ReadLine();
            Console.Write("prenom : ");
            string prenom = Console.ReadLine();
            Console.Write("N° tel :  ");
            string tel = Console.ReadLine();
            Console.Write("Adresse : ");
            string adresse = Console.ReadLine();
            Emprunteur emp = new Emprunteur(nom, prenom, tel, adresse);

            Console.WriteLine(emp.Nom + emp.Prenom);

            return emp;
        }

        /// <summary>
        /// Créer une objet de type Livre sans Auteur
        /// </summary>
        /// <returns>Livre</returns>
         public Livre creerLivre()
        {
            Console.Write("Titre : ");
            string titreLivre = Console.ReadLine();
            Console.Write("Genre : ");
            string genreLivre = Console.ReadLine();
            Console.Write("Collection : ");
            string collectionLivre = Console.ReadLine();

            Livre livre = new Livre(titreLivre, genreLivre, collectionLivre, null);

            return livre;
        }

        /// <summary>
        /// Affiche tous les livres en stock
        /// </summary>
        /// <returns></returns>
        public string afficherstock()
        {
            string stock = "";
            foreach (KeyValuePair<string, Livre> livre in Data.livres)
            {
               stock += livre.Key + "\n";
            }

            return stock;
            
        }

        public string afficherEmprunteurs()
        {
            string emps = "";
            foreach (KeyValuePair<string, Emprunteur> emp in Data.emprunteurs)
            {
                emps += emp.Key + "\n";
            }

            return emps;
        }

        public string afficherLivres()
        {
            string livres = "";
            foreach (KeyValuePair<string, Livre> livre in Data.livres)
            {
                livres += livre.Key + "\n";
            }

            return livres;
        }

        public string afficherEmprunt()
        {
            string emprunts = "";

            foreach (KeyValuePair<string, Emprunt> emprunt in Data.emprunts)
            {
                emprunts += emprunt.Key + "\n";
            }

            return emprunts;
        }
    }
}
