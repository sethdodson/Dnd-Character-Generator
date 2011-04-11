module Alignments

type Legality = 
    | Lawful
    | Neutral
    | Chaotic
    member l.Name = 
        match l with
        | Lawful -> "Lawful"
        | Neutral -> "Neutral"
        | Chaotic -> "Chaotic"    

type Morality = 
    | Good
    | Neutral
    | Evil
    member m.Name = 
        match m with
        | Good -> "Good"
        | Neutral -> "Neutral"
        | Evil -> "Evil"
    
type Alignment = Legality * Morality

let alignments = [ (Lawful, Good); 
                   (Lawful, Neutral);
                   (Lawful, Evil); 
                   (Legality.Neutral, Good); 
                   (Legality.Neutral, Neutral); 
                   (Legality.Neutral, Evil); 
                   (Chaotic, Good); 
                   (Chaotic, Neutral);
                   (Chaotic, Evil); ]