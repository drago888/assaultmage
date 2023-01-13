using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
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



            SuperDodgeFeat = FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .SetIcon(Icon)
                    .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                    .SetIsClassFeature(true)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.AC, ModifierDescriptor.Dodge)
                    .AddDerivativeStatBonus(StatType.Intelligence, StatType.AC, ModifierDescriptor.Dodge)
                    /*.AddBuffOnArmor(BuffRefs.TrueMutagenBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.NobilityDomainGreaterBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.CommunityDomainGreaterBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.MadnessDomainGreaterBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.PerfectPredictionBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.OathOfPeaceBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.SeamantleBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.ShieldOfFaithBuff.Reference.GetBlueprint())
                    .AddBuffOnArmor(BuffRefs.Haste.Reference.GetBlueprint())*/
                    .Configure(delayed: true);
            }

            public static void ConfigureDisabled()
            {
                FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat).Configure();
            }

        }
}
