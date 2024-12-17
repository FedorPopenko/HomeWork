namespace Homework.HomeworkBullsAndCows
{
    public class BullsAndCows
    {
        public enum PlayerType
        {
            None,
            Human,
            Machin
        };

        public class GameState
        {
            public PlayerType[] Players { get; set; }
            public PlayerType Winner { get; set; }
            public int HumanNumber { get; set; }
            public int HumanAnswer { get; set; }
            public int MachinNumber { get; set; }
            public int MachinAnswer { get; set; }
        }
        public GameState State { get; private set; }

        public BullsAndCows(PlayerType firstPlaer)
        {
            State = new GameState
            {
                Players = [
                    firstPlaer,
                    firstPlaer == PlayerType.Human ?
                                  PlayerType.Machin :
                                  PlayerType.Human
                ],
                Winner = PlayerType.None
            };
        }

        public void MakeTurn(PlayerType player)
        {
            switch (player)
            {
                case PlayerType.Human:
                    ActionHuman();
                    break;
                case PlayerType.Machin:
                    ActionMachin();
                    break;
                default:
                    throw new ArgumentException("Player not know.");
            }
            CalculateWinner(player);
        }

        private void CalculateWinner(PlayerType player)
        {
            if (State.HumanNumber == State.MachinAnswer || State.MachinNumber == State.HumanAnswer)
            {
                State.Winner = player;
                switch (State.Winner)
                {
                    case PlayerType.Human:
                        Console.WriteLine("Congratulations, you won!");
                        break;
                    case PlayerType.Machin:
                        Console.WriteLine("Sorry, you lost!");
                        break;
                    default:
                        throw new ArgumentException("Player not know.");
                }
                Console.ReadLine();
            }
            else
                return;
        }

        private void ActionMachin()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Random random = new Random();
            int machinAnswer = random.Next(1000, 9999);
            State.MachinAnswer = machinAnswer;
            CheckingNumbers(PlayerType.Machin);
            Console.ResetColor();
        }

        private void ActionHuman()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Write a four digit number:");
            int humanAnswer = int.Parse(Console.ReadLine());
            State.HumanAnswer = humanAnswer;
            CheckingNumbers(PlayerType.Human);
            Console.ResetColor();
        }

        void CheckingNumbers(PlayerType player)
        {
            int answer;
            int number;
            if (PlayerType.Human == player)
            {
                answer = State.HumanAnswer;
                number = State.MachinNumber;
            }
            else
            {
                answer = State.MachinAnswer;
                number = State.HumanNumber;
            }
            int ans1 = answer / 1000 % 10;
            int ans2 = answer / 100 % 10;
            int ans3 = answer / 10 % 10;
            int ans4 = answer % 10;
            int num1 = number / 1000 % 10;
            int num2 = number / 100 % 10;
            int num3 = number / 10 % 10;
            int num4 = number % 10;
            if (ans1 == ans2 || ans2 == ans3 || ans3 == ans4 || ans1 == ans3 || ans1 == ans4 || ans2 == ans4)
            {
                if (PlayerType.Human == player)
                {
                    Console.WriteLine("You need to enter different numbers!");
                    ActionHuman();
                }
                else
                {
                    ActionMachin();
                }
            }
            else
            {
                int countB = 0;
                int countC = 0;
                int[] ans = { ans1, ans2, ans3, ans4 };
                int[] num = { num1, num2, num3, num4 };
                for (int i = 0; i < 4; i++)
                {
                    if (ans[i] == num[i])
                    {
                        countB++;
                    }
                    else if (ans.Contains(num[i]))
                    {
                        countC++;
                    }
                }
                if (PlayerType.Machin == player)
                    Console.WriteLine($"My turn:\n{answer}");

                Console.WriteLine($"{countB}Bulls,{countC}Cows");

                return;
            }
        }
        public void InputValidation()
        {
        M1: Console.ForegroundColor = ConsoleColor.Red;
            int humanNumber = int.Parse(Console.ReadLine());
            Console.ResetColor();
            int hNum1 = humanNumber / 1000 % 10;
            int hNum2 = humanNumber / 100 % 10;
            int hNum3 = humanNumber / 10 % 10;
            int hNum4 = humanNumber % 10;
            if (hNum1 == hNum2 || hNum2 == hNum3 || hNum3 == hNum4 || hNum1 == hNum3 || hNum1 == hNum4 || hNum2 == hNum4)
            {
                Console.WriteLine("You need to enter different numbers!");
                goto M1;
            }
            else
            {
                State.HumanNumber = humanNumber;
            }
        M2: Random random = new Random();
            int machinNumber = random.Next(1000, 9999);
            int mNum1 = machinNumber / 1000 % 10;
            int mNum2 = machinNumber / 100 % 10;
            int mNum3 = machinNumber / 10 % 10;
            int mNum4 = machinNumber % 10;
            if (hNum1 == hNum2 || hNum2 == hNum3 || hNum3 == hNum4 || hNum1 == hNum3 || hNum1 == hNum4 || hNum2 == hNum4)
            {
                goto M2;
            }
            else
            {
                State.MachinNumber = machinNumber;
            }
        }
    }
}
