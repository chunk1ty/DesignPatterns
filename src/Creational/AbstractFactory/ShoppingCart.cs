namespace AbstractFactory;

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
        Console.WriteLine($"Total costs = {42 - (42 / 100 * _discountService.Discount()) + _shippingCostsService.ShippingCosts} coming from {_factory}");
    }
}

/// <summary>
/// AbstractFactory
/// </summary>
public interface IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService();

    public IShippingCostsService CreateShippingCostsService();
}

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
