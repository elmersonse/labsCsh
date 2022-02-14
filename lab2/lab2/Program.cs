namespace Lab2
{
    class Runner
    {
        static void Main()
        {
            Animal<int> a = new Animal<int>("cat", "barsik", 5);
            Console.WriteLine(a.ToString());
            Worker w = new Worker();
            w.Name = "Vasya";
            w.Salary = -1;
            Console.WriteLine(w.ToString());
        }
    }
}

