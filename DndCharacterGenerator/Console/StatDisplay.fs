#light

module StatDisplay

open CharacterGenerator
open System

let showSign (num:int) = num.ToString("+#;-#;0")

let displayStrength (cm:CharacterModel) = 
    let showStrength = function
        | (st, 0) -> st.ToString()
        | (st, e) -> String.Format("{0}/{1}", st, e)
    showStrength (cm.Abilities.Strength.Stat, cm.ExceptionalStrength)

let displayHitProbability = function 
    | 0 -> "Normal"
    | hp -> showSign hp

let displayDamageAdjustment = function
    | 0 -> "None"
    | da -> showSign da

let displayOpenDoors = function
    | (x, 0) -> x.ToString()
    | (x, y) -> String.Format("{0}({1})", x, y)

let displayRegeneration = function
    | Some(x, y) -> String.Format("{0}/{1} turns", x, y)
    | None -> "Nil"

let displayMaxSpellLevel = function
    | Some(lv) -> String.Format("{0}th", lv.ToString())
    | None -> "-"

let displayChanceToLearnSpell = function
    | Some(ch) -> String.Format("{0}%", ch.ToString())
    | None -> "-"

let displayIllusionImmunity = function
    | Some(1) -> "1st-level"
    | Some(2) -> "2nd-level"
    | Some(3) -> "3rd-level"
    | Some(x) -> String.Format("{0}th-level")
    | None -> "-"