public class Game
{
    private int HiddenNum;
    private int GuessNumber;

    public Game(int hiddenNum)
    {
        HiddenNum = hiddenNum;
    }

    public void GuessNumbers()
    {
        Console.Write("Enter Your Guess: ");
        GuessNumber = int.Parse(Console.ReadLine()!);
    }
    
    private int GenerateRandomNumber()
    {
        Random random = new Random();
        return random.Next(1, 101);
    }
    public static void TitleAndRules()
    {
        Console.WriteLine("!! Wellcome To Guess Number Game !!");
        Console.WriteLine("Rules : You Only Have 5 Chances To Guess Correctly.");
        Console.WriteLine("After Each Wrong Guess, We Tell You Your Number is Bigger or Smaller Than Answer.");
        
    }
    public void StartGame()
    {
        HiddenNum = GenerateRandomNumber();
        int WrongCounter = 0;
        while (true)
        {
            WrongCounter++;
            GuessNumbers();
            if (HiddenNum > GuessNumber)
            {
                Console.WriteLine("The Number You Guessed Was Smaller Than the Number in My Mind!");
            }
            else if (HiddenNum < GuessNumber)
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
}