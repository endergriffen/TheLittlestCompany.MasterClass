using HarmonyLib;
using UnityEngine;
using Unity.Netcode;

namespace TheLittlestCompany.MasterClass.Furniture.Traps
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class Trap_Handler
    {
        [HarmonyPatch("ShipHasLeft")]
        [HarmonyPostfix]
        private static void PatchStart(StartOfRound __instance)
        {
            if (!NetworkManager.Singleton.IsServer) return;

            TheLittlestCompanyPlugin.Instance.mls.LogInfo("The ship is leaving! Despawning all traps...");

            var landmines = GameObject.FindObjectsOfType<Landmine>();

            foreach (var landmine in landmines)
            {
                var networkObject = landmine.gameObject.GetComponentInParent<NetworkObject>();
                if (networkObject != null)
                {
                    networkObject.Despawn();
                    TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Despawned Trap Type: {landmine.name}");
                }
                else
                {
                    TheLittlestCompanyPlugin.Instance.mls.LogWarning($"Failed to despawn Trap Type: {landmine.name} (NetworkObject not found)");
                }
            }

            var turrets = GameObject.FindObjectsOfType<Turret>();

            foreach (var turret in turrets)
            {
                var networkObject = turret.gameObject.GetComponentInParent<NetworkObject>();
                if (networkObject != null)
                {
                    networkObject.Despawn();
                    TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Despawned Trap Type: {turret.name}");
                }
                else
                {
                    TheLittlestCompanyPlugin.Instance.mls.LogWarning($"Failed to despawn Trap Type: {turret.name} (NetworkObject not found)");
                }
            }

            var spikes = GameObject.FindObjectsOfType<SpikeRoofTrap>();

            foreach (var spike in spikes)
            {
                var networkObject = spike.gameObject.GetComponentInParent<NetworkObject>();
                if (networkObject != null)
                {
                    networkObject.Despawn();
                    TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Despawned Trap Type: {spike.name}");
                }
                else
                {
                    TheLittlestCompanyPlugin.Instance.mls.LogWarning($"Failed to despawn Trap Type: {spike.name} (NetworkObject not found)");
                }
            }
        }
    }
}