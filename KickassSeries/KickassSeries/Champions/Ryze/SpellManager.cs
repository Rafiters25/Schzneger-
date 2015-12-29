using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace KickassSeries.Champions.Ryze
{
    public static class SpellManager
    {  
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Skillshot QWC { get; private set; }
        public static Spell.Targeted W { get; private set; }
        public static Spell.Targeted E { get; private set; }
        public static Spell.Active R { get; private set; }

        static SpellManager()
        {
            QWC = new Spell.Skillshot(SpellSlot.Q, 880, SkillShotType.Linear, 250, 1700, 50)
            {
                AllowedCollisionCount = int.MaxValue
            };
            Q = new Spell.Skillshot(SpellSlot.Q, 880, SkillShotType.Linear, 250, 1700, 50);
            W = new Spell.Targeted(SpellSlot.W, 600);
            E = new Spell.Targeted(SpellSlot.E, 600);
            R = new Spell.Active(SpellSlot.R, 1);
        }

        public static void Initialize()
        {
        }
    }
}
