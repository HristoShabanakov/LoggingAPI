using LoggingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingAPI.Services
{
    public interface ILogMessageProcessor
    {
        Task ProcessLogMessagesAsync(List<CreateLogRequestModel> logMessages);
    }
}
