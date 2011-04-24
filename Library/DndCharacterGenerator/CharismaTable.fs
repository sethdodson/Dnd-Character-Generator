module CharismaTable

open Stats

let maximumNumberOfHenchmen = function
    | Charisma(1) -> 0
    | Charisma(s) when s < 5 -> 1
    | Charisma(5) | Charisma(6) -> 2
    | Charisma(7) | Charisma(8) -> 3
    | Charisma(s) when s < 12 -> 4
    | Charisma(12) | Charisma(13) -> 5
    | Charisma(14) -> 6
    | Charisma(15) -> 7
    | Charisma(16) -> 8
    | Charisma(s) -> (s - 15) * 5
    | _ -> failwith "Not charisma"       
    
let loyaltyBase = function
    | Charisma(s) when s < 10 -> s - 9
    | Charisma(s) when s < 14 -> 0
    | Charisma(14) -> 1
    | Charisma(15) -> 3
    | Charisma(s) when s < 25 -> (s - 14) * 2
    | Charisma(25) -> 20
    | _ -> failwith "Not charisma or impossible charisma"
    
