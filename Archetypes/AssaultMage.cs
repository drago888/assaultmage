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
//using Newtonsoft.Json;
using System.IO;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Localization;

namespace AssaultMage.Archetypes
{
    /*public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var serialized = JsonConvert.SerializeObject(self);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }*/

    class AssaultMage
    {

        private static string ArchetypeName = "AssaultMage";
        internal static string ArchtypeGuid = "0326be98-b3ff-479d-8ef6-eb3c33dd7d20";

        private static string ArchetypeDisplayName = "AssaultMage.Name";
        private static string ArchetypeDescription = "AssaultMage.Description";

        private static string ArchetypeSpellbook = "AssaultMage.Spellbook";
        internal static string ArchetypeSpellbookGuid = "d9bb94eb-a924-4726-bc11-f543eb103db6";

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

        private static readonly string AssaultMageSpellListName = "AssaultMageSpellList";
        private static readonly string AssaultMageSpellListGuid = "b14d9fae-8e68-441c-921c-8b8bd50d9622";

        private static readonly string AssaultMageSpellTableName = "AssaultMageSpellTable";
        private static readonly string AssaultMageSpellTableGuid = "3139d063-29f8-458d-a617-b8f3c8512fa1";

        internal static BlueprintSpellbook AssaultMageSpellbook;
        internal static BlueprintSpellList AssaultMageSpellList;
        internal static BlueprintSpellsTable AssaultMageSpellTable;

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

            //Main.Logger.Info("in configure {ArchetypeName} Archetype");

            StatType[] RecommendedStats = { StatType.Intelligence };
            List<Blueprint<BlueprintArchetypeReference>> FakeArchetypes = new List<Blueprint<BlueprintArchetypeReference>>();
            FakeArchetypes.Add(ArchetypeRefs.SwordSaintArchetype.Cast<BlueprintArchetypeReference>().Reference);
            FakeArchetypes.Add(ArchetypeRefs.VivisectionistArchetype.Cast<BlueprintArchetypeReference>().Reference);
            FakeArchetypes.Add(ArchetypeRefs.BrownFurTransmuterArchetype.Cast<BlueprintArchetypeReference>().Reference);
            FakeArchetypes.Add(ArchetypeRefs.ArchaeologistArchetype.Cast<BlueprintArchetypeReference>().Reference);
            FakeArchetypes.Add(ArchetypeRefs.TowerShieldSpecialistArchetype.Cast<BlueprintArchetypeReference>().Reference);
            FakeArchetypes.Add(ArchetypeRefs.TraditionalMonk.Cast<BlueprintArchetypeReference>().Reference);
            FakeArchetypes.Add(ArchetypeRefs.EnlightenedPhilosopherArchetype.Cast<BlueprintArchetypeReference>().Reference);
            FakeArchetypes.Add(ArchetypeRefs.ThugArchetype.Cast<BlueprintArchetypeReference>().Reference);
            FakeArchetypes.Add(ArchetypeRefs.CrossbloodedArchetype.Cast<BlueprintArchetypeReference>().Reference);
            FakeArchetypes.Add(ArchetypeRefs.HexChannelerWitchArchetype.Cast<BlueprintArchetypeReference>().Reference);
            FakeArchetypes.Add(ArchetypeRefs.SpellMasterArchetype.Cast<BlueprintArchetypeReference>().Reference);
            FakeArchetypes.Add(ArchetypeRefs.InvulnerableRagerArchetype.Cast<BlueprintArchetypeReference>().Reference);
            FakeArchetypes.Add(ArchetypeRefs.CrusaderArchetype.Cast<BlueprintArchetypeReference>().Reference);

