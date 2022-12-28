namespace AbstractFactory;

/// <summary>
///  AbstractProduct
/// </summary>
public interface IDiscountService
{
    public int Discount();
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class BulgarianDiscountService : IDiscountService
{
    public int Discount()
    {
        return 14;
    }
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class AmericanDiscountService : IDiscountService
{
    public int Discount()
    {
        return 10;
    }
}

/// <summary>
///  AbstractProduct
/// </summary>
public interface IShippingCostsService
{
    decimal ShippingCosts { get; }
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class BulgarianShippingCostsService : IShippingCostsService
{
    public decimal ShippingCosts => 5;
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class AmericanShippingCostsService : IShippingCostsService
{
    public decimal ShippingCosts => 3;
}

/// <summary>
/// AbstractFactory
/// </summary>
public interface IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService();

    public IShippingCostsService CreateShippingCostsService();
}

/// <summary>
/// ConcreteFactory
/// </summary>
public class BulgarianShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService()
    {
        return new BulgarianDiscountService();
    }

    public IShippingCostsService CreateShippingCostsService()
    {
        return new BulgarianShippingCostsService();
    }
}

/// <summary>
/// ConcreteFactory
/// </summary>
public class AmericanShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService()
    {
        return new AmericanDiscountService();
    }

    public IShippingCostsService CreateShippingCostsService()
    {
        return new AmericanShippingCostsService();
    }
}

/// <summary>
/// Client class 
/// </summary>
public class ShoppingCart
{
    private readonly IDiscountService _discountService;
    private readonly IShippingCostsService _shippingCostsService;
    private readonly IShoppingCartPurchaseFactory _factory;

    public ShoppingCart(IShoppingCartPurchaseFactory factory)
    {
        _factory = factory;
        _discountService = factory.CreateDiscountService();
        _shippingCostsService = factory.CreateShippingCostsService();
    }

    public void CalculateCosts()
    {
        Console.WriteLine(
            $"Total costs = {42 - (42 / 100 * _discountService.Discount()) + _shippingCostsService.ShippingCosts} coming from {_factory}");
    }
}