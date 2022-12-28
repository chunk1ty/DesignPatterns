using Newtonsoft.Json;

namespace Prototype;

/// <summary>
/// Prototype abstract class
/// </summary>
public abstract class Person
{
    public abstract string Name { get; set; }

    public abstract Person Clone(bool deepClone);
}

/// <summary>
/// ConcretePrototype1
/// </summary>
public class Manager : Person
{
    public override string Name { get; set; }

    public Manager(string name)
    {
        Name = name;
    }

    public override Person Clone(bool deepClone = false)
    {
        // Options of cloning in .NET (http://stackoverflow.com/a/966534/1862812)
        // Clone Manually - Tedious, but high level of control
        // Clone with MemberwiseClone - Fastest but only creates a shallow copy, i.e. for reference-type fields the original object and it's clone refer to the same object.
        // Clone with Reflection - Shallow copy by default, can be re-written to do deep copy. Advantage: automated. Disadvantage: reflection is slow.
        // Clone with Serialization - Easy, automated. Give up some control and serialization is slowest of all.
        if (deepClone)
        {
            var objectAsJson = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Person>(objectAsJson);
        }

        return (Person)MemberwiseClone();
    }
}

/// <summary>
/// ConcretePrototype1
/// </summary>
public class Employee : Person
{
    public Manager Manager { get; set; }
    public override string Name { get; set; }

    public Employee(string name, Manager manager)
    {
        Name = name;
        Manager = manager;
    }

    public override Person Clone(bool deepClone = false)
    {
        if (deepClone)
        {
            var objectAsJson = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Employee>(objectAsJson);
        }


        return (Person)MemberwiseClone();
    }
}
