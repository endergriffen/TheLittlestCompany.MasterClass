using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class Smol_Barber
    {
        public static float randomBarberNumberX;
        public static float randomBarberNumberY;
        public static float randomBarberNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(EnemyAI __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Clay Surgeon" enemy
            if (__instance.enemyType.enemyName != "Clay Surgeon") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolBarbers.Value && !Configs.Instance.FunkyBarbersSize.Value)
            {
                randomBarberNumberX = Random.Range(Configs.Instance.MinBarberBodySize.Value, Configs.Instance.MaxBarberBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomBarberNumberX, randomBarberNumberX, randomBarberNumberX);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Barber has spawned with: {randomBarberNumberX}, {randomBarberNumberX}, {randomBarberNumberX}");
            }
            if (Configs.Instance.EnableSmolBarbers.Value && Configs.Instance.FunkyBarbersSize.Value)
            {
                randomBarberNumberX = Random.Range(Configs.Instance.MinBarberBodySize.Value, Configs.Instance.MaxBarberBodySize.Value);
                randomBarberNumberY = Random.Range(Configs.Instance.MinBarberBodySize.Value, Configs.Instance.MaxBarberBodySize.Value);
                randomBarberNumberZ = Random.Range(Configs.Instance.MinBarberBodySize.Value, Configs.Instance.MaxBarberBodySize.Value);

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomBarberNumberX, randomBarberNumberY, randomBarberNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Barber has spawned with: {randomBarberNumberX}, {randomBarberNumberY}, {randomBarberNumberZ}");
            }
        }
    }
}