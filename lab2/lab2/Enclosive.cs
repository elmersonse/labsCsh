using Microsoft.Win32;

namespace Lab2;

public class Enclosure : IToString
{
    private Worker[] _workers;
    private string _type;
    private float _area;
    private Animal<int> _animal;

    public Enclosure()
    {
        _workers = null;
        _animal = new Animal<int>();
        _type = "";
        _area = 0;
    }

    public Enclosure(Worker[] workers, Animal<int> animal, string type, float area)
    {
        _workers = workers;
        _animal.SetAge(animal.GetAge());
        _animal.SetName(animal.GetName());
        _animal.SetAvgAge(animal.GetAvgAge());
        _animal.SetKind(animal.GetKind());
        _type = type;
        _area = area;
    }

    public Worker this[int i]
    {
        get => _workers[i];
        set => _workers[i] = value;
    }

    public Worker[] GetWorkers()
    {
        return _workers;
    }
    
    public string GetEType()
    {
        return _type;
    }

    public float GetArea()
    {
        return _area;
    }

    public Animal<int> GetAnimal()
    {
        return _animal;
    }

    public void SetWorkers(Worker[] workers)
    {
        _workers = workers;
    }

    public void SetType(string type)
    {
        _type = type;
    }

    public void SetArea(float area)
    {
        _area = area;
    }

    public void SetAnimal(Animal<int> animal)
    {
        _animal.SetAge(animal.GetAge());
        _animal.SetName(animal.GetName());
        _animal.SetAvgAge(animal.GetAvgAge());
        _animal.SetKind(animal.GetKind());
    }

    public override string ToString()
    {
        return _type + ";" + _area + ";" + _animal;
    }
}