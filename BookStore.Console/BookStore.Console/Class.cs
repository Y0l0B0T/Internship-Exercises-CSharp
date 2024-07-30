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

    public void SellBooks(string bookname)
    {
        Console.WriteLine($"Thanks For Buying {bookname} Book From {Name} BookStore.");
    }


    public void Advice(string customerName)
    {
        Console.WriteLine($"Wellcome {customerName} to Book Store. Just try reading for 15 min per day, and you need Discipline! ");
    }

    public void QueForReadingEvents(string customerName, string eventName)
    {
        Console.WriteLine($"With Regards to {customerName}, This is Your Invitation For the {eventName} Event.");
    }
}
