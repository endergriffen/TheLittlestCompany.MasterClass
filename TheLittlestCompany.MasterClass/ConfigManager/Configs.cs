using BepInEx.Configuration;

namespace TheLittlestCompany.MasterClass.ConfigManager
{
    public class Configs
    {
        private static Configs instance;

        public static Configs Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Configs();
                }
                return instance;
            }
        }

        public ConfigEntry<float> BodySizeX { get; private set; }
        public ConfigEntry<float> BodySizeY { get; private set; }
        public ConfigEntry<float> BodySizeZ { get; private set; }

        public ConfigEntry<float> HeadSizeX { get; private set; }
        public ConfigEntry<float> HeadSizeY { get; private set; }
        public ConfigEntry<float> HeadSizeZ { get; private set; }

        public ConfigEntry<bool> RandomizeBodySize { get; private set; }
        public ConfigEntry<bool> RandomizeHeadSize { get; private set; }
        public ConfigEntry<bool> FunkyRandomBodySize { get; private set; }

        public ConfigEntry<bool> FailurePenalty { get; private set; }

        public ConfigEntry<bool> EnableSmolBrackens { get; private set; }
        public ConfigEntry<bool> FunkyBrackensSize { get; private set; }
        public ConfigEntry<float> MinBrackenBodySize { get; private set; }
        public ConfigEntry<float> MaxBrackenBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolButlers { get; private set; }
        public ConfigEntry<bool> FunkyButlersSize { get; private set; }
        public ConfigEntry<float> MinButlerBodySize { get; private set; }
        public ConfigEntry<float> MaxButlerBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolCoilheads { get; private set; }
        public ConfigEntry<bool> FunkyCoilheadsSize { get; private set; }
        public ConfigEntry<float> MinCoilheadBodySize { get; private set; }
        public ConfigEntry<float> MaxCoilheadBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolHoardingbugs { get; private set; }
        public ConfigEntry<bool> FunkyHoardingbugsSize { get; private set; }
        public ConfigEntry<float> MinHoardingbugBodySize { get; private set; }
        public ConfigEntry<float> MaxHoardingbugBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolLizards { get; private set; }
        public ConfigEntry<bool> FunkyLizardsSize { get; private set; }
        public ConfigEntry<float> MinLizardBodySize { get; private set; }
        public ConfigEntry<float> MaxLizardBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolMask { get; private set; }
        public ConfigEntry<bool> MaskedCopyPlayerSize { get; private set; }
        public ConfigEntry<float> MaskBodySizeX { get; private set; }
        public ConfigEntry<float> MaskBodySizeY { get; private set; }
        public ConfigEntry<float> MaskBodySizeZ { get; private set; }

        public ConfigEntry<bool> EnableSmolNutcrackers { get; private set; }
        public ConfigEntry<bool> FunkyNutcrackersSize { get; private set; }
        public ConfigEntry<float> MinNutcrackerBodySize { get; private set; }
        public ConfigEntry<float> MaxNutcrackerBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolSlimes { get; private set; }
        public ConfigEntry<bool> FunkySlimesSize { get; private set; }
        public ConfigEntry<float> MinSlimeBodySize { get; private set; }
        public ConfigEntry<float> MaxSlimeBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolSnares { get; private set; }
        public ConfigEntry<bool> FunkySnaresSize { get; private set; }
        public ConfigEntry<float> MinSnareBodySize { get; private set; }
        public ConfigEntry<float> MaxSnareBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolSpiders { get; private set; }
        public ConfigEntry<bool> FunkySpidersSize { get; private set; }
        public ConfigEntry<float> MinSpiderBodySize { get; private set; }
        public ConfigEntry<float> MaxSpiderBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolThumpers { get; private set; }
        public ConfigEntry<bool> FunkyThumpersSize { get; private set; }
        public ConfigEntry<float> MinThumperBodySize { get; private set; }
        public ConfigEntry<float> MaxThumperBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolBaboons { get; private set; }
        public ConfigEntry<bool> FunkyBaboonsSize { get; private set; }
        public ConfigEntry<float> MinBaboonBodySize { get; private set; }
        public ConfigEntry<float> MaxBaboonBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolDogs { get; private set; }
        public ConfigEntry<bool> FunkyDogsSize { get; private set; }
        public ConfigEntry<float> MinDogBodySize { get; private set; }
        public ConfigEntry<float> MaxDogBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolGiants { get; private set; }
        public ConfigEntry<bool> FunkyGiantsSize { get; private set; }
        public ConfigEntry<float> MinGiantBodySize { get; private set; }
        public ConfigEntry<float> MaxGiantBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolMechs { get; private set; }
        public ConfigEntry<bool> FunkyMechsSize { get; private set; }
        public ConfigEntry<float> MinMechBodySize { get; private set; }
        public ConfigEntry<float> MaxMechBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolTulips { get; private set; }
        public ConfigEntry<bool> FunkyTulipsSize { get; private set; }
        public ConfigEntry<float> MinTulipBodySize { get; private set; }
        public ConfigEntry<float> MaxTulipBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolWorms { get; private set; }
        public ConfigEntry<bool> FunkyWormsSize { get; private set; }
        public ConfigEntry<float> MinWormBodySize { get; private set; }
        public ConfigEntry<float> MaxWormBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolBarbers { get; private set; }
        public ConfigEntry<bool> FunkyBarbersSize { get; private set; }
        public ConfigEntry<float> MinBarberBodySize { get; private set; }
        public ConfigEntry<float> MaxBarberBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolGirls { get; private set; }
        public ConfigEntry<bool> FunkyGirlsSize { get; private set; }
        public ConfigEntry<float> MinGirlBodySize { get; private set; }
        public ConfigEntry<float> MaxGirlBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolJesters { get; private set; }
        public ConfigEntry<bool> FunkyJestersSize { get; private set; }
        public ConfigEntry<float> MinJesterBodySize { get; private set; }
        public ConfigEntry<float> MaxJesterBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolManEaters { get; private set; }
        public ConfigEntry<bool> FunkyManEatersSize { get; private set; }
        public ConfigEntry<float> MinManEatersBodySize { get; private set; }
        public ConfigEntry<float> MaxManEatersBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolLandmines { get; private set; }
        public ConfigEntry<bool> FunkyLandminesSize { get; private set; }
        public ConfigEntry<float> MinLandminesBodySize { get; private set; }
        public ConfigEntry<float> MaxLandminesBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolTurrets { get; private set; }
        public ConfigEntry<bool> FunkyTurretsSize { get; private set; }
        public ConfigEntry<float> MinTurretsBodySize { get; private set; }
        public ConfigEntry<float> MaxTurretsBodySize { get; private set; }

        public ConfigEntry<bool> EnableSmolSpikeTraps { get; private set; }
        public ConfigEntry<bool> FunkySpikeTrapsSize { get; private set; }
        public ConfigEntry<float> MinSpikeTrapsBodySize { get; private set; }
        public ConfigEntry<float> MaxSpikeTrapsBodySize { get; private set; }

        public ConfigEntry<bool> HideVisor { get; private set; }
        public ConfigEntry<bool> EnableLogging { get; private set; }

        public void Setup(ConfigFile config)
        {
            BodySizeX = config.Bind("Body", "Body Size X", 0.5f, "Change the size of the body. \n Also affects head size.");
            BodySizeY = config.Bind("Body", "Body Size Y", 0.5f, "Change the size of the body. \n Also affects head size.");
            BodySizeZ = config.Bind("Body", "Body Size Z", 0.5f, "Change the size of the body. \n Also affects head size.");

            HeadSizeX = config.Bind("Head", "Head Size X", 2f, "Multiply the size of the head.");
            HeadSizeY = config.Bind("Head", "Head Size Y", 2f, "Multiply the size of the head.");
            HeadSizeZ = config.Bind("Head", "Head Size Z", 2f, "Multiply the size of the head.");

            FunkyRandomBodySize = config.Bind("Body", "Funky Random Body Size", false, "Set this to true to randomly size body in all dimensions (x, y, z). Ignores other body size configs.");
            RandomizeBodySize = config.Bind("Body", "Randomize Body Size", false, "Set this to true to randomize the body size between 0.2 and 1.5.");
            RandomizeHeadSize = config.Bind("Head", "Randomize Head Size", false, "Set this to true to randomize the head size between 0.2 and 3.");

            FailurePenalty = config.Bind("Head", "Failure Penalty", false, "Will set a new Random size for every player if you all die.\n One of the Random Size Configs needs to be active for this to take effect.");

            EnableSmolBrackens = config.Bind("Inside Enemy", "Enable Smol Brackens", true, "Allows Bracken Enemies to be small.");
            FunkyBrackensSize = config.Bind("Inside Enemy", "Funky Bracken Size", false, "If true the Bracken Enemies will have a random body size in all dimensions.");
            MinBrackenBodySize = config.Bind("Inside Enemy", "Minimum Bracken Body Size", 0.625f, "Change the minimum size of the Bracken body.");
            MaxBrackenBodySize = config.Bind("Inside Enemy", "Maximum Bracken Body Size", 0.95f, "Change the maximum size of the Bracken body.");

            EnableSmolButlers = config.Bind("Inside Enemy", "Enable Smol Butlers", true, "Allows Butler Enemies to be small.");
            FunkyButlersSize = config.Bind("Inside Enemy", "Funky Butler Size", false, "If true the Butler Enemies will have a random body size in all dimensions.");
            MinButlerBodySize = config.Bind("Inside Enemy", "Minimum Butler Body Size", 0.5f, "Change the minimum size of the Butler body.");
            MaxButlerBodySize = config.Bind("Inside Enemy", "Maximum Butler Body Size", 1.15f, "Change the maximum size of the Butler body.");

            EnableSmolCoilheads = config.Bind("Inside Enemy", "Enable Smol Coilheads", true, "Allows Coilhead Enemies to be small.");
            FunkyCoilheadsSize = config.Bind("Inside Enemy", "Funky Coilhead Size", false, "If true the Coilhead Enemies will have a random body size in all dimensions.");
            MinCoilheadBodySize = config.Bind("Inside Enemy", "Minimum Coilhead Body Size", 0.5f, "Change the minimum size of the Coilhead body.");
            MaxCoilheadBodySize = config.Bind("Inside Enemy", "Maximum Coilhead Body Size", 1.35f, "Change the maximum size of the Coilhead body.");

            EnableSmolHoardingbugs = config.Bind("Inside Enemy", "Enable Smol Hoardingbugs", true, "Allows Hoardingbug Enemies to be small.");
            FunkyHoardingbugsSize = config.Bind("Inside Enemy", "Funky Hoardingbug Size", false, "If true the Hoardingbug Enemies will have a random body size in all dimensions.");
            MinHoardingbugBodySize = config.Bind("Inside Enemy", "Minimum Hoardingbug Body Size", 0.05f, "Change the minimum size of the Hoardingbug body.");
            MaxHoardingbugBodySize = config.Bind("Inside Enemy", "Maximum Hoardingbug Body Size", 0.35f, "Change the maximum size of the Hoardingbug body.");

            EnableSmolLizards = config.Bind("Inside Enemy", "Enable Smol Lizards", true, "Allows Lizard Enemies to be small.");
            FunkyLizardsSize = config.Bind("Inside Enemy", "Funky Lizard Size", false, "If true the Lizard Enemies will have a random body size in all dimensions.");
            MinLizardBodySize = config.Bind("Inside Enemy", "Minimum Lizard Body Size", 0.5f, "Change the minimum size of the Lizard body.");
            MaxLizardBodySize = config.Bind("Inside Enemy", "Maximum Lizard Body Size", 1.15f, "Change the maximum size of the Lizard body.");

            EnableSmolMask = config.Bind("Inside Enemy", "Enable Smol Mask", true, "Allows Masked Enemies to be small.");
            MaskedCopyPlayerSize = config.Bind("Inside Enemy", "Funky Mask Size", false, "If true the Masked Enemies will copy the config sizes set for the player. \n This also includes any random sizes.");
            MaskBodySizeX = config.Bind("Inside Enemy", "Mask Body Size X", 0.5f, "Change the size of the Masked body.");
            MaskBodySizeY = config.Bind("Inside Enemy", "Mask Body Size Y", 0.5f, "Change the size of the Masked body.");
            MaskBodySizeZ = config.Bind("Inside Enemy", "Mask Body Size Z", 0.5f, "Change the size of the Masked body.");

            EnableSmolNutcrackers = config.Bind("Inside Enemy", "Enable Smol Nutcrackers", true, "Allows Nutcracker Enemies to be small.");
            FunkyNutcrackersSize = config.Bind("Inside Enemy", "Funky Nutcracker Size", false, "If true the Nutcracker Enemies will have a random body size in all dimensions.");
            MinNutcrackerBodySize = config.Bind("Inside Enemy", "Minimum Nutcracker Body Size", 0.5f, "Change the minimum size of the Nutcracker body.");
            MaxNutcrackerBodySize = config.Bind("Inside Enemy", "Maximum Nutcracker Body Size", 1.3f, "Change the maximum size of the Nutcracker body.");

            EnableSmolSlimes = config.Bind("Inside Enemy", "Enable Smol Slimes", true, "Allows Slime Enemies to be small.");
            FunkySlimesSize = config.Bind("Inside Enemy", "Funky Slime Size", false, "If true the Slime Enemies will have a random body size in all dimensions.");
            MinSlimeBodySize = config.Bind("Inside Enemy", "Minimum Slime Body Size", 0.25f, "Change the minimum size of the Slime body.");
            MaxSlimeBodySize = config.Bind("Inside Enemy", "Maximum Slime Body Size", 1.5f, "Change the maximum size of the Slime body.");

            EnableSmolSnares = config.Bind("Inside Enemy", "Enable Smol Snares", true, "Allows Snare Enemies to be small.");
            FunkySnaresSize = config.Bind("Inside Enemy", "Funky Snare Size", false, "If true the Snare Enemies will have a random body size in all dimensions.");
            MinSnareBodySize = config.Bind("Inside Enemy", "Minimum Snare Body Size", 0.35f, "Change the minimum size of the Snare body.");
            MaxSnareBodySize = config.Bind("Inside Enemy", "Maximum Snare Body Size", 1.25f, "Change the maximum size of the Snare body.");

            EnableSmolSpiders = config.Bind("Inside Enemy", "Enable Smol Spiders", true, "Allows Spider Enemies to be small.");
            FunkySpidersSize = config.Bind("Inside Enemy", "Funky Spider Size", false, "If true the Spider Enemies will have a random body size in all dimensions.");
            MinSpiderBodySize = config.Bind("Inside Enemy", "Minimum Spider Body Size", 0.35f, "Change the minimum size of the Spider body.");
            MaxSpiderBodySize = config.Bind("Inside Enemy", "Maximum Spider Body Size", 0.85f, "Change the maximum size of the Spider body.");

            EnableSmolThumpers = config.Bind("Inside Enemy", "Enable Smol Thumpers", true, "Allows Thumper Enemies to be small. \n If big seems to lag alot");
            FunkyThumpersSize = config.Bind("Inside Enemy", "Funky Thumper Size", false, "If true the Thumper Enemies will have a random body size in all dimensions.");
            MinThumperBodySize = config.Bind("Inside Enemy", "Minimum Thumper Body Size", 0.7f, "Change the minimum size of the Thumper body.");
            MaxThumperBodySize = config.Bind("Inside Enemy", "Maximum Thumper Body Size", 0.95f, "Change the maximum size of the Thumper body.");


            EnableSmolBaboons = config.Bind("Outside Enemy", "Enable Smol Baboons", true, "Allows Baboon Enemies to be small.");
            FunkyBaboonsSize = config.Bind("Outside Enemy", "Funky Baboon Size", false, "If true the Baboon Enemies will have a random body size in all dimensions.");
            MinBaboonBodySize = config.Bind("Outside Enemy", "Minimum Baboon Body Size", 0.8f, "Change the minimum size of the Baboon body.");
            MaxBaboonBodySize = config.Bind("Outside Enemy", "Maximum Baboon Body Size", 1.95f, "Change the maximum size of the Baboon body.");

            EnableSmolDogs = config.Bind("Outside Enemy", "Enable Smol Dogs", true, "Allows Dog Enemies to be small.");
            FunkyDogsSize = config.Bind("Outside Enemy", "Funky Dog Size", false, "If true the Dog Enemies will have a random body size in all dimensions.");
            MinDogBodySize = config.Bind("Outside Enemy", "Minimum Dog Body Size", 0.6f, "Change the minimum size of the Dog body.");
            MaxDogBodySize = config.Bind("Outside Enemy", "Maximum Dog Body Size", 1.2f, "Change the maximum size of the Dog body.");

            EnableSmolGiants = config.Bind("Outside Enemy", "Enable Smol Giants", true, "Allows Giant Enemies to be small.");
            FunkyGiantsSize = config.Bind("Outside Enemy", "Funky Giant Size", false, "If true the Giant Enemies will have a random body size in all dimensions.");
            MinGiantBodySize = config.Bind("Outside Enemy", "Minimum Giant Body Size", 0.75f, "Change the minimum size of the Giant body.");
            MaxGiantBodySize = config.Bind("Outside Enemy", "Maximum Giant Body Size", 2.5f, "Change the maximum size of the Giant body.");

            EnableSmolMechs = config.Bind("Outside Enemy", "Enable Smol Mechs", true, "Allows Mech Enemies to be small.");
            FunkyMechsSize = config.Bind("Outside Enemy", "Funky Mech Size", false, "If true the Mech Enemies will have a random body size in all dimensions.");
            MinMechBodySize = config.Bind("Outside Enemy", "Minimum Mech Body Size", 0.65f, "Change the minimum size of the Mech body.");
            MaxMechBodySize = config.Bind("Outside Enemy", "Maximum Mech Body Size", 2f, "Change the maximum size of the Mech body.");

            EnableSmolTulips = config.Bind("Outside Enemy", "Enable Smol Tulips", true, "Allows Tulip Enemies to be small.");
            FunkyTulipsSize = config.Bind("Outside Enemy", "Funky Tulip Size", false, "If true the Tulip Enemies will have a random body size in all dimensions.");
            MinTulipBodySize = config.Bind("Outside Enemy", "Minimum Tulip Body Size", 0.85f, "Change the minimum size of the Tulip body.");
            MaxTulipBodySize = config.Bind("Outside Enemy", "Maximum Tulip Body Size", 2.5f, "Change the maximum size of the Tulip body.");

            EnableSmolWorms = config.Bind("Outside Enemy", "Enable Smol Worms", true, "Allows Worm Enemies to be small.");
            FunkyWormsSize = config.Bind("Outside Enemy", "Funky Worm Size", false, "If true the Worm Enemies will have a random body size in all dimensions.");
            MinWormBodySize = config.Bind("Outside Enemy", "Minimum Worm Body Size", 0.7f, "Change the minimum size of the Worm body.");
            MaxWormBodySize = config.Bind("Outside Enemy", "Maximum Worm Body Size", 1.65f, "Change the maximum size of the Worm body.");


            EnableSmolBarbers = config.Bind("Special Enemy", "Enable Smol Barbers", true, "Allows Barber Enemies to be small.");
            FunkyBarbersSize = config.Bind("Special Enemy", "Funky Barber Size", false, "If true the Barber Enemies will have a random body size in all dimensions.");
            MinBarberBodySize = config.Bind("Special Enemy", "Minimum Barber Body Size", 0.65f, "Change the minimum size of the Barber body.");
            MaxBarberBodySize = config.Bind("Special Enemy", "Maximum Barber Body Size", 1.5f, "Change the maximum size of the Barber body.");

            EnableSmolGirls = config.Bind("Special Enemy", "Enable Smol Girls", true, "Allows Girl Enemies to be small.");
            FunkyGirlsSize = config.Bind("Special Enemy", "Funky Girl Size", false, "If true the Girl Enemies will have a random body size in all dimensions.");
            MinGirlBodySize = config.Bind("Special Enemy", "Minimum Girl Body Size", 0.5f, "Change the minimum size of the Girl body.");
            MaxGirlBodySize = config.Bind("Special Enemy", "Maximum Girl Body Size", 1.5f, "Change the maximum size of the Girl body.");

            EnableSmolJesters = config.Bind("Special Enemy", "Enable Smol Jesters", true, "Allows Jester Enemies to be small.");
            FunkyJestersSize = config.Bind("Special Enemy", "Funky Jester Size", false, "If true the Jester Enemies will have a random body size in all dimensions.");
            MinJesterBodySize = config.Bind("Special Enemy", "Minimum Jester Body Size", 0.75f, "Change the minimum size of the Jester body.");
            MaxJesterBodySize = config.Bind("Special Enemy", "Maximum Jester Body Size", 1.35f, "Change the maximum size of the Jester body.");

            EnableSmolManEaters = config.Bind("Special Enemy", "Enable Smol ManEaters", true, "Allows ManEater Enemies to be small.");
            FunkyManEatersSize = config.Bind("Special Enemy", "Funky ManEater Size", false, "If true the ManEater Enemies will have a random body size in all dimensions.");
            MinManEatersBodySize = config.Bind("Special Enemy", "Minimum ManEater Body Size", 0.75f, "Change the minimum size of the ManEater body.");
            MaxManEatersBodySize = config.Bind("Special Enemy", "Maximum ManEater Body Size", 1.35f, "Change the maximum size of the ManEater body.");

            EnableSmolLandmines = config.Bind("Trap", "Enable Smol Landmines", true, "Allows Landmines to be small.");
            FunkyLandminesSize = config.Bind("Trap", "Funky Landmine Size", false, "If true the Landmines will have a random body size in all dimensions.");
            MinLandminesBodySize = config.Bind("Trap", "Minimum Landmine Size", 0.5f, "Change the minimum size of the Landmines.");
            MaxLandminesBodySize = config.Bind("Trap", "Maximum Landmine Size", 1.35f, "Change the maximum size of the Landmines.");

            EnableSmolTurrets = config.Bind("Trap", "Enable Smol Turrets", true, "Allows Turrets to be small.");
            FunkyTurretsSize = config.Bind("Trap", "Funky Turret Size", false, "If true the Turrets will have a random body size in all dimensions.");
            MinTurretsBodySize = config.Bind("Trap", "Minimum Turret Size", 0.5f, "Change the minimum size of the Turrets.");
            MaxTurretsBodySize = config.Bind("Trap", "Maximum Turret Size", 1.35f, "Change the maximum size of the Turrets.");

            EnableSmolSpikeTraps = config.Bind("Trap", "Enable Smol Spike Traps", true, "Allows Spike Traps to be small.");
            FunkySpikeTrapsSize = config.Bind("Trap", "Funky Spike Trap Size", false, "If true the Spike Traps will have a random body size in all dimensions.");
            MinSpikeTrapsBodySize = config.Bind("Trap", "Minimum Spike Trap Size", 0.5f, "Change the minimum size of the Spike Traps.");
            MaxSpikeTrapsBodySize = config.Bind("Trap", "Maximum Spike Trap Size", 1f, "Change the maximum size of the Spike Traps.");

            HideVisor = config.Bind("General", "Visuals", true, "This hides the Visor HUD.");
            EnableLogging = config.Bind("General", "Logging", true, "Set this to true to enable logging.");
        }
    }
}