using LoggingAPI.Data.Models;
using LoggingAPI.Models;
using LoggingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly IPostLogMessage _logMessageProcessor;

        public LogController(IPostLogMessage logMessageProcessor)
        {
            _logMessageProcessor = logMessageProcessor;
        }
        
        [Route("/Logs/create")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] List<CreateLogRequestModel> logMessages)
        {
            if (logMessages == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var processedMessages = _logMessageProcessor.ProcessLogMessages(logMessages);
            return Ok(processedMessages);
        }
    }

}
