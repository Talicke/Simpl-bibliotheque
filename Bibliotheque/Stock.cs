using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    internal class Stock
    {
        public Livre Livre { get; set; }
        public int nbTotal { get; set; }
        public int nbStock { get; set; }


        public Stock(int nbStock, int nbTotal, Livre livre)
        {
            this.nbStock = nbStock ;
            this.nbTotal = nbTotal;
            this.Livre = livre;
        }

        public void ajouterStock(Dictionary<string, Stock> dict)
        {
            dict.Add(this.Livre.Titre, this);
        }

        public void modifierStock (Dictionary<string, Stock> dict, int balance)
        {
            dict[this.Livre.Titre].nbStock += balance;
        }

        public void consulterStock(Dictionary<string, Stock> dict)
        {

        }
    }
}
