using static System.Console;
public class GuessNumber : Game
{
    public override string Name { get; }
    public override string Description { get; }
    private readonly int _hiddenNumber;
    private int _guessCount;
    public GuessNumber(string name, string description = "Guess Number Between 0 to 100")
    {
        Name = name;
        Description = description;
        _hiddenNumber = RandomNumberGenerator();
    }
    public override void Play()
    {
        var IsGuessCorrect = false;
        while (!IsGuessCorrect)
        {
            _guessCount++;
            var number = GetNumber();
            if (number == _hiddenNumber)
            {
                WriteLine($"Nice !!! You Found it After {_guessCount} Time.");
                IsGuessCorrect = true;
            }
            else Help(number);
        }
    }
    private void Help(int number)
    {
        if (number > _hiddenNumber) WriteLine($"Please Enter Number Smaller Than {number}");
        if (number < _hiddenNumber) WriteLine($"Please Enter Number Greater Than {number}");
    }
    private int RandomNumberGenerator() => new Random().Next(1, 101);
    private int GetNumber()
    {
        var canParseNumber = false;
        var number = 0;
        while (!canParseNumber)
        {
            Write("Enter Your Guess Number : ");
            canParseNumber = int.TryParse(ReadLine(), out number);
        }
        return number;
    }
}