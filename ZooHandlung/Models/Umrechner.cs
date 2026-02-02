using System.Collections.Generic;

namespace ZooHandlung.Models
{
    public static class Umrechner
    {
        public static decimal TierZuEuro(List<EingabeViewModel> eingListe)
        {
            decimal erg = 0;
            for(int i = 0; i < eingListe.Count;i++)
            {
                erg += eingListe[i].Anzahl * Repository.Tiere.First(t => t.ID == eingListe[i].TierID).Wechselkurs;
                Console.WriteLine(erg);
            }//Läd jetzt den Wechselkurs direkt aus dem Repository passend zur TierID
            return erg;
        }
        public static List<EingabeViewModel> EuroZuTier(decimal geld)
        {
            List<EingabeViewModel> erg = new();
            IEnumerable<Tier> SortTier = Repository.Tiere.OrderByDescending(t => t.Wechselkurs);
            if (geld != 0)
            {
                foreach (Tier t in SortTier)
                {
                    if (t.Wechselkurs != 0)
                    {
                        erg.Add(new EingabeViewModel
                        {
                            TierID = t.ID,//hier muss nur tier durch TierID vor
                            Anzahl = (int)(geld / t.Wechselkurs)
                        });
                        geld = geld % t.Wechselkurs;
                    }
                    else
                    {
                        erg.Add(new EingabeViewModel
                        {
                            TierID = t.ID,
                            Anzahl = 0
                        });
                    }
                }
            }
            erg.Add(new EingabeViewModel
            {
                TierID = 0, //hier wird die ID direkt auf 0 gesetzt
                Anzahl = 1
            }
            );
            return erg;
        }
    }
}
