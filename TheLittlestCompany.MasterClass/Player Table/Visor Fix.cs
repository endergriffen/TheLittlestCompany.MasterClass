using GameNetcodeStuff;
using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Player_Table
{
    internal class Visor_Fix
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(PlayerControllerB), "Awake")]
        public static void VisorFixing(PlayerControllerB __instance)
        {
            if (Configs.Instance.HideVisor.Value)
            {
                __instance.localVisor.localScale = Vector3.zero;
            }
        }
    }
}