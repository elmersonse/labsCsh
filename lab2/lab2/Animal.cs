namespace Lab2;

public class Animal<T>: AnimalKind
{
    private string _name;
    private T? _age;

    public Animal()
    {
        _name = "";
    }

    public Animal(string kind, string name, T? age) : base(kind)
    {
        _name = name;
        _age = age;
    }

    public string GetName()
    {
        return _name;
    }

    public T? GetAge()
    {
        return _age;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetAge(T? age)
    {
        _age = age;
    }

    public override string ToString()
    {
        return base.ToString() + _name + ";" + _age;
    }
}