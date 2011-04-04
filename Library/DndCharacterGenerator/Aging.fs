module Aging

open Dice
open Races
open Stats

let startingAge = function
    | Dwarf -> 40 + (roll 5 6)
    | Elf -> 100 + (roll 5 6)
    | Gnome -> 60 + (roll 3 12)
    | HalfElf -> 15 + (roll 1 6)
    | Halfling -> 20 + (roll 3 4)
    | Human -> 15 + (roll 1 4)
    
let (|Young|MiddleAge|OldAge|Venerable|) (race, age) = 
    match race with
    | Dwarf when age < 125 -> Young
    | Elf when age < 175 -> Young
    | Gnome when age < 100 -> Young
    | HalfElf when age < 62 -> Young
    | Halfling when age < 50 -> Young
    | Human when age < 45 -> Young
    | Dwarf when age < 167 -> MiddleAge
    | Elf when age < 233 -> MiddleAge
    | Gnome when age < 133 -> MiddleAge
    | HalfElf when age < 83 -> MiddleAge
    | Halfling when age < 67 -> MiddleAge
    | Human when age < 60 -> MiddleAge
    | Dwarf when age < 250 -> OldAge
    | Elf when age < 350 -> OldAge
    | Gnome when age < 200 -> OldAge
    | HalfElf when age < 125 -> OldAge
    | Halfling when age < 100 -> OldAge
    | Human when age < 90 -> OldAge
    | _ -> Venerable
    
let agingEffects (abilities:Abilities) = function
    | Young -> abilities
    | MiddleAge -> { abilities with 
                        Strength = abilities.Strength - 1;
                        Constitution = abilities.Constitution - 1;
                        Intelligence = abilities.Intelligence + 1;
                        Wisdom = abilities.Wisdom + 1; }
    | OldAge -> { abilities with
                    Strength = abilities.Strength - 3;
                    Dexterity = abilities.Dexterity - 2 ;
                    Constitution = abilities.Constitution - 2;
                    Intelligence = abilities.Intelligence + 1;
                    Wisdom = abilities.Wisdom + 2; }
    | Venerable -> { abilities with
                        Strength = abilities.Strength - 4;
                        Dexterity = abilities.Dexterity - 3;
                        Constitution = abilities.Constitution - 3;
                        Intelligence = abilities.Intelligence + 2;
                        Wisdom = abilities.Wisdom + 3; }                                                                                              