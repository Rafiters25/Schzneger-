using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Activator.Config.Types.OffensiveItems;

namespace KickassSeries.Activator.Items
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class Offensive : Ids
    {
        private static int LastRun;

        public static void Execute()
        {
            if (LastRun > Environment.TickCount) return;

            var target =
                EntityManager.Heroes.Enemies.FirstOrDefault(e => !e.IsDead && e.IsInRange(Player.Instance, 1000));

            if (Player.Instance.IsRecalling() || Player.Instance.IsInShopRange() || target == null ||
                !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)) return;

            if (Settings.Bilgewater && BilgewaterCutlass.IsOwned() && BilgewaterCutlass.IsReady())
            {
                if (Settings.BilgewaterMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.BilgewaterTargetHp)
                {
                    BilgewaterCutlass.Cast(target);
                }
            }

            if (Settings.Blade && BladeOfTheRuinedKing.IsOwned() && BladeOfTheRuinedKing.IsReady())
            {
                if (Settings.BladeMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.BladeTargetHp)
                {
                    BladeOfTheRuinedKing.Cast(target);
                }
            }

            if (Settings.Tiamat && Tiamat.IsOwned() && Tiamat.IsReady())
            {
                if (Settings.TiamatMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.TiamatTargetHp)
                {
                    Tiamat.Cast();
                }
            }

            if (Settings.Hydra && Hydra.IsOwned() && Hydra.IsReady())
            {
                if (Settings.HydraMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.HydraTargetHp)
                {
                    Hydra.Cast();
                }
            }

            if (Settings.Titanic && TitanicHydra.IsOwned() && TitanicHydra.IsReady())
            {
                if (Settings.TitanicMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.TitanicTargetHp)
                {
                    TitanicHydra.Cast();
                }
            }

            if (Settings.Youmuu && Youmuu.IsOwned() && Youmuu.IsReady())
            {
                if (Settings.YoumuuMyHp >= Player.Instance.HealthPercent &&
                    target.HealthPercent <= Settings.YoumuuTargetHp)
                {
                    Youmuu.Cast();
                }
            }

            LastRun = Environment.TickCount + 200;
        }
    }
}
