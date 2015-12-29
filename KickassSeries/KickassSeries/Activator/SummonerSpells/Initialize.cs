namespace KickassSeries.Activator.SummonerSpells
{
    internal class Initialize : Extensions
    {
        public static int lastSpell;

        public static void Init()
        {
            if (HasSpell("summonersmite"))
            {
                Spells.Smite.Initialize();
            }

            if (HasSpell("summonerheal"))
            {
                Spells.Heal.Initialize();
            }

            if (HasSpell("summonerbarrier"))
            {
                Spells.Barrier.Initialize();
            }

            if (HasSpell("summonerexhaust"))
            {
                //TODO EXHAUST
            }

            if (HasSpell("summonerghost"))
            {
                //TODO EXHAUST
            }
        }
    }
}
