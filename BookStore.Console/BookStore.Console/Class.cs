public class BookStore 
{
     public string Name { get; set; }
    public string Address { get; set; }
    public bool HasCafe { get; set; }
    public bool HasStudyPlace { get; set; }
    public bool HasStationery { get; set; }

    public BookStore(string name)
    {
        Name = name;
        Address = "";
        HasCafe = false;
        HasStudyPlace = false;
        HasStationery = false;
    }

    public void SellBooks()
    {
        Console.WriteLine($"Selling Book in {Name} BookStore ");
    }


    public void Advice(string customerName)
    {
        Console.WriteLine($"Helping {customerName} To Choose a Book For Read in {Name} BookStore ");
    }

    public void QueForReadingEvents()
    {
        Console.WriteLine($"Queuing Users For the Reading Event in {Name} BookStore");
    }
}
