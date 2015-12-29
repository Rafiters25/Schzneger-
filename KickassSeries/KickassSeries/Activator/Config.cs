using System.Linq;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberHidesStaticFromOuterClass

namespace KickassSeries.Activator
{
    internal static class Config
    {
        private const string MenuName = "KA Activator";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("KA Activator");
            Menu.AddLabel("Made By: MarioGK", 50);

            // Initialize the modes
            Types.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Types
        {
            private static readonly Menu OffensiveMenu, DefensiveMenu, ConsumablesMenu, DrawMenu;
            public static readonly Menu SummonerMenu, SettingsMenu;

            static Types()
            {
                OffensiveMenu = Menu.AddSubMenu("Offensive Items");
                OffensiveItems.Initialize();

                DefensiveMenu = Menu.AddSubMenu("Defensive Items");
                DeffensiveItems.Initialize();

                ConsumablesMenu = Menu.AddSubMenu("Consumables Items");
                ConsumablesItems.Initialize();

                SummonerMenu = Menu.AddSubMenu("Summoner Spells");
                SummonerSpells.Initialize();

                DrawMenu = Menu.AddSubMenu("Drawings");
                DrawMenu.AddLabel("SOON");

                SettingsMenu = Menu.AddSubMenu("Settings");
                Settings.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class OffensiveItems
            {
                private static readonly CheckBox UseMuramana;
                private static readonly CheckBox UseFrostQueen;

                #region Bilgewater

                private static readonly CheckBox UseBilgewater;
                private static readonly Slider MyHpBilgewater;
                private static readonly Slider TargetHpBilgewater;

                public static bool Bilgewater
                {
                    get { return UseBilgewater.CurrentValue; }
                }

                public static int BilgewaterMyHp
                {
                    get { return MyHpBilgewater.CurrentValue; }
                }

                public static int BilgewaterTargetHp
                {
                    get { return TargetHpBilgewater.CurrentValue; }
                }

                #endregion Bilgewater

                #region BladeOfTheRuinedKing

                private static readonly CheckBox UseBlade;
                private static readonly Slider MyHpBlade;
                private static readonly Slider TargetHpBlade;

                public static bool Blade
                {
                    get { return UseBlade.CurrentValue; }
                }

                public static int BladeMyHp
                {
                    get { return MyHpBlade.CurrentValue; }
                }

                public static int BladeTargetHp
                {
                    get { return TargetHpBlade.CurrentValue; }
                }

                #endregion BladeOfTheRuinedKing

                #region Tiamat

                private static readonly CheckBox UseTiamat;
                private static readonly Slider MyHpTiamat;
                private static readonly Slider TargetHpTiamat;

                public static bool Tiamat
                {
                    get { return UseTiamat.CurrentValue; }
                }

                public static int TiamatMyHp
                {
                    get { return MyHpTiamat.CurrentValue; }
                }

                public static int TiamatTargetHp
                {
                    get { return TargetHpTiamat.CurrentValue; }
                }

                #endregion Tiamat

                #region Hydra

                private static readonly CheckBox UseHydra;
                private static readonly Slider MyHpHydra;
                private static readonly Slider TargetHpHydra;

                public static bool Hydra
                {
                    get { return UseHydra.CurrentValue; }
                }

                public static int HydraMyHp
                {
                    get { return MyHpHydra.CurrentValue; }
                }

                public static int HydraTargetHp
                {
                    get { return TargetHpHydra.CurrentValue; }
                }

                #endregion Hydra

                #region Titanic

                private static readonly CheckBox UseTitanicHydra;
                private static readonly Slider MyHpTitanicHydra;
                private static readonly Slider TargetHpTitanicHydra;

                public static bool Titanic
                {
                    get { return UseTitanicHydra.CurrentValue; }
                }

                public static int TitanicMyHp
                {
                    get { return MyHpTitanicHydra.CurrentValue; }
                }

                public static int TitanicTargetHp
                {
                    get { return TargetHpTitanicHydra.CurrentValue; }
                }

                #endregion Titanic

                #region Youmuu

                private static readonly CheckBox UseYoumuu;
                private static readonly Slider MyHpYoumuu;
                private static readonly Slider TargetHpYoumuu;

                public static bool Youmuu
                {
                    get { return UseYoumuu.CurrentValue; }
                }

                public static int YoumuuMyHp
                {
                    get { return MyHpYoumuu.CurrentValue; }
                }

                public static int YoumuuTargetHp
                {
                    get { return TargetHpYoumuu.CurrentValue; }
                }

                #endregion Youmuu

                #region Hextech

                private static readonly CheckBox UseHextech;
                private static readonly Slider MyHpHextech;
                private static readonly Slider TargetHpHextech;

                public static bool Hextech
                {
                    get { return UseHextech.CurrentValue; }
                }

                public static int HextechMyHp
                {
                    get { return MyHpHextech.CurrentValue; }
                }

                public static int HextechTargetHp
                {
                    get { return TargetHpHextech.CurrentValue; }
                }

                #endregion Hextech


                #region Offensive Menu

                static OffensiveItems()
                {
                    // Initialize the menu values
                    OffensiveMenu.AddGroupLabel("Bilgewater Cutlass");
                    UseBilgewater = OffensiveMenu.Add("useBilgewater", new CheckBox("Use Bilgewater Cutlass ?"));
                    MyHpBilgewater = OffensiveMenu.Add("useBilgewaterMyHP",
                        new Slider("Use Bilgewater Cutlass When My Health hits X%", 80));
                    TargetHpBilgewater = OffensiveMenu.Add("useBilgewaterTargetHP",
                        new Slider("Use Bilgewater Cutlass When Target`s Health hits X%", 80));
                    OffensiveMenu.AddSeparator();

                    OffensiveMenu.AddGroupLabel("Blade Of The Ruined King");
                    UseBlade = OffensiveMenu.Add("useBlade", new CheckBox("Use Blade Of The Ruined King ?"));
                    MyHpBlade = OffensiveMenu.Add("useBladeMyHP",
                        new Slider("Use Blade Of The Ruined King When My Health hits X%", 80));
                    TargetHpBlade = OffensiveMenu.Add("useBladeTargetHP",
                        new Slider("Use Blade Of The Ruined King When Target`s Health hits X%", 80));
                    OffensiveMenu.AddSeparator();

                    OffensiveMenu.AddGroupLabel("Tiamat");
                    UseTiamat = OffensiveMenu.Add("useTiamat", new CheckBox("Use Tiamat ?"));
                    MyHpTiamat = OffensiveMenu.Add("useTiamatMyHP",
                        new Slider("Use Tiamat When My Health hits X%", 80));
                    TargetHpTiamat = OffensiveMenu.Add("useTiamatTargetHP",
                        new Slider("Use Tiamat When Target`s Health hits X%", 80));
                    OffensiveMenu.AddSeparator();

                    OffensiveMenu.AddGroupLabel("Ravenous Hydra");
                    UseHydra = OffensiveMenu.Add("useHydra", new CheckBox("Use Ravenous Hydra ?"));
                    MyHpHydra = OffensiveMenu.Add("useHydraMyHP",
                        new Slider("Use Ravenous Hydra When My Health hits X%", 80));
                    TargetHpHydra = OffensiveMenu.Add("useHydraTargetHP",
                        new Slider("Use Ravenous Hydra When Target`s Health hits X%", 80));
                    OffensiveMenu.AddSeparator();

                    OffensiveMenu.AddGroupLabel("Titanic Hydra");
                    UseTitanicHydra = OffensiveMenu.Add("useTitanic", new CheckBox("Use Titanic Hydra ?"));
                    MyHpTitanicHydra = OffensiveMenu.Add("useTitanicMyHP",
                        new Slider("Use Titanic Hydra When My Health hits X%", 80));
                    TargetHpTitanicHydra = OffensiveMenu.Add("useTitanicTargetHP",
                        new Slider("Use Titanic Hydra When Target`s Health hits X%", 80));
                    OffensiveMenu.AddSeparator();

                    OffensiveMenu.AddGroupLabel("Youmuu");
                    UseYoumuu = OffensiveMenu.Add("useYoumuu ", new CheckBox("Use Youmuu ?"));
                    MyHpYoumuu = OffensiveMenu.Add("useYoumuu MyHP",
                        new Slider("Use Youmuu  When My Health hits X%", 80));
                    TargetHpYoumuu = OffensiveMenu.Add("useYoumuuTargetHP",
                        new Slider("Use Youmuu  When Target`s Health hits X%", 80));
                    OffensiveMenu.AddSeparator();

                    OffensiveMenu.AddGroupLabel("Hextech");
                    UseHextech = OffensiveMenu.Add("useHextech", new CheckBox("Use Hextech ?"));
                    MyHpHextech = OffensiveMenu.Add("useHextech MyHP",
                        new Slider("Use Hextech When My Health hits X%", 80));
                    TargetHpHextech = OffensiveMenu.Add("useHextechTargetHP",
                        new Slider("Use Hextech When Target`s Health hits X%", 80));
                    OffensiveMenu.AddSeparator();

                }

                #endregion Offensive Menu

                public static void Initialize()
                {
                }
            }

            public static class DeffensiveItems
            {
                #region Zhonyas

                private static readonly CheckBox UseZhonyas;
                private static readonly Slider HpZhonyas;

                public static bool Bilgewater
                {
                    get { return UseZhonyas.CurrentValue; }
                }

                public static int BilgewaterMyHp
                {
                    get { return HpZhonyas.CurrentValue; }
                }

                #endregion Zhonyas

                #region ArchengelStaff

                private static readonly CheckBox UseArchengelStaff;
                private static readonly Slider MyHPArchengelStaff;

                public static bool ArchengelStaff
                {
                    get { return UseArchengelStaff.CurrentValue; }
                }

                public static int MYHPArchengelStaff
                {
                    get { return MyHPArchengelStaff.CurrentValue; }
                }

                #endregion ArchengelStaff

                static DeffensiveItems()
                {
                    DefensiveMenu.AddGroupLabel("Defensive Menu");
                    DefensiveMenu.AddLabel("Please configure if the player is in danger in the settings menu");
                    // Initialize the menu values
                    DefensiveMenu.AddGroupLabel("Zhonyas");
                    UseZhonyas = OffensiveMenu.Add("useZhonyas", new CheckBox("Use Zhonyas ?"));
                    HpZhonyas = OffensiveMenu.Add("useZhonyasrMyHP",
                        new Slider("Use Zhonyas When My Health hits X%", 20));
                    DefensiveMenu.AddSeparator();

                    DefensiveMenu.AddGroupLabel("ArchengelStaff");
                    UseArchengelStaff = OffensiveMenu.Add("useArchengelStaff", new CheckBox("Use ArchengelStaff ?"));
                    MyHPArchengelStaff = OffensiveMenu.Add("useArchengelStaffMyHP",
                        new Slider("Use ArchengelStaff When My Health hits X%", 80));
                    DefensiveMenu.AddSeparator();
                }

                public static void Initialize()
                {
                }
                
                }

                public static class ConsumablesItems
            {
                #region HP Pot

                private static readonly CheckBox UseHealthPot;
                private static readonly Slider MinHealthPot;

                public static bool UseHPpot
                {
                    get { return UseHealthPot.CurrentValue; }
                }

                public static int MinHPpot
                {
                    get { return MinHealthPot.CurrentValue; }
                }

                #endregion HP Pot

                #region Biscuit

                private static readonly CheckBox UseBiscuit;
                private static readonly Slider MinHealthBiscuit;
                private static readonly Slider MinManaBiscuit;

                public static bool UseBiscuits
                {
                    get { return UseBiscuit.CurrentValue; }
                }

                public static int MinBiscuitHp
                {
                    get { return MinHealthBiscuit.CurrentValue; }
                }

                public static int MinBiscuitMp
                {
                    get { return MinManaBiscuit.CurrentValue; }
                }

                #endregion Biscuit

                #region Refill

                private static readonly CheckBox UseRefillPotion;
                private static readonly Slider MinHPRefillPotion;

                public static bool UseRefillPOT
                {
                    get { return UseRefillPotion.CurrentValue; }
                }

                public static int MinRefillHp
                {
                    get { return MinHPRefillPotion.CurrentValue; }
                }

                #endregion Refill

                #region Corrupt

                private static readonly CheckBox UseCorrupt;
                private static readonly Slider MinHealthCorrupt;
                private static readonly Slider MinManaCorrupt;

                public static bool UseCorrupts
                {
                    get { return UseCorrupt.CurrentValue; }
                }

                public static int MinCorruptHp
                {
                    get { return MinHealthCorrupt.CurrentValue; }
                }

                public static int MinCorruptMp
                {
                    get { return MinManaCorrupt.CurrentValue; }
                }

                #endregion Corrupt

                #region Hunter`s

                private static readonly CheckBox UseHunter;
                private static readonly Slider MinHealthHunter;
                private static readonly Slider MinManaHunter;
                private static readonly CheckBox UseHunterMinionWillDie;

                public static bool UseHunters
                {
                    get { return UseHunter.CurrentValue; }
                }

                public static int MinHunterHp
                {
                    get { return MinHealthHunter.CurrentValue; }
                }

                public static int MinHunterMp
                {
                    get { return MinManaHunter.CurrentValue; }
                }

                public static bool UseHuntersMinionWillDie
                {
                    get { return UseHunterMinionWillDie.CurrentValue; }
                }

                #endregion Hunter`s

                static ConsumablesItems()
                {
                    // Initialize the menu values
                    ConsumablesMenu.AddGroupLabel("Health Pot");
                    UseHealthPot = ConsumablesMenu.Add("useHealthPot", new CheckBox("Use Health Pot ?"));
                    MinHealthPot = ConsumablesMenu.Add("minHealthPot", new Slider("Min Health to use Health Pot", 30));
                    ConsumablesMenu.AddSeparator();

                    ConsumablesMenu.AddGroupLabel("Biscuit");
                    UseBiscuit = ConsumablesMenu.Add("useBiscuit", new CheckBox("Use Biscuit ?"));
                    MinHealthBiscuit = ConsumablesMenu.Add("minhpBiscuit", new Slider("Min Health to use Biscuit", 30));
                    MinManaBiscuit = ConsumablesMenu.Add("minmpBiscuit", new Slider("Min Mana to use Biscuit", 30));
                    ConsumablesMenu.AddSeparator();

                    ConsumablesMenu.AddGroupLabel("Refill Potion");
                    UseRefillPotion = ConsumablesMenu.Add("useRefill", new CheckBox("Use Refill Potion ?"));
                    MinHPRefillPotion = ConsumablesMenu.Add("minhpRefill",
                        new Slider("Min Health to use Refill Potion", 30));
                    ConsumablesMenu.AddSeparator();

                    ConsumablesMenu.AddGroupLabel("Corrupt Potion");
                    UseCorrupt = ConsumablesMenu.Add("useCorrupt", new CheckBox("Use Corrupt Potion ?"));
                    MinHealthCorrupt = ConsumablesMenu.Add("minhpCorrupt",
                        new Slider("Min Health to use Corrupt Potion", 30));
                    MinManaCorrupt = ConsumablesMenu.Add("minmpCorrupt",
                        new Slider("Min Mana to use Corrupt Potion", 30));
                    ConsumablesMenu.AddSeparator();

                    ConsumablesMenu.AddGroupLabel("Hunter`s Potion");
                    UseHunter = ConsumablesMenu.Add("useHunter", new CheckBox("Use Hunter`s Potion ?"));
                    MinHealthHunter = ConsumablesMenu.Add("minhpHunter",
                        new Slider("Min Health to use Hunter`s Potion", 30));
                    MinManaHunter = ConsumablesMenu.Add("minmpHunter", new Slider("Min Mana to use Hunter`s Potion", 30));
                    UseHunterMinionWillDie = ConsumablesMenu.Add("useHunterMinionWillDie",
                        new CheckBox("Use Hunter`s Potion when jungle minion will die ?"));
                    ConsumablesMenu.AddSeparator();
                }

                public static void Initialize()
                {
                }
            }

            public static class SummonerSpells
            {
                #region Smite

                private static readonly CheckBox UseSmite;
                private static readonly CheckBox UseSmiteDuel;
                private static readonly CheckBox UseSmiteKs;


                public static bool Smite
                {
                    get { return UseSmite.CurrentValue; }
                }

                public static bool DuelSmite
                {
                    get { return UseSmiteDuel.CurrentValue; }
                }

                public static bool KsSmite
                {
                    get { return UseSmiteKs.CurrentValue; }
                }

                #endregion Smite

                #region Heal

                private static readonly CheckBox Heal;

                public static bool UseHeal
                {
                    get { return Heal.CurrentValue; }
                }

                #endregion Heal

                #region Barrier

                private static readonly CheckBox Barrier;

                public static bool UseBarrier
                {
                    get { return Barrier.CurrentValue; }
                }

                #endregion Barrier

                #region Ghost

                private static readonly CheckBox Ghost;

                public static bool UseGhost
                {
                    get { return Ghost.CurrentValue; }
                }

                #endregion Ghost


                static SummonerSpells()
                {
                    #region SmiteMenu

                    if (KickassSeries.Activator.SummonerSpells.Extensions.HasSpell("summonersmite"))
                    {
                        // Initialize the menu values
                        SummonerMenu.AddGroupLabel("Smite");
                        UseSmite = SummonerMenu.Add("useSmite", new CheckBox("Use Smite ?"));
                        SummonerMenu.AddLabel("Epic Camps");
                        SummonerMenu.Add("SRU_Baron", new CheckBox("Baron"));
                        SummonerMenu.Add("SRU_Dragon", new CheckBox("Dragon"));
                        SummonerMenu.AddLabel("Normal Camps");
                        SummonerMenu.Add("SRU_Blue", new CheckBox("Blue"));
                        SummonerMenu.Add("SRU_Red", new CheckBox("Red"));
                        SummonerMenu.Add("Sru_Crab", new CheckBox("Skuttles(Crab)"));
                        SummonerMenu.AddLabel("Small Camps");
                        SummonerMenu.Add("SRU_Gromp", new CheckBox("Gromp", false));
                        SummonerMenu.Add("SRU_Murkwolf", new CheckBox("Murkwolf", false));
                        SummonerMenu.Add("SRU_Krug", new CheckBox("Krug", false));
                        SummonerMenu.Add("SRU_Razorbeak", new CheckBox("Razerbeak", false));
                        SummonerMenu.AddSeparator();

                        UseSmiteDuel = SummonerMenu.Add("useSmiteDuel", new CheckBox("Use Red Smite(Duel) ?"));
                        UseSmiteKs = SummonerMenu.Add("useSmiteKS", new CheckBox("Use Blue Smite(KS) ?"));
                        SummonerMenu.AddSeparator();
                    }

                    #endregion SmiteMenu

                    #region HealMenu

                    if (KickassSeries.Activator.SummonerSpells.Extensions.HasSpell("summonerheal"))
                    {
                        SummonerMenu.AddGroupLabel("Heal");
                        Heal = SummonerMenu.Add("healuse", new CheckBox("Use heal when you are in danger ?"));
                        SummonerMenu.AddLabel("You can configure when you are in danger in the settings menu");
                        SummonerMenu.AddSeparator();
                    }

                    #endregion HealMenu

                    #region BarrierMenu

                    if (KickassSeries.Activator.SummonerSpells.Extensions.HasSpell("summonerbarrier"))
                    {
                        SummonerMenu.AddGroupLabel("Barrier");
                        Barrier = SummonerMenu.Add("barrieruse", new CheckBox("Use barrier when you are in danger ?"));
                        SummonerMenu.AddLabel("You can configure when you are in danger in the settings menu");
                        SummonerMenu.AddSeparator();
                    }

                    #endregion BarrierMenu

                    #region GhostMenu

                    if (KickassSeries.Activator.SummonerSpells.Extensions.HasSpell("summonerghost"))
                    {
                        SummonerMenu.AddGroupLabel("Ghost");
                        Ghost = SummonerMenu.Add("Ghostuse", new CheckBox("Use ghost when you are in danger ?"));
                        SummonerMenu.AddLabel("You can configure when you are in danger in the settings menu");
                        SummonerMenu.AddSeparator();
                    }

                    #endregion GhostMenu
                }

                public static void Initialize()
                {
                }
            }

            public static class Settings
            {
                private static readonly CheckBox HPDanger;
                private static readonly Slider HPDangerSlider;
                private static readonly CheckBox RequireEnemy;
                private static readonly Slider EnemySlider;//
                private static readonly Slider EnemyRange;//
                private static readonly CheckBox Spells;
                private static readonly CheckBox Skillshots;
                private static readonly CheckBox Targeted;
                private static readonly CheckBox Attacks;
                private static readonly CheckBox Minions;
                private static readonly CheckBox DisableExecuteCheck;

                public static bool DangerHP
                {
                    get { return HPDanger.CurrentValue; }
                }

                public static int HealthDanger
                {
                    get { return HPDangerSlider.CurrentValue; }
                }

                public static bool RequiresEnemy
                {
                    get { return RequireEnemy.CurrentValue; }
                }

                public static int EnemyCount
                {
                    get { return EnemySlider.CurrentValue; }
                }
                public static int RangeEnemy
                {
                    get { return EnemyRange.CurrentValue; }
                }

                public static bool CountSpells
                {
                    get { return Spells.CurrentValue; }
                }

                public static bool CountSkillshots
                {
                    get { return Skillshots.CurrentValue; }
                }

                public static bool CountTargeted
                {
                    get { return Targeted.CurrentValue; }
                }

                public static bool CountAttacks
                {
                    get { return Attacks.CurrentValue; }
                }

                public static bool CountMinions
                {
                    get { return Minions.CurrentValue; }
                }

                public static bool DisableExeCheck
                {
                    get { return DisableExecuteCheck.CurrentValue; }
                }

                static Settings()
                {

                    SettingsMenu.AddGroupLabel("Danger Settings(Ty to fluxy :D)");
                    SettingsMenu.AddLabel("HP Tracking");

                    HPDanger = SettingsMenu.Add("HPDanger", new CheckBox("HP For Danger"));
                    HPDangerSlider = SettingsMenu.Add("HPDangerSlider", new Slider("HP % For Danger", 15));
                    RequireEnemy = SettingsMenu.Add("EnemiesDanger", new CheckBox("Require Enemies"));
                    EnemySlider = SettingsMenu.Add("EnemiesDangerSlider", new Slider("Enemies Around", 1, 1, 5));
                    EnemyRange = SettingsMenu.Add("EnemiesDangerRange", new Slider("Range", 850, 1, 2000));
                    SettingsMenu.AddGroupLabel("Handler Settings");
                    Spells = SettingsMenu.Add("ConsiderSpells", new CheckBox("Consider Spells"));
                    Skillshots = SettingsMenu.Add("ConsiderSkillshots", new CheckBox("Consider Skillshots"));
                    Targeted = SettingsMenu.Add("ConsiderTargeted", new CheckBox("Consider Targeted"));
                    Attacks = SettingsMenu.Add("ConsiderAttacks", new CheckBox("Consider Basic Attacks"));
                    Minions = SettingsMenu.Add("ConsiderMinions", new CheckBox("Consider Non-Champions", false));
                    SettingsMenu.AddLabel("Dont uncheck the setting below if you dont know what it is.");
                    DisableExecuteCheck = SettingsMenu.Add("DisableExecuteCheck", new CheckBox("Disable Execute Check", false));

                    SettingsMenu.AddGroupLabel("Dangerous Spells");
                    foreach (
                        var dangerousSpell in
                            DangerousSpells.Spells.Where(
                                a => EntityManager.Heroes.Enemies.Any(b => b.Hero == a.Champion)))
                    {
                        SettingsMenu.Add(dangerousSpell.Champion.ToString() + dangerousSpell.Slot,
                            new CheckBox(dangerousSpell.Champion + ": " + dangerousSpell.Slot +
                                         (dangerousSpell.IsCleanseable ? " (Cleanseable)" : "")));
                    }

                    SettingsMenu.AddLabel("Ty to fluxy :D");
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}


