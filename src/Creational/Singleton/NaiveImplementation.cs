namespace Singleton;

public sealed class Logger
{
    private static Logger _logger;

    private Logger()
    {
    }

    public static Logger Instance
    {
        get
        {
            if (_logger is null)
            {
                _logger = new Logger();
            }

            return _logger;
        }
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}