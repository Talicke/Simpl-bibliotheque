// See https://aka.ms/new-console-template for more information

using Bibliotheque;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

string exit = "";

Dictionary<string, Emprunteur> emprunteurs = new Dictionary<string, Emprunteur>();
Dictionary<string, Auteur> auteurs = new Dictionary<string, Auteur>();
Dictionary<string, Livre> livres = new Dictionary<string, Livre>();
Dictionary<string, Stock> stocks = new Dictionary<string, Stock>();


while (exit != "exit")
{
    Console.WriteLine("Que souhaitez vous faire ? ");
    Console.WriteLine("AjouterEmprunteur | AjouterAuteur | AjouterLivre | ModifierStock | ConsulterStock | Exit ");

    string souhait = Console.ReadLine();

    switch (souhait)
    {
        case "AjouterEmprunteur":
            Console.Write("nom : ");
            string nomEmp = Console.ReadLine();
            Console.Write("prenom : ");
            string prenomEmp = Console.ReadLine();
            Console.Write("N° tel :  ");
            string telEmp = Console.ReadLine();
            Console.Write("Adresse : ");
            string adresseEmp = Console.ReadLine();
            Emprunteur emp = new Emprunteur(nomEmp, prenomEmp, telEmp, adresseEmp);

            emp.ajouterEmprunteur(emprunteurs);

            break;

        case "AjouterAuteur":
            Console.Write("nom : ");
            string nomAut = Console.ReadLine();
            Console.Write("prenom : ");
            string prenomAut = Console.ReadLine();
            Auteur aut = new Auteur(nomAut, prenomAut);

            aut.ajouterAuteur(auteurs);
            break;

        case "AjouterLivre":
            Console.Write("Titre : ");
            string titreLivre = Console.ReadLine();
            Console.Write("Genre : ");
            string genreLivre = Console.ReadLine();
            Console.Write("Collection : ");
            string collectionLivre = Console.ReadLine();
            Console.WriteLine("Ce livre est-il d'un Auteur enregistrer");
            foreach (KeyValuePair<string, Auteur> auteur in auteurs)
                {
                Console.WriteLine(auteur.Key + " -");
                }
            Console.WriteLine("Ecrivez le nom de l'auteur existant sinon écrivez Nouveau");
            string AuteurValue = Console.ReadLine();
            switch (AuteurValue)
            {
                case "Nouveau":
                    Console.Write("nom : ");
                    string nomNewAut = Console.ReadLine();
                    Console.Write("prenom : ");
                    string prenomNewAut = Console.ReadLine();
                    Auteur newAut = new Auteur(nomNewAut, prenomNewAut);

                    newAut.ajouterAuteur(auteurs);
                    Livre livreNewAut = new Livre(titreLivre, genreLivre, collectionLivre, newAut);
                    livreNewAut.ajouterLivre(livres);
                    Stock stockLivreNewAut = new Stock(0, 100, livreNewAut);
                    stockLivreNewAut.ajouterStock(stocks);

                    break;
                default:
                    if (auteurs.ContainsKey(AuteurValue))
                    {
                        Livre livreOldAut = new Livre(titreLivre, genreLivre, collectionLivre, auteurs[AuteurValue]);
                        livreOldAut.ajouterLivre(livres);
                        Stock stockLivreOldAut = new Stock(0, 100, livreOldAut);
                        stockLivreOldAut.ajouterStock(stocks);
                    }
                    else
                    {
                        Console.WriteLine($"Désolé cet auteur : {AuteurValue} n'est pas dans notre base de données");
                    }
                    break;
            }
            break;

        case "ModifierStock":
            Console.WriteLine("à quel livre voulez vous modifiez le stock");
            foreach (KeyValuePair<string, Livre> livre in livres)
            {
                Console.WriteLine(livre.Key + " -");
            }
            Console.WriteLine("Entrez le titre du livre souhaitez, Si il n'est pas présent écrivez Exit et AjouterLivre");
            string livreValue = Console.ReadLine();
            switch (livreValue)
            {
                case "exit":
                    break;
                default:
                    if (stocks.ContainsKey(livreValue))
                    {
                        Console.WriteLine($"Voici l'état des stocks de {livreValue} {stocks[livreValue].nbStock} / {stocks[livreValue].nbTotal}");
                        Console.WriteLine("De combien voulez vous changer le stock");
                        int balance = int.Parse(Console.ReadLine());
                        stocks[livreValue].modifierStock(stocks, balance);
                        Console.WriteLine($"Le nouveau stock de {stocks[livreValue].Livre.Titre} est de {stocks[livreValue].nbStock} / {stocks[livreValue].nbTotal} ");
                    }
                    break;
            }
           

            break;

        case "ConsulterStock":
            Console.WriteLine("Pour quel livre voulez vous consulter le stock");
            foreach (KeyValuePair<string, Livre> livre in livres)
                {
                    Console.WriteLine(livre.Key);
                }
            Console.WriteLine("Ecrivez le titre du livre concernez");
            string stockLivre = Console.ReadLine();
            if (stocks.ContainsKey(stockLivre))
            {
                Console.WriteLine($"le stock de {stockLivre} est de : {stocks[stockLivre].nbStock} /{stocks[stockLivre].nbTotal}");
            }
            break;



        case "Exit":
            exit = "exit";
            break;

        default:
            Console.WriteLine("Désolé je n\'ai pas compris votre requête.");
            break;
    }

    /*
    foreach (KeyValuePair<string, Emprunteur> emprunteur in emprunteurs)
    {
        Console.WriteLine(emprunteur.Key + " : " + emprunteur.Value.Prenom);
    }

    foreach (KeyValuePair<string, Auteur> auteur in auteurs)
    {
        Console.WriteLine(auteur.Key + " : " + auteur.Value.Prenom);
    }
    

    foreach (KeyValuePair<string, Livre> livre in livres)
    {
        Console.WriteLine(livre.Key + " : " + livre.Value.Auteur.Nom);
    }

    foreach (KeyValuePair<string, Stock> stock in stocks)
    {
        Console.WriteLine(stock.Key + " : " + stock.Value.nbStock);
    }
    */


}




