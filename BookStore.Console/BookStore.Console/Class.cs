public class BookStore 
{
    public BookStore(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public void Advice(string customerName)
    {
        Console.WriteLine($"Wellcome To Blue Book Store {customerName}");
    }
}