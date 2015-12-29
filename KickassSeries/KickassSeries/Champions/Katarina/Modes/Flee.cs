using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace KickassSeries.Champions.Katarina.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        private static int _lastWardCast;

        private static InventorySlot GetWard()
        {
            var wards = new[]
            {
                ItemId.Warding_Totem_Trinket, ItemId.Sightstone, ItemId.Ruby_Sightstone,
                ItemId.Greater_Stealth_Totem_Trinket, ItemId.Greater_Vision_Totem_Trinket,
                ItemId.Stealth_Ward, ItemId.Vision_Ward
            };
            return
                Player.Instance.InventoryItems.FirstOrDefault(a => wards.Contains(a.Id) && a.IsWard && a.CanUseItem());
        }

        public static void WardJump(Vector3 pos)
        {
            if (SpellManager.E.IsReady() && _lastWardCast + 500 < Environment.TickCount)
            {
                GetWard().Cast(Player.Instance.Position.Extend(pos, 600).To3D());
                _lastWardCast = Environment.TickCount;
            }
        }

        public override void Execute()
        {  
            WardJump(Game.CursorPos);
        }
    }
}
