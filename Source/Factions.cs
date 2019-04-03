using Verse;
using RimWorld;
using AlienRace;
using System.Linq;

namespace BetaHumanoids
{
    public static class Factions
    {
        // adds labels to the alien race RaceSettings def using the chances values
        public static void AdjustAlienRaceSettingsSpawnChance(string[] labels, float[] chances)
        {
            for (int i = 0; i < labels.Length; i++)
            {
                string label = labels[i];
                foreach (RaceSettings rs in DefDatabase<RaceSettings>.AllDefsListForReading)
                {
                    if (rs.defName == "BetaRaceSettings")
                    {
                        foreach (FactionPawnKindEntry sc in rs.pawnKindSettings.startingColonists)
                        {
                            foreach (PawnKindEntry pke in sc.pawnKindEntries)
                            {
                                if (pke.kindDefs.Any(k => k.Contains(label)))
                                {
                                    pke.chance = chances[i];
                                };
                            };
                        };
                        foreach (FactionPawnKindEntry awk in rs.pawnKindSettings.alienwandererkinds)
                        {
                            foreach (PawnKindEntry pke in awk.pawnKindEntries)
                            {
                                if (pke.kindDefs.Any(k => k.Contains(label)))
                                {
                                    pke.chance = chances[i];
                                };
                            };
                        };
                        foreach (PawnKindEntry pke in rs.pawnKindSettings.alienrefugeekinds)
                        {
                            if (pke.kindDefs.Any(k => k.Contains(label)))
                            {
                                pke.chance = chances[i];
                            };
                        };
                        foreach (PawnKindEntry pke in rs.pawnKindSettings.alienslavekinds)
                        {
                            if (pke.kindDefs.Any(k => k.Contains(label)))
                            {
                                pke.chance = chances[i];
                            };
                        };
                        break;

                    }
                }
            }
        }


        // why make a bunch of defs when you can do some sloppy c# list manipulation
        public static void AddAliensToNPCFactions(string[] labels, float[] chances)
        {

            for (int i = 0; i < labels.Length; i++)
            {
                if (chances[i] <= 0f)
                {
                    continue;
                }

                if (SettingsController.Settings.IncludeInPirate)
                {
                    FactionDef f = DefDatabase<FactionDef>.GetNamed("Pirate", true);
                    PawnGroupMaker[] g = f.pawnGroupMakers.ToArray();
                    for (int x = 0; x < g.Length; x++)
                    {
                        f.pawnGroupMakers[x] = addPawnKindsToFactions(g[x], labels[i], chances[i]);
                    }
                }
                if (SettingsController.Settings.IncludeInOutlander)
                {
                    FactionDef f = DefDatabase<FactionDef>.GetNamed("OutlanderCivil", true);
                    PawnGroupMaker[] g = f.pawnGroupMakers.ToArray();
                    for (int x = 0; x < g.Length; x++)
                    {
                        f.pawnGroupMakers[x] = addPawnKindsToFactions(g[x], labels[i], chances[i]);
                    }
                }
                if (SettingsController.Settings.IncludeInOutlander)
                {
                    FactionDef f = DefDatabase<FactionDef>.GetNamed("OutlanderRough", true);
                    PawnGroupMaker[] g = f.pawnGroupMakers.ToArray();
                    for (int x = 0; x < g.Length; x++)
                    {
                        f.pawnGroupMakers[x] = addPawnKindsToFactions(g[x], labels[i], chances[i]);
                    }
                }
                if (SettingsController.Settings.IncludeInTribal)
                {
                    FactionDef f = DefDatabase<FactionDef>.GetNamed("TribeCivil", true);
                    PawnGroupMaker[] g = f.pawnGroupMakers.ToArray();
                    for (int x = 0; x < g.Length; x++)
                    {
                        f.pawnGroupMakers[x] = addPawnKindsToFactions(g[x], labels[i], chances[i]);
                    }
                }
                if (SettingsController.Settings.IncludeInTribal)
                {
                    FactionDef f = DefDatabase<FactionDef>.GetNamed("TribeRough", true);
                    PawnGroupMaker[] g = f.pawnGroupMakers.ToArray();
                    for (int x = 0; x < g.Length; x++)
                    {
                        f.pawnGroupMakers[x] = addPawnKindsToFactions(g[x], labels[i], chances[i]);
                    }
                }

            }
        }


