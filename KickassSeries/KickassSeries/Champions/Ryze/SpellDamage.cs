using EloBuddy;
using EloBuddy.SDK;

namespace KickassSeries.Champions.Ryze
{
    public static class SpellDamage
    {
        public static float GetTotalDamage(AIHeroClient target)
        {
            // Auto attack
            var damage = Player.Instance.GetAutoAttackDamage(target);

            // Q
            if (SpellManager.Q.IsReady())
            {
                damage += SpellManager.Q.GetRealDamage(target);
            }

            // W
            if (SpellManager.W.IsReady())
            {
                damage += SpellManager.W.GetRealDamage(target);
            }

            // E
            if (SpellManager.E.IsReady())
            {
                damage += SpellManager.E.GetRealDamage(target);
            }

            // R
            if (SpellManager.R.IsReady())
            {
                damage += SpellManager.R.GetRealDamage(target);
            }

            return damage;
        }

        public static float GetRealDamage(this Spell.SpellBase spell, Obj_AI_Base target)
        {
            return spell.Slot.GetRealDamage(target);
        }

        public static float GetRealDamage(this SpellSlot slot, Obj_AI_Base target)
        {
            // Helpers
            var spellLevel = Player.Instance.Spellbook.GetSpell(slot).Level;
            const DamageType damageType = DamageType.Magical;
            float damage = 0;
            var mana = Player.Instance.MaxMana;

            // Validate spell level
            if (spellLevel == 0)
            {
                return 0;
            }
            spellLevel--;

            switch (slot)
            {
                case SpellSlot.Q:

                    damage = new float[] { 60, 85, 110, 135, 160 }[spellLevel] +
                             0.55f * Player.Instance.FlatMagicDamageMod +
                             new[] { 0.02f * mana, 0.025f * mana, 0.03f * mana, 0.035f * mana, 0.04f * mana }[spellLevel];
                    break;

                case SpellSlot.W:

                    damage = new float[] { 80, 100, 120, 140, 160 }[spellLevel] +
                             0.4f * Player.Instance.FlatMagicDamageMod + 2.5f * mana;
                    break;

                case SpellSlot.E:

                    damage = new float[] { 54, 78, 102, 126, 150 }[spellLevel] + 0.3f * Player.Instance.FlatMagicDamageMod + 0.03f * mana;
                    break;

                case SpellSlot.R:

                    damage = new float[] { 0, 0, 0 }[spellLevel] + 0.0f * Player.Instance.FlatPhysicalDamageMod;
                    break;

            }

            if (damage <= 0)
            {
                return 0;
            }

            return Player.Instance.CalculateDamageOnUnit(target, damageType, damage) - 10;
        }
    }
}