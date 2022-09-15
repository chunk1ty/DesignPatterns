namespace Decorator;

/// <summary>
/// Component
/// </summary>
public interface IElectricalDevice
{
    void ConsumeElectricity(double electricity);
}

/// <summary>
/// Leaf
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
/// Composite
/// </summary>
public class PowerStrip : IElectricalDevice
{
    private readonly IEnumerable<IElectricalDevice> _electricalDevices;

    public PowerStrip(IEnumerable<IElectricalDevice> electricalDevices)
    {
        this._electricalDevices = electricalDevices;
    }

    public void ConsumeElectricity(double electricity)
    {
        foreach (IElectricalDevice consumer in this._electricalDevices)
        {
            consumer.ConsumeElectricity(electricity);
            Console.WriteLine(consumer);
        }
    }

    public override string ToString()
    {
        return $"Power strip with devices:\n{string.Join("\n", this._electricalDevices)}";
    }
}