namespace PdContainers;

public class RefrigeratedContainer : Container
{
    private string ProductType { get; }
    private double Temperature { get; }
    

    private static readonly Dictionary<string, double> RequiredTemperatures = new Dictionary<string, double>
    {
        { "Bananas", 13.3 }, { "Chocolate", 18 }, { "Fish", 2 }, { "Meat", -15 }, { "Ice cream", -18 },
        { "Frozen pizza", -30 }, { "Cheese", 7.2 }, { "Sausages", 5 }, { "Butter", 20.5 }, { "Eggs", 19 }
    };

    public RefrigeratedContainer(string productType)
        : base("C", 10000, 3000, 250, 600)
    {
        if (!RequiredTemperatures.ContainsKey(productType))
            throw new ArgumentException("Nieznany produkt!");

        ProductType = productType;
        Temperature = RequiredTemperatures[productType];
    }

    public override string ToString()
    {
        return base.ToString() + $" | Produkt: {ProductType} | Temp: {Temperature}°C";
    }
}
