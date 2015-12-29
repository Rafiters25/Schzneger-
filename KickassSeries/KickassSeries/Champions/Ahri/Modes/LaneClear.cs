using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Ahri.Config.Modes.LaneClear;

namespace KickassSeries.Champions.Ahri.Modes
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

            if (minion == null || Settings.ManaLane >= Player.Instance.ManaPercent) return;


            if (E.IsReady() && minion.IsValidTarget(E.Range) && Settings.UseE)
            {
                E.Cast(minion);
            }

            if (W.IsReady() && minion.IsValidTarget(W.Range) && Settings.UseW)
            {
                W.Cast();
            }

            if (Q.IsReady() && minion.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                var minions =
                   EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                       Player.Instance.ServerPosition, Q.Range, false).ToArray();
                if (minions.Length == 0) return;

                var farmLocation = EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, Q.Width, (int)Q.Range);
                if (farmLocation.HitNumber == Settings.MinQ)
                {
                    Q.Cast(farmLocation.CastPosition);
                }
            }
        }
    }
}
