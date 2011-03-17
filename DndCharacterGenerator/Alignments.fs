module Alignments

type Legality = 
    | Lawful
    | Neutral
    | Chaotic
    
type Morality = 
    | Good
    | Neutral
    | Evil
    
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