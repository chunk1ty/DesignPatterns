using Decorator;

IElectricalDevice laptop = new Laptop();
var defender = new HighElectricityDefenderDecorator(laptop);

defender.ConsumeElectricity(50);

Console.WriteLine(laptop);