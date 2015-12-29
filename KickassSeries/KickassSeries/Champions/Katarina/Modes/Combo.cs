using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Katarina.Config.Modes.Combo;

namespace KickassSeries.Champions.Katarina.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        private static bool _ulting;

        private static void CheckUlt()
        {
            _ulting = Player.Instance.Spellbook.IsChanneling;
        }

        private static void CancelCheck()
        {
            var target = TargetSelector.GetTarget(540, DamageType.Magical);
            if (target == null && Player.Instance.Spellbook.IsChanneling)
            {
                Orbwalker.DisableAttacking = false;
                Orbwalker.DisableMovement = false;
            }
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Magical);
            if (target == null) return;

            CheckUlt();
            /*

            if (KatarinaHu3.ComboMenu["Rcancel"].Cast<CheckBox>().CurrentValue)
            {
                CancelCheck();
            }
            */

            if (SpellManager.Q.IsReady() && target.IsValidTarget(Q.Range) && _ulting == false && Settings.UseQ)
            {
                SpellManager.Q.Cast(target);
            }

            if (SpellManager.E.IsReady() && target.IsValidTarget(E.Range) && _ulting == false && Settings.UseE)
            {
                SpellManager.E.Cast(target);
            }

            if (SpellManager.W.IsReady() && target.IsValidTarget(W.Range) && _ulting == false && Settings.UseW)
            {
                SpellManager.W.Cast();
            }

            if (SpellManager.R.IsReady() && target.IsValidTarget(R.Range) && _ulting == false && Settings.UseR)
            {
                Orbwalker.DisableAttacking = true;
                Orbwalker.DisableMovement = true;
                Core.DelayAction(() => SpellManager.R.Cast(), 50);
            }
        }
    }
}
