module CharacterGenerator

open Stats
open Dice
open Races         
open Alignments
open Classes          
open System 
open Aging
open BasicPhysical   
open StrengthTable
open DexterityTable
open ConstitutionTable
open IntelligenceTable
open WisdomTable   
open CharismaTable                  
open ExperienceLevels
open ClassAbilities

type CharacterModel = 
    { 
        Legality: Legality
        Morality: Morality
        Race: Race
        Class: CharacterClass
        Level: int
        Abilities: Abilities        
        ExceptionalStrength: int        
        Sex: Sex
        Age: int
        Height: Height
        Weight: int
        HitProbability: int
        DamageAdjustment: int
        WeightAllow: int        
        MaxPress: int   
        OpenDoors: int
        OpenHardenedDoors: int
        BendBars: int
        DexReactionAdjustment: int
        MissileAttackAdjustment: int
        DefensiveAdjustment: int
        HitPointAdjustment: int
        SystemShock: int
        ResurrectionSurvival: int
        PoisonSaveBonus: int
        Regeneration: (int * int) option
        NumberOfLanguages: int
        MaxSpellLevel: int option
        ChanceToLearnSpell: int option
        MaxNumberOfSpellsPerLevel: SpellLimit
        IllusionImmunity: int option
        MagicalDefenseAdjustment: int
        BonusPriestSpells: int list
        ChanceOfSpellFailure: int  
        MaximumNumberOfHenchmen: int           
        LoyaltyBase: int                      
        CharismaReactionAdjustment: int           
        HitPoints: int
        SpellImmunity: string list
    }      
                                                                   
let getCharacter level = 
    let abilities = rollAbilityScores()
    let availableRaces = Race.AvailableRaces abilities
    let race = List.nth availableRaces (random.Next(0, availableRaces.Length))
    let age = startingAge race
    let adjustedAbilities = agingEffects (racialAdjustments abilities race) (race, age)
    let chosenClass = 
        let prerequisiteValue (cc:CharacterClass) = 
            cc.Minimums 
            |> List.map(fun min -> match min with
                                   | Strength(s) -> adjustedAbilities.Strength.Stat - s + 1
                                   | Dexterity(d) -> adjustedAbilities.Dexterity.Stat - d + 1
                                   | Constitution(c) -> adjustedAbilities.Constitution.Stat - c + 1
                                   | Intelligence(i) -> adjustedAbilities.Intelligence.Stat - i + 1
                                   | Wisdom(w) -> adjustedAbilities.Wisdom.Stat - w + 1
                                   | Charisma(c) -> adjustedAbilities.Charisma.Stat - c + 1)            
            |> List.sum
        let (|PrestigeClass|MundaneClass|) = function
               | Wizard(Mage) -> MundaneClass
               | Wizard(_) -> PrestigeClass
               | Paladin -> PrestigeClass
               | Ranger -> PrestigeClass
               | Bard -> PrestigeClass
               | _ -> MundaneClass
        let getClassValue ccp1 ccp2 = 
            match (ccp1, ccp2) with
            | ((_, prereq1), (_, prereq2)) when prereq1 > prereq2 -> 1
            | ((_, prereq1), (_, prereq2)) when prereq1 < prereq2 -> -1
            | ((PrestigeClass, _), (MundaneClass, _)) -> 1
            | ((MundaneClass, _), (PrestigeClass, _)) -> -1
            | _ -> 0
        let classesByValue = 
            (CharacterClass.AvailableClasses race)
            >> List.map(fun cc -> (cc, (prerequisiteValue cc)))
            >> List.sortWith(getClassValue)
        adjustedAbilities |> classesByValue |> List.rev |> List.head |> fst
    let alignment = List.nth chosenClass.AvailableAlignments (random.Next(0, chosenClass.AvailableAlignments.Length))
    let sex = 
        let coin = (random.Next(0, 1))
        if coin = 0 then Male else Female
    let charHeight = (Height.GetHeight (race, sex))
    let charWeight = (weight (race, sex))
    let hitPointBonus = hitPointAdjustment (adjustedAbilities.Constitution, chosenClass)
    let charExceptionalStrength = exceptionalStrength (chosenClass, adjustedAbilities.Strength, race)            
    { 
        Legality = (fst alignment)
        Morality = (snd alignment)
        Race = race
        Class = chosenClass
        Level = level
        Abilities = adjustedAbilities
        ExceptionalStrength = charExceptionalStrength
        Sex = sex
        Age = age
        Height = charHeight
        Weight = charWeight
        HitProbability = hitProbability (adjustedAbilities.Strength, charExceptionalStrength)      
        DamageAdjustment = damageAdjustment (adjustedAbilities.Strength, charExceptionalStrength)
        WeightAllow = weightAllow(adjustedAbilities.Strength, charExceptionalStrength)
        MaxPress = maxPress (adjustedAbilities.Strength, charExceptionalStrength)
        OpenDoors = openDoors (adjustedAbilities.Strength, charExceptionalStrength)
        OpenHardenedDoors = openHardenedDoors (adjustedAbilities.Strength, charExceptionalStrength)
        BendBars = bendBars (adjustedAbilities.Strength, charExceptionalStrength)
        DexReactionAdjustment = dexReactionAdjustment (adjustedAbilities.Dexterity)
        MissileAttackAdjustment = missileAttackAdjustment (adjustedAbilities.Dexterity)
        DefensiveAdjustment = defensiveAdjustment (adjustedAbilities.Dexterity)
        HitPointAdjustment = hitPointBonus
        SystemShock = systemShock (adjustedAbilities.Constitution)
        ResurrectionSurvival = resurrectionSurvival (adjustedAbilities.Constitution)
        PoisonSaveBonus = poisonSaveBonus(adjustedAbilities.Constitution)
        Regeneration = regeneration adjustedAbilities.Constitution
        NumberOfLanguages = numberOfLanguages(adjustedAbilities.Intelligence)
        MaxSpellLevel = maxSpellLevel (chosenClass, adjustedAbilities.Intelligence)
        ChanceToLearnSpell = chanceToLearnSpell (chosenClass, adjustedAbilities.Intelligence)
        MaxNumberOfSpellsPerLevel = maxNumberOfSpellsPerLevel (chosenClass, adjustedAbilities.Intelligence)
        IllusionImmunity = illusionImmunity (adjustedAbilities.Intelligence)
        MagicalDefenseAdjustment = magicalDefenseAdjustment (adjustedAbilities.Wisdom)
        BonusPriestSpells = bonusSpells adjustedAbilities.Wisdom
        ChanceOfSpellFailure = chanceOfSpellFailure (adjustedAbilities.Wisdom)
        MaximumNumberOfHenchmen = maximumNumberOfHenchmen (adjustedAbilities.Charisma)
        LoyaltyBase = loyaltyBase adjustedAbilities.Charisma     
        CharismaReactionAdjustment = charismaReactionAdjustment adjustedAbilities.Charisma   
        HitPoints = hitPoints (chosenClass, level, hitPointBonus)
        SpellImmunity = spellImmunity adjustedAbilities.Wisdom
    }
