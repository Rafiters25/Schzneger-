using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = KickassSeries.Activator.Config.Types.ConsumablesItems;

namespace KickassSeries.Activator.Items
{
    // ReSharper disable once ClassNeverInstantiated.Global

    public sealed class Consumables : Ids
    {
        private static int LastRun;

        public static void Execute()
        {
            if (LastRun > Environment.TickCount)return;

            var target = EntityManager.Heroes.Enemies.FirstOrDefault(e => !e.IsDead && e.IsInRange(Player.Instance, 1000));

            if (Player.Instance.IsRecalling() || Player.Instance.IsInShopRange() || target == null) return;

            if (Settings.UseHPpot && HealthPotion.IsOwned())
            {
                if (Player.Instance.HealthPercent <= Settings.MinHPpot && !Player.Instance.HasBuff("RegenerationPotion"))
                {
                    HealthPotion.Cast();
                }
            }

            if (Settings.UseBiscuits && Biscuit.IsOwned())
            {
                if (Player.Instance.ManaPercent <= Settings.MinBiscuitMp && Player.Instance.HealthPercent <= Settings.MinBiscuitHp && !Player.Instance.HasBuff("ItemMiniRegenPotion"))
                {
                    Biscuit.Cast();
                }
            }

            if (Settings.UseRefillPOT && RefilablePotion.IsOwned())
            {
                if (Player.Instance.HealthPercent <= Settings.MinRefillHp && !Player.Instance.HasBuff("ItemCrystalFlask"))
                {
                    RefilablePotion.Cast();
                }
            }

            if (Settings.UseCorrupts && CorruptingPotion.IsOwned())
            {
                if (Player.Instance.ManaPercent <= Settings.MinCorruptMp && Player.Instance.HealthPercent <= Settings.MinCorruptHp && !Player.Instance.HasBuff("ItemDarkCrystalFlask"))
                {
                    CorruptingPotion.Cast();
                }
            }

            if (Settings.UseCorrupts && CorruptingPotion.IsOwned())
            {
                if (Player.Instance.ManaPercent <= Settings.MinCorruptMp && Player.Instance.HealthPercent <= Settings.MinCorruptHp && !Player.Instance.HasBuff("ItemDarkCrystalFlask"))
                {
                    CorruptingPotion.Cast();
                }
            }

            if (Settings.UseHunters && HuntersPotion.IsOwned())
            {
                if (Player.Instance.ManaPercent <= Settings.MinHunterMp && Player.Instance.HealthPercent <= Settings.MinHunterHp && !Player.Instance.HasBuff("ItemDarkCrystalFlask"))
                {
                    HuntersPotion.Cast();
                }

                if (Settings.UseHuntersMinionWillDie)
                {
                    var BigJGMinion =
                        EntityManager.MinionsAndMonsters.GetJungleMonsters()
                            .FirstOrDefault(
                                m =>
                                    m.BaseSkinName == "SRU_Baron" || m.BaseSkinName == "SRU_Dragon" ||
                                    m.BaseSkinName == "SRU_Blue" || m.BaseSkinName == "SRU_Red" ||
                                    m.BaseSkinName == "Sru_Crab" || m.BaseSkinName == "SRU_Gromp" ||
                                    m.BaseSkinName == "SRU_Murkwolf" || m.BaseSkinName == "SRU_Krug" ||
                                    m.BaseSkinName == "SRU_Razorbeak" && m.IsValidTarget(500) && m.Health <= 150);

                    if (BigJGMinion == null)return;

                    HuntersPotion.Cast();
                }
            }

            LastRun = Environment.TickCount + 10000;
        }
    }
}
