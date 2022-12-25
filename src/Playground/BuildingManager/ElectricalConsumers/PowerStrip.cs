using BuildingManager.Contracts;

namespace BuildingManager.ElectricalConsumers;

/// <summary>
///  Composite
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
        }
    }

    public override string ToString()
    {
        return $"Power strip with devices:\n{string.Join("\n", this._electricalDevices)}";
    }
}