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