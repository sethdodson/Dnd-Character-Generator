module IntelligenceTable

open Stats

let numberOfLanguages = function
    | Intelligence(1) -> 0
    | Intelligence(s) when s < 9 -> 1
    | Intelligence(s) when s < 12 -> 2
    | Intelligence(12) | Intelligence(13) -> 3
    | Intelligence(14) | Intelligence(15) -> 4
    | Intelligence(s) when s < 24 -> s - 11
    | Intelligence(24) -> 15
    | Intelligence(25) -> 20
    | _ -> failwith "Not intelligence"