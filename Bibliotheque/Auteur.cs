using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    internal class Auteur : Personne
    {
     
        public Auteur(string? nom, string? prenom) : base()
        {
            this.Nom = nom;
            this.Prenom = prenom;
        }

        public void ajouterAuteur(Dictionary<string, Auteur> dict)
        {
            dict.Add(this.Nom, this);
        }

        public void modifierAuteur(Dictionary<string, Auteur> dict)
        {

        }
    }

    
}
