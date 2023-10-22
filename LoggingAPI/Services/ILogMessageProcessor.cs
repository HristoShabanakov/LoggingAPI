using LoggingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingAPI.Services
{
    public interface ILogMessageProcessor
    {
        /// <summary>
        /// Asynchronously processes a list of raw log requests, extracts relevant log information, and saves them to the database.
        /// </summary>
        /// <param name="rawLogRequests">The list of raw log requests to process.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        Task ProcessLogMessagesAsync(List<CreateLogRequestModel> logMessages);
    }
}
