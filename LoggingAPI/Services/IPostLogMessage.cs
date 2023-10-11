using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingAPI.Services
{
    public interface IPostLogMessage
    {
        Task ProcessLogMessagesAsync(List<LogMessage> logMessages);
    }
}
