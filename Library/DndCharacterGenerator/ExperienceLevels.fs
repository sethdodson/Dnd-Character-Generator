module ExperienceLevels

open Dice
open Classes

let hitPoints = function
    | (Warrior, level, hitPointBonus) when level < 10 -> (roll level 10) + hitPointBonus    
    | (Warrior, level, hitPointBonus) -> (roll 9 10) + ((level - 9) * 3) + hitPointBonus
    | (Thaumaturge, level, hitPointBonus) when level < 11 -> (roll level 4) + hitPointBonus
    | (Thaumaturge, level, hitPointBonus) -> (roll 10 4) + level - 10 + hitPointBonus
    | (Priest, level, hitPointBonus) when level < 10 -> (roll level 8) + hitPointBonus
    | (Priest, level, hitPointBonus) -> (roll 9 8) + ((level - 9) * 2) + hitPointBonus
    | (Rogue, level, hitPointBonus) when level < 11 -> (roll level 6) + hitPointBonus
    | (Rogue, level, hitPointBonus) -> (roll 10 6) + ((level - 10) * 2) + hitPointBonus            
                
    
let (|BasicWarriorXp|RangerXp|WizardXp|ClericXp|DruidXp|RogueXp|) = function
    | Fighter -> BasicWarriorXp
    | Paladin -> BasicWarriorXp
    | Ranger ->  RangerXp
    | Wizard(_) -> WizardXp
    | Cleric -> ClericXp
    | Druid -> DruidXp
    | Thief -> RogueXp
    | Bard -> RogueXp
    
let experience = function
    | (_, 1) -> 0
    | (BasicWarriorXp, level) when level < 8 -> (pown 2 (level - 1)) * 1000
    | (BasicWarriorXp, 8) -> 125000
    | (BasicWarriorXp, level) -> (level - 8) * 250000
    | (RangerXp, 2) -> 2250
    | (RangerXp, 3) -> 4500
    | (RangerXp, 4) -> 9000
    | (RangerXp, 5) -> 18000
    | (RangerXp, 6) -> 36000
    | (RangerXp, 7) -> 75000
    | (RangerXp, 8) -> 150000
    | (RangerXp, level) -> (level - 8) * 300000
    | (WizardXp, 2) -> 2500
    | (WizardXp, 3) -> 5000
    | (WizardXp, 4) -> 10000
    | (WizardXp, 5) -> 20000
    | (WizardXp, 6) -> 40000
    | (WizardXp, 7) -> 60000
    | (WizardXp, 8) -> 90000
    | (WizardXp, 9) -> 135000
    | (WizardXp, 10) -> 250000
    | (WizardXp, 11) -> 375000
    | (WizardXp, 12) -> 750000
    | (WizardXp, 13) -> 1125000
    | (WizardXp, 14) -> 1500000
    | (WizardXp, 15) -> 1875000
    | (WizardXp, 16) -> 2250000
    | (WizardXp, 17) -> 2625000
    | (WizardXp, 18) -> 3000000
    | (WizardXp, 19) -> 3375000
    | (WizardXp, 20) -> 3750000
    | (ClericXp, 2) -> 1500
    | (ClericXp, 3) -> 3000
    | (ClericXp, 4) -> 6000
    | (ClericXp, 5) -> 13000
    | (ClericXp, 6) -> 27500
    | (ClericXp, 7) -> 55000
    | (ClericXp, 8) -> 110000
    | (ClericXp, 9) -> 225000
    | (ClericXp, 10) -> 450000
    | (ClericXp, 11) -> 675000
    | (ClericXp, 12) -> 900000
    | (ClericXp, 13) -> 1125000
    | (ClericXp, 14) -> 1350000
    | (ClericXp, 15) -> 1575000
    | (ClericXp, 16) -> 1800000
    | (ClericXp, 17) -> 2025000
    | (ClericXp, 18) -> 2250000
    | (ClericXp, 19) -> 2475000
    | (ClericXp, 20) -> 2700000
    | (DruidXp, 2) -> 2000
    | (DruidXp, 3) -> 4000
    | (DruidXp, 4) -> 7500
    | (DruidXp, 5) -> 12500
    | (DruidXp, 6) -> 20000
    | (DruidXp, 7) -> 35000
    | (DruidXp, 8) -> 60000
    | (DruidXp, 9) -> 90000
    | (DruidXp, 10) -> 125000
    | (DruidXp, 11) -> 200000
    | (DruidXp, 12) -> 300000
    | (DruidXp, 13) -> 750000
    | (DruidXp, 14) -> 1500000
    | (DruidXp, 15) -> 3000000
    | (DruidXp, 16) -> 3500000
    | (DruidXp, 17) -> 4000000
    | (DruidXp, 18) -> 4500000
    | (DruidXp, 19) -> 5000000
    | (DruidXp, 20) -> 5500000
    | (RogueXp, 2) -> 1250
    | (RogueXp, 3) -> 2500
    | (RogueXp, 4) -> 5000
    | (RogueXp, 5) -> 10000
    | (RogueXp, 6) -> 20000
    | (RogueXp, 7) -> 40000
    | (RogueXp, 8) -> 70000
    | (RogueXp, 9) -> 110000
    | (RogueXp, 10) -> 160000
    | (RogueXp, 11) -> 220000
    | (RogueXp, 12) -> 440000
    | (RogueXp, 13) -> 660000
    | (RogueXp, 14) -> 880000
    | (RogueXp, 15) -> 1100000
    | (RogueXp, 16) -> 1320000
    | (RogueXp, 17) -> 1540000
    | (RogueXp, 18) -> 1760000
    | (RogueXp, 19) -> 1980000
    | (RogueXp, 20) -> 2200000    
    | _ -> failwith "Impossible level"
    