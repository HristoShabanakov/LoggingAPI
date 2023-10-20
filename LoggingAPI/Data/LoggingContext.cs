using LoggingAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LoggingAPI.Data
{
    public class LoggingContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<LogMessage> LogMessages { get; set; }

        public LoggingContext(DbContextOptions<LoggingContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString:
               "Server=postgres_database;Port=5432;User Id=user;Password=password;Database=logs_db;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the enum mapping for LogLevel
            modelBuilder.Entity<LogMessage>()
                .Property(e => e.LogLevel)
                .HasConversion<string>();

            // Configure the relationship between Application and LogMessage
            modelBuilder.Entity<LogMessage>()
                .HasOne(l => l.Application)
                .WithMany(a => a.LogMessages)
                .HasForeignKey(l => l.ApplicationId);

            // Configure the index for Application name
            modelBuilder.Entity<Application>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Application>()
                .Property(a => a.Name)
                .IsRequired();

            modelBuilder.Entity<Application>()
                .HasIndex(a => a.Name)
                .IsUnique();
        }
    }
}










