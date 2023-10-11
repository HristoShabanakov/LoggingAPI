using Microsoft.EntityFrameworkCore;

namespace LoggingAPI
{
    public class LoggingContext : DbContext
    {
        public DbSet<LogMessage> LogMessages { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Your_Connection_String_Here");
        }
    }

}
