using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;
using Font = SharpDX.Direct3D9.Font;
using Settings = KickassSeries.Champions.Caitlyn.Config.Modes.Draw;
using Misc = KickassSeries.Champions.Caitlyn.Config.Modes.Misc;

namespace KickassSeries.Champions.Caitlyn
{
    internal static class Caitlyn
    {
        private static Font _font;

        public static void Initialize()
        {
            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();
            DamageIndicator.Initialize(SpellDamage.GetTotalDamage);
            EventsManager.Initialize();

            Drawing.OnDraw += OnDraw;

            _font = new Font(
                Drawing.Direct3DDevice,
                new FontDescription
                {
                    FaceName = "Segoi UI",
                    Height = 22,
                    OutputPrecision = FontPrecision.Default,
                    Quality = FontQuality.Default
                });
        }

        private static void OnDraw(EventArgs args)
        {
            if (Settings.DrawReady ? SpellManager.Q.IsReady() : Settings.DrawQ)
            {
                new Circle { Color = Settings.colorQ, BorderWidth = Settings._widthQ, Radius = SpellManager.Q.Range }.Draw(Player.Instance.Position);
            }

            if (Settings.DrawReady ? SpellManager.W.IsReady() : Settings.DrawW)
            {
                new Circle { Color = Settings.colorW, BorderWidth = Settings._widthW, Radius = SpellManager.W.Range }.Draw(Player.Instance.Position);
            }

            if (Settings.DrawReady ? SpellManager.E.IsReady() : Settings.DrawE)
            {
                new Circle { Color = Settings.colorE, BorderWidth = Settings._widthE, Radius = SpellManager.E.Range }.Draw(Player.Instance.Position);
            }

            if (Settings.DrawReady ? SpellManager.R.IsReady() : Settings.DrawR)
            {
                new Circle { Color = Settings.colorR, BorderWidth = Settings._widthR, Radius = SpellManager.R.Range }.Draw(Player.Instance.Position);
            }

            if (Settings.DrawKillable)
            {
                var target = TargetSelector.GetTarget(SpellManager.R.Range, DamageType.Physical);
                if (target != null)
                {
                    if (target.Health < SpellDamage.GetRealDamage(SpellSlot.R, target) && SpellManager.R.IsReady() &&
                        target.IsValidTarget(SpellManager.R.Range))
                    {
                        var playerPos = Drawing.WorldToScreen(Player.Instance.Position);
                        _font.DrawText(null, "Target is Killable with R, if you want to Kill him press " + Misc.WhatKey, (int)playerPos[0] - 220, (int)playerPos[1] + 38, Color.Red);
                    }
                }
            }
        }
    }
}
