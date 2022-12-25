using BuildingManager.Adapters;
using BuildingManager.Contracts;
using BuildingManager.Decorators;
using BuildingManager.ElectricalConsumers;

var laptop = new Laptop();

var americanLaptop = new AmericanLaptop();
var adaptedAmericanLaptop = new AmericanElectricalDeviceAdapter(americanLaptop);

var electricalDevices = new List<IElectricalDevice> { laptop, adaptedAmericanLaptop };

var powerStrip = new PowerStrip(electricalDevices);

var ups = new UpsDecorator(powerStrip);
var defender = new HighElectricityDefenderDecorator(ups);

defender.ConsumeElectricity(20);

Console.WriteLine(defender.ToString());