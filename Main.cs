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
using Kingmaker.UI.MVVM._VM.CharGen.Phases.Class;
using Kingmaker.UI.GlobalMap.Temp;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UI.MVVM._VM.CharGen;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UI.ServiceWindow.CharacterScreen;
using Kingmaker.UI.MVVM._VM.CharGen.Phases.Spells;
using System.Collections.Generic;
using Kingmaker.UI.MVVM._VM.ServiceWindows.MythicInfo;
using Kingmaker.UI.MVVM._VM.CharGen.Phases.Total;

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
        

        public static void AddChanges()
        {
            ArmorAttune.Configure();
            SuperDodge.Configure();
            AssaultMage.Archetypes.AssaultMage.Configure();

            /*
            BlueprintFeatureSelectMythicSpellbook AngelIncorporateSpellbook;
            BlueprintFeatureSelectMythicSpellbook LichIncorporateSpellbook;
            BlueprintSpellbookReference AssaultMageSpellBookReference;


            AngelIncorporateSpellbook = (BlueprintFeatureSelectMythicSpellbook)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("e1fbb0e0e610a3a4d91e5e5284587939"));
            LichIncorporateSpellbook = (BlueprintFeatureSelectMythicSpellbook)ResourcesLibrary.TryGetBlueprint(BlueprintGuid.Parse("3f16e9caf7c683c40884c7c455ed26af"));
            AssaultMageSpellBookReference = AssaultMage.Archetypes.AssaultMage.AssaultMageSpellbook.ToReference<BlueprintSpellbookReference>();

            if (AngelIncorporateSpellbook != null)
            {
                Main.Logger.Info("Angel Spellbook found");

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
            */
        }
    }
}

