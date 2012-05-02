module Magic

type School = 
    | Illusion
    | Enchantment
    | Conjuration
    | Abjuration
    | Necromancy
    | Invocation
    | GreaterDivination
    | Alteration
    
type Sphere = string

type SpellRange = 
    | Self
    | Touch
    | Distance of int
    
type SpellComponent = 
    | Verbal
    | Somatic
    | Material of string
    
type SpellDuration = 
    | RoundsPerLevel of int
    | Variable of (unit -> int)

type WizardSpell = 
    { Name: string
      School: School
      Range: SpellRange
      Components: SpellComponent list
      Duration: SpellDuration
      Level: int }
                      