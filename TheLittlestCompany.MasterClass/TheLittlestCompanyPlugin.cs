using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using TheLittlestCompany.MasterClass.Commands;
using TheLittlestCompany.MasterClass.ConfigManager;
using TheLittlestCompany.MasterClass.Enemy_Table;
using TheLittlestCompany.MasterClass.Furniture.Terminal_Patch;
using TheLittlestCompany.MasterClass.Furniture.Traps;
using TheLittlestCompany.MasterClass.Player_Table;
using UnityEngine;

namespace TheLittlestCompany.MasterClass
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class TheLittlestCompanyPlugin : BaseUnityPlugin
    {
        private const string modGUID = "endergriffen.TheLittlestCompany";
        private const string modName = "TheLittlestCompany";
        private const string modVersion = "3.8.2";

        public readonly Harmony harmony = new Harmony(modGUID);
        public static TheLittlestCompanyPlugin Instance;
        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource("TheLittlestCompany");
            mls.LogInfo("The Littlest Company is alive!");

            Configs.Instance.Setup(Config);

            SyncConfigs syncConfigs = gameObject.AddComponent<SyncConfigs>();

            if (syncConfigs.IsHost)
            {
                syncConfigs.RequestConfigSync();
            }

            harmony.PatchAll(typeof(TheLittlestCompanyPlugin));
            harmony.PatchAll(typeof(Configs));
            harmony.PatchAll(typeof(SyncConfigs));

            // harmony.PatchAll(typeof(Failure_Punishment));
            harmony.PatchAll(typeof(Player_Joins));
            harmony.PatchAll(typeof(Player_Size));
            harmony.PatchAll(typeof(Visor_Fix));

            harmony.PatchAll(typeof(Terminal_Reflection_Extensions));
            harmony.PatchAll(typeof(Terminal_Check_Patch));
            harmony.PatchAll(typeof(Set_Terminal_Size));
            harmony.PatchAll(typeof(Reset_Terminal_Size));

            // harmony.PatchAll(typeof(All_Commands));

            harmony.PatchAll(typeof(Smol_Bracken));
            harmony.PatchAll(typeof(Smol_Butler));
            harmony.PatchAll(typeof(Smol_Coilhead));
            harmony.PatchAll(typeof(Smol_Hoardingbug));
            harmony.PatchAll(typeof(Smol_Lizard));
            harmony.PatchAll(typeof(Smol_Masked_Boi));
            harmony.PatchAll(typeof(Smol_Nutcracker));
            harmony.PatchAll(typeof(Smol_Slimes));
            harmony.PatchAll(typeof(Smol_Snare));
            harmony.PatchAll(typeof(Smol_Spider));
            harmony.PatchAll(typeof(Smol_Thumper));

            harmony.PatchAll(typeof(Smol_Baboon));
            harmony.PatchAll(typeof(Smol_Dogs));
            harmony.PatchAll(typeof(Smol_Giants));
            harmony.PatchAll(typeof(Smol_Mech));
            harmony.PatchAll(typeof(Smol_Tulip));
            harmony.PatchAll(typeof(Smol_Worm));

            harmony.PatchAll(typeof(Smol_Barber));
            harmony.PatchAll(typeof(Smol_Girl));
            harmony.PatchAll(typeof(Smol_Jester));
            // harmony.PatchAll(typeof(Smol_ManEater));

            harmony.PatchAll(typeof(Trap_Handler));

            harmony.PatchAll(typeof(Smol_Landmines));
            harmony.PatchAll(typeof(Smol_Turrets));
            harmony.PatchAll(typeof(Smol_Spikes));
        }
    }
}