using Singleton;

// call the property getter twice
//var instance1 = Logger.Instance;
//var instance2 = Logger.Instance;

//if (instance1 == instance2 && instance2 == Logger.Instance)
//{
//    Console.WriteLine("Instances are the same.");
//}

//instance1.Log($"Message from {nameof(instance1)}");
//// or
//instance1.Log($"Message from {nameof(instance2)}");
//// or
//Logger.Instance.Log($"Message from {nameof(Logger.Instance)}");

//var instance1 = ThreadSafeLogger.Instance;
//var instance2 = ThreadSafeLogger.Instance;

//if (instance1 == instance2 && instance2 == ThreadSafeLogger.Instance)
//{
//    Console.WriteLine("Instances are the same.");
//}

//instance1.Log($"Message from {nameof(instance1)}");
//// or
//instance1.Log($"Message from {nameof(instance2)}");
//// or
//Logger.Instance.Log($"Message from {nameof(ThreadSafeLogger.Instance)}");

var instance1 = ThreadSafeLazyLogger.Instance;
var instance2 = ThreadSafeLazyLogger.Instance;

if (instance1 == instance2 && instance2 == ThreadSafeLazyLogger.Instance)
{
    Console.WriteLine("Instances are the same.");
}

instance1.Log($"Message from {nameof(instance1)}");
// or
instance1.Log($"Message from {nameof(instance2)}");
// or
Logger.Instance.Log($"Message from {nameof(ThreadSafeLazyLogger.Instance)}");