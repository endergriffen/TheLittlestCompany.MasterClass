using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Spider
    {
        public static float randomSpiderNumberX;
        public static float randomSpiderNumberY;
        public static float randomSpiderNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Bunker Spider" enemy
            if (__instance.enemyType.enemyName != "Bunker Spider") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolSpiders.Value && !Configs.Instance.FunkySpidersSize.Value)
            {
                randomSpiderNumberX = Random.Range(Configs.Instance.MinSpiderBodySize.Value, Configs.Instance.MaxSpiderBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomSpiderNumberX, randomSpiderNumberX, randomSpiderNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Slime has spawned with: {randomSpiderNumberX}, {randomSpiderNumberX}, {randomSpiderNumberX}");
            }
            if (Configs.Instance.EnableSmolSpiders.Value && Configs.Instance.FunkySpidersSize.Value)
            {
                randomSpiderNumberX = Random.Range(Configs.Instance.MinSpiderBodySize.Value, Configs.Instance.MaxSpiderBodySize.Value);
                randomSpiderNumberY = Random.Range(Configs.Instance.MinSpiderBodySize.Value, Configs.Instance.MaxSpiderBodySize.Value);
                randomSpiderNumberZ = Random.Range(Configs.Instance.MinSpiderBodySize.Value, Configs.Instance.MaxSpiderBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomSpiderNumberX, randomSpiderNumberY, randomSpiderNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Slime has spawned with: {randomSpiderNumberX}, {randomSpiderNumberY}, {randomSpiderNumberZ}");
            }
        }
    }
}