            BlueprintFeature Cleric1 = FeatureConfigurator.New(Cleric1Name, Cleric1Guid, FeatureGroup.Feat)
                                           .SetDisplayName(Cleric1DisplayName)
                                           .SetDescription(Cleric1Description)
                                           .SetHideInUI(true)
                                           .SetHideInCharacterSheetAndLevelUp(true)
                                           .SetHideNotAvailibleInUI(true)
                                           .RemoveFromGroups(FeatureGroup.Feat)
                                           .AddChangeHitDie(Kingmaker.RuleSystem.DiceType.D12)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.FighterClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.MonkClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.WizardClass.Reference.GetBlueprint(), null,1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.RogueClass.Reference.GetBlueprint(), null,1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.ClericClass.Reference.GetBlueprint(), null,1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.DruidClass.Reference.GetBlueprint(), null,1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.MagusClass.Reference.GetBlueprint(), null, 1)
                                           .AddConditionImmunity(Kingmaker.UnitLogic.UnitCondition.DevouredBySwarm)
                                           .AddClassLevels(FakeArchetypes, null, false, 1)
                                           .AddImmunityToAbilityScoreDamage()
                                           /*.AddSpellbook(1, 
                                                         null, 
                                                         BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip, 
                                                         SpellbookRefs.ClericSpellbook.Reference.Get())*/
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
                                            .AddClassLevels(FakeArchetypes, null, false, 2)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 3)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 4)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 5)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 6)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 7)
                                            .Configure();

            BlueprintFeature Cleric8 = FeatureConfigurator.New(Cleric8Name, Cleric8Guid, FeatureGroup.Feat)
                                           .SetDisplayName(Cleric1DisplayName)
                                           .SetDescription(Cleric1Description)
                                           .SetHideInUI(true)
                                           .SetHideInCharacterSheetAndLevelUp(true)
                                           .SetHideNotAvailibleInUI(true)
                                           .RemoveFromGroups(FeatureGroup.Feat)
                                           .AddSpellbook(8,
                                                          null,
                                                          BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,
                                                          SpellbookRefs.ClericSpellbook.Reference.GetBlueprint())
                                           .AddClassLevels(FakeArchetypes, null, false, 8)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 9)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 10)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 11)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 12)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 13)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 14)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 15)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 16)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 17)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 18)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 19)
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
                                            .AddClassLevels(FakeArchetypes, null, false, 20)
                                            .Configure();




            AssaultMageArchetype = ArchetypeConfigurator.New(
                ArchetypeName, ArchtypeGuid, BaseClass)
                .SetLocalizedName(ArchetypeDisplayName)
                .SetLocalizedDescription(ArchetypeDescription)
                .SetIsDivineCaster(true)
                .SetIsArcaneCaster(true)
                .SetChangeCasterType(true)
                .SetReplaceSpellbook(CreateSpellbook())
                //.SetReplaceSpellbook(SpellbookRefs.WizardSpellbook.Reference.Get())
                .SetFortitudeSave(CharacterClassRefs.MonkClass.Reference.Get().FortitudeSave)
                .SetWillSave(CharacterClassRefs.WizardClass.Reference.Get().WillSave)
                .SetReflexSave(CharacterClassRefs.MonkClass.Reference.Get().ReflexSave)
                .SetBaseAttackBonus(CharacterClassRefs.FighterClass.Reference.Get().BaseAttackBonus)
                .AddToClassSkills(ClassSkills)
                .SetReplaceClassSkills(true)
                .AddPrerequisiteMainCharacter(true, false, GroupType.All, false)
                .ClearStartingItems()
                .AddToStartingItems(
                    ItemArmorRefs.FullplateStandard.Reference.Get(),
                    ItemEquipmentUsableRefs.ScrollOfMageArmor.Reference.Get(),
                    ItemEquipmentUsableRefs.ScrollOfMageShield.Reference.Get(),
                    ItemEquipmentUsableRefs.ScrollOfMagicMissile.Reference.Get(),
                    ItemEquipmentUsableRefs.ScrollOfExpeditiousRetreat.Reference.Get(),
                    ItemEquipmentUsableRefs.ScrollOfHurricaneBow.Reference.Get()
                )
                .SetReplaceStartingEquipment(true)
                .SetRecommendedAttributes(RecommendedStats)
                .SetOverrideAttributeRecommendations(true)
                .SetAddSkillPoints(4)
                .Configure();
            
            ArchetypeConfigurator.For(AssaultMageArchetype)
                .AddToAddFeatures(1,
                    FeatureRefs.TricksterStatFocusAC.ToString(),
                    FeatureRefs.TricksterStatFocusAttack.ToString(),
                    FeatureRefs.TricksterStatFocusSaveFortitude.ToString(),
                    FeatureRefs.TricksterStatFocusSaveReflex.ToString(),
                    FeatureRefs.TricksterStatFocusSaveWill.ToString(),
                    FeatureRefs.TricksterStatFocusHP.ToString(),
                    FeatureRefs.TricksterStatFocusDamage.ToString(),
                    FeatureRefs.TricksterStatFocusSpeed.ToString(),
                    FeatureRefs.TricksterStatFocusInitiative.ToString(),
                    FeatureRefs.TricksterKnowledgeArcanaTier1Feature.ToString(),
                    FeatureRefs.TricksterKnowledgeArcanaTier2Feature.ToString(),
                    FeatureRefs.TricksterKnowledgeArcanaTier3Feature.ToString(),
                    FeatureRefs.TricksterLoreNature1Feature.ToString(),
                    FeatureRefs.TricksterLoreNature2Feature.ToString(),
                    FeatureRefs.TricksterLoreNature3Feature.ToString(),
                    FeatureRefs.TricksterStealthTier1Feature.ToString(),
                    FeatureRefs.TricksterStealthTier2Feature.ToString(),
                    FeatureRefs.TricksterStealthTier3Feature.ToString(),
                    /*FeatureRefs.TricksterAthleticsTier1Feature.ToString(),
                    FeatureRefs.TricksterAthleticsTier2Feature.ToString(),
                    FeatureRefs.TricksterAthleticsTier3Feature.ToString(),
                    FeatureRefs.TricksterKnowledgeWorldTier1Feature.ToString(),
                    FeatureRefs.TricksterKnowledgeWorldTier2Feature.ToString(),
                    FeatureRefs.TricksterKnowledgeWorldTier3Feature.ToString(),
                    FeatureRefs.TricksterMobilityTier1Feature.ToString(),
                    FeatureRefs.TricksterMobilityTier2Feature.ToString(),
                    FeatureRefs.TricksterMobilityTier3Feature.ToString(),
                    FeatureRefs.TricksterPerceptionTier1Feature.ToString(),
                    FeatureRefs.TricksterPerceptionTier2Feature.ToString(),
                    //FeatureRefs.TricksterPerceptionTier3Feature.ToString(),
                    FeatureRefs.TricksterLoreReligionTier1Feature.ToString(),
                    /*FeatureRefs.TricksterLoreReligionNobilityDomainFeature.ToString(),
                    FeatureRefs.TricksterLoreReligionNobilityDomainRankFeature.ToString(),
                    FeatureRefs.TricksterLoreReligionMadnessDomainFeature.ToString(),
                    FeatureRefs.TricksterLoreReligionMadnessDomainRankFeature.ToString(),
                    FeatureRefs.TricksterLoreReligionCommunityDomainFeature.ToString(),
                    FeatureRefs.TricksterLoreReligionCommunityDomainRankFeature.ToString(),
                    FeatureRefs.TricksterLoreReligionAnimalDomainFeature.ToString(),
                    FeatureRefs.TricksterLoreReligionAnimalDomainRankFeature.ToString(),
                    FeatureRefs.TricksterLoreReligionLuckDomainFeature.ToString(),
                    FeatureRefs.TricksterLoreReligionLuckDomainRankFeature.ToString(),*/
                    FeatureRefs.FullCasterFeature.ToString(),
                    FeatureRefs.FighterProficiencies.ToString(),
                    FeatureRefs.BardProficiencies.ToString(),
                    FeatureRefs.WitchHexIceplantFeature.ToString(),
                    FeatureRefs.ArcaneArmorTraining.ToString(),
                    FeatureRefs.ArcaneArmorMastery.ToString(),
                    Feats.ArmorAttune.ArmorAttuneFeat,
                    //Feats.SuperDodge.SuperDodgeFeat,
                    Feats.SuperDodge.ShiftingProjectionFeat,
                    //FeatureRefs.SwordSaintCannyDefense.ToString(),
                    //FeatureRefs.SwordSaintFighterTraining.ToString(),
                    //FeatureRefs.SwordSaintWeaponMastery.ToString(),
                    //FeatureRefs.SwordSaintPerfectStrikeFeature.ToString(),
                    /*FeatureSelectionRefs.SorcererBloodlineSelection.ToString(),
                    FeatureSelectionRefs.SorcererBloodlineSelection.ToString(),
                    FeatureSelectionRefs.SorcererBloodlineSelection.ToString(),
                    FeatureSelectionRefs.SorcererBloodlineSelection.ToString(),*/
                    FeatureRefs.CautiousFighter.ToString(),
                    //FeatureRefs.DefensiveStanceFeature.ToString(),
                    FeatureRefs.Toughness.ToString(),
                    //FeatureRefs.StalwartDefenderACBonus.ToString(),
                    FeatureRefs.ItemBondFeature.ToString(),
                    //FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    FeatureRefs.UniversalistSchoolBaseFeature.ToString(),
                    //FeatureSelectionRefs.ArcaneBondSelection.ToString(),
                    //FeatureSelectionRefs.SpecialistSchoolSelection.ToString(),
                    FeatureRefs.ScribingScrolls.ToString(),
                    //FeatureSelectionRefs.DeitySelection.ToString(),
                    //FeatureSelectionRefs.DomainsSelection.ToString(),
                    //FeatureSelectionRefs.DomainsSelection.ToString(),
                    //FeatureSelectionRefs.DomainsSelection.ToString(),
                    FeatureRefs.ThugFrightening.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    //FeatureRefs.ShieldBashFeature.ToString(),
                    //FeatureRefs.ClericSpontaneousCure.ToString(),
                    /*FeatureRefs.ErastilFeature.ToString(),
                    FeatureRefs.CommunityDomainAllowed.ToString(),
                    FeatureRefs.CommunityDomainBaseFeature.ToString(),
                    FeatureRefs.CommunityDomainSpellListFeature.ToString(),
                    FeatureRefs.AnimalDomainAllowed.ToString(),
                    FeatureRefs.AnimalDomainBaseFeature.ToString(),
                    FeatureRefs.AnimalDomainSpellListFeature.ToString(),
                    //FeatureRefs.CommunityBlessingFeature.ToString(),
                    FeatureRefs.AbadarFeature.ToString(),
                    FeatureRefs.NobilityDomainAllowed.ToString(),
                    FeatureRefs.NobilityDomainBaseFeature.ToString(),
                    FeatureRefs.NobilityDomainSpellListFeature.ToString(),*/
                    /*FeatureRefs.NobilityDomainAllowed.ToString(),
                    FeatureRefs.CommunityDomainAllowed.ToString(),
                    FeatureRefs.MadnessDomainAllowed.ToString(),
                    FeatureRefs.AnimalDomainAllowed.ToString(),
                    FeatureRefs.LuckDomainAllowed.ToString(),
                    FeatureRefs.TrickeryDomainAllowed.ToString(),*/
                    FeatureRefs.BloodlineDraconicBronzeArcana.ToString(),
                    FeatureRefs.BloodlineDraconicCopperArcana.ToString(),
                    FeatureRefs.BloodlineDraconicGoldArcana.ToString(),
                    FeatureRefs.BloodlineDraconicSilverArcana.ToString(),
                    FeatureRefs.BloodlineArcaneArcana.ToString(),
                    FeatureRefs.ArcanistArcaneReservoirFeature.ToString(),
                    FeatureRefs.ImmunityToNauseated.ToString(),
                    FeatureRefs.ImmunityToCharm.ToString(),
                    FeatureRefs.ImmunityToCompulsion.ToString(),
                    FeatureRefs.ImmunityToConfusion.ToString(),
                    FeatureRefs.ImmunityToFear.ToString(),
                    FeatureRefs.ImmunityToMindAffecting.ToString(),
                    FeatureRefs.TripImmunityFeature.ToString(),
                    FeatureRefs.ImmunityToParalysis.ToString(),
                    FeatureRefs.ImmunityToPetrification.ToString(),
                    FeatureRefs.ImmunityToSleep.ToString(),
                    FeatureRefs.ImmunityToStun.ToString(),
                    //FeatureRefs.TwoWeaponFighting.ToString(),
                    //FeatureRefs.BloodlineCelestialAscensionAbility.ToString(),
                    //FeatureRefs.BloodlineAbyssalDemonicMight.ToString(),
                    //FeatureRefs.BloodlineDraconicGoldPowerOfWyrms.ToString(),
                    //FeatureRefs.ArcanePoolFeature.ToString(),
                    //FeatureRefs.MissileShield.ToString(),
                    FeatureRefs.ShieldFocus.ToString(),
                    FeatureRefs.ShieldFocusGreater.ToString(),
                    FeatureRefs.ShieldMaster.ToString(),
                    //FeatureRefs.RayShield.ToString(),
                    //FeatureRefs.ShieldFocusMythicFeat.ToString(),
                    FeatureRefs.ArmorFocusHeavy.ToString(),
                    FeatureRefs.Dodge.ToString(),
                    //FeatureRefs.DodgeMythicFeat.ToString(),
                    FeatureRefs.GreatFortitude.ToString(),
                    FeatureRefs.GreatFortitudeImproved.ToString(),
                    //FeatureRefs.GreatFortitudeMythicFeat.ToString(),
                    FeatureRefs.LightningReflexes.ToString(),
                    FeatureRefs.LightningReflexesImproved.ToString(),
                    //FeatureRefs.LightningReflexesMythicFeat.ToString(),
                    FeatureRefs.IronWill.ToString(),
                    FeatureRefs.IronWillImproved.ToString(),
                    //FeatureRefs.IronWillMythicFeat.ToString(),
                    FeatureRefs.Ironguts.ToString(),
                    FeatureRefs.BlindFight.ToString(),
                    FeatureRefs.BlindFightImproved.ToString(),
                    FeatureRefs.BlindFightGreater.ToString(),
                    FeatureRefs.CombatCasting.ToString(),
                    FeatureRefs.CriticalFocus.ToString(),
                    FeatureRefs.CriticalMastery.ToString(),
                    FeatureRefs.FastLearner.ToString(),
                    FeatureRefs.Ironhide.ToString(),
                    FeatureRefs.PenetratingStrike.ToString(),
                    FeatureRefs.GreaterPenetratingStrike.ToString(),
                    FeatureRefs.SpellPenetration.ToString(),
                    FeatureRefs.GreaterSpellPenetration.ToString(),
                    //FeatureRefs.DragonDiscipleNaturalArmor.ToString(),
                    //FeatureRefs.DragonDiscipleNaturalArmor.ToString(),
                    //FeatureRefs.DragonDiscipleNaturalArmor.ToString(),
                    //FeatureRefs.BloodlineDraconicGoldResistancesAbilityLevel1.ToString(),
                    //FeatureRefs.BloodlineDraconicGoldResistancesAbilityLevel2.ToString(),
                    //FeatureRefs.BloodlineDraconicGoldResistancesAbilityLevel3.ToString(),
                    //FeatureRefs.BloodlineDraconicGoldResistancesAbilityAddLevel1.ToString(),
                    //FeatureRefs.BloodlineDraconicGoldResistancesAbilityAddLevel2.ToString(),
                    /*FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),*/
                    FeatureRefs.CraneStyleFeat.ToString(),
                    FeatureRefs.CraneStyleRiposteFeat.ToString(),
                    FeatureRefs.CombatExpertiseFeature.ToString(),
                    FeatureRefs.CombatReflexes.ToString(),
                    FeatureRefs.MutagenFeature.ToString(),
                    FeatureRefs.BolsteredSpellFeat.ToString(),
                    FeatureRefs.EmpowerSpellFeat.ToString(),
                    FeatureRefs.ExtendSpellFeat.ToString(),
                    FeatureRefs.HeightenSpellFeat.ToString(),
                    FeatureRefs.MaximizeSpellFeat.ToString(),
                    FeatureRefs.PersistentSpellFeat.ToString(),
                    FeatureRefs.QuickenSpellFeat.ToString(),
                    FeatureRefs.CompletelyNormalSpellFeat.ToString(),
                    FeatureRefs.ReachSpellFeat.ToString(),
                    FeatureRefs.SelectiveSpellFeat.ToString(),
                    FeatureRefs.ElementalFocusAcid.ToString(),
                    FeatureRefs.GreaterElementalFocusAcid.ToString(),
                    FeatureRefs.ElementalFocusCold.ToString(),
                    FeatureRefs.GreaterElementalFocusCold.ToString(),
                    FeatureRefs.ElementalFocusElectricity.ToString(),
                    FeatureRefs.GreaterElementalFocusElectricity.ToString(),
                    FeatureRefs.ElementalFocusFire.ToString(),
                    FeatureRefs.GreaterElementalFocusFire.ToString(),
                    FeatureRefs.ArcanePoolFeature.ToString(),
                    FeatureRefs.ArcaneWeaponEnchancementMountFeature.ToString(),
                    FeatureSelectionRefs.DeitySelection.ToString(),
                    FeatureSelectionRefs.DomainsSelection.ToString(),
                    FeatureSelectionRefs.DomainsSelection.ToString(),
                    FeatureSelectionRefs.DomainsSelection.ToString(),
                    FeatureSelectionRefs.SwordSaintChosenWeaponSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    /*FeatureRefs.SpellFocusAbjuration.ToString(),
                    FeatureRefs.GreaterSpellFocusAbjuration.ToString(),
                    FeatureRefs.SpellFocusConjuration.ToString(),
                    FeatureRefs.GreaterSpellFocusConjuration.ToString(),
                    FeatureRefs.SpellFocusDivination.ToString(),
                    FeatureRefs.GreaterSpellFocusDivination.ToString(),
                    FeatureRefs.SpellFocusEnchanctment.ToString(),
                    FeatureRefs.GreaterSpellFocusDivination.ToString(),
                    FeatureRefs.SpellFocusEvocation.ToString(),
                    FeatureRefs.GreaterSpellFocusEvocation.ToString(),
                    FeatureRefs.SpellFocusIllusion.ToString(),
                    FeatureRefs.GreaterSpellFocusIllusion.ToString(),
                    FeatureRefs.SpellFocusNecromancy.ToString(),
                    FeatureRefs.GreaterSpellFocusNecromancy.ToString(),
                    FeatureRefs.SpellFocusTransmutation.ToString(),
                    FeatureRefs.GreaterSpellFocusTransmutation.ToString(),*/
                    //FeatureRefs.TwoWeaponFighting.ToString(),
                    //FeatureRefs.TwoWeaponFightingImproved.ToString(),
                    //FeatureRefs.TwoWeaponFightingGreater.ToString(),
                    //FeatureRefs.TwoWeaponFightingMythicFeat.ToString(),
                    /*FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),*/
                    //FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    //FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    //FeatureSelectionRefs.MythicFeatSelection.ToString(),
                    FeatureSelectionRefs.WitchFamiliarSelection.ToString(),
                    Cleric1
                )
                .AddToAddFeatures(2,
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.BrewPotions.ToString(),
                    //FeatureRefs.UncannyDodgeTalent.ToString(),
                    FeatureRefs.Evasion.ToString(),
                    FeatureRefs.UncannyDodge.ToString(),
                    FeatureRefs.ArmoredHulkArmoredSwiftness.ToString(),
                    FeatureRefs.StudentOfWarMindOverMetal.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric2
                )
                .AddToAddFeatures(3,
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.PowerfulChange.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric3
                )
                .AddToAddFeatures(4,
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.SwordSaintPerfectStrikeFeature.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    FeatureSelectionRefs.MythicFeatSelection.ToString()
                //FeatureRefs.AnimalDomainGreaterFeature.ToString(),
                //FeatureSelectionRefs.AnimalCompanionSelectionDomain.ToString()
                //Cleric4
                )
                .AddToAddFeatures(5,
                    FeatureRefs.PurityOfBody.ToString(),
                    FeatureRefs.ImprovedEvasion.ToString(),
                    //FeatureRefs.ImprovedUncannyDodgeTalent.ToString(),
                    FeatureRefs.ImprovedUncannyDodge.ToString(),
                    FeatureRefs.ArmoredHulkImprovedArmoredSwiftness.ToString(),
                    //FeatureRefs.TowerShieldNegatePenalty.ToString(),
                    //FeatureRefs.ArmorTraining.ToString(),
                    //FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    FeatureRefs.ArcaneWeaponPlus2.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString()
                    //FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                    //FeatureRefs.ArcaneWeaponPlus2.ToString(),
                    //FeatureRefs.ArcaneArmorEnchantPlus2.ToString()
                //Cleric5
                )
                .AddToAddFeatures(6,
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.MythicFeatSelection.ToString()
                    //Cleric6
                )
                .AddToAddFeatures(7,
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    //FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.EnlightenedPhilosopherRevelationMentalAcuity.ToString(),
                    FeatureRefs.SwordSaintLightningDraw.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.ExtraRogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                    //Cleric7
                )
                .AddToAddFeatures(8,
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    FeatureRefs.UniversalistSchoolExtendReachFeature.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.MythicFeatSelection.ToString()
                    //FeatureRefs.CommunityDomainGreaterFeature.ToString(),
                    //FeatureRefs.CommunityBlessingMajorFeature.ToString(),
                    //FeatureRefs.NobilityDomainGreaterFeature.ToString(),
                    //FeatureRefs.NobilityBlessingMajorFeature.ToString()
                    //Cleric8
                )
                .AddToAddFeatures(9,
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    //FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.TowerShieldSpecialistTouchShield.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.SwordSaintCriticalPerfection.ToString(),
                    //FeatureRefs.TowerShieldTraining.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.ShareTransmutation.ToString(),
                    FeatureRefs.ArcaneWeaponPlus3.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                    //FeatureRefs.ArcaneWeaponPlus3.ToString(),
                    //FeatureRefs.ArcaneArmorEnchantPlus3.ToString()
                    //Cleric9
                )
                .AddToAddFeatures(10,
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.EnlightenedPhilosopherRevelationMentalAcuity.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    FeatureSelectionRefs.ExtraRogueTalentSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric10
                )
                .AddToAddFeatures(11,
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.SwordSaintSuperiorReflexes.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.ExtraRogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric11
                )
                .AddToAddFeatures(12,
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.UniversalistSchoolEmpowerFeature.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric12
                )
                .AddToAddFeatures(13,
                    FeatureRefs.EnlightenedPhilosopherRevelationMentalAcuity.ToString(),
                    FeatureRefs.ArcaneWeaponPlus4.ToString(),
                    FeatureRefs.SwordSaintInstantFocus.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureRefs.TowerShieldTotalCover.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //FeatureRefs.ArcaneWeaponPlus4.ToString(),
                //FeatureRefs.ArcaneArmorEnchantPlus4.ToString()
                //Cleric13
                )
                .AddToAddFeatures(14,
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.PersistantMutagen.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric14
                )
                .AddToAddFeatures(15,
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    FeatureRefs.FeatureWingsAngelSorcerer.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric15
                )
                .AddToAddFeatures(16,
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.EnlightenedPhilosopherRevelationMentalAcuity.ToString(),
                    FeatureRefs.Counterstrike.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.UniversalistSchoolMaximizeFeature.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric16
                )
                .AddToAddFeatures(17,
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    //FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureRefs.ArcaneWeaponPlus5.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //FeatureRefs.ArcaneWeaponPlus5.ToString(),
                //FeatureRefs.ArcaneArmorEnchantPlus5.ToString()
                //Cleric17
                )
                .AddToAddFeatures(18,
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric18
                )
                .AddToAddFeatures(19,
                    FeatureRefs.EnlightenedPhilosopherRevelationMentalAcuity.ToString(),
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureRefs.ArmorMastery.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.SwordSaintPerfectReflexes.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric19
                )
                .AddToAddFeatures(20,
                    FeatureRefs.AwakenedIntellect.ToString(),
                    FeatureSelectionRefs.GrandDiscoverySelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.TrueMutagen.ToString(),
                    FeatureSelectionRefs.WeaponMasterySelection.ToString(),
                    FeatureRefs.MasterStrike.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    //FeatureRefs.BloodlineDraconicBronzePowerOfWyrms.ToString(),
                    //FeatureRefs.BloodlineDraconicCopperPowerOfWyrms.ToString(),
                    //FeatureRefs.BloodlineDraconicGoldPowerOfWyrms.ToString(),
                    //FeatureRefs.BloodlineDraconicSilverPowerOfWyrms.ToString(),
                    //FeatureRefs.BloodlineCelestialAscensionAbility.ToString(),
                    FeatureRefs.BloodlineCelestialAscensionAbility.ToString(),
                    FeatureRefs.BloodlineAbyssalDemonicMight.ToString(),
                    FeatureRefs.BloodlineDraconicGoldPowerOfWyrms.ToString(),
                    FeatureRefs.UniversalistSchoolQuickenFeature.ToString(),
                    FeatureRefs.TransmutationSupremacy.ToString(),
                    FeatureRefs.SwordSaintWeaponMastery.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric20
                )
                .Configure();
                

            FeatureConfigurator.For(Feats.ArmorAttune.ArmorAttuneFeat)
                .SetReapplyOnLevelUp(true)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, null, 1)
                .Configure();

            FeatureConfigurator.For(Feats.SuperDodge.SuperDodgeFeat)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, null,1)
                .Configure();

            FeatureConfigurator.For(Feats.SuperDodge.ShiftingProjectionFeat)
                .SetReapplyOnLevelUp(true)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, null,1)
                .Configure();
        }

        private static void SetSpellList()
        {
            BlueprintSpellbook WizardSpellbook = (BlueprintSpellbook)SpellbookRefs.WizardSpellbook.Reference.Get();
            BlueprintSpellList WizardSpellList = WizardSpellbook.SpellList;

            BlueprintSpellbook ClericSpellbook = (BlueprintSpellbook)SpellbookRefs.ClericSpellbook.Reference.Get();
            BlueprintSpellsTable ClericSpellSlots = SpellsTableRefs.ClericSpellLevels.Reference.Get();
            BlueprintSpellList ClericSpellList = ClericSpellbook.SpellList;



            SpellLevelList zeroLevelSpells = new SpellLevelList(0)
            {
                m_Spells =
                WizardSpellList.GetSpells(0)
                  .Select(s => s.ToReference<BlueprintAbilityReference>())
                  .ToList()
            };

            zeroLevelSpells.m_Spells.AddRange(
                ClericSpellList.GetSpells(0)
                    .Except(WizardSpellList.GetSpells(0))
                    .Select(s => s.ToReference<BlueprintAbilityReference>())
            );

            SpellLevelList firstLevelSpells = new SpellLevelList(1)
            {
                m_Spells =
                WizardSpellList.GetSpells(1)
                  .Select(s => s.ToReference<BlueprintAbilityReference>())
                  .ToList()
            };

            firstLevelSpells.m_Spells.AddRange(
                ClericSpellList.GetSpells(1)
                    .Except(WizardSpellList.GetSpells(1))
                    .Except(WizardSpellList.GetSpells(2))
                    .Except(WizardSpellList.GetSpells(3))
                    .Except(WizardSpellList.GetSpells(4))
                    .Except(WizardSpellList.GetSpells(5))
                    .Except(WizardSpellList.GetSpells(6))
                    .Except(WizardSpellList.GetSpells(7))
                    .Except(WizardSpellList.GetSpells(8))
                    .Except(WizardSpellList.GetSpells(9))
                    .Except(WizardSpellList.GetSpells(10))
                    .Select(s => s.ToReference<BlueprintAbilityReference>())
            );

            SpellLevelList secondLevelSpells = new SpellLevelList(2)
            {
                m_Spells =
                WizardSpellList.GetSpells(2)
                  .Select(s => s.ToReference<BlueprintAbilityReference>())
                  .ToList()
            };

            secondLevelSpells.m_Spells.AddRange(
                ClericSpellList.GetSpells(2)
                    .Except(WizardSpellList.GetSpells(1))
                    .Except(WizardSpellList.GetSpells(2))
                    .Except(WizardSpellList.GetSpells(3))
                    .Except(WizardSpellList.GetSpells(4))
                    .Except(WizardSpellList.GetSpells(5))
                    .Except(WizardSpellList.GetSpells(6))
                    .Except(WizardSpellList.GetSpells(7))
                    .Except(WizardSpellList.GetSpells(8))
                    .Except(WizardSpellList.GetSpells(9))
                    .Except(WizardSpellList.GetSpells(10))
                    .Select(s => s.ToReference<BlueprintAbilityReference>())
            );

            SpellLevelList thirdLevelSpells = new SpellLevelList(3)
            {
                m_Spells =
                WizardSpellList.GetSpells(3)
                  .Select(s => s.ToReference<BlueprintAbilityReference>())
                  .ToList()
            };

            thirdLevelSpells.m_Spells.AddRange(
                ClericSpellList.GetSpells(3)
                    .Except(WizardSpellList.GetSpells(1))
                    .Except(WizardSpellList.GetSpells(2))
                    .Except(WizardSpellList.GetSpells(3))
                    .Except(WizardSpellList.GetSpells(4))
                    .Except(WizardSpellList.GetSpells(5))
                    .Except(WizardSpellList.GetSpells(6))
                    .Except(WizardSpellList.GetSpells(7))
                    .Except(WizardSpellList.GetSpells(8))
                    .Except(WizardSpellList.GetSpells(9))
                    .Except(WizardSpellList.GetSpells(10))
                    .Select(s => s.ToReference<BlueprintAbilityReference>())
            );

            SpellLevelList fourthLevelSpells = new SpellLevelList(4)
            {
                m_Spells =
                WizardSpellList.GetSpells(4)
                  .Select(s => s.ToReference<BlueprintAbilityReference>())
                  .ToList()
            };

            fourthLevelSpells.m_Spells.AddRange(
                ClericSpellList.GetSpells(4)
                    .Except(WizardSpellList.GetSpells(1))
                    .Except(WizardSpellList.GetSpells(2))
                    .Except(WizardSpellList.GetSpells(3))
                    .Except(WizardSpellList.GetSpells(4))
                    .Except(WizardSpellList.GetSpells(5))
                    .Except(WizardSpellList.GetSpells(6))
                    .Except(WizardSpellList.GetSpells(7))
                    .Except(WizardSpellList.GetSpells(8))
                    .Except(WizardSpellList.GetSpells(9))
                    .Except(WizardSpellList.GetSpells(10))
                    .Select(s => s.ToReference<BlueprintAbilityReference>())
            );

            SpellLevelList fifthLevelSpells = new SpellLevelList(5)
            {
                m_Spells =
                WizardSpellList.GetSpells(5)
                  .Select(s => s.ToReference<BlueprintAbilityReference>())
                  .ToList()
            };

            fifthLevelSpells.m_Spells.AddRange(
                ClericSpellList.GetSpells(5)
                    .Except(WizardSpellList.GetSpells(1))
                    .Except(WizardSpellList.GetSpells(2))
                    .Except(WizardSpellList.GetSpells(3))
                    .Except(WizardSpellList.GetSpells(4))
                    .Except(WizardSpellList.GetSpells(5))
                    .Except(WizardSpellList.GetSpells(6))
                    .Except(WizardSpellList.GetSpells(7))
                    .Except(WizardSpellList.GetSpells(8))
                    .Except(WizardSpellList.GetSpells(9))
                    .Except(WizardSpellList.GetSpells(10))
                    .Select(s => s.ToReference<BlueprintAbilityReference>())
            );

            SpellLevelList sixthLevelSpells = new SpellLevelList(6)
            {
                m_Spells =
                WizardSpellList.GetSpells(6)
                  .Select(s => s.ToReference<BlueprintAbilityReference>())
                  .ToList()
            };

            sixthLevelSpells.m_Spells.AddRange(
                ClericSpellList.GetSpells(6)
                    .Except(WizardSpellList.GetSpells(1))
                    .Except(WizardSpellList.GetSpells(2))
                    .Except(WizardSpellList.GetSpells(3))
                    .Except(WizardSpellList.GetSpells(4))
                    .Except(WizardSpellList.GetSpells(5))
                    .Except(WizardSpellList.GetSpells(6))
                    .Except(WizardSpellList.GetSpells(7))
                    .Except(WizardSpellList.GetSpells(8))
                    .Except(WizardSpellList.GetSpells(9))
                    .Except(WizardSpellList.GetSpells(10))
                    .Select(s => s.ToReference<BlueprintAbilityReference>())
            );

            SpellLevelList seventhLevelSpells = new SpellLevelList(7)
            {
                m_Spells =
                WizardSpellList.GetSpells(7)
                  .Select(s => s.ToReference<BlueprintAbilityReference>())
                  .ToList()
            };

            seventhLevelSpells.m_Spells.AddRange(
                ClericSpellList.GetSpells(7)
                    .Except(WizardSpellList.GetSpells(1))
                    .Except(WizardSpellList.GetSpells(2))
                    .Except(WizardSpellList.GetSpells(3))
                    .Except(WizardSpellList.GetSpells(4))
                    .Except(WizardSpellList.GetSpells(5))
                    .Except(WizardSpellList.GetSpells(6))
                    .Except(WizardSpellList.GetSpells(7))
                    .Except(WizardSpellList.GetSpells(8))
                    .Except(WizardSpellList.GetSpells(9))
                    .Except(WizardSpellList.GetSpells(10))
                    .Select(s => s.ToReference<BlueprintAbilityReference>())
            );

            SpellLevelList eighthLevelSpells = new SpellLevelList(8)
            {
                m_Spells =
                WizardSpellList.GetSpells(8)
                  .Select(s => s.ToReference<BlueprintAbilityReference>())
                  .ToList()
            };

            eighthLevelSpells.m_Spells.AddRange(
                ClericSpellList.GetSpells(8)
                    .Except(WizardSpellList.GetSpells(1))
                    .Except(WizardSpellList.GetSpells(2))
                    .Except(WizardSpellList.GetSpells(3))
                    .Except(WizardSpellList.GetSpells(4))
                    .Except(WizardSpellList.GetSpells(5))
                    .Except(WizardSpellList.GetSpells(6))
                    .Except(WizardSpellList.GetSpells(7))
                    .Except(WizardSpellList.GetSpells(8))
                    .Except(WizardSpellList.GetSpells(9))
                    .Except(WizardSpellList.GetSpells(10))
                    .Select(s => s.ToReference<BlueprintAbilityReference>())
            );

            SpellLevelList ninthLevelSpells = new SpellLevelList(9)
            {
                m_Spells =
                WizardSpellList.GetSpells(9)
                  .Select(s => s.ToReference<BlueprintAbilityReference>())
                  .ToList()
            };

            ninthLevelSpells.m_Spells.AddRange(
                ClericSpellList.GetSpells(9)
                    .Except(WizardSpellList.GetSpells(1))
                    .Except(WizardSpellList.GetSpells(2))
                    .Except(WizardSpellList.GetSpells(3))
                    .Except(WizardSpellList.GetSpells(4))
                    .Except(WizardSpellList.GetSpells(5))
                    .Except(WizardSpellList.GetSpells(6))
                    .Except(WizardSpellList.GetSpells(7))
                    .Except(WizardSpellList.GetSpells(8))
                    .Except(WizardSpellList.GetSpells(9))
                    .Except(WizardSpellList.GetSpells(10))
                    .Select(s => s.ToReference<BlueprintAbilityReference>())
            );

            SpellLevelList tenthLevelSpells = new SpellLevelList(10)
            {
                m_Spells =
                WizardSpellList.GetSpells(10)
                  .Select(s => s.ToReference<BlueprintAbilityReference>())
                  .ToList()
            };

            tenthLevelSpells.m_Spells.AddRange(
                ClericSpellList.GetSpells(10)
                    .Except(WizardSpellList.GetSpells(1))
                    .Except(WizardSpellList.GetSpells(2))
                    .Except(WizardSpellList.GetSpells(3))
                    .Except(WizardSpellList.GetSpells(4))
                    .Except(WizardSpellList.GetSpells(5))
                    .Except(WizardSpellList.GetSpells(6))
                    .Except(WizardSpellList.GetSpells(7))
                    .Except(WizardSpellList.GetSpells(8))
                    .Except(WizardSpellList.GetSpells(9))
                    .Except(WizardSpellList.GetSpells(10))
                    .Select(s => s.ToReference<BlueprintAbilityReference>())
            );

            AssaultMageSpellList = SpellListConfigurator.New(AssaultMageSpellListName, AssaultMageSpellListGuid)
                .AddToSpellsByLevel(
                    zeroLevelSpells,
                    firstLevelSpells,
                    secondLevelSpells,
                    thirdLevelSpells,
                    fourthLevelSpells,
                    fifthLevelSpells,
                    sixthLevelSpells,
                    seventhLevelSpells,
                    eighthLevelSpells,
                    ninthLevelSpells,
                    tenthLevelSpells
                 )
                .Configure();
        }

        private static void SetSpellSlots()
        {
            SpellsLevelEntry[] entries = new SpellsLevelEntry[] { 
                new SpellsLevelEntry(),
                // 1
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        2
                    }
                },
                // 2
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        4
                    }
                },
                // 3
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        4,
                        2
                    }
                },
                // 4
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        6,
                        4
                    }
                },
                // 5
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        6,
                        4,
                        2
                    }
                },
                // 6
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        6,
                        6,
                        4
                    }
                },
                // 7
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        6,
                        4,
                        2
                    }
                },
                // 8
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        6,
                        6,
                        4
                    }
                },
                // 9
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        8,
                        6,
                        4,
                        2
                    }
                },
                // 10
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        8,
                        6,
                        6,
                        4
                    }
                },
                // 11
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        8,
                        8,
                        6,
                        4,
                        2
                    }
                },
                // 12
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        8,
                        8,
                        6,
                        6,
                        4
                    }
                },
                // 13
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        8,
                        8,
                        8,
                        6,
                        4,
                        2
                    }
                },
                // 14
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        8,
                        8,
                        8,
                        6,
                        6,
                        4
                    }
                },
                // 15
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        8,
                        8,
                        8,
                        8,
                        6,
                        4,
                        2
                    }
                },
                // 16
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        8,
                        8,
                        8,
                        8,
                        6,
                        6,
                        4
                    }
                },
                // 17
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        6,
                        4,
                        2
                    }
                },
                // 18
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        6,
                        6,
                        4
                    }
                },
                // 19
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        6,
                        6
                    }
                },
                // 20
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 21
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 22
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 23
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 24
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 25
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 26
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 27
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 28
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 29
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 30
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 31
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 32
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 33
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 34
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 35
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 36
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 37
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 38
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 39
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        10,
                        10,
                        10,
                        8,
                        8,
                        8,
                        8
                    }
                },
                // 40
                new SpellsLevelEntry() {
                    Count = new int[]
                    {
                        0,
                        10,
                        10,
                        10,
                        10,
                        10,
                        10,
                        8,
                        8,
                        8
                    }
                }
            };


            AssaultMageSpellTable = SpellsTableConfigurator.New(AssaultMageSpellTableName, AssaultMageSpellTableGuid)
                .CopyFrom(SpellsTableRefs.InquisitorSpellsKnownTable)
                .SetLevels(entries)
                .Configure();

            Main.Logger.Info("After AssaultMageSpellTable");

            for (int i=0; i<AssaultMageSpellTable.Levels.Length; ++i)
            {
                Main.Logger.Info("Spell Table level " + i);
                for(int j=0; j<AssaultMageSpellTable.Levels[i].Count.Length; ++j)
                {
                    Main.Logger.Info("Spell count " + j + " value " + AssaultMageSpellTable.Levels[i].Count[j]);
                }
            }
        }

        private static BlueprintSpellbook CreateSpellbook()
        {
            BlueprintSpellbook WizardSpellbook = (BlueprintSpellbook)SpellbookRefs.WizardSpellbook.Reference.Get();
            BlueprintSpellbook ClericSpellbook = (BlueprintSpellbook)SpellbookRefs.ClericSpellbook.Reference.Get();

            SetSpellList();
            SetSpellSlots();

            AssaultMageSpellbook = SpellbookConfigurator.New(ArchetypeSpellbook, ArchetypeSpellbookGuid)
                .CopyFrom(WizardSpellbook)
                .SetName(ArchetypeDisplayName)
                //.SetCantripsType(CantripsType.Orisions)
                .SetCantripsType(CantripsType.Cantrips)
                .SetSpellList(AssaultMageSpellList)
                .SetSpellsPerDay(AssaultMageSpellTable)
                .SetHasSpecialSpellList()
                //.SetSpellSlots(AssaultMageSpellTable)
                .SetAllSpellsKnown(false)
                .SetCanCopyScrolls(true)
                .SetCastingAttribute(StatType.Intelligence)
                .SetIsArcane(true)
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
