using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Schnezeger
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        public static Menu Teemo;

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Teemo = MainMenu.AddMenu("Teemo", "1");
            Teemo.AddLabel("koas");
            Teemo.AddGroupLabel("koas");
            if (Player.Instance.ChampionName =="Teemo")
            {
                Chat.Print("Eu teeamo");
            }
            Teemo.Add("2", new Slider("Tanto de chorar o cu",300,10,500));
            Teemo.Add("3", new CheckBox("Tanto de enfiar o dedo no cu",false));
        }
    }
}
