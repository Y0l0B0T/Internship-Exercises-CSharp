public class PC
    {
    public string CPU { get; set; }
    public string GPU { get; set; }
    public int RAM { get; set; }
    public int Storage { get; set; }

        
    public PC(string cpu, string gpu, int ram, int storage)
        {
            CPU = cpu;
            GPU = gpu;
            RAM = ram;
            Storage = storage;
        }

        public void DisplaySpecs()
        {
            Console.WriteLine("===================");
            Console.WriteLine($"CPU: {CPU}");
            Console.WriteLine($"GPU: {GPU}");
            Console.WriteLine($"RAM: {RAM} GB");
            Console.WriteLine($"Storage: {Storage} GB");
            Console.WriteLine("===================");
        }
        public void Boot()
        {
            Console.WriteLine("Booting up...");
        }
        public void Shutdown()
        {
            Console.WriteLine("Shutting down...");
        }
    }