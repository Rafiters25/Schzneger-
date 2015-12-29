using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Other = KickassSeries.Champions.Ryze.Config.Modes.Other;
using Harass = KickassSeries.Champions.Ryze.Config.Modes.Harass;

namespace KickassSeries.Champions.Ryze
{
    internal class Functions
    {
        #region Getting Spells from SpellManager
        protected static Spell.Skillshot Q
        {
            get { return SpellManager.Q; }
        }
        protected static Spell.Targeted W
        {
            get { return SpellManager.W; }
        }
        protected static Spell.Targeted E
        {
            get { return SpellManager.E; }
        }
        protected static Spell.Active R
        {
            get { return SpellManager.R; }
        }
        #endregion Getting Spells from SpellManager

        public static void AutoStack()
        {
            var stacks = Player.Instance.GetBuffCount("ryzepassivestack");
            if (EntityManager.MinionsAndMonsters.CombinedAttackable.Any(x => x.IsValidTarget(SpellManager.Q.Range + 100))) return;
            if (EntityManager.Heroes.Enemies.Any(x => x.IsValidTarget(SpellManager.Q.Range + 150))) return;
            if (Player.Instance.IsRecalling() || Game.CursorPos.IsZero) return;
            if (Player.Instance.ManaPercent < Other.UseS3) return;
            if (Other.UseS)
            {
                if (!Other.UseS1 && stacks >= Other.UseS2) return;
                if (SpellManager.Q.IsReady())
                {
                    SpellManager.Q.Cast(Player.Instance.ServerPosition.Extend(Game.CursorPos, SpellManager.Q.Range).To3D());
                } 
            }
        }

        public static void AutoCc()
        {
            var autoCcTarget =
                EntityManager.Heroes.Enemies.FirstOrDefault(
                    x => x.IsValidTarget(SpellManager.Q.Range) &&
                         x.HasBuffOfType(BuffType.Charm) ||
                         x.HasBuffOfType(BuffType.Knockup) ||
                         x.HasBuffOfType(BuffType.Stun) ||
                         x.HasBuffOfType(BuffType.Suppression) ||
                         x.HasBuffOfType(BuffType.Snare));

            if (autoCcTarget != null && autoCcTarget.IsValidTarget(SpellManager.Q.Range))
            {
                if (Config.Modes.Combo.UseCC && SpellManager.Q.IsReady())
                {
                    Q.Cast(autoCcTarget);
                }

                if (Config.Modes.Combo.UseCC1 && SpellManager.W.IsReady())
                {
                    W.Cast(autoCcTarget);
                }

                if (Config.Modes.Combo.UseCC2 && SpellManager.E.IsReady())
                {
                    E.Cast(autoCcTarget);
                }
            }
        }

        public static void AutoHarass()
        {
            var stacks = Player.Instance.GetBuffCount("ryzepassivestack");
            var targetselector = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Magical);

            if (targetselector == null || targetselector.IsZombie) return;

            if (Harass.UseA)
            {
                if (!Harass.UseS && Harass.UseS1 <= stacks) return;

                if (SpellManager.Q.IsReady() && SpellManager.Q.IsInRange(targetselector))
                {
                    Q.Cast(Q.GetPrediction(targetselector).CastPosition);
                }

                if (SpellManager.W.IsReady() && SpellManager.W.IsInRange(targetselector))
                {
                    W.Cast(targetselector);
                }

                if (SpellManager.E.IsReady() && SpellManager.E.IsInRange(targetselector))
                {
                    E.Cast(targetselector);
                }
            }
        }

        public static void KillSteal()
        {
            foreach (
              var target in
                  EntityManager.Heroes.Enemies.Where(
                      hero =>
                          hero.IsValidTarget(SpellManager.R.Range) && !hero.IsDead && !hero.IsZombie && hero.HealthPercent <= 25))
            {

                if (Other.UseQ && SpellManager.Q.IsReady() &&
                    target.Health + target.AttackShield <=
                    Player.Instance.GetSpellDamage(target, SpellSlot.Q))
                {
                    Q.Cast(target.Position);
                }

                if (Other.UseWKS &&
                    target.Health + target.AttackShield <
                    Player.Instance.GetSpellDamage(target, SpellSlot.W) && Player.Instance.Mana >= 100)
                {
                    W.Cast(target);
                }

                if (Other.UseEKS && SpellManager.E.IsReady() &&
                    target.Health + target.AttackShield <
                    Player.Instance.GetSpellDamage(target, SpellSlot.E))
                {
                    E.Cast(target);
                }
            }
        }

        public static void AaBlock()
        {
            var combo = Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
            var targetselector = TargetSelector.GetTarget(1000, DamageType.Magical);
            if (targetselector == null)
            {
                Orbwalker.DisableAttacking = false;
                return;
            }
            if (Config.Modes.Combo.UseAA && combo)
            {
                Orbwalker.DisableAttacking = true;
            }
        }
    }
}
