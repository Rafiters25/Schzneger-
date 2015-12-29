using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Ryze.Config.Modes.LastHit;

namespace KickassSeries.Champions.Ryze.Modes
{
    public sealed class LastHit : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
            var minion =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.IsValidTarget(Q.Range));
            var minionQ =
                    EntityManager.MinionsAndMonsters.GetLaneMinions()
                        .OrderByDescending(m => m.Health)
                        .FirstOrDefault(
                            m => m.IsValidTarget(Q.Range) && m.Health <= SpellDamage.GetRealDamage(SpellSlot.Q, m));
            var minionW =
                    EntityManager.MinionsAndMonsters.GetLaneMinions()
                        .OrderByDescending(m => m.Health)
                        .FirstOrDefault(
                            m => m.IsValidTarget(W.Range) && m.Health <= SpellDamage.GetRealDamage(SpellSlot.W, m));
            var minionE =
                   EntityManager.MinionsAndMonsters.GetLaneMinions()
                       .OrderByDescending(m => m.Health)
                       .FirstOrDefault(
                           m => m.IsValidTarget(E.Range) && m.Health <= SpellDamage.GetRealDamage(SpellSlot.E, m));

            if (minion == null) return;

            if (E.IsReady() && minion.IsValidTarget(E.Range) && Settings.UseE)
            {
                E.Cast(minionE);
            }

            if (W.IsReady() && minion.IsValidTarget(W.Range) && Settings.UseW)
            {
                W.Cast(minionW);
            }

            if (Q.IsReady() && minion.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                Q.Cast(minionQ);
            }
        }
    }
}
