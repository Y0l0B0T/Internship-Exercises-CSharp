using static System.Console;
public class GuessWord : Game
{
    public override string Name { get; }
    public override string Description { get; }
    private readonly string _hiddenWord;
    private int _guessCount;
    public GuessWord(string name, string description = "Guess Word Between Words in List")
    {
        Name = name;
        Description = description;
        _hiddenWord = RandomWord();
    }
    public override void Play()
    {
        WriteLine("Words : ali , esi , mamad , hossein , reza , pouya , mehrdad, amir , milad , iman");
        var IsGuessCorrect = false;
        while (!IsGuessCorrect)
        {
            _guessCount++;
            var word = GetWord();
            if (word == _hiddenWord)
            {
                WriteLine($"Nice !!! You Found it After {_guessCount} Time.");
                IsGuessCorrect = true;
            }
            else WriteLine("Wrong Word !");
        }
    }
    private string GetWord() => ReadLine()!;
    private string RandomWord()
    {
        string[] words = ["ali", "esi", "mamad", "hossein", "reza", "pouya", "mehrdad", "amir", "milad", "iman"];
        return words[new Random().Next(words.Length)];
    }
}