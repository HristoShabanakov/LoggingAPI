using System;

namespace LoggingAPI
{
    public class LogMessage
    {
        public DateTime LogDate { get; set; }
        public string ApplicationName { get; set; }
        public string Message { get; set; }
        public string LogLevel { get; set; } = "Info"; // Default log level
    }

}
