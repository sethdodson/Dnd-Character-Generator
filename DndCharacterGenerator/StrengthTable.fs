module StrengthTable

open Dice
open Stats
open Races
open Classes

let exceptionalStrength = function
    | (_, _, Halfling) -> 0
    | (Fighter, Strength(18), _) -> (roll 1 100)
    | (Paladin, Strength(18), _) -> (roll 1 100)
    | (Ranger, Strength(18), _) -> (roll 1 100)
    | _ -> 0

let hitProbability = function
    | (Strength(1), _) -> -5
    | (Strength(2), _) -> -3
    | (Strength(3), _) -> -3
    | (Strength(4), _) | (Strength(5), _) -> -2
    | (Strength(6), _) | (Strength(7), _) -> -1
    | (Strength(s), _) when s < 17 -> 0
    | (Strength(17), _) -> 1
    | (Strength(18), ex) when ex < 51 -> 1
    | (Strength(18), ex) when ex < 100 -> 2
    | (Strength(18), 100) -> 3
    | (Strength(19), _) | (Strength(20), _) -> 3
    | (Strength(21), _) | (Strength(22), _) -> 4
    | (Strength(23), _) -> 5
    | (Strength(24), _) -> 6
    | (Strength(25), _) -> 7
    | _ -> failwith "Impossible strength"   