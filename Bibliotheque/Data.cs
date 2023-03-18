using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    internal class Data
    {
        public static Dictionary<string, Emprunteur> emprunteurs = new Dictionary<string, Emprunteur>();
        public static Dictionary<string, Auteur> auteurs = new Dictionary<string, Auteur>();
        public static Dictionary<string, Livre> livres = new Dictionary<string, Livre>();
        public static Dictionary<string, Stock> stocks = new Dictionary<string, Stock>();
        public static Dictionary<string, Emprunt> emprunts = new Dictionary<string, Emprunt>();


        public static bool saveBeforeLeave()
        {
            
            string jsonEmprunteursOut = JsonConvert.SerializeObject(emprunteurs);
            string jsonLivresOut = JsonConvert.SerializeObject(livres);
            string jsonAuteursOut = JsonConvert.SerializeObject(auteurs);
            string jsonStocksOut = JsonConvert.SerializeObject(stocks);
            string jsonEmpruntsOut = JsonConvert.SerializeObject(emprunts);

            using (StreamWriter sw = new StreamWriter("JsonEmprunteurs.txt"))
            {
                sw.WriteLine(jsonEmprunteursOut);
            }

            using (StreamWriter sw = new StreamWriter("JsonLivres.txt"))
            {
                sw.WriteLine(jsonLivresOut);
            }

            using (StreamWriter sw = new StreamWriter("JsonAuteurs.txt"))
            {
                sw.WriteLine(jsonAuteursOut);
            }

            using (StreamWriter sw = new StreamWriter("JsonStocks.txt"))
            {
                sw.WriteLine(jsonStocksOut);
            }

            using (StreamWriter sw = new StreamWriter("JsonEmprunts.txt"))
            {
                sw.WriteLine(jsonEmpruntsOut);
            }

            

            return false;
        }

        public static void loadData()
        {
            
            emprunteurs = JsonConvert.DeserializeObject<Dictionary<string, Emprunteur>>(File.ReadAllText("JsonEmprunteurs.txt"));
        
            auteurs = JsonConvert.DeserializeObject<Dictionary<string, Auteur>>(File.ReadAllText("JsonAuteurs.txt"));
            
            livres = JsonConvert.DeserializeObject<Dictionary<string, Livre>>(File.ReadAllText("JsonLivres.txt"));
           
            stocks = JsonConvert.DeserializeObject<Dictionary<string, Stock>>(File.ReadAllText("JsonStocks.txt"));
        
            emprunts = JsonConvert.DeserializeObject<Dictionary<string, Emprunt>>(File.ReadAllText("JsonEmprunts.txt"));


        }
    }
}
