using Verse;
using UnityEngine;
using Harmony;
using AlienRace;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

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
        public static string[] RaceIdentif = new string[] {
            "BetaBear",
            "BetaCamel",
            "BetaCroc",
            "BetaElephant",
            "BetaElk",
            "BetaFox",
            "BetaGazelle",
            "BetaHog",
            "BetaLynx",
            "BetaRaccoon",
            "BetaWolf"
        };
        private static int num = RaceIdentif.Length;
        const float defaultSpawnChance = 6f;
        public float[] SpawnChance = Enumerable.Repeat(defaultSpawnChance, num).ToArray();
        private string[] spawnChanceString = Enumerable.Repeat("", num).ToArray();


        private Vector2 pos = new Vector2(0, 0);
        public void DoWindowContents(Rect canvas)
        {
            Listing_Standard list = new Listing_Standard
            {
                ColumnWidth = canvas.width - 20
            };
            list.Begin(canvas);

            Rect scrollView = new Rect(canvas.x, canvas.y, canvas.width, canvas.height * RaceIdentif.Length);
            list.BeginScrollView(canvas, ref pos, ref scrollView);

            list.Gap(60);
            for (int i = 0; i < RaceIdentif.Length; i++)
            {
                list.DrawSlider(("BetaHumanoids.Include_" + RaceIdentif[i]).Translate() + " " + GetspawnChanceLabel(SpawnChance[i]), 
                    ref SpawnChance[i], ref spawnChanceString[i], 0f, 10f);
                list.Gap(24);
            }
            list.EndScrollView(ref scrollView);
            list.End();
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
    }

    public static class LSUtil
    {
        public static void DrawSlider(this Listing_Standard list, string label, ref float value, ref string buffer, float min, float max)
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
            LSUtil.LoadASpecies(Settings.RaceIdentif, SettingsController.Settings.SpawnChance);
        }
    }
}

