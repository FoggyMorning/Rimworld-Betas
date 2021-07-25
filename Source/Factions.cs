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
                                if (pke.kindDefs.Any(k => k.label.Contains(label)))
                                {
                                    pke.chance = chances[i];
                                };
                            };
                        };
                        foreach (FactionPawnKindEntry awk in rs.pawnKindSettings.alienwandererkinds)
                        {
                            foreach (PawnKindEntry pke in awk.pawnKindEntries)
                            {
                                if (pke.kindDefs.Any(k => k.label.Contains(label)))
                                {
                                    pke.chance = chances[i];
                                };
                            };
                        };
                        foreach (PawnKindEntry pke in rs.pawnKindSettings.alienrefugeekinds)
                        {
                            if (pke.kindDefs.Any(k => k.label.Contains(label)))
                            {
                                pke.chance = chances[i];
                            };
                        };
                        foreach (PawnKindEntry pke in rs.pawnKindSettings.alienslavekinds)
                        {
                            if (pke.kindDefs.Any(k => k.label.Contains(label)))
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
                        f.pawnGroupMakers[x] = AddPawnKindsToFactions(g[x], labels[i], chances[i]);
                    }
                }
                if (SettingsController.Settings.IncludeInOutlander)
                {
                    FactionDef f = DefDatabase<FactionDef>.GetNamed("OutlanderCivil", true);
                    PawnGroupMaker[] g = f.pawnGroupMakers.ToArray();
                    for (int x = 0; x < g.Length; x++)
                    {
                        f.pawnGroupMakers[x] = AddPawnKindsToFactions(g[x], labels[i], chances[i]);
                    }
                }
                if (SettingsController.Settings.IncludeInOutlander)
                {
                    FactionDef f = DefDatabase<FactionDef>.GetNamed("OutlanderRough", true);
                    PawnGroupMaker[] g = f.pawnGroupMakers.ToArray();
                    for (int x = 0; x < g.Length; x++)
                    {
                        f.pawnGroupMakers[x] = AddPawnKindsToFactions(g[x], labels[i], chances[i]);
                    }
                }
                if (SettingsController.Settings.IncludeInTribal)
                {
                    FactionDef f = DefDatabase<FactionDef>.GetNamed("TribeCivil", true);
                    PawnGroupMaker[] g = f.pawnGroupMakers.ToArray();
                    for (int x = 0; x < g.Length; x++)
                    {
                        f.pawnGroupMakers[x] = AddPawnKindsToFactions(g[x], labels[i], chances[i]);
                    }
                }
                if (SettingsController.Settings.IncludeInTribal)
                {
                    FactionDef f = DefDatabase<FactionDef>.GetNamed("TribeRough", true);
                    PawnGroupMaker[] g = f.pawnGroupMakers.ToArray();
                    for (int x = 0; x < g.Length; x++)
                    {
                        f.pawnGroupMakers[x] = AddPawnKindsToFactions(g[x], labels[i], chances[i]);
                    }
                }
                if (SettingsController.Settings.IncludeInTribal)
                {
                    FactionDef f = DefDatabase<FactionDef>.GetNamed("TribeSavage", true);
                    PawnGroupMaker[] g = f.pawnGroupMakers.ToArray();
                    for (int x = 0; x < g.Length; x++)
                    {
                        f.pawnGroupMakers[x] = AddPawnKindsToFactions(g[x], labels[i], chances[i]);
                    }
                }

            }
        }


        private static PawnGroupMaker AddPawnKindsToFactions(PawnGroupMaker pgm, string label, float chance)
        {
            if (label == "Elk")
            {
                SettingsController.Settings.ElkMale = true;
                // Elks are separate races based on gender due to the antlers.  // so need to do twice
                // groups can be either an options or a guards for whatever reason, so check for both.
                PawnGenOption[] optionsElkMale = pgm.options.ToArray();
                for (int i = 0; i < optionsElkMale.Length; i++)
                {
                PawnGenOption pgo = MakePawnGenOption(optionsElkMale[i], label, chance);
                    if (pgo != null) { pgm.AddPawn(pgo, false); }
                }
                PawnGenOption[] guardsElkMale = pgm.guards.ToArray();
                for (int j = 0; j < guardsElkMale.Length; j++)
                {
                    PawnGenOption pgo = MakePawnGenOption(guardsElkMale[j], label, chance);
                    if (pgo != null) { pgm.AddPawn(pgo, true); }
                }
                SettingsController.Settings.ElkMale = false;
            }
            // groups can be either an options or a guards for whatever reason, so check for both.
            PawnGenOption[] options = pgm.options.ToArray();
            for (int i = 0; i < options.Length; i++)
            {
                PawnGenOption pgo = MakePawnGenOption(options[i], label, chance);
                if (pgo != null) { pgm.AddPawn(pgo, false); }
            }
            PawnGenOption[] guards = pgm.guards.ToArray();
            for (int j = 0; j < guards.Length; j++)
            {
                PawnGenOption pgo = MakePawnGenOption(guards[j], label, chance);
                if (pgo != null) { pgm.AddPawn(pgo, true); }
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
        private static PawnGenOption MakePawnGenOption(PawnGenOption existing, string label, float chance)
        {
            string pawnKindLabel = existing.kind.defName;
            float sw = existing.selectionWeight * 0.075f;

            // if it is one of our defs then don't recreate it
            // if some alien race other than a Human then don't risk copying it
            if (pawnKindLabel.Contains("_BetaHumanoids_") || PawnKindDef.Named(pawnKindLabel).race != ThingDefOf.Human)
            {
                return null;
            }
            string defname = "Beta" + label + "_" + pawnKindLabel;
            if (label == "Elk")
            { 
                // Elks are separate races based on gender due to the antlers.  so need to add gender
                if (SettingsController.Settings.ElkMale)
                {
                    defname += "Beta" + label + "_Male_" + pawnKindLabel;
                } else
                {
                    defname += "Beta" + label + "_Female_" + pawnKindLabel;
                }
            }
            PawnKindDef pkOld = PawnKindDef.Named(pawnKindLabel);
            if (pkOld.factionLeader)
            {
                return null;
            }
            CreateNewPawnKind(pkOld, label, defname);
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

        private static void CreateNewPawnKind(PawnKindDef pkOld, string label, string defname)
        {
            // if it already exists then don't recreate it
            if (DefDatabase<PawnKindDef>.GetNamedSilentFail(defname) != null)
            {
                return;
            }
            PawnKindDef pk = new PawnKindDef
            {
                defName = defname,
                label = pkOld.label + " (Beta" + label + ")",

                allowRoyalApparelRequirements = pkOld.allowRoyalApparelRequirements,
                allowRoyalRoomRequirements = pkOld.allowRoyalRoomRequirements,
                alternateGraphicChance = pkOld.alternateGraphicChance,
                alternateGraphics = pkOld.alternateGraphics.ListFullCopyOrNull<AlternateGraphic>(),
                apparelRequired = pkOld.apparelRequired.ListFullCopyOrNull<ThingDef>(),
                apparelDisallowTags = pkOld.apparelDisallowTags.ListFullCopyOrNull<string>(),
                apparelTags = pkOld.apparelTags.ListFullCopyOrNull<string>(),
                apparelAllowHeadgearChance = pkOld.apparelAllowHeadgearChance,
                aiAvoidCover = pkOld.aiAvoidCover,
                apparelColor = pkOld.apparelColor,
                apparelIgnoreSeasons = pkOld.apparelIgnoreSeasons,
                apparelMoney = new FloatRange(min: pkOld.apparelMoney.min, max: pkOld.apparelMoney.max),
                backstoryCategories = pkOld.backstoryCategories.ListFullCopyOrNull<string>(),
                backstoryFilters = pkOld.backstoryFilters.ListFullCopyOrNull<BackstoryCategoryFilter>(),
                backstoryFiltersOverride = pkOld.backstoryFiltersOverride.ListFullCopyOrNull<BackstoryCategoryFilter>(),
                backstoryCryptosleepCommonality = pkOld.backstoryCryptosleepCommonality,
                baseRecruitDifficulty = pkOld.baseRecruitDifficulty,
                biocodeWeaponChance = pkOld.biocodeWeaponChance,
                canArriveManhunter = pkOld.canArriveManhunter,
                canBeSapper = pkOld.canBeSapper,
                chemicalAddictionChance = pkOld.chemicalAddictionChance,
                combatEnhancingDrugsChance = pkOld.combatEnhancingDrugsChance,
                combatEnhancingDrugsCount = pkOld.combatEnhancingDrugsCount,
                combatPower = pkOld.combatPower,
                defaultFactionType = pkOld.defaultFactionType,
                description = pkOld.description,
                defendPointRadius = pkOld.defendPointRadius,
                destroyGearOnDrop = pkOld.destroyGearOnDrop,
                disallowedTraits = pkOld.disallowedTraits.ListFullCopyOrNull<TraitDef>(),
                ecoSystemWeight = pkOld.ecoSystemWeight,
                factionLeader = pkOld.factionLeader,
                fixedInventory = pkOld.fixedInventory.ListFullCopyOrNull<ThingDefCountClass>(),
                fleeHealthThresholdRange = new FloatRange(min: pkOld.fleeHealthThresholdRange.min, max: pkOld.fleeHealthThresholdRange.max),
                forceNormalGearQuality = pkOld.forceNormalGearQuality,
                gearHealthRange = new FloatRange(min: pkOld.gearHealthRange.min, max: pkOld.gearHealthRange.max),
                generated = pkOld.generated,
                inventoryOptions = pkOld.inventoryOptions,
                invFoodDef = pkOld.invFoodDef,
                invNutrition = pkOld.invNutrition,
                isFighter = pkOld.isFighter,
                itemQuality = pkOld.itemQuality,
                labelMale = pkOld.labelMale,
                labelMalePlural = pkOld.labelMalePlural,
                labelFemale = pkOld.labelFemale,
                labelFemalePlural = pkOld.labelFemalePlural,
                labelPlural = pkOld.labelPlural,
                lifeStages = pkOld.lifeStages.ListFullCopyOrNull<PawnKindLifeStage>(),
                maxGenerationAge = pkOld.maxGenerationAge,
                minGenerationAge = pkOld.minGenerationAge,
                modContentPack = pkOld.modContentPack,
                modExtensions = pkOld.modExtensions,
                royalTitleChance = pkOld.royalTitleChance,
                skills = pkOld.skills.ListFullCopyOrNull<SkillRange>()
            };
            pk.specificApparelRequirements = pkOld.specificApparelRequirements.ListFullCopyOrNull<SpecificApparelRequirement>();
            pk.trader = pkOld.trader;
            pk.titleSelectOne = pkOld.titleSelectOne.ListFullCopyOrNull<RoyalTitleDef>();
            pk.techHediffsRequired = pkOld.techHediffsRequired.ListFullCopyOrNull<ThingDef>();
            pk.techHediffsChance = pkOld.techHediffsChance;
            pk.techHediffsMaxAmount = pkOld.techHediffsMaxAmount;
            pk.techHediffsMoney = new FloatRange(min: pkOld.techHediffsMoney.min, max: pkOld.techHediffsMoney.max);
            pk.techHediffsTags = pkOld.techHediffsTags.ListFullCopyOrNull<string>();
            pk.techHediffsDisallowTags = pkOld.techHediffsDisallowTags.ListFullCopyOrNull<string>();
            pk.weaponMoney = new FloatRange(min: pkOld.weaponMoney.min, max: pkOld.weaponMoney.max);
            pk.weaponTags = pkOld.weaponTags.ListFullCopyOrNull<string>();
            pk.wildGroupSize = pkOld.wildGroupSize;
            pk.initialResistanceRange = pkOld.initialResistanceRange.GetValueOrDefault();
            pk.initialWillRange = pkOld.initialWillRange.GetValueOrDefault();

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
        }
    }
}
