using GameNetcodeStuff;
using HarmonyLib;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Furniture.Terminal_Patch
{
    public class Reset_Terminal_Size
    {
        [HarmonyPatch(typeof(InteractTrigger), "__rpc_handler_880620475")]
        [HarmonyPrefix]
        [HarmonyWrapSafe]
        public static bool __rpc_handler_880620475(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
        {
            if (Terminal_Check_Patch.Check(rpcParams, out var p) || StartOfRound.Instance.IsHost)
            {
                ByteUnpacker.ReadValueBitPacked(reader, out int playerNum);
                reader.Seek(0);
                if (playerNum == (int)p.playerClientId)
                {
                    var terminal = UnityEngine.Object.FindObjectOfType<Terminal>();
                    var terminalTrigger = terminal.GetField<Terminal, InteractTrigger>("terminalTrigger");
                    if (terminalTrigger.GetInstanceID() == ((InteractTrigger)target).GetInstanceID())
                    {
                        Set_Terminal_Size.whoUseTerminal = null;
                        TheLittlestCompanyPlugin.Instance.mls.LogInfo($"player {p.playerUsername} stop use Terminal");
                        ResetPlayerSizeToOriginal(p);
                    }
                }
            }
            else if (p == null)
            {
                return false;
            }
            return true;
        }

        public static void ResetPlayerSizeToOriginal(PlayerControllerB player)
        {
            GameObject playerObject = player.gameObject; // Get the player's GameObject
            if (playerObject != null)
            {
                playerObject.transform.localScale = Set_Terminal_Size.originalSize; // Reset to original size
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Player size reset to original {Set_Terminal_Size.originalSize.ToString("F7")} for {player.playerUsername}");
            }
        }
    }
}