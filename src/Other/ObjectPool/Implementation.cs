namespace ObjectPool;

/// <summary>
/// The Pool class is the most important class in the object pool design pattern. It controls access to the
/// pooled objects, maintaining a list of available objects and a collection of objects that have already been
/// requested from the pool and are still in use. The pool also ensures that objects that have been released
/// are returned to a suitable state, ready for the next time they are requested.
/// </summary>
/// <typeparam name="T">The pool objects type.</typeparam>
public class Warehouse<T> where T : IDisposable, new()
{
    private readonly List<T> _availableEquipment;
    private readonly List<T> _usedEquipment;

    // We can define the size of the pool in constructor
    public Warehouse()
    {
        _availableEquipment = new List<T>();
        _usedEquipment = new List<T>();
    }

    public T GetEquipment()
    {
        lock (_availableEquipment)
        {
            if (_availableEquipment.Count != 0)
            {
                var equipment = _availableEquipment[0];
                _usedEquipment.Add(equipment);
                _availableEquipment.RemoveAt(0);
                return equipment;
            }
            else
            {
                var equipment = new T();
                _usedEquipment.Add(equipment);
                return equipment;
            }
        }
    }

    public void ReleaseEquipment(T equipment)
    {
        equipment.Dispose();

        lock (_availableEquipment)
        {
            _availableEquipment.Add(equipment);
            _usedEquipment.Remove(equipment);
        }
    }
}

/// <summary>
/// The PooledObject class is the type that is expensive or slow to instantiate, or that has limited availability, so is to be held in the object pool.
/// </summary>
public class Equipment : IDisposable
{
    private readonly DateTime orderedAt = DateTime.Now;

    public DateTime OrderedAt => this.orderedAt;

    public string EmployeeName { get; set; }

    public void Dispose()
    {
        this.EmployeeName = null;
    }
}