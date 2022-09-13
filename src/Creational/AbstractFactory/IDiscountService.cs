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