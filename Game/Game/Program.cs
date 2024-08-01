class Program
    {
        static void Main()
        {
            Game.TitleAndRules();
            var GuessNumberGame = new Game();
            GuessNumberGame.StartGame();
        }
    }
