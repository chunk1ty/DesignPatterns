namespace Decorator;

/// <summary>
/// Component (as interface)
/// </summary>
public interface IElectricalDevice
{
    void ConsumeElectricity(double electricity);
}

/// <summary>
/// ConcreteComponent1
/// </summary>
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

/// <summary>
/// Decorator (as abstract base class)
/// </summary>
public class HighElectricityDefenderDecorator : IElectricalDevice
{
    private const double MaxElectricityAllowed = 100;

    private readonly IElectricalDevice _electricalDevice;

    public HighElectricityDefenderDecorator(IElectricalDevice electricalDevice)
    {
        _electricalDevice = electricalDevice;
    }

    public void ConsumeElectricity(double electricity)
    {
        if (electricity <= MaxElectricityAllowed)
        {
            _electricalDevice.ConsumeElectricity(electricity);
        }
    }

    public override string ToString()
    {
        return $"Defender with:\n{_electricalDevice}";
    }
}