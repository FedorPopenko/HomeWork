namespace Homework.HomeworkGallows
{
    class Gallows
    {
        public Gallows()
        {
            string[] allWords = File.ReadAllLines("WordsStockRus.txt");
            Random rand = new Random();
            int wordIndex = rand.Next(1, 11651);
            string word = allWords[wordIndex];
            int count = 1;
            string playerWord = "";
            string wrong = "";
            bool found = true;

            for (int i = 0; i < word.Length; i++)
            {
                playerWord = playerWord + "-";
            }
            Console.WriteLine("Добро пожаловать на капитал шоу ПОЛЕ ЧУДЕС!");
            Console.WriteLine("Наши дорогие телезрители прислали в нашу редакцию слово, которое вам нужно отгадать за 6 попыток.");

            do
            {
                Console.WriteLine($"Cлово: {playerWord.ToUpper()}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Нет таких букв: {wrong.ToUpper()}");
                Console.ResetColor();
                Alphabet();
                Console.WriteLine($"Вращайте барабан! Это {count} попытка.");
                Console.WriteLine("Напишите букву:");
                string letter = Console.ReadLine();
                Console.Clear();

                found = false;

                string right = "";
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter[0])
                    {
                        found = true;
                        right = right + word[i];
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
                        wrong = wrong + "," + letter[0]; //добавлять и менять цвет в алфавите
                    Console.WriteLine("Нет такой буквы!");
                }
                count++;
            }
            while (count < 7 && word != playerWord);
            if (word == playerWord)
            {
                Console.Clear();
                Console.WriteLine($"Вы совершенно правы, это {word.ToUpper()}");
                Console.WriteLine("Вы выйграли АВТОМОБИЛЬ!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"К сожалению вы проиграли:( Откройте слово! {word.ToUpper()}");
            }
            Console.Write("Нажмите любую клавишу");
            Console.ReadKey();
        }
        public static void Alphabet()
        {
            Console.WriteLine(" А Б В Г Д Е Ё Ж З И Й ");
            Console.WriteLine(" К Л М Н О П Р С Т У Ф ");
            Console.WriteLine(" Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я ");
        }

    }
}
