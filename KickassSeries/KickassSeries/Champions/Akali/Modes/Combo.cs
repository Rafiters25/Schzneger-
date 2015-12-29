using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Akali.Config.Modes.Combo;

namespace KickassSeries.Champions.Akali.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(R.Range, DamageType.Magical);
            if (target == null || target.IsZombie) return;

            if (Q.IsReady() && target.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                Q.Cast(target);
            }
            //TODO GET Q BUFF NAME
            if (R.IsReady() && target.IsValidTarget(R.Range) && Settings.UseR && target.HasBuff("QBUFFNAME"))
            {
                R.Cast(target);
            }

            if (E.IsReady() && target.IsValidTarget(E.Range) && Settings.UseE)
            {
                E.Cast();
            }

            if (W.IsReady() && target.IsValidTarget(Q.Range) && Settings.UseW &&
                Player.Instance.CountEnemiesInRange(Q.Range) >= 2 || Player.Instance.HealthPercent <= 15)
            {
                W.Cast(Player.Instance);
            }
        }
    }
}
