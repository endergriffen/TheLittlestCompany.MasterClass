using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Lizard
    {
        public static float randomLizardNumberX;
        public static float randomLizardNumberY;
        public static float randomLizardNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Puffer" enemy
            if (__instance.enemyType.enemyName != "Puffer") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolLizards.Value && !Configs.Instance.FunkyLizardsSize.Value)
            {
                randomLizardNumberX = Random.Range(Configs.Instance.MinLizardBodySize.Value, Configs.Instance.MaxLizardBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomLizardNumberX, randomLizardNumberX, randomLizardNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Slime has spawned with: {randomLizardNumberX}, {randomLizardNumberX}, {randomLizardNumberX}");
            }
            if (Configs.Instance.EnableSmolLizards.Value && Configs.Instance.FunkyLizardsSize.Value)
            {
                randomLizardNumberX = Random.Range(Configs.Instance.MinLizardBodySize.Value, Configs.Instance.MaxLizardBodySize.Value);
                randomLizardNumberY = Random.Range(Configs.Instance.MinLizardBodySize.Value, Configs.Instance.MaxLizardBodySize.Value);
                randomLizardNumberZ = Random.Range(Configs.Instance.MinLizardBodySize.Value, Configs.Instance.MaxLizardBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomLizardNumberX, randomLizardNumberY, randomLizardNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Slime has spawned with: {randomLizardNumberX}, {randomLizardNumberY}, {randomLizardNumberZ}");
            }
        }
    }
}