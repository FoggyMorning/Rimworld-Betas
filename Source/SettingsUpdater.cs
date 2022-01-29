using Verse;
using AlienRace;

namespace BetaHumanoids
{
    public static class RaceSettingsUpdater
    {
        public static void AdjustSpawnChance()
        {
            UpdateRaceSettings(ref SettingsController.Settings.Bear);
            UpdateRaceSettings(ref SettingsController.Settings.Camel);
            UpdateRaceSettings(ref SettingsController.Settings.Croc);
            UpdateRaceSettings(ref SettingsController.Settings.Elephant);
            UpdateRaceSettings(ref SettingsController.Settings.Elk);
            UpdateRaceSettings(ref SettingsController.Settings.Fox);
            UpdateRaceSettings(ref SettingsController.Settings.Gazelle);
            UpdateRaceSettings(ref SettingsController.Settings.Hog);
            UpdateRaceSettings(ref SettingsController.Settings.Lynx);
            UpdateRaceSettings(ref SettingsController.Settings.Raccoon);
            UpdateRaceSettings(ref SettingsController.Settings.Wolf);
        }

        private static void UpdateRaceSettings(ref SpeciesControl speciesControl)
        {
            foreach(string label in speciesControl.DefNames)
            { 
                foreach (RaceSettings rs in DefDatabase<RaceSettings>.AllDefsListForReading)
                {
                    if (rs.defName == "BetaRaceSettings")
                    {
                        foreach (FactionPawnKindEntry sc in rs.pawnKindSettings.startingColonists)
                        {
                            foreach (PawnKindEntry pke in sc.pawnKindEntries)
                            {
                                if (pke.kindDefs.Exists(k => k.race.Equals(label)))
                                {
                                    pke.chance = speciesControl.Colonist ? label.Contains("_Male") || label.Contains("_Female") ? SettingsController.Settings.spawnChance/10 :  SettingsController.Settings.spawnChance : 0f;
                                };
                            };
                        };
                        foreach (FactionPawnKindEntry awk in rs.pawnKindSettings.alienwandererkinds)
                        {
                            foreach (PawnKindEntry pke in awk.pawnKindEntries)
                            {
                                if (pke.kindDefs.Exists(k => k.race.Equals(label)))
                                {
                                    pke.chance = speciesControl.Wanderer ? label.Contains("_Male") || label.Contains("_Female") ? SettingsController.Settings.spawnChance / 10 : SettingsController.Settings.spawnChance : 0f;
                                };
                            };
                        };
                        foreach (PawnKindEntry pke in rs.pawnKindSettings.alienrefugeekinds)
                        {
                            if (pke.kindDefs.Exists(k => k.race.Equals(label)))
                            {
                                pke.chance = speciesControl.Refugee ? label.Contains("_Male") || label.Contains("_Female") ? SettingsController.Settings.spawnChance / 10 : SettingsController.Settings.spawnChance : 0f;
                            };
                        };
                        foreach (PawnKindEntry pke in rs.pawnKindSettings.alienslavekinds)
                        {
                            if (pke.kindDefs.Exists(k => k.race.Equals(label)))
                            {
                                pke.chance = speciesControl.Slave ? label.Contains("_Male") || label.Contains("_Female") ? SettingsController.Settings.spawnChance / 10 : SettingsController.Settings.spawnChance : 0f;
                            };
                        };
                    }
                }
            }
        }
    }
}
