using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Giants
    {
        public static float randomGiantNumberX;
        public static float randomGiantNumberY;
        public static float randomGiantNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "ForestGiant" enemy
            if (__instance.enemyType.enemyName != "ForestGiant") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolGiants.Value && !Configs.Instance.FunkyGiantsSize.Value)
            {
                randomGiantNumberX = Random.Range(Configs.Instance.MinGiantBodySize.Value, Configs.Instance.MaxGiantBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomGiantNumberX, randomGiantNumberX, randomGiantNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Giant has spawned with: {randomGiantNumberX}, {randomGiantNumberX}, {randomGiantNumberX}");
            }
            if (Configs.Instance.EnableSmolGiants.Value && Configs.Instance.FunkyGiantsSize.Value)
            {
                randomGiantNumberX = Random.Range(Configs.Instance.MinGiantBodySize.Value, Configs.Instance.MaxGiantBodySize.Value);
                randomGiantNumberY = Random.Range(Configs.Instance.MinGiantBodySize.Value, Configs.Instance.MaxGiantBodySize.Value);
                randomGiantNumberZ = Random.Range(Configs.Instance.MinGiantBodySize.Value, Configs.Instance.MaxGiantBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomGiantNumberX, randomGiantNumberY, randomGiantNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Giant has spawned with: {randomGiantNumberX}, {randomGiantNumberY}, {randomGiantNumberZ}");
            }
        }
    }
}