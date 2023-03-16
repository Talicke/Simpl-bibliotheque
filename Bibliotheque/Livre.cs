using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    internal class Livre
    {
        public string Titre { get; set; }
        public string Genre { get; set; }
        public string Collection { get; set; }
        public Auteur Auteur { get; set; }


        public Livre(string titre, string genre, string collection, Auteur auteur)
        {
            this.Titre = titre;
            this.Genre = genre;
            this.Collection = collection;
            this.Auteur = auteur;
        }

        public void ajouterLivre(Dictionary<string, Livre> dic)
        {
            dic.Add(this.Titre, this);
        }

        public void modifierLivre(Dictionary<string, Livre> dic)
        {

        }
    }
}
