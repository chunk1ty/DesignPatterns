namespace Strategy;

/// <summary>
/// Strategy
/// </summary>
public interface IExportService
{
    void Export(Order order);
}

/// <summary>
/// ConcreteStrategy
/// </summary>
public class JsonExportService : IExportService
{
    public void Export(Order order)
    {
        Console.WriteLine($"Exporting {order.Name} to Json.");
    }
}

/// <summary>
/// ConcreteStrategy
/// </summary>
public class XmlExportService : IExportService
{
    public void Export(Order order)
    {
        Console.WriteLine($"Exporting {order.Name} to XML.");
    }
}

/// <summary>
/// ConcreteStrategy
/// </summary>
public class CsvExportService : IExportService
{
    public void Export(Order order)
    {
        Console.WriteLine($"Exporting {order.Name} to CSV.");
    }
}
   
/// <summary>
/// Context
/// </summary>
public class Order
{
    public Order(string customer, int amount, string name)
    {
        Customer = customer;
        Amount = amount;
        Name = name;
    }
    
    public string Customer { get; }
    
    public int Amount { get; }
    
    public string Name { get; }

    public void Export(IExportService exportService)
    {
        if (exportService is null)
        {
            throw new ArgumentNullException(nameof(exportService));
        }

        exportService.Export(this);
    }
}