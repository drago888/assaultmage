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

namespace AssaultMage
{
    public static class Main
    {
        public static bool Enabled;
        internal static readonly LogWrapper Logger = LogWrapper.Get("AssaultMage");
        public static bool isAssaultMageSelected = false;
        public static List<BlueprintAbility> SelectedClericSpells = new List<BlueprintAbility>();
        public static int SpellLevel = 0;


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


        public static int LearnClericSpells(LevelUpController levelUpController)
        {
            int level = levelUpController.State.NextClassLevel;
            BlueprintSpellbook clericSpellbook = SpellbookRefs.ClericSpellbook.Reference.Get();
            int spellLevel = clericSpellbook.SpellsPerDay.Levels[level].Count.Length - 1;

            Main.Logger.Info("Next class level " + level);
            Main.Logger.Info("Next spell level " + spellLevel);


            int lastKnownSpellIndex = levelUpController.State.Unit.GetSpellbook(CharacterClassRefs.ClericClass.Reference.Get()).m_KnownSpells.Length;
            SelectedClericSpells.Clear();
            Main.Logger.Info("SelectedClericSpells count after empty - " + SelectedClericSpells.Count);
            Main.Logger.Info("Cleric spellbooks count " + SpellListRefs.ClericSpellList.Reference.Get().SpellsByLevel[spellLevel].m_Spells.Count);

            for (int i = 0; i < SpellListRefs.ClericSpellList.Reference.Get().SpellsByLevel[spellLevel].m_Spells.Count; ++i)
            {
                BlueprintAbility spell = SpellListRefs.ClericSpellList.Reference.Get().SpellsByLevel[spellLevel].m_Spells.ElementAt(i).Get();

                Main.Logger.Info("Spell is " + spell.name);

                if (levelUpController != null && levelUpController.State != null && levelUpController.State.Unit != null &&
                    levelUpController.State.Unit.GetSpellbook(CharacterClassRefs.ClericClass.Reference.Get()) != null)
                {
                    levelUpController.State.Unit.GetSpellbook(CharacterClassRefs.ClericClass.Reference.Get()).AddKnown(spellLevel, spell);

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
                int spellLevel = 0;

                if (isAssaultMageSelected)
                {
                    SpellLevel = LearnClericSpells(levelUpController);

                } else
                {
                    SelectedClericSpells.Empty();
                }

                if (levelUpController.State != null && levelUpController.State.Unit != null && 
                    levelUpController.State.Unit.GetSpellbook(CharacterClassRefs.ClericClass.Reference.Get())!=null &&
                    levelUpController.State.Unit.GetSpellbook(CharacterClassRefs.ClericClass.Reference.Get()).m_KnownSpells != null)
                {
                    levelUpController.State.Unit.GetSpellbook(CharacterClassRefs.ClericClass.Reference.Get()).m_KnownSpells[spellLevel].ForEach(
                        a =>
                        Main.Logger.Info("CharGenSpellsPhaseVM.CreateSpellVMsCollection known spells " + a.Name)
                     );
                }

                if (levelUpController != null && levelUpController.Unit != null &&
                    levelUpController.Unit.GetSpellbook(CharacterClassRefs.ClericClass.Reference.Get()) != null &&
                    levelUpController.Unit.GetSpellbook(CharacterClassRefs.ClericClass.Reference.Get()).m_KnownSpells != null)
                {
                    levelUpController.Unit.GetSpellbook(CharacterClassRefs.ClericClass.Reference.Get()).m_KnownSpells[spellLevel].ForEach(
                        a =>
                        Main.Logger.Info("Unit known spells " + a.Name)
                     );
                }

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

                if (isAssaultMageSelected && spellbook.Blueprint.AssetGuid == BlueprintGuid.Parse(AssaultMage.Archetypes.AssaultMage.ArchetypeSpellbookGuid))
                {
                    for (int i=0; i < SelectedClericSpells.Count; ++i)
                    {
                        spellbook.AddKnown(SpellLevel, SelectedClericSpells.ElementAt(i));
                    }
                }

                return true;
            }

            [HarmonyPatch(MethodType.Constructor, new Type[] { typeof(Spellbook) }), HarmonyPostfix]
            public static void Postfix(CharInfoSpellTableVM __instance, ref Spellbook spellbook)
            {
                Main.Logger.Info("CharInfoSpellTableVM constructor postfix");


                if (spellbook != null && spellbook.m_KnownSpells != null)
                {
                    for(int i=0; i < spellbook.m_KnownSpells[SpellLevel].Count;++i)
                    {
                        Main.Logger.Info("Spell is " + spellbook.m_KnownSpells[SpellLevel].ElementAt(i).Name);
                    }
                }

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

        [HarmonyPatch(typeof(CharGenContextVM))]
        public static class CharGenContextVM_Patch
        {

        }*/

        public static void AddChanges()
        {
            ArmorAttune.Configure();
            SuperDodge.Configure();
            AssaultMage.Archetypes.AssaultMage.Configure();
        }
    }
}

