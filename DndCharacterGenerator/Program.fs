// Learn more about F# at http://fsharp.net

#light

open Stats
open Dice
open Races         
open Classes          
open System 
open Aging
    
type Sex = 
    | Male
    | Female
    
let height = function
    | (Dwarf, Male) -> 43 + (roll 1 10)
    | (Dwarf, Female) -> 41 + (roll 1 10)
    | (Elf, Male) -> 55 + (roll 1 10)
    | (Elf, Female) -> 50 + (roll 1 10)
    | (Gnome, Male) -> 38 + (roll 1 6)
    | (Gnome, Female) -> 36 + (roll 1 6)
    | (HalfElf, Male) -> 60 + (roll 2 6)
    | (HalfElf, Female) -> 58 + (roll 2 6)
    | (Halfling, Male) -> 32 + (roll 2 8)
    | (Halfling, Female) -> 30 + (roll 2 8)
    | (Human, Male) -> 60 + (roll 2 10)
    | (Human, Female) -> 59 + (roll 2 10)
    
let weight = function
    | (Dwarf, Male) -> 130 + (roll 4 10)
    | (Dwarf, _) -> 105 + (roll 4 10)
    | (Elf, Male) -> 90 + (roll 3 10)
    | (Elf, _) -> 70 + (roll 3 10)
    | (Gnome, Male) -> 72 + (roll 5 4)
    | (Gnome, _) -> 68 + (roll 5 4)
    | (HalfElf, Male) -> 110 + (roll 3 12)
    | (HalfElf, _) -> 85 + (roll 3 12)
    | (Halfling, Male) -> 52 + (roll 5 4)
    | (Halfling, _) -> 48 + (roll 5 4)
    | (Human, Male) -> 140 + (roll 6 10)
    | (Human, _) -> 100 + (roll 6 10)    
                                               
let getCharacter() = 
    let abilities = rollAbilityScores()
    let availableRaces = Race.AvailableRaces abilities
    let race = List.nth availableRaces (random.Next(0, availableRaces.Length))
    let age = characterAge race
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
    (alignment, race, chosenClass, 1, sex, age, charHeight, charWeight)
    
[<EntryPoint>]
let main args =
    printfn "Arguments passed to function : %A" args
    Console.ReadLine() |> ignore
    // Return 0. This indicates success.
    0