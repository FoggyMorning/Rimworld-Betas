
using System;
using System.Reflection;
using Harmony;
using Verse;

namespace BetaHumanoids
{
    [StaticConstructorOnStartup]
    internal static class Main
    {
        static Main()
        {
            HarmonyInstance harmony = HarmonyInstance.Create("com.rimworld.mod.FoggyMorning.BetaHumanoids");
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
