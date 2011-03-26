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
    
let bonusPriestSpells = function
    | Wisdom(s) when s < 13 -> None
    | Wisdom(13) -> Some([(1, 1)])
    | Wisdom(14) -> Some([(2, 1)])
    | Wisdom(15) -> Some([(2, 1); (1, 2)])
    | Wisdom(16) -> Some([(2, 1); (2, 2)])
    | Wisdom(17) -> Some([(2, 1); (2, 2); (1, 3)])
    | Wisdom(18) -> Some([(2, 1); (2, 2); (1, 3); (1, 4)])
    | Wisdom(19) -> Some([(3, 1); (2, 2); (2, 3); (1, 4)])
    | Wisdom(20) -> Some([(3, 1); (3, 2); (2, 3); (2, 4)])
    | Wisdom(21) -> Some([(3, 1); (3, 2); (3, 3); (2, 4); (1, 5)])
    | Wisdom(22) -> Some([(3, 1); (3, 2); (3, 3); (3, 4); (2, 5)])
    | Wisdom(23) -> Some([(4, 1); (3, 2); (3, 3); (3, 4); (2, 5); (1, 6);])
    | Wisdom(24) -> Some([(4, 1); (3, 2); (3, 3); (3, 4); (3, 5); (2, 6);])
    | Wisdom(25) -> Some([(4, 1); (3, 2); (3, 3); (3, 4); (3, 5); (3, 6); (1, 7);])
    | _ -> failwith "Impossible wisdom"
    
let bonusSpells = function
    | (Priest, Wisdom(s)) -> bonusPriestSpells (Wisdom(s))
    | _ -> None