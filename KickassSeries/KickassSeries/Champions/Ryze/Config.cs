using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using KickassSeries.MenuSettings;
using Color = System.Drawing.Color;

// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass

namespace KickassSeries.Champions.Ryze
{
    public static class Config
    {
        private static readonly string MenuName = "KA " + Player.Instance.ChampionName;

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("KA " + Player.Instance.ChampionName);
            Menu.AddLabel("Made By: iRaxe", 50);

            // Initialize the modes
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu
                DrawMenu,
                ComboMenu,
                HarassMenu,
                LaneclearMenu,
                LastHitMenu,
                OtherMenu;

            static Modes()
            {
                DrawMenu = Menu.AddSubMenu("Draw");
                Draw.Initialize();
                ComboMenu = Menu.AddSubMenu("Combo");
                Combo.Initialize();
                HarassMenu = Menu.AddSubMenu("Harass");
                Harass.Initialize();
                LaneclearMenu = Menu.AddSubMenu("Laneclear");
                LaneClear.Initialize();
                LastHitMenu = Menu.AddSubMenu("Lasthit");
                LastHit.Initialize();
                OtherMenu = Menu.AddSubMenu("Misc Functions");
                Other.Initialize();

            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                //Use Q
                private static readonly CheckBox _useQ;
                //Use W
                private static readonly CheckBox _useW;
                //Use E
                private static readonly CheckBox _useE;
                //Use R
                private static readonly CheckBox _useR;
                //Use AutoAttacks
                private static readonly CheckBox _useAA;
                //Use Q on CC
                private static readonly CheckBox _useCC;
                //Use W on CC
                private static readonly CheckBox _useCC1;
                //Use E on CC
                private static readonly CheckBox _useCC2;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static bool UseAA
                {
                    get { return _useAA.CurrentValue; }
                }

                public static bool UseCC
                {
                    get { return _useCC.CurrentValue; }
                }

                public static bool UseCC1
                {
                    get { return _useCC1.CurrentValue; }
                }

                public static bool UseCC2
                {
                    get { return _useCC2.CurrentValue; }
                }

                static Combo()
                {
                    // Initialize the menu values
                    ComboMenu.AddGroupLabel("Combo");
                    _useQ = ComboMenu.Add("comboQ", new CheckBox("Use Overload (Q Spell)"));
                    _useW = ComboMenu.Add("comboW", new CheckBox("Use Rune Prison (W Spell)"));
                    _useE = ComboMenu.Add("comboE", new CheckBox("Use Spell Flux (E Spell)"));
                    _useR = ComboMenu.Add("comboR", new CheckBox("Use Desperate Power (R Spell)"));
                    ComboMenu.AddSeparator();
                    ComboMenu.AddGroupLabel("Combo Preferences");
                    _useAA = ComboMenu.Add("comboAA", new CheckBox("Use AutoAttack", false));
                    _useCC = ComboMenu.Add("comboCC", new CheckBox("Use Overload (Q Spell) on CC"));
                    _useCC1 = ComboMenu.Add("comboCC1", new CheckBox("Use Rune Prison (W Spell) on CC"));
                    _useCC2 = ComboMenu.Add("comboCC2", new CheckBox("Use Spell Flux (E Spell) on CC"));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                //Use Q
                private static readonly CheckBox _useQ;
                //Use W
                private static readonly CheckBox _useW;
                //Use E
                private static readonly CheckBox _useE;
                //Use AA
                private static readonly CheckBox _useA;
                //Use Stack Limiter
                private static readonly CheckBox _useS;
                //Values of Stack Limiter
                private static readonly Slider _useS1;
                //Values of Maximium Mana
                private static readonly Slider _useQWE;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseA
                {
                    get { return _useA.CurrentValue; }
                }

                public static bool UseS
                {
                    get { return _useS.CurrentValue; }
                }

                public static float UseS1
                {
                    get { return _useS1.CurrentValue; }
                }

                public static float UseQWE
                {
                    get { return _useQWE.CurrentValue; }
                }

                static Harass()
                {
                    // Initialize the menu values
                    HarassMenu.AddGroupLabel("Harass");
                    _useQ = HarassMenu.Add("harassQ", new CheckBox("Use Overload (Q Spell)"));
                    _useW = HarassMenu.Add("harassW", new CheckBox("Use Rune Prison (W Spell)"));
                    _useE = HarassMenu.Add("harassE", new CheckBox("Use Spell Flux (E Spell)"));
                    HarassMenu.AddSeparator();
                    HarassMenu.AddGroupLabel("Harass Preferences");
                    _useA = HarassMenu.Add("harassA", new CheckBox("Use Auto Harass"));
                    _useS = HarassMenu.Add("harassS", new CheckBox("Limit passive stacks", false));
                    _useS1 = HarassMenu.Add("harassS1", new Slider("Maximium stacks", 3, 1, 5));
                    _useQWE = HarassMenu.Add("harassQWE", new Slider("Min. Mana for Harass Spells %", 35));
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                //Use Q
                private static readonly CheckBox _useQ;
                //Use W
                private static readonly CheckBox _useW;
                //Use E
                private static readonly CheckBox _useE;
                //Use R
                private static readonly CheckBox _useR;
                //Use AutoHarass
                private static readonly CheckBox _useH;
                //Use Autostack Limiter
                private static readonly CheckBox _useS;
                //Value of Stack Limiter
                private static readonly Slider _useS1;
                //Values of Maximium Mana
                private static readonly Slider _useQWER;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseH
                {
                    get { return _useH.CurrentValue; }
                }

                public static bool UseS
                {
                    get { return _useS.CurrentValue; }
                }

                public static float UseS1
                {
                    get { return _useS1.CurrentValue; }
                }

                public static float UseQWER
                {
                    get { return _useQWER.CurrentValue; }
                }

                static LaneClear()
                {
                    // Initialize the menu values
                    LaneclearMenu.AddGroupLabel("LaneClear");
                    _useQ = LaneclearMenu.Add("laneQ", new CheckBox("Use Overload (Q Spell)"));
                    _useW = LaneclearMenu.Add("laneW", new CheckBox("Use Rune Prison (W Spell)"));
                    _useE = LaneclearMenu.Add("laneE", new CheckBox("Use Spell Flux (E Spell)"));
                    _useR = LaneclearMenu.Add("laneR", new CheckBox("Use Desperate Power (R Spell)", false));
                    LaneclearMenu.AddSeparator();
                    LaneclearMenu.AddGroupLabel("LaneClear Preferences");
                    _useH = LaneclearMenu.Add("laneH", new CheckBox("Prioritize Harass instead of LastHit"));
                    _useS = LaneclearMenu.Add("laneS", new CheckBox("Limit passive stacks", false));
                    _useS1 = LaneclearMenu.Add("laneS1", new Slider("Maximium stacks", 3, 1, 5));
                    _useQWER = LaneclearMenu.Add("laneQWER", new Slider("Min. Mana for Laneclear Spells %", 30));
                }

                public static void Initialize()
                {
                }
            }

            public static class LastHit
            {
                //Use Q
                private static readonly CheckBox _useQ;
                //Use W
                private static readonly CheckBox _useW;
                //Use E
                private static readonly CheckBox _useE;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                static LastHit()
                {
                    // Initialize the menu values
                    LastHitMenu.AddGroupLabel("LastHit");
                    _useQ = LastHitMenu.Add("lastQ", new CheckBox("Use Overload (Q Spell)"));
                    _useW = LastHitMenu.Add("lastW", new CheckBox("Use Rune Prison (W Spell)"));
                    _useE = LastHitMenu.Add("lastE", new CheckBox("Use Spell Flux (E Spell)"));
                }

                public static void Initialize()
                {
                }
            }
            public static class Other
            {
                //Use Q on KS
                private static readonly CheckBox _useQ;
                //Use W on KS
                private static readonly CheckBox _useWKS;
                //Use E on KS
                private static readonly CheckBox _useEKS;
                //Use W on GapCloser
                private static readonly CheckBox _useW;
                //Use R on GapCloser
                private static readonly CheckBox _useR;
                //Values of Mana for Flee
                private static readonly Slider _useM;
                //Use Auto Stack
                private static readonly CheckBox _useS;
                //Use Auto Stack Limiter
                private static readonly CheckBox _useS1;
                //Values of Limiter
                private static readonly Slider _useS2;
                //Values of Maximium Mana
                private static readonly Slider _useS3;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseWKS
                {
                    get { return _useWKS.CurrentValue; }
                }

                public static bool UseEKS
                {
                    get { return _useEKS.CurrentValue; }
                }

                public static float UseM
                {
                    get { return _useM.CurrentValue; }
                }

                public static bool UseS
                {
                    get { return _useS.CurrentValue; }
                }

                public static bool UseS1
                {
                    get { return _useS1.CurrentValue; }
                }

                public static float UseS2
                {
                    get { return _useS2.CurrentValue; }
                }

                public static float UseS3
                {
                    get { return _useS3.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                static Other()
                {
                    // Initialize the menu values
                    LastHitMenu.AddGroupLabel("Misc Functions");
                    _useQ = OtherMenu.Add("miscQKS", new CheckBox("Use Overload (Q Spell) on KS"));
                    _useWKS = OtherMenu.Add("miscWKS", new CheckBox("Use Rune Prison (W Spell) on KS"));
                    _useEKS = OtherMenu.Add("miscEKS", new CheckBox("Use Spell Flux (E Spell) on KS"));
                    _useW = OtherMenu.Add("miscW", new CheckBox("Use Rune Prison (W Spell) on Gap"));
                    _useR = OtherMenu.Add("miscR", new CheckBox("Use Desperate Power (R Spell) on Gap"));
                    _useM = OtherMenu.Add("miscM", new Slider("Use Desperate Power (R Spell) for Flee if mana is higher than {0}(%)", 10, 1));
                    _useS = OtherMenu.Add("miscS", new CheckBox("Auto Stack Passive", false));
                    _useS1 = OtherMenu.Add("miscS1", new CheckBox("Limit passive stacks", false));
                    _useS2 = OtherMenu.Add("miscS2", new Slider("Maximium stacks", 2, 1, 5));
                    _useS3 = OtherMenu.Add("miscS3", new Slider("Use Auto Stack Passive if mana is higher than {0}(%)", 10, 1));

                }

                public static void Initialize()
                {
                }
            }

            public static class Draw
            {
                private static readonly CheckBox _drawHealth;
                private static readonly CheckBox _drawQ;
                private static readonly CheckBox _drawW;
                private static readonly CheckBox _drawE;
                private static readonly CheckBox _drawR;

                private static readonly CheckBox _drawReady;

                public static bool DrawHealth
                {
                    get { return _drawHealth.CurrentValue; }
                }

                public static bool DrawQ
                {
                    get { return _drawQ.CurrentValue; }
                }

                public static bool DrawW
                {
                    get { return _drawW.CurrentValue; }
                }

                public static bool DrawE
                {
                    get { return _drawE.CurrentValue; }
                }

                public static bool DrawR
                {
                    get { return _drawR.CurrentValue; }
                }

                public static bool DrawReady
                {
                    get { return _drawReady.CurrentValue; }
                }


                public static Color colorHealth
                {
                    get { return DrawMenu.GetColor("colorHealth"); }
                }

                public static Color colorQ
                {
                    get { return DrawMenu.GetColor("colorQ"); }
                }

                public static Color colorW
                {
                    get { return DrawMenu.GetColor("colorW"); }
                }

                public static Color colorE
                {
                    get { return DrawMenu.GetColor("colorE"); }
                }

                public static Color colorR
                {
                    get { return DrawMenu.GetColor("colorR"); }
                }

                public static float _widthQ
                {
                    get { return DrawMenu.GetWidth("widthQ"); }
                }

                public static float _widthW
                {
                    get { return DrawMenu.GetWidth("widthW"); }
                }

                public static float _widthE
                {
                    get { return DrawMenu.GetWidth("widthE"); }
                }

                public static float _widthR
                {
                    get { return DrawMenu.GetWidth("widthR"); }
                }

                static Draw()
                {
                    DrawMenu.AddGroupLabel("Draw");
                    _drawReady = DrawMenu.Add("drawReady", new CheckBox("Draw Only If The Spells Are Ready.", false));
                    DrawMenu.AddSeparator();
                    DrawMenu.AddLabel("Reload is required to aply the changes made in the damage indicator");
                    _drawHealth = DrawMenu.Add("drawHealth", new CheckBox("Draw Damage in HealthBar"));
                    DrawMenu.AddColorItem("colorHealth");
                    DrawMenu.AddSeparator();
                    //Q
                    _drawQ = DrawMenu.Add("drawQ", new CheckBox("Draw Overload (Q Spell)"));
                    DrawMenu.AddColorItem("colorQ");
                    DrawMenu.AddWidthItem("widthQ");
                    //W
                    _drawW = DrawMenu.Add("drawW", new CheckBox("Draw Rune Prison (W Spell)"));
                    DrawMenu.AddColorItem("colorW");
                    DrawMenu.AddWidthItem("widthW");
                    //E
                    _drawE = DrawMenu.Add("drawE", new CheckBox("Draw Spell Flux (E Spell)"));
                    DrawMenu.AddColorItem("colorE");
                    DrawMenu.AddWidthItem("widthE");
                    //R
                    _drawR = DrawMenu.Add("drawR", new CheckBox("Draw Desperate Power (R Spell)"));
                    DrawMenu.AddColorItem("colorR");
                    DrawMenu.AddWidthItem("widthR");
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}