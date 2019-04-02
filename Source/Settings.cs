using Verse;
using UnityEngine;
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
        public override string SettingsCategory() => "BetaHumanoids.ModTitle".Translate();
        public override void DoSettingsWindowContents(Rect canvas) { Settings.DoWindowContents(canvas); }

    }


    public class Settings : ModSettings
    {
        public static string[] RaceIdentif = new string[] {
            "Bear",
            "Camel",
            "Croc",
            "Elephant",
            "Elk",
            "Fox",
            "Gazelle",
            "Hog",
            "Lynx",
            "Raccoon",
            "Wolf"
        };
        public string[] labels = RaceIdentif;
        private static int num = RaceIdentif.Length;
        const float defaultSpawnChance = 1.5f;
        public float[] SpawnChance = Enumerable.Repeat(defaultSpawnChance, num).ToArray();
        public bool IncludeInPirate = false;
        public bool IncludeInOutlander = false;
        public bool IncludeInTribal = false;
        // Elks are separate races based on gender due to the antlers.  // so need to do twice
        public bool ElkMale = false;

        private Vector2 pos = new Vector2(0, 0);
        public void DoWindowContents(Rect canvas)
        {
            Listing_Standard list = new Listing_Standard
            {
                ColumnWidth = canvas.width - 20
            };
            list.Begin(canvas);

            Rect scrollView = new Rect(canvas.x, canvas.y, canvas.width + 1.50f, canvas.height );

            list.BeginScrollView(canvas, ref pos, ref scrollView);

            list.Gap(60);
            list.GapLine();
            list.Label("BetaHumanoids.IncludeHeader".Translate());
            list.Label("BetaHumanoids.IncludeSubHeader".Translate());
            list.GapLine();
            for (int i = 0; i < RaceIdentif.Length; i++)
            {
                list.SliderLabelled(("BetaHumanoids.Include_Beta" + RaceIdentif[i]).Translate(), ref SpawnChance[i], "", 0f, 10f, (SpawnChance[i]*10f).ToString("0.00")+"%");
                list.Gap(list.verticalSpacing);
            }

            list.GapLine();
            Rect rect = list.GetRect(Text.LineHeight).LeftPart(0.5f);
            Widgets.CheckboxLabeled(rect, ("BetaHumanoids.IncludeInPirate").Translate(), ref IncludeInPirate);

            list.GapLine();
            rect = list.GetRect(Text.LineHeight).LeftPart(0.5f);
            Widgets.CheckboxLabeled(rect, ("BetaHumanoids.IncludeInOutlander").Translate(), ref IncludeInOutlander);

            list.GapLine();
            rect = list.GetRect(Text.LineHeight).LeftPart(0.5f);
            Widgets.CheckboxLabeled(rect, ("BetaHumanoids.IncludeInTribal").Translate(), ref IncludeInTribal);

            list.EndScrollView(ref scrollView);

            list.End();
        }
        public override void ExposeData()
        {
            base.ExposeData();
            for (int i = 0; i < RaceIdentif.Length; i++)
            {
                string nameVal = RaceIdentif[i];
                Scribe_Values.Look(ref SpawnChance[i], "BetaHumanoids.Include_Beta" + nameVal, defaultSpawnChance);
            }
            Scribe_Values.Look(ref IncludeInPirate, "BetaHumanoids.IncludeAsPirate", false);
            Scribe_Values.Look(ref IncludeInOutlander, "BetaHumanoids.IncludeInOutlander", false);
            Scribe_Values.Look(ref IncludeInTribal, "BetaHumanoids.IncludeInTribal", false);
            if (Scribe.mode == LoadSaveMode.Saving)
            {
                Factions.AdjustAlienRaceSettingsSpawnChance(RaceIdentif, SpawnChance);
                Factions.AddAliensToNPCFactions(RaceIdentif, SpawnChance);
            }
        }
    }

    public static class SettingsHelper
    {

        // got this function from AUTOMATIC's gradient hair mod.
        public static void SliderLabelled(this Listing_Standard listing, string label, ref float val, string tooltip, float min, float max, string format)
        {
            Rect rect = listing.GetRect(Text.LineHeight);

            TextAnchor anchor = Text.Anchor;
            Text.Anchor = TextAnchor.MiddleLeft;
            Widgets.Label(rect.LeftPart(0.5f), label);
            val = Widgets.HorizontalSlider(rect.RightPart(0.5f).LeftPart(0.8f), val, min, max, true);
            Text.Anchor = TextAnchor.MiddleRight;
            Widgets.Label(rect.RightPart(0.1f), string.Format(format, val));
            if (!tooltip.NullOrEmpty()) TooltipHandler.TipRegion(rect, tooltip);
            Text.Anchor = anchor;

            listing.Gap(listing.verticalSpacing);
        }
    }
}

