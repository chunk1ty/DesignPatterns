namespace Singleton;

internal class ThreadSafeLazyLogger
{
    private static Lazy<ThreadSafeLazyLogger> _lazyLogger = new Lazy<ThreadSafeLazyLogger>(() => new ThreadSafeLazyLogger());

    private ThreadSafeLazyLogger()
    {
    }

    public static ThreadSafeLazyLogger Instance => _lazyLogger.Value;

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
