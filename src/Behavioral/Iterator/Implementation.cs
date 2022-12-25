﻿namespace Iterator;
  
/// <summary>
/// Iterator
/// </summary>
public interface IPeopleIterator 
{
    Person First();
    Person Next();
    bool IsDone { get; }
    Person CurrentItem { get; }
}

/// <summary>
/// ConcreteIterator
/// </summary>
public class PeopleIterator : IPeopleIterator
{
    private readonly PeopleCollection _peopleCollection;
    private int _current = 0; 
     
    public PeopleIterator(PeopleCollection collection)
    {
        _peopleCollection = collection;
    } 

    public Person First()
    {
        _current = 0;
        return _peopleCollection.OrderBy(p => p.Name).ToList()[_current];
    }

    public Person Next()
    {
        _current++;
        if (!IsDone)
        {                
            return _peopleCollection
                .OrderBy(p => p.Name).ToList()[_current];   
        }

        return null;
    }

    public bool IsDone => _current >= _peopleCollection.Count;

    public Person CurrentItem => _peopleCollection.OrderBy(p => p.Name).ToList()[_current];
}

/// <summary>
/// Aggregate
/// </summary>
public interface IPeopleCollection  
{
    IPeopleIterator CreateIterator();
}

/// <summary>
/// ConcreteAggregate
/// </summary>
public class PeopleCollection : List<Person>, IPeopleCollection
{
    public IPeopleIterator CreateIterator()
    {
        return new PeopleIterator(this);
    } 
}

public class Person
{
    public Person(string name, string country)
    {
        Name = name; 
        Country = country;
    }
    
    public string Name { get; } 
    
    public string Country { get; }
}
