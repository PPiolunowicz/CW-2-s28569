namespace PdContainers;

public class ContainerShip
{
    public string Name { get; }
    public double MaxSpeed { get; }
    public int MaxContainers { get; }
    public double MaxWeight { get; }
    private List<Container> Containers = new();

    public ContainerShip(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
            throw new InvalidOperationException("Przekroczono limit kontenerów na statku");

        double totalWeight = Containers.Sum(c => c.OwnWeight + c.CargoMass);
        if (totalWeight + container.OwnWeight + container.CargoMass > MaxWeight * 1000)
            throw new InvalidOperationException("Przekroczono maksymalną ładowność statku");

        Containers.Add(container);
    }

    public void RemoveContainer(string serialNumber)
    {
        Containers.RemoveAll(c => c.SerialNumber == serialNumber);
    }

    public void TransferContainer(ContainerShip destination, string serialNumber)
    {
        Container container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            RemoveContainer(serialNumber);
            destination.LoadContainer(container);
        }
    }

    public override string ToString()
    {
        return $"Statek: {Name} | Prędkość: {MaxSpeed} | Kontenery: {Containers.Count}/{MaxContainers}";
    }
}