        private static PawnGroupMaker addPawnKindsToFactions(PawnGroupMaker pgm, string label, float chance)
        {
            if (label == "Elk")
            {
                SettingsController.Settings.ElkMale = true;
                // Elks are separate races based on gender due to the antlers.  // so need to do twice
                // groups can be either an options or a guards for whatever reason, so check for both.
                PawnGenOption[] optionsElkMale = pgm.options.ToArray();
                for (int i = 0; i < optionsElkMale.Length; i++)
                {
                PawnGenOption pgo = makePawnGenOption(optionsElkMale[i], label, chance);
                    if (pgo != null) { pgm.addPawn(pgo, false); }
                }
                PawnGenOption[] guardsElkMale = pgm.guards.ToArray();
                for (int j = 0; j < guardsElkMale.Length; j++)
                {
                    PawnGenOption pgo = makePawnGenOption(guardsElkMale[j], label, chance);
                    if (pgo != null) { pgm.addPawn(pgo, true); }
                }
                SettingsController.Settings.ElkMale = false;
            }
            // groups can be either an options or a guards for whatever reason, so check for both.
            PawnGenOption[] options = pgm.options.ToArray();
            for (int i = 0; i < options.Length; i++)
            {
                PawnGenOption pgo = makePawnGenOption(options[i], label, chance);
                if (pgo != null) { pgm.addPawn(pgo, false); }
            }
            PawnGenOption[] guards = pgm.guards.ToArray();
            for (int j = 0; j < guards.Length; j++)
            {
                PawnGenOption pgo = makePawnGenOption(guards[j], label, chance);
                if (pgo != null) { pgm.addPawn(pgo, true); }
            }
            return pgm;
        }
        private static void addPawn(this PawnGroupMaker pgm, PawnGenOption pgo, bool isTrader = false)
        {
            if (pgo.kind == null) { return; };
            if (isTrader)
            {
                pgm.guards.Add(pgo);
                return;
            }
            pgm.options.Add(pgo);
        }
        private static PawnGenOption makePawnGenOption(PawnGenOption existing, string label, float chance)
        {
            string pawnKindLabel = existing.kind.defName;
            float sw = existing.selectionWeight * chance / 10;

            // if it is one of our defs then don't recreate it
            // if some alien race other than a Human then don't risk copying it
            if (pawnKindLabel.Contains("_BetaHumanoids_") || PawnKindDef.Named(pawnKindLabel).race != ThingDefOf.Human)
            {
                return null;
            }
            string defname = pawnKindLabel + "_BetaHumanoids_Beta" + label;
            if (label == "Elk")
            { 
                // Elks are separate races based on gender due to the antlers.  // so need to do twice
                if (SettingsController.Settings.ElkMale)
                {
                    defname = pawnKindLabel + "_BetaHumanoids_Beta" + label + "_Male";
                } else
                {
                    defname = pawnKindLabel + "_BetaHumanoids_Beta" + label + "_Female";
                }
            }
            //createNewPawnKind(PawnKindDef.Named(pawnKindLabel), label, defname);
            if (DefDatabase<PawnKindDef>.GetNamedSilentFail(defname) == null)
            {
                return null;
            }
            return new PawnGenOption
            {
                selectionWeight = sw,
                kind = PawnKindDef.Named(defname)
            };
        }
        /*
        private static void createNewPawnKind(PawnKindDef pkOld, string label, string defname)
        {
            // if it already exists then don't recreate it
            if (DefDatabase<PawnKindDef>.GetNamedSilentFail(defname) != null)
            {
                return;
            }
            PawnKindDef pk = new PawnKindDef();
            pk.defName = defname;
            pk.label = pkOld.label + " (" + label + ")";

            pk.apparelRequired = pkOld.apparelRequired.ListFullCopyOrNull<ThingDef>();
            pk.apparelTags = pkOld.apparelTags.ListFullCopyOrNull<string>();
            pk.apparelAllowHeadgearChance = pkOld.apparelAllowHeadgearChance;
            pk.aiAvoidCover = pkOld.aiAvoidCover;
            pk.apparelColor = pkOld.apparelColor;
            pk.apparelIgnoreSeasons = pkOld.apparelIgnoreSeasons;
            pk.apparelMoney = new FloatRange(min: pkOld.apparelMoney.min, max: pkOld.apparelMoney.max);
            pk.backstoryCategories = pkOld.backstoryCategories.ListFullCopyOrNull<string>();
            pk.backstoryCryptosleepCommonality = pkOld.backstoryCryptosleepCommonality;
            pk.baseRecruitDifficulty = pkOld.baseRecruitDifficulty;
            pk.canArriveManhunter = pkOld.canArriveManhunter;
            pk.canBeSapper = pkOld.canBeSapper;
            pk.chemicalAddictionChance = pkOld.chemicalAddictionChance;
            pk.combatEnhancingDrugsChance = pkOld.combatEnhancingDrugsChance;
            pk.combatEnhancingDrugsCount = new IntRange(min: pkOld.combatEnhancingDrugsCount.min, max: pkOld.combatEnhancingDrugsCount.max);
            pk.combatPower = pkOld.combatPower;
            pk.defPackage = pkOld.defPackage;
            pk.defaultFactionType = pkOld.defaultFactionType;
            pk.description = pkOld.description;
            pk.destroyGearOnDrop = pkOld.destroyGearOnDrop;
            pk.ecoSystemWeight = pkOld.ecoSystemWeight;
            pk.factionLeader = pkOld.factionLeader;
            pk.fixedInventory = pkOld.fixedInventory.ListFullCopyOrNull<ThingDefCountClass>();
            pk.fleeHealthThresholdRange = new FloatRange(min: pkOld.fleeHealthThresholdRange.min, max: pkOld.fleeHealthThresholdRange.max);
            pk.forceNormalGearQuality = pkOld.forceNormalGearQuality;
            pk.gearHealthRange = new FloatRange(min: pkOld.gearHealthRange.min, max: pkOld.gearHealthRange.max);
            pk.generated = pkOld.generated;
            pk.inventoryOptions = pkOld.inventoryOptions;
            pk.invFoodDef = pkOld.invFoodDef;
            pk.invNutrition = pkOld.invNutrition;
            pk.isFighter = pkOld.isFighter;
            pk.itemQuality = pkOld.itemQuality;
            pk.lifeStages = pkOld.lifeStages;
            pk.maxGenerationAge = pkOld.maxGenerationAge;
            pk.minGenerationAge = pkOld.minGenerationAge;
            pk.modContentPack = pkOld.modContentPack;
            pk.modExtensions = pkOld.modExtensions;
            pk.trader = pkOld.trader;
            pk.techHediffsChance = pkOld.techHediffsChance;
            pk.techHediffsMoney = new FloatRange(min: pkOld.techHediffsMoney.min, max: pkOld.techHediffsMoney.max);
            pk.techHediffsTags = pkOld.techHediffsTags.ListFullCopyOrNull<string>();
            pk.weaponMoney = new FloatRange(min: pkOld.weaponMoney.min, max: pkOld.weaponMoney.max);
            pk.weaponTags = pkOld.weaponTags.ListFullCopyOrNull<string>();
            pk.wildGroupSize = pkOld.wildGroupSize;

            switch (label)
            {
                case "Elk":
                    // Elks are separate races based on gender due to the antlers.  // so need to do twice
                    if (SettingsController.Settings.ElkMale)
                    {
                        pk.race = DefDatabase<ThingDef_AlienRace>.GetNamed("Beta" + label + "_Male");
                        break;
                    }
                    pk.race = DefDatabase<ThingDef_AlienRace>.GetNamed("Beta" + label + "_Female");
                    break;
                default:
                    pk.race = DefDatabase<ThingDef_AlienRace>.GetNamed("Beta" + label);
                    break;
            }
            DefDatabase<PawnKindDef>.Add(pk);
            DefDatabase<PawnKindDef>.ErrorCheckAllDefs();
            DefDatabase<PawnKindDef>.ResolveAllReferences();
        }
        */
    }
}
