using GameNetcodeStuff;
using Unity.Netcode;

namespace TheLittlestCompany.MasterClass.Furniture.Terminal_Patch
{
    public class Terminal_Check_Patch
    {
        public static bool Check(__RpcParams rpcParams, out PlayerControllerB p)
        {
            if (StartOfRound.Instance.localPlayerController == null)
            {
                p = default;
                return false;
            }
            else if (!StartOfRound.Instance.localPlayerController.IsHost)
            {
                p = StartOfRound.Instance.localPlayerController;
                return false;
            }
            var tmp = GetPlayer(rpcParams);
            p = tmp;
            if (p == null)
            {
                NetworkManager.Singleton.DisconnectClient(rpcParams.Server.Receive.SenderClientId);
                return false;
            }
            else if (rpcParams.Server.Receive.SenderClientId == GameNetworkManager.Instance.localPlayerController.actualClientId)
            {
                p = StartOfRound.Instance.localPlayerController;
                return false;
            }
            else if (StartOfRound.Instance.KickedClientIds.Contains(p.playerSteamId))
            {
                NetworkManager.Singleton.DisconnectClient(rpcParams.Server.Receive.SenderClientId);
                return false;
            }
            return true;
        }

        public static PlayerControllerB GetPlayer(__RpcParams rpcParams)
        {
            foreach (var item in StartOfRound.Instance.allPlayerScripts)
            {
                if (item.actualClientId == rpcParams.Server.Receive.SenderClientId)
                {
                    return item;
                }
            }
            return null;
        }
    }
}