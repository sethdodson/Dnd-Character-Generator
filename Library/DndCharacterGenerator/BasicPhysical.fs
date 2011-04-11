module BasicPhysical

open Dice
open Races

type Sex = 
    | Male
    | Female
    member s.Name = 
        match s with
        | Male -> "Male"
        | Female -> "Female"
    
let height = function
    | (Dwarf, Male) -> 43 + (roll 1 10)
    | (Dwarf, Female) -> 41 + (roll 1 10)
    | (Elf, Male) -> 55 + (roll 1 10)
    | (Elf, Female) -> 50 + (roll 1 10)
    | (Gnome, Male) -> 38 + (roll 1 6)
    | (Gnome, Female) -> 36 + (roll 1 6)
    | (HalfElf, Male) -> 60 + (roll 2 6)
    | (HalfElf, Female) -> 58 + (roll 2 6)
    | (Halfling, Male) -> 32 + (roll 2 8)
    | (Halfling, Female) -> 30 + (roll 2 8)
    | (Human, Male) -> 60 + (roll 2 10)
    | (Human, Female) -> 59 + (roll 2 10)
    
let weight = function
    | (Dwarf, Male) -> 130 + (roll 4 10)
    | (Dwarf, _) -> 105 + (roll 4 10)
    | (Elf, Male) -> 90 + (roll 3 10)
    | (Elf, _) -> 70 + (roll 3 10)
    | (Gnome, Male) -> 72 + (roll 5 4)
    | (Gnome, _) -> 68 + (roll 5 4)
    | (HalfElf, Male) -> 110 + (roll 3 12)
    | (HalfElf, _) -> 85 + (roll 3 12)
    | (Halfling, Male) -> 52 + (roll 5 4)
    | (Halfling, _) -> 48 + (roll 5 4)
    | (Human, Male) -> 140 + (roll 6 10)
    | (Human, _) -> 100 + (roll 6 10)    