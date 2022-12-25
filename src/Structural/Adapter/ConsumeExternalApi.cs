namespace Adapter;

/// <summary>
/// Adaptee
/// </summary>
public class ExternalSystemApi
{
    public CityFromExternalSystem GetCity()
    {
        return new CityFromExternalSystem("Antwerp", "'t Stad", 500000);
    }
}

public class CityFromExternalSystem
{
    public CityFromExternalSystem(string name, string nickName, int inhabitants)
    {
        Name = name;
        NickName = nickName;
        Inhabitants = inhabitants;
    }

    public string Name { get; }
    public string NickName { get; }
    public int Inhabitants { get; }
}

/// <summary>
/// Target
/// </summary>
public interface ICityAdapter
{
    City GetCity();
}

/// <summary>
/// Adapter
/// </summary>
public class CityAdapter : ExternalSystemApi, ICityAdapter
{
    public City GetCity()
    {
        // call into the external system 
        var cityFromExternalSystem = base.GetCity();

        // adapt the CityFromExternalCity to a City 
        return new City($"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}", 
                        cityFromExternalSystem.Inhabitants);
    }
}

public class City
{
    public City(string fullName, long inhabitants)
    {
        FullName = fullName;
        Inhabitants = inhabitants;
    }

    public string FullName { get; private set; }
    public long Inhabitants { get; private set; }
}
