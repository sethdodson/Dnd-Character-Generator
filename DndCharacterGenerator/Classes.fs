module Classes

open Stats
open Races
open Alignments

type Specialization = 
    | Mage
    | Abjurer
    | Conjurer
    | Diviner
    | Enchanter
    | Illusionist
    | Invoker
    | Necromancer
    | Transmuter

type CharacterClass = 
    | Fighter 
    | Paladin
    | Ranger
    | Wizard of Specialization
    | Cleric
    | Druid
    | Thief
    | Bard    
    member cc.Minimums = 
        match cc with
        | Fighter -> [ Strength(9) ]
        | Paladin -> [ Strength(12); Constitution(9); Wisdom(13); Charisma(17); ]
        | Ranger -> [ Strength(13); Dexterity(13); Constitution(14); Wisdom(14); ]
        | Wizard(Mage) -> [ Intelligence(9); ]
        | Wizard(Abjurer) -> [ Intelligence(9); Wisdom(15); ]
        | Wizard(Conjurer) -> [ Intelligence(9); Constitution(15); ]
        | Wizard(Diviner) -> [ Intelligence(9); Wisdom(16); ]
        | Wizard(Enchanter) -> [ Intelligence(9); Charisma(16); ]
        | Wizard(Illusionist) -> [ Intelligence(9); Dexterity(16); ]
        | Wizard(Invoker) -> [ Intelligence(9); Constitution(16); ]
        | Wizard(Necromancer) -> [ Intelligence(9); Wisdom(16); ]
        | Wizard(Transmuter) -> [ Intelligence(9); Dexterity(15); ]
        | Cleric -> [ Wisdom(9); ]
        | Druid -> [ Wisdom(12); Charisma(15); ]
        | Thief -> [ Dexterity(9); ]
        | Bard -> [ Dexterity(12); Intelligence(13); Charisma(15); ]        
    member cc.MeetsMinimums (abilities:Abilities) = 
        cc.Minimums |> List.forall(fun min -> match min with
                                              | Strength(s) -> abilities.Strength.Stat >= s
                                              | Dexterity(d) -> abilities.Dexterity.Stat >= d
                                              | Constitution(c) -> abilities.Dexterity.Stat >= c
                                              | Intelligence(i) -> abilities.Intelligence.Stat >= i
                                              | Wisdom(w) -> abilities.Wisdom.Stat >= w
                                              | Charisma(c) -> abilities.Charisma.Stat >= c)  
    member cc.PrimeRequisites =     
        match cc with
        | Fighter -> [ Strength; ]
        | Paladin -> [ Strength; Charisma; ]
        | Ranger -> [ Strength; Dexterity; Wisdom; ]
        | Wizard(_) -> [ Intelligence; ]
        | Cleric -> [ Wisdom; ]
        | Druid -> [ Wisdom; Charisma; ]
        | Thief -> [ Dexterity; ]
        | Bard -> [ Dexterity; Charisma; ]        
    member cc.AvailableAlignments = 
        match cc with
        | Fighter -> alignments
        | Paladin -> [ (Lawful, Good); ]
        | Ranger -> [ (Lawful, Good); (Legality.Neutral, Good); (Chaotic, Good); ]
        | Wizard(_) -> alignments
        | Cleric -> alignments
        | Druid -> [ (Legality.Neutral, Neutral); ]
        | Thief -> alignments |> List.filter(fun al -> ((fst al) <> Lawful) || ((snd al) <> Good))
        | Bard -> alignments |> List.filter(fun al -> ((fst al) = Legality.Neutral) || (snd al) = Neutral)
    static member AvailableClasses race abilities = 
        let meetsRequirements = List.filter(fun (c:CharacterClass) -> c.MeetsMinimums abilities)
        match race with 
        | Human -> meetsRequirements [ Fighter; 
                                       Paladin; 
                                       Ranger; 
                                       Wizard(Mage); 
                                       Wizard(Abjurer); 
                                       Wizard(Conjurer); 
                                       Wizard(Diviner); 
                                       Wizard(Enchanter); 
                                       Wizard(Illusionist); 
                                       Wizard(Invoker);
                                       Wizard(Necromancer);
                                       Wizard(Transmuter);
                                       Cleric;
                                       Druid;
                                       Thief;
                                       Bard; ]
        | Dwarf -> meetsRequirements [ Fighter; Cleric; Thief; ]
        | Elf -> meetsRequirements [ Fighter; Ranger; Wizard(Mage); Wizard(Diviner); Wizard(Enchanter); Cleric; Thief; ]
        | Gnome -> meetsRequirements [ Fighter; Wizard(Illusionist); Cleric; Thief; ]
        | HalfElf -> meetsRequirements [ Fighter; 
                                         Ranger; 
                                         Wizard(Mage); 
                                         Wizard(Conjurer); 
                                         Wizard(Diviner); 
                                         Wizard(Enchanter);
                                         Wizard(Transmuter);
                                         Cleric;
                                         Druid;
                                         Thief;
                                         Bard; ]
        | Halfling -> meetsRequirements [ Fighter; Cleric; Thief; ]
        
let (|Warrior|Thaumaturge|Rogue|Priest|) = function
    | Fighter -> Warrior
    | Paladin -> Warrior
    | Ranger -> Warrior
    | Wizard(_) -> Thaumaturge
    | Cleric -> Priest
    | Druid -> Priest
    | Thief -> Rogue
    | Bard -> Rogue