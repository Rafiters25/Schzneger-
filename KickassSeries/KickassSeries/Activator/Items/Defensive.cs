using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace KickassSeries.Activator.Items
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Defensive : Ids
    {
        public static void Execute()
        {
            var target =
                EntityManager.Heroes.Enemies.FirstOrDefault(e => !e.IsDead && e.IsInRange(Player.Instance, 1500));

            if (Player.Instance.IsInShopRange() || target == null || DamageHandler.LastItemCast > Environment.TickCount)
                return;

            #region Self

            if (Zhonyas.IsReady() && Player.Instance.InDanger() && Zhonyas.IsOwned())
            {
                Zhonyas.Cast();
                DamageHandler.LastItemCast = Environment.TickCount + 450;
            }

            if (ArchengelStaff.IsReady() && Player.Instance.InDanger() && ArchengelStaff.IsOwned())
            {
                ArchengelStaff.Cast();
                DamageHandler.LastItemCast = Environment.TickCount + 450;
            }

            if (FaceOfTheMountain.IsReady() && Player.Instance.InDanger() && FaceOfTheMountain.IsOwned())
            {
                FaceOfTheMountain.Cast(Player.Instance);
                DamageHandler.LastItemCast = Environment.TickCount + 450;
            }

            if (Talisman.IsReady() && Player.Instance.CountAlliesInRange(450) >= 2 ||
                Player.Instance.InDanger() && FaceOfTheMountain.IsOwned())
            {
                FaceOfTheMountain.Cast();
                DamageHandler.LastItemCast = Environment.TickCount + 450;
            }

            if (Mikael.IsReady() && Player.Instance.InDanger() || Player.Instance.HasCC() && Mikael.IsOwned())
            {
                Mikael.Cast(Player.Instance);
                DamageHandler.LastItemCast = Environment.TickCount + 450;
            }

            if (Solari.IsReady() && Player.Instance.InDanger() && Solari.IsOwned())
            {
                Solari.Cast();
                DamageHandler.LastItemCast = Environment.TickCount + 450;
            }

            if (Ohm.IsReady() && Ohm.IsOwned())
            {
                var turret = EntityManager.Turrets.Enemies.FirstOrDefault(t => t.IsAttackingPlayer);
                if (turret != null)
                {
                    Ohm.Cast(turret);
                    DamageHandler.LastItemCast = Environment.TickCount + 450;
                }
            }

            if (Randuin.IsReady() && Player.Instance.CountEnemiesInRange(Randuin.Range) >= 2 && Randuin.IsOwned())
            {
                Randuin.Cast();
                DamageHandler.LastItemCast = Environment.TickCount + 450;
            }

            //CC

            if (!Player.Instance.HasCC()) return;

            if (DerbishBlade.IsReady() && DerbishBlade.IsOwned())
            {
                DerbishBlade.Cast();
                DamageHandler.LastItemCast = Environment.TickCount + 450;
            }

            if (Mercurial.IsReady() && Mercurial.IsOwned())
            {
                Mercurial.Cast();
                DamageHandler.LastItemCast = Environment.TickCount + 450;
            }

            if (QuickSilver.IsReady() && QuickSilver.IsOwned())
            {
                QuickSilver.Cast();
                DamageHandler.LastItemCast = Environment.TickCount + 450;
            }

            #endregion Self

            #region Ally

            if (DamageHandler.LastItemCast < Environment.TickCount)
            {
                if (FaceOfTheMountain.IsReady() && FaceOfTheMountain.IsOwned())
                {
                    foreach (
                        var ally in
                            EntityManager.Heroes.Allies.Where(
                                a => DamageHandler.Damages.ContainsKey(a.NetworkId) && a.InDanger()))
                    {
                        FaceOfTheMountain.Cast(ally);
                        DamageHandler.LastItemCast = Environment.TickCount + 450;
                    }
                }
            }

            if (Talisman.IsReady() && Player.Instance.CountAlliesInRange(450) >= 2 ||
                Player.Instance.InDanger() && FaceOfTheMountain.IsOwned())
            {
                foreach (
                    var ally in
                        EntityManager.Heroes.Allies.Where(
                            a => DamageHandler.Damages.ContainsKey(a.NetworkId) && a.InDanger()))
                {
                    FaceOfTheMountain.Cast(ally);
                    DamageHandler.LastItemCast = Environment.TickCount + 450;
                }
            }

            if (Mikael.IsReady() && Player.Instance.InDanger() || Player.Instance.HasCC() && Mikael.IsOwned())
            {
                foreach (
                    var ally in
                        EntityManager.Heroes.Allies.Where(
                            a => DamageHandler.Damages.ContainsKey(a.NetworkId) && a.InDanger()))
                {
                    Mikael.Cast(ally);
                    DamageHandler.LastItemCast = Environment.TickCount + 450;
                }
            }

            if (Solari.IsReady() && Player.Instance.InDanger() && Solari.IsOwned())
            {
                foreach (
                    var ally in
                        EntityManager.Heroes.Allies.Where(
                            a => DamageHandler.Damages.ContainsKey(a.NetworkId) && a.InDanger()))
                {
                    Solari.Cast(ally);
                    DamageHandler.LastItemCast = Environment.TickCount + 450;
                }
            }

            if (Ohm.IsReady() && Ohm.IsOwned())
            {
                foreach (var objAiTurret in EntityManager.Turrets.AllTurrets)
                {
                    if (DamageHandler.LastTargetTurrets.ContainsKey(objAiTurret.NetworkId))
                    {
                        var turrettarget = DamageHandler.LastTargetTurrets[objAiTurret.NetworkId];
                        if (!turrettarget.IsValidTarget() || !turrettarget.IsAlly) continue;
                        Ohm.Cast();
                        DamageHandler.LastItemCast = Environment.TickCount + 450;
                    }
                }
            }
        }
        #endregion Ally
    }
}


