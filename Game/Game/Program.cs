class Program
    {
        static void Main()
        {
            Game.TitleAndRules();
            var GuessNumberGame = new Game(0);
            GuessNumberGame.StartGame();
        }
    }