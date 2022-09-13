namespace FactoryMethod;

/// <summary>
/// Creator
/// </summary>
public abstract class DiscountFactory
{
    public abstract DiscountService CreateDiscountService();
}

/// <summary>
/// ConcretCreator
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
