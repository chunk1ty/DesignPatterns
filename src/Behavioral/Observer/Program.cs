using Observer.ClearImplementation;

// ClearImplementation();

EventsImplementation();

void ClearImplementation()
{
    var john = new Trader("John");
    var mat = new Trader("Mat");

    var facebookStock = new FacebookStock(101, 99);
    facebookStock.AttachTrader(john);
    facebookStock.AttachTrader(mat);

    facebookStock.UpdateRate(102, 100);
    facebookStock.UpdateRate(103, 101);
    facebookStock.DetachTrader(john);
    facebookStock.UpdateRate(99, 97);

    var vwStock = new VolkswagenStock(200, 199);
    vwStock.AttachTrader(john);
    vwStock.AttachTrader(mat);

    vwStock.UpdateRate(201, 200);
    vwStock.DetachTrader(mat);
    vwStock.UpdateRate(205, 204);

    facebookStock.UpdateRate(96, 95);
}

void EventsImplementation()
{
    var john = new Observer.EventsImplementation.Trader("John");
    var mat = new Observer.EventsImplementation.Trader("Mat");

    var facebookStock = new Observer.EventsImplementation.FacebookStock(101, 99);
    facebookStock.StockUpdated += john.Update;
    facebookStock.StockUpdated += mat.Update;
    
    facebookStock.UpdateRate(102, 100);
    facebookStock.UpdateRate(103, 101);
    facebookStock.StockUpdated -= john.Update;
    facebookStock.UpdateRate(99, 97);
    
    var vwStock = new Observer.EventsImplementation.VolkswagenStock(200, 199);
    vwStock.StockUpdated += john.Update;
    vwStock.StockUpdated += mat.Update;

    vwStock.UpdateRate(201, 200);
    vwStock.StockUpdated -= mat.Update;
    vwStock.UpdateRate(205, 204);

    facebookStock.UpdateRate(96, 95);
    
}