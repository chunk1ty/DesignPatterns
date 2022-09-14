using Builder;

var garage = new Garage();

CarBuilder vwBuilder = new VwBuilder();
CarBuilder bmwBuilder = new BMWBuilder();

garage.Construct(vwBuilder);
garage.Show();

garage.Construct(bmwBuilder);
garage.Show();

Console.ReadKey();