using GameNetcodeStuff;
using HarmonyLib;
using System.Collections.Generic;
using TheLittlestCompany.MasterClass.ConfigManager;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Player_Table
{
    internal class Failure_Punishment
    {
        /*
        // Separate flags to control each method's execution
        public static bool LogOnceForResize = true;
        public static bool LogOnceForAnnouncement = true;

        public static float extraRandomNumberX;
        public static float extraRandomNumberY;
        public static float extraRandomNumberZ;

        // List to keep track of players that have been randomized
        private static HashSet<GameObject> extraRandomizedPlayers = new HashSet<GameObject>();

        [HarmonyPatch(typeof(StartOfRound), "Update")]
        [HarmonyPostfix]
        private static void FailureResize(StartOfRound __instance)
        {
            if (__instance.allPlayersDead && Configs.Instance.FailurePenalty.Value)
            {
                if (LogOnceForResize)
                {
                    TheLittlestCompanyPlugin.Instance.mls.LogInfo("All Players have died! Applying failure penalty...");
                    LogOnceForResize = false;
                    ServerStarts();  // Call ServerStarts to resize players
                }

                if (LogOnceForAnnouncement)
                {
                    LogOnceForAnnouncement = false;
                    ChatAnnouncment();  // Call ChatAnnouncement to announce in chat
                }
            }
            else if (!__instance.allPlayersDead)
            {
                // Reset both flags when players are no longer all dead
                LogOnceForResize = true;
                LogOnceForAnnouncement = true;

                // Clear the extraRandomizedPlayers set to allow resizing again in future rounds
                ClearRandomizedPlayers();
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(PlayerControllerB), "Update")]
        private static void ServerStarts()
        {
            if (!LogOnceForResize)
            {
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

                foreach (var player in players)
                {
                    // Check if the player has already been randomized
                    if (!extraRandomizedPlayers.Contains(player) && Configs.Instance.FailurePenalty.Value)
                    {
                        if (Configs.Instance.FunkyRandomBodySize.Value)
                        {
                            extraRandomNumberX = Random.Range(0.2f, 1.5f);
                            extraRandomNumberY = Random.Range(0.2f, 1.5f);
                            extraRandomNumberZ = Random.Range(0.2f, 1.5f);

                            TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Player: {player.name}, Random number: {extraRandomNumberX}, {extraRandomNumberY}, {extraRandomNumberZ}");
                            player.transform.localScale = new Vector3(extraRandomNumberX, extraRandomNumberY, extraRandomNumberZ);
                        }
                        else if (Configs.Instance.RandomizeBodySize.Value)
                        {
                            extraRandomNumberX = Random.Range(0.2f, 1.5f);

                            TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Player: {player.name}, Random number: {extraRandomNumberX}");
                            player.transform.localScale = new Vector3(extraRandomNumberX, extraRandomNumberX, extraRandomNumberX);
                        }

                        // Add player to the list of randomized players
                        extraRandomizedPlayers.Add(player);
                    }
                }
            }
        }

        [HarmonyPatch(typeof(HUDManager), "Start")]
        [HarmonyPostfix]
        private static void ChatAnnouncment()
        {
            if (!LogOnceForAnnouncement && Configs.Instance.FailurePenalty.Value && (Configs.Instance.FunkyRandomBodySize.Value || Configs.Instance.RandomizeBodySize.Value))
            {
                HUDManager.Instance.AddTextToChatOnServer("The Company is NOT Satisfied with your level of performance, and has decided that you might work better if you are looking from a different perspective: ", -1);
                TheLittlestCompanyPlugin.Instance.mls.LogInfo("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            }
        }

        // Method to clear the extraRandomizedPlayers set when players are no longer dead
        private static void ClearRandomizedPlayers()
        {
            extraRandomizedPlayers.Clear();
        }
        */
    }
}