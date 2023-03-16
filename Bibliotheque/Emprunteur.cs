using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bibliotheque
{
    internal class Emprunteur : Personne
    {
        string telephone { get; set; }
        string addresse { get; set; }
        public Emprunteur(string nom, string prenom, string telephone, string adresse) : base()
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.telephone = telephone;
            this.addresse = adresse;
        }

        public void ajouterEmprunteur (Dictionary<string, Emprunteur> emprunteurs)
        {
            emprunteurs.Add(this.Nom, this);

        }

        public void modifierEmprunteur(Dictionary<string, Emprunteur> emprunteurs)
        {

        }

        /*
        public string trouverEmprunteur(string nom, Dictionary<string, Emprunteur> empruntes)
        {
            string emprunteur = "Aucun emprunteur n'as était trouvver à ce nom";

            foreach(KeyValuePair<string, Emprunteur> emprunteur1 in empruntes) {
                if (emprunteur1.Key == nom){
                    emprunteur = emprunteur1.Value.Prenom;
                }
            }
            return emprunteur;
        }

        */


    }

}
