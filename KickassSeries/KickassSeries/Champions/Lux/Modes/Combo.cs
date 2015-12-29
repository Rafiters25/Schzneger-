using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Lux.Config.Modes.Combo;

namespace KickassSeries.Champions.Lux.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            if (target == null || target.IsZombie) return;

            if (Q.IsReady() && target.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                Q.Cast(target);
            }

            if (E.IsReady() && target.IsValidTarget(E.Range) && Settings.UseE)
            {
                E.Cast(target);
            }

            if (W.IsReady() && target.IsValidTarget(W.Range) && Settings.UseW)
            {
                W.Cast();
            }

            if (R.IsReady() && Settings.UseR)
            {
                var targetR = TargetSelector.GetTarget(R.Range, DamageType.Magical);

                if (targetR == null)return;
                R.Cast(targetR);
            }
        }
    }
}
