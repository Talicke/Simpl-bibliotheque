using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    internal class Emprunt
    {
        public List<Livre> livres { get; set; }
        public Emprunteur emprunteur { get; set; }
        public DateOnly dateFin { get; set; }
        public DateOnly dateDebut { get; set; }
        
        public Emprunt(Emprunteur emprunteur, List<Livre> livres, DateOnly dateDebut)
        {
            this.livres = livres;
            this.emprunteur = emprunteur;
            this.dateDebut = dateDebut;
            this.dateFin = this.dateDebut.AddDays(15);
        }

        public void ajouterEmprunt(Dictionary<string, Emprunt> emprunts)
        {
            emprunts.Add(this.emprunteur.Nom, this);
        }

        /*
        public string[] empruntEnCoursParEmprunteur(Dictionary<string, Emprunt> dict,  Emprunteur emprunteur)
        {
            string[] listeEmprunt = {};
            return listeEmprunt;
        }

        public string[] empruntParEmprunteur(Dictionary<string, Emprunt> dict, Emprunteur emprunteur)
        {
            string[] listeEmprunt = {};
            return listeEmprunt;
        }
        */
    }
}
