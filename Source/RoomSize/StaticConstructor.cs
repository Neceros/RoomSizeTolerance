using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace RoomSize
{
  [StaticConstructorOnStartup]
  public static class RSStartUp
  {
    static RSStartUp()
    {
      // Loads right before main menu
      RSUtility.UpdateRoomSizes();
    }
  }

  public class RSUtility
  {
    public static void UpdateRoomSizes()
    {
      //DefDatabase<HediffDef>.GetNamed("SmokeleafHigh").stages[0].capMods[0].offset = LLLModSettings.amountPenaltyConsciousness;
      //HediffDef.Named("SmokeleafHigh").stages.Where((HediffStage stage) => stage.capMods.Any((PawnCapacityModifier mod) => mod.capacity == PawnCapacityDefOf.Consciousness)).First().capMods.Where((PawnCapacityModifier mod) => mod.capacity == PawnCapacityDefOf.Consciousness).First().offset = RSModSettings.amountCramped;
      foreach(RoomStatScoreStage stage in DefDatabase<RoomStatDef>.GetNamed("Space").scoreStages)
      {
        if (stage.label == "rather tight")
          stage.minScore = RSModSettings.amountRatherTight;

        if (stage.label == "average-sized")
          stage.minScore = RSModSettings.amountAverageSized;

        if (stage.label == "somewhat spacious")
          stage.minScore = RSModSettings.amountSomewhatSpacious;

        if (stage.label == "quite spacious")
          stage.minScore = RSModSettings.amountQuiteSpacious;

        if (stage.label == "very spacious")
          stage.minScore = RSModSettings.amountVerySpacious;

        if (stage.label == "extremely spacious")
          stage.minScore = RSModSettings.amountExtremelyspacious;
      }
    }
  }
}
