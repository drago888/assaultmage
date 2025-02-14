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
using Kingmaker.PubSubSystem;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.UpgraderEx;
using Kingmaker.UnitLogic;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UI.MVVM._VM.ServiceWindows.CharacterInfo.Sections.Progression.Main;
using AssaultMage.Feats;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.Items.Slots;
using Kingmaker.Designers.Mechanics.Buffs;
using System.ComponentModel;

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
            FakeClasses.Add(CharacterClassRefs.MagusClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.AlchemistClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.ArcanistClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.BardClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.FighterClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.MonkClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.OracleClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.RogueClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.SorcererClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.WitchClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.WizardClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.BarbarianClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.ClericClass.Reference.Get());

            List<Blueprint<BlueprintAbilityReference>> BindedAbilities = new List<Blueprint<BlueprintAbilityReference>>();
            BindedAbilities.Add(AbilityResourceRefs.ArcanePoolResourse.Reference.Get());
                
            BlueprintFeature Cleric1 = FeatureConfigurator.New(Cleric1Name, Cleric1Guid, FeatureGroup.Feat)
                                           .SetDisplayName(Cleric1DisplayName)
                                           .SetDescription(Cleric1Description)
                                           .SetHideInUI(true)
                                           .SetHideInCharacterSheetAndLevelUp(true)
                                           .SetHideNotAvailibleInUI(true)
                                           .RemoveFromGroups(FeatureGroup.Feat)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.AlchemistClass.Reference.GetBlueprint(), null, 1)
                                           /*.AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.ArcanistClass.Reference.GetBlueprint())*/
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.BarbarianClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.BardClass.Reference.GetBlueprint(), null, 1)
                                           /*.AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.BloodragerClass.Reference.GetBlueprint(), null, 1)*/
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.CavalierClass.Reference.GetBlueprint(), null, 1)
                                           // already cleric class
                                           /*.AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.ClericClass.Reference.GetBlueprint(), null, 1)*/
                                           /*.AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.DruidClass.Reference.GetBlueprint(), null, 1)*/
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.FighterClass.Reference.GetBlueprint(), null, 1)
                                           /*.AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.HunterClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.InquisitorClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.KineticistClass.Reference.GetBlueprint(), null, 1)*/
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.MagusClass.Reference.GetBlueprint(), null, 1)
                                           /*.AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.MonkClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.OracleClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.PaladinClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.RangerClass.Reference.GetBlueprint(), null, 1)*/
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.RogueClass.Reference.GetBlueprint(), null, 1)
                                           /*.AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.ShamanClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.ShifterClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.SorcererClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.WarpriestClass.Reference.GetBlueprint(), null, 1)
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.WitchClass.Reference.GetBlueprint(), null, 1)*/
                                           .AddClassLevelsForPrerequisites(BaseClass,
                                                CharacterClassRefs.WizardClass.Reference.GetBlueprint(), null, 1)
                                           /*.AddClassLevelsForPrerequisites(BaseClass,
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
                                                CharacterClassRefs.SwarmThatWalksClass.Reference.GetBlueprint(), null, 1)*/
                                           .AddReplaceStatForPrerequisites(StatType.Intelligence, StatType.Strength)
                                           .AddReplaceStatForPrerequisites(StatType.Intelligence, StatType.Dexterity)
                                           .AddReplaceStatForPrerequisites(StatType.Intelligence, StatType.Constitution)
                                           .AddReplaceStatForPrerequisites(StatType.Intelligence, StatType.Wisdom)
                                           .AddReplaceStatForPrerequisites(StatType.Intelligence, StatType.Charisma)
                                           //.AddConditionImmunity(Kingmaker.UnitLogic.UnitCondition.DevouredBySwarm)
                                           //.AddClassLevels(FakeArchetypes, BaseClass, false, 1)
                                           //.AddImmunityToAbilityScoreDamage()
                                           /*.AddSpellbook(1, 
                                                         null, 
                                                         BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip, 
                                                         SpellbookRefs.ClericSpellbook.Reference.Get())*/

                                           //.AddBindAbilitiesToClass(BindedAbilities, null, null, null, BaseClass, true, 10)
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
                    //ItemArmorRefs.ChainmailStandard.Reference.Get(),
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
                .Configure(delayed: true);
            
            ArchetypeConfigurator.For(AssaultMageArchetype)
                .AddToAddFeatures(1,
                    // alchemist
                    //FeatureRefs.AlchemistProficiencies.ToString(),

                    //Bombs are useless as based on alchemist class
                    //FeatureRefs.AlchemistBombsFeature.ToString(),
                    FeatureRefs.MutagenFeature.ToString(),
                    FeatureRefs.AlchemistThrowAnything.ToString(),
                    FeatureRefs.BrewPotions.ToString(),
                    FeatureRefs.DismissAreaEffectFeature.ToString(),

                    // vivisectionists
                    //FeatureRefs.SneakAttack.ToString(),

                    //arcanists
                    //FeatureRefs.ArcanistCantripsFeature.ToString(),
                    //FeatureRefs.ArcanistProficiencies.ToString(),
                    //FeatureRefs.RayCalculateFeature.ToString(),
                    //FeatureRefs.TouchCalculateFeature.ToString(),
                    //FeatureRefs.ArcanistArcaneReservoirFeature.ToString(),
                    //FeatureRefs.ArcanistConsumeSpellsFeature.ToString(),
                    // arcanist exploit are mostly useless as most use arcanist levels
                    //FeatureSelectionRefs.ArcanistExploitSelection.ToString(),

                    // barbarian
                    //FeatureRefs.FastMovement.ToString(),
                    //FeatureRefs.RageFeature.ToString(),
                    //FeatureRefs.BarbarianProficiencies.ToString(),

                    // armored hulk
                    FeatureRefs.ArmoredHulkIndomitableStance.ToString(),
                    //FeatureRefs.HeavyArmorProficiency.ToString(),

                    // bard
                    FeatureRefs.BardProficiencies.ToString(),
                    //FeatureRefs.BardCantripsFeature.ToString(),
                    //FeatureRefs.BardicPerformanceResourceFact.ToString(),
                    //FeatureRefs.InspireCourageFeature.ToString(),
                    FeatureRefs.BardicKnowledge.ToString(),
                    FeatureRefs.TouchCalculateFeature.ToString(),
                    FeatureRefs.RayCalculateFeature.ToString(),
                    FeatureRefs.DetectMagic.ToString(),

                    // Cavalier
                    //FeatureRefs.CavalierChallengeFeature.ToString(),
                    //FeatureSelectionRefs.CavalierOrderSelection.ToString(),
                    //FeatureRefs.CavalierTacticianFeature.ToString(),
                    //FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString(),
                    FeatureSelectionRefs.CavalierMountSelection.ToString(),
                    //FeatureRefs.CavalierProficiencies.ToString(),

                    // knights of the wall
                    FeatureRefs.ShieldFocus.ToString(),

                    // fighter
                    //FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.FighterProficiencies.ToString(),

                    // defender of the hearth
                    FeatureRefs.ShieldBlockFeature.ToString(),

                    // magus
                    //FeatureRefs.ArcanePoolFeature.ToString(),
                    //FeatureRefs.SpellCombatFeature.ToString(),
                    //FeatureRefs.MagusProficiencies.ToString(),
                    //FeatureRefs.MagusCantripsFeature.ToString(),
                    //FeatureRefs.TouchCalculateFeature.ToString(),
                    //FeatureRefs.RayCalculateFeature.ToString(),
                    //FeatureRefs.DetectMagic.ToString(),

                    // armored battlemage
                    FeatureRefs.ArmoredBattlemageArcanePoolFeature.ToString(),
                    FeatureRefs.ArmoredBattlemageMediumArmor.ToString(),

                    // sword saint
                    FeatureSelectionRefs.SwordSaintChosenWeaponSelection.ToString(),
                    //FeatureRefs.SwordSaintCannyDefense.ToString(),

                    // rogue
                    FeatureRefs.SneakAttack.ToString(),
                    //FeatureRefs.RogueProficiencies.ToString(),
                    FeatureRefs.WeaponFinesse.ToString(),
                    //FeatureRefs.Trapfinding.ToString(),

                    // thug
                    FeatureRefs.ThugFrightening.ToString(),

                    // wizard
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    //FeatureRefs.TouchCalculateFeature.ToString(),
                    //FeatureRefs.RayCalculateFeature.ToString(),
                    FeatureRefs.WizardCantripsFeature.ToString(),
                    //FeatureSelectionRefs.SpecialistSchoolSelection.ToString(),
                    //FeatureRefs.WizardProficiencies.ToString(),
                    FeatureRefs.FullCasterFeature.ToString(),
                    //FeatureSelectionRefs.ArcaneBondSelection.ToString(),
                    //FeatureRefs.DetectMagic.ToString(),
                    FeatureRefs.ScribingScrolls.ToString(),

                    // spell master
                    // 0933849149cfc9244ac05d6a5b57fd80 - specialist school progression
                    // Item bond is useless as replaced by cleric healing spell conversion
                    //FeatureRefs.ItemBondFeature.ToString(),
                    //FeatureRefs.SpellMasterFocusedSpellsFeature.ToString(),

                    // school
                    //FeatureRefs.UniversalistSchoolBaseFeature.ToString(),
                    //ProgressionRefs.SpecialisationSchoolUniversalistProgression.ToString(),

                    // dragon disciple
                    FeatureRefs.DragonDiscipleNaturalArmor.ToString(),

                    // free feats
                    FeatureRefs.WitchHexIceplantFeature.ToString(),
                    FeatureRefs.CautiousFighter.ToString(),
                    //FeatureRefs.DefensiveStanceFeature.ToString(),
                    FeatureRefs.Toughness.ToString(),
                    //FeatureRefs.StalwartDefenderACBonus.ToString(),
                    FeatureRefs.CompanionBoon.ToString(),
                    FeatureRefs.ShieldFocus.ToString(),
                    FeatureRefs.ShieldFocusGreater.ToString(),
                    FeatureRefs.ShieldMaster.ToString(),
                    FeatureRefs.MountedCombat.ToString(),
                    FeatureRefs.MountedShield.ToString(),
                    FeatureRefs.ArmorFocusHeavy.ToString(),
                    FeatureRefs.Dodge.ToString(),
                    FeatureRefs.GreatFortitude.ToString(),
                    FeatureRefs.GreatFortitudeImproved.ToString(),
                    //FeatureRefs.GreatFortitudeMythicFeat.ToString(),
                    FeatureRefs.LightningReflexes.ToString(),
                    FeatureRefs.LightningReflexesImproved.ToString(),
                    //FeatureRefs.LightningReflexesMythicFeat.ToString(),
                    FeatureRefs.IronWill.ToString(),
                    FeatureRefs.IronWillImproved.ToString(),
                    //FeatureRefs.IronWillMythicFeat.ToString(),
                    FeatureRefs.CombatCasting.ToString(),
                    FeatureRefs.FastLearner.ToString(),
                    FeatureRefs.Ironhide.ToString(),
                    FeatureRefs.CraneStyleFeat.ToString(),
                    //FeatureRefs.CraneStyleRiposteFeat.ToString(),
                    FeatureRefs.CombatExpertiseFeature.ToString(),
                    //FeatureRefs.CombatReflexes.ToString(),
                    FeatureRefs.UncannyDodgeTalent.ToString(),

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

                    // self created feats
                    //Feats.ArmorAttune.ArmorAttuneFeat,
                    /*Feats.SuperDodge.SuperDodgeFeat,
                    Feats.SuperDodge.ShiftingProjectionFeat,*/

                    // deity and domains
                    FeatureSelectionRefs.DeitySelection.ToString(),
                    FeatureSelectionRefs.DomainsSelection.ToString(),
                    FeatureSelectionRefs.DomainsSelection.ToString(),
                    FeatureSelectionRefs.DomainsSelection.ToString(),
                    FeatureSelectionRefs.SecondDomainsSeparatistSelection.ToString(),
                    FeatureSelectionRefs.SecondDomainsSeparatistSelection.ToString(),
                    FeatureSelectionRefs.SecondDomainsSeparatistSelection.ToString(),

                    // free familiar
                    FeatureSelectionRefs.WitchFamiliarSelection.ToString(),

                    /*
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
                    FeatureRefs.TricksterLoreReligionLuckDomainRankFeature.ToString(),
                    */

                    /*
                    FeatureRefs.ArcaneWeaponEnchancementMountFeature.ToString(),
                    FeatureRefs.MonkACBonusUnlock.ToString(),
                    FeatureRefs.BloodragerFastMovement.ToString(),
                    FeatureRefs.ArcaneAccuracyFeature.ToString(),
                    //FeatureRefs.MagicalHackFeature.ToString(), 
                    */

                    /*
                    FeatureRefs.BloodlineDraconicBronzeArcana.ToString(),
                    FeatureRefs.BloodlineDraconicCopperArcana.ToString(),
                    FeatureRefs.BloodlineDraconicGoldArcana.ToString(),
                    FeatureRefs.BloodlineDraconicSilverArcana.ToString(),
                    FeatureRefs.BloodlineArcaneArcana.ToString(),
                    //FeatureRefs.BloodlineElementalWaterArcana.ToString(),
                    //FeatureRefs.BloodlineCelestialAscensionAbility.ToString(),
                    //FeatureRefs.BloodlineAbyssalDemonicMight.ToString(),
                    */


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

                    /*
                    //FeatureRefs.TwoWeaponFighting.ToString(),
                    //FeatureRefs.MissileShield.ToString(),
                    //FeatureRefs.RayShield.ToString(),
                    //FeatureRefs.ShieldFocusMythicFeat.ToString(),
                    //FeatureRefs.DodgeMythicFeat.ToString(),
                    FeatureRefs.Ironguts.ToString(),
                    FeatureRefs.BlindFight.ToString(),
                    FeatureRefs.BlindFightImproved.ToString(),
                    FeatureRefs.BlindFightGreater.ToString(),
                    FeatureRefs.CriticalFocus.ToString(),
                    FeatureRefs.CriticalMastery.ToString(),
                    FeatureRefs.PenetratingStrike.ToString(),
                    FeatureRefs.GreaterPenetratingStrike.ToString(),
                    FeatureRefs.SpellPenetration.ToString(),
                    FeatureRefs.GreaterSpellPenetration.ToString(),*/

                    /*
                    FeatureRefs.ShieldBashFeature.ToString(),
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

                    /*
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

                    /*
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    //FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    //FeatureSelectionRefs.MythicFeatSelection.ToString(),
                    */
                    Cleric1,
                    HD
                )
                .AddToAddFeatures(2,
                    // alchemist
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureRefs.PoisonResistance.ToString(),

                    // vivisectionists
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),

                    // arcanist

                    // barbarian
                    //FeatureSelectionRefs.RagePowerSelection.ToString(),
                    //FeatureRefs.UncannyDodgeChecker.ToString(),

                    // armored hulk
                    FeatureRefs.ArmoredHulkArmoredSwiftness.ToString(),

                    // invulnerable rager
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),

                    // bard
                    FeatureSelectionRefs.BardTalentSelection_0.ToString(),
                    FeatureRefs.BardWellVersed.ToString(),

                    // cavalier

                    // fighter
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    //FeatureRefs.Bravery.ToString(),

                    // magus
                    //FeatureRefs.SpellStrikeFeature.ToString(),

                    // rogue
                    FeatureRefs.Evasion.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),

                    // wizard

                    // dragon disciple
                    FeatureRefs.DragonDiscipleStrength.ToString(),
                    
                    // free feats
                    FeatureRefs.ImprovedUncannyDodgeTalent.ToString(),
                    FeatureRefs.StudentOfWarMindOverMetal.ToString(),

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()*/
                    HD
                )
                .AddToAddFeatures(3,
                    // alchemist
                    //FeatureRefs.AlchemistBombsFeature.ToString(),

                    // vivisectionists
                    //FeatureRefs.SneakAttack.ToString(),

                    //arcanists
                    //FeatureSelectionRefs.ArcanistExploitSelection.ToString(),

                    // brown fur transmuter
                    // powerful change is useless as it only affects spells from arcanists slot
                    //FeatureRefs.PowerfulChange.ToString(),

                    // barbarian
                    //FeatureRefs.DangerSenseBarbarian.ToString(),

                    // armored hulk
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),

                    // bard
                    //FeatureRefs.InspireCompetenceFeature.ToString(),

                    // cavalier
                    FeatureRefs.CavalierCharge.ToString(),

                    // fighter
                    FeatureRefs.ArmorTraining.ToString(),

                    // magus
                    FeatureSelectionRefs.MagusArcanaSelection.ToString(),

                    // armored battlemage
                    //FeatureRefs.ArmorTraining.ToString(),

                    // rogue
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureSelectionRefs.FinesseTrainingSelection.ToString(),
                    //FeatureRefs.DangerSenseRogue.ToString(),

                    // thug
                    FeatureRefs.ThugBrutalBeatingFeature.ToString(),

                    // wizard

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()*/
                    HD
                )
                .AddToAddFeatures(4,
                    // alchemist
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),

                    // vivisectionists
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),

                    // arcanist

                    // barbarian
                    //FeatureSelectionRefs.RagePowerSelection.ToString(),

                    // invulnerable rager
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),

                    // bard

                    // cavalier

                    // knights of the wall
                    FeatureRefs.KnightOfTheWallDeflectiveShield.ToString(),

                    // fighter
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),

                    // magus
                    //FeatureRefs.MagusSpellRecallFeature.ToString(),

                    // sword saint
                    FeatureRefs.SwordSaintPerfectStrikeFeature.ToString(),

                    // rogue
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    //FeatureRefs.DebilitatingInjury.ToString(),
                    //FeatureRefs.UncannyDodgeChecker.ToString(),

                    // wizard

                    // dragon disciple
                    FeatureRefs.DragonDiscipleStrength.ToString(),
                    FeatureRefs.DragonDiscipleNaturalArmor.ToString(),

                    // self created feat
                    Feats.SuperDodge.AddArcanePoolFeat,

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                    */
                    HD
                )
                .AddToAddFeatures(5,
                    // alchemist
                    //FeatureRefs.AlchemistBombsFeature.ToString(),
                    FeatureRefs.PoisonResistance.ToString(),

                    // vivisectionists
                    //FeatureRefs.SneakAttack.ToString(),

                    //arcanists
                    //FeatureSelectionRefs.ArcanistExploitSelection.ToString(),

                    //barbarian
                    //FeatureRefs.ImprovedUncannyDodge.ToString(),

                    //armored hulk
                    FeatureRefs.ArmoredHulkImprovedArmoredSwiftness.ToString(),

                    // bard
                    //FeatureRefs.InspireCourageFeature.ToString(),
                    FeatureRefs.BardLoreMaster.ToString(),

                    // cavalier
                    //FeatureRefs.CavalierBanner.ToString(),

                    // fighter
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),

                    // defender of the hearth
                    FeatureRefs.HeavenStrikeFeature.ToString(),

                    // magus
                    FeatureSelectionRefs.MagusFeatSelection.ToString(),
                    //FeatureRefs.ArcaneWeaponPlus2.ToString(),

                    // armored battlemage
                    FeatureRefs.ArcaneArmorEnchantPlus2.ToString(),

                    // rogue
                    FeatureRefs.SneakAttack.ToString(),

                    // wizard
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),

                    // spell master
                    //FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),

                    // free ability
                    FeatureRefs.PurityOfBody.ToString(),

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString()
                    //FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                    */
                    HD
                )
                .AddToAddFeatures(6,
                    // alchemist
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),

                    // vivisectionists
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),

                    // arcanist

                    // barbarian
                    //FeatureSelectionRefs.RagePowerSelection.ToString(),
                    //FeatureRefs.DangerSenseBarbarian.ToString(),

                    // armored hulk
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),

                    // invulnerable rager
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),

                    // bard
                    FeatureSelectionRefs.BardTalentSelection_0.ToString(),
                    //FeatureRefs.FascinateFeature.ToString(),

                    // cavalier 
                    FeatureSelectionRefs.CavalierBonusFeatSelection.ToString(),

                    // fighter
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.Bravery.ToString(),

                    // magus
                    FeatureSelectionRefs.MagusArcanaSelection.ToString(),

                    // sword saint
                    //FeatureRefs.SwordSaintFighterTraining.ToString(),
                    FeatureRefs.SwordSaintLightningDraw.ToString(),

                    // rogue
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    //FeatureRefs.DangerSenseRogue.ToString(),

                    // wizard

                    // dragon disciple
                    FeatureRefs.DragonDiscipleConstitution.ToString(),

                    // self created feat
                    Feats.SuperDodge.AddArcanePoolFeat,

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                    */
                    HD
                )
                .AddToAddFeatures(7,
                    // alchemist
                    //FeatureRefs.AlchemistBombsFeature.ToString(),

                    // vivisectionists
                    //FeatureRefs.SneakAttack.ToString(),

                    //arcanists
                    //FeatureSelectionRefs.ArcanistExploitSelection.ToString(),

                    // barbarian
                    //FeatureRefs.DamageReduction.ToString(),

                    // bard
                    //FeatureRefs.InspireCompetenceFeature.ToString(),
                    //FeatureRefs.BardMovePerformance.ToString(),

                    // cavalier

                    // fighter
                    FeatureRefs.ArmorTraining.ToString(),

                    // magus
                    //FeatureRefs.ArcaneMediumArmor.ToString(),

                    // armored battlemage
                    FeatureRefs.ArmoredBattlemageArcaneHeavyArmor.ToString(),

                    // rogue
                    FeatureRefs.SneakAttack.ToString(),

                    // wizard

                    // dragon disciple
                    FeatureRefs.DragonDiscipleNaturalArmor.ToString(),

                    // self created feats
                    Feats.SuperDodge.MentalAcuity1Feat,

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.ExtraRogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                    */
                    HD
                )
                .AddToAddFeatures(8,
                    // alchemist
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureRefs.PoisonResistance.ToString(),

                    // vivisectionists
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),

                    // arcanist

                    // barbarian
                    //FeatureSelectionRefs.RagePowerSelection.ToString(),

                    // invulnerable rager
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),

                    // bard
                    //FeatureRefs.DirgeOfDoomFeature.ToString(),

                    // cavalier

                    // fighter
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),

                    // magus
                    //FeatureRefs.ImprovedSpellCombat.ToString(),

                    // armored battlemage
                    //FeatureRefs.ArmorTraining.ToString(),

                    // rogue
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    //FeatureRefs.ImprovedUncannyDodge.ToString(),

                    // wizard

                    // dragon disciple
                    FeatureRefs.DragonDiscipleIntelligence.ToString(),

                    // free ability
                    //FeatureRefs.UniversalistSchoolExtendReachFeature.ToString(),

                    // self created feat
                    Feats.SuperDodge.AddArcanePoolFeat,

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    //Cleric8
                    */
                    HD
                )
                .AddToAddFeatures(9,
                    // alchemist
                    //FeatureRefs.AlchemistBombsFeature.ToString(),

                    // vivisectionists
                    //FeatureRefs.SneakAttack.ToString(),

                    //arcanists
                    //FeatureSelectionRefs.ArcanistExploitSelection.ToString(),

                    // brown fur transmuter
                    // Share Transmutation is useless as it affects only arcanist spell slots
                    //FeatureRefs.ShareTransmutation.ToString(),

                    // barbarian
                    //FeatureRefs.DangerSenseBarbarian.ToString(),

                    // armored hulk
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),

                    // bard
                    //FeatureRefs.InspireGreatnessFeature.ToString(),

                    // cavalier
                    //FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString(),
                    //FeatureRefs.CavalierTacticianGreater.ToString(),

                    // knights of the wall
                    FeatureRefs.KnightOfTheWallSoulShield.ToString(),

                    // fighter
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),

                    // magus
                    FeatureSelectionRefs.MagusArcanaSelection.ToString(),
                    //FeatureRefs.ArcaneWeaponPlus3.ToString(),

                    // armored battlemage
                    FeatureRefs.ArcaneArmorEnchantPlus3.ToString(),

                    // sword saint
                    FeatureRefs.SwordSaintCriticalPerfection.ToString(),

                    // rogue
                    FeatureRefs.SneakAttack.ToString(),
                    //FeatureRefs.DangerSenseRogue.ToString(),

                    // wizard

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                    //Cleric9
                    */
                    HD
                )
                .AddToAddFeatures(10,
                    // alchemist
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureRefs.PoisonImmunity.ToString(),

                    // vivisectionists
                    //FeatureRefs.AdvanceTalents.ToString(),

                    // vivisectionists
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),

                    // arcanist

                    // barbarian
                    //FeatureSelectionRefs.RagePowerSelection.ToString(),
                    //FeatureRefs.DamageReduction.ToString(),

                    // invulnerable rager
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),

                    // bard
                    FeatureSelectionRefs.BardTalentSelection_0.ToString(),
                    FeatureRefs.BardJackOfAllTrades.ToString(),

                    // cavalier

                    // fighter
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.Bravery.ToString(),

                    // magus
                    //FeatureRefs.FighterTraining.ToString(),

                    // rogue
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    FeatureRefs.AdvanceTalents.ToString(),

                    // wizard
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),

                    // spell master
                    //FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),

                    // self created feat
                    Feats.SuperDodge.AddArcanePoolFeat,

                    // self created ability
                    Feats.SuperDodge.MentalAcuity2Feat,

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.AdvanceTalents.ToString(),
                    //FeatureSelectionRefs.ExtraRogueTalentSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric10
                    */
                    HD
                )
                .AddToAddFeatures(11,
                    // alchemist
                    //FeatureRefs.AlchemistBombsFeature.ToString(),

                    // vivisectionists
                    //FeatureRefs.SneakAttack.ToString(),

                    //arcanists
                    //FeatureRefs.ArcanistGreaterExploitsFeature.ToString(),
                    //FeatureSelectionRefs.ArcanistExploitSelection.ToString(),

                    // barbarian
                    //FeatureRefs.GreaterRageFeature.ToString(),

                    // bard
                    //FeatureRefs.InspireCompetenceFeature.ToString(),
                    //FeatureRefs.InspireCourageFeature.ToString(),

                    // cavalier
                    FeatureRefs.CavalierMightyCharge.ToString(),

                    // fighter
                    FeatureRefs.ArmorTraining.ToString(),

                    // magus
                    FeatureSelectionRefs.MagusFeatSelection.ToString(),
                    //FeatureRefs.MagusImprovedSpellRecallFeature.ToString(),

                    // sword saint
                    FeatureRefs.SwordSaintSuperiorReflexes.ToString(),

                    // rogue
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureSelectionRefs.FinesseTrainingSelection.ToString(),

                    // wizard

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.BasicFeatSelection.ToString()
                    //FeatureSelectionRefs.ExtraRogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric11
                    */
                    HD
                )
                .AddToAddFeatures(12,
                    // alchemist
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),

                    // vivisectionists
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),

                    // arcanist

                    // barbarian
                    //FeatureSelectionRefs.RagePowerSelection.ToString(),
                    //FeatureRefs.DangerSenseBarbarian.ToString(),

                    // armored hulk
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),

                    // invulnerable rager
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),

                    // bard
                    FeatureRefs.SoothingPerformanceFeature.ToString(),

                    // cavalier
                    FeatureSelectionRefs.CavalierBonusFeatSelection.ToString(),
                    //FeatureRefs.CavalierDemandingChallenge.ToString(),

                    // knights of the wall
                    //FeatureRefs.KnightOfTheWallDefensiveChallenge.ToString(),

                    // fighter
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),

                    // magus
                    FeatureSelectionRefs.MagusArcanaSelection.ToString(),

                    // rogue
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    //FeatureRefs.DangerSenseRogue.ToString(),

                    // wizard

                    // free ability
                    //FeatureRefs.UniversalistSchoolEmpowerFeature.ToString(),

                    // self created feat
                    Feats.SuperDodge.AddArcanePoolFeat,

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric12
                    */
                    HD
                )
                .AddToAddFeatures(13,
                    // alchemist
                    //FeatureRefs.AlchemistBombsFeature.ToString(),

                    // vivisectionists
                    //FeatureRefs.SneakAttack.ToString(),

                    //arcanists
                    //FeatureSelectionRefs.ArcanistExploitSelection.ToString(),

                    // barbarian
                    //FeatureRefs.DamageReduction.ToString(),

                    // bard
                    //FeatureRefs.BardSwiftPerformance.ToString(),

                    // cavalier

                    // fighter
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),

                    // magus
                    //FeatureRefs.ArcaneWeaponPlus4.ToString(),
                    //FeatureRefs.ArcaneHeavyArmor.ToString(),

                    // armored battlemage
                    //FeatureRefs.ArmorTraining.ToString(),
                    FeatureRefs.ArcaneArmorEnchantPlus4.ToString(),

                    // sword saint
                    FeatureRefs.SwordSaintInstantFocus.ToString(),

                    // rogue
                    FeatureRefs.SneakAttack.ToString(),

                    // wizard

                    // self created feats
                    Feats.SuperDodge.MentalAcuity3Feat,

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric13*/
                    HD
                )
                .AddToAddFeatures(14,
                    // alchemist
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    FeatureRefs.PersistantMutagen.ToString(),

                    // vivisectionists
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),

                    // arcanist

                    // barbarian
                    //FeatureSelectionRefs.RagePowerSelection.ToString(),
                    FeatureRefs.IndomitableWill.ToString(),

                    // invulnerable rager
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),

                    // bard
                    FeatureSelectionRefs.BardTalentSelection_0.ToString(),
                    //FeatureRefs.FrighteningTuneFeature.ToString(),

                    // cavalier
                    //FeatureRefs.CavalierBannerGreater.ToString(),

                    // fighter
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.Bravery.ToString(),

                    // magus

                    //rogue
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),

                    // wizard

                    // self created feat
                    Feats.SuperDodge.AddArcanePoolFeat,

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric14
                    */
                    HD
                )
                .AddToAddFeatures(15,
                    // alchemist
                    //FeatureRefs.AlchemistBombsFeature.ToString(),

                    // vivisectionists
                    //FeatureRefs.SneakAttack.ToString(),

                    //arcanists
                    //FeatureSelectionRefs.ArcanistExploitSelection.ToString(),

                    // barbarian
                    //FeatureRefs.DangerSenseBarbarian.ToString(),

                    // armored hulk
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),

                    // bard
                    //FeatureRefs.InspireCompetenceFeature.ToString(),
                    //FeatureRefs.InspireHeroicsFeature.ToString(),

                    // cavalier

                    // fighter
                    FeatureRefs.ArmorTraining.ToString(),

                    // magus
                    FeatureSelectionRefs.MagusArcanaSelection.ToString(),

                    // rogue
                    FeatureRefs.SneakAttack.ToString(),
                    //FeatureRefs.DangerSenseRogue.ToString(),

                    // wizard
                    //FeatureSelectionRefs.WizardFeatSelection.ToString(),

                    // spell master
                    //FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),

                    // free ability
                    FeatureRefs.FeatureWingsAngelSorcerer.ToString(),
                    FeatureRefs.BloodlineFeyFeyMagicFeature.ToString(),

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric15
                    */
                    HD
                )
                .AddToAddFeatures(16,
                    // alchemist
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),

                    // vivisectionists
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),

                    // arcanist

                    // barbarian
                    //FeatureSelectionRefs.RagePowerSelection.ToString(),
                    //FeatureRefs.DamageReduction.ToString(),

                    // invulnerable rager
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),

                    // bard

                    // cavalier

                    // fighter
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),

                    // magus
                    FeatureRefs.Counterstrike.ToString(),

                    // rogue
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),

                    // wizard

                    // free ability
                    //FeatureRefs.UniversalistSchoolMaximizeFeature.ToString(),

                    // self created feat
                    Feats.SuperDodge.MentalAcuity4Feat,
                    Feats.SuperDodge.AddArcanePoolFeat,

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric16
                    */
                    HD
                )
                .AddToAddFeatures(17,
                    // alchemist
                    //FeatureRefs.AlchemistBombsFeature.ToString(),

                    // vivisectionists
                    //FeatureRefs.SneakAttack.ToString(),

                    //arcanists
                    //FeatureSelectionRefs.ArcanistExploitSelection.ToString(),

                    // barbarian
                    //FeatureRefs.TirelessRage.ToString(),

                    // bard
                    //FeatureRefs.InspireCourageFeature.ToString(),

                    // cavalier
                    //FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString(),

                    // fighter
                    FeatureSelectionRefs.WeaponTrainingSelection.ToString(),
                    FeatureSelectionRefs.WeaponTrainingRankUpSelection.ToString(),

                    // magus
                    FeatureSelectionRefs.MagusFeatSelection.ToString(),
                    //FeatureRefs.ArcaneWeaponPlus5.ToString(),

                    // armored battlemage
                    FeatureRefs.ArcaneArmorEnchantPlus5.ToString(),

                    // rogue
                    FeatureRefs.SneakAttack.ToString(),

                    // wizard

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    /*
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric17
                    */
                    HD
                )
                .AddToAddFeatures(18,
                    // alchemist
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),

                    // vivisectionists
                    FeatureSelectionRefs.VivsectionistDiscoverySelection.ToString(),

                    // barbarian
                    //FeatureSelectionRefs.RagePowerSelection.ToString(),
                    //FeatureRefs.DangerSenseBarbarian.ToString(),

                    // armored hulk
                    FeatureRefs.ArmoredHulkResilienceOfSteel.ToString(),

                    // invulnerable rager
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),

                    // bard
                    FeatureSelectionRefs.BardTalentSelection_0.ToString(),

                    // cavalier
                    FeatureSelectionRefs.CavalierBonusFeatSelection.ToString(),

                    // fighter
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureRefs.Bravery.ToString(),

                    // magus
                    FeatureSelectionRefs.MagusArcanaSelection.ToString(),

                    // armored battlemage
                    //FeatureRefs.ArmorTraining.ToString(),

                    // rogue
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    //FeatureRefs.DangerSenseRogue.ToString(),

                    // wizard

                    // self created feat
                    Feats.SuperDodge.AddArcanePoolFeat,

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),
                    /*
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric18
                    */
                    HD
                )
                .AddToAddFeatures(19,
                    // alchemist
                    //FeatureRefs.AlchemistBombsFeature.ToString(),

                    // vivisectionists
                    //FeatureRefs.SneakAttack.ToString(),

                    //arcanists
                    //FeatureSelectionRefs.ArcanistExploitSelection.ToString(),

                    // barbarian
                    //FeatureRefs.DamageReduction.ToString(),

                    // bard
                    //FeatureRefs.InspireCompetenceFeature.ToString(),

                    // cavalier

                    // fighter
                    FeatureRefs.ArmorMastery.ToString(),

                    // magus
                    //FeatureRefs.GreaterSpellAccess.ToString(),

                    // sword saint
                    FeatureRefs.SwordSaintPerfectReflexes.ToString(),

                    // rogue
                    FeatureRefs.SneakAttack.ToString(),
                    FeatureSelectionRefs.FinesseTrainingSelection.ToString(),

                    // wizard


                    // self created feats
                    Feats.SuperDodge.MentalAcuity5Feat,

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric19
                    */
                    HD
                )
                .AddToAddFeatures(20,
                    // alchemist
                    FeatureSelectionRefs.GrandDiscoverySelection.ToString(),
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),
                    //FeatureSelectionRefs.DiscoverySelection.ToString(),

                    // vivisectionists
                    // addition GrandDiscovery for this archetype
                    FeatureSelectionRefs.GrandDiscoverySelection.ToString(),

                    //arcanists
                    //FeatureRefs.ArcanistMagicalSupremacy.ToString(),

                    // brown fur transmuter
                    // only useful feature is the extend spell as change and share is not useable 
                    FeatureRefs.TransmutationSupremacy.ToString(),

                    // barbarian
                    //FeatureSelectionRefs.RagePowerSelection.ToString(),
                    //FeatureRefs.MightyRage.ToString(),

                    // invulnerable rager
                    FeatureRefs.InvulnerableRagerDamageReduction.ToString(),

                    // bard
                    //FeatureRefs.DeadlyPerformanceFeature.ToString(),

                    // cavalier
                    FeatureRefs.CavalierSupremeCharge.ToString(),

                    // fighter
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.WeaponMasterySelection.ToString(),

                    // defender of the hearth
                    FeatureRefs.DefenderGiftFeature.ToString(),

                    // magus
                    FeatureRefs.TrueMagusFeature.ToString(),

                    // sword saint
                    FeatureRefs.SwordSaintWeaponMastery.ToString(),

                    // rogue
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    //FeatureRefs.MasterStrike.ToString(),

                    // wizard
                    FeatureSelectionRefs.WizardFeatSelection.ToString(),

                    // spell master
                    //FeatureRefs.SpellMasterItemBondSpecializationFeature.ToString(),

                    // free ability
                    //FeatureRefs.BloodlineDraconicBronzePowerOfWyrms.ToString(),
                    //FeatureRefs.BloodlineDraconicCopperPowerOfWyrms.ToString(),
                    //FeatureRefs.BloodlineDraconicGoldPowerOfWyrms.ToString(),
                    //FeatureRefs.BloodlineDraconicSilverPowerOfWyrms.ToString(),
                    //FeatureRefs.BloodlineCelestialAscensionAbility.ToString(),
                    FeatureRefs.BloodlineCelestialAscensionAbility.ToString(),
                    FeatureRefs.BloodlineAbyssalDemonicMight.ToString(),
                    FeatureRefs.BloodlineDraconicGoldPowerOfWyrms.ToString(),
                    FeatureRefs.BloodlineElementalWaterElementalBodyFeature.ToString(),
                    //FeatureRefs.UniversalistSchoolQuickenFeature.ToString(),
                    FeatureRefs.DrunkenCapstoneFeature.ToString(),
                    FeatureRefs.SplitTimelineFeature.ToString(),

                    // self created feat
                    Feats.SuperDodge.AddArcanePoolFeat,

                    // level up animal
                    FeatureRefs.AnimalCompanionRank.ToString(),

                    /*
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    //FeatureSelectionRefs.BasicFeatSelection.ToString(),
                    FeatureSelectionRefs.FighterFeatSelection.ToString(),
                    FeatureSelectionRefs.RogueTalentSelection.ToString(),
                    FeatureSelectionRefs.WizardFeatSelection.ToString()
                    //FeatureSelectionRefs.MythicFeatSelection.ToString()
                //Cleric20
                    */
                    HD
                )
                .Configure();


            // existing feats
            List<Blueprint<BlueprintCharacterClassReference>> AddToMagusClasses = new List<Blueprint<BlueprintCharacterClassReference>>();
            //FakeClasses.Add(CharacterClassRefs.MagusClass.Reference.Get());
            FakeClasses.Add(CharacterClassRefs.ClericClass.Reference.Get());

            FeatureConfigurator.New("Test", Cleric20Guid)
                .CopyFrom(FeatureRefs.SwordSaintCannyDefense)
                .Configure();


            // new feats

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

            FeatureConfigurator.For(Feats.SuperDodge.AddArcanePoolFeat)
                .SetReapplyOnLevelUp(true)
                .AddPrerequisiteArchetypeLevel(AssaultMageArchetype, BaseClass, true, GroupType.All, false, null, 1)
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
