namespace ZooHandlung.Models
{
    public static class Repository
    {
        private static List<Tier> _tiere = new List<Tier> {
            new Tier {
                ID=1,
                Name = "Schaf",
                Wechselkurs=650m
            },
            new Tier
            {
                ID = 2,
                Name = "Ziege",
                Wechselkurs = 500m
            },
            new Tier
            {
                ID = 3,
                Name = "kleine Ziege",
                Wechselkurs = 50m
            },
            new Tier
            {
                ID = 4,
                Name = "Kuh",
                Wechselkurs = 2800m
            }
        };
        public static IEnumerable<Tier> Tiere => _tiere;

        public static void AddTier(Tier tier)
        {
            tier.ID = _tiere.Last().ID + 1;
            _tiere.Add(tier);
        }
        public static void UpdateTier(Tier tier)
        {
            int index =_tiere.IndexOf(_tiere.First(t => t.ID == tier.ID));
            _tiere[index] = tier;
        }
    }
}
