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
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
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
using Kingmaker.UI.MVVM._VM.CharGen.Phases.Class;
using Kingmaker.UI.GlobalMap.Temp;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UI.MVVM._VM.CharGen;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UI.ServiceWindow.CharacterScreen;
using Kingmaker.UI.MVVM._VM.CharGen.Phases.Spells;
using System.Collections.Generic;
using Kingmaker.UI.MVVM._VM.ServiceWindows.MythicInfo;
using Kingmaker.UI.MVVM._VM.CharGen.Phases.Total;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Mechanics.Components;
using UniRx;
using System.Reflection;
using TinyJson;

using BlueprintCore.Blueprints.CustomConfigurators;
using Kingmaker.Blueprints.Facts;


namespace AssaultMage
{
    public static class Main
    {
        public static bool Enabled;
        internal static readonly LogWrapper Logger = LogWrapper.Get("AssaultMage");
        public static bool isAssaultMageSelected = false;
        public static List<BlueprintAbility> SelectedClericSpells = new List<BlueprintAbility>();
        public static int SpellLevel = 0;
        public static int AssaultMageLevel = 0;


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
            static bool loaded = false;

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

            [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
            static void Postfix()
            {
                if (loaded) return;
                loaded = true;

                AddPatches();

                /*
                var groetusFeature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("c3e4d5681906d5246ab8b0637b98cbfe");
                groetusFeature.ComponentsArray = groetusFeature.ComponentsArray
                    .Where(c => !(c is PrerequisiteFeature))
                    .ToArray();
                */
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
  
        [HarmonyPatch(typeof(CharGenClassPhaseVM))]
        public static class CharGenClassPhaseVM_Patch
        {
            [HarmonyPatch(nameof(CharGenClassPhaseVM.OnSelectorClassChanged), new Type[] { typeof(CharGenClassSelectorItemVM) }), HarmonyPrefix]
            public static bool Prefix(CharGenClassPhaseVM __instance, CharGenClassSelectorItemVM charClass)
            {
                isAssaultMageSelected = false;

                return true;
            }

            [HarmonyPatch(nameof(CharGenClassPhaseVM.OnSelectorArchetypeChanged), new Type[] { typeof(BlueprintArchetype) }), HarmonyPrefix]
            public static bool Prefix(CharGenClassPhaseVM __instance, BlueprintArchetype archetype)
            {
                isAssaultMageSelected = false;

                if (archetype != null && archetype.AssetGuid == BlueprintGuid.Parse(AssaultMage.Archetypes.AssaultMage.ArchtypeGuid))
                {
                    isAssaultMageSelected = true;
                }


                return true;
            }
        }

        public static void SetAssaultMageSelected(LevelUpController levelUpController)
        {
            isAssaultMageSelected = false;
            if (levelUpController != null && levelUpController.State != null && levelUpController.State.SelectedClass != null)
            {
                Main.Logger.Info("Selected class is " + levelUpController.State.SelectedClass.Name);

                if (levelUpController.TryGetSeletedArchetype() != null && levelUpController.TryGetSeletedArchetype().AssetGuid == BlueprintGuid.Parse(AssaultMage.Archetypes.AssaultMage.ArchtypeGuid))
                {
                    isAssaultMageSelected = true;
                    Main.Logger.Info("Assault Mage is selected.");
                }
            }
        }


        public static int LearnClericSpells(ref LevelUpController levelUpController)
        {
            int level = levelUpController.State.NextClassLevel;
            BlueprintSpellbook clericSpellbook = SpellbookRefs.ClericSpellbook.Reference.Get();
            int spellLevel = clericSpellbook.SpellsPerDay.Levels[level].Count.Length - 1;

            AssaultMageLevel = level;

            Spellbook AssaultMageSpellbook = null;

            foreach (Spellbook spellbook in levelUpController.State.Unit.Spellbooks)
            {
                if (isAssaultMageSelected && spellbook.Blueprint.AssetGuid == BlueprintGuid.Parse(AssaultMage.Archetypes.AssaultMage.ArchetypeSpellbookGuid))
                {
                    AssaultMageSpellbook = spellbook;
                }
            }

                    Main.Logger.Info("Next class level " + level);
            Main.Logger.Info("Next spell level " + spellLevel);


            //int lastKnownSpellIndex = levelUpController.State.Unit.GetSpellbook(CharacterClassRefs.ClericClass.Reference.Get()).m_KnownSpells.Length;
            SelectedClericSpells.Clear();
            Main.Logger.Info("SelectedClericSpells count after empty - " + SelectedClericSpells.Count);
            Main.Logger.Info("Cleric spellbooks count " + SpellListRefs.ClericSpellList.Reference.Get().SpellsByLevel[spellLevel].m_Spells.Count);

            for (int i = 0; i < SpellListRefs.ClericSpellList.Reference.Get().SpellsByLevel[spellLevel].m_Spells.Count; ++i)
            {
                BlueprintAbility spell = SpellListRefs.ClericSpellList.Reference.Get().SpellsByLevel[spellLevel].m_Spells.ElementAt(i).Get();

                Main.Logger.Info("Spell is " + spell.name);

                if (levelUpController != null && levelUpController.State != null && levelUpController.State.Unit != null &&
                    AssaultMageSpellbook != null)
                {
                    if (!AssaultMageSpellbook.IsKnown(spell))
                    {
                        AssaultMageSpellbook.AddKnown(spellLevel, spell);
                    }


                    Main.Logger.Info("Learn spell " + spell.name);
                    SelectedClericSpells.Add(spell);
                }
            }

            Main.Logger.Info("SelectedClericSpells count - " + SelectedClericSpells.Count);

            return spellLevel;
        }

        [HarmonyPatch(typeof(CharGenSpellsPhaseVM))]
        public static class CharGenSpellsPhaseVM_Patch
        {
            [HarmonyPatch(nameof(CharGenSpellsPhaseVM.UpdateSelection), new Type[] {typeof(SpellSelectionData) }), HarmonyPrefix]
            public static bool Prefix(CharGenSpellsPhaseVM __instance, SpellSelectionData selectionData)
            {
                Main.Logger.Info("CharGenSpellsPhaseVM UpdateSelection");
                return true;
            }

            [HarmonyPatch(nameof(CharGenSpellsPhaseVM.OnBeginDetailedView)), HarmonyPrefix]
            public static bool Prefix(CharGenSpellsPhaseVM __instance)
            {
                Main.Logger.Info("CharGenSpellsPhaseVM OnBeginDetailedView");
                return true;
            }


            [HarmonyPatch(nameof(CharGenSpellsPhaseVM.CreateSpellbookVM)), HarmonyPrefix]
            public static bool Prefix2(CharGenSpellsPhaseVM __instance)
            {
                Main.Logger.Info("CharGenSpellsPhaseVM CreateSpellbookVM");
                return true;
            }

            [HarmonyPatch(nameof(CharGenSpellsPhaseVM.CreateSpellVMsCollection), new Type[] { typeof(LevelUpController), typeof(BlueprintSpellList) }), HarmonyPrefix]
            public static bool Prefix(CharGenSpellsPhaseVM __instance, ref LevelUpController levelUpController, BlueprintSpellList spellSelectionSpellList)
            {
                Main.Logger.Info("CharGenSpellsPhaseVM CreateSpellVMsCOllection");

                SetAssaultMageSelected(levelUpController);

                foreach(var sp in levelUpController.State.Unit.m_Spellbooks)
                {
                    Main.Logger.Info("Spellbook blueprint is " + sp.Key.name);

                    BlueprintSpellsTable spt = sp.Key.m_SpellSlots.Get();

                    if (spt != null && spt.Levels != null)
                    {
                        for (int i = 0; i < spt.Levels.Length; ++i)
                        {
                            for (int j = 0; j < spt.Levels[i].Count.Length; ++j)
                            {
                                Main.Logger.Info("Count " + j + " value " + spt.Levels[i].Count[j]);
                            }
                        }
                    }
                }

                if (isAssaultMageSelected)
                {
                    SpellLevel = LearnClericSpells(ref levelUpController);

                } else
                {
                    SelectedClericSpells.Empty();
                }

                Main.Logger.Info("End CharGenSpellsPhaseVM CreateSpellVMsCOllection");

                return true;
            }

            [HarmonyPatch(nameof(CharGenSpellsPhaseVM.OnChangedSelectedSpellsCount), new Type[] { typeof(int)}), HarmonyPrefix]
            public static bool Prefix(CharGenSpellsPhaseVM __instance, int count)
            {
                Main.Logger.Info("In CharGenSpellsPhaseVM.OnChangedSelectedSpellsCount");
                Main.Logger.Info("Count " + count);
                Main.Logger.Info("MechanicSelectedSpells " + __instance.MechanicSelectedSpells.Length);

                return true;
            }

            [HarmonyPatch(nameof(CharGenSpellsPhaseVM.MechanicSelectedSpellsChanged),new Type[] { typeof(BlueprintAbility[]) }), HarmonyPrefix]
            public static bool Prefix(CharGenSpellsPhaseVM __instance, BlueprintAbility[] selectedSpells)
            {
                Main.Logger.Info("In CharGenSpellsPhaseVM.MechanicSelectedSpellsChanged");

                return true;
            }

            [HarmonyPatch(nameof(CharGenSpellsPhaseVM.CheckIsCompleted)), HarmonyPrefix]
            public static bool Prefix3(CharGenSpellsPhaseVM __instance)
            {
                Main.Logger.Info("CharGenSpellsPhaseVM.CheckIsCompleted");

                return true;
            }
        }

        [HarmonyPatch(typeof(CharInfoSpellTableVM))]
        public static class CharInfoSpellTableVM_Patch
        {
            [HarmonyPatch(MethodType.Constructor, new Type[] { typeof(Spellbook) }), HarmonyPrefix]
            public static bool Prefix(CharInfoSpellTableVM __instance, ref Spellbook spellbook)
            {
                Main.Logger.Info("CharInfoSpellTableVM constructor");

                return true;
            }

            [HarmonyPatch(MethodType.Constructor, new Type[] { typeof(Spellbook) }), HarmonyPostfix]
            public static void Postfix(CharInfoSpellTableVM __instance, ref Spellbook spellbook)
            {
                Main.Logger.Info("CharInfoSpellTableVM constructor postfix");

                return;
            }
        }

        [HarmonyPatch(typeof(SpellSelectionData))]
        public static class ApplySpellbook_Patch
        {
            [HarmonyPatch(nameof(SpellSelectionData.SetLevelSpells), new Type[] { typeof(int), typeof(int) } ), HarmonyPrefix]
            public static bool Prefix(SpellSelectionData __instance, int level, int count)
            {
                Main.Logger.Info("SpellSelectionData.SetLevelSpells");

                return true;
            }
        }

        [HarmonyPatch(typeof(CharInfoSpellTableListVM))]
        public static class CharInfoSpellTableListVM_Patch
        {
            [HarmonyPatch(nameof(CharInfoSpellTableListVM.RefreshData)), HarmonyPrefix]
            public static bool Prefix_2(CharInfoSpellTableListVM __instance)
            {
                Main.Logger.Info("CharInfoSpellTableListVM.RefreshData");


                return true;
            }

        }

        [HarmonyPatch(typeof(CharGenTotalPhaseVM))]
        public static class CharGenTotalPhaseVM_Patch
        {
            [HarmonyPatch(nameof(CharGenTotalPhaseVM.CreateLevelupInfoParts), new Type[] { typeof(LevelUpController)}), HarmonyPrefix]
            public static bool Prefix(CharGenTotalPhaseVM __instance, LevelUpController levelUpController)
            {
                Main.Logger.Info("CharGenTotalPhaseVM.CreateLevelupInfoParts");
                
                if (__instance.UnitDescriptor != null && __instance.UnitDescriptor.Value != null && __instance.UnitDescriptor.Value.Spellbooks!=null)
                {
                    foreach (Spellbook spellbook in __instance.UnitDescriptor.Value.Spellbooks)
                    {
                        if (isAssaultMageSelected && spellbook.Blueprint.AssetGuid == BlueprintGuid.Parse(AssaultMage.Archetypes.AssaultMage.ArchetypeSpellbookGuid))
                        {
                            for (int i = 0; i < SelectedClericSpells.Count; ++i)
                            {
                                if (!spellbook.IsKnown(SelectedClericSpells.ElementAt(i)))
                                {
                                    spellbook.AddKnown(SpellLevel, SelectedClericSpells.ElementAt(i));
                                }
                            }
                        }
                    }
                }


                return true;
            }
        }

        [HarmonyPatch(typeof(CharGenContextVM))]
        public static class CharGenContextVM_Patch
        {
            [HarmonyPatch(nameof(CharGenContextVM.CompleteCharGen)), HarmonyPrefix]
            public static bool CompleteCharGen_Patch(ref CharGenContextVM __instance)
            {
                Main.Logger.Info("CharGenContextVM.CompleteCharGen");
                Main.Logger.Info("Assault Mage selected - " + isAssaultMageSelected);

                if (isAssaultMageSelected)
                {
                    //__instance.m_LevelUpController.Unit.DemandSpellbook(AssaultMage.Archetypes.AssaultMage.AssaultMageSpellbook);
                    //__instance.m_LevelUpController.Unit.DemandSpellbook(SpellbookRefs.WizardSpellbook.Reference.Get());
                    __instance.m_LevelUpController.Unit.DemandSpellbook(AssaultMage.Archetypes.AssaultMage.AssaultMageArchetype.m_ReplaceSpellbook.Get());
                }


                if (__instance.m_LevelUpController != null && __instance.m_LevelUpController.Unit != null &&
                    __instance.m_LevelUpController.Unit.Spellbooks != null)
                {
                    foreach (Spellbook spellbook in __instance.m_LevelUpController.Unit.Spellbooks)
                    {
                        if (isAssaultMageSelected && spellbook.Blueprint.AssetGuid == BlueprintGuid.Parse(AssaultMage.Archetypes.AssaultMage.ArchetypeSpellbookGuid))
                        {
                            for (int i = 0; i < SelectedClericSpells.Count; ++i)
                            {
                                if (!spellbook.IsKnown(SelectedClericSpells.ElementAt(i)))
                                {
                                    spellbook.AddKnown(SpellLevel, SelectedClericSpells.ElementAt(i));
                                    Main.Logger.Info("Added spell " + SelectedClericSpells.ElementAt(i).name);
                                }
                            }
                        }
                    }
                }

                //__instance.m_LevelUpController.Commit();
                return true;
            }

            [HarmonyPatch(nameof(CharGenContextVM.CompleteLevelUp)), HarmonyPrefix]
            public static bool CompleteLevelUp_Prefix(CharGenContextVM __instance)
            {
                Main.Logger.Info("CharGenContextVM.CompleteLevelUp");

                if (isAssaultMageSelected)
                {
                    //__instance.m_LevelUpController.Unit.DemandSpellbook(AssaultMage.Archetypes.AssaultMage.AssaultMageSpellbook);
                    //__instance.m_LevelUpController.Unit.DemandSpellbook(SpellbookRefs.WizardSpellbook.Reference.Get());
                    __instance.m_LevelUpController.Unit.DemandSpellbook(AssaultMage.Archetypes.AssaultMage.AssaultMageArchetype.m_ReplaceSpellbook.Get());
                }


                if (__instance.m_LevelUpController != null && __instance.m_LevelUpController.Unit != null &&
                    __instance.m_LevelUpController.Unit.Spellbooks != null)
                {
                    foreach (Spellbook spellbook in __instance.m_LevelUpController.Unit.Spellbooks)
                    {
                        if (isAssaultMageSelected && spellbook.Blueprint.AssetGuid == BlueprintGuid.Parse(AssaultMage.Archetypes.AssaultMage.ArchetypeSpellbookGuid))
                        {
                            for (int i = 0; i < SelectedClericSpells.Count; ++i)
                            {
                                if (!spellbook.IsKnown(SelectedClericSpells.ElementAt(i)))
                                {
                                    spellbook.AddKnown(SpellLevel, SelectedClericSpells.ElementAt(i));
                                    Main.Logger.Info("Added spell " + SelectedClericSpells.ElementAt(i).name);
                                }
                            }
                        }
                    }
                }

                return true;
            }
        }*/
        
        public static void AddPatches()
        {
            BlueprintCharacterClassReference ClericClassRef = BlueprintReferenceBase.CreateTyped<BlueprintCharacterClassReference>(ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("67819271767a9dd4fbfd4ae700befea0")));
            BlueprintArchetypeReference AssaultMageArchetypeRef = BlueprintReferenceBase.CreateTyped<BlueprintArchetypeReference>(ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse(AssaultMage.Archetypes.AssaultMage.ArchtypeGuid)));
            BlueprintSpellbookReference AssaultMageSpellbookRef = BlueprintReferenceBase.CreateTyped<BlueprintSpellbookReference>(ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse(AssaultMage.Archetypes.AssaultMage.ArchetypeSpellbookGuid)));
            //BlueprintAbilityReference AssaultMageItemBondRef = BlueprintReferenceBase.CreateTyped<BlueprintAbilityReference>(ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse(Feats.SuperDodge.ItemBondFeatureGuid)));

