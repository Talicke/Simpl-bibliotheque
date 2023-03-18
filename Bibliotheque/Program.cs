// See https://aka.ms/new-console-template for more information

using Bibliotheque;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


string exit = "";


CLI cli = new CLI();

while (exit != "exit")
{
    Data.loadData();

    Console.WriteLine("Que souhaitez vous faire ? ");
    Console.WriteLine("AjouterEmprunteur | AjouterAuteur | AjouterLivre | ConsulterStock | CreerEmprunt | ConsulterEmprunt | Exit ");

    string souhait = Console.ReadLine();

    switch (souhait)
    {
        case "AjouterEmprunteur":
            cli.creerEmprunteur().ajouterEmprunteur(Data.emprunteurs);
            break;

        case "AjouterAuteur":
                   
               cli.creerAuteur().ajouterAuteur(Data.auteurs);
            break;

        case "AjouterLivre":

            Livre newLivre = cli.creerLivre();

            foreach (KeyValuePair<string, Auteur> auteur in Data.auteurs)
            {
                Console.WriteLine(auteur.Key);
            }
            Console.WriteLine("Ecrivez le nom de l'auteur existant sinon écrivez : 'Nouveau'");

            string AuteurValue = Console.ReadLine();

            switch (AuteurValue)
            {
                case "Nouveau":
                    Auteur newAut = cli.creerAuteur();
                    newAut.ajouterAuteur(Data.auteurs);
                    newLivre.Auteur = newAut;
                    newLivre.ajouterLivre(Data.livres);
                    Console.WriteLine("Combien ?");
                    int nbStockLivre = int.Parse(Console.ReadLine());
                    Stock stockLivres = new Stock(nbStockLivre, 100, newLivre);
                    stockLivres.ajouterStock(Data.stocks);

                    break;

                default:
                    if (Data.auteurs.ContainsKey(AuteurValue))
                    {
                        newLivre.Auteur = Data.auteurs[AuteurValue];
                        newLivre.ajouterLivre(Data.livres);
                        Console.WriteLine("Combien ?");
                        int nbStockLivre2 = int.Parse(Console.ReadLine());
                        Stock stockLivres2 = new Stock(nbStockLivre2, 100, newLivre);
                        stockLivres2.ajouterStock(Data.stocks);
                    }
                    else
                    {
                        Console.WriteLine($"Désolé cet auteur : {AuteurValue} n'est pas dans notre base de données");
                    }
                    break;
            }
            break;


        case "ConsulterStock":
            Console.WriteLine("de quel livre consulter le stock? ");

            Console.WriteLine(cli.afficherstock());

            Console.WriteLine("Entrez le titre du livre souhaitez, Si il n'est pas présent écrivez Exit et AjouterLivre");

            string livreValue = Console.ReadLine();

            switch (livreValue)
            {
                case "exit":
                    break;
                default:
                    if (Data.stocks.ContainsKey(livreValue))
                    {
                        Console.WriteLine($"Voici l'état des stocks de {livreValue} {Data.stocks[livreValue].nbStock} / {Data.stocks[livreValue].nbTotal}");
                        Console.WriteLine("Que souhaitez vous faire ? (Exit | ModifierStock)");
                     
                        string inputStock = Console.ReadLine();

                        if (inputStock == "exit")
                        {
                            break;
                        }
                        else if (inputStock == "ModifierStock")
                        {
                            Console.WriteLine("Quel livre ? (titre du livre)");
                            string stockLivre = Console.ReadLine();
                            if (Data.stocks.ContainsKey(stockLivre))
                            {
                                Stock stock = Data.stocks[stockLivre];
                                Console.WriteLine("De combien voulez vous changer le stock");
                                int balance = int.Parse(Console.ReadLine());
                                stock.modifierStock(Data.stocks, balance);
                                Console.WriteLine($"Le nouveau stock de {stock.Livre.Titre} est de {stock.nbStock} / {stock.nbTotal} ");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Je suis désolé, je n'est pas compris votre demande");
                        break;
                    }
                    break;

                    
            }
            break;

        case "CreerEmprunt":
            
            Console.WriteLine(cli.afficherEmprunteurs());
            Console.WriteLine("Qui emprunte le livre ? Sinon écrire Nouveau");
            string empValue = Console.ReadLine();
            Emprunteur Emp;
            if (empValue == "Nouveau")
            {
                Emp = cli.creerEmprunteur();
                Emp.ajouterEmprunteur(Data.emprunteurs);
            }
            else
            {
                if (Data.emprunteurs.ContainsKey(empValue))
                {
                    Emp = Data.emprunteurs[empValue];
                }
                else
                {
                    Console.WriteLine($"Désolé, {empValue} n'est pas dans notre base de données");
                    break;
                }
            }
            List<Livre> livreEmp = new List<Livre>();
            string inputValueLivre = "";
            while (inputValueLivre != "Stop")
            {
                Console.WriteLine("Quel livre emprunte t'il ? pour arreter écrivez Stop");
                Console.WriteLine(cli.afficherLivres());
                inputValueLivre = Console.ReadLine();
                if(inputValueLivre != "Stop")
                {
                    if(Data.livres.ContainsKey(inputValueLivre))
                    {
                        if (Data.stocks.ContainsKey(inputValueLivre)) 
                        {
                            if (Data.stocks[inputValueLivre].nbStock > 0)
                            {

                                livreEmp.Add(Data.livres[inputValueLivre]);
                                Data.stocks[inputValueLivre].nbStock--;
                            }
                            else
                            {
                                Console.WriteLine($"Désolé il n'y as plus aucun livre {inputValueLivre} en stock");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Désolé aucun stock n'existe pour {inputValueLivre}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Désolé {inputValueLivre} n'est pas dans la base de données");
                    }
                }
                else
                {
                    Emprunt emprunt = new Emprunt(Emp, livreEmp, DateOnly.FromDateTime(DateTime.Now));
                    emprunt.ajouterEmprunt(Data.emprunts);
                }
            }

            break;

        case "ConsulterEmprunt":
            Console.WriteLine(cli.afficherEmprunt());
            Console.WriteLine("Quel Emprunt ? ");
            string inputValueEmprunt = Console.ReadLine();
            if(Data.emprunts.ContainsKey(inputValueEmprunt))
            {
                Emprunt emprunt = Data.emprunts[inputValueEmprunt];
                Console.WriteLine($"Mr {emprunt.emprunteur.Nom}{emprunt.emprunteur.Prenom} à emprunter le : {emprunt.dateDebut}");
                Console.WriteLine("Il à en sa posession les livres : ");
                foreach(Livre livre in emprunt.livres)
                {
                    Console.WriteLine(livre.Titre);
                }
                Console.WriteLine($"Il doit les rendre le : {emprunt.dateFin}");
            }

            break;

        case "Exit":
            Console.WriteLine("Voulez-vous vraiment Quittez ? (Oui/Non) ");
            string confirmationValue = Console.ReadLine();
            switch (confirmationValue)
            {
                case "Oui":
                    if (Data.saveBeforeLeave())
                    {
                        exit = "exit";
                        break;  
                    }
                    else
                    {
                        Console.Write("un problème est survenue pendant la sauvegarde des données si vous quittez maintenant tout les modifications seront perduent.");
                        Console.WriteLine("Continuer ? (Oui/Non)");
                        confirmationValue = Console.ReadLine();
                        if( confirmationValue == "Oui")
                        {
                            exit = "exit";
                        }
                        else
                        {
                          break;
                        }
                    }
                    break;

                    
                case "Non":
                    break;
                default:
                    Console.WriteLine("Désolé je n'ai pas compris votre requête");
                    break;   
            }
            break;

        default:
            Console.WriteLine("Désolé je n\'ai pas compris votre requête.");
            break;

    
    }
    

}




