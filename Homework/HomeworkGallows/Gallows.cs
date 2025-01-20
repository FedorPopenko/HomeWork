namespace Homework.HomeworkGallows
{
    class Gallows
    {
        public string Word { get; private set; }
        public GameStatus GameStatus { get; private set; }

        public int count = 1;
        public string playerWord = "";
        public string wrong = "";
        public string letter;
        bool found = true;
        public HashSet<char> calledLetters = new HashSet<char>();

        public void CheckLetter()
        {
            found = false;

            string right = "";
            for (int i = 0; i < Word.Length; i++)
            {
                playerWord = playerWord + "-";

                if (Word[i] == letter[0])
                {
                    found = true;
                    right = right + Word[i];
                    Console.Clear();
                    Console.WriteLine("Есть такая буква!");
                }
                else
                {
                    right = right + playerWord[i];
                }
            }

            if (found == true)
            {
                count--;
            }

            playerWord = right;

            if (!found)
            {
                if (wrong.Length == 0)
                {
                    wrong = wrong + letter[0];
                }
                else
                    wrong = wrong + "," + letter[0];
                Console.WriteLine("Нет такой буквы!");
            }
        }
        public void CheckResult()
        {
            if (Word == playerWord)
            {
                GameStatus = GameStatus.Won;
                Console.Clear();
                Console.WriteLine($"Вы совершенно правы, это {Word.ToUpper()}");
                Console.WriteLine("Вы выйграли АВТОМОБИЛЬ!");
            }
            else
            {
                GameStatus = GameStatus.Lost;
                Console.Clear();
                Console.WriteLine($"К сожалению вы проиграли:( Откройте слово! {Word.ToUpper()}");
            }
            Console.Write("Нажмите любую клавишу");
            Console.ReadKey();
        }
        public string HiddenWord()
        {
            string[] allWords = File.ReadAllLines("WordsStockRus.txt");
            Random rand = new Random();
            int wordIndex = rand.Next(0, 11651);
            Word = allWords[wordIndex].ToUpper();
            GameStatus = GameStatus.InProgress;
            return Word;
        }

        public void Alphabet()
        {
            char[] alphabet = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й',
            'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
            'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'};
            int counter = 0;
            foreach (char letters in alphabet)
            {
                if (calledLetters.Contains(letters))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(letters + " ");

                counter++;

                if (counter == alphabet.Length / 3)
                    Console.WriteLine();
                else if (counter == alphabet.Length - 11)
                    Console.WriteLine();
            }

            Console.ResetColor();
            Console.WriteLine();
        }

    }
}
