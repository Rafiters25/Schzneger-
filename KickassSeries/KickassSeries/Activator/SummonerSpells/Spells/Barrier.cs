using System;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Activator.Config.Types.SummonerSpells;

namespace KickassSeries.Activator.SummonerSpells.Spells
{
    internal class Barrier
    {
        public static Spell.Active SummonerBarrier;
        public static void Initialize()
        {
            SetHealtSlot();
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (!SummonerBarrier.IsReady() || SummonerSpells.Initialize.lastSpell + 1500 >= Environment.TickCount || !Settings.UseBarrier) return;

            if (Player.Instance.InDanger())
            {
                SummonerBarrier.Cast();
                SummonerSpells.Initialize.lastSpell = Environment.TickCount;
            }
        }

        private static void SetHealtSlot()
        {
            if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.Contains("barrier"))
                SummonerBarrier = new Spell.Active(SpellSlot.Summoner1);
            else if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.Contains("barrier"))
                SummonerBarrier = new Spell.Active(SpellSlot.Summoner2);
        }
    }
}
