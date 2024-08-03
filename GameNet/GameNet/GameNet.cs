using Games;

namespace GameNet;
public class Gamenet
{
    private Game? _game;
    
    public void PlayGame()
    {
         BuyGame();
        _game.Start();
    }

    private void BuyGame()
    {
        while (true)
        {
            Console.WriteLine("List :");
            Console.WriteLine("1. Guess Number\n2. Guess Word");
            Console.WriteLine("Select Your Game : ");
            switch (Console.ReadLine())
            {
                case "1": _game = new GuessNumber(); return;
                case "2": _game = new GuessWord(); return;
            }
        }
    }
}