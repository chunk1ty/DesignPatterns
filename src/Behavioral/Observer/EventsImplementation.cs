namespace Observer.EventsImplementation;

/// <summary>
/// ConcreteObserver
/// </summary>
public class Trader 
{
    public Trader(string name)
    {
        Name = name;
    }

    public string Name { get; }
    
    public void Update(object sender, Stock stock)
    {
        Console.WriteLine($"Trader: [{Name}] received stock: {stock}. Recalculating PnL.");
    }
}

/// <summary>
/// Subject
/// </summary>
public abstract class Stock
{
    protected Stock(string symbol, double buy, double sell)
    {
        Symbol = symbol;
        Buy = buy;
        Sell = sell;
    }

    public string Symbol { get; private set; }
    
    public double Buy { get; private set; }
    
    public double Sell { get; private set; }
    
    /// <summary>
    /// Observer
    /// </summary>
    public event EventHandler<Stock> StockUpdated;

    public void UpdateRate(double buy, double sell)
    {
        Buy = buy;
        Sell = sell;
        StockUpdated?.Invoke(this, this);
    }

    public override string ToString()
    {
        return $"Symbol: [{Symbol}] Ask: [{Buy}], Bid: [{Sell}]";
    }
}

/// <summary>
/// ConcreteSubject
/// </summary>
public class FacebookStock : Stock
{
    public FacebookStock(double buy, double sell) 
        : base("FB", buy, sell)
    {
    }
}

/// <summary>
/// ConcreteSubject
/// </summary>
public class VolkswagenStock : Stock
{
    public VolkswagenStock(double buy, double sell) 
        : base("VW", buy, sell)
    {
    }
}