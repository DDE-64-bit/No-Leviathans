using HarmonyLib;
using UnityEngine;

namespace NoLeviathansModNamespace
{
    [HarmonyPatch(typeof(Creature))] // Target the Creature class
    public class CreaturePatches
    {
        // Patch the Start method with a Prefix patch
        [HarmonyPatch("Start")]
        [HarmonyPrefix] // Run this code before the original Start method
        public static bool PrefixStart(Creature __instance)
        {
            // Get the name of the creature type
            string name = __instance.GetType().Name;

            // List of Leviathan names to block
            string[] leviathans = {
                "ReaperLeviathan",
                "GhostLeviathan",
                "SeaDragon",
                "SeaEmperor",
                "SeaTreader",
                "GhostLeviathanJuvenile",
                "SeaDragonJuvenile",
                "SeaEmperorJuvenile",
                "SeaEmperorBaby",
                "GlowWhale",
                "Chelicerate",
                "VoidChelicerate",
                "ShadowLeviathan",
                "IceWorm",
                "Ventgarden",
                "JuvenileVentgarden",
                "bleeder",
                "mesmer",
                "shuttlebug",

            };

            // Only destroy Leviathan-class creatures
            if (System.Array.Exists(leviathans, element => element == name))
            {
                UnityEngine.Object.Destroy(__instance.gameObject);
                return false; // Skip the original Start method
            }

            // Allow non-Leviathan creatures to proceed normally
            return true;
        }
    }
}
