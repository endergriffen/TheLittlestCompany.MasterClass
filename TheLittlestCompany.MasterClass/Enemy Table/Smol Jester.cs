using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Jester
    {
        public static float randomJesterNumberX;
        public static float randomJesterNumberY;
        public static float randomJesterNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Jester" enemy
            if (__instance.enemyType.enemyName != "Jester") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolJesters.Value && !Configs.Instance.FunkyJestersSize.Value)
            {
                randomJesterNumberX = Random.Range(Configs.Instance.MinJesterBodySize.Value, Configs.Instance.MaxJesterBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomJesterNumberX, randomJesterNumberX, randomJesterNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Jester has spawned with: {randomJesterNumberX}, {randomJesterNumberX}, {randomJesterNumberX}");
            }
            if (Configs.Instance.EnableSmolJesters.Value && Configs.Instance.FunkyJestersSize.Value)
            {
                randomJesterNumberX = Random.Range(Configs.Instance.MinJesterBodySize.Value, Configs.Instance.MaxJesterBodySize.Value);
                randomJesterNumberY = Random.Range(Configs.Instance.MinJesterBodySize.Value, Configs.Instance.MaxJesterBodySize.Value);
                randomJesterNumberZ = Random.Range(Configs.Instance.MinJesterBodySize.Value, Configs.Instance.MaxJesterBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomJesterNumberX, randomJesterNumberY, randomJesterNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Jester has spawned with: {randomJesterNumberX}, {randomJesterNumberY}, {randomJesterNumberZ}");
            }
        }
    }
}