namespace PdContainers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    public LiquidContainer(bool isHazardous)
        : base("L", 12000, 3500, 260, 620)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double mass)
    {
        double maxCapacity = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;

        if (CargoMass + mass > maxCapacity)
        {
            NotifyHazard($"Próba przekroczenia limitu dla {SerialNumber}");
            throw new OverfillException($"Nie można załadować {mass} kg do {SerialNumber}");
        }

        CargoMass += mass;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"UWAGA: {message}");
    }
}
