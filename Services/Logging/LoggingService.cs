using System;

namespace Services.Logging
{
    public class LoggingService : ILoggingService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}