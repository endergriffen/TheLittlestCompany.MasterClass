using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Dogs
    {
        public static float randomDogNumberX;
        public static float randomDogNumberY;
        public static float randomDogNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "MouthDog" enemy
            if (__instance.enemyType.enemyName != "MouthDog") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolDogs.Value && !Configs.Instance.FunkyDogsSize.Value)
            {
                randomDogNumberX = Random.Range(Configs.Instance.MinDogBodySize.Value, Configs.Instance.MaxDogBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomDogNumberX, randomDogNumberX, randomDogNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Dog has spawned with: {randomDogNumberX}, {randomDogNumberX}, {randomDogNumberX}");
            }
            if (Configs.Instance.EnableSmolDogs.Value && Configs.Instance.FunkyDogsSize.Value)
            {
                randomDogNumberX = Random.Range(Configs.Instance.MinDogBodySize.Value, Configs.Instance.MaxDogBodySize.Value);
                randomDogNumberY = Random.Range(Configs.Instance.MinDogBodySize.Value, Configs.Instance.MaxDogBodySize.Value);
                randomDogNumberZ = Random.Range(Configs.Instance.MinDogBodySize.Value, Configs.Instance.MaxDogBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomDogNumberX, randomDogNumberY, randomDogNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Dog has spawned with: {randomDogNumberX}, {randomDogNumberY}, {randomDogNumberZ}");
            }
        }
    }
}