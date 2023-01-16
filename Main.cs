using AssaultMage.Feats;
using BlueprintCore.Blueprints.Configurators.Root;
using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.UI.MVVM._VM.ServiceWindows.CharacterInfo.Sections.Progression.Main;
using Kingmaker.UnitLogic;
using System;
using UnityModManagerNet;
using System.Linq;
using Kingmaker.UI.MVVM._VM.ServiceWindows.CharacterInfo.Sections.Progression.Spellbook;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.UI.MVVM._VM.ServiceWindows.CharacterInfo.Sections.Progression.Level;
using Kingmaker.Blueprints.Classes.Spells;
using UnityEngine;
using Kingmaker.Utility;
using Kingmaker.Blueprints;
using Kingmaker.UI.MVVM._VM.Tooltip.Templates;
using Kingmaker.UnitLogic.Class.LevelUp.Actions;
using Kingmaker.UnitLogic.Class.LevelUp;

namespace AssaultMage
{
    public static class Main
    {
        public static bool Enabled;
        internal static readonly LogWrapper Logger = LogWrapper.Get("AssaultMage");


        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                modEntry.OnToggle = OnToggle;
                var harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll();

                Logger.Info("Finished patching.");
            }
            catch (Exception e)
            {
                Logger.Error("Failed to patch", e);
            }
            return true;
        }

        public static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Enabled = value;
            return true;
        }

        [HarmonyPatch(typeof(BlueprintsCache))]
        static class BlueprintsCaches_Patch
        {
            private static bool Initialized = false;

            [HarmonyPriority(Priority.First)]
            [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
            static void Init()
            {
                try
                {
                    if (Initialized)
                    {
                        Logger.Info("Already configured blueprints.");
                        return;
                    }
                    Initialized = true;

                    Logger.Info("Configuring blueprints.");

                    AddChanges();
                }
                catch (Exception e)
                {
                    Logger.Error("Failed to configure blueprints.", e);
                }
            }
        }

        [HarmonyPatch(typeof(StartGameLoader))]
        static class StartGameLoader_Patch
        {
            private static bool Initialized = false;

            [HarmonyPatch(nameof(StartGameLoader.LoadPackTOC)), HarmonyPostfix]
            static void LoadPackTOC()
            {
                try
                {
                    if (Initialized)
                    {
                        Logger.Info("Already configured delayed blueprints.");
                        return;
                    }
                    Initialized = true;

                    RootConfigurator.ConfigureDelayedBlueprints();
                }
                catch (Exception e)
                {
                    Logger.Error("Failed to configure delayed blueprints.", e);
                }
            }
        }

        /*
        [HarmonyPatch(typeof(ClassProgressionVM), MethodType.Constructor, new Type[] { typeof(UnitDescriptor), typeof(ClassData) })]
        private static class ClassProgressionVM_Constructor_Patch
        {
            private static void Postfix(ClassProgressionVM __instance, UnitDescriptor unit, ClassData unitClass)
            {
                Main.Logger.Info("In ClassProgressionVM_Constructor_Patch");
                var Name = string.Join("/", unitClass.Archetypes.Select(a => a.Name));
                if (!string.IsNullOrEmpty(Name))
                {
                    __instance.Name = string.Join(" ", unitClass.CharacterClass.Name, $"({Name})");
                }

                Main.Logger.Info("Instance Name " + __instance.Name);

                BlueprintArchetype AssaultMageBP = unitClass.Archetypes.Where(a => a.AssetGuid == AssaultMage.Archetypes.AssaultMage.ArchtypeGuid).FirstOrDefault();
                if (AssaultMageBP != null)
                {
                    Main.Logger.Info("Assault Mage selected.");
                }
                else
                {
                    Main.Logger.Info("Assault Mage NOT selected");
                }
            }
        }*/
        /*
        [HarmonyPatch(typeof(SpellbookProgressionVM),MethodType.Constructor, new Type[] {typeof(BlueprintCharacterClass), 
                                                                                         typeof(BlueprintArchetype), typeof(UnitDescriptor),
                                                                                         typeof(LevelProgressionVM)})]
        private static class SpellbookProgressionVM_Constructor_Patch
        {
            private static void Postfix(SpellbookProgressionVM __instance, BlueprintCharacterClass unitClass, BlueprintArchetype unitArchetype, UnitDescriptor unit, LevelProgressionVM levelProgressionVM)
            {
                Main.Logger.Info("In SpellbookProgressionVM_Constructor_Patch postfix");
                if (unitArchetype && unitArchetype.AssetGuid == AssaultMage.Archetypes.AssaultMage.ArchtypeGuid)
                {
                    Main.Logger.Info("Assault Mage Wizard spellbook.");
                    unit.DemandSpellbook((BlueprintSpellbook)SpellbookRefs.WizardSpellbook.Reference.GetBlueprint());
  
                    BlueprintSpellbook blueprintSpellbook;
                    if (unitArchetype == null)
                    {
                        blueprintSpellbook = null;
                    }
                    else
                    {
                        BlueprintArchetype blueprintArchetype = unitArchetype.Or(null);
                        blueprintSpellbook = ((blueprintArchetype != null) ? unit.m_Spellbooks.Where(a => a.Key.CharacterClass.Name == "Wizard").FirstOrDefault().Key : null);
                    }
                    BlueprintSpellbook blueprintSpellbook2;
                    if ((blueprintSpellbook2 = blueprintSpellbook) == null)
                    {
                        BlueprintCharacterClass blueprintCharacterClass = unit.m_Spellbooks.Where(a => a.Key.CharacterClass.Name == "Wizard").FirstOrDefault().Key.CharacterClass;
                        blueprintSpellbook2 = ((blueprintCharacterClass != null) ? unit.m_Spellbooks.Where(a => a.Key.CharacterClass.Name == "Wizard").FirstOrDefault().Key : null);
                    }
                    BlueprintSpellbook blueprintSpellbook3 = blueprintSpellbook2;
                    bool? flag;
                    if (unitArchetype == null)
                    {
                        flag = null;
                    }
                    else
                    {
                        BlueprintArchetype blueprintArchetype2 = null;//unitArchetype.Or(null);
                        flag = ((blueprintArchetype2 != null) ? new bool?(blueprintArchetype2.RemoveSpellbook) : null);
                    }
                    bool? flag2 = flag;
                    if (flag2.GetValueOrDefault())
                    {
                        blueprintSpellbook3 = null;
                    }
                    if (blueprintSpellbook3 == null)
                    {
                        return;
                    }
                    int num = 0;
                    int num2 = 1;
                    while (num2 - blueprintSpellbook3.CasterLevelModifier <= Mathf.Min(blueprintSpellbook3.SpellsPerDay.Levels.Length, __instance.MaxLevel))
                    {
                        SpellsLevelEntry spellsLevelEntry = blueprintSpellbook3.SpellsPerDay.Levels.Get(num2, null) ?? blueprintSpellbook3.SpellsPerDay.Levels.LastItem<SpellsLevelEntry>();
                        int num3 = (spellsLevelEntry != null) ? (spellsLevelEntry.Count.Length - 1) : 0;
                        if (num3 != 0)
                        {
                            int? spellLevel = (num3 != num) ? new int?(num3) : null;
                            int level = num2 - blueprintSpellbook3.CasterLevelModifier;
                            SpellbookProgressionChupaChupsVM spellbookProgressionChupaChupsVM = __instance.MainChupaChupsList.LastOrDefault<SpellbookProgressionChupaChupsVM>();
                            SpellbookProgressionChupaChupsVM spellbookProgressionChupaChupsVM2 = new SpellbookProgressionChupaChupsVM(spellLevel, level, (spellbookProgressionChupaChupsVM != null) ? new int?(spellbookProgressionChupaChupsVM.Level) : null, new TooltipTemplateSpellbookProgressionEntry(new ClassInformation
                            {
                                Unit = unit,
                                Class = unit.m_Spellbooks.Where(a => a.Key.CharacterClass.Name == "Wizard").FirstOrDefault().Key.CharacterClass,
                                Archetype = null,
                                ClassLevel = new int?(num2 - blueprintSpellbook3.CasterLevelModifier)
                            }));
                            num = num3;
                            __instance.AddDisposable(spellbookProgressionChupaChupsVM2);
                            __instance.MainChupaChupsList.Add(spellbookProgressionChupaChupsVM2);
                        }
                        num2++;
                    }
                }    
            }
        }*/

        // Do not proceed the spell selection if the caster level was not changed
        /*[HarmonyPatch(typeof(ApplySpellbook), nameof(ApplySpellbook.Apply))]
        [HarmonyPatch(new Type[] { typeof(LevelUpState), typeof(UnitDescriptor) })]
        private static class ApplySpellbook_Apply_Patch
        {
            LevelUpController cont = new LevelUpController();

            cont.

                LevelUpState.CharBuildMode.
            public static bool Prefix(LevelUpState state, UnitDescriptor unit)
            {
                Main.Logger.Info("In applySpellbook");

                return true;
                /*
                if (state.SelectedClass == null)
                {
                    return false;
                }

                var component1 = state.SelectedClass.GetComponent<SkipLevelsForSpellProgression>();
                if (component1 != null && component1.Levels.Contains(state.NextClassLevel))
                {
                    return false;
                }

                var classData = unit.Progression.GetClassData(state.SelectedClass);
                if (classData?.Spellbook == null)
                {
                    return false;
                }

                var spellbook1 = unit.DemandSpellbook(classData.Spellbook);
                if (state.SelectedClass.Spellbook && state.SelectedClass.Spellbook != classData.Spellbook)
                {
                    var spellbook2 = unit.Spellbooks.FirstOrDefault(s => s.Blueprint == state.SelectedClass.Spellbook);
                    if (spellbook2 != null)
                    {
                        foreach (var allKnownSpell in spellbook2.GetAllKnownSpells())
                        {
                            spellbook1.AddKnown(allKnownSpell.SpellLevel, allKnownSpell.Blueprint);
                        }

                        unit.DeleteSpellbook(state.SelectedClass.Spellbook);
                    }
                }
                var casterLevelAfter = CasterHelpers.GetRealCasterLevel(unit, spellbook1.Blueprint); // Calculates based on progression which includes class selected in level up screen
                spellbook1.AddLevelFromClass(classData.CharacterClass); // This only adds one class at a time and will only ever increase by 1 or 2
                var casterLevelBefore = casterLevelAfter - (classData.CharacterClass.IsMythic ? 2 : 1); // Technically only needed to see if this is our first level of a casting class
                var spellSelectionData = state.DemandSpellSelection(spellbook1.Blueprint, spellbook1.Blueprint.SpellList);
                if (spellbook1.Blueprint.SpellsKnown != null)
                {
                    for (var index = 0; index <= 10; ++index)
                    {
                        var spellsKnown = spellbook1.Blueprint.SpellsKnown;
                        var expectedCount = spellsKnown.GetCount(casterLevelAfter, index);
                        var actual = CasterHelpers.GetCachedSpellsKnown(unit, spellbook1, index);
#if DEBUG
                        //Mod.Trace($"Spellbook {spellbook1.Blueprint.Name}: Granting {expectedCount-actual} spells of spell level:{index} based on expected={expectedCount} and actual={actual}");
#endif
                        spellSelectionData.SetLevelSpells(index, Math.Max(0, expectedCount - actual));
                    }
                }
                var maxSpellLevel = spellbook1.MaxSpellLevel;
                if (spellbook1.Blueprint.SpellsPerLevel > 0)
                {
                    if (casterLevelBefore == 0)
                    {
                        spellSelectionData.SetExtraSpells(0, maxSpellLevel);
                        spellSelectionData.ExtraByStat = true;
                        spellSelectionData.UpdateMaxLevelSpells(unit);
                    }
                    else
                    {
                        spellSelectionData.SetExtraSpells(spellbook1.Blueprint.SpellsPerLevel, maxSpellLevel);
                    }
                }
                foreach (var component2 in spellbook1.Blueprint.GetComponents<AddCustomSpells>())
                {
                    ApplySpellbook.TryApplyCustomSpells(spellbook1, component2, state, unit);
                }

                return false;
            }
        }*/



        public static void AddChanges()
        {
            //MyFeat.Configure();
            ArmorAttune.Configure();
            SuperDodge.Configure();
            AssaultMage.Archetypes.AssaultMage.Configure();
        }
    }
}

