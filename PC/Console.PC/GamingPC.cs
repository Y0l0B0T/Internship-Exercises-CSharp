public class GamingPC : PC
    {
        public string CoolingSystem { get; set; }
        public bool HasRGBLighting { get; set; }

        public GamingPC(string cpu, string gpu, int ram, int storage, string coolingSystem, bool hasRGBLighting)
            : base(cpu, gpu, ram, storage)
        {
            CoolingSystem = coolingSystem;
            HasRGBLighting = hasRGBLighting;
        }
        public void DisplayGamingSpecs()
        {
            DisplaySpecs();
            Console.WriteLine($"Cooling System: {CoolingSystem}");
            Console.WriteLine($"RGB Lighting: {(HasRGBLighting ? "Yes" : "No")}");
        }
        public void LaunchGame(string gameName)
        {
            Console.WriteLine($"Launching game: {gameName}...");
        }
        public void StreamGameplay(string gameName)
        {
            Console.WriteLine($"Starting to stream {gameName} now on Twitch !");
        }
        public void EnableVRMode()
        {
            Console.WriteLine("Enabling VR mode.");
        }
        public void Overclock()
        {
            Console.WriteLine("Overclocking the system for Boosting Frame Rate !!");
        }
    }