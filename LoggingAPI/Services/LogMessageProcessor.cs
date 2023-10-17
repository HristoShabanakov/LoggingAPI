using LoggingAPI.Data.Models;
using LoggingAPI.Data.Repository;
using LoggingAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingAPI.Services
{
    public class LogMessageProcessor : ILogMessageProcessor
    {
        private readonly IRepository repository;

        public LogMessageProcessor(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task ProcessLogMessagesAsync(List<CreateLogRequestModel> rawLogRequests)
        {
            var processedMessages = new List<LogMessage>();

            foreach (var rawRequest in rawLogRequests)
            {
                var existingApplication = await repository.GetApplicationByNameAsync(rawRequest.Application);
                int appId;

                if (existingApplication is not null)
                {
                    appId = existingApplication.Id;
                }
                else
                {
                    appId = await repository.CreateApplicationAsync(rawRequest.Application);
                }
                
                var logMessage = new LogMessage
                {
                    ApplicationId = appId,
                    Date = rawRequest.LogDate,
                    Message = ExtractMessage(rawRequest.Message),
                    LogLevel = ExtractLogLevel(rawRequest.Message) 
                };
                processedMessages.Add(logMessage);
            }
            await repository.CreateLogMessagesAsync(processedMessages);
        }

        private static LogLevel ExtractLogLevel(string message)
        {
            var split = message.Split("]", StringSplitOptions.RemoveEmptyEntries);

            if (split.Length == 0)
            {
                return LogLevel.Info;
            }
            var logLevel = split[0].Replace("[",string.Empty).ToLower();

            return logLevel switch
            {
                "error" => LogLevel.Error,
                "trace" => LogLevel.Trace,
                "debug" => LogLevel.Debug,
                "warn" => LogLevel.Warn,
                _ => LogLevel.Info,
            };
        }

        private static string ExtractMessage(string message)
        {
            var split = message.Split("]", StringSplitOptions.RemoveEmptyEntries);

            if (split.Length > 0)
            {
                return split[1].Trim();
            }

            return split[0];
        }
    }
}