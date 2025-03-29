using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Coilhead
    {
        public static float randomCoilheadNumberX;
        public static float randomCoilheadNumberY;
        public static float randomCoilheadNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Spring" enemy
            if (__instance.enemyType.enemyName != "Spring") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolCoilheads.Value && !Configs.Instance.FunkyCoilheadsSize.Value)
            {
                randomCoilheadNumberX = Random.Range(Configs.Instance.MinCoilheadBodySize.Value, Configs.Instance.MaxCoilheadBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomCoilheadNumberX, randomCoilheadNumberX, randomCoilheadNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Coilhead has spawned with: {randomCoilheadNumberX}, {randomCoilheadNumberX}, {randomCoilheadNumberX}");
            }
            if (Configs.Instance.EnableSmolCoilheads.Value && Configs.Instance.FunkyCoilheadsSize.Value)
            {
                randomCoilheadNumberX = Random.Range(Configs.Instance.MinCoilheadBodySize.Value, Configs.Instance.MaxCoilheadBodySize.Value);
                randomCoilheadNumberY = Random.Range(Configs.Instance.MinCoilheadBodySize.Value, Configs.Instance.MaxCoilheadBodySize.Value);
                randomCoilheadNumberZ = Random.Range(Configs.Instance.MinCoilheadBodySize.Value, Configs.Instance.MaxCoilheadBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomCoilheadNumberX, randomCoilheadNumberY, randomCoilheadNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Coilhead has spawned with: {randomCoilheadNumberX}, {randomCoilheadNumberY}, {randomCoilheadNumberZ}");
            }
        }
    }
}