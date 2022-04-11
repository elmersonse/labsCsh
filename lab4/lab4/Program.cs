using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace lab4
{
    class lab4
    {
        static void Main()
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1) Строки\n2) Текстовый файл\n3) Бинарный файл");
            int c = Int32.Parse(Console.ReadLine());
            switch (c)
            {
                case 1:
                    Strings();
                    break;
                case 2:
                    TxtFile();
                    break;
                case 3:
                    BinFile();
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
            Console.ReadLine();
            Menu();
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

        static void TxtFile()
        {
            Console.Clear();
            StreamReader file = new StreamReader("temp.txt");
            
            List<string> l = TxtFileDo(file);
            using (StreamWriter res = new StreamWriter("res.txt", false))
            {
                foreach (var s in l)
                {
                    Console.WriteLine(s);
                    res.WriteLine(s);
                }
            }
            Console.WriteLine("Task done!");
            Console.ReadLine();
            Menu();
        }

        static List<string> TxtFileDo(StreamReader file)
        {
            String s;
            List<string> list = new List<string>();
            while ((s = file.ReadLine()) != null)
            {
                if (!s.Contains(','))
                {
                    list.Add(s);
                }
            }
            return list;
        }

        static void BinFile()
        {
            string desktopPath = "";
            using StreamReader sr = new StreamReader("Var10.dat");
            BinaryFormatter bf = new BinaryFormatter();

            TvShow[] shows = (TvShow[]) bf.Deserialize(sr.BaseStream);
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            desktopPath = Path.Combine(desktopPath, "TvShows");
            Directory.CreateDirectory(desktopPath);
            for (int i = 0; i < shows.Length; i++)
            {
                using StreamWriter file = new StreamWriter(Path.Combine(desktopPath, shows[i].TvChannel + ".txt"), true);
                file.WriteLine("Название: {0}, Время показа: {1}", shows[i].Title, shows[i].BroadcastTime);
            }
        }
    }
}