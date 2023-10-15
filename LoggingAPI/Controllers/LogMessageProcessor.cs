using LoggingAPI.Data;
using LoggingAPI.Data.Models;
using LoggingAPI.Models;
using LoggingAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingAPI.Controllers
{
    public class LogMessageProcessor : IPostLogMessage
    {
        private readonly LoggingContext _context;

        public LogMessageProcessor(LoggingContext context)
        {
            _context = context;
        }

        public List<CreateLogRequestModel> ProcessLogMessages(List<CreateLogRequestModel> rawLogRequests)
        {
            var processedMessages = new List<CreateLogRequestModel>();
            var allowedLogLevels = new HashSet<string> { "Trace", "Debug", "Info", "Warn", "Error" };

            foreach (var rawRequest in rawLogRequests)
            {
                var logMessage = new CreateLogRequestModel
                {
                    Id = rawRequest.Id,
                    ApplicationName = rawRequest.ApplicationName,
                    LogDate = rawRequest.LogDate
                };

                if (rawRequest.Message.StartsWith("["))
                {
                    var endIndex = rawRequest.Message.IndexOf("]");
                    if (endIndex > 0)
                    {
                        var potentialLogLevel = rawRequest.Message.Substring(1, endIndex - 1).Trim();
                        if (allowedLogLevels.Contains(potentialLogLevel))
                        {
                            logMessage.LogLevel = potentialLogLevel;
                            logMessage.Message = rawRequest.Message.Substring(endIndex + 1).Trim();
                        }
                        else
                        {
                            logMessage.LogLevel = "Info";
                            logMessage.Message = rawRequest.Message.Substring(endIndex + 1).Trim();
                        }
                    }
                    else
                    {
                        logMessage.LogLevel = "Info";
                        logMessage.Message = rawRequest.Message.Trim();
                    }
                }
                else
                {
                    logMessage.LogLevel = "Info";
                    logMessage.Message = rawRequest.Message.Trim();
                }

                processedMessages.Add(logMessage);
            }

            return processedMessages;
        }
        // Save to the database
        // await _context.LogMessages.AddRangeAsync((IEnumerable<Data.Models.LogMessage>)logMessages);
        // await _context.SaveChangesAsync();
    }
}