namespace Lab2;

public abstract class AnimalKind
{
    private string _kind;

    protected AnimalKind()
    {
        _kind = "";
    }

    protected AnimalKind(string kind)
    {
        _kind = kind;
    }

    public string GetKind()
    {
        return _kind;
    }

    public void SetKind(string kind)
    {
        _kind = kind;
    }

    public override string ToString()
    {
        return _kind + ";";
    }
}