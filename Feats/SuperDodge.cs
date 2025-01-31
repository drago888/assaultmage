using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
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

            UltimateBuff = BuffConfigurator.New(BuffName, BuffGuid)
                    .SetDisplayName(BuffDisplayName)
                    .SetDescription(BuffDescription)
                    .SetIcon(BuffIcon)
                    //.AddBuffOnArmor(BuffRefs.TrueMutagenBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.NobilityDomainGreaterBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.CommunityDomainGreaterBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.MadnessDomainBaseAttackRollsBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.PerfectPredictionBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.OathOfPeaceBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.SeamantleBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.ShieldOfFaithBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.HasteBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.TrueStrikeBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.MageShieldBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.MageArmorBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.AlignWeaponGoodBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.HeroismGreaterBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.DisplacementBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.BurstOfGloryBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.DivinePowerBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.MagicWeaponGreaterPrimaryBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.BullsStrengthBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.OwlsWisdomBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.FoxsCunningBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.FrightfulAspectBuff.Reference.GetBlueprint())
                    //.AddBuffOnArmor(BuffRefs.LegendaryProportionsBuff.Reference.GetBlueprint())
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
                    .SetIcon(Icon)
                    .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                    .SetIsClassFeature(true)
                    .AddFacts(new() { AbilityUltimateBuff })
                    //.AddFacts(new() { AbilityUltimateBuff })
                    .Configure(delayed: true);

            ShiftingProjectionFeat = FeatureConfigurator.New(ShiftingProjectionFeatName, ShiftingProjectionFeatGuid, FeatureGroup.Feat)
                    .SetDisplayName(ShiftingProjectionDisplayName)
                    .SetDescription(ShiftingProjectionDescription)
                    .SetIcon(Icon)
                    .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                    .SetIsClassFeature(true)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.AC, ModifierDescriptor.UntypedStackable)
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
                    .AddRecalculateOnStatChange(null, BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip, StatType.Intelligence, false)
                    .Configure(delayed: true);
        }
    

            public static void ConfigureDisabled()
            {
                FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat).Configure();
            }

        }
}
