using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssaultMage.Archetypes;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Unity.Injection;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;

namespace AssaultMage.Feats
{
        /// <summary>
        /// Creates a feat that does nothing but show up.
        /// </summary>
        public class SuperDodge
        {
            private static readonly string FeatName = "SuperDodge";
            internal static readonly string FeatGuid = "89ddeb34-20ae-4249-b3de-01354d710801";

            private static readonly string DisplayName = "SuperDodge.Name";
            private static readonly string Description = "SuperDodge.Description";
            private static readonly string Icon = "assets/icons/armoredmage.jpg";
            internal static BlueprintFeature SuperDodgeFeat;

            private static readonly string ConBuffName = "ConUltimateBuff";
            internal static readonly string ConBuffGuid = "8be56a13-ad5e-4b0b-ae37-4249124d3d32";
            private static readonly string ConBuffDisplayName = "ConUltimateBuff.Name";
            private static readonly string ConBuffDescription = "ConUltimateBuff.Description";
            private static readonly string ConBuffIcon = "assets/icons/armoredmage.jpg";
            internal static BlueprintBuff ConUltimateBuff;

            private static readonly string BuffName = "UltimateBuff";
            internal static readonly string BuffGuid = "30591265-853a-4e83-afb7-de15d4a35778";
            private static readonly string BuffDisplayName = "UltimateBuff.Name";
            private static readonly string BuffDescription = "UltimateBuff.Description";
            private static readonly string BuffIcon = "assets/icons/armoredmage.jpg";
            internal static BlueprintBuff UltimateBuff;

            private static readonly string AbilityName = "UltimateBuffAbility";
            internal static readonly string AbilityGuid = "d3737e69-78d0-4889-936d-d9e40487e062";
            private static readonly string AbilityDisplayName = "UltimateBuffAbility.Name";
            private static readonly string AbilityDescription = "UltimateBuffAbility.Description";
            private static readonly string AbilityIcon = "assets/icons/armoredmage.jpg";
            internal static BlueprintActivatableAbility AbilityUltimateBuff;

            private static readonly string ShiftingProjectionFeatName = "ShiftingProjection";
            internal static readonly string ShiftingProjectionFeatGuid = "cc6acc5d-4017-4a8f-ba33-cf7319d458b8";
            private static readonly string ShiftingProjectionDisplayName = "ShiftingProjection.Name";
            private static readonly string ShiftingProjectionDescription = "ShiftingProjection.Description";
            private static readonly string ShiftingProjectionIcon = "assets/icons/armoredmage.jpg";
            internal static BlueprintFeature ShiftingProjectionFeat;

            private static readonly string MentalAcuity1FeatName = "MentalAcuity1";
            internal static readonly string MentalAcuity1FeatGuid = "803b16c6-ceeb-4caa-89e5-489484047316";
            private static readonly string MentalAcuity1DisplayName = "MentalAcuity1.Name";
            private static readonly string MentalAcuity1Description = "MentalAcuity1.Description";
            private static readonly string MentalAcuity1Icon = null;
            internal static BlueprintFeature MentalAcuity1Feat;

            private static readonly string MentalAcuity2FeatName = "MentalAcuity2";
            internal static readonly string MentalAcuity2FeatGuid = "d1524d7d-33f4-4031-b881-25d371fd9cf9";
            private static readonly string MentalAcuity2DisplayName = "MentalAcuity2.Name";
            private static readonly string MentalAcuity2Description = "MentalAcuity2.Description";
            private static readonly string MentalAcuity2Icon = null;
            internal static BlueprintFeature MentalAcuity2Feat;

            private static readonly string MentalAcuity3FeatName = "MentalAcuity3";
            internal static readonly string MentalAcuity3FeatGuid = "c4362445-2d8a-4b49-86bb-5da05d6da9ea";
            private static readonly string MentalAcuity3DisplayName = "MentalAcuity3.Name";
            private static readonly string MentalAcuity3Description = "MentalAcuity3.Description";
            private static readonly string MentalAcuity3Icon = null;
            internal static BlueprintFeature MentalAcuity3Feat;

            private static readonly string MentalAcuity4FeatName = "MentalAcuity4";
            internal static readonly string MentalAcuity4FeatGuid = "03b26ae9-d08f-4b2f-820d-2c7aaf62a6ee";
            private static readonly string MentalAcuity4DisplayName = "MentalAcuity4.Name";
            private static readonly string MentalAcuity4Description = "MentalAcuity4.Description";
            private static readonly string MentalAcuity4Icon = null;
            internal static BlueprintFeature MentalAcuity4Feat;

