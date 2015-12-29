using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Color = System.Drawing.Color;

namespace KickassSeries.Ultilities.Drawings
{
    public static class AntiJuke
    {
        private static List<Tuple<float, Vector3>> Times = new List<Tuple<float, Vector3>>();

        public static void Init()
        {
            Drawing.OnDraw += Drawing_OnDraw;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            if (Player.Instance.IsDead) return;

            var auxtimes = new List<Tuple<float, Vector3>>();
            foreach (var time in Times)
            {
                var diffTime = time.Item1 - Game.Time;
                if (diffTime > 0)
                {
                    new Circle() { Color = Color.GreenYellow, Radius = 250f, BorderWidth = 8f }.Draw(time.Item2);
                }
                else
                {
                    auxtimes.Add(time);
                }
            }

            if (auxtimes.Count > 0)
            {
                Times = Times.Except(auxtimes).ToList();
            }
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if (hero.IsValid()) return;

            if (args.SData.Name != "EzrealArcaneShift" && args.SData.Name != "summonerflash") return;

            var timer = new Tuple<float, Vector3>(Game.Time + 1, args.End);
            Times.Add(timer);
        }
    }
}
