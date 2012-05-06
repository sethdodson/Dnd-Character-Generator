#light

module StatDisplay

open CharacterGenerator
open System

let showSign (num:int) = num.ToString("+#;-#;0")

let displayStrength (cm:CharacterModel) = 
    let showStrength = function
        | (st, 0) when st < 19 -> st.ToString()
        | (st, e) -> String.Format("{0}/{1}", st, e)
        | (19, _) -> "19 (Hill Giant)"
        | (20, _) -> "20 (Stone Giant)"
        | (21, _) -> "21 (Frost Giant)"
        | (22, _) -> "22 (Fire Giant)"
        | (23, _) -> "23 (Cloud Giant)"
        | (24, _) -> "24 (Storm Giant)"
        | (25, _) -> "25 (Titan)"
        | _ -> failwith "No Strength"
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
    | Some(x) -> String.Format("{0}th-level", x)
    | None -> "-"

let displayBonusSpells = 
    let level = function
        | (1) -> "1st"
        | (2) -> "2nd"
        | (3) -> "3rd"
        | (l) -> String.Format("{0}th", l)
    let levels = List.map(level) >> List.toArray
    let separate = function
        | [||] -> "-"
        | levels -> String.Join(", ", levels)
    levels >> separate

let displayImmunity = function
    | [] -> "-"
    | immunities -> String.Join(", ", (List.toArray immunities))