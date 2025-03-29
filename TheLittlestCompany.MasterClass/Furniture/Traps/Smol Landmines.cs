using HarmonyLib;
using TheLittlestCompany.MasterClass.ConfigManager;
using UnityEngine;
using Unity.Netcode;
using System.Collections;

namespace TheLittlestCompany.MasterClass.Furniture.Traps
{
    [HarmonyPatch(typeof(Landmine))]
    internal class Smol_Landmines
    {
        public static float randomLandmineNumberX;
        public static float randomLandmineNumberY;
        public static float randomLandmineNumberZ;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void PatchStart(Landmine __instance)
        {
            if (!NetworkManager.Singleton.IsHost) return;

            if (!__instance.IsServer || !__instance.IsOwner) return;

            var networkObject = __instance.gameObject.GetComponentInParent<NetworkObject>();
            if (networkObject == null)
            {
                TheLittlestCompanyPlugin.Instance.mls.LogWarning("NetworkObject not found for Landmine.");
                return;
            }

            Vector3 newScale;

            if (Configs.Instance.EnableSmolLandmines.Value && !Configs.Instance.FunkyLandminesSize.Value)
            {
                randomLandmineNumberX = Random.Range(Configs.Instance.MinLandminesBodySize.Value, Configs.Instance.MaxLandminesBodySize.Value);
                newScale = new Vector3(randomLandmineNumberX, randomLandmineNumberX, randomLandmineNumberX);
            }
            else if (Configs.Instance.EnableSmolLandmines.Value && Configs.Instance.FunkyLandminesSize.Value)
            {
                randomLandmineNumberX = Random.Range(Configs.Instance.MinLandminesBodySize.Value, Configs.Instance.MaxLandminesBodySize.Value);
                randomLandmineNumberY = Random.Range(Configs.Instance.MinLandminesBodySize.Value, Configs.Instance.MaxLandminesBodySize.Value);
                randomLandmineNumberZ = Random.Range(Configs.Instance.MinLandminesBodySize.Value, Configs.Instance.MaxLandminesBodySize.Value);
                newScale = new Vector3(randomLandmineNumberX, randomLandmineNumberY, randomLandmineNumberZ);
            }
            else
            {
                return;
            }

            TheLittlestCompanyPlugin.Instance.mls.LogInfo($"A Landmine has spawned with scale: {newScale}");

            networkObject.Despawn(false);
            __instance.gameObject.transform.parent.localScale = newScale;
            networkObject.Spawn();
        }

        [HarmonyPatch("ExplodeMineServerRpc")]
        [HarmonyPostfix]
        private static void ExplodeDespawn(Landmine __instance)
        {
            if (!NetworkManager.Singleton.IsServer) return;

            __instance.StartCoroutine(HandleExplodedLandmine(__instance));
        }

        private static IEnumerator HandleExplodedLandmine(Landmine __instance)
        {
            yield return new WaitForSeconds(1.3f);

            // Disable the collider to prevent further interactions
            var collider = __instance.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            var rigidbody = __instance.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.isKinematic = true;  // Disable physics interactions
            }

            TheLittlestCompanyPlugin.Instance.mls.LogInfo($"Landmine exploded and is being removed. Position: {__instance.transform.position}");

            // Get the NetworkObject of the exploded landmine
            var networkObject = __instance.gameObject.GetComponent<NetworkObject>();
            if (networkObject != null)
            {
                networkObject.Despawn();
            }
            else
            {
                TheLittlestCompanyPlugin.Instance.mls.LogWarning("Failed to despawn exploded landmine: NetworkObject not found.");
            }

            __instance.gameObject.SetActive(false);
        }
    }
}