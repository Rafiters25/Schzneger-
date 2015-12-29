using System.Linq;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Ryze.Config.Modes.LaneClear;

namespace KickassSeries.Champions.Ryze.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            var minion =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.IsValidTarget(Q.Range));

            var stacks = EloBuddy.Player.Instance.GetBuffCount("ryzepassivestack");
            if (minion == null) return;
            if (Settings.UseQWER <= EloBuddy.Player.Instance.ManaPercent) return;
            if (Settings.UseS && Settings.UseS1 >= stacks) return;

            if (E.IsReady() && minion.IsValidTarget(E.Range) && Settings.UseE)
            {
                E.Cast(minion);
            }

            if (W.IsReady() && minion.IsValidTarget(W.Range) && Settings.UseW)
            {
                W.Cast(minion);
            }

            if (Q.IsReady() && minion.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                Q.Cast(minion);
            }

            if (R.IsReady() && minion.IsValidTarget(R.Range) && Settings.UseR)
            {
                R.Cast();
            }
        }
    }
}
