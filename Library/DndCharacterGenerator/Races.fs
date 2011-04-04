module Races

open Stats

type Race = 
    | Human
    | Dwarf 
    | Elf
    | Gnome
    | HalfElf
    | Halfling
    member r.MeetsRequirements = 
        match r with 
        | Human -> (fun _ -> true)
        | Dwarf -> meetsRequirements 
                    { 
                        Strength = (8, 18);
                        Dexterity = (3, 17);
                        Constitution = (11, 18);
                        Intelligence = (3, 18);
                        Wisdom = (3, 18);
                        Charisma = (3, 17)
                    }
        | Elf -> meetsRequirements 
                   {
                       Strength = (3, 18);
                       Dexterity = (6, 18);
                       Constitution = (7, 18);
                       Intelligence = (8, 18);
                       Wisdom = (3, 18);
                       Charisma = (8, 18)
                   }
        | Gnome -> meetsRequirements
                    {
                        Strength = (6, 18);
                        Dexterity = (3, 18);
                        Constitution = (8, 18);
                        Intelligence = (6, 18);
                        Wisdom = (3, 18);
                        Charisma = (3, 18)
                    }
        | HalfElf -> meetsRequirements
                      { 
                        Strength = (3, 18);
                        Dexterity = (6, 18);
                        Constitution = (6, 18);
                        Intelligence = (4, 18);
                        Wisdom = (3, 18);
                        Charisma = (3, 18)
                      }
        | Halfling -> meetsRequirements
                        {
                            Strength = (7, 18);
                            Dexterity = (7, 18);
                            Constitution = (10, 18);
                            Intelligence = (6, 18);
                            Wisdom = (3, 17);
                            Charisma = (3, 18)
                        }
    static member AvailableRaces abilities = 
        [ Human; Dwarf; Elf; Gnome; HalfElf; Halfling ]
        |> List.filter(fun r -> r.MeetsRequirements abilities)     
        
let racialAdjustments (abilities:Abilities) race = 
    match race with
    | Human -> abilities
    | HalfElf -> abilities
    | Dwarf -> { abilities with Constitution = (abilities.Constitution + 1); Charisma = (abilities.Charisma - 1); }
    | Elf -> { abilities with Dexterity = (abilities.Dexterity + 1); Constitution = (abilities.Constitution - 1); }
    | Gnome -> { abilities with Intelligence = (abilities.Intelligence + 1); Wisdom = (abilities.Wisdom - 1); }
    | Halfling -> { abilities with Dexterity = abilities.Dexterity + 1; Strength = abilities.Strength - 1; }            