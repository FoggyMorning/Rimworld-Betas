using Verse;
using RimWorld;
using System.Collections.Generic;
using System.Linq;

namespace BetaHumanoids
{
    public static class Factions
    {
        public static void AddAliensToNPCFactions()
        {
            List<SpeciesControl> x = new List<SpeciesControl> {
                SettingsController.Settings.Bear,
                SettingsController.Settings.Camel,
                SettingsController.Settings.Croc,
                SettingsController.Settings.Elephant,
                SettingsController.Settings.Elk,
                SettingsController.Settings.Fox,
                SettingsController.Settings.Gazelle,
                SettingsController.Settings.Hog,
                SettingsController.Settings.Lynx,
                SettingsController.Settings.Raccoon,
                SettingsController.Settings.Wolf,
                };
            UpdateNPCFactions(x);
        }
        private static void UpdateNPCFactions(List<SpeciesControl> speciesControl)
        {
            if (speciesControl.Any(s => s.Pirate == false))
            {
                List<string> defNames = new List<string> { };
                foreach (SpeciesControl s in speciesControl)
                {
                    if (!s.Pirate)
                    {
                        foreach (string defname in s.DefNames)
                        {
                            defNames.Add(defname);
                        }
                    }
                };
                UpdateNPCFaction("Pirate", defNames);
            }
            if (speciesControl.Any(s => s.Outlander == false))
            {
                List<string> defNames = new List<string> { };
                foreach (SpeciesControl s in speciesControl)
                {
                    if (!s.Outlander)
                    {
                        foreach (string defname in s.DefNames)
                        {
                            defNames.Add(defname);
                        }
                    }
                };
                UpdateNPCFaction("OutlanderCivil", defNames);
                UpdateNPCFaction("OutlanderRough", defNames);
            }
            if (speciesControl.Any(s => s.Tribal == false))
            {
                List<string> defNames = new List<string> { };
                foreach (SpeciesControl s in speciesControl)
                {
                    if (!s.Tribal)
                    {
                        foreach (string defname in s.DefNames)
                        {
                            defNames.Add(defname);
                        }
                    }
                };
                UpdateNPCFaction("TribeCivil", defNames);
                UpdateNPCFaction("TribeRough", defNames);
                UpdateNPCFaction("TribeSavage", defNames);
            }

            DefDatabase<FactionDef>.AddAllInMods();
        }
        private static void UpdateNPCFaction(string factionName, List<string> labels)
        {
            FactionDef f = DefDatabase<FactionDef>.GetNamedSilentFail(factionName);
            if (f == null) { return; };
            Log.Message($"Removing {f.label} faction pawnkinds for races: {string.Join(", ", labels)}");
            PawnGroupMaker[] g = f.pawnGroupMakers.ToArray();
            for (int x = 0; x < g.Length; x++)
            {
                // groups can be either an options or a guards for whatever reason, so check for both.
                // they default to an empty array so if there are no entries for one of them it will skip
                PawnGenOption[] options = g[x].options.ToArray();
                for (int i = 0; i < options.Length; i++)
                {
                    if (labels.Any(l => options[i].kind.defName.StartsWith(l)))
                    {

                        g[x].options.Remove(options[i]);
                    }
                }
                PawnGenOption[] guards = g[x].guards.ToArray();
                for (int j = 0; j < guards.Length; j++)
                {
                    if (labels.Any(l => guards[j].kind.defName.StartsWith(l)))
                    {
                        g[x].guards.Remove(guards[j]);
                    }
                }
                f.pawnGroupMakers[x] = g[x];
            }
        }
    }
}
