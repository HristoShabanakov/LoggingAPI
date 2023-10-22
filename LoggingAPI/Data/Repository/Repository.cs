using LoggingAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingAPI.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly LoggingContext context;

        public Repository(LoggingContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Asynchronously creates a new application entity.
        /// </summary>
        /// <param name="name">The name of the application.</param>
        /// <returns>The ID of the created application entity.</returns>
        public async Task<int> CreateApplicationAsync(string name)
        {
            var application = new Application
            {
                Name = name
            };
            await context.Applications.AddAsync(application);
            await context.SaveChangesAsync();
            return application.Id;
        }
        /// <summary>
        /// Asynchronously creates new log message entities.
        /// </summary>
        /// <param name="messages">The log messages to create.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task CreateLogMessagesAsync(List<LogMessage> messages)
        {
            await context.LogMessages.AddRangeAsync(messages);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Asynchronously retrieves an application entity by its name.
        /// </summary>
        /// <param name="name">The name of the application to retrieve.</param>
        /// <returns>The application entity, or null if not found.</returns>
        public async Task<Application> GetApplicationByNameAsync(string name)
        {
            var existingApplication = await context.Applications.FirstOrDefaultAsync(x => x.Name == name);

            return existingApplication;
        }
    }
}
