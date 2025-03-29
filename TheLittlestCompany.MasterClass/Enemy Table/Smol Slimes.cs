using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Slimes
    {
        public static float randomSlimeNumberX;
        public static float randomSlimeNumberY;
        public static float randomSlimeNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Blob" enemy
            if (__instance.enemyType.enemyName != "Blob") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolSlimes.Value && !Configs.Instance.FunkySlimesSize.Value)
            {
                randomSlimeNumberX = Random.Range(Configs.Instance.MinSlimeBodySize.Value, Configs.Instance.MaxSlimeBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomSlimeNumberX, randomSlimeNumberX, randomSlimeNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Slime has spawned with: {randomSlimeNumberX}, {randomSlimeNumberX}, {randomSlimeNumberX}");
            }
            if (Configs.Instance.EnableSmolSlimes.Value && Configs.Instance.FunkySlimesSize.Value)
            {
                randomSlimeNumberX = Random.Range(Configs.Instance.MinSlimeBodySize.Value, Configs.Instance.MaxSlimeBodySize.Value);
                randomSlimeNumberY = Random.Range(Configs.Instance.MinSlimeBodySize.Value, Configs.Instance.MaxSlimeBodySize.Value);
                randomSlimeNumberZ = Random.Range(Configs.Instance.MinSlimeBodySize.Value, Configs.Instance.MaxSlimeBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomSlimeNumberX, randomSlimeNumberY, randomSlimeNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Slime has spawned with: {randomSlimeNumberX}, {randomSlimeNumberY}, {randomSlimeNumberZ}");
            }
        }
    }
}