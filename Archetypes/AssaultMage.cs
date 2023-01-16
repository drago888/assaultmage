using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;
using BlueprintCore.Actions.Builder.ContextEx;
using Newtonsoft.Json;
using System.IO;
using Kingmaker.Blueprints.Classes.Selection;

namespace AssaultMage.Archetypes
{
    class AssaultMage
    {

        private static string ArchetypeName = "AssaultMage";
        internal static string ArchtypeGuid = "0326be98-b3ff-479d-8ef6-eb3c33dd7d20";

        private static string ArchetypeDisplayName = "AssaultMage.Name";
        private static string ArchetypeDescription = "AssaultMage.Description";

        private static string ArchetypeSpellbook = "AssaultMage.Spellbook";
        private static string ArchetypeSpellbookGuid = "d9bb94eb-a924-4726-bc11-f543eb103db6";

        private static readonly string Cleric1Name = "Cleric1";
        private static readonly string Cleric1Guid = "8e829f35-a2a8-4206-b88e-c7a88fdc8eb1";
        private static readonly string Cleric1DisplayName = "Cleric1.Name";
        private static readonly string Cleric1Description = "Cleric1.Description";

        private static readonly string Cleric2Name = "Cleric2";
        private static readonly string Cleric2Guid = "596b459b-bc08-4e3d-845d-c0035e2b80d6";
        private static readonly string Cleric2DisplayName = "Cleric2.Name";
        private static readonly string Cleric2Description = "Cleric2.Description";

        private static readonly string Cleric3Name = "Cleric3";
        private static readonly string Cleric3Guid = "1d1ecba8-81c1-4359-99fa-2b700a75c344";
        private static readonly string Cleric3DisplayName = "Cleric3.Name";
        private static readonly string Cleric3Description = "Cleric3.Description";

        private static readonly string Cleric4Name = "Cleric4";
        private static readonly string Cleric4Guid = "2f899382-0070-4fc3-8f08-6ed4c032f0cb";
        private static readonly string Cleric4DisplayName = "Cleric4.Name";
        private static readonly string Cleric4Description = "Cleric4.Description";

        private static readonly string Cleric5Name = "Cleric5";
        private static readonly string Cleric5Guid = "feac94ba-a08e-4575-8f02-d203367c63d9";
        private static readonly string Cleric5DisplayName = "Cleric5.Name";
        private static readonly string Cleric5Description = "Cleric5.Description";

        private static readonly string Cleric6Name = "Cleric6";
        private static readonly string Cleric6Guid = "d3cb804a-4585-4a92-bfc3-7c191aa6451d";
        private static readonly string Cleric6DisplayName = "Cleric6.Name";
        private static readonly string Cleric6Description = "Cleric6.Description";

        private static readonly string Cleric7Name = "Cleric7";
        private static readonly string Cleric7Guid = "07dd48c5-3049-4606-a7e3-64e5aa6c864d";
        private static readonly string Cleric7DisplayName = "Cleric7.Name";
        private static readonly string Cleric7Description = "Cleric7.Description";

        private static readonly string Cleric8Name = "Cleric8";
        private static readonly string Cleric8Guid = "25f80d37-0888-44ca-8f68-df9b1e4d6bfe";
        private static readonly string Cleric8DisplayName = "Cleric8.Name";
        private static readonly string Cleric8Description = "Cleric8.Description";

        private static readonly string Cleric9Name = "Cleric9";
        private static readonly string Cleric9Guid = "04551f76-6641-4ea4-b493-b0568980d537";
        private static readonly string Cleric9DisplayName = "Cleric9.Name";
        private static readonly string Cleric9Description = "Cleric9.Description";

        private static readonly string Cleric10Name = "Cleric10";
        private static readonly string Cleric10Guid = "8b858d49-1928-44d5-880e-b4487cceb573";
        private static readonly string Cleric10DisplayName = "Cleric10.Name";
        private static readonly string Cleric10Description = "Cleric10.Description";

