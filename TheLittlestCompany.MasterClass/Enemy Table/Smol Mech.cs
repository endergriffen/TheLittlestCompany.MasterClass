using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Mech
    {
        public static float randomMechNumberX;
        public static float randomMechNumberY;
        public static float randomMechNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "RadMech" enemy
            if (__instance.enemyType.enemyName != "RadMech") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolMechs.Value && !Configs.Instance.FunkyMechsSize.Value)
            {
                randomMechNumberX = Random.Range(Configs.Instance.MinMechBodySize.Value, Configs.Instance.MaxMechBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomMechNumberX, randomMechNumberX, randomMechNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Mech has spawned with: {randomMechNumberX}, {randomMechNumberX}, {randomMechNumberX}");
            }
            if (Configs.Instance.EnableSmolMechs.Value && Configs.Instance.FunkyMechsSize.Value)
            {
                randomMechNumberX = Random.Range(Configs.Instance.MinMechBodySize.Value, Configs.Instance.MaxMechBodySize.Value);
                randomMechNumberY = Random.Range(Configs.Instance.MinMechBodySize.Value, Configs.Instance.MaxMechBodySize.Value);
                randomMechNumberZ = Random.Range(Configs.Instance.MinMechBodySize.Value, Configs.Instance.MaxMechBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomMechNumberX, randomMechNumberY, randomMechNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Mech has spawned with: {randomMechNumberX}, {randomMechNumberY}, {randomMechNumberZ}");
            }
        }
    }
}