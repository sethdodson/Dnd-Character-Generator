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
    
let chanceWizardToLearnSpell = function
    | s when s < 9 -> None
    | s when s < 18 -> Some((s - 2) * 5)
    | 18 -> Some(85)
    | s when s < 25 -> Some(95 + (s - 19))
    | 25 -> Some(100)
    | _ -> failwith "Impossible intelligence"
    
let chanceToLearnSpell = function
    | (Thaumaturge, Intelligence(s)) -> chanceWizardToLearnSpell s   
    | _ -> None 
    
type SpellLimit = 
    | Limited of int option
    | All
    
let maxNumberOfSpellsPerWizardLevel = function
    | 9 -> Limited(Some(6))
    | s when s < 13 -> Limited(Some(7))
    | 13 | 14 -> Limited(Some(9))
    | 15 | 16 -> Limited(Some(11))
    | 17 -> Limited(Some(14))
    | 18 -> Limited(Some(18))
    | s when s > 18 -> All
    | _ -> failwith "Impossible intelligence"
    
let maxNumberOfSpellsPerLevel = function
    | (Thaumaturge, Intelligence(s)) -> maxNumberOfSpellsPerWizardLevel s
    | _ -> Limited(None)
    
let illusionImmunity = function
    | Intelligence(s) when s < 19 -> None
    | Intelligence(s) -> Some((s - 18))
    | _ -> failwith "Not intelligence"