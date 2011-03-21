// Learn more about F# at http://fsharp.net

#light

open Stats
open Dice
open Races         
open Classes          
open System 
open Aging
open BasicPhysical   
open StrengthTable
open DexterityTable
open ConstitutionTable
                                               
let getCharacter() = 
    let abilities = rollAbilityScores()
    let availableRaces = Race.AvailableRaces abilities
    let race = List.nth availableRaces (random.Next(0, availableRaces.Length))
    let age = startingAge race
    let adjustedAbilities = agingEffects (racialAdjustments abilities race) (race, age)
    let chosenClass = 
        let prerequisiteValue (cc:CharacterClass) = 
            cc.Minimums 
            |> List.map(fun min -> match min with
                                   | Strength(s) -> adjustedAbilities.Strength.Stat - s + 1
                                   | Dexterity(d) -> adjustedAbilities.Dexterity.Stat - d + 1
                                   | Constitution(c) -> adjustedAbilities.Constitution.Stat - c + 1
                                   | Intelligence(i) -> adjustedAbilities.Intelligence.Stat - i + 1
                                   | Wisdom(w) -> adjustedAbilities.Wisdom.Stat - w + 1
                                   | Charisma(c) -> adjustedAbilities.Charisma.Stat - c + 1)            
            |> List.sum
        let (|PrestigeClass|MundaneClass|) = function
               | Wizard(Mage) -> MundaneClass
               | Wizard(_) -> PrestigeClass
               | Paladin -> PrestigeClass
               | Ranger -> PrestigeClass
               | Bard -> PrestigeClass
               | _ -> MundaneClass
        let getClassValue ccp1 ccp2 = 
            match (ccp1, ccp2) with
            | ((_, prereq1), (_, prereq2)) when prereq1 > prereq2 -> 1
            | ((_, prereq1), (_, prereq2)) when prereq1 < prereq2 -> -1
            | ((PrestigeClass, _), (MundaneClass, _)) -> 1
            | ((MundaneClass, _), (PrestigeClass, _)) -> -1
            | _ -> 0
        let classesByValue = 
            (CharacterClass.AvailableClasses race)
            >> List.map(fun cc -> (cc, (prerequisiteValue cc)))
            >> List.sortWith(getClassValue)
        adjustedAbilities |> classesByValue |> List.rev |> List.head |> fst
    let alignment = List.nth chosenClass.AvailableAlignments (random.Next(0, chosenClass.AvailableAlignments.Length))
    let sex = 
        let coin = (random.Next(0, 1))
        if coin = 0 then Male else Female
    let charHeight = (height (race, sex))
    let charWeight = (weight (race, sex))
    let charExceptionalStrength = exceptionalStrength (chosenClass, adjustedAbilities.Strength, race)
    let charHitProbability = hitProbability (adjustedAbilities.Strength, charExceptionalStrength)
    let charDamageAdjustment = damageAdjustment (adjustedAbilities.Strength, charExceptionalStrength)
    (alignment, race, chosenClass, 1, adjustedAbilities, 
     charExceptionalStrength, sex, age, charHeight, charWeight, 
     charHitProbability, charDamageAdjustment, 
     (weightAllow (adjustedAbilities.Strength, charExceptionalStrength)),
     (maxPress (adjustedAbilities.Strength, charExceptionalStrength)),
     (openDoors (adjustedAbilities.Strength, charExceptionalStrength)),
     (openHardenedDoors (adjustedAbilities.Strength, charExceptionalStrength)),
     (bendBars (adjustedAbilities.Strength, charExceptionalStrength)),
     (dexReactionAdjustment adjustedAbilities.Dexterity),
     (missileAttackAdjustment adjustedAbilities.Dexterity),
     (defensiveAdjustment adjustedAbilities.Dexterity),
     (hitPointAdjustment (adjustedAbilities.Constitution, chosenClass.Type)),
     (systemShock adjustedAbilities.Constitution),
     (resurrectionSurvival adjustedAbilities.Constitution),
     (poisonSaveBonus adjustedAbilities.Constitution))
    
[<EntryPoint>]
let main args =
    printfn "Arguments passed to function : %A" args
    Console.ReadLine() |> ignore
    // Return 0. This indicates success.
    0