        private static readonly string Cleric11Name = "Cleric11";
        private static readonly string Cleric11Guid = "42c7dcd1-b5c3-4149-8a27-63c0a714bda9";
        private static readonly string Cleric11DisplayName = "Cleric11.Name";
        private static readonly string Cleric11Description = "Cleric11.Description";

        private static readonly string Cleric12Name = "Cleric12";
        private static readonly string Cleric12Guid = "272e905c-145a-44ee-b2eb-8a0d006cae6d";
        private static readonly string Cleric12DisplayName = "Cleric12.Name";
        private static readonly string Cleric12Description = "Cleric12.Description";

        private static readonly string Cleric13Name = "Cleric13";
        private static readonly string Cleric13Guid = "9a5854b1-a2a8-46d2-932c-c99921b67a15";
        private static readonly string Cleric13DisplayName = "Cleric13.Name";
        private static readonly string Cleric13Description = "Cleric13.Description";

        private static readonly string Cleric14Name = "Cleric14";
        private static readonly string Cleric14Guid = "5afd01a3-2071-4c3e-8afb-64e47dc76e67";
        private static readonly string Cleric14DisplayName = "Cleric14.Name";
        private static readonly string Cleric14Description = "Cleric14.Description";

        private static readonly string Cleric15Name = "Cleric15";
        private static readonly string Cleric15Guid = "40050f34-811d-4d86-875d-1078dcea9327";
        private static readonly string Cleric15DisplayName = "Cleric15.Name";
        private static readonly string Cleric15Description = "Cleric15.Description";

        private static readonly string Cleric16Name = "Cleric16";
        private static readonly string Cleric16Guid = "8d6a0c03-a64d-4b9b-9e11-1152210828f7";
        private static readonly string Cleric16DisplayName = "Cleric16.Name";
        private static readonly string Cleric16Description = "Cleric16.Description";

        private static readonly string Cleric17Name = "Cleric17";
        private static readonly string Cleric17Guid = "3928d7f1-bcc7-4807-8375-4ae9db8b8621";
        private static readonly string Cleric17DisplayName = "Cleric17.Name";
        private static readonly string Cleric17Description = "Cleric17.Description";

        private static readonly string Cleric18Name = "Cleric18";
        private static readonly string Cleric18Guid = "9a6172d5-4579-48c5-9336-902f5f223bf5";
        private static readonly string Cleric18DisplayName = "Cleric18.Name";
        private static readonly string Cleric18Description = "Cleric18.Description";

        private static readonly string Cleric19Name = "Cleric19";
        private static readonly string Cleric19Guid = "ea11f712-fc5a-49ca-8be8-d6b436a87ee0";
        private static readonly string Cleric19DisplayName = "Cleric19.Name";
        private static readonly string Cleric19Description = "Cleric19.Description";

        private static readonly string Cleric20Name = "Cleric20";
        private static readonly string Cleric20Guid = "482e2ca4-fb62-46a5-8277-70ea0314cd93";
        private static readonly string Cleric20DisplayName = "Cleric20.Name";
        private static readonly string Cleric20Description = "Cleric20.Description";

        /*private static readonly string WizardSpellbookSelectionName = "WizardSpellbookSelection";
        private static readonly string WizardSpellbookSelectionGuid = "b5c58d04-67d3-4a79-93aa-998147b54722";
        private static readonly string WizardSpellbookSelectionDisplayName = "WizardSpellbookSelection.DisplayName";
        private static readonly string WizardSpellbookSelectionDescription = "WizardSpellbookSelection.Description";*/


        internal static BlueprintArchetype AssaultMageArchetype;

        internal static SimpleBlueprint BaseClass = CharacterClassRefs.ClericClass.Reference.GetBlueprint();

        public static int AssaultMageLevel = 1;

        public static void Configure()
        {
            if (Main.Enabled)
            {
                ConfigureEnabled();
            }
            else
            {
                // Below is not used
                ConfigureDisabled();
            }
        }

