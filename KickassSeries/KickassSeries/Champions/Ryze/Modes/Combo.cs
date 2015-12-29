using EloBuddy;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Ryze.Config.Modes.Combo;

namespace KickassSeries.Champions.Ryze.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(W.Range, DamageType.Magical);

            if (target == null || target.IsZombie) return;

            var stacks = Player.Instance.GetBuffCount("ryzepassivestack");
            var stacksOn = Player.Instance.HasBuff("ryzepassivecharged");
            var snared = target.HasBuff("RyzeW");

            if (stacks <= 1 && !stacksOn)
            {
                if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range))
                {
                    Q.Cast(Q.GetPrediction(target).CastPosition);
                }

                if (Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range))
                {
                    E.Cast(target);
                }

                if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range))
                {
                    W.Cast(target);
                }

                if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range) && snared)
                {
                    R.Cast();
                }
            }
            if (stacks == 2)
            {
                if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range))
                {
                    Q.Cast(Q.GetPrediction(target).CastPosition);
                }

                if (Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range))
                {
                    E.Cast(target);
                }

                if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range))
                {
                    W.Cast(target);
                }

                if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range) && snared)
                {
                    R.Cast();
                }
            }

            if (stacks == 3)
            {
                if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range))
                {
                    Q.Cast(Q.GetPrediction(target).CastPosition);
                }

                if (Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range))
                {
                    E.Cast(target);
                }

                if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range))
                {
                    W.Cast(target);
                }

                if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range) && snared)
                {
                    R.Cast();
                }
            }
            if (stacks == 4)
            {
                if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range))
                {
                    W.Cast(target);
                }

                if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range))
                {
                    Q.Cast(Q.GetPrediction(target).CastPosition);
                }

                if (Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range))
                {
                    E.Cast(target);
                }

                if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range) && snared)
                {
                    R.Cast();
                }
            }

            if (stacksOn)
            {
                if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range))
                {
                    W.Cast(target);
                }

                if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range))
                {
                    Q.Cast(Q.GetPrediction(target).CastPosition);
                }

                if (Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range))
                {
                    E.Cast(target);
                }

                if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range) && snared)
                {
                    R.Cast();
                }
            }
            if (stacksOn)
            {
                if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range))
                {
                    Q.Cast(Q.GetPrediction(target).CastPosition);
                }

                if (Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range))
                {
                    E.Cast(target);
                }

                if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range) && snared)
                {
                    R.Cast();
                }
            }

            else if (Settings.UseW && W.IsReady() && target.IsValidTarget(W.Range))
            {
                W.Cast(target);
            }

            if (Settings.UseQ && Q.IsReady() && target.IsValidTarget(Q.Range))
            {
                Q.Cast(Q.GetPrediction(target).CastPosition);
            }

            if (Settings.UseE && E.IsReady() && target.IsValidTarget(E.Range))
            {
                E.Cast(target);
            }

            if (Settings.UseR && R.IsReady() && target.IsValidTarget(R.Range) && snared)
            {
                R.Cast();
            }
        }
    }
}

