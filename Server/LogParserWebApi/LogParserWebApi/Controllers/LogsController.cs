using System.Threading.Tasks;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Services.LogService;

namespace LogParserWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Logs")]
    public class LogsController : Controller
    {
        /// <summary>
        /// The log service
        /// </summary>
        private readonly ILogService _logService;
        
        public LogsController(ILogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// Gets the top hosts.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/GetHosts")]
        public async Task<IActionResult> GetTopHosts([FromQuery] HostsFilterDto filter)
        {
            return Ok(await _logService.GetTopHosts(filter.Start, filter.End, filter.N));
        }

        /// <summary>
        /// Gets the top routes.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/GetRoutes")]
        public async Task<IActionResult> GetTopRoutes([FromQuery] RoutesFilterDto filter)
        {
            return Ok(await _logService.GetTopRoutes(filter.Start, filter.End, filter.N));
        }

        /// <summary>
        /// Gets the logs.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/GetLogs")]
        public async Task<IActionResult> GetLogs([FromQuery] LogsFilterDto filter)
        {
            return Ok(await _logService.GetLogs(filter.Start, filter.End, filter.Offset, filter.Limit));
        }
    }
}