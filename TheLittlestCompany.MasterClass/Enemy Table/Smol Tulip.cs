using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Tulip
    {
        public static float randomTulipNumberX;
        public static float randomTulipNumberY;
        public static float randomTulipNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Tulip Snake" enemy
            if (__instance.enemyType.enemyName != "Tulip Snake") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolTulips.Value && !Configs.Instance.FunkyTulipsSize.Value)
            {
                randomTulipNumberX = Random.Range(Configs.Instance.MinTulipBodySize.Value, Configs.Instance.MaxTulipBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomTulipNumberX, randomTulipNumberX, randomTulipNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Tulip Snake has spawned with: {randomTulipNumberX}, {randomTulipNumberX}, {randomTulipNumberX}");
            }
            if (Configs.Instance.EnableSmolTulips.Value && Configs.Instance.FunkyTulipsSize.Value)
            {
                randomTulipNumberX = Random.Range(Configs.Instance.MinTulipBodySize.Value, Configs.Instance.MaxTulipBodySize.Value);
                randomTulipNumberY = Random.Range(Configs.Instance.MinTulipBodySize.Value, Configs.Instance.MaxTulipBodySize.Value);
                randomTulipNumberZ = Random.Range(Configs.Instance.MinTulipBodySize.Value, Configs.Instance.MaxTulipBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomTulipNumberX, randomTulipNumberY, randomTulipNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Tulip Snake has spawned with: {randomTulipNumberX}, {randomTulipNumberY}, {randomTulipNumberZ}");
            }
        }
    }
}