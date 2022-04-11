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
            int n, c, d, i;
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
                Console.WriteLine("Введите c:");
                if (!int.TryParse(Console.ReadLine(), out c))
                {
                    Console.WriteLine("Данные введены неверно");
                    continue;
                }
                Console.WriteLine("Введите d:");
                if (!int.TryParse(Console.ReadLine(), out d))
                {
                    Console.WriteLine("Данные введены неверно");
                    continue;
                }

                if (c > d)
                {
                    Console.WriteLine("n должно быть меньше k");
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
            int res = task1(v, c, d, n);
            if (res == -1)
            {
                Console.WriteLine("\nОшибка выполнения. Проверьте данные");
            }
            else
            {
                Console.WriteLine(String.Format($"\nНомер последнего максимального элемента = {res}"));
            }
        }

        static int task1(int[] v, params int[] p)
        {
            int even, i, max, imax;
            for (even = 0; even < p[2]; even++)
            {
                if (v[even] % 2 == 0)
                {
                    break;
                }
            }

            max = int.MinValue;
            imax = -1;
            for (i = 0; i < even; i++)
            {
                if (v[i] >= p[0] && v[i] <= p[1] && v[i] >= max)
                {
                    max = v[i];
                    imax = i;
                }
            }
            return imax;
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
                    if (m[j, i] % 2 == 1 )
                    {
                        sum++;
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
            int temp;
            for (int i = 0; i < n; i++)
            {
                temp = m[0, i];
                m[0, i] = m[i, n-1];
                m[i, n-1] = temp;
            }
        }
    }
}