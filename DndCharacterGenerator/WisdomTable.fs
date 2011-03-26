module WisdomTable

open Stats

let magicalDefenseAdjustment = function
    | Wisdom(1) -> -6
    | Wisdom(s) when s < 6 -> s - 6
    | Wisdom(6) | Wisdom(7) -> -1
    | Wisdom(s) when s < 15 -> 0
    | Wisdom(s) when s < 20 -> s - 14
    | Wisdom(_) -> 4
    | _ -> failwith "Not wisdom"