using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace KickassSeries.Champions.Jax.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            if (Q.IsReady() && Player.Instance.HealthPercent <= 35 && Player.Instance.CountEnemiesInRange(Q.Range) >= 1)
            {
                var enemyminion =
                    EntityManager.MinionsAndMonsters.EnemyMinions.OrderByDescending(m => m.Distance(Game.CursorPos))
                        .FirstOrDefault(m => m.IsValidTarget(E.Range));
                if (enemyminion == null) return;

                Q.Cast(enemyminion);
            }
        }
    }
}
