﻿using System;
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
using Kingmaker.PubSubSystem;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.UpgraderEx;
using Kingmaker.UnitLogic;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UI.MVVM._VM.ServiceWindows.CharacterInfo.Sections.Progression.Main;
using AssaultMage.Feats;

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

            List<Blueprint<BlueprintCharacterClassReference>> FakeClasses = new List<Blueprint<BlueprintCharacterClassReference>>();
            FakeClasses.Add(CharacterClassRefs.MagusClass.Cast<BlueprintCharacterClassReference>().Reference);
            FakeClasses.Add(CharacterClassRefs.AlchemistClass.Cast<BlueprintCharacterClassReference>().Reference);
            FakeClasses.Add(CharacterClassRefs.ArcanistClass.Cast<BlueprintCharacterClassReference>().Reference);
            FakeClasses.Add(CharacterClassRefs.BardClass.Cast<BlueprintCharacterClassReference>().Reference);
            FakeClasses.Add(CharacterClassRefs.FighterClass.Cast<BlueprintCharacterClassReference>().Reference);
            FakeClasses.Add(CharacterClassRefs.MonkClass.Cast<BlueprintCharacterClassReference>().Reference);
            FakeClasses.Add(CharacterClassRefs.OracleClass.Cast<BlueprintCharacterClassReference>().Reference);
            FakeClasses.Add(CharacterClassRefs.RogueClass.Cast<BlueprintCharacterClassReference>().Reference);
            FakeClasses.Add(CharacterClassRefs.SorcererClass.Cast<BlueprintCharacterClassReference>().Reference);
            FakeClasses.Add(CharacterClassRefs.WitchClass.Cast<BlueprintCharacterClassReference>().Reference);
            FakeClasses.Add(CharacterClassRefs.WizardClass.Cast<BlueprintCharacterClassReference>().Reference);
            FakeClasses.Add(CharacterClassRefs.BarbarianClass.Cast<BlueprintCharacterClassReference>().Reference);
            FakeClasses.Add(CharacterClassRefs.ClericClass.Cast<BlueprintCharacterClassReference>().Reference);

            BlueprintFeature Cleric1 = FeatureConfigurator.New(Cleric1Name, Cleric1Guid, FeatureGroup.Feat)
                                           .SetDisplayName(Cleric1DisplayName)
                                           .SetDescription(Cleric1Description)
                                           .SetHideInUI(true)
                                           .SetHideInCharacterSheetAndLevelUp(true)
                                           .SetHideNotAvailibleInUI(true)
                                           .RemoveFromGroups(FeatureGroup.Feat)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.AlchemistClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.ArcanistClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.BarbarianClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.BardClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.BloodragerClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.CavalierClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.ClericClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.DruidClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.FighterClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.HunterClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.InquisitorClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.KineticistClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.MagusClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.MonkClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.OracleClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.PaladinClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.RangerClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.RogueClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.ShamanClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.ShifterClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.SorcererClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.WarpriestClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.WitchClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.WizardClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.AeonMythicClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.AngelMythicClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.AzataMythicClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.DemonMythicClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.DevilMythicClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.GoldenDragonClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.LichMythicClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.LegendClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.TricksterMythicClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.SwarmThatWalksClass.Reference.GetBlueprint(), null, 1)
                                           .AddReplaceStatForPrerequisites(StatType.Intelligence, StatType.Strength)
                                           .AddReplaceStatForPrerequisites(StatType.Intelligence, StatType.Dexterity)
                                           .AddReplaceStatForPrerequisites(StatType.Intelligence, StatType.Constitution)
                                           .AddReplaceStatForPrerequisites(StatType.Intelligence, StatType.Wisdom)
                                           .AddReplaceStatForPrerequisites(StatType.Intelligence, StatType.Charisma)
                                           //.AddConditionImmunity(Kingmaker.UnitLogic.UnitCondition.DevouredBySwarm)
                                           //.AddClassLevels(FakeArchetypes, BaseClass, false, 1)
                                           .AddImmunityToAbilityScoreDamage()
                                           /*.AddSpellbook(1, 
                                                         null, 
                                                         BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip, 
                                                         SpellbookRefs.ClericSpellbook.Reference.Get())*/
                                           .Configure();

            BlueprintFeature HD = FeatureConfigurator.New(Cleric2Name, Cleric2Guid, FeatureGroup.Feat)
                                            .SetDisplayName(Cleric1DisplayName)
                                            .SetDescription(Cleric1Description)
                                            .SetHideInUI(true)
                                            .SetHideInCharacterSheetAndLevelUp(true)
                                            .SetHideNotAvailibleInUI(true)
                                            .RemoveFromGroups(FeatureGroup.Feat)
                                            .AddChangeHitDie(Kingmaker.RuleSystem.DiceType.D12)
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
                    //ItemArmorRefs.FullplateStandard.Reference.Get(),
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
                    HD,
                    /*FeatureRefs.TricksterStatFocusAC.ToString(),
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
                    FeatureRefs.TricksterStealthTier3Feature.ToString(),*/
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
                    FeatureRefs.TowerShieldProficiency.ToString(),
                    FeatureRefs.ArcaneWeaponEnchancementMountFeature.ToString(),
                    FeatureRefs.WitchHexIceplantFeature.ToString(),
                    //FeatureRefs.ArcaneArmorTraining.ToString(),
                    //FeatureRefs.ArcaneArmorMastery.ToString(),
                    //Feats.ArmorAttune.ArmorAttuneFeat,
                    FeatureRefs.ArmoredBattlemageMediumArmor.ToString(),
                    FeatureRefs.ItemBondFeature.ToString(),
                    //FeatureRefs.ArcaneHeavyArmor.ToString(),
                    Feats.SuperDodge.SuperDodgeFeat,
                    Feats.SuperDodge.ShiftingProjectionFeat,
                    FeatureRefs.SwordSaintCannyDefense.ToString(),
                    FeatureRefs.MonkACBonusUnlock.ToString(),
                    FeatureRefs.BloodragerFastMovement.ToString(),
                    FeatureRefs.ArcaneAccuracyFeature.ToString(),
                    //FeatureRefs.MagicalHackFeature.ToString(), 
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
                    //FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    FeatureRefs.UniversalistSchoolBaseFeature.ToString(),
                    //FeatureSelectionRefs.ArcaneBondSelection.ToString(),
                    //FeatureSelectionRefs.SpecialistSchoolSelection.ToString(),
                    FeatureRefs.ScribingScrolls.ToString(),
                    FeatureRefs.ThugFrightening.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    /*FeatureRefs.BloodlineDraconicBronzeArcana.ToString(),
                    FeatureRefs.BloodlineDraconicCopperArcana.ToString(),
                    FeatureRefs.BloodlineDraconicGoldArcana.ToString(),
                    FeatureRefs.BloodlineDraconicSilverArcana.ToString(),
                    FeatureRefs.BloodlineArcaneArcana.ToString(),*/
                    //FeatureRefs.BloodlineElementalWaterArcana.ToString(),
                    FeatureRefs.ArcanistArcaneReservoirFeature.ToString(),
                    /*FeatureRefs.ImmunityToNauseated.ToString(),
                    FeatureRefs.ImmunityToCharm.ToString(),
                    FeatureRefs.ImmunityToCompulsion.ToString(),
                    FeatureRefs.ImmunityToConfusion.ToString(),
                    FeatureRefs.ImmunityToFear.ToString(),
                    FeatureRefs.ImmunityToMindAffecting.ToString(),
                    FeatureRefs.TripImmunityFeature.ToString(),
                    FeatureRefs.ImmunityToParalysis.ToString(),
                    FeatureRefs.ImmunityToPetrification.ToString(),
                    FeatureRefs.ImmunityToSleep.ToString(),
                    FeatureRefs.ImmunityToStun.ToString(),*/
                    //FeatureRefs.CavalierAnimalCompanion.ToString(),
                    FeatureSelectionRefs.CavalierMountSelection.ToString(),
                    FeatureRefs.CompanionBoon.ToString(),
                    //FeatureRefs.TwoWeaponFighting.ToString(),
                    //FeatureRefs.BloodlineCelestialAscensionAbility.ToString(),
                    //FeatureRefs.BloodlineAbyssalDemonicMight.ToString(),
                    //FeatureRefs.BloodlineDraconicGoldPowerOfWyrms.ToString(),
                    //FeatureRefs.ArcanePoolFeature.ToString(),
                    //FeatureRefs.MissileShield.ToString(),
                    FeatureRefs.ShieldFocus.ToString(),
                    FeatureRefs.ShieldFocusGreater.ToString(),
                    FeatureRefs.ShieldMaster.ToString(),
                    FeatureRefs.MountedCombat.ToString(),
                    FeatureRefs.MountedShield.ToString(),
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
                    //FeatureRefs.CompletelyNormalSpellFeat.ToString(),
                    FeatureRefs.ReachSpellFeat.ToString(),
                    FeatureRefs.SelectiveSpellFeat.ToString(),
                    FeatureRefs.IntensifiedSpell.ToString(),
                    FeatureRefs.PiercingSpell.ToString(),
                    FeatureRefs.ElementalFocusAcid.ToString(),
                    FeatureRefs.GreaterElementalFocusAcid.ToString(),
                    FeatureRefs.ElementalFocusCold.ToString(),
                    FeatureRefs.GreaterElementalFocusCold.ToString(),
                    FeatureRefs.ElementalFocusElectricity.ToString(),
                    FeatureRefs.GreaterElementalFocusElectricity.ToString(),
                    FeatureRefs.ElementalFocusFire.ToString(),
                    FeatureRefs.GreaterElementalFocusFire.ToString(),
                    FeatureRefs.ArcanePoolFeature.ToString(),
                    FeatureRefs.ShieldBlockFeature.ToString(),
                    FeatureRefs.ShieldBashFeature.ToString(),
                    FeatureSelectionRefs.DeitySelection.ToString(),
                    FeatureSelectionRefs.DomainsSelection.ToString(),
                    FeatureSelectionRefs.DomainsSelection.ToString(),
                    FeatureSelectionRefs.DomainsSelection.ToString(),
                    FeatureSelectionRefs.SecondDomainsSeparatistSelection.ToString(),
                    FeatureSelectionRefs.SecondDomainsSeparatistSelection.ToString(),
                    FeatureSelectionRefs.SecondDomainsSeparatistSelection.ToString(),
                    FeatureSelectionRefs.SwordSaintChosenWeaponSelection.ToString(),
                    /*FeatureSelectionRefs.WizardFeatSelection.ToString(),
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
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),*/
                    FeatureRefs.SpellMasterFocusedSpellsFeature.ToString(),
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
                    HD,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.Evasion.ToString(),
                    FeatureRefs.UncannyDodgeTalent.ToString(),
                    FeatureRefs.ArmoredHulkArmoredSwiftness.ToString(),
                    FeatureRefs.BrewPotions.ToString(),
                    FeatureRefs.StudentOfWarMindOverMetal.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric2
                )
                .AddToAddFeatures(3,
                    HD,
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureRefs.PowerfulChange.ToString(),
                    FeatureRefs.CavalierCharge.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric3
                )
                .AddToAddFeatures(4,
                    HD,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.SwordSaintPerfectStrikeFeature.ToString(),
                    FeatureRefs.KnightOfTheWallDeflectiveShield.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //FeatureRefs.AnimalDomainGreaterFeature.ToString(),
                //FeatureSelectionRefs.AnimalCompanionSelectionDomain.ToString()
                //Cleric4
                )
                .AddToAddFeatures(5,
                    HD,
                    FeatureRefs.ImprovedEvasion.ToString(),
                    FeatureRefs.ImprovedUncannyDodgeTalent.ToString(),
                    FeatureRefs.ArmoredHulkImprovedArmoredSwiftness.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.CavalierBanner.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureRefs.ArcaneWeaponPlus2.ToString(),
                    FeatureRefs.PurityOfBody.ToString(),
                    //FeatureRefs.TowerShieldNegatePenalty.ToString(),
                    //FeatureRefs.ArmorTraining.ToString(),
                    //FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    FeatureRefs.HeavenStrikeFeature.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
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
                    HD,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                    //Cleric6
                )
                .AddToAddFeatures(7,
                    HD,
                    Feats.SuperDodge.MentalAcuity1Feat,
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    //FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.SwordSaintLightningDraw.ToString(),
                    FeatureRefs.ArmoredBattlemageArcaneHeavyArmor.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureRefs.EnlightenedPhilosopherRevelationMentalAcuity.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.ExtraRogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                    //Cleric7
                )
                .AddToAddFeatures(8,
                    HD,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.UniversalistSchoolExtendReachFeature.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                    //FeatureRefs.CommunityDomainGreaterFeature.ToString(),
                    //FeatureRefs.CommunityBlessingMajorFeature.ToString(),
                    //FeatureRefs.NobilityDomainGreaterFeature.ToString(),
                    //FeatureRefs.NobilityBlessingMajorFeature.ToString()
                    //Cleric8
                )
                .AddToAddFeatures(9,
                    HD,
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.TowerShieldSpecialistTouchShield.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureRefs.SwordSaintCriticalPerfection.ToString(),
                    FeatureRefs.KnightOfTheWallSoulShield.ToString(),
                    FeatureRefs.ArcaneWeaponPlus3.ToString(),
                    //FeatureRefs.TowerShieldTraining.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureRefs.ShareTransmutation.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                    //FeatureRefs.ArcaneWeaponPlus3.ToString(),
                    //FeatureRefs.ArcaneArmorEnchantPlus3.ToString()
                    //Cleric9
                )
                .AddToAddFeatures(10,
                    HD,
                    Feats.SuperDodge.MentalAcuity2Feat,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    FeatureSelectionRefs.ExtraRogueTalentSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric10
                )
                .AddToAddFeatures(11,
                    HD,
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureRefs.CavalierMightyCharge.ToString(),
                    FeatureRefs.SwordSaintSuperiorReflexes.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.ExtraRogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric11
                )
                .AddToAddFeatures(12,
                    HD,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.KnightOfTheWallDefensiveChallenge.ToString(),
                    FeatureRefs.UniversalistSchoolEmpowerFeature.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric12
                )
                .AddToAddFeatures(13,
                    HD,
                    Feats.SuperDodge.MentalAcuity3Feat,
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.TowerShieldTotalCover.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureRefs.SwordSaintInstantFocus.ToString(),
                    FeatureRefs.ArcaneWeaponPlus4.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //FeatureRefs.ArcaneWeaponPlus4.ToString(),
                //FeatureRefs.ArcaneArmorEnchantPlus4.ToString()
                //Cleric13
                )
                .AddToAddFeatures(14,
                    HD,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.CavalierBannerGreater.ToString(),
                    FeatureRefs.PersistantMutagen.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric14
                )
                .AddToAddFeatures(15,
                    HD,
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),
                    FeatureRefs.FeatureWingsAngelSorcerer.ToString(),
                    FeatureRefs.BloodlineFeyFeyMagicFeature.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric15
                )
                .AddToAddFeatures(16,
                    HD,
                    Feats.SuperDodge.MentalAcuity4Feat,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.Counterstrike.ToString(),
                    FeatureRefs.UniversalistSchoolMaximizeFeature.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric16
                )
                .AddToAddFeatures(17,
                    HD,
                   //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                   //FeatureSelectionRefs.FighterFeatSelection.ToString(),
                   //FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    FeatureRefs.ArcaneWeaponPlus5.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //FeatureRefs.ArcaneWeaponPlus5.ToString(),
                //FeatureRefs.ArcaneArmorEnchantPlus5.ToString()
                //Cleric17
                )
                .AddToAddFeatures(18,
                    HD,
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric18
                )
                .AddToAddFeatures(19,
                    HD,
                    Feats.SuperDodge.MentalAcuity5Feat,
                    //FeatureRefs.EnlightenedPhilosopherRevelationMentalAcuity.ToString(),
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureRefs.ArmorMastery.ToString(),
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureRefs.TowerShieldTraining.ToString(),
                    FeatureRefs.SwordSaintPerfectReflexes.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric19
                )
                .AddToAddFeatures(20,
                    HD,
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),
                    FeatureRefs.AwakenedIntellect.ToString(),
                    FeatureSelectionRefs.GrandDiscoverySelection.ToString(),
                    FeatureRefs.CavalierSupremeCharge.ToString(),
                    FeatureSelectionRefs.WeaponMasterySelection.ToString(),
                    FeatureRefs.SwordSaintWeaponMastery.ToString(),
                    FeatureRefs.TrueMutagen.ToString(),
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
                    FeatureRefs.BloodlineElementalWaterElementalBodyFeature.ToString(),
                    FeatureRefs.UniversalistSchoolQuickenFeature.ToString(),
                    FeatureRefs.TransmutationSupremacy.ToString(),
                    FeatureRefs.DefenderGiftFeature.ToString(),
                    FeatureRefs.DrunkenCapstoneFeature.ToString(),
                    FeatureRefs.SplitTimelineFeature.ToString(),
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric20
                )
                .Configure();
                

            /*FeatureConfigurator.For(Feats.ArmorAttune.ArmorAttuneFeat)
                .SetReapplyOnLevelUp(true)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, null, 1)
                .Configure();*/

            FeatureConfigurator.For(Feats.SuperDodge.SuperDodgeFeat)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, null,1)
                .Configure();

            FeatureConfigurator.For(Feats.SuperDodge.ShiftingProjectionFeat)
                .SetReapplyOnLevelUp(true)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, null,1)
                .Configure();

            FeatureConfigurator.For(Feats.SuperDodge.MentalAcuity1Feat)
                .SetReapplyOnLevelUp(true)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, null, 7)
                .Configure();

            FeatureConfigurator.For(Feats.SuperDodge.MentalAcuity2Feat)
                .SetReapplyOnLevelUp(true)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, null, 10)
                .Configure();

            FeatureConfigurator.For(Feats.SuperDodge.MentalAcuity3Feat)
                .SetReapplyOnLevelUp(true)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, null, 13)
                .Configure();

            FeatureConfigurator.For(Feats.SuperDodge.MentalAcuity4Feat)
                .SetReapplyOnLevelUp(true)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, null, 16)
                .Configure();

            FeatureConfigurator.For(Feats.SuperDodge.MentalAcuity5Feat)
                .SetReapplyOnLevelUp(true)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, null, 19)
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
