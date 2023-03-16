using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    internal class Emprunt
    {
        Livre livre { get; set; }
        Emprunteur emprunteur { get; set; }
        DateOnly dateFin { get; set; }
        DateOnly dateDebut { get; set; }
        
        public Emprunt(Livre livre, Emprunteur emprunteur, DateOnly dateFin, DateOnly dateDebut)
        {
            this.livre = livre;
            this.emprunteur = emprunteur;
            this.dateFin = dateFin;
            this.dateDebut = dateDebut;
        }

        public void ajouterEmprunt(Dictionary<string, Emprunt> emprunts)
        {

        }

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
    
    }
}
