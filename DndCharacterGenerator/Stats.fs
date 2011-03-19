module Stats

open Dice

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