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
    
let damageAdjustment = function
    | (Strength(1), _) -> -4
    | (Strength(2), _) -> -2
    | (Strength(s), _) when s < 6 -> -1
    | (Strength(s), _) when s < 16 -> 0
    | (Strength(s), _) when s < 18 -> 1
    | (Strength(18), 0) -> 2
    | (Strength(18), ex) when ex < 76 -> 3
    | (Strength(18), ex) when ex < 91 -> 4
    | (Strength(18), ex) when ex < 100 -> 5
    | (Strength(18), 100) -> 6
    | (Strength(s), _) when s < 25 -> s - 12
    | (Strength(25), _) -> 14
    | _ -> failwith "Impossible strength"
    
let weightAllow = function
    | (Strength(s), _) when s < 3 -> 1
    | (Strength(3), _) -> 5
    | (Strength(s), _) when s < 6 -> 10
    | (Strength(s), _) when s < 8 -> 20 
    | (Strength(s), _) when s < 10 -> 35
    | (Strength(s), _) when s < 12 -> 40
    | (Strength(s), _) when s < 14 -> 45
    | (Strength(s), _) when s < 16 -> 55
    | (Strength(16), _) -> 70
    | (Strength(17), _) -> 85
    | (Strength(18), 0) -> 110
    | (Strength(18), ex) when ex < 51 -> 135
    | (Strength(18), ex) when ex < 76 -> 160
    | (Strength(18), ex) when ex < 91 -> 185
    | (Strength(18), ex) when ex < 100 -> 235
    | (Strength(18), 100) -> 335
    | (Strength(19), _) -> 485
    | (Strength(20), _) -> 535
    | (Strength(21), _) -> 635
    | (Strength(22), _) -> 785
    | (Strength(23), _) -> 935
    | (Strength(24), _) -> 1235
    | (Strength(25), _) -> 1535
    | _ -> failwith "Impossible strength"
    
let maxPress = function
    | (Strength(1), _) -> 3
    | (Strength(2), _) -> 5
    | (Strength(3), _) -> 10
    | (Strength(s), _) when s < 6 -> 25
    | (Strength(s), _) when s < 8 -> 55
    | (Strength(s), _) when s < 10 -> 90 
    | (Strength(s), _) when s < 12 -> 115
    | (Strength(s), _) when s < 14 -> 140
    | (Strength(s), _) when s < 16 -> 170 
    | (Strength(16), _) -> 195
    | (Strength(17), _) -> 220
    | (Strength(18), 0) -> 255
    | (Strength(18), 51) -> 280
    | (Strength(18), 76) -> 305
    | (Strength(18), 91) -> 330
    | (Strength(18), 100) -> 380
    | (Strength(18), 100) -> 480
    | (Strength(19), _) -> 640
    | (Strength(20), _) -> 700
    | (Strength(21), _) -> 810
    | (Strength(22), _) -> 970
    | (Strength(23), _) -> 1130 
    | (Strength(24), _) -> 1440
    | (Strength(25), _) -> 1750
    | _ -> failwith "Impossible strength" 
    
let openDoors = function
    | (Strength(s), _) when s < 3 -> 1
    | (Strength(3), _) -> 2
    | (Strength(s), _) when s < 6 -> 3
    | (Strength(s), _) when s < 8 -> 4
    | (Strength(s), _) when s < 10 -> 5
    | (Strength(s), _) when s < 12 -> 6
    | (Strength(s), _) when s < 14 -> 7
    | (Strength(s), _) when s < 16 -> 8
    | (Strength(16), _) -> 9 
    | (Strength(17), _) -> 10
    | (Strength(18), 0) -> 11
    | (Strength(18), ex) when ex < 51 -> 12
    | (Strength(18), ex) when ex < 76 -> 14
    | (Strength(18), ex) when ex < 100 -> 15
    | (Strength(18), 100) -> 16
    | (Strength(19), _) -> 16
    | (Strength(s) , _) when s < 22 -> 17
    | (Strength(s), _) when s < 24 -> 18
    | (Strength(s), _) when s < 26 -> 19
    | _ -> failwith "Impossible strength"
    
