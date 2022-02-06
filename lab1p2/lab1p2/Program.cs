using System;
using System.Diagnostics;

namespace lab1p2
{
    class Runner
    {
        static void Main()
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Выберите задачу для выполнения:");
            Console.WriteLine("1) Вектор 1");
            Console.WriteLine("2) Вектор 2");
            Console.WriteLine("3) Матрица");
            Console.WriteLine("4) Выход");
            String c = Console.ReadLine();
            switch (c)
            {
                case "1":
                    Console.Clear();
                    vector1();
                    break;
                case "2":
                    Console.Clear();
                    vector2();
                    break;
                case "3":
                    Console.Clear();
                    matrix();
                    break;
                case "4":
                    return;
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }

        static void vector1()
        {
            int n, t, s, i;
            while (true)
            {
                Console.WriteLine("Введите длину вектора:");
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Данные введены неверно");
                }
                else
                {
                    break;
                }
            }
            int[] v = new int[n];
            while (true)
            {
                Console.WriteLine("Введите элементы вектора:");
                for (i = 0; i < n; i++)
                {
                    Console.Write(String.Format($"v[{i}] = "));
                    if (!int.TryParse(Console.ReadLine(), out v[i]))
                    {
                        Console.WriteLine("Данные введены неверно");
                        break;
                    }
                }
                if (i == n)
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Введите t:");
                if (!int.TryParse(Console.ReadLine(), out t))
                {
                    Console.WriteLine("Данные введены неверно");
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Введите s:");
                if (!int.TryParse(Console.ReadLine(), out s))
                {
                    Console.WriteLine("Данные введены неверно");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Исходный вектор:");
            foreach (int e in v)
            {
                Console.Write(e+" ");
            }
            int res = task1(v, t, s);
            if (res == -1)
            {
                Console.WriteLine("\nНет подходящих элементов");
            }
            else
            {
                Console.WriteLine(String.Format($"\nНомер последнего минимального элемента среди элементов, меньших {t} " +
                                                $"и лежащих правее первого элемента, равного {s} = {res}"));
            }
        }

        static int task1(int[] v, int t, int s)
        {
            int eq, i, min, imin;
            int n = v.Length;
            for (eq = 0; eq < n; eq++)
            {
                if (v[eq] == s)
                {
                    break;
                }
            }

            min = v[eq];
            imin = eq;
            for (i = eq+1; i < n; i++)
            {
                if (v[i] < t && v[i] <= min)
                {
                    min = v[i];
                    imin = i;
                }
            }

            if (imin == eq)
            {
                return -1;
            }
            return imin;
        }

        static void vector2()
        {
            int n, i, j;
            while (true)
            {
                Console.WriteLine("Введите размерность матрицы:");
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Данные введены неверно");
                }
                else
                {
                    break;
                }
            }
            int[,] m = new int[n,n];
            while (true)
            {
                Console.WriteLine("Введите элементы вектора:");
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        Console.Write(String.Format($"v[{i},{j}] = "));
                        if (!int.TryParse(Console.ReadLine(), out m[i,j]))
                        {
                            Console.WriteLine("Данные введены неверно");
                            break;
                        }
                    }
                    if (j != n)
                    {
                        break;
                        
                    }
                }
                if (i == n)
                {
                    break;
                }
            }

            Console.WriteLine("Исходная матрица");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write($"{m[i,j]} ");
                }
                Console.WriteLine();
            }
            int[] b = new int[n];
            task2(m, out b, n);
            Console.WriteLine("Полученный вектор:");
            foreach (int e in b)
            {
                Console.Write(e+" ");
            }
        }

        static void task2(int[,] m, out int[] b, int n)
        {
            int[] res = new int[n];
            int sum;
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (m[i, j] < 0)
                    {
                        sum += m[i, j];
                    }
                }
                res[i] = sum;
            }
            b = res;
        }

        static void matrix()
        {
            int n, i, j;
            while (true)
            {
                Console.WriteLine("Введите размерность матрицы:");
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Данные введены неверно");
                }
                else
                {
                    break;
                }
            }
            int[,] m = new int[n,n];
            while (true)
            {
                Console.WriteLine("Введите элементы вектора:");
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        Console.Write(String.Format($"v[{i},{j}] = "));
                        if (!int.TryParse(Console.ReadLine(), out m[i,j]))
                        {
                            Console.WriteLine("Данные введены неверно");
                            break;
                        }
                    }
                    if (j != n)
                    {
                        break;
                        
                    }
                }
                if (i == n)
                {
                    break;
                }
            }
            Console.WriteLine("Исходная матрица");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write($"{m[i,j]} ");
                }
                Console.WriteLine();
            }
            task3(ref m, n);
            Console.WriteLine("Полученная матрица");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write($"{m[i,j]} ");
                }
                Console.WriteLine();
            }
            
        }

        static void task3(ref int[,] m, int n)
        {
            int[] temp = new int[n];
            for (int i = 0; i < n-1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (m[i, 0] > m[j, 0])
                    {
                        for (int k = 0; k < n; k++)
                        {
                            temp[k] = m[i, k];
                        }
                        for (int k = 0; k < n; k++)
                        {
                            m[i,k] = m[j, k];
                        }
                        for (int k = 0; k < n; k++)
                        {
                            m[j, k] = temp[k];
                        }
                    }
                }
            }
        }
    }
}