            private static readonly string MentalAcuity5FeatName = "MentalAcuity5";
            internal static readonly string MentalAcuity5FeatGuid = "0de0c0e5-f19f-4fb4-a97c-caf340fc24fc";
            private static readonly string MentalAcuity5DisplayName = "MentalAcuity5.Name";
            private static readonly string MentalAcuity5Description = "MentalAcuity5.Description";
            private static readonly string MentalAcuity5Icon = null;
            internal static BlueprintFeature MentalAcuity5Feat;

            private static readonly string AddArcanePoolFeatName = "AddArcanePool";
            internal static readonly string AddArcanePoolFeatGuid = "f7b3cc69-2753-497a-aeb1-97826be31788";
            private static readonly string AddArcanePoolDisplayName = "AddArcanePool.Name";
            private static readonly string AddArcanePoolDescription = "AddArcanePool.Description";
            private static readonly string AddArcanePoolIcon = null;
            internal static BlueprintFeature AddArcanePoolFeat;

            private static readonly string ItemBondFeatureName = "ItemBondAbility";
            internal static readonly string ItemBondFeatureGuid = "027f3c3f0b144673a09d287f0a046bbf";
            private static readonly string ItemBondFeatureDisplayName = "ItemBondFeature.Name";
            private static readonly string ItemBondFeatureDescription = "ItemBondFeature.Description";
            private static readonly string AItemBondFeatureIcon = null;
            internal static BlueprintAbility ItemBondFeature;

            internal static List<Blueprint<BlueprintSpellbookReference>> AllowedSpellbooks = new List<Blueprint<BlueprintSpellbookReference>>();


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
            ArmorProficiencyGroup[] ArmorsProficiencies = { /*ArmorProficiencyGroup.Heavy ,
                                                            ArmorProficiencyGroup.Medium,
                                                            ArmorProficiencyGroup.Light,
                                                            ArmorProficiencyGroup.Buckler,
                                                            ArmorProficiencyGroup.LightShield,
                                                            ArmorProficiencyGroup.HeavyShield,
                                                            ArmorProficiencyGroup.TowerShield*/
                                                            ArmorProficiencyGroup.None};
            List<Blueprint<BlueprintArchetypeReference>> Archetypes = new List<Blueprint<BlueprintArchetypeReference>>();
            Archetypes.Add(ArchetypeRefs.EcclesitheurgeArchetype.Reference.GetBlueprint());
            //Archetypes.Add(ArchetypeRefs.FighterSwordAndBoard.Reference.GetBlueprint());


            var BuffAction = ActionsBuilder.New()
                            /*.CastSpell(AbilityRefs.ShieldOfFaith.Reference.GetBlueprint(), true, false, false, true, false, null, null, null, false, false, false)
                            .CastSpell(AbilityRefs.HeroismGreater.Reference.GetBlueprint(), true, false, false, true, false, null, null, null, false, false, false)
                            .CastSpell(AbilityRefs.Barkskin.Reference.GetBlueprint(), true, false, false, true, false, null, null, null, false, false, false)
                            //.CastSpell(AbilityRefs.MagicalVestment.Reference.GetBlueprint(), true, false, false, true, false, null, null, null, false, false, false)
                            .CastSpell(AbilityRefs.MagicalVestmentShield.Reference.GetBlueprint(), true, false, false, true, false, null, null, null, false, false, false)
                            .CastSpell(AbilityRefs.MagicalVestmentArmor.Reference.GetBlueprint(), true, false, false, true, false, null, null, null, false, false, false)
                            .CastSpell(AbilityRefs.MagicWeaponGreaterPrimary.Reference.GetBlueprint(), true, false, false, true, false, null, null, null, false, false, false)
                            .ApplyBuffPermanent(BuffRefs.HasteBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.BullsStrengthBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.OwlsWisdomBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.BearsEnduranceBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.FoxsCunningBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.CatsGraceBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.EaglesSplendorBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.LegendaryProportionsBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.ForesightBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.InvisibilityGreaterBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.ShamanHexProtectiveLuckBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.StoneskinBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.GuidanceBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.MageShieldBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.TrueSeeingBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.LuckDomainBaseBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.FreedomOfMovementBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.NobilityDomainGreaterBuff.Reference.GetBlueprint(), true, false, false, false, null, null, true)*/
                            //.Build();

