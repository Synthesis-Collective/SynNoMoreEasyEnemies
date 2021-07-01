# NoMoreEasyEnemies
Rework NPC leveled list difficulty multipliers and settings to banish low-level enemies from your high-level dungeons.

ELI5: No more level 1 draugers in your level 30 dungeon.

## Wait, what?
The way Skyrim chooses which NPC to place in a dungeon is...complicated. Long story short, it uses a combination of your level, actor multipliers, the spawn's difficulty setting, and some flags to determine which level of an NPC is standing in a particular spot. 

The problem is that one of the spawn difficulties, "Easy", chooses from the list in such a way that it has the (quite good) chance to spawn the lowest-level enemies. There is a flag to turn this off, which "Easy" ignores completely. So any time you have an "Easy" spawn in a dungeon, there's a chance for you to see a low-level enemy in that spot.

This patcher reworks the multipliers and the spawn settings to avoid this issue with the "Easy" setting.  It optionally updates all Leveled NPC lists to prevent low-level enemies from being spawned.

## How?
The easiest way to explain the HOW is with an example.

By default, Skyrim uses the following spawn difficulty (leveled actors) multipliers:
- fLeveledActorMultEasy: 0.33
- fLeveledActorMultMedium: 0.67
- fLeveledActorMultHard: 1.00
- fLeveledActorMultVeryHard: 1.25

Critically, if a spawn does NOT have a difficulty set, the multiplier used is a static 1.00.  We can abuse this fact to avoid the issue with the "Easy" spawn difficulty.

If you leave the "Level Modifier to Replace" setting at the default of Hard, NoMoreEasyEnemies will do the following:
- Change fLeveledActorMultMedium to 0.33 (new Easy)
- Change fLeveledActorMultHard to 0.67 (new Medium)
- For all enemy spawns (Placed NPCs), if the old difficulty setting was "Easy", change it to "Medium"
- For all enemy spawns (Placed NPCs), if the old difficulty setting was "Medium", change it to "Hard"
- For all enemy spawns (Placed NPCs), if the old difficulty setting was "Hard", delete the setting (force to multiplier of 1.00)
- Optionally update all Leveled NPC lists to remove the "Calculate From All Levels Less Than Or Equal Player" flag if it is set, preventing low level NPCs from spawning when those lists are used

Now there should be NO spawns with a difficulty of "Easy". Previously "Easy" spawns are now "Medium". Previously "Medium" spawns are now "Hard". Previously "Hard" spawns are now empty, so a multiplier of 1.00. And all the Leveled NPC lists will only select the highest-eligible NPCs.

## Settings
All settings can be configured inside the Synthesis app.

### Spawn Difficulty to Replace
This is the Difficulty (Level Modifier) that will be replaced by a static multiplier of 1.0 (modifier removed).

Pick the Modifier with a multiplier closest to 1.0.  

If your multipliers are vanilla, use 'Hard'.
If your multipliers are harder than normal (OWL, SRLEZ, etc), 'Medium' is probably your best bet.

To get the exact correct value, open up xEdit with your load order. Enter each of the following FormIDs in the 'FormID' box in the top left and hit ENTER. Note the Data/Float value for each setting.  Use the value in the farthest-right column of the right pane. Do NOT use the value in Synthesis.esp, though.

- Easy: 0001A1D9
- Medium: 0001A1DB
- Hard: 0001A1DA
- VeryHard: 00023C0B

Whichever game setting is closest to 1.00 is the difficulty you should set in Synthesis.

**Default**: Hard

### Leveled NPC lists prefer player-level NPCs
If enabled, all Leveled NPC lists will be updated to remove the "Calculate From All Levels Less Than Or Equal Player" flag if it is set. This will prevent the Leveled NPC list from selecting lower-level NPCs when spawning NPCs. This is slightly more risky if a mod or event depends on lower-level NPCs being selected. Please report any issues with this.

**Default**: enabled


## FAQ
### Will this break things?
I don't think so. You're using the same leveled lists that you were before, all we're doing is influencing which NPC will get selected. If you want to be extra safe, disable the "Leveled NPC lists prefer player-level NPCs" setting.

As a precaution, you could create a save before entering a new interior area with enemies. Once you enter a dungeon, the enemies are generated and saved into your next save file, and it is not simple to regenerate them.

### Why are there still a few level 1 enemies?!?
Bethesda, in its infinite wisdom, has statically set some spawns to use specific NPCs rather than leveled lists. These NPCs are often set to level 1 and do not scale with the player. Call Todd and ask him.