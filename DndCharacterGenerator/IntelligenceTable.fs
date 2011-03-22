module IntelligenceTable

open Stats
open Classes

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
    
let maxWizardSpellLevel = function
    | Intelligence(s) when s < 9 -> None
    | Intelligence(9) -> Some(4)
    | Intelligence(10) | Intelligence(11) -> Some(5)
    | Intelligence(12) | Intelligence(13) -> Some(6)
    | Intelligence(14) | Intelligence(15) -> Some(7)
    | Intelligence(16) | Intelligence(17) -> Some(8)
    | Intelligence(_) -> Some(9)
    | _ -> failwith "Not intelligence"
    
let maxSpellLevel = function
    | (Thaumaturge, s) -> maxWizardSpellLevel s
    | _ -> None    