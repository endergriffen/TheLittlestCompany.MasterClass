using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Bracken
    {
        public static float randomBrackenNumberX;
        public static float randomBrackenNumberY;
        public static float randomBrackenNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Flowerman" enemy
            if (__instance.enemyType.enemyName != "Flowerman") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolBrackens.Value && !Configs.Instance.FunkyBrackensSize.Value)
            {
                randomBrackenNumberX = Random.Range(Configs.Instance.MinBrackenBodySize.Value, Configs.Instance.MaxBrackenBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomBrackenNumberX, randomBrackenNumberX, randomBrackenNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Bracken has spawned with: {randomBrackenNumberX}, {randomBrackenNumberX}, {randomBrackenNumberX}");
            }
            if (Configs.Instance.EnableSmolBrackens.Value && Configs.Instance.FunkyBrackensSize.Value)
            {
                randomBrackenNumberX = Random.Range(Configs.Instance.MinBrackenBodySize.Value, Configs.Instance.MaxBrackenBodySize.Value);
                randomBrackenNumberY = Random.Range(Configs.Instance.MinBrackenBodySize.Value, Configs.Instance.MaxBrackenBodySize.Value);
                randomBrackenNumberZ = Random.Range(Configs.Instance.MinBrackenBodySize.Value, Configs.Instance.MaxBrackenBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomBrackenNumberX, randomBrackenNumberY, randomBrackenNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Bracken has spawned with: {randomBrackenNumberX}, {randomBrackenNumberY}, {randomBrackenNumberZ}");
            }
        }
    }
}