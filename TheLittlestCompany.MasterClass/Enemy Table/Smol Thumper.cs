using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Thumper
    {
        public static float randomThumperNumberX;
        public static float randomThumperNumberY;
        public static float randomThumperNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Crawler" enemy
            if (__instance.enemyType.enemyName != "Crawler") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolThumpers.Value && !Configs.Instance.FunkyThumpersSize.Value)
            {
                randomThumperNumberX = Random.Range(Configs.Instance.MinThumperBodySize.Value, Configs.Instance.MaxThumperBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomThumperNumberX, randomThumperNumberX, randomThumperNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Slime has spawned with: {randomThumperNumberX}, {randomThumperNumberX}, {randomThumperNumberX}");
            }
            if (Configs.Instance.EnableSmolSnares.Value && Configs.Instance.FunkySnaresSize.Value)
            {
                randomThumperNumberX = Random.Range(Configs.Instance.MinThumperBodySize.Value, Configs.Instance.MaxThumperBodySize.Value);
                randomThumperNumberY = Random.Range(Configs.Instance.MinThumperBodySize.Value, Configs.Instance.MaxThumperBodySize.Value);
                randomThumperNumberZ = Random.Range(Configs.Instance.MinThumperBodySize.Value, Configs.Instance.MaxThumperBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomThumperNumberX, randomThumperNumberY, randomThumperNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Slime has spawned with: {randomThumperNumberX}, {randomThumperNumberY}, {randomThumperNumberZ}");
            }
        }
    }
}