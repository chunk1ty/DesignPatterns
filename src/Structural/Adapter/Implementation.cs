namespace Adapter;

/// <summary>
/// Target
/// </summary>
public interface IElectricalDevice
{
    void ConsumeElectricity(double electricity);
}

/// <summary>
/// Adaptee
/// </summary>
public interface IAmericanElectricalDevice
{
    void ConsumeAmericanElectricity(double electricity);
}

/// <summary>
/// Adapter
/// </summary>
public class AmericanElectricalAdapter : IElectricalDevice
{
    private readonly IAmericanElectricalDevice _americanElectricalDevice;

    public AmericanElectricalAdapter(IAmericanElectricalDevice americanElectricalDevice)
    {
        _americanElectricalDevice = americanElectricalDevice;
    }

    public void ConsumeElectricity(double electricity)
    {
        _americanElectricalDevice.ConsumeAmericanElectricity(electricity);
    }

    public override string ToString()
    {
        return $"Adapter with:\n{_americanElectricalDevice}";
    }
}

public class Laptop : IElectricalDevice
{
    private const double MaxCapacity = 100;

    public double ElectricityCapacity { get; private set; }

    public void ConsumeElectricity(double electricity)
    {
        ElectricityCapacity = Math.Min(this.ElectricityCapacity + electricity, MaxCapacity);
    }

    public override string ToString()
    {
        return $"Laptop with capacity: {(this.ElectricityCapacity / MaxCapacity) * 100}%";
    }
}

public class AmericanLaptop : IAmericanElectricalDevice
{
    private const double MaxCapacity = 200;

    public double ElectricityCapacity { get; private set; }

    public void ConsumeAmericanElectricity(double electricity)
    {
        // if its needed do electricity adjusments
        ElectricityCapacity = Math.Min(ElectricityCapacity + electricity, MaxCapacity);
    }

    public override string ToString()
    {
        return $"American laptop with capacity: {(ElectricityCapacity / MaxCapacity) * 100}%";
    }
}
