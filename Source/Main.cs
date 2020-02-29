
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
            LongEventHandler.QueueLongEvent(new Action(Init), "LibraryStartup", false, null);
        }
        private static void Init()
        {
            string[] labels = SettingsController.Settings.labels;
            float[] chances = SettingsController.Settings.SpawnChance;
            Factions.AdjustAlienRaceSettingsSpawnChance(labels, chances);
            Factions.AddAliensToNPCFactions(labels, chances);
        }
    }
}
