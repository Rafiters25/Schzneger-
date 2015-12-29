using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

using Settings = KickassSeries.Activator.Config.Types.Settings;

// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace KickassSeries.Activator
{
    internal static class DamageHandler
    {
        public static Dictionary<int, SpellDamageClass> Damages = new Dictionary<int, SpellDamageClass>();
        public static readonly Dictionary<int, Obj_AI_Base> LastTargetTurrets = new Dictionary<int, Obj_AI_Base>();

        private static readonly List<SpellSlot> SpellSlots = new List<SpellSlot>()
        {
            SpellSlot.Q, SpellSlot.W, SpellSlot.E, SpellSlot.R
        };

        public static int LastItemCast;

        public static void Init()
        {
            foreach (var ally in EntityManager.Heroes.Allies)
            {
                Damages.Add(ally.NetworkId, new SpellDamageClass());
            }

            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            Obj_AI_Base.OnBasicAttack += Obj_AI_Base_OnBasicAttack;
        }

        private static void Obj_AI_Base_OnBasicAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender is Obj_AI_Turret)
            {
                LastTargetTurrets[sender.NetworkId] = args.Target as Obj_AI_Base;
            }

            if (sender.IsAlly || !Settings.CountAttacks || sender.IsMinion() && !Settings.CountMinions) return;
            if (!Damages.ContainsKey(args.Target.NetworkId)) return;

            var target = (Obj_AI_Base)args.Target;
            Damages[args.Target.NetworkId].AddDamage(args.SData.Name, sender.GetAutoAttackDamage(target),
                (target.IsMelee ? sender.AttackDelay : target.Distance(sender) / args.SData.MissileSpeed) * 1000);
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        { 
            var caster = sender as AIHeroClient;
            if (caster == null || sender.IsAlly || !SpellSlots.Contains(args.Slot) || !Settings.CountSpells) return;
            foreach (var target in EntityManager.Heroes.Allies)
            {
                if (!Damages.ContainsKey(target.NetworkId)) return;

                var dangerSpell =
                        DangerousSpells.Spells.FirstOrDefault(
                            a => a.Champion == caster.Hero && args.Slot == a.Slot && Config.Types.SettingsMenu[a.Champion.ToString() + a.Slot].Cast<CheckBox>().CurrentValue);
                if (dangerSpell != null)
                {
                    Damages[target.NetworkId].DangerousSpells.Add(Environment.TickCount + (dangerSpell.BonusDelay > 0 ? dangerSpell.BonusDelay : 2000), dangerSpell);
                }

                if (args.Target != null && args.Target.NetworkId == target.NetworkId && Settings.CountTargeted || Settings.CountTargeted && args.End != Vector3.Zero && args.End.Distance(target) < 200)
                {
                    Damages[target.NetworkId].AddDamage(args.SData.Name, caster.GetSpellDamage(target, args.Slot),
                        args.SData.MissileSpeed > 100 ? (target.Distance(sender) / args.SData.MissileSpeed) * 1000 : 1500);
                }
            }
        }

        #region Extensions

        public static float PredictedHealth(this AIHeroClient target)
        {
            if (!Damages.ContainsKey(target.NetworkId)) return target.Health;
            return target.Health - Damages[target.NetworkId].Damage;
        }

        public static bool InDanger(this AIHeroClient target, bool execute = false)
        {
            if (!Damages.ContainsKey(target.NetworkId)) return false;
            if (execute && Settings.DisableExeCheck) execute = false;
            return Damages[target.NetworkId].Damage > target.Health
                || !execute && Settings.DangerHP && target.HealthPercent <= Settings.HealthDanger && (!Settings.RequiresEnemy || target.CountEnemiesInRange(Settings.RangeEnemy) >= Settings.EnemyCount)
                || (Damages[target.NetworkId].Damage / target.MaxHealth) > 0.15 && !execute
                || target.NetworkId == Player.Instance.NetworkId && Damages[target.NetworkId].DangerousSpells.Any() && !execute;
        }

        #endregion Extensions
    }

    public class DamageSpell
    {
        public float Damage;
        public float EndTime;

        public DamageSpell(float endTime, float damage)
        {
            EndTime = (int)endTime;
            Damage = damage;
        }
    }

    public class SpellDamageClass
    {
        private readonly ConcurrentDictionary<string, DamageSpell> _damages =
            new ConcurrentDictionary<string, DamageSpell>();

        public Dictionary<int, DangerousSpell> DangerousSpells = new Dictionary<int, DangerousSpell>();

        public SpellDamageClass()
        {
            foreach (var source in DangerousSpells.ToList().Where(source => source.Key < Environment.TickCount))
            {
                DangerousSpells.Remove(source.Key);
            }
        }

        public float Damage
        {
            get
            {
                float dmg = 0;
                var damages = _damages;
                foreach (var damage in damages)
                {
                    if (damage.Value.EndTime < Environment.TickCount)
                    {
                        DamageSpell l;
                        _damages.TryRemove(damage.Key, out l);
                        continue;
                    }
                    dmg += damage.Value.Damage;
                }
                return dmg;
            }
        }

        public void AddDamage(string spellName, float dmg, float endTime = 1500)
        {
            if (_damages.ContainsKey(spellName))
            {
                _damages[spellName] = new DamageSpell(Environment.TickCount + endTime, dmg);
                return;
            }
            _damages.TryAdd(spellName, new DamageSpell(Environment.TickCount + endTime, dmg));
        }
    }

    public static class DangerousSpells
    {
        public static List<DangerousSpell> Spells = new List<DangerousSpell>()
        {
            new DangerousSpell(Champion.Annie, SpellSlot.R),
            new DangerousSpell(Champion.Caitlyn, SpellSlot.R),
            new DangerousSpell(Champion.Darius, SpellSlot.R),
            new DangerousSpell(Champion.Malphite, SpellSlot.R),
            new DangerousSpell(Champion.Zed, SpellSlot.R, 3900) {IsCleanseable = true},
            new DangerousSpell(Champion.Yasuo, SpellSlot.R),
            new DangerousSpell(Champion.Syndra, SpellSlot.R),
            new DangerousSpell(Champion.Ahri, SpellSlot.E , 600) {IsCleanseable = true},
            new DangerousSpell(Champion.Amumu, SpellSlot.R),
            new DangerousSpell(Champion.Ashe, SpellSlot.R),
            new DangerousSpell(Champion.Braum, SpellSlot.R),
            new DangerousSpell(Champion.Gnar, SpellSlot.R),
            new DangerousSpell(Champion.Gragas, SpellSlot.R),
            new DangerousSpell(Champion.Lux, SpellSlot.R),
            new DangerousSpell(Champion.Lux, SpellSlot.Q , 600) {IsCleanseable = true},
            new DangerousSpell(Champion.Varus, SpellSlot.R , 600) {IsCleanseable = true},
            new DangerousSpell(Champion.Veigar, SpellSlot.E, 600) {IsCleanseable = true},
            new DangerousSpell(Champion.Nami, SpellSlot.R),
            new DangerousSpell(Champion.Nami, SpellSlot.Q, 600) {IsCleanseable = true},
            new DangerousSpell(Champion.Sona, SpellSlot.R, 600) {IsCleanseable = true},
            new DangerousSpell(Champion.Shen, SpellSlot.E, 600) {IsCleanseable = true},
            new DangerousSpell(Champion.Riven, SpellSlot.R),
            new DangerousSpell(Champion.Blitzcrank, SpellSlot.Q),
            new DangerousSpell(Champion.Blitzcrank, SpellSlot.R),
            new DangerousSpell(Champion.Morgana, SpellSlot.Q, 600) {IsCleanseable = true},
            new DangerousSpell(Champion.Morgana, SpellSlot.R, 600) {IsCleanseable = true},
            new DangerousSpell(Champion.Vayne, SpellSlot.E, 600) {IsCleanseable = true},
            new DangerousSpell(Champion.Pantheon, SpellSlot.W),
            new DangerousSpell(Champion.Garen, SpellSlot.R),
            new DangerousSpell(Champion.JarvanIV, SpellSlot.R),
            new DangerousSpell(Champion.Lulu, SpellSlot.W, 600) {IsCleanseable = true},
            new DangerousSpell(Champion.Mordekaiser, SpellSlot.R),
            new DangerousSpell(Champion.Vladimir, SpellSlot.R),
        };
    }

    public class DangerousSpell
    {
        public DangerousSpell(Champion champ, SpellSlot slot, int bonusDelay = 0)
        {
            Slot = slot;
            Champion = champ;
            BonusDelay = bonusDelay;
        }

        public SpellSlot Slot;
        public Champion Champion;
        public int BonusDelay;
        public bool IsCleanseable = false;
    }
}