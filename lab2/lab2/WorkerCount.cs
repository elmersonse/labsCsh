namespace Lab2;

public static class WorkerCount
{
    public static int CountW(this Enclosure enclosure)
    {
        return enclosure.GetWorkers().Length;
    }
}