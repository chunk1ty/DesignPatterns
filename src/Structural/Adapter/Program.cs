﻿using Adapter;

//var laptop = new Laptop();
//var americanLaptop = new AmericanLaptop();

//var americanElectricalAdapter = new AmericanElectricalAdapter(americanLaptop);

//var electricalDevices = new List<IElectricalDevice> { laptop, americanElectricalAdapter };

//foreach (var electricalDevice in electricalDevices)
//{
//    electricalDevice.ConsumeElectricity(100);
//    Console.WriteLine(electricalDevice.ToString());
//}


ICityAdapter adapter = new CityAdapter();
var city = adapter.GetCity();

Console.WriteLine($"{city.FullName}, {city.Inhabitants}");
Console.ReadKey();