module ClassAbilities

open Classes

let warriorAttacksPerRound = function
    | level when level < 7 -> (1, 1)
    | level when level < 13 -> (3, 2)
    | _ -> (2, 1)
    
let fighterExperienceBonus = function
    | strength when strength < 16 -> 0
    | _ -> 10        
        

type FighterAbilities = 
    {
        AttacksPerRound: int * int
        ExperienceBonus: int        
    }    

type ClassAbilities = 
    | FighterAbilities of FighterAbilities    