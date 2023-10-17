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

        public async Task CreateLogMessagesAsync(List<LogMessage> messages)
        {
            await context.LogMessages.AddRangeAsync(messages);
            await context.SaveChangesAsync();
        }

        public async Task<Application> GetApplicationByNameAsync(string name)
        {
            var existingApplication = await context.Applications.FirstOrDefaultAsync(x => x.Name == name);

            return existingApplication;
        }
    }
}
