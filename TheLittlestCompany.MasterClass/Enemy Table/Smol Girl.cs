using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Girl
    {
        public static float randomGirlNumberX;
        public static float randomGirlNumberY;
        public static float randomGirlNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Girl" enemy
            if (__instance.enemyType.enemyName != "Girl") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolGirls.Value && !Configs.Instance.FunkyGirlsSize.Value)
            {
                randomGirlNumberX = Random.Range(Configs.Instance.MinGirlBodySize.Value, Configs.Instance.MaxGirlBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomGirlNumberX, randomGirlNumberX, randomGirlNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Ghost Girl has spawned with: {randomGirlNumberX}, {randomGirlNumberX}, {randomGirlNumberX}");
            }
            if (Configs.Instance.EnableSmolGirls.Value && Configs.Instance.FunkyGirlsSize.Value)
            {
                randomGirlNumberX = Random.Range(Configs.Instance.MinGirlBodySize.Value, Configs.Instance.MaxGirlBodySize.Value);
                randomGirlNumberY = Random.Range(Configs.Instance.MinGirlBodySize.Value, Configs.Instance.MaxGirlBodySize.Value);
                randomGirlNumberZ = Random.Range(Configs.Instance.MinGirlBodySize.Value, Configs.Instance.MaxGirlBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomGirlNumberX, randomGirlNumberY, randomGirlNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Ghost Girl has spawned with: {randomGirlNumberX}, {randomGirlNumberY}, {randomGirlNumberZ}");
            }
        }
    }
}