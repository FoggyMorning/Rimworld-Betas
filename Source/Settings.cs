using Verse;
using UnityEngine;

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
        private Vector2 scrollPosition;
        public SpeciesControl Bear = new SpeciesControl("Bear", new string[] { "BetaBear" });
        public SpeciesControl Camel = new SpeciesControl("Camel", new string[] { "BetaCamel" });
        public SpeciesControl Croc = new SpeciesControl("Croc", new string[] { "BetaCroc" });
        public SpeciesControl Elephant = new SpeciesControl("Elephant", new string[] { "BetaElephant" });
        public SpeciesControl Elk = new SpeciesControl("Elk", new string[] { "BetaElk_Female", "BetaElk_Male" });
        public SpeciesControl Fox = new SpeciesControl("Fox", new string[] { "BetaFox" });
        public SpeciesControl Gazelle = new SpeciesControl("Gazelle", new string[] { "BetaGazelle" });
        public SpeciesControl Hog = new SpeciesControl("Hog", new string[] { "BetaHog" });
        public SpeciesControl Lynx = new SpeciesControl("Lynx", new string[] { "BetaLynx" });
        public SpeciesControl Raccoon = new SpeciesControl("Raccoon", new string[] { "BetaRaccoon" });
        public SpeciesControl Wolf = new SpeciesControl("Wolf", new string[] { "BetaWolf" });
        public void DoWindowContents(Rect canvas)
        {
            SpeciesControl[] speciesList = new SpeciesControl[] { Bear, Camel, Croc, Elephant, Elk, Fox, Gazelle, Hog, Lynx, Raccoon, Wolf };
            GUI.BeginGroup(position: canvas);
            Widgets.BeginScrollView(
                outRect: canvas,
                scrollPosition: ref this.scrollPosition,
                viewRect: new Rect(x: 0f, y: 0f, width: canvas.width, height: speciesList.Length * 400f)
            );

            float num = 6f;
            float grower = 40f;
            Text.Font = GameFont.Small;
            Rect rect;
            Widgets.DrawLineHorizontal(x: 0, y: num += grower, length: canvas.width);
            rect = new Rect(x: 0f, y: num, width: canvas.width - 16f, height: 40f);
            Text.Font = GameFont.Medium;
            Widgets.Label(rect, "Colonist, Wanderer, Refugees, and Slaves");
            Text.Font = GameFont.Small;
            for (int x = 0; x < speciesList.Length; x++)
            {
                Widgets.DrawLineHorizontal(x: 0, y: num += grower, length: canvas.width);
                rect = new Rect(x: 0f, y: num, width: canvas.width - 16f, height: grower);
                Widgets.Label(rect, speciesList[x].Label + " settings");
                Widgets.DrawLineHorizontal(x: 0, y: num += grower, length: canvas.width);
                rect = new Rect(x: 0f, y: num, width: canvas.width - 16f, height: grower);
                Widgets.CheckboxLabeled(rect, "include " + speciesList[x].Label + " as possible colonists", ref speciesList[x].Colonist);
                rect = new Rect(x: 0f, y: num += grower, width: canvas.width - 16f, height: grower);
                Widgets.CheckboxLabeled(rect, "include " + speciesList[x].Label + " as possible wanderers", ref speciesList[x].Wanderer);
                rect = new Rect(x: 0f, y: num += grower, width: canvas.width - 16f, height: grower);
                Widgets.CheckboxLabeled(rect, "include " + speciesList[x].Label + " as possible refugees", ref speciesList[x].Refugee);
                rect = new Rect(x: 0f, y: num += grower, width: canvas.width - 16f, height: grower);
                Widgets.CheckboxLabeled(rect, "include " + speciesList[x].Label + " as potential slaves", ref speciesList[x].Slave);
            }
            Widgets.DrawLineHorizontal(x: 0, y: num += grower, length: canvas.width);
            rect = new Rect(x: 0f, y: num + 15f, width: canvas.width - 16f, height: 40f);
            Text.Font = GameFont.Medium;
            Widgets.Label(rect, "Include in Factions: Pirate, Outlander, and Tribals");
            Text.Font = GameFont.Small;
            for (int x = 0; x < speciesList.Length; x++)
            {
                Widgets.DrawLineHorizontal(x: 0, y: num += grower, length: canvas.width);
                rect = new Rect(x: 0f, y: num + 15f, width: canvas.width - 16f, height: grower);
                Widgets.Label(rect, speciesList[x].Label + " settings");
                Widgets.DrawLineHorizontal(x: 0, y: num += grower, length: canvas.width);
                rect = new Rect(x: 0f, y: num, width: canvas.width - 16f, height: grower);
                Widgets.CheckboxLabeled(rect, "include in Pirate factions?", ref speciesList[x].Pirate);
                rect = new Rect(x: 0f, y: num += grower, width: canvas.width - 16f, height: grower);
                Widgets.CheckboxLabeled(rect, "include in the Outlander factions?", ref speciesList[x].Outlander);
                rect = new Rect(x: 0f, y: num += grower, width: canvas.width - 16f, height: grower);
                Widgets.CheckboxLabeled(rect, "include in the Tribal factions?", ref speciesList[x].Tribal);
            }
            Widgets.EndScrollView();
            GUI.EndGroup();
        }

        public float spawnChance = 60f;
        public override void ExposeData()
        {
            SpeciesControl[] speciesList = new SpeciesControl[] { Bear, Camel, Croc, Elephant, Elk, Fox, Gazelle, Hog, Lynx, Raccoon, Wolf };
            base.ExposeData();
            Scribe_Values.Look(ref spawnChance, "BetaHumanoids.SpawnChance", 70f);
            for (int x = 0; x < speciesList.Length; x++)
            {
                Scribe_Values.Look(ref speciesList[x].Colonist, "BetaHumanoids." + speciesList[x].Label + ".IncludeAsColonist", true);
                Scribe_Values.Look(ref speciesList[x].Wanderer, "BetaHumanoids." + speciesList[x].Label + ".IncludeAsWanderer", true);
                Scribe_Values.Look(ref speciesList[x].Refugee, "BetaHumanoids." + speciesList[x].Label + ".IncludeAsRefugee", true);
                Scribe_Values.Look(ref speciesList[x].Slave, "BetaHumanoids." + speciesList[x].Label + ".IncludeAsSlave", false);

                Scribe_Values.Look(ref speciesList[x].Pirate, "BetaHumanoids." + speciesList[x].Label + ".IncludeAsPirate", true);
                Scribe_Values.Look(ref speciesList[x].Outlander, "BetaHumanoids." + speciesList[x].Label + ".IncludeAsOutlander", false);
                Scribe_Values.Look(ref speciesList[x].Tribal, "BetaHumanoids." + speciesList[x].Label + ".IncludeAsTribal", false);
                if (Scribe.mode == LoadSaveMode.Saving)
                {
                    RaceSettingsUpdater.AdjustSpawnChance();
                    Factions.AddAliensToNPCFactions();
                }
            }
        }
    }
    public class SpeciesControl
    {
        public string[] DefNames;
        public string Label;
        public SpeciesControl(string label, string[] defName)
        {
            Label = label;
            DefNames = defName;
        }
        public bool Pirate = true;
        public bool Outlander = true;
        public bool Tribal = true;
        public bool Colonist = true;
        public bool Refugee = true;
        public bool Wanderer = true;
        public bool Slave = true;
    }
}
