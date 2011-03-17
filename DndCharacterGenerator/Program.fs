// Learn more about F# at http://fsharp.net

#light

open Stats
open Dice
open Races         
open Classes          
open System 
    
type Sex = 
    | Male
    | Female

let getCharacter() = 
    let abilities = rollAbilityScores()
    let availableRaces = Race.AvailableRaces abilities
    let race = List.nth availableRaces (random.Next(0, availableRaces.Length))
    let adjustedAbilities = racialAdjustments abilities race
    let availableClasses = CharacterClass.AvailableClasses race adjustedAbilities     
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
        let (|PrestigeClass|MundaneClass|) cc = 
               match cc with
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
            availableClasses
            |> List.map(fun cc -> (cc, (prerequisiteValue cc)))
            |> List.sortWith(getClassValue)
        classesByValue |> List.rev |> List.head |> fst
    let alignment = List.nth chosenClass.AvailableAlignments (random.Next(0, chosenClass.AvailableAlignments.Length))
    let sex = 
        let coin = (random.Next(0, 1))
        if coin = 0 then Male else Female
    (alignment, race, chosenClass, 1, sex)
    
[<EntryPoint>]
let main args =
    printfn "Arguments passed to function : %A" args
    Console.ReadLine() |> ignore
    // Return 0. This indicates success.
    0