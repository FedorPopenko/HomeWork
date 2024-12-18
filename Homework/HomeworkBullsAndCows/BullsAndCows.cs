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
            public int[] HumanNumber { get; set; }
            public int[] HumanAnswer { get; set; }
            public int[] MachinNumber { get; set; }
            public int[] MachinAnswer { get; set; }
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
            if (State.MachinAnswer != null && State.HumanNumber.SequenceEqual(State.MachinAnswer)
                || State.HumanAnswer != null && State.MachinNumber.SequenceEqual(State.HumanAnswer))
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
            int[] oldMachinAnswer = State.MachinAnswer;
            int[] machinAnswer = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (oldMachinAnswer != null && oldMachinAnswer.Contains(State.HumanNumber[i]))
                {
                    if (oldMachinAnswer[i] == State.HumanNumber[i])
                        machinAnswer[i] = oldMachinAnswer[i];
                    else
                        machinAnswer[i] = random.Next(oldMachinAnswer.Length);
                }
                else
                    machinAnswer[i] = random.Next(0, 9);
            }
            State.MachinAnswer = machinAnswer;
            CheckingNumbers(PlayerType.Machin);
            Console.ResetColor();
        }

        private void ActionHuman()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Write a four digit number:");
            int[] humanAnswer = new int[4];
            //for (int i = 0; i < 4; i++)
            //    humanAnswer[i] = int.Parse(Console.ReadLine());
            humanAnswer = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            State.HumanAnswer = humanAnswer;
            CheckingNumbers(PlayerType.Human);
            Console.ResetColor();
        }

        void CheckingNumbers(PlayerType player)
        {
            int[] answer;
            int[] number;
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
            if (answer[0] == answer[1] || answer[1] == answer[2]
                || answer[2] == answer[3] || answer[0] == answer[2]
                || answer[0] == answer[3] || answer[1] == answer[3])
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
                for (int i = 0; i < 4; i++)
                {
                    if (answer[i] == number[i])
                    {
                        countB++;
                    }
                    else if (answer.Contains(number[i]))
                    {
                        countC++;
                    }
                }
                if (PlayerType.Machin == player)
                    Console.WriteLine($"My turn:\n{answer[0]} {answer[1]} {answer[2]} {answer[3]}");

                Console.WriteLine($"{countB}Bulls,{countC}Cows");

                return;
            }
        }
        public void InputValidation()
        {
            int[] humanNumber = new int[4];
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //for (int i = 0; i < 4; i++)
                //    humanNumber[i] = int.Parse(Console.ReadLine());
                humanNumber = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                Console.ResetColor();
                if (humanNumber[0] == humanNumber[1] || humanNumber[1] == humanNumber[2]
                    || humanNumber[2] == humanNumber[3] || humanNumber[0] == humanNumber[2]
                    || humanNumber[0] == humanNumber[3] || humanNumber[1] == humanNumber[3])
                {
                    Console.WriteLine("You need to enter different numbers!");
                }
                else
                {
                    State.HumanNumber = humanNumber;
                }
            }
            while (State.HumanNumber != humanNumber);
            int[] machinNumber = new int[4];
            do
            {
                Random random = new Random();
                for (int i = 0; i < 4; i++)
                    machinNumber[i] = random.Next(0, 9);
                if (machinNumber[0] == machinNumber[1] || machinNumber[1] == machinNumber[2]
                    || machinNumber[2] == machinNumber[3] || machinNumber[0] == machinNumber[2]
                    || machinNumber[0] == machinNumber[3] || machinNumber[1] == machinNumber[3])
                {
                }
                else
                {
                    State.MachinNumber = machinNumber;
                }
            }
            while (State.MachinNumber != machinNumber);
        }
    }
}
