using UnityEngine;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LeOwlDeMod.Hooks;
using LobbyCompatibility.Attributes;
using LobbyCompatibility.Enums;
using MonoMod.RuntimeDetour;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace LeOwlDeMod
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInDependency("BMX.LobbyCompatibility", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency(LethalLib.Plugin.ModGUID)]
    [LobbyCompatibility(CompatibilityLevel.ClientOnly, VersionStrictness.None)]
    public class LeOwlDeMod : BaseUnityPlugin
    {
        public static LeOwlDeMod Instance { get; private set; } = null!;
        internal new static ManualLogSource Logger { get; private set; } = null!;
        internal static List<IDetour> Hooks { get; set; } = new List<IDetour>();

        public static AssetBundle bundleBodalicious;

        private void Awake()
        {
            Logger = base.Logger;
            Instance = this;

            string sAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Bodalicious.Initialize(ref bundleBodalicious, AssetBundle.LoadFromFile(Path.Combine(sAssemblyLocation, "bodalicious")));

            Hook();

            Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
        }

        internal static void Hook()
        {
            Logger.LogDebug("Hooking...");

            /*
             *  Add to the Hooks list for each method you're patching with:
             *
             *  Hooks.Add(new Hook(
             *      typeof(Class).GetMethod("Method", AccessTools.allDeclared),
             *      CustomClass.CustomMethod));
             */

            Hooks.Add(new Hook(
                    typeof(GameNetcodeStuff.PlayerControllerB).GetMethod("Update", AccessTools.allDeclared),
                    PlayerExhaustedDeath.PlayerControllerB_Update));

            Logger.LogDebug("Finished Hooking!");
        }

        internal static void Unhook()
        {
            Logger.LogDebug("Unhooking...");

            foreach (var detour in Hooks)
                detour.Undo();
            Hooks.Clear();

            Logger.LogDebug("Finished Unhooking!");
        }
    }
}
