using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Activator.Config.Types.SummonerSpells;

namespace KickassSeries.Activator.SummonerSpells.Spells
{
    internal class Heal
    {
        public static Spell.Active SummonerHeal;
        public static void Initialize()
        {
            SetHealtSlot();
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            if(!SummonerHeal.IsReady() || SummonerSpells.Initialize.lastSpell + 1500 >= Environment.TickCount || !Settings.UseHeal) return;
            var ally =
                EntityManager.Heroes.Allies.OrderByDescending(a => a.Health)
                    .FirstOrDefault(a => a.IsValidTarget(SummonerHeal.Range) && a.InDanger());
            if (ally != null)
            {
                SummonerHeal.Cast();
                SummonerSpells.Initialize.lastSpell = Environment.TickCount;
            }
        }

        private static void SetHealtSlot()
        {
            if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.Contains("heal"))
                SummonerHeal = new Spell.Active(SpellSlot.Summoner1, 830);
            else if (Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.Contains("heal"))
                SummonerHeal = new Spell.Active(SpellSlot.Summoner2, 830);
        }
    }
}
