using System;

namespace LoggingAPI.Data.Models
{
    public class LogMessage
    {
        public int Id { get; set; }

        public DateTime Date{ get; set; }

        public string Message { get; set; }

        public LogLevel LogLevel { get; set; }

        // Navigation property
        public Application Application { get; set; }

        // Foreign key property
        public int ApplicationId { get; set; }
    }
}
