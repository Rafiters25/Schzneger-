using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;


namespace KickassSeries.Champions.Ryze
{
    internal static class EventsManager
    {
        public static void Initialize()
        {
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!e.Sender.IsValidTarget() || e.Sender.Type != Player.Instance.Type || !e.Sender.IsEnemy)
            {
                return;
            }
            if (Config.Modes.Other.UseW && SpellManager.W.IsReady() && SpellManager.W.IsInRange(sender))
            {
                SpellManager.W.Cast(sender);
            }
            if (Config.Modes.Other.UseR && SpellManager.R.IsReady() && SpellManager.R.IsInRange(sender))
            {
                SpellManager.R.Cast();
            }
        }

    }
}