        public static void ConfigureEnabled()
        {
            StatType[] ClassSkills = { 
                StatType.SkillAthletics,
                StatType.SkillMobility,
                StatType.SkillThievery,
                StatType.SkillStealth,
                StatType.SkillKnowledgeArcana,
                StatType.SkillKnowledgeWorld,
                StatType.SkillLoreNature,
                StatType.SkillLoreReligion,
                StatType.SkillPerception,
                StatType.SkillPersuasion,
                StatType.SkillUseMagicDevice
            };
      
                
            Main.Logger.Info("in configure {ArchetypeName} Archetype");

            StatType[] RecommendedStats = { StatType.Intelligence, StatType.Wisdom };


            AssaultMageArchetype = ArchetypeConfigurator.New(
                ArchetypeName, ArchtypeGuid, BaseClass)
                .SetLocalizedName(ArchetypeDisplayName)
                .SetLocalizedDescription(ArchetypeDescription)
                .SetIsDivineCaster(true)
                .SetIsArcaneCaster(true)
                .SetChangeCasterType(true)
                //.SetReplaceSpellbook(CreateSpellbook())
                .SetFortitudeSave(CharacterClassRefs.MonkClass.Reference.Get().FortitudeSave)
                .SetWillSave(CharacterClassRefs.WizardClass.Reference.Get().WillSave)
                .SetReflexSave(CharacterClassRefs.MonkClass.Reference.Get().ReflexSave)
                .SetBaseAttackBonus(CharacterClassRefs.FighterClass.Reference.Get().BaseAttackBonus)
                .AddToClassSkills(ClassSkills)
                .SetReplaceClassSkills(true)
                .AddPrerequisiteMainCharacter(true, false, GroupType.All, false)
                .ClearStartingItems()
                .AddToStartingItems(
                    ItemArmorRefs.FullplateStandard.Reference.GetBlueprint(),
                    ItemEquipmentUsableRefs.ScrollOfMageArmor.Reference.GetBlueprint(),
                    ItemEquipmentUsableRefs.ScrollOfMageShield.Reference.GetBlueprint(),
                    ItemEquipmentUsableRefs.ScrollOfMagicMissile.Reference.GetBlueprint(),
                    ItemEquipmentUsableRefs.ScrollOfExpeditiousRetreat.Reference.GetBlueprint(),
                    ItemEquipmentUsableRefs.ScrollOfHurricaneBow.Reference.GetBlueprint()
                )
                .SetReplaceStartingEquipment(true)
                .SetRecommendedAttributes(RecommendedStats)
                .SetOverrideAttributeRecommendations(true)
                .SetAddSkillPoints(4)
                .Configure();
            
            ArchetypeConfigurator.For(AssaultMageArchetype)
                .AddToAddFeatures(1,
                    FeatureRefs.FullCasterFeature.ToString(),
                    FeatureRefs.FighterProficiencies.ToString(),
                    FeatureRefs.BardProficiencies.ToString(),
                    FeatureRefs.WitchHexIceplantFeature.ToString(),
                    FeatureRefs.ArcaneArmorTraining.ToString(),
                    FeatureRefs.ArcaneArmorMastery.ToString(),
                    Feats.ArmorAttune.ArmorAttuneFeat,
                    Feats.SuperDodge.SuperDodgeFeat,
                    FeatureSelectionRefs.SorcererBloodlineSelection.ToString(),
                    FeatureSelectionRefs.SorcererBloodlineSelection.ToString(),
                    FeatureSelectionRefs.SorcererBloodlineSelection.ToString(),
                    FeatureSelectionRefs.SorcererBloodlineSelection.ToString(),
                    FeatureRefs.CraneStyleFeat.ToString(),
                    FeatureRefs.CautiousFighter.ToString(),
                    FeatureRefs.StudentOfWarMindOverMetal.ToString(),
                    FeatureRefs.DefensiveStanceFeature.ToString(),
                    FeatureRefs.Toughness.ToString(),
                    FeatureRefs.Dodge.ToString(),
                    FeatureRefs.StalwartDefenderACBonus.ToString(),
                    FeatureRefs.WizardArcaneBond.ToString(),
                    FeatureRefs.ScribingScrolls.ToString(),
                    FeatureRefs.CombatExpertiseFeature.ToString(),
                    FeatureSelectionRefs.DeitySelection.ToString(),
                    FeatureSelectionRefs.DomainsSelection.ToString(),
                    FeatureSelectionRefs.DomainsSelection.ToString(),
                    FeatureSelectionRefs.DomainsSelection.ToString()
                )
                .AddToAddFeatures(2,
                    FeatureSelectionRefs.WitchFamiliarSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    FeatureRefs.MutagenFeature.ToString(),
                    FeatureRefs.BrewPotions.ToString(),
                    FeatureRefs.UncannyDodgeTalent.ToString(),
                    FeatureRefs.Evasion.ToString()
                )
                .AddToAddFeatures(3,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString()
                )
                .AddToAddFeatures(4,
                    FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    FeatureRefs.AnimalDomainGreaterFeature.ToString()
                )
                .AddToAddFeatures(5,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.PurityOfBody.ToString(),
                    FeatureRefs.ImprovedEvasion.ToString(),
                    FeatureRefs.ImprovedUncannyDodgeTalent.ToString(),
                    FeatureRefs.TowerShieldNegatePenalty.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString()
                )
                .AddToAddFeatures(6,
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.DamageReduction.ToString()
                )
                .AddToAddFeatures(7,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.EnlightenedPhilosopherRevelationMentalAcuity.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString()
                )
                .AddToAddFeatures(8,
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.DamageReduction.ToString()
                )
                .AddToAddFeatures(9,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.TowerShieldSpecialistTouchShield.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString()
                )
                .AddToAddFeatures(10,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString()
                )
                .AddToAddFeatures(11,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString()
                )
                .AddToAddFeatures(12,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.DamageReduction.ToString()
                )
                .AddToAddFeatures(13,
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString()
                )
                .AddToAddFeatures(14,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.DamageReduction.ToString()
                )
                .AddToAddFeatures(15,
                    FeatureRefs.PersistantMutagen.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString()
                )
                .AddToAddFeatures(16,
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.DamageReduction.ToString()
                )
                .AddToAddFeatures(17,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString()
                )
                .AddToAddFeatures(18,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.DamageReduction.ToString()
                )
                .AddToAddFeatures(19,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureRefs.ArmorMastery.ToString()
                )
                .AddToAddFeatures(20,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.AwakenedIntellect.ToString(),
                    FeatureSelectionRefs.GrandDiscoverySelection.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    FeatureRefs.TrueMutagen.ToString(),
                    FeatureSelectionRefs.WeaponMasterySelection.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString()
                )
                .Configure();
                

            FeatureConfigurator.For(Feats.ArmorAttune.ArmorAttuneFeat)
                .SetReapplyOnLevelUp(true)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, 1)
                .Configure();

            FeatureConfigurator.For(Feats.SuperDodge.SuperDodgeFeat)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, 1)
                .Configure();

        }


        private static BlueprintSpellbook CreateSpellbook()
        {
            BlueprintSpellbook AssaultMageSpellbook;

            AssaultMageSpellbook = SpellbookConfigurator.New(ArchetypeSpellbook, ArchetypeSpellbookGuid)
                .CopyFrom(SpellbookRefs.WizardSpellbook.Reference.GetBlueprint())
                .Configure();

            return AssaultMageSpellbook;
        }
        public static void ConfigureDisabled()
        {
            AssaultMageArchetype = ArchetypeConfigurator.New(
                 ArchetypeName, ArchtypeGuid, BaseClass).Configure();
        }


    }


}
