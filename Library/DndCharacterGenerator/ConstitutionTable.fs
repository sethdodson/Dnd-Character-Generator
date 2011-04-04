module ConstitutionTable

open Stats
open Classes

let hitPointAdjustment = function
    | (Constitution(1), _) -> -3
    | (Constitution(s), _) when s < 4 -> -2
    | (Constitution(s), _) when s < 7 -> -1
    | (Constitution(s), _) when s < 15 -> 0
    | (Constitution(15), _) -> 1
    | (Constitution(16), _) -> 2
    | (Constitution(17), Warrior) -> 3
    | (Constitution(18), Warrior) -> 4
    | (Constitution(s), Warrior) when s < 21 -> 5
    | (Constitution(s), Warrior) when s < 24 -> 6
    | (Constitution(s), Warrior) when s < 26 -> 7
    | (Constitution(_), _) -> 2
    | _ -> failwith "Wrong ability or impossible constitution"

let hitPointMinimum = function
    | (Constitution(s), _) when s < 20 -> 1
    | (Constitution(20), Warrior) -> 2
    | (Constitution(s), Warrior) when s < 23 -> 3
    | (Constitution(s), Warrior) when s < 26 -> 4
    | _ -> 1    
    
let systemShock = function
    | Constitution(s) when s < 14 -> (s + 4) * 5
    | Constitution(14) -> 88
    | Constitution(15) -> 90
    | Constitution(16) -> 95
    | Constitution(17) -> 97
    | Constitution(s) when s < 25 -> 99
    | Constitution(_) -> 100
    | _ -> failwith "Not constitution"
        
let resurrectionSurvival = function
    | Constitution(s) when s < 14 -> (s + 5) * 5
    | Constitution(s) when s < 18 -> ((s - 13) * 2) + 90
    | Constitution(_) -> 100
    | _ -> failwith "Not constitution"     
    
let poisonSaveBonus = function
    | Constitution(1) -> -2
    | Constitution(2) -> -1
    | Constitution(s) when s < 19 -> 0
    | Constitution(19) | Constitution(20) -> 1
    | Constitution(21) | Constitution(22) -> 2
    | Constitution(23) | Constitution(24) -> 3
    | Constitution(_) -> 4
    | _ -> failwith "Not constitution"
    
let regenerationTurns = function
    | Constitution(s) when s < 20 -> None
    | Constitution(s) -> Some((26 - s))
    | _ -> failwith "Not constitution"    