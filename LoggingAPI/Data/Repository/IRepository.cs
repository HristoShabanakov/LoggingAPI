using LoggingAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingAPI.Data.Repository
{
    public interface IRepository
    {
        Task<Application> GetApplicationByNameAsync(string name);

        Task<int> CreateApplicationAsync(string name);

        Task CreateLogMessagesAsync (List<LogMessage> messages);
    }
}
