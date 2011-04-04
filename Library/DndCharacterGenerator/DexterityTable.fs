module DexterityTable

open Stats

let dexReactionAdjustment = function
    | Dexterity(1) -> -6
    | Dexterity(2) -> -4
    | Dexterity(3) -> -3
    | Dexterity(4) -> -2
    | Dexterity(5) -> -1
    | Dexterity(s) when s < 16 -> 0
    | Dexterity(16) -> 1
    | Dexterity(17) | Dexterity(18) -> 2
    | Dexterity(19) | Dexterity(20) -> 3
    | Dexterity(s) when s < 24 -> 4
    | Dexterity(s) when s < 26 -> 5
    | _ -> failwith "Impossible dexterity"
    
let missileAttackAdjustment = function
    | Dexterity(1) -> -6
    | Dexterity(2) -> -4
    | Dexterity(3) -> -3
    | Dexterity(4) -> -2
    | Dexterity(5) -> -1
    | Dexterity(s) when s < 16 -> 0
    | Dexterity(16) -> 1
    | Dexterity(17) | Dexterity(18) -> 2
    | Dexterity(19) | Dexterity(20) -> 3
    | Dexterity(s) when s < 24 -> 4
    | Dexterity(24) | Dexterity(25) -> 5
    | _ -> failwith "Impossible dexterity" 
    
let defensiveAdjustment = function
    | Dexterity(s) when s < 3 -> 5
    | Dexterity(3) -> 4
    | Dexterity(4) -> 3
    | Dexterity(5) -> 2
    | Dexterity(6) -> 1
    | Dexterity(s) when s < 15 -> 0
    | Dexterity(15) -> -1
    | Dexterity(16) -> -2
    | Dexterity(17) -> -3
    | Dexterity(s) when s < 21 -> -4
    | Dexterity(s) when s < 24 -> -5
    | Dexterity(24) | Dexterity(25) -> -6
    | _ -> failwith "Impossible dexterity"    