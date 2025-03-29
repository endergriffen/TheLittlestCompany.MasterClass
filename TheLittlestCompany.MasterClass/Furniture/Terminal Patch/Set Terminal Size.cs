using GameNetcodeStuff;
using HarmonyLib;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Furniture.Terminal_Patch
{
    public class Set_Terminal_Size
    {
        public static PlayerControllerB whoUseTerminal { get; set; }
        public static Vector3 originalSize; // To store the original size of the player

        [HarmonyPatch(typeof(InteractTrigger), "__rpc_handler_1430497838")]
        [HarmonyPrefix]
        [HarmonyWrapSafe]
        public static bool __rpc_handler_1430497838(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
        {
            if (Terminal_Check_Patch.Check(rpcParams, out var p) || StartOfRound.Instance.IsHost || StartOfRound.Instance.IsClient)
            {
                ByteUnpacker.ReadValueBitPacked(reader, out int playerNum);
                reader.Seek(0);
                if (playerNum == (int)p.playerClientId)
                {
                    var terminal = UnityEngine.Object.FindObjectOfType<Terminal>();
                    var terminalTrigger = terminal.GetField<Terminal, InteractTrigger>("terminalTrigger");
                    if (terminalTrigger.GetInstanceID() == ((InteractTrigger)target).GetInstanceID())
                    {
                        whoUseTerminal = p;
                        TheLittlestCompanyPlugin.Instance.mls.LogInfo($"player {p.playerUsername} use Terminal");
                        StoreOriginalSize(p);
                        ResetPlayerSizeToDefault(p);
                    }
                }
            }
            else if (p == null)
            {
                return false;
            }
            return true;
        }

        private static void StoreOriginalSize(PlayerControllerB player)
        {
            originalSize = player.gameObject.transform.localScale; // Store current size
            TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Stored original size for {player.playerUsername}: {originalSize.ToString("F7")}");
        }

        public static void ResetPlayerSizeToDefault(PlayerControllerB player)
        {
            GameObject playerObject = player.gameObject; // Get the player's GameObject
            if (playerObject != null)
            {
                /**
                var networkObject = playerObject.GetComponent<NetworkObject>();

                // Temporarily change ownership to the server
                if (networkObject != null)
                {
                    networkObject.ChangeOwnership(NetworkManager.ServerClientId); // Change ownership to server
                }
                */

                playerObject.transform.localScale = new Vector3(1f, 1f, 1f); // Reset size
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Player size reset to 1f, 1f, 1f for {player.playerUsername}");

                // After size is reset, reassign ownership back to the player
                // networkObject.ChangeOwnership(player.actualClientId); // Change ownership back to the player
            }
        }
    }
}