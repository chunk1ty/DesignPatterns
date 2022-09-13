namespace Singleton;

internal class ThreadSafeLogger
{
    private static ThreadSafeLogger _logger;
    private static object _lock = new object();

    private ThreadSafeLogger()
    {
    }

    public static ThreadSafeLogger Instance
    {
        get
        {
            // Ensure that the instance hasn't yet been
            // initialized by another thread while this one
            // has been waiting for the lock's release.
            if (_logger is null)
            {
                lock (_lock)
                {
                    if (_logger is null)
                    {
                        _logger = new ThreadSafeLogger();
                    }
                }
            }
            return _logger;
        }
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
