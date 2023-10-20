using LoggingAPI.Models;
using LoggingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILogMessageProcessor _logMessageProcessor;

        public LogsController(ILogMessageProcessor logMessageProcessor)
        {
            _logMessageProcessor = logMessageProcessor;
        }
        
        [Route("create")]
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
