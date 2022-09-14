namespace Builder;

/// <summary>
/// Director
/// </summary>
public class Garage
{
    private CarBuilder _builder;

    public Garage()
    {
    }

    public void Construct(CarBuilder builder)
    {
        _builder = builder;

        _builder.BuildEngine();
        _builder.BuildFrame();
    }

    // variation: the show method on the director instead of on the product.
    public void Show()
    {
        Console.WriteLine(_builder.Car.ToString());
    }
}