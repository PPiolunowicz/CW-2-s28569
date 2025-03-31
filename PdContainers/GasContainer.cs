namespace PdContainers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }

    public GasContainer(double pressure)
        : base("G", 8000, 2500, 240, 580)
    {
        Pressure = pressure;
    }

    public override void Unload()
    {
        CargoMass *= 0.05; 
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"UWAGA: {message}");
    }
}
