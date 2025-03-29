using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using UnityEngine;
using Unity.Netcode;

namespace TheLittlestCompany.MasterClass.Furniture.Traps
{
    [HarmonyPatch(typeof(SpikeRoofTrap))]
    internal class Smol_Spikes
    {
        public static float randomSpikeTrapNumberX;
        public static float randomSpikeTrapNumberY;
        public static float randomSpikeTrapNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(SpikeRoofTrap __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for server-owned spike traps
            if (!__instance.IsServer || !__instance.IsOwner) return;

            // Get the NetworkObject from the parent or current object
            var networkObject = __instance.gameObject.GetComponentInParent<NetworkObject>();
            if (networkObject == null)
            {
                TheLittlestCompanyPlugin.Instance.mls.LogWarning("NetworkObject not found for Spike Trap.");
                return;
            }

            Vector3 newScale;

            if (Configs.Instance.EnableSmolSpikeTraps.Value && !Configs.Instance.FunkySpikeTrapsSize.Value)
            {
                randomSpikeTrapNumberX = Random.Range(Configs.Instance.MinSpikeTrapsBodySize.Value, Configs.Instance.MaxSpikeTrapsBodySize.Value);
                newScale = new Vector3(randomSpikeTrapNumberX, randomSpikeTrapNumberX, randomSpikeTrapNumberX);
            }
            else if (Configs.Instance.EnableSmolSpikeTraps.Value && Configs.Instance.FunkySpikeTrapsSize.Value)
            {
                randomSpikeTrapNumberX = Random.Range(Configs.Instance.MinSpikeTrapsBodySize.Value, Configs.Instance.MaxSpikeTrapsBodySize.Value);
                randomSpikeTrapNumberY = Random.Range(Configs.Instance.MinSpikeTrapsBodySize.Value, Configs.Instance.MaxSpikeTrapsBodySize.Value);
                randomSpikeTrapNumberZ = Random.Range(Configs.Instance.MinSpikeTrapsBodySize.Value, Configs.Instance.MaxSpikeTrapsBodySize.Value);
                newScale = new Vector3(randomSpikeTrapNumberX, randomSpikeTrapNumberY, randomSpikeTrapNumberZ);
            }
            else
            {
                return;
            }

            TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Spike Trap has spawned with scale: {newScale}");

            networkObject.Despawn(false);
            __instance.gameObject.transform.parent.localScale = newScale;
            networkObject.Spawn();
        }
    }
}