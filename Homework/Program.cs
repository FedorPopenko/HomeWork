using Homework.HomeworkBullsAndCows;
using Homework.HomeworkGallows;
using Homework.HomeworkQuestions;
using Homework.HomeworkTicTacToe;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать на капитал шоу ПОЛЕ ЧУДЕС!");
        Console.WriteLine("Наши дорогие телезрители прислали в нашу редакцию слово, которое вам нужно отгадать за 6 попыток.");
        Gallows game = new Gallows();
        string word = game.HiddenWord();
        do
        {
            if (game.count == 1 && game.letter == null)
            {
                Console.WriteLine($"В слове {game.Word.Length} букв! ");
            }
            else
                Console.WriteLine($"Cлово: {game.playerWord.ToUpper()}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Буквы которые вы называли:");
            Console.ResetColor();

            game.Alphabet();
            Console.WriteLine($"Вращайте барабан! Это {game.count} попытка.");
            Console.WriteLine("Напишите букву:");
            game.letter = Console.ReadLine()?.ToUpper();
            if (!string.IsNullOrEmpty(game.letter) && game.letter.Length == 1 && char.IsLetter(game.letter[0]))
            {
                game.calledLetters.Add(game.letter[0]);
            }
            Console.Clear();
            game.CheckLetter();
            game.count++;

        }
        while (game.count < 7 && word != game.playerWord);
        {
            game.CheckResult();
        }
    }
    static void HomeWorkGameBullsAndCows()
    {
        Console.WriteLine("This game is called Bulls and Cows");
        Console.WriteLine("Rules: \n" +
            "each player guesses a four-digit number with different digits.\n" +
            "The first player names a four-digit number with different digits\n" +
            "and if there is such a digit in the hidden number, then it is a Cow,\n" +
            "and if there is such a digit and it is in the same place, then it is a Bull.\n" +
            "The first one to collect four bulls wins.");
        Console.WriteLine("For example: \n" +
            "I think  the number 2315, and you say the number 6342\n" +
            "I must answer 1B (bull) and 1C (cow), where 1B is the number 3, and 1C is the number 2.\n" +
            "We'll find out as the game progresses.");
        Console.WriteLine("Choose who will go first '1' you '2' me:");
        BullsAndCows.PlayerType firstPlayer = (BullsAndCows.PlayerType)int.Parse(Console.ReadLine());
        Console.WriteLine("Write your number:");
        BullsAndCows game = new BullsAndCows(firstPlayer);
        game.InputValidation();
        do
        {
            foreach (BullsAndCows.PlayerType player in game.State.Players)
            {
                game.MakeTurn(player);
                if (game.State.Winner != BullsAndCows.PlayerType.None)
                    break;
            }
        }
        while (game.State.Winner == BullsAndCows.PlayerType.None);
    }
    static void HomeworkGameSticks()
    {
        Console.WriteLine("This game is called sticks!");
        Console.WriteLine("The rules are simple.\n" +
            "There is a certain number of sticks and\n" +
            "we take turns taking from 1 to 3 sticks until\n" +
            "they run out.The one who took the last one loses.\n");
        Console.WriteLine("Write down the number of sticks:");
        int totalSticks = int.Parse(Console.ReadLine());
        Console.WriteLine("Choose who will go first '1' you '2' me:");
        Sticks.PlayerType firstPlayer = (Sticks.PlayerType)int.Parse(Console.ReadLine());

        Sticks game = new Sticks(firstPlayer, totalSticks);
        do
            foreach (Sticks.PlayerType player in game.State.Players)
                game.MakeTurn(player);
        while (game.State.Winner == Sticks.PlayerType.None);

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
        //Gallows game = new Gallows();
    }
    static void HomeworkGameTicTacToe()
    {
        TicTacToe game = new TicTacToe(_opponent: Opponent.Machin);// Игра с компьютером, игра с человеком .Human
        game.Start();

        Console.ReadLine();
    }
    static void HomeworkGameQuestions()
    {
        HomeworkQuestions game = new HomeworkQuestions("Questions(in).csv");

        Console.WriteLine("Welcome to the game I Believe It or Not!\nWe will have 5 rounds and 2 attempts to guess all the statements.");

        game.Start();
    }
}