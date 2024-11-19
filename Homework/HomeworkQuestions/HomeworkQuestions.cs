using System.Globalization;

namespace Homework.HomeworkQuestions
{
    public class HomeworkQuestions
    {
        public GameStatus Status { get; set; }

        public int Attempt = 2;

        public int Count = 0;

        private List<Statment> statement;

        public HomeworkQuestions(string file)
        {
            List<Statment> statement = File.ReadAllLines(file)
                                           .Select(x =>
                                           {
                                               string[] parts = x.Split(';');
                                               string quection = parts[0];
                                               string answer = parts[1];
                                               string fact = parts[2];

                                               return new Statment(quection, answer, fact);
                                           })
                                           .ToList();
            this.statement = statement;
            Status = GameStatus.InProgress;
        }

        public Statment GetNextStatment()
        {
            return statement[Count];
        }
        public void HumanAnswer()
        {
            Console.WriteLine("If you think this is true, enter 'Yes', if you think this is false, enter 'No':");
            string answer = Console.ReadLine();
            answer = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(answer);
            string Answer = statement[Count].Answer;
            if (answer != string.Empty && (answer == "Yes" || answer == "No") && answer == Answer)
            {
                Console.WriteLine("You are right!");
                return;
            }
            if (answer != string.Empty && (answer == "Yes" || answer == "No") && answer != Answer)
            {
                Attempt--;
                Console.WriteLine($"You're wrong!{Attempt} attempts left.");
                MachineFact();
                return;
            }
            else
            {
                throw new ArgumentException("You need to answer YES or NO!");
            }
        }
        public void InputValidation()
        {
            bool writtenCorrectly = false;
            while (!writtenCorrectly)
            {
                try
                {
                    HumanAnswer();
                    writtenCorrectly = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        public void MachinQuestion()
        {
            string Question = statement[Count].Question;
            Console.ForegroundColor = ConsoleColor.Red;
            if (Count == 0)
            {
                Console.WriteLine($"Attention! Do you believe that: {Question}");
            }
            else
                Console.WriteLine($"Next statement: {Question}");
            Console.ResetColor();
        }

        public void MachineFact()
        {
            string Fact = statement[Count].Fact;
            Console.WriteLine($"Fact: {Fact}");
        }
        public void Start()
        {
            Status = GameStatus.InProgress;

            while (Status == GameStatus.InProgress)
            {
                if (Count <= 4 && Attempt != 0)
                {
                    MachinQuestion();
                    InputValidation();
                }
                else
                {
                    EndOfGame();
                }
                Count++;
                if (Count <= 4)
                    GetNextStatment();
            }
        }
        private void EndOfGame()
        {
            if (Count > 4 && Attempt != 0)
            {
                Status = GameStatus.GameIsOver;
                Console.WriteLine($"You Won!{Attempt} more attempts left.");
            }
            if (Count <= 4 && Attempt == 0)
            {
                Status = GameStatus.GameIsOver;
                Console.WriteLine($"I won! {Attempt} attempts are over.");
            }
            Environment.Exit(0);
        }
    }

}
