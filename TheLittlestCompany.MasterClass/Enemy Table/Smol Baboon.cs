using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Baboon
    {
        public static float randomBaboonNumberX;
        public static float randomBaboonNumberY;
        public static float randomBaboonNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Baboon hawk" enemy
            if (__instance.enemyType.enemyName != "Baboon hawk") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolBaboons.Value && !Configs.Instance.FunkyBaboonsSize.Value)
            {
                randomBaboonNumberX = Random.Range(Configs.Instance.MinBaboonBodySize.Value, Configs.Instance.MaxBaboonBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomBaboonNumberX, randomBaboonNumberX, randomBaboonNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Baboon Hawk has spawned with: {randomBaboonNumberX}, {randomBaboonNumberX}, {randomBaboonNumberX}");
            }
            if (Configs.Instance.EnableSmolBaboons.Value && Configs.Instance.FunkyBaboonsSize.Value)
            {
                randomBaboonNumberX = Random.Range(Configs.Instance.MinBaboonBodySize.Value, Configs.Instance.MaxBaboonBodySize.Value);
                randomBaboonNumberY = Random.Range(Configs.Instance.MinBaboonBodySize.Value, Configs.Instance.MaxBaboonBodySize.Value);
                randomBaboonNumberZ = Random.Range(Configs.Instance.MinBaboonBodySize.Value, Configs.Instance.MaxBaboonBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomBaboonNumberX, randomBaboonNumberY, randomBaboonNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Baboon Hawk has spawned with: {randomBaboonNumberX}, {randomBaboonNumberY}, {randomBaboonNumberZ}");
            }
        }
    }
}