using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Ryze.Config.Modes.Harass;

namespace KickassSeries.Champions.Ryze.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            if (target == null || target.IsZombie) return;

            if (Settings.UseQ && E.IsReady() && target.IsValidTarget(E.Range)
                && Player.Instance.ManaPercent >= Settings.UseQWE)
            {
                E.Cast(target);
            }

            if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range)
                && Player.Instance.ManaPercent >= Settings.UseQWE)
            {
                W.Cast(target);
            }

            if (Settings.UseE && Q.IsReady() && target.IsValidTarget(Q.Range)
                && Player.Instance.ManaPercent >= Settings.UseQWE)
            {
                Q.Cast(Q.GetPrediction(target).CastPosition);
            }
        }
    }
}
