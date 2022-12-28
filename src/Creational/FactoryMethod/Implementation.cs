namespace FactoryMethod;

/// <summary>
/// Product
/// </summary>
public abstract class DiscountService
{
    public abstract int Discount();
}

/// <summary>
/// ConcreteProduct
/// </summary>
public sealed class CountryDiscountService : DiscountService
{
    private readonly string _countryCode;

    public CountryDiscountService(string countryCode)
    {
        _countryCode = countryCode;
    }

    public override int Discount()
    {
        switch (_countryCode)
        {
            case "BG":
                return 17;
            case "US":
                return 10;
            default:
                return 0;
        }
    }
}

/// <summary>
/// ConcreteProduct
/// </summary>
public sealed class CodeDiscountService : DiscountService
{
    public override int Discount()
    {
        return 5;
    }
}

/// <summary>
/// Creator
/// </summary>
public abstract class DiscountFactory
{
    public abstract DiscountService CreateDiscountService();
}

/// <summary>
/// ConcreteCreator
/// </summary>
public class CountryDiscountFactory : DiscountFactory
{
    private readonly string _countryIdentifier;
    public CountryDiscountFactory(string countryIdentifier)
    {
        _countryIdentifier = countryIdentifier;
    }

    public override DiscountService CreateDiscountService()
    {
        return new CountryDiscountService(_countryIdentifier);
    }
}

/// <summary>
/// ConcreteCreator
/// </summary>
public class CodeDiscountFactory : DiscountFactory
{   
    public override DiscountService CreateDiscountService()
    {
        return new CodeDiscountService();
    }
}
