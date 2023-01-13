using System;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;

namespace AssaultMage.Feats
{
    /// <summary>
    /// Creates a feat that does nothing but show up.
    /// </summary>
    public class ArmorAttune
    {
        private static readonly string FeatName = "ArmorAttune";
        internal static readonly string FeatGuid = "8c3f2a90-a5ec-4192-874f-6e509db18857";

        private static readonly string DisplayName = "ArmorAttune.Name";
        private static readonly string Description = "ArmorAttune.Description";
        private static readonly string Icon = "assets/icons/magicarmor.png";
        internal static BlueprintFeature ArmorAttuneFeat;

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
            System.Collections.Generic.List<Blueprint<BlueprintFeatureReference>> FighterFeats = new System.Collections.Generic.List<Blueprint<BlueprintFeatureReference>>();
            FighterFeats.Add(FeatureRefs.ShieldFocusGreater.Reference.GetBlueprint());

            ArmorAttuneFeat = FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                .SetIsClassFeature(true)
                .AddChangeHitDie(Kingmaker.RuleSystem.DiceType.D12)
                .AddClassLevelsForPrerequisites(AssaultMage.Archetypes.AssaultMage.BaseClass, 
                                                CharacterClassRefs.FighterClass.Reference.GetBlueprint(),1)
                .AddClassLevelsForPrerequisites(AssaultMage.Archetypes.AssaultMage.BaseClass,
                                                CharacterClassRefs.MonkClass.Reference.GetBlueprint(), 1)
                .AddClassLevelsForPrerequisites(AssaultMage.Archetypes.AssaultMage.BaseClass,
                                                CharacterClassRefs.WizardClass.Reference.GetBlueprint(), 1)
                .AddArcaneSpellFailureIncrease(-20)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Competence, false, StatType.Wisdom, 2)
                .Configure(delayed: true);



        }

        public static void ConfigureDisabled()
        {
            FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat).Configure();
        }


    }
}

