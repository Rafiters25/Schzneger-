using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace KickassSeries
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            try
            {
                #region Champion`s Swith
                switch (ObjectManager.Player.Hero)
                {
                    //TODO ADD CHAMPIONS HERE
                    case Champion.Aatrox:
                        Champions.Aatrox.Aatrox.Initialize();
                        break;
                    case Champion.Ahri:
                        Champions.Ahri.Ahri.Initialize();
                        break;
                    case Champion.Akali:
                        Champions.Akali.Akali.Initialize();
                        break;
                    case Champion.Alistar:
                        Champions.Alistar.Alistar.Initialize();
                        break;
                    case Champion.Amumu:
                        Champions.Amumu.Amumu.Initialize();
                        break;
                    case Champion.Anivia:
                        Champions.Anivia.Anivia.Initialize();
                        break;
                    case Champion.Annie:
                        Champions.Annie.Annie.Initialize();
                        break;
                    case Champion.Ashe:
                        Champions.Ashe.Ashe.Initialize();
                        break;
                    case Champion.Azir:
                        Champions.Azir.Azir.Initialize();
                        break;
                    case Champion.Bard:
                        Champions.Bard.Bard.Initialize();
                        break;
                    case Champion.Blitzcrank:
                        Champions.Blitzcrank.Blitzcrank.Initialize();
                        break;
                    case Champion.Brand:
                        Champions.Brand.Brand.Initialize();
                        break;
                    case Champion.Braum:
                        Champions.Braum.Braum.Initialize();
                        break;
                    case Champion.Caitlyn:
                        Champions.Caitlyn.Caitlyn.Initialize();
                        break;
                    case Champion.Cassiopeia:
                        Champions.Cassiopeia.Cassiopeia.Initialize();
                        break;
                    case Champion.Chogath:
                        Champions.ChoGath.ChoGath.Initialize();
                        break;
                    case Champion.Corki:
                        Champions.Corki.Corki.Initialize();
                        break;
                    case Champion.Darius:
                        //Champions.Darius.Darius.Initialize();
                        break;
                    case Champion.Diana:
                        Champions.Diana.Diana.Initialize();
                        break;
                    case Champion.DrMundo:
                        Champions.DrMundo.DrMundo.Initialize();
                        break;
                    case Champion.Draven:
                        Champions.Draven.Draven.Initialize();
                        break;
                    case Champion.Ekko:
                        Champions.Ekko.Ekko.Initialize();
                        break;
                    case Champion.Elise:

                        break;
                    case Champion.Evelynn:

                        break;
                    case Champion.Ezreal:
                        Champions.Ezreal.Ezreal.Initialize();
                        break;
                    case Champion.FiddleSticks:

                        break;
                    case Champion.Fiora:

                        break;
                    case Champion.Fizz:

                        break;
                    case Champion.Galio:

                        break;
                    case Champion.Gangplank:

                        break;
                    case Champion.Garen:

                        break;
                    case Champion.Gnar:

                        break;
                    case Champion.Gragas:

                        break;
                    case Champion.Graves:

                        break;
                    case Champion.Hecarim:

                        break;
                    case Champion.Heimerdinger:

                        break;
                    case Champion.Illaoi:
                        Champions.Illaoi.Illaoi.Initialize();
                        break;
                    case Champion.Irelia:
                        Champions.Irelia.Irelia.Initialize();
                        break;
                    case Champion.Janna:

                        break;
                    case Champion.JarvanIV:

                        break;
                    case Champion.Jax:
                        Champions.Jax.Jax.Initialize();
                        break;
                    case Champion.Jayce:

                        break;
                    case Champion.Jinx:
                        Champions.Jinx.Jinx.Initialize();
                        break;
                    case Champion.Kalista:
                        //Champions.Kalista.Kalista.Initialize();
                        break;
                    case Champion.Karma:

                        break;
                    case Champion.Karthus:
                        Champions.Karthus.Karthus.Initialize();
                        break;
                    case Champion.Kassadin:

                        break;
                    case Champion.Katarina:
                        Champions.Katarina.Katarina.Initialize();
                        break;
                    case Champion.Kayle:
                        //Champions.Kayle.Kayle.Initialize();
                        break;
                    case Champion.Kennen:
                        Champions.Kennen.Kennen.Initialize();
                        break;
                    case Champion.Khazix:

                        break;
                    case Champion.Kindred:

                        break;
                    case Champion.KogMaw:
                        Champions.KogMaw.KogMaw.Initialize();
                        break;
                    case Champion.Leblanc:

                        break;
                    case Champion.LeeSin:

                        break;
                    case Champion.Leona:

                        break;
                    case Champion.Lissandra:

                        break;
                    case Champion.Lucian:

                        break;
                    case Champion.Lulu:

                        break;
                    case Champion.Lux:
                        Champions.Lux.Lux.Initialize();
                        break;
                    case Champion.Malphite:

                        break;
                    case Champion.Malzahar:

                        break;
                    case Champion.Maokai:

                        break;
                    case Champion.MasterYi:
                        Champions.MasterYi.MasterYi.Initialize();
                        break;
                    case Champion.MissFortune:

                        break;
                    case Champion.Mordekaiser:

                        break;
                    case Champion.Morgana:

                        break;
                    case Champion.MonkeyKing:
                        Champions.MonkeyKing.MonkeyKing.Initialize();
                        break;
                    case Champion.Nami:

                        break;
                    case Champion.Nasus:

                        break;
                    case Champion.Nautilus:

                        break;
                    case Champion.Nidalee:

                        break;
                    case Champion.Nocturne:

                        break;
                    case Champion.Nunu:
                        Champions.Nunu.Nunu.Initialize();
                        break;
                    case Champion.Olaf:

                        break;
                    case Champion.Orianna:

                        break;
                    case Champion.Pantheon:

                        break;
                    case Champion.Poppy:

                        break;
                    case Champion.Quinn:

                        break;
                    case Champion.Rammus:

                        break;
                    case Champion.RekSai:

                        break;
                    case Champion.Renekton:

                        break;
                    case Champion.Rengar:

                        break;
                    case Champion.Riven:
                        Champions.Riven.Riven.Initialize();
                        break;
                    case Champion.Rumble:

                        break;
                    case Champion.Ryze:
                        Champions.Ryze.Ryze.Initialize();
                        break;
                    case Champion.Sejuani:

                        break;
                    case Champion.Shaco:

                        break;
                    case Champion.Shen:

                        break;
                    case Champion.Shyvana:

                        break;
                    case Champion.Singed:

                        break;
                    case Champion.Sion:

                        break;
                    case Champion.Sivir:

                        break;
                    case Champion.Skarner:

                        break;
                    case Champion.Sona:

                        break;
                    case Champion.Soraka:

                        break;
                    case Champion.Swain:

                        break;
                    case Champion.Syndra:

                        break;
                    case Champion.TahmKench:

                        break;
                    case Champion.Talon:
                        Champions.Talon.Talon.Initialize();
                        break;
                    case Champion.Taric:

                        break;
                    case Champion.Teemo:

                        break;
                    case Champion.Thresh:
                        Champions.Thresh.Thresh.Initialize();
                        break;
                    case Champion.Tristana:
                        Champions.Tristana.Tristana.Initialize();
                        break;
                    case Champion.Trundle:

                        break;
                    case Champion.Tryndamere:
                        Champions.Tryndamere.Tryndamere.Initialize();
                        break;
                    case Champion.TwistedFate:

                        break;
                    case Champion.Twitch:

Champions.Twitch.Twitch.Initialize();
                        break;
                    case Champion.Udyr:

                        break;
                    case Champion.Urgot:

                        break;
                    case Champion.Varus:

                        break;
                    case Champion.Vayne:

                        break;
                    case Champion.Veigar:
                        Champions.Veigar.Veigar.Initialize();
                        break;
                    case Champion.Velkoz:

                        break;
                    case Champion.Vi:

                        break;
                    case Champion.Viktor:
                        Champions.Viktor.Viktor.Initialize();
                        break;
                    case Champion.Vladimir:
                        Champions.Vladimir.Vladimir.Initialize();
                        break;
                    case Champion.Volibear:
                        Champions.Volibear.Volibear.Initialize();
                        break;
                    case Champion.Warwick:
                        Champions.Warwick.Warwick.Initialize();
                        break;
                    case Champion.Xerath:
                        Champions.Xerath.Xerath.Initialize();
                        break;
                    case Champion.XinZhao:
                        Champions.XinZhao.XinZhao.Initialize();
                        break;
                    case Champion.Yasuo:
                        Champions.Yasuo.Yasuo.Initialize();
                        break;
                    case Champion.Yorick:
                        Champions.Yorick.Yorick.Initialize();
                        break;
                    case Champion.Zac:
                        Champions.Zac.Zac.Initialize();
                        break;
                    case Champion.Zed:
                        Champions.Zed.Zed.Initialize();
                        break;
                    case Champion.Ziggs:
                        Champions.Ziggs.Ziggs.Initialize();
                        break;
                    case Champion.Zilean:
                        Champions.Zilean.Zilean.Initialize();
                        break;
                    case Champion.Zyra:
                        Champions.Zyra.Zyra.Initialize();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                #endregion Champion`s Swith

                Console.WriteLine(" ");

                #region LoadingChampion
                try
                {
                    Console.WriteLine(Player.Instance.ChampionName + " Loaded Kickass Series");
                }
                catch (Exception exp)
                {
                    Console.Write(exp);
                }
                #endregion LoadingChampion

                Console.WriteLine(" ");

                #region LoadingActivator
                try
                {
                    Activator.Activator.Init();
                    Console.WriteLine("Kickass Activator Loaded");
                }
                catch (Exception exp)
                {
                    Console.Write(exp);
                }
                #endregion LoadingActivator

                Console.WriteLine(" ");

                #region LoadingEvade
                try
                {
                    //Evade.Initialize.Init();
                    Console.WriteLine("Evade Loaded");
                }
                catch (Exception exp)
                {
                    Console.Write(exp);
                }
                #endregion LoadingEvade

                Console.WriteLine(" ");

                #region LoadingSkinHack
                try
                {
                    Ultilities.SkinHack.Initialize();
                    Console.WriteLine("SkinHack Loaded");
                }
                catch (Exception exp)
                {
                    Console.Write(exp);
                }
                #endregion LoadingSkinHack

                Console.WriteLine(" ");

                #region LoadingDrawings
                try
                {
                    Console.WriteLine("Drawings Loaded");
                }
                catch (Exception exp)
                {
                    Console.Write(exp);
                }
                #endregion LoadingDrawings
            }
            catch (Exception exp)
            {
                Console.Write(exp);
            }
        }
    }
}
