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