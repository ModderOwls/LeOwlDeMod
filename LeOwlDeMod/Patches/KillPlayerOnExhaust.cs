using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

public class PlayerExhaustDeath
{
    // We use Attributes to tell Harmony which class' method we are targeting
    [HarmonyPatch(typeof(PlayerControllerB), nameof(PlayerControllerB.Update))]
    // We also specify that our patch method will run after the original method
    [HarmonyPostfix]
    private static void PlayerControllerB_Update(PlayerControllerB __instance)
    {
        if (__instance.isExhausted)
        {
            __instance.KillPlayer(Vector3.zero);
        }
    }
}