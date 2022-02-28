namespace lab3;
class lab3
{
    delegate double Func(double x, double y);

    static void Main()
    {
        Console.WriteLine("Выберите функцию (1 - f, 2 - g):");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите x:");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите y:");
        double y = double.Parse(Console.ReadLine());
        double res;
        switch (n)
        {
            case 1:
                res = z(x, y, f);
                break;
            case 2:
                res = z(x, y, g);
                break;
            default:
                res = -1;
                break;
        }
        Console.WriteLine("Результат выполнения метода = {0}", res);
    }

    static double f(double x, double y)
    {
        return 6 * x + y;
    }

    static double g(double x, double y)
    {
        return 5 * x - y + 5;
    }

    static double z(double x, double y, Func fn)
    {
        return fn(x, y) - 3 * fn(x, 2 * y);
    }
}

