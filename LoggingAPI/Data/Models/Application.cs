using System.Collections.Generic;

namespace LoggingAPI.Data.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public List<LogMessage> LogMessages { get; set; }
    }
}
