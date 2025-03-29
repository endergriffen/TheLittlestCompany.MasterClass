using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Commands
{
    internal class All_Commands
    {
        private static List<string> commands = new List<string> { "tradeSize", "setSize", "stuck", "commands", "yes", "no", "greet", "customTeleport" };
        private static Dictionary<string, string> tradeRequests = new Dictionary<string, string>(); // Store trade requests

        [HarmonyPatch(typeof(HUDManager), "SubmitChat_performed")]
        [HarmonyPrefix]
        private static void Prefix()
        {
            if (!NetworkManager.Singleton.IsHost) return;
            
            string text = HUDManager.Instance.chatTextField.text.Split(' ')[0];
            if ((!HUDManager.Instance.localPlayer.isHostPlayerObject && !commands.Contains(text)) || !text.StartsWith("!"))
            {
                return;
            }

            string playerName = HUDManager.Instance.localPlayer.playerUsername; // Get the local player's username
            text = text.Trim('!');

            switch (text)
            {
                case "tradeSize":
                    HandleTradeSizeCommand(playerName);
                    break;

                case "setSize":
                    HandleSetSizeCommand(playerName);
                    break;

                case "stuck":
                    TheLittlestCompanyPlugin.Instance.mls.LogInfo($"{playerName} needs a teleport!");
                    break;

                case "commands":
                    ShowCommandList();
                    break;

                case "yes":
                    HandleTradeResponse(playerName, true);
                    break;

                case "no":
                    HandleTradeResponse(playerName, false);
                    break;

                case "greet":
                    HandleGreetCommand();
                    break;

                case "customTeleport":
                    HandleCustomTeleportCommand();
                    break;
            }
        }

        private static void HandleTradeSizeCommand(string issuerName)
        {
            string[] array = HUDManager.Instance.chatTextField.text.Split(' ');
            if (array.Length != 2)
            {
                return;
            }

            string targetName = array[1];
            PlayerControllerB targetPlayer = Array.Find(StartOfRound.Instance.allPlayerScripts, (PlayerControllerB x) => x.playerUsername == targetName);
            if (targetPlayer == null)
            {
                HUDManager.Instance.AddTextToChatOnServer("Can't find player: " + targetName, -1);
                return;
            }

            // Store the trade request
            tradeRequests[issuerName] = targetName;
            HUDManager.Instance.AddTextToChatOnServer($"{targetName}, {issuerName} wants to trade sizes! Type !yes to accept or !no to decline.", -1);
            TheLittlestCompanyPlugin.Instance.mls.LogInfo($"{issuerName} wants to trade sizes with {targetName}!");
        }

        private static void HandleTradeResponse(string responderName, bool accepted)
        {
            if (tradeRequests.ContainsValue(responderName))
            {
                string issuerName = tradeRequests.FirstOrDefault(x => x.Value == responderName).Key; // Find the issuer
                if (accepted)
                {
                    HUDManager.Instance.AddTextToChatOnServer($"{responderName} accepted the trade size request from {issuerName}.", -1);
                    TheLittlestCompanyPlugin.Instance.mls.LogInfo($"{responderName} accepted the trade size request from {issuerName}.");
                    // Implement size swap logic here if needed
                }
                else
                {
                    HUDManager.Instance.AddTextToChatOnServer($"{responderName} declined the trade size request from {issuerName}.", -1);
                    TheLittlestCompanyPlugin.Instance.mls.LogInfo($"{responderName} declined the trade size request from {issuerName}.");
                }

                // Remove the request after processing
                tradeRequests.Remove(issuerName);
            }
        }

        private static void HandleSetSizeCommand(string issuerName)
        {
            string[] array = HUDManager.Instance.chatTextField.text.Split(' ');
            if (array.Length != 5)
            {
                HUDManager.Instance.AddTextToChatOnServer("Usage: !setSize PLAYERNAME X Y Z", 0);
                return;
            }

            string name = array[1];
            if (!float.TryParse(array[2], out float scaleX) ||
                !float.TryParse(array[3], out float scaleY) ||
                !float.TryParse(array[4], out float scaleZ))
            {
                HUDManager.Instance.AddTextToChatOnServer("Invalid size values. Use numbers like: !setSize PLAYERNAME 1.0 1.0 1.0", 0);
                return;
            }

            PlayerControllerB player = Array.Find(StartOfRound.Instance.allPlayerScripts, (PlayerControllerB x) => x.playerUsername == name);
            if (player == null)
            {
                HUDManager.Instance.AddTextToChatOnServer("Can't find player: " + name, 0);
                return;
            }

            // Set the player scale
            player.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            HUDManager.Instance.AddTextToChatOnServer($"{name}'s size set to ({scaleX}, {scaleY}, {scaleZ}) by {issuerName}", -1);

            // Log the action
            TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Set {name}'s size to ({scaleX}, {scaleY}, {scaleZ}) by {issuerName}");
        }

        private static void HandleGreetCommand()
        {
            HUDManager.Instance.AddTextToChatOnServer("Hello, players!", -1);
        }

        private static void HandleCustomTeleportCommand()
        {
            string[] args = HUDManager.Instance.chatTextField.text.Split(' ');
            if (args.Length < 2)
            {
                HUDManager.Instance.AddTextToChatOnServer("Usage: !customTeleport PLAYERNAME", 0);
                return;
            }

            string targetPlayerName = args[1];
            PlayerControllerB player = StartOfRound.Instance.allPlayerScripts.FirstOrDefault(p => p.playerUsername == targetPlayerName);
            if (player == null)
            {
                HUDManager.Instance.AddTextToChatOnServer("Can't find player: " + targetPlayerName, -1);
                return;
            }

            Vector3 teleportPosition = new Vector3(0, 0, 0); // Example teleport position
            player.TeleportPlayer(teleportPosition, false, 0f, false, true);
            HUDManager.Instance.AddTextToChatOnServer($"Teleported {targetPlayerName}!", -1);
        }

        private static void ShowCommandList()
        {
            string commandList = "<color=yellow>TheLittlestCompany Commands</color>\n" +
                                 "<color=white>!tradeSize PLAYERNAME</color> - Request to trade sizes with a player\n" +
                                 "<color=white>!setSize PLAYERNAME X Y Z</color> - Set a player's size\n" +
                                 "<color=white>!stuck</color> - Call for help if stuck\n" +
                                 "<color=white>!greet</color> - Say hello to everyone\n" +
                                 "<color=white>!customTeleport PLAYERNAME</color> - Teleport a player to a fixed position";
            HUDManager.Instance.AddTextToChatOnServer(commandList, -1);
        }
    }
}