                            .ApplyBuffPermanent(BuffRefs.LuckDomainBaseBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .ApplyBuffPermanent(BuffRefs.ProtectiveWardEffectBuff.Reference.GetBlueprint())
                            //.ApplyBuffPermanent(BuffRefs.GuidanceBuff.Reference.GetBlueprint(), true, false, true, false, null, null, true)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.AC, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.AdditionalAttackBonus, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.AdditionalCMB, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.AdditionalCMD, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SkillKnowledgeArcana, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SkillKnowledgeWorld, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SkillLoreNature, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SkillLoreReligion, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SkillAthletics, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SkillMobility, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SkillPerception, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SkillPersuasion, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SkillStealth, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SkillThievery, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SkillUseMagicDevice, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SaveFortitude, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SaveWill, 30)
                            .BuffActionAddStatBonus(ModifierDescriptor.UntypedStackable, StatType.SaveReflex, 30);



            ConUltimateBuff = BuffConfigurator.New(ConBuffName, ConBuffGuid)
                                    .SetDisplayName(ConBuffDisplayName)
                                    .SetDescription(ConBuffDescription)
                                    .SetIcon(ConBuffIcon)
                                    .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                                    .AddBuffActions(BuffAction)
                                    //.AddTimerContextActions(BuffAction, 120, null, true)
                                    .Configure();

            UltimateBuff = BuffConfigurator.New(BuffName, BuffGuid)
                    .SetDisplayName(BuffDisplayName)
                    .SetDescription(BuffDescription)
                    .SetIcon(BuffIcon)
                    .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                    .AddBuffOnArmor(ConUltimateBuff)
                    /*
                    //.AddBuffOnArmor(BuffRefs.TrueMutagenBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.MadnessDomainBaseAttackRollsBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.PerfectPredictionBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.OathOfPeaceBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.SeamantleBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.TrueStrikeBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.MageShieldBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.MageArmorBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.DisplacementBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.BurstOfGloryBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.DivinePowerBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.MagicWeaponGreaterPrimaryBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.FrightfulAspectBuff.Reference.GetBlueprint())
                    */
                    .Configure();



            AbilityUltimateBuff = ActivatableAbilityConfigurator.New(AbilityName, AbilityGuid)
                    .SetDisplayName(AbilityDisplayName)
                    .SetDescription(AbilityDescription)
                    .SetIcon(Icon)
                    .SetIsOnByDefault()
                    .SetBuff(UltimateBuff)
                    .Configure(delayed: true);

            SuperDodgeFeat = FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    //.SetIcon(Icon)
                    .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                    .SetIsClassFeature(true)
                    .SetHideInUI(false)
                    .SetHideInCharacterSheetAndLevelUp(false)
                    .SetHideNotAvailibleInUI(false)
                    .RemoveFromGroups(FeatureGroup.Feat)
                    .AddFacts(new() { AbilityUltimateBuff })
                    //.AddFacts(new() { AbilityUltimateBuff })
                    .Configure(delayed: true);

            ShiftingProjectionFeat = FeatureConfigurator.New(ShiftingProjectionFeatName, ShiftingProjectionFeatGuid, FeatureGroup.Feat)
                    .SetDisplayName(ShiftingProjectionDisplayName)
                    .SetDescription(ShiftingProjectionDescription)
                    //.SetIcon(Icon)
                    .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                    .SetIsClassFeature(true)
                    .SetHideInUI(false)
                    .SetHideInCharacterSheetAndLevelUp(false)
                    .SetHideNotAvailibleInUI(true)
                    .RemoveFromGroups(FeatureGroup.Feat)
                    /*.AddDerivativeStatBonus(StatType.Intelligence, StatType.AC, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.AdditionalAttackBonus, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.AdditionalCMB, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.AdditionalCMD, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.AdditionalDamage, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.HitPoints, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.CheckIntimidate, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.CheckDiplomacy, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.Initiative, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SaveFortitude, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SaveReflex, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SaveWill, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.Speed, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.Wisdom, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.Strength, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.Constitution, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.Dexterity, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.Charisma, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SkillThievery, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SkillAthletics, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SkillKnowledgeArcana, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SkillKnowledgeWorld, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SkillLoreNature, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SkillLoreReligion, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SkillMobility, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SkillPerception, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SkillPersuasion, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SkillStealth, ModifierDescriptor.UntypedStackable)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.SkillUseMagicDevice, ModifierDescriptor.UntypedStackable)
                    .AddRecalculateOnStatChange(null, BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip, StatType.Intelligence, false)*/
                    .Configure(delayed: true);

            MentalAcuity1Feat = FeatureConfigurator.New(MentalAcuity1FeatName, MentalAcuity1FeatGuid, FeatureGroup.Feat)
                    .SetDisplayName(MentalAcuity1DisplayName)
                    .SetDescription(MentalAcuity1Description)
                    //.SetIcon(Icon)
                    .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                    .SetIsClassFeature(true)
                    .SetHideInUI(false)
                    .SetHideInCharacterSheetAndLevelUp(false)
                    .SetHideNotAvailibleInUI(false)
                    .RemoveFromGroups(FeatureGroup.Feat)
                    .AddBuffSkillBonus(StatType.Intelligence, 1, ModifierDescriptor.Inherent)
                    .AddRecalculateOnStatChange(null, BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip, StatType.Intelligence, false)
                    .Configure(delayed: true);

            MentalAcuity2Feat = FeatureConfigurator.New(MentalAcuity2FeatName, MentalAcuity2FeatGuid, FeatureGroup.Feat)
                    .SetDisplayName(MentalAcuity2DisplayName)
                    .SetDescription(MentalAcuity2Description)
                    //.SetIcon(Icon)
                    .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                    .SetIsClassFeature(true)
                    .SetHideInUI(false)
                    .SetHideInCharacterSheetAndLevelUp(false)
                    .SetHideNotAvailibleInUI(false)
                    .RemoveFromGroups(FeatureGroup.Feat)
                    .AddBuffSkillBonus(StatType.Intelligence, 2, ModifierDescriptor.Inherent)
                    .AddRecalculateOnStatChange(null, BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip, StatType.Intelligence, false)
                    .Configure(delayed: true);

            MentalAcuity3Feat = FeatureConfigurator.New(MentalAcuity3FeatName, MentalAcuity3FeatGuid, FeatureGroup.Feat)
                    .SetDisplayName(MentalAcuity3DisplayName)
                    .SetDescription(MentalAcuity3Description)
                    //.SetIcon(Icon)
                    .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                    .SetIsClassFeature(true)
                    .SetHideInUI(false)
                    .SetHideInCharacterSheetAndLevelUp(false)
                    .SetHideNotAvailibleInUI(false)
                    .RemoveFromGroups(FeatureGroup.Feat)
                    .AddBuffSkillBonus(StatType.Intelligence, 3, ModifierDescriptor.Inherent)
                    .AddRecalculateOnStatChange(null, BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip, StatType.Intelligence, false)
                    .Configure(delayed: true);

            MentalAcuity4Feat = FeatureConfigurator.New(MentalAcuity4FeatName, MentalAcuity4FeatGuid, FeatureGroup.Feat)
                    .SetDisplayName(MentalAcuity4DisplayName)
                    .SetDescription(MentalAcuity4Description)
                    //.SetIcon(Icon)
                    .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                    .SetIsClassFeature(true)
                    .SetHideInUI(false)
                    .SetHideInCharacterSheetAndLevelUp(false)
                    .SetHideNotAvailibleInUI(false)
                    .RemoveFromGroups(FeatureGroup.Feat)
                    .AddBuffSkillBonus(StatType.Intelligence, 4, ModifierDescriptor.Inherent)
                    .AddRecalculateOnStatChange(null, BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip, StatType.Intelligence, false)
                    .Configure(delayed: true);

            MentalAcuity5Feat = FeatureConfigurator.New(MentalAcuity5FeatName, MentalAcuity5FeatGuid, FeatureGroup.Feat)
                    .SetDisplayName(MentalAcuity5DisplayName)
                    .SetDescription(MentalAcuity5Description)
                    //.SetIcon(Icon)
                    .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                    .SetIsClassFeature(true)
                    .SetHideInUI(false)
                    .SetHideInCharacterSheetAndLevelUp(false)
                    .SetHideNotAvailibleInUI(false)
                    .RemoveFromGroups(FeatureGroup.Feat)
                    .AddBuffSkillBonus(StatType.Intelligence, 5, ModifierDescriptor.Inherent)
                    .AddRecalculateOnStatChange(null, BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip, StatType.Intelligence, false)
                    .Configure(delayed: true);

            AddArcanePoolFeat = FeatureConfigurator.New(AddArcanePoolFeatName, AddArcanePoolFeatGuid, FeatureGroup.Feat)
                    .SetDisplayName(AddArcanePoolDisplayName)
                    .SetDescription(AddArcanePoolDescription)
                    //.SetIcon(Icon)
                    .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                    .SetIsClassFeature(true)
                    .SetHideInUI(true)
                    .SetHideInCharacterSheetAndLevelUp(true)
                    .SetHideNotAvailibleInUI(true)
                    .RemoveFromGroups(FeatureGroup.Feat)
                    .AddIncreaseResourceAmount(AbilityResourceRefs.ArcanePoolResourse.ToString(), 1)
                    .AddRecalculateOnStatChange(null, BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip, StatType.Intelligence, false)
                    .Configure(delayed: false);


            AllowedSpellbooks.Add(AssaultMage.Archetypes.AssaultMage.ArchetypeSpellbookGuid);

            ItemBondFeature = AbilityConfigurator.New(ItemBondFeatureName, ItemBondFeatureGuid)
                    .SetDisplayName(ItemBondFeatureName)
                    .SetDescription(ItemBondFeatureGuid)
                    .AddAbilityResourceLogic(1, false, true, null, ComponentMerge.Skip, AbilityResourceRefs.ItemBondResource.Reference.Get(),
                            null, null)
                    .AddAbilityRestoreSpellSlot(true, true, null, ComponentMerge.Skip, AllowedSpellbooks, null)
                    .Configure(delayed: true);
        }
    

            public static void ConfigureDisabled()
            {
                //FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat).Configure();
            }

        }
}
