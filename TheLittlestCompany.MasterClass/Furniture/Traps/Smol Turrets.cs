using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using UnityEngine;
using Unity.Netcode;

namespace TheLittlestCompany.MasterClass.Furniture.Traps
{
    [HarmonyPatch(typeof(Turret))]
    internal class Smol_Turrets
    {
        public static float randomTurretNumberX;
        public static float randomTurretNumberY;
        public static float randomTurretNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(Turret __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for server-owned turrets
            if (!__instance.IsServer || !__instance.IsOwner) return;

            // Get the NetworkObject from the parent or current object
            var networkObject = __instance.gameObject.GetComponentInParent<NetworkObject>();
            if (networkObject == null)
            {
                TheLittlestCompanyPlugin.Instance.mls.LogWarning("NetworkObject not found for Turret.");
                return;
            }

            Vector3 newScale;

            if (Configs.Instance.EnableSmolTurrets.Value && !Configs.Instance.FunkyTurretsSize.Value)
            {
                randomTurretNumberX = Random.Range(Configs.Instance.MinTurretsBodySize.Value, Configs.Instance.MaxTurretsBodySize.Value);
                newScale = new Vector3(randomTurretNumberX, randomTurretNumberX, randomTurretNumberX);
            }
            else if (Configs.Instance.EnableSmolTurrets.Value && Configs.Instance.FunkyTurretsSize.Value)
            {
                randomTurretNumberX = Random.Range(Configs.Instance.MinTurretsBodySize.Value, Configs.Instance.MaxTurretsBodySize.Value);
                randomTurretNumberY = Random.Range(Configs.Instance.MinTurretsBodySize.Value, Configs.Instance.MaxTurretsBodySize.Value);
                randomTurretNumberZ = Random.Range(Configs.Instance.MinTurretsBodySize.Value, Configs.Instance.MaxTurretsBodySize.Value);
                newScale = new Vector3(randomTurretNumberX, randomTurretNumberY, randomTurretNumberZ);
            }
            else
            {
                return;
            }

            TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Turret has spawned with scale: {newScale}");

            networkObject.Despawn(false);
            __instance.gameObject.transform.parent.localScale = newScale;
            networkObject.Spawn();
        }
    }
}