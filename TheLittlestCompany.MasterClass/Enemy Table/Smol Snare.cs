using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Snare
    {
        public static float randomSnareNumberX;
        public static float randomSnareNumberY;
        public static float randomSnareNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Centipede" enemy
            if (__instance.enemyType.enemyName != "Centipede") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolSnares.Value && !Configs.Instance.FunkySnaresSize.Value)
            {
                randomSnareNumberX = Random.Range(Configs.Instance.MinSnareBodySize.Value, Configs.Instance.MaxSnareBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomSnareNumberX, randomSnareNumberX, randomSnareNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Slime has spawned with: {randomSnareNumberX}, {randomSnareNumberX}, {randomSnareNumberX}");
            }
            if (Configs.Instance.EnableSmolSnares.Value && Configs.Instance.FunkySnaresSize.Value)
            {
                randomSnareNumberX = Random.Range(Configs.Instance.MinSnareBodySize.Value, Configs.Instance.MaxSnareBodySize.Value);
                randomSnareNumberY = Random.Range(Configs.Instance.MinSnareBodySize.Value, Configs.Instance.MaxSnareBodySize.Value);
                randomSnareNumberZ = Random.Range(Configs.Instance.MinSnareBodySize.Value, Configs.Instance.MaxSnareBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomSnareNumberX, randomSnareNumberY, randomSnareNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Slime has spawned with: {randomSnareNumberX}, {randomSnareNumberY}, {randomSnareNumberZ}");
            }
        }
    }
}