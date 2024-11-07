using BepInEx;
using HarmonyLib;
using System;
using UnityEngine;

namespace NoLeviathansModNamespace
{
    // Define the BepInEx plugin with a unique GUID, name, and version
    [BepInPlugin("com.DDE64bit.noleviathans", "No Leviathans Mod", "1.0.0")]
    public class NoLeviathansMod : BaseUnityPlugin
    {
        private static Harmony harmonyInstance;

        private void Awake()
        {
            try
            {
                // Initialize the Harmony instance with the plugin GUID
                harmonyInstance = new Harmony("com.DDE64bit.noleviathans");
                harmonyInstance.PatchAll(); // Apply all patches
                Logger.LogInfo("No Leviathans Mod loaded successfully.");
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during initialization
                Logger.LogError($"Error loading No Leviathans Mod: {ex.Message}");
            }
        }

        private void OnDestroy()
        {
            try
            {
                // Unpatch the current Harmony instance when the plugin is destroyed
                harmonyInstance.UnpatchSelf();
                Logger.LogInfo("No Leviathans Mod unloaded successfully.");
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during unpatching
                Logger.LogError($"Error unloading No Leviathans Mod: {ex.Message}");
            }
        }
    }
}
