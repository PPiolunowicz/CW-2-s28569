namespace PdContainers;

public abstract class Container
{
    private static int _counter = 1;
    public string SerialNumber { get; }
    public double CargoMass { get; protected set; }
    public double MaxLoad { get; }
    public double OwnWeight { get; }
    public double Height { get; }
    public double Depth { get; }

    protected Container(string type, double maxLoad, double ownWeight, double height, double depth)
    {
        SerialNumber = $"KON-{type}-{_counter++}";
        MaxLoad = maxLoad;
        OwnWeight = ownWeight;
        Height = height;
        Depth = depth;
        CargoMass = 0;
    }

    public virtual void Load(double mass)
    {
        if (CargoMass + mass > MaxLoad)
            throw new OverfillException($"Przekroczono ładowność kontenera {SerialNumber}");
        CargoMass += mass;
    }

    public virtual void Unload()
    {
        CargoMass = 0;
    }

    public override string ToString()
    {
        return $"{SerialNumber} | Ładunek: {CargoMass}/{MaxLoad} kg";
    }
}

public class OverfillException : Exception
{
    public OverfillException()
    {
    }
    public OverfillException(string s)
        : base(s)
    {
    }

    public OverfillException(string s, Exception inner)
        : base(s, inner)
    {
    }
}


