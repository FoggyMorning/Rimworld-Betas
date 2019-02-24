using Verse;
using UnityEngine;
using Harmony;
using AlienRace;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace BetaHumanoids
{
    public class SettingsController : Mod
    {
        public static Settings Settings;

        public SettingsController(ModContentPack content) : base(content)
        {
            Settings = GetSettings<Settings>();
        }
        public override string SettingsCategory()
        {
            return "BetaHumanoids.ModTitle".Translate();
        }
        public override void DoSettingsWindowContents(Rect canvas) { Settings.DoWindowContents(canvas); }

    }
    public class Settings : ModSettings
    {
        const float defaultSpawnChance = 6f;
        public string[] RaceIdentif = new string[] { "BetaBear", "BetaCamel", "BetaElephant", "BetaElk",
            "BetaFox", "BetaGazelle", "BetaHog", "BetaLynx", "BetaRaccoon", "BetaWolf" };
        public float[] SpawnChance = new float[] { defaultSpawnChance, defaultSpawnChance, defaultSpawnChance,
            defaultSpawnChance, defaultSpawnChance, defaultSpawnChance, defaultSpawnChance, defaultSpawnChance,
            defaultSpawnChance, defaultSpawnChance };
        private string[] spawnChanceString = new string[] { "", "", "", "", "", "", "", "", "", "" };


        private Vector2 pos = new Vector2(0, 0);
        public void DoWindowContents(Rect canvas)
        {
            const float HEIGHT = 70;
            float WIDTH = canvas.width;

            float x = canvas.x;
            float y = canvas.y + 20;
            Widgets.BeginScrollView(new Rect(x, y, WIDTH + 16, 500), ref pos, new Rect(canvas.x, canvas.y, WIDTH, HEIGHT * RaceIdentif.Length * 20));

            for (int i = 0; i < RaceIdentif.Length; i++)
            {
                Widgets.Label(new Rect(x, y, WIDTH, 32), ("BetaHumanoids.Include_" + RaceIdentif[i]).Translate() + GetspawnChanceLabel(SpawnChance[i]));
                y += 30;
                SpawnChance[i] = Widgets.HorizontalSlider(new Rect(x + 80, y, 200, 32), SpawnChance[i], 0f, 10f);
                if (Widgets.ButtonText(new Rect(x + 300, y - 2, 100, 28), "Reset".Translate()))
                {
                    SpawnChance[i] = defaultSpawnChance;
                }
                y += 30;
            }
            Widgets.EndScrollView();
        }
        public override void ExposeData()
        {
            base.ExposeData();
            for (int i = 0; i < RaceIdentif.Length; i++)
            {
                string nameVal = "BetaHumanoids.Include_" + RaceIdentif[i];
                Scribe_Values.Look(ref SpawnChance[i], nameVal, 6f);

                if (Scribe.mode == LoadSaveMode.PostLoadInit)
                {
                        spawnChanceString[i] = ((int)SpawnChance[i]).ToString();
                }
            }
            if (Scribe.mode == LoadSaveMode.Saving)
            {
                LSUtil.LoadASpecies(RaceIdentif, SpawnChance);
            }
        }
        private static string GetspawnChanceLabel(float spawnChance)
        {
            if (spawnChance <= 0.0)
            {
                return "BetaHumanoids.spawnChanceVeryLow".Translate();
            }
            else if (spawnChance < .75)
            {
                return "BetaHumanoids.spawnChanceLow".Translate();
            }
            else if (spawnChance < 1.5)
            {
                return "BetaHumanoids.spawnChanceNormal".Translate();
            }
            else if (spawnChance < 4)
            {
                return "BetaHumanoids.spawnChanceHigh".Translate();
            }
            else if (spawnChance < 8)
            {
                return "BetaHumanoids.spawnChanceVeryHigh".Translate();
            }
            return "BetaHumanoids.spawnChanceInsane".Translate();
        }
        public static void DrawSlider(Listing_Standard list, string label, ref float value, ref string buffer, float min, float max)
        {
            float f;
            string s = buffer;
            buffer = list.ModTextEntryLabeled(label, buffer);
            if (!s.Equals(buffer))
            {
                if (float.TryParse(buffer, out f))
                {
                    if (f > 0)
                        value = f;
                }
            }

            f = value;
            value = list.Slider(value, min, max);
            if (f != value)
            {
                buffer = ((int)value).ToString();
            }
        }
    }

    public static class LSUtil
    {
        public static string ModTextEntryLabeled(this Listing_Standard ls, string label, string buffer, int lineCount = 1)
        {
            Rect rect = ls.GetRect(Text.LineHeight * (float)lineCount);
            Widgets.Label(new Rect(rect.x, rect.y, rect.width - 75, rect.height), label);
            string result = Widgets.TextField(new Rect(rect.xMax - 65, rect.y, 65, rect.height), buffer);
            ls.Gap(ls.verticalSpacing);
            return result;
        }
        public static void LoadASpecies(string[] labels, float[] chances)
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
                                foreach (string kd in pke.kindDefs)
                                {
                                    if (kd.Contains(label))
                                    {
                                        pke.chance = chances[i] * 10;
                                    };
                                };
                            };
                        };
                        foreach (FactionPawnKindEntry awk in rs.pawnKindSettings.alienwandererkinds)
                        {
                            foreach (PawnKindEntry pke in awk.pawnKindEntries)
                            {
                                foreach (string kd in pke.kindDefs)
                                {
                                    if (kd.Contains(label))
                                    {
                                        pke.chance = chances[i] * 10;

                                    };
                                };
                            };
                        };
                        foreach (PawnKindEntry ark in rs.pawnKindSettings.alienrefugeekinds)
                        {
                            foreach (string kd in ark.kindDefs)
                            {
                                if (kd.Contains(label))
                                {
                                    ark.chance = chances[i] * 10;

                                };
                            };
                        };
                        foreach (PawnKindEntry ask in rs.pawnKindSettings.alienslavekinds)
                        {
                            foreach (string kd in ask.kindDefs)
                            {
                                if (kd.Contains(label))
                                {
                                    ask.chance = chances[i] * 10;

                                };
                            };
                        };
                        break;

                    }
                }
            }
        }
    }
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
            LSUtil.LoadASpecies(SettingsController.Settings.RaceIdentif, SettingsController.Settings.SpawnChance);
        }
    }
}

