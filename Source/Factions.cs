using Verse;
using RimWorld;
using AlienRace;

namespace BetaHumanoids
{
    public static class Factions
    {
        public static void AddAliensToNPCFactions()
        {
            UpdateNPCFactions(ref SettingsController.Settings.Bear);
            UpdateNPCFactions(ref SettingsController.Settings.Camel);
            UpdateNPCFactions(ref SettingsController.Settings.Croc);
            UpdateNPCFactions(ref SettingsController.Settings.Elephant);
            UpdateNPCFactions(ref SettingsController.Settings.Elk);
            UpdateNPCFactions(ref SettingsController.Settings.Fox);
            UpdateNPCFactions(ref SettingsController.Settings.Gazelle);
            UpdateNPCFactions(ref SettingsController.Settings.Hog);
            UpdateNPCFactions(ref SettingsController.Settings.Lynx);
            UpdateNPCFactions(ref SettingsController.Settings.Raccoon);
            UpdateNPCFactions(ref SettingsController.Settings.Wolf);
        }
        private static void UpdateNPCFactions(ref SpeciesControl speciesControl)
        {
            if (speciesControl.Pirate)
            {
                UpdateNPCFaction("Pirate", speciesControl.DefNames, speciesControl.Label);
            }
            if (speciesControl.Outlander)
            {
                UpdateNPCFaction("OutlanderCivil", speciesControl.DefNames, speciesControl.Label);
                UpdateNPCFaction("OutlanderRough", speciesControl.DefNames, speciesControl.Label);
            }
            if (speciesControl.Tribal)
            {
                UpdateNPCFaction("TribeCivil", speciesControl.DefNames, speciesControl.Label);
                UpdateNPCFaction("TribeRough", speciesControl.DefNames, speciesControl.Label);
                UpdateNPCFaction("TribeSavage", speciesControl.DefNames, speciesControl.Label);
            }
        }
        private static void UpdateNPCFaction(string factionName, string[] raceDefs, string label)
        {
            FactionDef f = DefDatabase<FactionDef>.GetNamedSilentFail(factionName);
            if (f == null) { return; };
            PawnGroupMaker[] g = f.pawnGroupMakers.ToArray();
            for (int x = 0; x < g.Length; x++)
            {
                f.pawnGroupMakers[x] = AddPawnKindsToFactions(g[x], raceDefs, label);
            }
        }
        private static PawnGroupMaker AddPawnKindsToFactions(PawnGroupMaker pgm, string[] raceDefs, string label)
        {
            // groups can be either an options or a guards for whatever reason, so check for both.
            PawnGenOption[] options = pgm.options.ToArray();
            for (int i = 0; i < options.Length; i++)
            {
                foreach (string defName in raceDefs)
                {
                    PawnGenOption pgo = MakePawnGenOption(options[i], label, defName);
                    if (pgo != null) { pgm.AddPawn(pgo, false); }
                }
            }
            PawnGenOption[] guards = pgm.guards.ToArray();
            for (int j = 0; j < guards.Length; j++)
            {
                foreach (string defName in raceDefs)
                {
                    PawnGenOption pgo = MakePawnGenOption(guards[j], label, defName);
                    if (pgo != null) { pgm.AddPawn(pgo, true); }
                }
            }

            return pgm;
        }
        private static void AddPawn(this PawnGroupMaker pgm, PawnGenOption pgo, bool isTrader = false)
        {
            if (pgo.kind == null) { return; };
            if (isTrader)
            {
                pgm.guards.Add(pgo);
                return;
            }
            pgm.options.Add(pgo);
        }
        private static PawnGenOption MakePawnGenOption(PawnGenOption existing, string label, string defName)
        {
            string existingDefName = existing.kind.defName;
            PawnKindDef pkOld = PawnKindDef.Named(existingDefName);
            if (existingDefName.StartsWith(defName) || pkOld.race != ThingDefOf.Human || pkOld.factionLeader)
            {
                return null;
            }
            string newDefName = defName + "_" + pkOld.defName;
            // if the pawnkind does not exist then skip it
            if (DefDatabase<PawnKindDef>.GetNamedSilentFail(newDefName) == null)
            {
                return null;
            }
            return new PawnGenOption
            {
                selectionWeight = existing.selectionWeight,
                kind = PawnKindDef.Named(newDefName)
            };
        }
    }
}
