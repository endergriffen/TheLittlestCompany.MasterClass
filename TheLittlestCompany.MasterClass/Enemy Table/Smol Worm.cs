using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Worm
    {
        public static float randomWormNumberX;
        public static float randomWormNumberY;
        public static float randomWormNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Earth Leviathan" enemy
            if (__instance.enemyType.enemyName != "Earth Leviathan") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolWorms.Value && !Configs.Instance.FunkyWormsSize.Value)
            {
                randomWormNumberX = Random.Range(Configs.Instance.MinWormBodySize.Value, Configs.Instance.MaxWormBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomWormNumberX, randomWormNumberX, randomWormNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Worm has spawned with: {randomWormNumberX}, {randomWormNumberX}, {randomWormNumberX}");
            }
            if (Configs.Instance.EnableSmolWorms.Value && Configs.Instance.FunkyWormsSize.Value)
            {
                randomWormNumberX = Random.Range(Configs.Instance.MinWormBodySize.Value, Configs.Instance.MaxWormBodySize.Value);
                randomWormNumberY = Random.Range(Configs.Instance.MinWormBodySize.Value, Configs.Instance.MaxWormBodySize.Value);
                randomWormNumberZ = Random.Range(Configs.Instance.MinWormBodySize.Value, Configs.Instance.MaxWormBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomWormNumberX, randomWormNumberY, randomWormNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Worm has spawned with: {randomWormNumberX}, {randomWormNumberY}, {randomWormNumberZ}");
            }
        }
    }
}