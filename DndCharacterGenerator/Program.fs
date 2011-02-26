// Learn more about F# at http://fsharp.net

#light

open System

let random = new Random(DateTime.Now.Millisecond)

let roll dice sides = 
    Seq.initInfinite(fun index -> random.Next(1, (sides + 1)))
    |> Seq.take(dice)
    |> Seq.sum
    
type Ability = 
    | Strength of int
    | Dexterity of int
    | Constitution of int
    | Intelligence of int
    | Wisdom of int
    | Charisma of int   
    member a.Stat = 
        match a with
        | Strength(s) -> s
        | Dexterity(s) -> s
        | Constitution(s) -> s
        | Intelligence(s) -> s
        | Wisdom(s) -> s
        | Charisma(s) -> s
    member a.ChangeStat (f:int->int) = 
        match a with
        | Strength(s) -> Strength(f s)
        | Dexterity(s) -> Dexterity(f s)
        | Constitution(s) -> Constitution(f s)
        | Intelligence(s) -> Intelligence(f s)
        | Wisdom(s) -> Wisdom(f s)
        | Charisma(s) -> Charisma(f s)
    static member (+) (a:Ability, i) = a.ChangeStat(fun s -> s + i)
    static member (+) (i, a:Ability) = a.ChangeStat(fun s -> s + i)
        

type Abilities = { Strength : Ability; Dexterity : Ability; Constitution : Ability; Intelligence : Ability; Wisdom : Ability; Charisma : Ability }

let rollAbilityScores() = 
    let ability() = roll 3 6
    {
        Strength = Strength(ability())
        Dexterity = Dexterity(ability())
        Constitution = Constitution(ability())
        Intelligence = Intelligence(ability())
        Wisdom = Wisdom(ability())
        Charisma = Charisma(ability())
    } 
    
type MinMax = int * int

type AbilityRequirements = { Strength : MinMax; Dexterity : MinMax; Constitution : MinMax; Intelligence : MinMax; Wisdom : MinMax; Charisma : MinMax }

let meetsRequirement (stat:Ability) minmax = (stat.Stat >= (fst minmax)) && (stat.Stat <= (snd minmax))

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
                         
type Specialization = 
    | Mage
    | Abjurer
    | Conjurer
    | Diviner
    | Enchanter
    | Illusionist
    | Invoker
    | Necromancer
    | Transmuter

type CharacterClass = 
    | Fighter 
    | Paladin
    | Ranger
    | Wizard of Specialization
    | Cleric
    | Druid
    | Thief
    | Bard
    
let meetsMinimum cc (abilities:Abilities) = 
    let meetsMinimums = List.forall(fun sm -> (fst sm) >= (snd sm))   
    let meetsSpecialistMinimums specialistAbility = meetsMinimums [(abilities.Intelligence.Stat, 9); specialistAbility; ] 
    match cc with
    | Fighter -> abilities.Strength.Stat >= 9 
    | Paladin -> meetsMinimums [(abilities.Strength.Stat, 12); (abilities.Constitution.Stat, 9); (abilities.Wisdom.Stat, 13); (abilities.Charisma.Stat, 17);]
    | Ranger -> meetsMinimums [(abilities.Strength.Stat, 13); (abilities.Dexterity.Stat, 13); (abilities.Constitution.Stat, 14); (abilities.Wisdom.Stat, 14);]
    | Wizard(Mage) -> abilities.Intelligence.Stat >= 9
    | Wizard(Abjurer) -> meetsSpecialistMinimums (abilities.Wisdom.Stat, 15)
    | Wizard(Conjurer) -> meetsSpecialistMinimums (abilities.Constitution.Stat, 15)
    | Wizard(Diviner) -> meetsSpecialistMinimums (abilities.Wisdom.Stat, 16)
    | Wizard(Enchanter) -> meetsSpecialistMinimums (abilities.Charisma.Stat, 16)
    | Wizard(Illusionist) -> meetsSpecialistMinimums (abilities.Dexterity.Stat, 16)
    | Wizard(Invoker) -> meetsSpecialistMinimums (abilities.Constitution.Stat, 16)
    | Wizard(Necromancer) -> meetsSpecialistMinimums (abilities.Wisdom.Stat, 16)
    | Wizard(Transmuter) -> meetsSpecialistMinimums (abilities.Dexterity.Stat, 15)
    | Cleric -> abilities.Wisdom.Stat >= 9
    | Druid -> meetsMinimums [(abilities.Wisdom.Stat, 12); (abilities.Charisma.Stat, 15);] 
    | Thief -> abilities.Dexterity.Stat >= 9
    | Bard -> meetsMinimums [(abilities.Dexterity.Stat, 12); (abilities.Intelligence.Stat, 13); (abilities.Charisma.Stat, 15);]
    
let availableRaces characterClass = 
    let all = [ Human; Dwarf; Elf; Gnome; HalfElf; Halfling; ]
    match characterClass with
    | Fighter -> all
    | Paladin -> [ Human; ]
    | Ranger -> [ Human; Elf; HalfElf; ]
    | Wizard(Mage) -> [ Human; Elf; HalfElf; ]
    | Wizard(Abjurer) -> [ Human; ]
    | Wizard(Conjurer) -> [ Human; HalfElf; ]
    | Wizard(Diviner) -> [ Human; HalfElf; Elf; ]
    | Wizard(Enchanter) -> [ Human; HalfElf; Elf; ]
    | Wizard(Illusionist) -> [ Human; Gnome; ]
    | Wizard(Invoker) -> [ Human; ]
    | Wizard(Necromancer) -> [ Human; ]
    | Wizard(Transmuter) -> [ Human; HalfElf; ]
    | Cleric -> all
    | Druid -> [ Human; HalfElf; ]
    | Thief -> all
    | Bard -> [ Human; HalfElf; ]
    
let racialAdjustments (abilities:Abilities) race = 
    match race with
    | Human -> abilities
    | HalfElf -> abilities
    | Dwarf -> { abilities with Constitution = (abilities.Constitution + 1); Charisma = (abilities.Charisma - 1); }
    | Elf -> { abilities with Dexterity = (abilities.Dexterity + 1); Constitution = (abilities.Constitution - 1); }
    | Gnome -> { abilities with Intelligence = (abilities.Intelligence + 1); Wisdom = (abilities.Wisdom - 1); }
    | Halfling -> { abilities with Dexterity = abilities.Dexterity + 1; Strength = abilities.Strength - 1; }

//let availableClasses abilities race = 
        
    
//    match characterClass with 
//    | Fighter -> [
//    | Human -> [ Fighter; Paladin; Ranger; Mage; Specialist(Necromancer); Specialist(Illusionist); Cleric; Druid; Thief; Bard; ]
//    | Dwarf -> [ Fighter; ]
//    | _ -> List.empty
//    member cc.AvailableRaces = 
//        let all = [ Human; Dwarf; Elf; Gnome; HalfElf; Halfling; ]
//        match cc with
//        | Fighter -> all
//        | 
//        
//    static member AvailableClasses race abilities = 
//        match race with
//        | Human -> 
////        | Human
////    | Dwarf 
////    | Elf
////    | Gnome
////    | HalfElf
////    | Halfling
//let getCharacter() = 
//    let availableRaces = Race.AvailableRaces (rollAbilityScores())
//    let count = availableRaces.Length
//    List.nth availableRaces (random.Next(0, count))
    
[<EntryPoint>]
let main args =
    printfn "Arguments passed to function : %A" args
    // Return 0. This indicates success.
    0