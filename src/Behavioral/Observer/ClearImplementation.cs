namespace Observer.ClearImplementation;

/// <summary>
/// Observer
/// </summary>
public interface IStockUpdater
{
    void Update(Stock stock);
}

/// <summary>
/// ConcreteObserver
/// </summary>
public class Trader : IStockUpdater
{
    public Trader(string name)
    {
        Name = name;
    }

    public string Name { get; }
    
    public void Update(Stock stock)
    {
        Console.WriteLine($"Trader: [{Name}] received stock: {stock}. Recalculating PnL.");
    }
}

/// <summary>
/// Subject
/// </summary>
public abstract class Stock
{
    // traders
    private readonly List<IStockUpdater> _observers;

    protected Stock(string symbol, double buy, double sell)
    {
        Symbol = symbol;
        Buy = buy;
        Sell = sell;
        _observers = new List<IStockUpdater>();
    }

    public string Symbol { get; private set; }
    
    public double Buy { get; private set; }
    
    public double Sell { get; private set; }
    
    /// <summary>
    /// Add observer.
    /// </summary>
    /// <param name="observer"></param>
    public void AttachTrader(IStockUpdater observer)
    {
        _observers.Add(observer);
    }

    /// <summary>
    /// Remove observer.
    /// </summary>
    /// <param name="observer"></param>
    public void DetachTrader(IStockUpdater observer)
    {
        _observers.Remove(observer);
    }

    public void UpdateRate(double buy, double sell)
    {
        Buy = buy;
        Sell = sell;
        Notify();
    }
    
    private void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
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