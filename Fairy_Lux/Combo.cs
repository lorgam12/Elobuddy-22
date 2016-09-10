﻿using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Fairy_Lux.Menus;

namespace Fairy_Lux
{
    internal static class Combo
    {
        public static void Execute()
        {
            var etarget = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Magical);

            if ((etarget == null) || etarget.IsInvulnerable)
                return;
            //Cast E
            if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
                if (etarget.IsValidTarget(SpellsManager.E.Range + 300) && SpellsManager.E.IsReady())
                    SpellsManager.E.TryToCast(etarget, ComboMenu);

            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (qtarget.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                    SpellsManager.Q.TryToCast(qtarget, ComboMenu);


            var rtarget = TargetSelector.GetTarget(SpellsManager.R.Range, DamageType.Magical);

            if ((rtarget == null) || rtarget.IsInvulnerable)
                return;

            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsOnCooldown &&
                SpellsManager.E.IsOnCooldown)
                if (ComboMenu["R"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && rtarget.IsValidTarget(SpellsManager.R.Range) &&
                        Prediction.Health.GetPrediction(rtarget, SpellsManager.R.CastDelay) <=
                        SpellsManager.GetRealDamage(rtarget, SpellSlot.R))
                    {
                        SpellsManager.R.Cast(rtarget);
                    }





        }

        public static void Execute8()
        {
            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (ComboMenu["Q2"].Cast<CheckBox>().CurrentValue)
                if (qtarget.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                    SpellsManager.Q.TryToCast(qtarget, ComboMenu);


            var etarget = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Magical);

            if ((etarget == null) || etarget.IsInvulnerable)
                return;
            //Cast E
            if (ComboMenu["E2"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsOnCooldown)
                if (etarget.IsValidTarget(SpellsManager.E.Range+300) && SpellsManager.E.IsReady())
                    SpellsManager.E.TryToCast(etarget, ComboMenu);


            var rtarget = TargetSelector.GetTarget(SpellsManager.R.Range, DamageType.Magical);

            if ((rtarget == null) || rtarget.IsInvulnerable)
                return;

            if (ComboMenu["R2"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsOnCooldown &&
                SpellsManager.E.IsOnCooldown)
                if (SpellsManager.R.IsReady() && rtarget.IsValidTarget(SpellsManager.R.Range) &&
                    Prediction.Health.GetPrediction(rtarget, SpellsManager.R.CastDelay) <=
                    SpellsManager.GetRealDamage(rtarget, SpellSlot.R))
                {
                    SpellsManager.R.Cast(rtarget);
                }
        }
    }
}



