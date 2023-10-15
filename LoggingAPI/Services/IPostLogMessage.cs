using LoggingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingAPI.Services
{
    public interface IPostLogMessage
    {
        List<CreateLogRequestModel> ProcessLogMessages(List<CreateLogRequestModel> logMessages);
    }
}
