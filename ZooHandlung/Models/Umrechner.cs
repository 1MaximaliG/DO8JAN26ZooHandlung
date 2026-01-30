using System.Collections.Generic;

namespace ZooHandlung.Models
{
    public static class Umrechner
    {
        public static decimal TierZuEuro(List<EingabeViewModel> tierListe)
        {
            decimal erg = 0;
            foreach (var item in tierListe)
            {
                if(item != null)
                erg += item.Anzahl * item.Tier.Wechselkurs;
            }
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
                            Tier = t,
                            Anzahl = (int)(geld / t.Wechselkurs)
                        });
                        geld = geld % t.Wechselkurs;
                    }
                    else
                    {
                        erg.Add(new EingabeViewModel
                        {
                            Tier = t,
                            Anzahl = 0
                        });
                    }
                }
            }
            erg.Add(new EingabeViewModel
            {
                Tier = new Tier { ID = 0, Name = "Restbetrag", Wechselkurs = geld },
                Anzahl = 1
            }
            );
            return erg;
        }
    }
}
