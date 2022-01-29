
using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace BetaHumanoids
{
    [StaticConstructorOnStartup]
    internal static class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.rimworld.mod.FoggyMorning.BetaHumanoids");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            LongEventHandler.QueueLongEvent(new Action(InitLib), "LibraryStartup", false, null);
        }
        private static void InitLib()
        {
            SettingsController.Settings.ExposeData();
            RaceSettingsUpdater.AdjustSpawnChance();
            Factions.AddAliensToNPCFactions();
        }
    }
}
