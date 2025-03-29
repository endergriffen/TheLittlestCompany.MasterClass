using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_ManEater
    {
        public static float randomManEaterNumberX;
        public static float randomManEaterNumberY;
        public static float randomManEaterNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "CaveDweller" enemy
            if (__instance.enemyType.enemyName != "Cave Dweller") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolManEaters.Value && !Configs.Instance.FunkyManEatersSize.Value)
            {
                randomManEaterNumberX = Random.Range(Configs.Instance.MinManEatersBodySize.Value, Configs.Instance.MaxManEatersBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomManEaterNumberX, randomManEaterNumberX, randomManEaterNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A ManEater has spawned with: {randomManEaterNumberX}, {randomManEaterNumberX}, {randomManEaterNumberX}");
            }
            if (Configs.Instance.EnableSmolManEaters.Value && Configs.Instance.FunkyManEatersSize.Value)
            {
                randomManEaterNumberX = Random.Range(Configs.Instance.MinManEatersBodySize.Value, Configs.Instance.MaxManEatersBodySize.Value);
                randomManEaterNumberY = Random.Range(Configs.Instance.MinManEatersBodySize.Value, Configs.Instance.MaxManEatersBodySize.Value);
                randomManEaterNumberZ = Random.Range(Configs.Instance.MinManEatersBodySize.Value, Configs.Instance.MaxManEatersBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomManEaterNumberX, randomManEaterNumberY, randomManEaterNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A ManEater has spawned with: {randomManEaterNumberX}, {randomManEaterNumberY}, {randomManEaterNumberZ}");
            }
        }
    }
}