namespace Lab2
{
    class Runner
    {
        static void Main()
        {
            Animal<int> a1 = new Animal<int>("Ruslan", 22, "Ruslan", 20);
            Enclosure e1 = new Enclosure();
            e1.SetType("Kvartira");
            e1.SetArea(40);
            e1.SetAnimal(a1);
            Console.WriteLine(a1);
            Console.WriteLine(e1);
        }
    }
}

