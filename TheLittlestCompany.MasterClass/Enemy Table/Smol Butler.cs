using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Butler
    {
        public static float randomButlerNumberX;
        public static float randomButlerNumberY;
        public static float randomButlerNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;
            
            // Only change size for the "Butler" enemy
            if (__instance.enemyType.enemyName != "Butler") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolButlers.Value && !Configs.Instance.FunkyButlersSize.Value)
            {
                randomButlerNumberX = Random.Range(Configs.Instance.MinButlerBodySize.Value, Configs.Instance.MaxButlerBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomButlerNumberX, randomButlerNumberX, randomButlerNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Slime has spawned with: {randomButlerNumberX}, {randomButlerNumberX}, {randomButlerNumberX}");
            }
            if (Configs.Instance.EnableSmolButlers.Value && Configs.Instance.FunkyButlersSize.Value)
            {
                randomButlerNumberX = Random.Range(Configs.Instance.MinButlerBodySize.Value, Configs.Instance.MaxButlerBodySize.Value);
                randomButlerNumberY = Random.Range(Configs.Instance.MinButlerBodySize.Value, Configs.Instance.MaxButlerBodySize.Value);
                randomButlerNumberZ = Random.Range(Configs.Instance.MinButlerBodySize.Value, Configs.Instance.MaxButlerBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomButlerNumberX, randomButlerNumberY, randomButlerNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Slime has spawned with: {randomButlerNumberX}, {randomButlerNumberY}, {randomButlerNumberZ}");
            }
        }
    }
}