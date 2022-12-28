using System.Text;

namespace Builder;

/// <summary>
/// Product class
/// </summary>
public class Car
{
    private readonly List<string> _parts = new();
    private readonly string _carType;

    public Car(string carType)
    {
        _carType = carType;
    }

    public void AddPart(string part)
    {
        _parts.Add(part);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (string part in _parts)
        {
            sb.Append($"Car of type [{_carType}] has part [{part}]. ");
        }

        return sb.ToString();
    }
}

/// <summary>
/// Builder abstract class
/// </summary>
public abstract class CarBuilder
{
    public CarBuilder(string carType)
    {
        Car = new Car(carType);
    }
    public Car Car { get; private set; }

    public abstract void BuildEngine();

    public abstract void BuildFrame();
}

/// <summary>
/// ConcreteBuilder1 class
/// </summary>
public class VwBuilder : CarBuilder
{
    public VwBuilder()
        : base("Vw")
    {
    }

    public override void BuildEngine()
    {
        Car.AddPart("174-hp turbocharged 2.0-liter four-cylinder");
    }

    public override void BuildFrame()
    {
        Car.AddPart("5-door");
    }
}

/// <summary>
/// ConcreteBuilder2 class
/// </summary>
public class BMWBuilder : CarBuilder
{
    public BMWBuilder()
        : base("BMW")
    {
    }

    public override void BuildEngine()
    {
        Car.AddPart("'a fancy V8 engine'");
    }

    public override void BuildFrame()
    {
        Car.AddPart("'5-door with metallic finish'");
    }
}

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