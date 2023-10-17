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
        private readonly ILogMessageProcessor _logMessageProcessor;

        public LogController(ILogMessageProcessor logMessageProcessor)
        {
            _logMessageProcessor = logMessageProcessor;
        }
        
        [Route("/Logs/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<CreateLogRequestModel> logMessages)
        {
            if (logMessages == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _logMessageProcessor.ProcessLogMessagesAsync(logMessages);

            return Ok();
        }
    }

}
