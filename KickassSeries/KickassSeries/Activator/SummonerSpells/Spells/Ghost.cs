using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace KickassSeries.Activator.SummonerSpells.Spells
{
    internal class Ghost
    {
        public static Spell.Active SummonerGhost;
        public static void Initialize()
        {
            SetHealtSlot();
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (!SummonerGhost.IsReady() || SummonerSpells.Initialize.lastSpell + 1500 >= Environment.TickCount) return;

            if (Player.Instance.InDanger())
            {
                SummonerGhost.Cast();
                SummonerSpells.Initialize.lastSpell = Environment.TickCount;
            }
        }

        private static void SetHealtSlot()
        {
            if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.Contains("ghost"))
                SummonerGhost = new Spell.Active(SpellSlot.Summoner1);
            else if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.Contains("ghost"))
                SummonerGhost = new Spell.Active(SpellSlot.Summoner2);
        }
    }
}
