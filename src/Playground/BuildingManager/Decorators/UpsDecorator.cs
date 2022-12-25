using BuildingManager.Contracts;

namespace BuildingManager.Decorators;

public class UpsDecorator : IElectricalDevice
{
    private const double MaxReservedCapacity = 50;
    private const double PassedElectricity = 5;

    private readonly IElectricalDevice _electricalDevice;

    public UpsDecorator(IElectricalDevice electricalDevice)
    {
        _electricalDevice = electricalDevice;
    }

    public double ReservedCapacity
    {
        get;
        private set;
    }

    public void ConsumeElectricity(double electricity)
    {
        double electricityToPass = electricity;

        if (electricityToPass > 0)
        {
            ReservedCapacity = Math.Min(ReservedCapacity + electricityToPass, MaxReservedCapacity);
        }
        else if (ReservedCapacity > 0)
        {
            electricityToPass = Math.Min(PassedElectricity, ReservedCapacity);
            ReservedCapacity -= electricityToPass;
        }

        _electricalDevice.ConsumeElectricity(electricityToPass);
    }

    public override string ToString()
    {
        return  $"Ups with reserved capacity {(ReservedCapacity / MaxReservedCapacity) * 100}% and device:\n{_electricalDevice}";
    }
}

