namespace AbstractFactory;

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