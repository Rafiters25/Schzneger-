using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable

namespace KickassSeries.Ultilities
{
    internal static class SkinHack
    {
        private static readonly Dictionary<string, int> Skins = new Dictionary<string, int>();

        private const string MenuName = "KA SkinHack";

        private static int lastCheck;

        private static readonly Menu Menu;

        static SkinHack()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("KA SkinHack");
            Menu.AddLabel("It`s very unstable becareful changing the skins");
            TurnOff = Menu.Add("turnoff", new CheckBox("Turn Off Skin hack ?", false));
            Menu.AddLabel("Made By: MarioGK", 50);

            // Initialize the modes
            Types.Initialize();
        }

        private static readonly CheckBox TurnOff;

        private static bool TurnOffSkinHack
        {
            get { return TurnOff.CurrentValue; }
        }

        public static void Initialize()
        {
        }

        private static class Types
        {
            private static readonly Menu AlliesMenu, EnemiesMenu;
            private static Slider skinSliderAlly, skinSliderEnemy;

            static Types()
            {
                AlliesMenu = Menu.AddSubMenu("My Team");
                AlliesSkins.Initialize();

                EnemiesMenu = Menu.AddSubMenu("Enemy Team");
                EnemiesSkin.Initialize();
            }

            public static void Initialize()
            {
                Game.OnTick += delegate
                {
                    if (lastCheck + 5000 > Environment.TickCount || TurnOffSkinHack) return;
                    CheckSkin();
                    lastCheck = Environment.TickCount;
                };
            }

            private static void CheckSkin()
            {
                if (TurnOffSkinHack) return;
                var enemies = EntityManager.Heroes.Enemies.Where(e => e.SkinId != EnemiesMenu["kaenemy" + e.ChampionName].Cast<Slider>().CurrentValue);

                if (enemies != null)
                {
                    foreach (var enemy in enemies)
                    {
                        Skins[enemy.Name] = EnemiesMenu["kaenemy" + enemy.ChampionName].Cast<Slider>().CurrentValue;
                        enemy.SetSkin(enemy.ChampionName, Skins[enemy.Name]);
                    }
                }

                var allies = EntityManager.Heroes.Allies.Where(a => a.SkinId != AlliesMenu["kaally" + a.ChampionName].Cast<Slider>().CurrentValue);
                if (allies != null)
                {
                    foreach (var ally in allies)
                    {
                        Skins[ally.Name] = AlliesMenu["kaally" + ally.ChampionName].Cast<Slider>().CurrentValue;
                        ally.SetSkin(ally.ChampionName, Skins[ally.Name]);
                    }
                }
            }

            private static class AlliesSkins
            {
                static AlliesSkins()
                {
                    foreach (var ally in EntityManager.Heroes.Allies)
                    {
                        skinSliderAlly = AlliesMenu.Add("kaally" + ally.ChampionName,
                            new Slider("Select a skin for " + ally.ChampionName, 0, 0, 15));
                        AlliesMenu.AddSeparator();

                        if (TurnOffSkinHack) return;
                        skinSliderAlly.OnValueChange += delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                        {
                            Skins[ally.Name] = args.NewValue;
                            ally.SetSkin(ally.ChampionName, Skins[ally.Name]);
                        };
                    }
                }

                public static void Initialize()
                {
                }
            }

            private static class EnemiesSkin
            {
                static EnemiesSkin()
                {
                    foreach (var enemy in EntityManager.Heroes.Enemies)
                    {
                        skinSliderEnemy = EnemiesMenu.Add("kaenemy" + enemy.ChampionName,
                            new Slider("Select a skin for " + enemy.ChampionName, 0, 0, 15));
                        EnemiesMenu.AddSeparator();

                        if (TurnOffSkinHack) return;
                        skinSliderEnemy.OnValueChange += delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                        {
                            Skins[enemy.Name] = args.NewValue;
                            enemy.SetSkin(enemy.ChampionName, Skins[enemy.Name]);
                        };

                    }
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}