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
    static member (-) (a:Ability, i) = a.ChangeStat(fun s -> s - i)
    static member (-) (i, a:Ability) = a.ChangeStat(fun s -> i - s)

type Abilities = 
     { Strength : Ability; 
       Dexterity : Ability; 
       Constitution : Ability; 
       Intelligence : Ability; 
       Wisdom : Ability; 
       Charisma : Ability }
     member a.ToList = [ a.Strength; a.Dexterity; a.Constitution; a.Intelligence; a.Wisdom; a.Charisma; ]     

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
    member cc.Minimums = 
        match cc with
        | Fighter -> [ Strength(9) ]
        | Paladin -> [ Strength(12); Constitution(9); Wisdom(13); Charisma(17); ]
        | Ranger -> [ Strength(13); Dexterity(13); Constitution(14); Wisdom(14); ]
        | Wizard(Mage) -> [ Intelligence(9); ]
        | Wizard(Abjurer) -> [ Intelligence(9); Wisdom(15); ]
        | Wizard(Conjurer) -> [ Intelligence(9); Constitution(15); ]
        | Wizard(Diviner) -> [ Intelligence(9); Wisdom(16); ]
        | Wizard(Enchanter) -> [ Intelligence(9); Charisma(16); ]
        | Wizard(Illusionist) -> [ Intelligence(9); Dexterity(16); ]
        | Wizard(Invoker) -> [ Intelligence(9); Constitution(16); ]
        | Wizard(Necromancer) -> [ Intelligence(9); Wisdom(16); ]
        | Wizard(Transmuter) -> [ Intelligence(9); Dexterity(15); ]
        | Cleric -> [ Wisdom(9); ]
        | Druid -> [ Wisdom(12); Charisma(15); ]
        | Thief -> [ Dexterity(9); ]
        | Bard -> [ Dexterity(12); Intelligence(13); Charisma(15); ]        
    member cc.MeetsMinimums (abilities:Abilities) = 
        cc.Minimums |> List.forall(fun min -> match min with
                                              | Strength(s) -> abilities.Strength.Stat >= s
                                              | Dexterity(d) -> abilities.Dexterity.Stat >= d
                                              | Constitution(c) -> abilities.Dexterity.Stat >= c
                                              | Intelligence(i) -> abilities.Intelligence.Stat >= i
                                              | Wisdom(w) -> abilities.Wisdom.Stat >= w
                                              | Charisma(c) -> abilities.Charisma.Stat >= c)  
    member cc.PrimeRequisites =     
        match cc with
        | Fighter -> [ Strength; ]
        | Paladin -> [ Strength; Charisma; ]
        | Ranger -> [ Strength; Dexterity; Wisdom; ]
        | Wizard(_) -> [ Intelligence; ]
        | Cleric -> [ Wisdom; ]
        | Druid -> [ Wisdom; Charisma; ]
        | Thief -> [ Dexterity; ]
        | Bard -> [ Dexterity; Charisma; ]        
    static member AvailableClasses race abilities = 
        let meetsRequirements = List.filter(fun (c:CharacterClass) -> c.MeetsMinimums abilities)
        match race with 
        | Human -> meetsRequirements [ Fighter; 
                                       Paladin; 
                                       Ranger; 
                                       Wizard(Mage); 
                                       Wizard(Abjurer); 
                                       Wizard(Conjurer); 
                                       Wizard(Diviner); 
                                       Wizard(Enchanter); 
                                       Wizard(Illusionist); 
                                       Wizard(Invoker);
                                       Wizard(Necromancer);
                                       Wizard(Transmuter);
                                       Cleric;
                                       Druid;
                                       Thief;
                                       Bard; ]
        | Dwarf -> meetsRequirements [ Fighter; Cleric; Thief; ]
        | Elf -> meetsRequirements [ Fighter; Ranger; Wizard(Mage); Wizard(Diviner); Wizard(Enchanter); Cleric; Thief; ]
        | Gnome -> meetsRequirements [ Fighter; Wizard(Illusionist); Cleric; Thief; ]
        | HalfElf -> meetsRequirements [ Fighter; 
                                         Ranger; 
                                         Wizard(Mage); 
                                         Wizard(Conjurer); 
                                         Wizard(Diviner); 
                                         Wizard(Enchanter);
                                         Wizard(Transmuter);
                                         Cleric;
                                         Druid;
                                         Thief;
                                         Bard; ]
        | Halfling -> meetsRequirements [ Fighter; Cleric; Thief; ]
            
let racialAdjustments (abilities:Abilities) race = 
    match race with
    | Human -> abilities
    | HalfElf -> abilities
    | Dwarf -> { abilities with Constitution = (abilities.Constitution + 1); Charisma = (abilities.Charisma - 1); }
    | Elf -> { abilities with Dexterity = (abilities.Dexterity + 1); Constitution = (abilities.Constitution - 1); }
    | Gnome -> { abilities with Intelligence = (abilities.Intelligence + 1); Wisdom = (abilities.Wisdom - 1); }
    | Halfling -> { abilities with Dexterity = abilities.Dexterity + 1; Strength = abilities.Strength - 1; }    
    
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
    (abilities, availableRaces, race, adjustedAbilities, availableClasses, chosenClass)
    
[<EntryPoint>]
let main args =
    printfn "Arguments passed to function : %A" args
    // Return 0. This indicates success.
    0