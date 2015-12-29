using System;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Color = System.Drawing.Color;

namespace KickassSeries.Ultilities.Drawings
{
    internal class SpellTracker
    {
        private static int X;  // HPBar Screen X Position
        private static int Y;  // HPBar Screen Y Position
        private static int SummonerSpellX; // Coor of X Summoner Spell
        private static int SummonerSpellY; // Coor of Y Summoner Spell

        //static Font DisplayTextFont = new Font(Drawing.Direct3DDevice, new System.Drawing.Font("Tahoma", 10)); // Text Font
        private static string GetSummonerSpellName;

        private static readonly SpellSlot[] SummonerSpellSlots = { SpellSlot.Summoner1, SpellSlot.Summoner2 };
        private static readonly SpellSlot[] SpellSlots = { SpellSlot.Q, SpellSlot.W, SpellSlot.E, SpellSlot.R };

        private static Text Text { get; set; }

        public static void Init()
        {
            Text = new Text("", new Font(FontFamily.GenericSansSerif, 9, FontStyle.Regular)) { Color = Color.White };

            Drawing.OnDraw += Cooldown_OnDraw;
        }

        public static void Cooldown_OnDraw(EventArgs args)
        {

            // some menu verification here
            foreach (
                var heroes in ObjectManager.Get<AIHeroClient>()
                .Where(h => h.IsValid && !h.IsMe && h.IsHPBarRendered))
            {

                for (var spell = 0; spell < SpellSlots.Count(); spell++)
                {
                    var getSpell = heroes.Spellbook.GetSpell(SpellSlots[spell]);
                    X = (int)heroes.HPBarPosition.X + 5 + (spell * 25);
                    Y = (int)heroes.HPBarPosition.Y + 25;
                    var getSpellCd = getSpell.CooldownExpires - Game.Time;
                    var spellString = string.Format(getSpellCd < 1f ? "{0:0.0}" : "{0:0}", getSpellCd);

                    Text.Draw(getSpellCd > 0 ? spellString : SpellSlots[spell].ToString(), getSpell.Level < 1 ? Color.Gray : getSpellCd > 0 && getSpellCd <= 4 ? Color.Red : getSpellCd > 0 ? Color.Yellow : Color.White, new Vector2(X, Y));
                }

                for (var summoner = 0; summoner < SummonerSpellSlots.Count(); summoner++)
                {
                    SummonerSpellX = (int)heroes.HPBarPosition.X - 15;
                    SummonerSpellY = (int)heroes.HPBarPosition.Y + 1 + (summoner * 20);

                    var getSummoner = heroes.Spellbook.GetSpell(SummonerSpellSlots[summoner]);
                    var getSummonerCd = getSummoner.CooldownExpires - Game.Time;
                    var summonerString = string.Format(getSummonerCd < 1f ? "{0:0.0}" : "{0:0}", getSummonerCd);

                    switch (getSummoner.Name.ToLower())
                    {
                        case "summonerflash":
                            GetSummonerSpellName = "F";
                            break;
                        case "summonerdot":
                            GetSummonerSpellName = "I";
                            break;

                        case "summonerheal":
                            GetSummonerSpellName = "H";
                            break;

                        case "summonerteleport":
                            GetSummonerSpellName = "T";
                            break;

                        case "summonerexhaust":
                            GetSummonerSpellName = "E";
                            break;

                        case "summonerhaste":
                            GetSummonerSpellName = "G";
                            break;

                        case "summonerbarrier":
                            GetSummonerSpellName = "B";
                            break;

                        case "summonerboost":
                            GetSummonerSpellName = "C";
                            break;

                        case "summonermana":
                            GetSummonerSpellName = "C";
                            break;

                        case "summonerclairvoyance":
                            GetSummonerSpellName = "C";
                            break;

                        case "summonerodingarrison":
                            GetSummonerSpellName = "G";
                            break;

                        case "summonersnowball":
                            GetSummonerSpellName = "M";
                            break;//keke

                        default:
                            GetSummonerSpellName = "S";
                            break;
                    }
                    Text.Draw(getSummonerCd > 0 ? summonerString : GetSummonerSpellName, getSummonerCd > 0 ?
                        Color.Red : Color.White, new Vector2(SummonerSpellX, SummonerSpellY));
                }

            }
        }
    }
}
