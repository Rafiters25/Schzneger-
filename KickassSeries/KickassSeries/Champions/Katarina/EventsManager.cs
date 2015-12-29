using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using KickassSeries.Champions.Katarina.Modes;

namespace KickassSeries.Champions.Katarina
{
    internal static class EventsManager
    {
        public static void Initialize()
        {
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
            GameObject.OnCreate += Obj_AI_Base_OnCreate;
        }

        private static void Obj_AI_Base_OnCreate(GameObject sender, System.EventArgs args)
        {
            var ward = sender as Obj_Ward;
            if(ward == null || !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee)) return;

            SpellManager.E.Cast(ward);
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!sender.IsEnemy) return;

            if (sender.IsValidTarget(SpellManager.E.Range))
            {
                Flee.WardJump(Player.Instance.Position.Shorten(sender.Position, SpellManager.E.Range));
            }
        }
    }
}
