using Homework.HomeworkGallows;
using Homework.HomeworkQuestions;
using Homework.HomeworkTicTacToe;

class Program
{
    static int _currentPlayer = 1;
    static Sticks _sticks;
    static void Main(string[] args)
    {
        int firstPlayer;
        _sticks = new Sticks();
        _sticks.RegisterRemainger(Winner);
        Console.WriteLine("This game is called sticks!");
        Console.WriteLine("The rules are simple." +
            "There is a certain number of sticks and" +
            " we take turns taking from 1 to 3 sticks until" +
            " they run out.The one who took the last one loses.");
        Console.WriteLine("Write down the number of sticks:");
        _sticks.Start();

        Console.WriteLine("Choose who will go first '1' you '2' me:");

        firstPlayer = int.Parse(Console.ReadLine());

        if (firstPlayer == 1)
        {
            _currentPlayer = 1;
        }
        else
        {
            _currentPlayer = 2;
        }

        do
        {
            if (_currentPlayer == 1)
            {
                Console.WriteLine("Your move:");
                _sticks.actionHuman();
                _sticks.RegisterRemainger(Winner);
                Console.Clear();
            }
            if (_currentPlayer == 2)
            {
                Console.WriteLine("My move:");
                _sticks.actionMachine();
                _sticks.RegisterRemainger(Winner);
            }
            _currentPlayer = (_currentPlayer == 1) ? 2 : 1;
        }
        while (true);
    }
    private static void Winner(int sticksLeft)
    {
        if (sticksLeft <= 0 && _currentPlayer == 1)
        {
            Console.WriteLine("Sorry, you lost!");
            _sticks.Stop();
        }
        if (sticksLeft <= 0 && _currentPlayer == 2)
        {
            Console.WriteLine("Congratulations, you won!");
            _sticks.Stop();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{sticksLeft} sticks left");
            Console.ResetColor();
        }
    }
    static void HomeworkGameSticks()
    {
        //static int _currentPlayer = 1;
        //static Sticks _sticks;
        //static void Main(string[] args)
        //{
        //    int firstPlayer;
        //    _sticks = new Sticks();
        //    _sticks.RegisterRemainger(Winner);
        //    Console.WriteLine("This game is called sticks!");
        //    Console.WriteLine("The rules are simple." +
        //        "There is a certain number of sticks and" +
        //        " we take turns taking from 1 to 3 sticks until" +
        //        " they run out.The one who took the last one loses.");
        //    Console.WriteLine("Write down the number of sticks:");
        //    _sticks.Start();

        //    Console.WriteLine("Choose who will go first '1' you '2' me:");

        //    firstPlayer = int.Parse(Console.ReadLine());

        //    if (firstPlayer == 1)
        //    {
        //        _currentPlayer = 1;
        //    }
        //    else
        //    {
        //        _currentPlayer = 2;
        //    }

        //    do
        //    {
        //        if (_currentPlayer == 1)
        //        {
        //            Console.WriteLine("Your move:");
        //            _sticks.actionHuman();
        //            _sticks.RegisterRemainger(Winner);
        //            Console.Clear();
        //        }
        //        if (_currentPlayer == 2)
        //        {
        //            Console.WriteLine("My move:");
        //            _sticks.actionMachine();
        //            _sticks.RegisterRemainger(Winner);
        //        }
        //        _currentPlayer = (_currentPlayer == 1) ? 2 : 1;
        //    }
        //    while (true);
        //}
        //private static void Winner(int sticksLeft)
        //{
        //    if (sticksLeft <= 0 && _currentPlayer == 1)
        //    {
        //        Console.WriteLine("Sorry, you lost!");
        //        _sticks.Stop();
        //    }
        //    if (sticksLeft <= 0 && _currentPlayer == 2)
        //    {
        //        Console.WriteLine("Congratulations, you won!");
        //        _sticks.Stop();
        //    }
        //    else
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine($"{sticksLeft} sticks left");
        //        Console.ResetColor();
        //    }


    }
    static void HomeworkGameGallows()
    {
        var game = new Gallows();

    }
    static void HomeworkGameTicTacToe()
    {
        var game = new TicTacToe(_opponent: Opponent.Machin);// Игра с компьютером, игра с человеком .Human
        game.Start();

        Console.ReadLine();
    }
    static void HomeworkGameQuestions()
    {
        var game = new HomeworkQuestions("Questions(in).csv");

        Console.WriteLine("Welcome to the game I Believe It or Not!\nWe will have 5 rounds and 2 attempts to guess all the statements.");

        game.Start();
    }
}