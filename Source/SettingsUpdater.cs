using Verse;
using AlienRace;
using System.Collections.Generic;

namespace BetaHumanoids
{
    public static class RaceSettingsUpdater
    {
        public static void AdjustSpawnChance()
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
            UpdateRaceSettings(x);
        }

        private static void UpdateRaceSettings(List<SpeciesControl> speciesControl)
        {
            RaceSettings rs = DefDatabase<RaceSettings>.AllDefsListForReading.Find(x => x.defName == "BetaRaceSettings");
            if (rs == null) { return;  }
            if (speciesControl.Any(s => s.Colonist == false))
            {
                List<string> defNames = new List<string> { };
                foreach (SpeciesControl s in speciesControl)
                {
                    if (!s.Colonist)
                    {
                        foreach (string defname in s.DefNames)
                        {
                            defNames.Add(defname);
                        }
                    }
                }; 
                foreach (FactionPawnKindEntry sc in rs.pawnKindSettings.startingColonists)
                {
                    foreach (PawnKindEntry pke in sc.pawnKindEntries)
                    {
                        
                        if (pke.kindDefs.Exists(k => defNames.Any(d => k.race.defName == d)))
                        {
                            pke.chance = 0f;
                        };
                    };
                };
            }
            if (speciesControl.Any(s => s.Wanderer == false))
            {
                List<string> defNames = new List<string> { };
                foreach (SpeciesControl s in speciesControl)
                {
                    if (!s.Wanderer)
                    {
                        foreach (string defname in s.DefNames)
                        {
                            defNames.Add(defname);
                        }
                    }
                };
                foreach (FactionPawnKindEntry sc in rs.pawnKindSettings.alienwandererkinds)
                {
                    foreach (PawnKindEntry pke in sc.pawnKindEntries)
                    {

                        if (pke.kindDefs.Exists(k => defNames.Any(d => k.race.defName == d)))
                        {
                            pke.chance = 0f;
                        };
                    };
                };
            }
            if (speciesControl.Any(s => s.Refugee == false))
            {
                List<string> defNames = new List<string> { };
                foreach (SpeciesControl s in speciesControl)
                {
                    if (!s.Refugee)
                    {
                        foreach (string defname in s.DefNames)
                        {
                            defNames.Add(defname);
                        }
                    }
                };
                foreach (PawnKindEntry pke in rs.pawnKindSettings.alienrefugeekinds)
                {
                    if (pke.kindDefs.Exists(k => defNames.Any(d => k.race.defName == d)))
                    {
                        pke.chance = 0f;
                    };
                };
            }
            if (speciesControl.Any(s => s.Slave == false))
            {
                List<string> defNames = new List<string> { };
                foreach (SpeciesControl s in speciesControl)
                {
                    if (!s.Slave)
                    {
                        foreach (string defname in s.DefNames)
                        {
                            defNames.Add(defname);
                        }
                    }
                };
                foreach (PawnKindEntry pke in rs.pawnKindSettings.alienslavekinds)
                {
                    if (pke.kindDefs.Exists(k => defNames.Any(d => k.race.defName == d)))
                    {
                        pke.chance = 0f;
                    };
                };
            }
        }
    }
}
