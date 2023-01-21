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


            BlueprintFeature Cleric1 = FeatureConfigurator.New(Cleric1Name, Cleric1Guid, FeatureGroup.Feat)
                                           .SetDisplayName(Cleric1DisplayName)
                                           .SetDescription(Cleric1Description)
                                           .SetHideInUI(true)
                                           .SetHideInCharacterSheetAndLevelUp(true)
                                           .SetHideNotAvailibleInUI(true)
                                           .RemoveFromGroups(FeatureGroup.Feat)
                                           .AddSpellbook(1,
                                                         null,
                                                         BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                         SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                           .Configure();

            BlueprintFeature Cleric2 = FeatureConfigurator.New(Cleric2Name, Cleric2Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric2DisplayName)
                                            .SetDescription(Cleric2Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(2,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric3 = FeatureConfigurator.New(Cleric3Name, Cleric3Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric3DisplayName)
                                            .SetDescription(Cleric3Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(3,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric4 = FeatureConfigurator.New(Cleric4Name, Cleric4Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric4DisplayName)
                                            .SetDescription(Cleric4Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(4,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric5 = FeatureConfigurator.New(Cleric5Name, Cleric5Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric5DisplayName)
                                            .SetDescription(Cleric5Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(5,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric6 = FeatureConfigurator.New(Cleric6Name, Cleric6Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric6DisplayName)
                                            .SetDescription(Cleric6Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(6,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric7 = FeatureConfigurator.New(Cleric7Name, Cleric7Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric7DisplayName)
                                            .SetDescription(Cleric7Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(7,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric8 = FeatureConfigurator.New(Cleric8Name, Cleric8Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric8DisplayName)
                                            .SetDescription(Cleric8Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(8,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric9 = FeatureConfigurator.New(Cleric9Name, Cleric9Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric9DisplayName)
                                            .SetDescription(Cleric9Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(9,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric10 = FeatureConfigurator.New(Cleric10Name, Cleric10Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric10DisplayName)
                                            .SetDescription(Cleric10Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(10,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric11 = FeatureConfigurator.New(Cleric11Name, Cleric11Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric11DisplayName)
                                            .SetDescription(Cleric11Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(11,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric12 = FeatureConfigurator.New(Cleric12Name, Cleric12Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric12DisplayName)
                                            .SetDescription(Cleric12Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(12,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric13 = FeatureConfigurator.New(Cleric13Name, Cleric13Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric13DisplayName)
                                            .SetDescription(Cleric13Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(13,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric14 = FeatureConfigurator.New(Cleric14Name, Cleric14Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric14DisplayName)
                                            .SetDescription(Cleric14Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(14,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric15 = FeatureConfigurator.New(Cleric15Name, Cleric15Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric15DisplayName)
                                            .SetDescription(Cleric15Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(15,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric16 = FeatureConfigurator.New(Cleric16Name, Cleric16Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric16DisplayName)
                                            .SetDescription(Cleric16Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(16,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric17 = FeatureConfigurator.New(Cleric17Name, Cleric17Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric17DisplayName)
                                            .SetDescription(Cleric17Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(17,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric18 = FeatureConfigurator.New(Cleric18Name, Cleric18Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric18DisplayName)
                                            .SetDescription(Cleric18Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(18,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric19 = FeatureConfigurator.New(Cleric19Name, Cleric19Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric19DisplayName)
                                            .SetDescription(Cleric19Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(19,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            BlueprintFeature Cleric20 = FeatureConfigurator.New(Cleric20Name, Cleric20Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric20DisplayName)
                                            .SetDescription(Cleric20Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddSpellbook(20,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                            .Configure();

            Main.Logger.Info("in configure {ArchetypeName} Archetype");

            StatType[] RecommendedStats = { StatType.Intelligence, StatType.Wisdom };


            AssaultMageArchetype = ArchetypeConfigurator.New(
                ArchetypeName, ArchtypeGuid, BaseClass)
                .SetLocalizedName(ArchetypeDisplayName)
                .SetLocalizedDescription(ArchetypeDescription)
                .SetIsDivineCaster(true)
                .SetIsArcaneCaster(true)
                .SetChangeCasterType(true)
                .SetReplaceSpellbook(SpellbookRefs.WizardSpellbook.Reference.GetBlueprint())
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
                    FeatureSelectionRefs.DomainsSelection.ToString(),
                    Cleric1
                )
                .AddToAddFeatures(2,
                    FeatureSelectionRefs.WitchFamiliarSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    FeatureRefs.MutagenFeature.ToString(),
                    FeatureRefs.BrewPotions.ToString(),
                    FeatureRefs.UncannyDodgeTalent.ToString(),
                    FeatureRefs.Evasion.ToString(),
                    Cleric2
                )
                .AddToAddFeatures(3,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    Cleric3
                )
                .AddToAddFeatures(4,
                    FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    FeatureRefs.AnimalDomainGreaterFeature.ToString(),
                    Cleric4
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
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    Cleric5
                )
                .AddToAddFeatures(6,
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    Cleric6
                )
                .AddToAddFeatures(7,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.EnlightenedPhilosopherRevelationMentalAcuity.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    Cleric7
                )
                .AddToAddFeatures(8,
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    Cleric8
                )
                .AddToAddFeatures(9,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.TowerShieldSpecialistTouchShield.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    Cleric9
                )
                .AddToAddFeatures(10,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    Cleric10
                )
                .AddToAddFeatures(11,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    Cleric11
                )
                .AddToAddFeatures(12,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    Cleric12
                )
                .AddToAddFeatures(13,
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    Cleric13
                )
                .AddToAddFeatures(14,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    Cleric14
                )
                .AddToAddFeatures(15,
                    FeatureRefs.PersistantMutagen.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    Cleric15
                )
                .AddToAddFeatures(16,
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    Cleric16
                )
                .AddToAddFeatures(17,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    Cleric17
                )
                .AddToAddFeatures(18,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    Cleric18
                )
                .AddToAddFeatures(19,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureRefs.ArmorMastery.ToString(),
                    Cleric19
                )
                .AddToAddFeatures(20,
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.AwakenedIntellect.ToString(),
                    FeatureSelectionRefs.GrandDiscoverySelection.ToString(),
                    FeatureRefs.DamageReduction.ToString(),
                    FeatureRefs.TrueMutagen.ToString(),
                    FeatureSelectionRefs.WeaponMasterySelection.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    Cleric20
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



        public static void ConfigureDisabled()
        {
            AssaultMageArchetype = ArchetypeConfigurator.New(
                 ArchetypeName, ArchtypeGuid, BaseClass).Configure();
        }


    }


}
