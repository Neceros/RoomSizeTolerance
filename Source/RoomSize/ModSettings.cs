using System;
using UnityEngine;
using Verse;

namespace RoomSize
{
  public class RSModSettings : ModSettings
  {
    public static int amountRatherTight = 11;
    public static int amountAverageSized = 21;
    public static int amountSomewhatSpacious = 34;
    public static int amountQuiteSpacious = 55;
    public static int amountVerySpacious = 80;
    public static int amountExtremelyspacious = 135;


    public override void ExposeData()
    {
      base.ExposeData();
      Scribe_Values.Look(ref amountRatherTight, "amountRatherTight");
      Scribe_Values.Look(ref amountAverageSized, "amountAverageSized");
      Scribe_Values.Look(ref amountSomewhatSpacious, "amountSomewhatSpacious");
      Scribe_Values.Look(ref amountQuiteSpacious, "amountQuiteSpacious");
      Scribe_Values.Look(ref amountVerySpacious, "amountVerySpacious");
      Scribe_Values.Look(ref amountExtremelyspacious, "amountExtremelyspacious");
    }
  }

  public class RSMod : Mod
  {
    RSModSettings settings;
    public RSMod(ModContentPack con) : base(con)
    {
      this.settings = GetSettings<RSModSettings>();
    }

    public bool resetPressed;

    public override void DoSettingsWindowContents(Rect inRect)
    {
      if (resetPressed)
      {
        RSModSettings.amountRatherTight = 11;
        RSModSettings.amountAverageSized = 21;
        RSModSettings.amountSomewhatSpacious = 34;
        RSModSettings.amountQuiteSpacious = 55;
        RSModSettings.amountVerySpacious = 80;
        RSModSettings.amountExtremelyspacious = 135;
        resetPressed = false;
      }

      Listing_Standard listing = new Listing_Standard();
      listing.Begin(inRect);
      listing.Label("RSRTLabel".Translate() + ": " + RSModSettings.amountRatherTight.ToString(), tooltip: "RSTooltip".Translate());
      RSModSettings.amountRatherTight = (int)listing.Slider(RSModSettings.amountRatherTight, 1, RSModSettings.amountAverageSized - 1);
      listing.Gap();
      listing.Label("RSASLabel".Translate() + ": " + RSModSettings.amountAverageSized.ToString(), tooltip: "RSTooltip".Translate());
      RSModSettings.amountAverageSized = (int)listing.Slider(RSModSettings.amountAverageSized, RSModSettings.amountRatherTight + 1, RSModSettings.amountSomewhatSpacious - 1);
      listing.Gap();
      listing.Label("RSSSLabel".Translate() + ": " + RSModSettings.amountSomewhatSpacious.ToString(), tooltip: "RSTooltip".Translate());
      RSModSettings.amountSomewhatSpacious = (int)listing.Slider(RSModSettings.amountSomewhatSpacious, RSModSettings.amountAverageSized + 1, RSModSettings.amountQuiteSpacious - 1);
      listing.Gap();
      listing.Label("RSQSLabel".Translate() + ": " + RSModSettings.amountQuiteSpacious.ToString(), tooltip: "RSTooltip".Translate());
      RSModSettings.amountQuiteSpacious = (int)listing.Slider(RSModSettings.amountQuiteSpacious, RSModSettings.amountSomewhatSpacious + 1, RSModSettings.amountVerySpacious - 1);
      listing.Gap();
      listing.Label("RSVSLabel".Translate() + ": " + RSModSettings.amountVerySpacious.ToString(), tooltip: "RSTooltip".Translate());
      RSModSettings.amountVerySpacious = (int)listing.Slider(RSModSettings.amountVerySpacious, RSModSettings.amountQuiteSpacious + 1, RSModSettings.amountExtremelyspacious - 1);
      listing.Gap();
      listing.Label("RSESLabel".Translate() + ": " + RSModSettings.amountExtremelyspacious.ToString(), tooltip: "RSTooltip".Translate());
      RSModSettings.amountExtremelyspacious = (int)listing.Slider(RSModSettings.amountExtremelyspacious, RSModSettings.amountVerySpacious + 1, 500);
      listing.Gap();
      resetPressed = listing.ButtonText("RSResetLabel".Translate());
      listing.End();
      base.DoSettingsWindowContents(inRect);
    }

    public override void WriteSettings()
    {
      RSUtility.UpdateRoomSizes();

      base.WriteSettings();
    }

    public override string SettingsCategory()
    {
      return "RSTitle".Translate();
    }

    private float RoundToNearestHalf(float val)
    { 
      return (float)Math.Round(val * 2, MidpointRounding.AwayFromZero) / 2;
    }

    private float RoundToNearestHundredth(float val)
    {
      return (float)Math.Round(val * 100, MidpointRounding.AwayFromZero) / 100;
    }
  }
}
