using static System.Console;
public class GameClub(params Game[] games)
{
    private readonly List<Game> _games = new();
    public void ComeIn(string player) => ChooseMenu(player);

    private void ChooseMenu(string player)
    {
        bool playAgain = true;
        while (playAgain)
        {
            ShowMenu(player);
            var choice = GetChoice();
            playAgain = DoOrder(player, choice, playAgain);
        }
    }

    private bool DoOrder(string player, int choice, bool playAgain)
    {
        switch (choice)
        {
            case 1:
                {
                    ShowGames(player);
                    var gameId = GetChoice();
                    PlayGame(player, gameId);
                }
                break;
            case 2:
                {
                    ShowGames(player);
                    var gameId = GetChoice();
                    ShowGameDescription(gameId);
                }
                break;
            case 3: playAgain = false; break;
            default:
                WriteLine("Wrong Choice. Try again !");
                break;
        }

        return playAgain;
    }

    private void ShowGameDescription(int gameId)
        => WriteLine($"the {games[gameId - 1].Name} Description :" +
                             $" \n {games[gameId - 1].Description} \n");

    private void PlayGame(string player, int gameId)
    {
        if (GameNotFound(gameId)) return;

        var game = games[gameId - 1];

        WriteLine($"Wellcome Dear {player}. Enjoy the {game.Name}.");

        game.Play();
    }

    private void ShowGames(string player)
    {
        if (GamesAreEmpty()) return;

        string result = "Select Your Game : \n";
        for (int i = 1; i <= games.Length; i++)
            result += $"[{i}]. {games[i - 1].Name} \n";

        Write($"{result} \n Dear {player} Choice : ");
    }

    private bool GamesAreEmpty()
    {
        if (games.Length != 0) return false;

        WriteLine("Game Club Have No Game!");
        return true;
    }

    private bool GameNotFound(int gameId)
    {
        if (gameId >= 1 && gameId <= games.Length) return false;

        WriteLine("Game Not Found");
        return true;
    }

    private static int GetChoice()
    {
        int choice = 0;
        bool isChoiceValid = false;
        while (isChoiceValid == false)
        {
            isChoiceValid = int.TryParse(ReadLine()!, out int userInput);
            choice = userInput;
        }
        Clear();
        return choice;
    }
    public void AddGame(Game game)
    {
        _games.Add(game);
    }

    private void ShowMenu(string player)
    {
        Write(@$"
Welcome {player}. Select One Of Them 
[1]. Play game
[2]. Show game description
[3]. Exit

{player} Choice : ");
    }

}