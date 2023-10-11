using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly LoggingContext _context;

        public LogController(LoggingContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostLogMessage(List<LogMessage> logMessages)
        {
            // Process the log messages, extract log levels, etc.
            // Save to the database
            await _context.LogMessages.AddRangeAsync(logMessages);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}
