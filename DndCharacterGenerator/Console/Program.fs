// Learn more about F# at http://fsharp.net
#light

open CharacterGenerator
open System
open StatDisplay

Console.WriteLine("Character Generator")

let quitting = function
    | "Q" -> true
    | "q" -> true
    | _ -> false

let rec getLevel() = 
    Console.Write("Level: ")
    let level = Console.ReadLine() |> Int32.TryParse
    if ((fst level)) then snd level
    else getLevel()
    
let characterModel = getLevel() |> getCharacter

Console.WriteLine("Alignment: {0}/{1}", characterModel.Legality.Name, characterModel.Morality.Name)
Console.WriteLine("Race: {0}", characterModel.Race.Name)
Console.WriteLine("Class: {0}", characterModel.Class.Name)
Console.WriteLine("Level: {0}", characterModel.Level)
Console.WriteLine("Strength: {0}", displayStrength characterModel)
Console.WriteLine("Dexterity: {0}", characterModel.Abilities.Dexterity.Stat)
Console.WriteLine("Constitution: {0}", characterModel.Abilities.Constitution.Stat)
Console.WriteLine("Intelligence: {0}", characterModel.Abilities.Intelligence.Stat)
Console.WriteLine("Wisdom: {0}", characterModel.Abilities.Wisdom.Stat)
Console.WriteLine("Charisma: {0}", characterModel.Abilities.Charisma.Stat)
Console.WriteLine("Sex: {0}", characterModel.Sex.Name)
Console.WriteLine("Age: {0}", characterModel.Age)
Console.WriteLine("Height: {0}", characterModel.Height.Description)
Console.WriteLine("Weight: {0} lbs", characterModel.Weight)
Console.WriteLine("Hit Probability Adjustment: {0}", displayHitProbability characterModel.HitProbability)
Console.WriteLine("Damage Adjustment: {0}", displayDamageAdjustment characterModel.DamageAdjustment)
Console.WriteLine("Weight Allowance: {0} lbs", characterModel.WeightAllow)
Console.WriteLine("Max Press: {0} lbs", characterModel.MaxPress)
Console.WriteLine("Open Doors: {0}", displayOpenDoors (characterModel.OpenDoors, characterModel.OpenHardenedDoors))
Console.WriteLine("Bend Bars: {0}%", characterModel.BendBars)
Console.WriteLine("Reaction Adjustment: {0}", (showSign characterModel.DexReactionAdjustment))
Console.WriteLine("Missile Attack Adjustment: {0}", showSign characterModel.DexReactionAdjustment)
Console.WriteLine("Defensive Adjustment: {0}", showSign characterModel.DefensiveAdjustment)
Console.WriteLine("Hit Point Adjustment: {0}", showSign characterModel.HitPointAdjustment)
Console.WriteLine("System Shock: {0}%", characterModel.SystemShock)
Console.WriteLine("Resurrection Survival: {0}%", characterModel.ResurrectionSurvival)
Console.WriteLine("Poison Save: {0}", showSign characterModel.PoisonSaveBonus)
Console.WriteLine("Regeneration: {0}", displayRegeneration characterModel.Regeneration)
Console.WriteLine("Number of Languages: {0}", characterModel.NumberOfLanguages)
Console.WriteLine("Spell Level: {0}", displayMaxSpellLevel characterModel.MaxSpellLevel)
Console.WriteLine("Chance to Learn Spell: {0}", displayChanceToLearnSpell characterModel.ChanceToLearnSpell)
Console.WriteLine("Max Number of Spells Per Level: {0}", characterModel.MaxNumberOfSpellsPerLevel.Description)
Console.WriteLine("Illusion Immunity: {0}", displayIllusionImmunity characterModel.IllusionImmunity)
Console.WriteLine("Magical Defense Adjustment: {0}", showSign characterModel.MagicalDefenseAdjustment)

Console.ReadLine() |> ignore