using BuildingManager.Contracts;

namespace BuildingManager.Adapters;

public class AmericanElectricalDeviceAdapter : IElectricalDevice
{
    private readonly IAmericanElectricalDevice _americanElectricalDevice;

    public AmericanElectricalDeviceAdapter(IAmericanElectricalDevice americanElectricalDevice)
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