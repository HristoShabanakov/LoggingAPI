using System;

namespace LoggingAPI.Models
{
    public class CreateLogRequestModel
    {
        public string Application { get; set; }
        public DateTime LogDate { get; set; }
        public string Message { get; set; }
    }
}
