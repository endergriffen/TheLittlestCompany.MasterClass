using GameNetcodeStuff;
using HarmonyLib;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Player_Table
{
    public class Player_Joins
    {
        public static bool apple = false;

        // List to keep track of players that have been randomizedf
        private static Dictionary<ulong, string> playerLogs = new Dictionary<ulong, string>();

        // Assuming postfixRandomizedPlayers is defined in another class, reference it here
        private static HashSet<GameObject> postfixRandomizedPlayers = Player_Size.postfixRandomizedPlayers;

        [HarmonyPostfix]
        [HarmonyPatch(typeof(PlayerControllerB), "Update")]
        public static void OnPlayerJoin(PlayerControllerB __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            ulong actualClientId = __instance.actualClientId;

            if (__instance.isPlayerControlled)
            {
                // Check if the player is already logged
                if (!playerLogs.ContainsKey(actualClientId))
                {
                    // Log the player and add them to the dictionary
                    playerLogs[actualClientId] = __instance.playerUsername;
                    TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Controlled player detected: {__instance.playerUsername} with Client ID: {actualClientId}");
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(StartOfRound), "OnClientDisconnect")]
        public static void OnClientDisconnect(ulong clientId)
        {
            if (NetworkManager.Singleton.IsHost)
            {
                // Check if the clientId is logged
                if (playerLogs.ContainsKey(clientId))
                {
                    // Log the disconnection and remove from the dictionary
                    TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Player disconnected: {playerLogs[clientId]} with Client ID: {clientId}");
                    playerLogs.Remove(clientId);

                    // Clear postfixRandomizedPlayers HashSet before setting apple to true
                    postfixRandomizedPlayers.Clear();

                    // Set apple to true after clearing the HashSet
                    apple = true;
                }
            }
        }
    }
}