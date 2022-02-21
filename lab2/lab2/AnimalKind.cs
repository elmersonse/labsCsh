namespace Lab2;

public abstract class AnimalKind<T> : IToString
{
    private string _kind;
    private T? _avgAge;

    protected AnimalKind()
    {
        _kind = "";
    }

    protected AnimalKind(string kind, T avgAge)
    {
        _kind = kind;
        _avgAge = avgAge;
    }

    public string GetKind()
    {
        return _kind;
    }

    public T GetAvgAge()
    {
        return _avgAge;
    }

    public void SetKind(string kind)
    {
        _kind = kind;
    }

    public void SetAvgAge(T? avgAge)
    {
        _avgAge = avgAge;
    }

    public override string ToString()
    {
        return _kind + ";" + _avgAge + ";";
    }
}