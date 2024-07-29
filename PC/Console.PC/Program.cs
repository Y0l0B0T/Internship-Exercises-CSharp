class Program
{
    static void Main(string[] args)
        {
            var OfficePC = new PC("Intel i5 8400F", "NVIDIA GTX 1050", 16, 512);
            OfficePC.Boot();
            OfficePC.DisplaySpecs();
            OfficePC.Shutdown();

            Console.WriteLine("\n");

            var HomeGamingPC = new GamingPC("Intel i9 14900K", "NVIDIA RTX 4090", 64, 2048, "Liquid Cooling", true);
            HomeGamingPC.Boot();
            HomeGamingPC.DisplayGamingSpecs();
            HomeGamingPC.Overclock();
            HomeGamingPC.LaunchGame("Forza Horizon 5");
            HomeGamingPC.EnableVRMode();
            HomeGamingPC.StreamGameplay("Forza Horizon 5 Online");
            HomeGamingPC.Shutdown();
        }
}