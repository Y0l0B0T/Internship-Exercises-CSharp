class Program 
{
    static void Main()
    {
        BookStore blueBookStore = new BookStore("Blue");

        blueBookStore.SellBooks();
        blueBookStore.Advice("Esmaeel");
        blueBookStore.QueForReadingEvents();
        blueBookStore.Address = "Shiraz/Qodoosi";
        blueBookStore.HasCafe = true;
        blueBookStore.HasStudyPlace = true;
        blueBookStore.HasStationery = true;

        Console.WriteLine($"Book Store {blueBookStore.Name} Opened!");
        Console.WriteLine($"{blueBookStore.Name} Book Store is in Address : \"{blueBookStore.Address}\"");
        Console.WriteLine($"Is This Book Store Has Cafe ? {blueBookStore.HasCafe}");
        Console.WriteLine($"Is This Book Store Has Study For Place ? {blueBookStore.HasStudyPlace}");
        Console.WriteLine($"Is This Book Store Has Stationery ? {blueBookStore.HasStationery}");
    }
}
