﻿using System.Linq;
using EloBuddy.SDK;

using Settings = KickassSeries.Champions.Ryze.Config.Modes.LaneClear;

namespace KickassSeries.Champions.Ryze.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            var jgminion =
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .OrderByDescending(j => j.Health)
                    .FirstOrDefault(j => j.IsValidTarget(Q.Range));
            var stacks = EloBuddy.Player.Instance.GetBuffCount("ryzepassivestack");

            if (jgminion == null) return;
            if (Settings.UseQWER <= EloBuddy.Player.Instance.ManaPercent) return;
            if (Settings.UseS && Settings.UseS1 <= stacks) return;

            if (E.IsReady() && jgminion.IsValidTarget(E.Range) && Settings.UseE)
            {
                E.Cast(jgminion);
            }

            if (W.IsReady() && jgminion.IsValidTarget(W.Range) && Settings.UseW)
            {
                W.Cast(jgminion);
            }

            if (Q.IsReady() && jgminion.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                Q.Cast(jgminion);
            }

            if (R.IsReady() && jgminion.IsValidTarget(R.Range) && Settings.UseR)
            {
                R.Cast();
            }
        }
    }
}
