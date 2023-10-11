using Microsoft.EntityFrameworkCore;

namespace LoggingAPI
{
    public class DbContext
    {
        public DbSet<LogMessage> LogMessages { get; set; }
        public DbSet<Application> Applications { get; set; }
    }
}
