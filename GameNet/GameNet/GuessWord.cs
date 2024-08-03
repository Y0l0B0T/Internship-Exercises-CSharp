namespace Games;
public class GuessWord : Game
{
    private string Word;
    private string HiddenWord { get; init; }
    protected override string Name { get; set; }

    public GuessWord()
    {
        HiddenWord = RandomWord();
    }

    private void GuessWords()
    {
        Console.Write("Enter Your Guess Word : ");
        Word = Console.ReadLine()!.ToLower();
    }

    private string RandomWord()
    {
        string[] hiddenWords = ["csharp", "java", "rust", "js", "go", "c", "python"];
        return hiddenWords[new Random().Next(hiddenWords.Length)];
    }
    public static void WellcomeGuessWord()
    {
        Console.WriteLine("!! Wellcome To Guess Word Game !!");
        Console.WriteLine("Rules : You Only Have 5 Chances To Guess Correctly.");
        Console.WriteLine($"Words : csharp, java, rust, js, go, c, python");
        
    }
    public void StartGame()
    {
        WellcomeGuessWord();
        int WrongCounter = 0;

        while (true)
        {
            WrongCounter++;
            GuessWords();
            if (HiddenWord != Word)
            {
                Console.WriteLine("This Word You Guessed Was Wrong!");
            }
            else
            {
                Console.WriteLine($"Nice !! You Guessed it Right After {WrongCounter} Time. \nThe Word is: {HiddenWord}");
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