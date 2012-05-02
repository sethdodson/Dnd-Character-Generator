module WisdomTable

open Stats
open Classes

let magicalDefenseAdjustment = function
    | Wisdom(1) -> -6
    | Wisdom(s) when s < 6 -> s - 6
    | Wisdom(6) | Wisdom(7) -> -1
    | Wisdom(s) when s < 15 -> 0
    | Wisdom(s) when s < 20 -> s - 14
    | Wisdom(_) -> 4
    | _ -> failwith "Not wisdom"   

let bonusSpells wisdom = 
    let rec accumulateBonus acc wis = 
        match wis with
        | Wisdom(13) -> accumulateBonus (1::acc) (Wisdom(12))
        | Wisdom(14) -> accumulateBonus (1::acc) (Wisdom(13))
        | Wisdom(15) -> accumulateBonus (2::acc) (Wisdom(14))
        | Wisdom(16) -> accumulateBonus (2::acc) (Wisdom(15))
        | Wisdom(17) -> accumulateBonus (3::acc) (Wisdom(16))
        | Wisdom(18) -> accumulateBonus (4::acc) (Wisdom(17))
        | Wisdom(19) -> accumulateBonus (List.append [1; 3] acc) (Wisdom(18))
        | Wisdom(20) -> accumulateBonus (List.append [2; 4] acc) (Wisdom(19))
        | Wisdom(21) -> accumulateBonus (List.append [3; 5] acc) (Wisdom(20))
        | Wisdom(22) -> accumulateBonus (List.append [4; 5] acc) (Wisdom(21))
        | Wisdom(23) -> accumulateBonus (List.append [1; 6] acc) (Wisdom(22))
        | Wisdom(24) -> accumulateBonus (List.append [5; 6] acc) (Wisdom(23))
        | Wisdom(25) -> accumulateBonus (List.append [6; 7] acc) (Wisdom(24))
        | _ -> acc
    accumulateBonus [] wisdom
   
let chanceOfSpellFailure = function
    | Wisdom(1) -> 80
    | Wisdom(2) -> 60
    | Wisdom(s) when s < 13 -> (13 - s) * 5
    | Wisdom(_) -> 0
    | _ -> failwith "Not wisdom"