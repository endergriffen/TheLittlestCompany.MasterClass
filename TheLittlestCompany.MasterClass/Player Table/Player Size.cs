using GameNetcodeStuff;
using HarmonyLib;
using System.Collections.Generic;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Player_Table
{
    internal class Player_Size
    {
        public static float randomNumberX;
        public static float randomNumberY;
        public static float randomNumberZ;

        // Separate HashSets for each method
        private static HashSet<GameObject> serverRandomizedPlayers = new HashSet<GameObject>();
        public static HashSet<GameObject> postfixRandomizedPlayers = new HashSet<GameObject>();

        [HarmonyPostfix]
        [HarmonyPatch(typeof(PlayerControllerB), "Update")]
        public static void ServerStarts(ref Transform ___thisPlayerBody, PlayerControllerB __instance)
        {
            if (NetworkManager.Singleton.IsHost)
            {
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

                foreach (var player in players)
                {
                    // Check if the player has already been randomized in ServerStarts
                    if (!serverRandomizedPlayers.Contains(player))
                    {
                        if (Configs.Instance.FunkyRandomBodySize.Value)
                        {
                            randomNumberX = Random.Range(0.2f, 1.5f);
                            randomNumberY = Random.Range(0.2f, 1.5f);
                            randomNumberZ = Random.Range(0.2f, 1.5f);

                            TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Player: {player.name}, Random number: {randomNumberX}, {randomNumberY}, {randomNumberZ}");
                            player.transform.localScale = new Vector3(randomNumberX, randomNumberY, randomNumberZ);
                        }
                        else if (Configs.Instance.RandomizeBodySize.Value)
                        {
                            randomNumberX = Random.Range(0.2f, 1.5f);
                            TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Player: {player.name}, Random number: {randomNumberX}");
                            player.transform.localScale = new Vector3(randomNumberX, randomNumberX, randomNumberX);
                        }
                        else
                        {
                            randomNumberX = Configs.Instance.BodySizeX.Value;
                            randomNumberY = Configs.Instance.BodySizeY.Value;
                            randomNumberZ = Configs.Instance.BodySizeZ.Value;

                            TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Player: {player.name}, Random number: {randomNumberX}, {randomNumberY}, {randomNumberZ}");
                            player.transform.localScale = new Vector3(randomNumberX, randomNumberY, randomNumberZ);
                        }

                        // Add player to the serverRandomizedPlayers HashSet
                        serverRandomizedPlayers.Add(player);
                    }
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(PlayerControllerB), "Update")]
        public static void Postfix(PlayerControllerB __instance)
        {
            if (Player_Joins.apple)
            {

                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

                foreach (var player in players)
                {
                    PlayerControllerB playerController = player.GetComponent<PlayerControllerB>();

                    if (playerController.isPlayerControlled)
                    {
                        TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Skipped {player.name}: Player is controlled.");
                        continue; // Skip if the player is already controlled
                    }

                    if (postfixRandomizedPlayers.Contains(player))
                    {
                        TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Skipped {player.name}: Already randomized.");
                        continue; // Skip if the player was already randomized
                    }

                    TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Randomizing body size for: {player.name}");

                    if (Configs.Instance.FunkyRandomBodySize.Value)
                    {
                        randomNumberX = Random.Range(0.2f, 1.5f);
                        randomNumberY = Random.Range(0.2f, 1.5f);
                        randomNumberZ = Random.Range(0.2f, 1.5f);
                        TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Random scale: {randomNumberX}, {randomNumberY}, {randomNumberZ}");
                        player.transform.localScale = new Vector3(randomNumberX, randomNumberY, randomNumberZ);
                    }
                    else if (Configs.Instance.RandomizeBodySize.Value)
                    {
                        randomNumberX = Random.Range(0.2f, 1.5f);
                        TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Uniform random scale: {randomNumberX}");
                        player.transform.localScale = new Vector3(randomNumberX, randomNumberX, randomNumberX);
                    }
                    else
                    {
                        randomNumberX = Configs.Instance.BodySizeX.Value;
                        randomNumberY = Configs.Instance.BodySizeY.Value;
                        randomNumberZ = Configs.Instance.BodySizeZ.Value;
                        TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Configured scale: {randomNumberX}, {randomNumberY}, {randomNumberZ}");
                        player.transform.localScale = new Vector3(randomNumberX, randomNumberY, randomNumberZ);
                    }

                    // Add player to the postfixRandomizedPlayers HashSet
                    postfixRandomizedPlayers.Add(player);
                }
                Player_Joins.apple = false;
            }
        }
    }
}