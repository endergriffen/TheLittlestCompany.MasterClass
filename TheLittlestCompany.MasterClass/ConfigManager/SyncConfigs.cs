using System.Collections;
using Unity.Netcode;
using UnityEngine;

namespace TheLittlestCompany.MasterClass.ConfigManager
{
    public class SyncConfigs : NetworkBehaviour
    {
        private static SyncConfigs instance;

        public static SyncConfigs Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<SyncConfigs>();
                }
                return instance;
            }
        }

        private void Start()
        {
            if (IsHost)
            {
                StartCoroutine(ConfigSyncRoutine());
            }
        }

        private IEnumerator ConfigSyncRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(2f);
                RequestConfigSync();
            }
        }

        public void RequestConfigSync()
        {
            if (IsHost)
            {
                ConfigSyncServerRpc();
            }
        }

        [ServerRpc(RequireOwnership = false)]
        public void ConfigSyncServerRpc(ServerRpcParams rpcParams = default)
        {
            ConfigSyncClientRpc(
                Configs.Instance.BodySizeX.Value,
                Configs.Instance.BodySizeY.Value,
                Configs.Instance.BodySizeZ.Value,
                Configs.Instance.HeadSizeX.Value,
                Configs.Instance.HeadSizeY.Value,
                Configs.Instance.HeadSizeZ.Value,
                Configs.Instance.RandomizeBodySize.Value,
                Configs.Instance.RandomizeHeadSize.Value,
                Configs.Instance.FunkyRandomBodySize.Value,
                Configs.Instance.HideVisor.Value
            );
        }

        [ClientRpc]
        public void ConfigSyncClientRpc(
            float bodySizeX, float bodySizeY, float bodySizeZ,
            float headSizeX, float headSizeY, float headSizeZ,
            bool randomizeBodySize, bool randomizeHeadSize,
            bool funkyRandomizeBodySize, bool hideVisor)
        {
            if (Configs.Instance.BodySizeX.Value != bodySizeX) Configs.Instance.BodySizeX.Value = bodySizeX;
            if (Configs.Instance.BodySizeY.Value != bodySizeY) Configs.Instance.BodySizeY.Value = bodySizeY;
            if (Configs.Instance.BodySizeZ.Value != bodySizeZ) Configs.Instance.BodySizeZ.Value = bodySizeZ;
            if (Configs.Instance.HeadSizeX.Value != headSizeX) Configs.Instance.HeadSizeX.Value = headSizeX;
            if (Configs.Instance.HeadSizeY.Value != headSizeY) Configs.Instance.HeadSizeY.Value = headSizeY;
            if (Configs.Instance.HeadSizeZ.Value != headSizeZ) Configs.Instance.HeadSizeZ.Value = headSizeZ;
            if (Configs.Instance.RandomizeBodySize.Value != randomizeBodySize) Configs.Instance.RandomizeBodySize.Value = randomizeBodySize;
            if (Configs.Instance.RandomizeHeadSize.Value != randomizeHeadSize) Configs.Instance.RandomizeHeadSize.Value = randomizeHeadSize;
            if (Configs.Instance.FunkyRandomBodySize.Value != funkyRandomizeBodySize) Configs.Instance.FunkyRandomBodySize.Value = funkyRandomizeBodySize;
            if (Configs.Instance.HideVisor.Value != hideVisor) Configs.Instance.HideVisor.Value = hideVisor;
        }
    }
}