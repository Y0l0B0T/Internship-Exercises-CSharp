namespace Games;
public class GuessNumber : Game
{
    private int Number;

    protected override string Name { get ; set ; }

    public GuessNumber()
    {}

    public void GuessNumbers()
    {
        Console.Write("Enter Your Guess: ");
        Number = int.Parse(Console.ReadLine()!);
    }
    
    private int GenerateRandomNumber()
    {
        Random random = new Random();
        return random.Next(1, 101);
    }
    public static void WellcomeGuessNumber()
    {
        Console.WriteLine("!! Wellcome To Guess Number Game !!");
        Console.WriteLine("Rules : You Only Have 5 Chances To Guess Correctly.");
        Console.WriteLine("After Each Wrong Guess, We Tell You Your Number is Bigger or Smaller Than Answer.");
        
    }
    public void StartGame()
    {
        WellcomeGuessNumber();
        int HiddenNum = 0;
        HiddenNum = GenerateRandomNumber();
        int WrongCounter = 0;
        while (true)
        {
            WrongCounter++;
            GuessNumbers();
            if (HiddenNum > Number)
            {
                Console.WriteLine("The Number You Guessed Was Smaller Than the Number in My Mind!");
            }
            else if (HiddenNum < Number)
            {
                Console.WriteLine("The Number You Guessed Was Greater Than the Number in My Mind!");
            }
            else
            {
                Console.WriteLine($"Nice !! You Guessed it Right After {WrongCounter} Time. \nThe Number is: {HiddenNum}");
                break;
            }
            if (WrongCounter >= 5)
            {
                Console.WriteLine("You've exceeded the maximum number of attempts. \nGame Over !");
                break;
            }
        }
    }
    public override void Start()
    {
        StartGame();
    }
}