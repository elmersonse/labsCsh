namespace lab3p2;

class lab3p2
{
    delegate int Operation(int x);
    
    static void Main()
    {
        int n, i;
        Console.WriteLine("Введите длину вектора:");
        n = int.Parse(Console.ReadLine());
        int[] v = new int[n];
        Console.WriteLine("Введите элементы вектора:");
        for (i = 0; i < n; i++)
        {
            Console.Write(String.Format($"v[{i}] = "));
            v[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Выберите функцию для выполнения:");
        int c = int.Parse(Console.ReadLine());
        int res;
        switch (c)
        {
            case 1:
                res = Func1(v, i => { if (i % 2 == 0) return i; return 1; });
                break;
            case 2:
                res = Func2(v, i => { if (i % 5 == 0) return i; return 0; });
                break;
            default:
                res = -1;
                break;
        }
        Console.WriteLine($"Результат выполнения = {res}");
    }

    static int Func1(int[] mas, Operation op)
    {
        int c = 1;
        foreach (var i in mas)
        {
            c*=op(i);
        }
        return c;
    }

    static int Func2(int[] mas, Operation op)
    {
        int c = 0;
        foreach (var i in mas)
        {
            c += op(i);
        }
        return c;
    }
}