            // ArcanePoolResourse
            BlueprintAbilityResource ArcanePoolResourse = (BlueprintAbilityResource)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("effc3e386331f864e9e06d19dc218b37"));

            List<BlueprintCharacterClassReference> ArcanePoolResourse_m_ClassDiv = ArcanePoolResourse.m_MaxAmount.m_ClassDiv.ToList<BlueprintCharacterClassReference>();
            ArcanePoolResourse_m_ClassDiv.Add(ClericClassRef);

            ArcanePoolResourse.m_MaxAmount.m_ClassDiv = ArcanePoolResourse_m_ClassDiv.ToArray();

            List<BlueprintArchetypeReference> ArcanePoolResourse_m_ArchetypesDiv = ArcanePoolResourse.m_MaxAmount.m_ArchetypesDiv.ToList<BlueprintArchetypeReference>();
            ArcanePoolResourse_m_ArchetypesDiv.Add(AssaultMageArchetypeRef);

            ArcanePoolResourse.m_MaxAmount.m_ArchetypesDiv = ArcanePoolResourse_m_ArchetypesDiv.ToArray();

            // ArcanistArcaneReservoirResource
            BlueprintAbilityResource ArcanistArcaneReservoirResource = (BlueprintAbilityResource)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("cac948cbbe79b55459459dd6a8fe44ce"));

            List<BlueprintCharacterClassReference> ArcanistArcaneReservoirResource_m_ClassDiv = ArcanistArcaneReservoirResource.m_MaxAmount.m_ClassDiv.ToList<BlueprintCharacterClassReference>();
            ArcanistArcaneReservoirResource_m_ClassDiv.Add(ClericClassRef);

            ArcanistArcaneReservoirResource.m_MaxAmount.m_ClassDiv = ArcanistArcaneReservoirResource_m_ClassDiv.ToArray();

            List<BlueprintArchetypeReference> ArcanistArcaneReservoirResource_m_ArchetypesDiv = ArcanistArcaneReservoirResource.m_MaxAmount.m_ArchetypesDiv.ToList<BlueprintArchetypeReference>();
            ArcanistArcaneReservoirResource_m_ArchetypesDiv.Add(AssaultMageArchetypeRef);

            ArcanistArcaneReservoirResource.m_MaxAmount.m_ArchetypesDiv = ArcanistArcaneReservoirResource_m_ArchetypesDiv.ToArray();

            
            // ArcanistArcaneReservoirCLBuff
            BlueprintBuff ArcanistArcaneReservoirCLBuff = (BlueprintBuff)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("33e0c3a2a54c0e7489fa4ec4d79a581b"));

            List<BlueprintSpellbookReference> ArcanistArcaneReservoirCLBuff_m_Spellbooks =
                ArcanistArcaneReservoirCLBuff.GetComponent<AddAbilityUseTrigger>()
                .m_Spellbooks
                .ToList<BlueprintSpellbookReference>();

            ArcanistArcaneReservoirCLBuff_m_Spellbooks.Add(AssaultMageSpellbookRef);

            ArcanistArcaneReservoirCLBuff.GetComponent<AddAbilityUseTrigger>().m_Spellbooks = ArcanistArcaneReservoirCLBuff_m_Spellbooks.ToArray();

            List<BlueprintSpellbookReference> ArcanistArcaneReservoirCLBuff_cl_m_Spellbooks =
                ArcanistArcaneReservoirCLBuff.GetComponent<AddCasterLevelForSpellbook>()
                .m_Spellbooks
                .ToList<BlueprintSpellbookReference>();

            ArcanistArcaneReservoirCLBuff_cl_m_Spellbooks.Add(AssaultMageSpellbookRef);

            ArcanistArcaneReservoirCLBuff.GetComponent<AddCasterLevelForSpellbook>().m_Spellbooks = ArcanistArcaneReservoirCLBuff_cl_m_Spellbooks.ToArray();

            // ArcanistArcaneReservoirCLPotentBuff
            BlueprintBuff ArcanistArcaneReservoirCLPotentBuff = (BlueprintBuff)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("ea01ddf2c1878354990000d1c7fc5ce4"));

            List<BlueprintSpellbookReference> ArcanistArcaneReservoirCLPotentBuff_m_Spellbooks =
                ArcanistArcaneReservoirCLPotentBuff.GetComponent<AddAbilityUseTrigger>()
                .m_Spellbooks
                .ToList<BlueprintSpellbookReference>();

            ArcanistArcaneReservoirCLPotentBuff_m_Spellbooks.Add(AssaultMageSpellbookRef);

            ArcanistArcaneReservoirCLPotentBuff.GetComponent<AddAbilityUseTrigger>().m_Spellbooks = ArcanistArcaneReservoirCLPotentBuff_m_Spellbooks.ToArray();

            List<BlueprintSpellbookReference> ArcanistArcaneReservoirCLPotentBuff_cl_m_Spellbooks =
                ArcanistArcaneReservoirCLPotentBuff.GetComponent<AddCasterLevelForSpellbook>()
                .m_Spellbooks
                .ToList<BlueprintSpellbookReference>();

            ArcanistArcaneReservoirCLPotentBuff_cl_m_Spellbooks.Add(AssaultMageSpellbookRef);

            ArcanistArcaneReservoirCLPotentBuff.GetComponent<AddCasterLevelForSpellbook>().m_Spellbooks = ArcanistArcaneReservoirCLPotentBuff_cl_m_Spellbooks.ToArray();

           
            // ArcanistArcaneReservoirDCBuff
            BlueprintBuff ArcanistArcaneReservoirDCBuff = (BlueprintBuff)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("db4b91a8a297c4247b13cfb6ea228bf3"));

            List<BlueprintSpellbookReference> ArcanistArcaneReservoirDCBuff_m_Spellbooks =
                ArcanistArcaneReservoirDCBuff.GetComponent<AddAbilityUseTrigger>()
                .m_Spellbooks
                .ToList<BlueprintSpellbookReference>();

            ArcanistArcaneReservoirDCBuff_m_Spellbooks.Add(AssaultMageSpellbookRef);

            ArcanistArcaneReservoirDCBuff.GetComponent<AddAbilityUseTrigger>().m_Spellbooks = ArcanistArcaneReservoirDCBuff_m_Spellbooks.ToArray();

            List<BlueprintSpellbookReference> ArcanistArcaneReservoirDCBuff_cl_m_Spellbooks =
                ArcanistArcaneReservoirDCBuff.GetComponent<IncreaseSpellSpellbookDC>()
                .m_Spellbooks
                .ToList<BlueprintSpellbookReference>();

            ArcanistArcaneReservoirDCBuff_cl_m_Spellbooks.Add(AssaultMageSpellbookRef);

            ArcanistArcaneReservoirDCBuff.GetComponent<IncreaseSpellSpellbookDC>().m_Spellbooks = ArcanistArcaneReservoirDCBuff_cl_m_Spellbooks.ToArray();

            // ArcanistArcaneReservoirDCPotentBuff
            BlueprintBuff ArcanistArcaneReservoirDCPotentBuff = (BlueprintBuff)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("6fea993ed5782054a88fa54037a3e6dd"));

            List<BlueprintSpellbookReference> ArcanistArcaneReservoirDCPotentBuff_m_Spellbooks =
                ArcanistArcaneReservoirDCPotentBuff.GetComponent<AddAbilityUseTrigger>()
                .m_Spellbooks
                .ToList<BlueprintSpellbookReference>();

            ArcanistArcaneReservoirDCPotentBuff_m_Spellbooks.Add(AssaultMageSpellbookRef);

            ArcanistArcaneReservoirDCPotentBuff.GetComponent<AddAbilityUseTrigger>().m_Spellbooks = ArcanistArcaneReservoirDCPotentBuff_m_Spellbooks.ToArray();

            List<BlueprintSpellbookReference> ArcanistArcaneReservoirDCPotentBuff_cl_m_Spellbooks =
                ArcanistArcaneReservoirDCPotentBuff.GetComponent<IncreaseSpellSpellbookDC>()
                .m_Spellbooks
                .ToList<BlueprintSpellbookReference>();

            ArcanistArcaneReservoirDCPotentBuff_cl_m_Spellbooks.Add(AssaultMageSpellbookRef);

            ArcanistArcaneReservoirDCPotentBuff.GetComponent<IncreaseSpellSpellbookDC>().m_Spellbooks = ArcanistArcaneReservoirDCPotentBuff_cl_m_Spellbooks.ToArray();

            // ArcanistArcaneReservoirResourceBuff
            BlueprintBuff ArcanistArcaneReservoirResourceBuff = (BlueprintBuff)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("1dd776b7b27dcd54ab3cedbbaf440cf3"));

            List<BlueprintArchetypeReference> ArcanistArcaneReservoirResourceBuff_m_AdditionalArchetypes =
                ArcanistArcaneReservoirResourceBuff.GetComponent<ContextRankConfig>()
                .m_AdditionalArchetypes
                .ToList<BlueprintArchetypeReference>();

            ArcanistArcaneReservoirResourceBuff_m_AdditionalArchetypes.Add(AssaultMageArchetypeRef);

            ArcanistArcaneReservoirResourceBuff.GetComponent<ContextRankConfig>()
                .m_AdditionalArchetypes = ArcanistArcaneReservoirResourceBuff_m_AdditionalArchetypes.ToArray();

            List<BlueprintCharacterClassReference> ArcanistArcaneReservoirResourceBuff_m_Class =
                ArcanistArcaneReservoirResourceBuff.GetComponent<ContextRankConfig>()
                .m_Class
                .ToList<BlueprintCharacterClassReference>();

            ArcanistArcaneReservoirResourceBuff_m_Class.Add(ClericClassRef);

            ArcanistArcaneReservoirResourceBuff.GetComponent<ContextRankConfig>()
                .m_Class = ArcanistArcaneReservoirResourceBuff_m_Class.ToArray();

            
            // DimensionStrikeFeature
            BlueprintFeature DimensionStrikeFeature = (BlueprintFeature)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("cb6916027e3c25e4185de068249254dc"));

            PrerequisiteClassLevel PrerequisiteClass = new PrerequisiteClassLevel();
            PrerequisiteClass.m_CharacterClass = ClericClassRef;
            PrerequisiteClass.Level = 9;

            PrerequisiteArchetypeLevel PrerequisiteArchetype = new PrerequisiteArchetypeLevel();
            PrerequisiteArchetype.m_CharacterClass = ClericClassRef;
            PrerequisiteArchetype.m_Archetype = AssaultMageArchetypeRef;
            PrerequisiteArchetype.Level = 9;

            DimensionStrikeFeature.AddComponents(PrerequisiteClass, PrerequisiteArchetype);

            // EnhancePotion
            BlueprintFeature EnhancePotion = (BlueprintFeature)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("2673ccdd6df742d42a8c94977c76a984"));

            List<BlueprintCharacterClassReference> EnhancePotion_m_Class = EnhancePotion.GetComponent<EnhancePotion>().m_Classes.ToList();
            EnhancePotion_m_Class.Add(ClericClassRef);

            EnhancePotion.GetComponent<EnhancePotion>().m_Classes = EnhancePotion_m_Class.ToArray();

            List<BlueprintArchetypeReference> EnhancePotion_m_Archetypes = EnhancePotion.GetComponent<EnhancePotion>().m_Archetypes.ToList();
            EnhancePotion_m_Archetypes.Add(AssaultMageArchetypeRef);

            EnhancePotion.GetComponent<EnhancePotion>().m_Archetypes = EnhancePotion_m_Archetypes.ToArray();


            // ItemBondAbility is not patched as ItemBondAbility.GetComponent<AbilityRestoreSpellSlot>().SpellbooksReference is not found
            // ItemBondAbility
            /*BlueprintAbility ItemBondAbility = (BlueprintAbility)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("e5dcf71e02e08fc448d9745653845df1"));
            foreach (BlueprintComponent com in ItemBondAbility.ComponentsArray)
            {
                if (com.name == "$AbilityRestoreSpellSlot$315be1da-597c-40bb-838b-f1bdf4955cde")
                {
                   
                    ((AbilityRestoreSpellSlot)com).
                }
            }*/

            // ItemBondAbility will use WMT to modify

            // ItemBondFeature
            BlueprintFeature ItemBondFeature = (BlueprintFeature)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("2fb5e65bd57caa943b45ee32d825e9b9"));
            ItemBondFeature.GetComponent<AddAbilityResources>().Amount = 1;
            ItemBondFeature.GetComponent<AddAbilityResources>().RestoreAmount = true;
            

            // PowerfulChangeBuff
            BlueprintBuff PowerfulChangeBuff = (BlueprintBuff)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("be5d23755e7e501448193bbbd71c5256"));

            List<BlueprintSpellbookReference> PowerfulChangeBuff_m_Spellbooks = PowerfulChangeBuff.GetComponent<AddAbilityUseTrigger>().m_Spellbooks.ToList();
            PowerfulChangeBuff_m_Spellbooks.Add(AssaultMageSpellbookRef);

            PowerfulChangeBuff.GetComponent<AddAbilityUseTrigger>().m_Spellbooks = PowerfulChangeBuff_m_Spellbooks.ToArray();

            // PowerfulChangeBuffGreater
            BlueprintBuff PowerfulChangeBuffGreater = (BlueprintBuff)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("d6ccf420a9b196e4cae334e0d3ea9e8b"));

            List<BlueprintSpellbookReference> PowerfulChangeBuffGreater_m_Spellbooks = PowerfulChangeBuffGreater.GetComponent<AddAbilityUseTrigger>().m_Spellbooks.ToList();
            PowerfulChangeBuffGreater_m_Spellbooks.Add(AssaultMageSpellbookRef);

            PowerfulChangeBuffGreater.GetComponent<AddAbilityUseTrigger>().m_Spellbooks = PowerfulChangeBuffGreater_m_Spellbooks.ToArray();


            // ShareTransmutationBuff
            BlueprintBuff ShareTransmutationBuff = (BlueprintBuff)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("2231eb5d1a5a48d499a20fa5bde7a4e2"));

            List<BlueprintSpellbookReference> ShareTransmutationBuff_m_Spellbooks = ShareTransmutationBuff.GetComponent<AddAbilityUseTrigger>().m_Spellbooks.ToList();
            ShareTransmutationBuff_m_Spellbooks.Add(AssaultMageSpellbookRef);

            ShareTransmutationBuff.GetComponent<AddAbilityUseTrigger>().m_Spellbooks = ShareTransmutationBuff_m_Spellbooks.ToArray();

            // ShareTransmutationBuffGreater
            BlueprintBuff ShareTransmutationBuffGreater = (BlueprintBuff)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("e0d4e42a41a0a24459a1bfc4f0a3ae4c"));

            List<BlueprintSpellbookReference> ShareTransmutationBuffGreater_m_Spellbooks = ShareTransmutationBuffGreater.GetComponent<AddAbilityUseTrigger>().m_Spellbooks.ToList();
            ShareTransmutationBuffGreater_m_Spellbooks.Add(AssaultMageSpellbookRef);

            ShareTransmutationBuffGreater.GetComponent<AddAbilityUseTrigger>().m_Spellbooks = ShareTransmutationBuffGreater_m_Spellbooks.ToArray();

            // SpecialisationSchoolUniversalistProgression
            BlueprintProgression SpecialisationSchoolUniversalistProgression = (BlueprintProgression)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("0933849149cfc9244ac05d6a5b57fd80"));

            List<BlueprintProgression.ClassWithLevel> SpecialisationSchoolUniversalistProgression_m_Class = SpecialisationSchoolUniversalistProgression.m_Classes.ToList();
            BlueprintProgression.ClassWithLevel ClassWithLevel = new BlueprintProgression.ClassWithLevel();
            ClassWithLevel.AdditionalLevel = 0;
            ClassWithLevel.m_Class = ClericClassRef;
            SpecialisationSchoolUniversalistProgression_m_Class.Add(ClassWithLevel);

            SpecialisationSchoolUniversalistProgression.m_Classes = SpecialisationSchoolUniversalistProgression_m_Class.ToArray();

            List<BlueprintProgression.ArchetypeWithLevel> SpecialisationSchoolUniversalistProgression_m_Archetypes = SpecialisationSchoolUniversalistProgression.m_Archetypes.ToList();
            BlueprintProgression.ArchetypeWithLevel ArchetypeWithLevel = new BlueprintProgression.ArchetypeWithLevel();
            ArchetypeWithLevel.AdditionalLevel = 0;
            ArchetypeWithLevel.m_Archetype = AssaultMageArchetypeRef;

            SpecialisationSchoolUniversalistProgression_m_Archetypes.Add(ArchetypeWithLevel);

            SpecialisationSchoolUniversalistProgression.m_Archetypes = SpecialisationSchoolUniversalistProgression_m_Archetypes.ToArray();

            // SpellMasterFocusedSpellsBuff
            BlueprintBuff SpellMasterFocusedSpellsBuff = (BlueprintBuff)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("967de73c1def41f79678bbe3116f2770"));

            List<BlueprintSpellbookReference> SpellMasterFocusedSpellsBuff_m_Spellbooks = SpellMasterFocusedSpellsBuff.GetComponent<AddCasterLevelForSpellbook>().m_Spellbooks.ToList();
            SpellMasterFocusedSpellsBuff_m_Spellbooks.Add(AssaultMageSpellbookRef);

            SpellMasterFocusedSpellsBuff.GetComponent<AddCasterLevelForSpellbook>().m_Spellbooks = SpellMasterFocusedSpellsBuff_m_Spellbooks.ToArray();

            // SpellMasterFocusedSpellsResource
            BlueprintAbilityResource SpellMasterFocusedSpellsResource = (BlueprintAbilityResource)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("32947324b3054fdea55092735de9c82c"));

            List<BlueprintCharacterClassReference> SpellMasterFocusedSpellsResource_m_Class = SpellMasterFocusedSpellsResource.m_MaxAmount.m_Class.ToList();
            SpellMasterFocusedSpellsResource_m_Class.Add(ClericClassRef);

            SpellMasterFocusedSpellsResource.m_MaxAmount.m_Class = SpellMasterFocusedSpellsResource_m_Class.ToArray();
            SpellMasterFocusedSpellsResource.m_MaxAmount.m_ClassDiv = SpellMasterFocusedSpellsResource_m_Class.ToArray();

            List<BlueprintArchetypeReference> SpellMasterFocusedSpellsResource_m_Archetypes = SpellMasterFocusedSpellsResource.m_MaxAmount.m_Archetypes.ToList();
            SpellMasterFocusedSpellsResource_m_Archetypes.Add(AssaultMageArchetypeRef);

            SpellMasterFocusedSpellsResource.m_MaxAmount.m_Archetypes = SpellMasterFocusedSpellsResource_m_Archetypes.ToArray();
            SpellMasterFocusedSpellsResource.m_MaxAmount.m_ArchetypesDiv = SpellMasterFocusedSpellsResource_m_Archetypes.ToArray();

            // UniversalistSchoolGreaterResource
            BlueprintAbilityResource UniversalistSchoolGreaterResource = (BlueprintAbilityResource)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("42fd5b455f986f94293b15b13f38d6a5"));

            List<BlueprintCharacterClassReference> UniversalistSchoolGreaterResource_m_Class = UniversalistSchoolGreaterResource.m_MaxAmount.m_Class.ToList();
            UniversalistSchoolGreaterResource_m_Class.Add(ClericClassRef);

            UniversalistSchoolGreaterResource.m_MaxAmount.m_Class = UniversalistSchoolGreaterResource_m_Class.ToArray();
            UniversalistSchoolGreaterResource.m_MaxAmount.m_ClassDiv = UniversalistSchoolGreaterResource_m_Class.ToArray();

            List<BlueprintArchetypeReference> UniversalistSchoolGreaterResource_m_Archetypes = UniversalistSchoolGreaterResource.m_MaxAmount.m_Archetypes.ToList();
            UniversalistSchoolGreaterResource_m_Archetypes.Add(AssaultMageArchetypeRef);

            UniversalistSchoolGreaterResource.m_MaxAmount.m_Archetypes = UniversalistSchoolGreaterResource_m_Archetypes.ToArray();
            UniversalistSchoolGreaterResource.m_MaxAmount.m_ArchetypesDiv = UniversalistSchoolGreaterResource_m_Archetypes.ToArray();
        }

        public static void AddChanges()
        {
            ArmorAttune.Configure();
            SuperDodge.Configure();
            AssaultMage.Archetypes.AssaultMage.Configure();

            BlueprintFeatureSelectMythicSpellbook AngelIncorporateSpellbook;
            BlueprintFeatureSelectMythicSpellbook LichIncorporateSpellbook;
            BlueprintSpellbookReference AssaultMageSpellBookReference;


            AngelIncorporateSpellbook = (BlueprintFeatureSelectMythicSpellbook)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("e1fbb0e0e610a3a4d91e5e5284587939"));
            LichIncorporateSpellbook = (BlueprintFeatureSelectMythicSpellbook)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("3f16e9caf7c683c40884c7c455ed26af"));
            AssaultMageSpellBookReference = AssaultMage.Archetypes.AssaultMage.AssaultMageSpellbook.ToReference<BlueprintSpellbookReference>();

            if (AngelIncorporateSpellbook != null)
            {
                Main.Logger.Info("Angel Spellbook found");

                AngelIncorporateSpellbook.m_AllowedSpellbooks = AngelIncorporateSpellbook.m_AllowedSpellbooks.AddToArray(SpellbookRefs.WizardSpellbook.Reference.Get().ToReference<BlueprintSpellbookReference>());

                if (AssaultMageSpellBookReference != null)
                {
                    Main.Logger.Info("Assault Mage Spellbook reference found");
                    AngelIncorporateSpellbook.m_AllowedSpellbooks = AngelIncorporateSpellbook.m_AllowedSpellbooks.AddToArray(AssaultMageSpellBookReference);
   
                    foreach (BlueprintSpellbookReference i in AngelIncorporateSpellbook.m_AllowedSpellbooks)
                    {
                        Main.Logger.Info("Spellbook allowed - " + i.GetBlueprint().name);
                    }
                }
            }
            else
            {
                Main.Logger.Info("Angel Spellbook not found");
            }

            if (LichIncorporateSpellbook != null)
            {
                Main.Logger.Info("Lich Spellbook found");

                if (AssaultMageSpellBookReference != null)
                {
                    Main.Logger.Info("Assault Mage Spellbook reference found");
                    LichIncorporateSpellbook.m_AllowedSpellbooks = LichIncorporateSpellbook.m_AllowedSpellbooks.AddToArray(AssaultMageSpellBookReference);

                    foreach (BlueprintSpellbookReference i in LichIncorporateSpellbook.m_AllowedSpellbooks)
                    {
                        Main.Logger.Info("Spellbook allowed - " + i.GetBlueprint().name);
                    }
                }
            }
            else
            {
                Main.Logger.Info("Lich Spellbook not found");
            }
        }
    }
}

