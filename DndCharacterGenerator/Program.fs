// Learn more about F# at http://fsharp.net

#light


open System


let random = new Random(DateTime.Now.Millisecond)

let roll dice sides = 
    Seq.initInfinite(fun index -> random.Next(1, (sides + 1)))
    |> Seq.take(dice)
    |> Seq.sum
    
type Abilities = { Strength : int; Dexterity : int; Constitution : int; Intelligence : int; Wisdom : int; Charisma : int }

let rollAbilityScores() = 
    let ability() = roll 3 6
    {
        Strength = ability();
        Dexterity = ability();
        Constitution = ability();
        Intelligence = ability();
        Wisdom = ability();
        Charisma = ability();
    } 
    
type MinMax = int * int

type AbilityRequirements = { Strength : MinMax; Dexterity : MinMax; Constitution : MinMax; Intelligence : MinMax; Wisdom : MinMax; Charisma : MinMax }

let meetsRequirement (stat:int) minmax = (stat >= (fst minmax)) && (stat <= (snd minmax))

let meetsRequirements (requirements:AbilityRequirements) (abilities:Abilities) = 
    let strOK = meetsRequirement abilities.Strength requirements.Strength
    let dexOK = meetsRequirement abilities.Dexterity requirements.Dexterity
    let conOK = meetsRequirement abilities.Constitution requirements.Constitution
    let intOK = meetsRequirement abilities.Intelligence requirements.Intelligence
    let wisOK = meetsRequirement abilities.Wisdom requirements.Wisdom
    let charOK = meetsRequirement abilities.Charisma requirements.Charisma
    strOK && dexOK && conOK && intOK && wisOK && charOK    

type Race = 
    | Human
    | Dwarf 
    | Elf
    | Gnome
    | HalfElf
    | Halfling
    member r.MeetsRequirements = 
        match r with 
        | Human -> (fun _ -> true)
        | Dwarf -> meetsRequirements 
                    { 
                        Strength = (8, 18);
                        Dexterity = (3, 17);
                        Constitution = (11, 18);
                        Intelligence = (3, 18);
                        Wisdom = (3, 18);
                        Charisma = (3, 17)
                    }
        | Elf -> meetsRequirements 
                   {
                       Strength = (3, 18);
                       Dexterity = (6, 18);
                       Constitution = (7, 18);
                       Intelligence = (8, 18);
                       Wisdom = (3, 18);
                       Charisma = (8, 18)
                   }
        | Gnome -> meetsRequirements
                    {
                        Strength = (6, 18);
                        Dexterity = (3, 18);
                        Constitution = (8, 18);
                        Intelligence = (6, 18);
                        Wisdom = (3, 18);
                        Charisma = (3, 18)
                    }
        | HalfElf -> meetsRequirements
                      { 
                        Strength = (3, 18);
                        Dexterity = (6, 18);
                        Constitution = (6, 18);
                        Intelligence = (4, 18);
                        Wisdom = (3, 18);
                        Charisma = (3, 18)
                      }
        | Halfling -> meetsRequirements
                        {
                            Strength = (7, 18);
                            Dexterity = (7, 18);
                            Constitution = (10, 18);
                            Intelligence = (6, 18);
                            Wisdom = (3, 17);
                            Charisma = (3, 18)
                        }
    static member AvailableRaces abilities = 
        [ Human; Dwarf; Elf; Gnome; HalfElf; Halfling ]
        |> List.filter(fun r -> r.MeetsRequirements abilities)
        
//type ClassRequirements = 
//
//type Specialist = 
//    | Necromancer
//    | Illusionist
//
//type CharacterClass = 
//    | Fighter 
//    | Paladin
//    | Ranger
//    | Mage
//    | Specialist of Specialist
//    | Cleric
//    | Druid
//    | Thief
//    | Bard
//    member c.MeetsRequirements abilities = 
        

[<EntryPoint>]
let main args =
    printfn "Arguments passed to function : %A" args
    // Return 0. This indicates success.
    0