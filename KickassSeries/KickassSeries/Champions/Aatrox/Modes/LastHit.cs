using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Alistar.Config.Modes.LastHit;

namespace KickassSeries.Champions.Aatrox.Modes
{
    public sealed class LastHit : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
            var laneminion =
                EntityManager.MinionsAndMonsters.GetLaneMinions().FirstOrDefault(m => m.IsValidTarget(Q.Range));
            if (laneminion == null) return;

            if (Q.IsReady() && laneminion.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                var minionQ =
                    EntityManager.MinionsAndMonsters.GetLaneMinions()
                        .OrderByDescending(m => m.Health)
                        .FirstOrDefault(
                            m => m.IsValidTarget(Q.Range) && m.Health <= SpellDamage.GetRealDamage(SpellSlot.Q, m));

                if (minionQ != null)
                {
                    Q.Cast(minionQ);
                }
            }

            if (E.IsReady() && laneminion.IsValidTarget(E.Range) && Settings.UseE)
            {
                var minionE =
                    EntityManager.MinionsAndMonsters.GetLaneMinions()
                        .OrderByDescending(m => m.Health)
                        .FirstOrDefault(
                            m => m.IsValidTarget(E.Range) && m.Health <= SpellDamage.GetRealDamage(SpellSlot.E, m));

                if (minionE != null)
                {
                    Q.Cast(minionE);
                }
            }
        }
    }
}
