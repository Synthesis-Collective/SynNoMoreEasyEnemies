using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis.Settings;

namespace SynNoMoreEasyEnemies
{
	class Settings
	{
		public enum LevelSetting
		{
			Medium,
			Hard,
			VeryHard
		}
		
		// Which difficulty level to replace with "None"
		[SynthesisOrder]
		[SynthesisSettingName("Level Modifier to Replace")]
		[SynthesisTooltip("The NPC Level Modifier that will be removed. Pick the Modifier with a multiplier closest to 1.0.\nIf your multipliers are vanilla, use 'Hard'.\nIf your multipliers are harder than normal (OWL, SRLEZ, etc), 'Medium' is probably your best bet.\nIf you want to be sure, open up xEdit with your load order and pick the fLeveledActorMult* Game Setting that is closest to 1.0.\n(XLCM Level Modifier on ACHR records will be deleted for this level modifer.)")]
		public LevelSetting LevelModifierToReplace { get; set; } = LevelSetting.Hard;

		// Should we remove the "Calculate from All Levels" flag from all Leveled NPC lists?
		[SynthesisOrder]
		[SynthesisSettingName("Leveled NPC lists prefer player-level NPCs")]
		[SynthesisTooltip("If enabled, all Leveled NPC lists will prefer NPCs closer to your level.\n(Removes the \"Calculate from all levels <= player's level\" flag from all LVLN records.)")]
		public bool RemoveFlag = true;
	}
}
