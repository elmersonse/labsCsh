using Microsoft.VisualBasic;

namespace lab4
{
    class lab4
    {
        static void Main()
        {
            Console.WriteLine("1) Строки\n2) Текстовый файл\n3) Бинарный файл");
            int c = Int32.Parse(Console.ReadLine());
            switch (c)
            {
                case 1:
                    Strings();
                    break;
            }
        }

        static void Strings()
        {
            Console.Clear();
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            string newText = StringsDo(text);
            if (newText.Equals("-1"))
            {
                Console.WriteLine("Пара слов отсутствует");
            }
            else
            {
                Console.WriteLine($"Полученная пара слов: {newText}");    
            }
        }

        static string StringsDo(string text)
        {
            List<string> words = text.Split(' ').ToList();
            List<string> reversedWords = new List<string>();
            foreach (var word in words)
            {
                reversedWords.Add(new string(word.ToCharArray().Reverse().ToArray()));
            }

            foreach (var word in words)
            {
                if (reversedWords.Contains(word))
                {
                    return word + " " + new string(word.ToCharArray().Reverse().ToArray());
                }
                
            }
            return "-1";
        }
    }
}