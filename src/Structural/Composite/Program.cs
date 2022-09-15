using Decorator;

var laptop = new Laptop();
var powerStrip = new PowerStrip(new List<IElectricalDevice>() {laptop});

powerStrip.ConsumeElectricity(100);