using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.Enemy_Table
{
    [HarmonyPatch(typeof(MaskedPlayerEnemy))]
    internal class Smol_Masked_Boi
    {
        public static float randomMaskNumberX;
        public static float randomMaskNumberY;
        public static float randomMaskNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(MaskedPlayerEnemy __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            // Only change size for the "Masked" enemy
            if (__instance.enemyType.enemyName != "Masked") return;

            // Fun mode adjustments
            if (Configs.Instance.EnableSmolMask.Value && !Configs.Instance.MaskedCopyPlayerSize.Value)
            {
                randomMaskNumberX = Configs.Instance.MaskBodySizeX.Value;
                randomMaskNumberY = Configs.Instance.MaskBodySizeY.Value;
                randomMaskNumberZ = Configs.Instance.MaskBodySizeZ.Value;

                // Update the enemy size
                __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                __instance.gameObject.transform.localScale = new Vector3(randomMaskNumberX, randomMaskNumberY, randomMaskNumberZ);
                __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Masked are now: {randomMaskNumberX}, {randomMaskNumberY}, {randomMaskNumberZ}");
            }
            else if (Configs.Instance.EnableSmolMask.Value && Configs.Instance.MaskedCopyPlayerSize.Value)
            {
                if (Configs.Instance.FunkyRandomBodySize.Value)
                {
                    randomMaskNumberX = Random.Range(0.2f, 1.5f);
                    randomMaskNumberY = Random.Range(0.2f, 1.5f);
                    randomMaskNumberZ = Random.Range(0.2f, 1.5f);

                    // Update the enemy size
                    __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                    __instance.gameObject.transform.localScale = new Vector3(randomMaskNumberX, randomMaskNumberY, randomMaskNumberZ);
                    __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                    TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Masked Random number: {randomMaskNumberX}, {randomMaskNumberY}, {randomMaskNumberZ}");
                }
                if (Configs.Instance.RandomizeBodySize.Value && !Configs.Instance.FunkyRandomBodySize.Value)
                {
                    randomMaskNumberX = Random.Range(0.2f, 1.5f);

                    // Update the enemy size
                    __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                    __instance.gameObject.transform.localScale = new Vector3(randomMaskNumberX, randomMaskNumberX, randomMaskNumberX);
                    __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                    TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Masked Random number: {randomMaskNumberX}, {randomMaskNumberX}, {randomMaskNumberX}");
                }
                if (!Configs.Instance.FunkyRandomBodySize.Value && !Configs.Instance.RandomizeBodySize.Value)
                {
                    randomMaskNumberX = Configs.Instance.BodySizeX.Value;
                    randomMaskNumberY = Configs.Instance.BodySizeY.Value;
                    randomMaskNumberZ = Configs.Instance.BodySizeZ.Value;

                    // Update the enemy size
                    __instance.gameObject.GetComponent<NetworkObject>().Despawn(false);
                    __instance.gameObject.transform.localScale = new Vector3(randomMaskNumberX, randomMaskNumberY, randomMaskNumberZ);
                    __instance.gameObject.GetComponent<NetworkObject>().Spawn();
                    TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Masked are now: {randomMaskNumberX}, {randomMaskNumberY}, {randomMaskNumberZ}");
                }
            }
            else
            {
                TheLittlestCompanyPlugin.Instance.mls.LogInfo($"EnableSmolMasks is false no smol masks for you!");
            }
        }
    }
}