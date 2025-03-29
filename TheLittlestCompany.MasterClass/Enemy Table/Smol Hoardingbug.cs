using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Hoardingbug
    {
        public static float randomHoardingbugNumberX;
        public static float randomHoardingbugNumberY;
        public static float randomHoardingbugNumberZ;
        private static bool useLowerRange = true; // Toggle flag to alternate ranges

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Hoarding bug" enemy
            if (__instance.enemyType.enemyName != "Hoarding bug") return;

            float minSize = Configs.Instance.MinHoardingbugBodySize.Value;
            float maxSize = Configs.Instance.MaxHoardingbugBodySize.Value;
            float midSize = (minSize + maxSize) / 2;

            // Determine range based on the toggle
            float rangeMin = useLowerRange ? minSize : midSize;
            float rangeMax = useLowerRange ? midSize : maxSize;

            // Toggle the range for the next use
            useLowerRange = !useLowerRange;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolHoardingbugs.Value && !Configs.Instance.FunkyHoardingbugsSize.Value)
            {
                randomHoardingbugNumberX = Random.Range(rangeMin, rangeMax);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomHoardingbugNumberX, randomHoardingbugNumberX, randomHoardingbugNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Hoarding Bug has spawned with: {randomHoardingbugNumberX}, {randomHoardingbugNumberX}, {randomHoardingbugNumberX}");
            }
            if (Configs.Instance.EnableSmolHoardingbugs.Value && Configs.Instance.FunkyHoardingbugsSize.Value)
            {
                randomHoardingbugNumberX = Random.Range(rangeMin, rangeMax);
                randomHoardingbugNumberY = Random.Range(rangeMin, rangeMax);
                randomHoardingbugNumberZ = Random.Range(rangeMin, rangeMax);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomHoardingbugNumberX, randomHoardingbugNumberY, randomHoardingbugNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Hoarding Bug has spawned with: {randomHoardingbugNumberX}, {randomHoardingbugNumberY}, {randomHoardingbugNumberZ}");
            }
        }
    }
}