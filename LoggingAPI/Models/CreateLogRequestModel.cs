using System;

namespace LoggingAPI.Models
{
    public class CreateLogRequestModel
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public DateTime LogDate { get; set; }
        public string Message { get; set; }
        public string LogLevel { get; set; }
    }
}
