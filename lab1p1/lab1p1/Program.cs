using System;
using System.Collections.Generic;

namespace lab1p1
{
    class Runner
    {
        static void Main()
        {
            int n, k;
            while (true)
            {
                Console.WriteLine("Введите n");
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Данные введены неверно");
                    continue;
                }
                
                Console.WriteLine("Введите k");
                if (!int.TryParse(Console.ReadLine(), out k))
                {
                    Console.WriteLine("Данные введены неверно");
                    continue;
                }

                if (n > k)
                {
                    Console.WriteLine("n должно быть меньше k");
                }
                else
                {
                    break;
                }
            }
            float h;
            List<double[]> list = new List<double[]>();
            while (true)
            {
                Console.WriteLine("Введите шаг:");
                if (!float.TryParse(Console.ReadLine(), out h))
                {
                    Console.WriteLine("Данные введены неверно");
                }
                else
                {
                    break;
                }
            }
            
            int j = 0;
            double x, y;
            for (float i = n; i <= k; i += h, j++)
            {
                x = i;
                if (i <= -6)
                {
                    y = -2 * Math.Sqrt(1 - Math.Pow(i / 2 + 4, 2)) + 2;
                }
                else if (i <= -4)
                {
                    y = 2;
                }
                else if (i <= 2)
                {
                    y = -i / 2;
                }
                else
                {
                    y = i - 3;
                }

                list.Add(new double[] {x, y});
                
            }
            
            Console.WriteLine($"{'x', -7} | {'y', -7}");
            foreach (double[] mas in list)
            {
                Console.WriteLine($"{mas[0].ToString("F"), -7} | {mas[1].ToString("F"), -7}");
            }
        }
    }
}
