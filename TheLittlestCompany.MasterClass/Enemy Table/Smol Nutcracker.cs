using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Nutcracker
    {
        public static float randomNutcrackerNumberX;
        public static float randomNutcrackerNumberY;
        public static float randomNutcrackerNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Nutcracker" enemy
            if (__instance.enemyType.enemyName != "Nutcracker") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolNutcrackers.Value && !Configs.Instance.FunkyNutcrackersSize.Value)
            {
                randomNutcrackerNumberX = Random.Range(Configs.Instance.MinNutcrackerBodySize.Value, Configs.Instance.MaxNutcrackerBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomNutcrackerNumberX, randomNutcrackerNumberX, randomNutcrackerNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Nutcracker has spawned with: {randomNutcrackerNumberX}, {randomNutcrackerNumberX}, {randomNutcrackerNumberX}");
            }
            if (Configs.Instance.EnableSmolNutcrackers.Value && Configs.Instance.FunkyNutcrackersSize.Value)
            {
                randomNutcrackerNumberX = Random.Range(Configs.Instance.MinNutcrackerBodySize.Value, Configs.Instance.MaxNutcrackerBodySize.Value);
                randomNutcrackerNumberY = Random.Range(Configs.Instance.MinNutcrackerBodySize.Value, Configs.Instance.MaxNutcrackerBodySize.Value);
                randomNutcrackerNumberZ = Random.Range(Configs.Instance.MinNutcrackerBodySize.Value, Configs.Instance.MaxNutcrackerBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomNutcrackerNumberX, randomNutcrackerNumberY, randomNutcrackerNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Nutcracker has spawned with: {randomNutcrackerNumberX}, {randomNutcrackerNumberY}, {randomNutcrackerNumberZ}");
            }
        }
    }
}