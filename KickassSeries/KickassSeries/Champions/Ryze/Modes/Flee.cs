using EloBuddy;
using EloBuddy.SDK;

namespace KickassSeries.Champions.Ryze.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            if (target == null || target.IsZombie) return;

            if (Config.Modes.Other.UseM >= Player.Instance.ManaPercent && target.IsValidTarget(1000) && R.IsReady())
            {
                R.Cast();
            }
        }
    }
}
