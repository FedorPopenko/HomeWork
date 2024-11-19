namespace Homework.HomeworkTicTacToe
{
    public class TicTacToe
    {
        static int _currentPlayer = 1;
        private readonly Opponent _opponent;

        public TicTacToe(int _currentPlayer = 1, Opponent _opponent = Opponent.Human)
        {
            this._opponent = _opponent;
        }
        public void Start()
        {
            if (_opponent == Opponent.Human)
            {
                HumanPlays();
            }
            else
            {
                MachinPlays();
            }
        }
        public static void MarkingBoard()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"   {0} | {1} | {2} ");
            Console.WriteLine(" -------------");
            Console.WriteLine($"   {3} | {4} | {5} ");
            Console.WriteLine(" -------------");
            Console.WriteLine($"   {6} | {7} | {8} ");
            Console.WriteLine();
            Console.WriteLine("This is a board so you don't forget the free numbers!");
            Console.ResetColor();
            Console.WriteLine();
        }

        private void HumanPlays()
        {
            Array myBoard = Array.CreateInstance(typeof(string), new[] { 9 }, new[] { 0 });
            myBoard.SetValue(" ", 0);
            myBoard.SetValue(" ", 1);
            myBoard.SetValue(" ", 2);
            myBoard.SetValue(" ", 3);
            myBoard.SetValue(" ", 4);
            myBoard.SetValue(" ", 5);
            myBoard.SetValue(" ", 6);
            myBoard.SetValue(" ", 7);
            myBoard.SetValue(" ", 8);
            int index;
            bool validInput;
            Console.WriteLine("Yes, the game is about to begin!");
            Console.WriteLine("The rules are simple: the one who goes first puts “x”, and the second one puts “o”.");
            Console.WriteLine("The game continues until there are no identical symbols left horizontally, vertically or diagonally.");
            Console.WriteLine("You need to enter the number according to the board below");

            MarkingBoard();

            do
            {
                Console.WriteLine($"Player {_currentPlayer}, enter number:");
                validInput = int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 8 && myBoard.GetValue(index) is not "X" && myBoard.GetValue(index) is not "O";

                for (int i = 0; i < 10; i++)
                {
                    if (validInput && i == index && (_currentPlayer == 1))
                    {
                        myBoard.SetValue("X", i);
                    }
                    else if (validInput && i == index && (_currentPlayer == 2))
                    {
                        myBoard.SetValue("O", i);
                    }
                }
                if (validInput)
                {
                    if (CheckForWin(myBoard))
                    {
                        Console.Clear();
                        Board(myBoard);
                        Console.WriteLine($"Player {_currentPlayer} Wins!");
                        break;
                    }
                    if (CheckForDraw(myBoard))
                    {
                        Console.Clear();
                        Board(myBoard);
                        Console.WriteLine("Friendship has won!");
                        break;
                    }
                    _currentPlayer = (_currentPlayer == 1) ? 2 : 1;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again!");
                    continue;
                }

                Console.Clear();
                MarkingBoard();
                Board(myBoard);
            }
            while (true);
        }

        private static void Board(Array myBoard)
        {
            Console.WriteLine($"  {myBoard.GetValue(0)} | {myBoard.GetValue(1)} | {myBoard.GetValue(2)} ");
            Console.WriteLine(" -----------");
            Console.WriteLine($"  {myBoard.GetValue(3)} | {myBoard.GetValue(4)} | {myBoard.GetValue(5)} ");
            Console.WriteLine(" -----------");
            Console.WriteLine($"  {myBoard.GetValue(6)} | {myBoard.GetValue(7)} | {myBoard.GetValue(8)} ");

        }
        static bool CheckForWin(Array myBoard)
        {
            return

                (myBoard.GetValue(0) == myBoard.GetValue(1) && myBoard.GetValue(1) == myBoard.GetValue(2)) && myBoard.GetValue(0) is not " " ||
                (myBoard.GetValue(3) == myBoard.GetValue(4) && myBoard.GetValue(4) == myBoard.GetValue(5)) && myBoard.GetValue(3) is not " " ||
                (myBoard.GetValue(6) == myBoard.GetValue(7) && myBoard.GetValue(7) == myBoard.GetValue(8)) && myBoard.GetValue(6) is not " " ||
                (myBoard.GetValue(0) == myBoard.GetValue(3) && myBoard.GetValue(3) == myBoard.GetValue(6)) && myBoard.GetValue(0) is not " " ||
                (myBoard.GetValue(1) == myBoard.GetValue(4) && myBoard.GetValue(4) == myBoard.GetValue(7)) && myBoard.GetValue(1) is not " " ||
                (myBoard.GetValue(2) == myBoard.GetValue(5) && myBoard.GetValue(5) == myBoard.GetValue(8)) && myBoard.GetValue(2) is not " " ||
                (myBoard.GetValue(0) == myBoard.GetValue(4) && myBoard.GetValue(4) == myBoard.GetValue(8)) && myBoard.GetValue(0) is not " " ||
                (myBoard.GetValue(2) == myBoard.GetValue(4) && myBoard.GetValue(4) == myBoard.GetValue(6)) && myBoard.GetValue(2) is not " ";

        }
        static bool CheckForDraw(Array myBoard)
        {
            foreach (string cell in myBoard)
            {
                if (cell is not "X" && cell is not "O")
                    return false;
            }
            return true;
        }


        private void MachinPlays()
        {

            Array myBoard = Array.CreateInstance(typeof(string), new[] { 9 }, new[] { 0 });
            myBoard.SetValue(" ", 0);
            myBoard.SetValue(" ", 1);
            myBoard.SetValue(" ", 2);
            myBoard.SetValue(" ", 3);
            myBoard.SetValue(" ", 4);
            myBoard.SetValue(" ", 5);
            myBoard.SetValue(" ", 6);
            myBoard.SetValue(" ", 7);
            myBoard.SetValue(" ", 8);

            int index;
            bool validInput;
            bool validMove;
            int firstPlayer;
            Console.WriteLine("Yes, the game is about to begin!");
            Console.WriteLine("The rules are simple: the one who goes first puts “X”, and the second one puts “O”.");
            Console.WriteLine("The game continues until there are no identical symbols left horizontally, vertically or diagonally.");
            Console.WriteLine("You need to enter the number according to the board below");

            MarkingBoard();

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
                    Console.WriteLine($"Player {_currentPlayer}, enter number:");
                    validInput = int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 8 && myBoard.GetValue(index) is not "X" && myBoard.GetValue(index) is not "O";

                    for (int i = 0; i < 10; i++)
                    {
                        if (validInput && i == index && (_currentPlayer == 1))
                        {
                            myBoard.SetValue("X", i);
                        }
                        else if (validInput && i == index && (_currentPlayer == 2))
                        {
                            myBoard.SetValue("O", i);
                        }
                    }
                    if (validInput)
                    {
                        if (CheckForWin(myBoard))
                        {
                            Console.Clear();
                            Board(myBoard);
                            Console.WriteLine($"Player {_currentPlayer} Wins!");
                            break;
                        }
                        if (CheckForDraw(myBoard))
                        {
                            Console.Clear();
                            Board(myBoard);
                            Console.WriteLine("Friendship has won!");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again!");
                        continue;
                    }

                    Console.Clear();
                    MarkingBoard();
                    Board(myBoard);

                }
                if (_currentPlayer == 2)
                {
                    Random random = new Random();
                    int move = random.Next(0, 8);
                    validMove = move >= 0 && move <= 8 && myBoard.GetValue(move) is not "X" && myBoard.GetValue(move) is not "O";
                    for (int i = 0; i < 10; i++)
                    {
                        if (validMove && i == move && (_currentPlayer == 1))
                        {
                            myBoard.SetValue("X", i);
                        }
                        else if (validMove && i == move && (_currentPlayer == 2))
                        {
                            myBoard.SetValue("O", i);
                        }
                    }
                    if (validMove)
                    {
                        if (CheckForWin(myBoard))
                        {
                            Console.Clear();
                            Board(myBoard);
                            Console.WriteLine($"Player {_currentPlayer} Wins!");
                            break;
                        }
                        if (CheckForDraw(myBoard))
                        {
                            Console.Clear();
                            Board(myBoard);
                            Console.WriteLine("Friendship has won!");
                            break;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    Console.Clear();
                    MarkingBoard();
                    Board(myBoard);
                }
                _currentPlayer = (_currentPlayer == 1) ? 2 : 1;

            }
            while (true);
        }
    }

}
