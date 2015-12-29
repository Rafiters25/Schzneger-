using System;
using EloBuddy;
using KickassSeries.Activator.Items;

namespace KickassSeries.Activator
{
    public static class Activator
    {
        public static void Init()
        {
            Config.Initialize();

            DamageHandler.Init();


            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            Defensive.Execute();
            Offensive.Execute();
            Consumables.Execute();
        }
    }
}
