namespace Builder;

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