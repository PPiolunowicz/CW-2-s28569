namespace PdContainers;


class Program
{
    static void Main()
    {
        var ship1 = new ContainerShip("Statek1", 30, 5, 50000);
        var ship2 = new ContainerShip("Statek2", 25, 3, 40000);

        var bananaContainer = new RefrigeratedContainer("Bananas");
        var fuelContainer = new LiquidContainer(true);
        var milkContainer = new LiquidContainer(false);
        var heliumContainer = new GasContainer(5);

        
        bananaContainer.Load(5000);
        milkContainer.Load(10000);
        try
        {
            fuelContainer.Load(7000); 
        }
        catch (OverfillException ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
        
        ship1.LoadContainer(bananaContainer);
        ship1.LoadContainer(milkContainer);
        ship1.LoadContainer(heliumContainer);

        
        ship1.TransferContainer(ship2, bananaContainer.SerialNumber);
        
        Console.WriteLine(ship1);
        Console.WriteLine(ship2);
        Console.WriteLine(bananaContainer);
    }
}