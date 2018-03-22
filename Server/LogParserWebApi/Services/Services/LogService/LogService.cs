using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Repositories;
using DomainModels.Models;

namespace Services.Services.LogService
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _parserRepository;

        public LogService(ILogRepository parserRepository)
        {
            _parserRepository = parserRepository;
        }

        /// <summary>
        /// Gets the logs.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Log>> GetLogs(DateTime start, DateTime end, int offset, int limit)
        {
            return await _parserRepository.GetLogs(start, end, offset, limit);
        }

        /// <summary>
        /// Gets the top hosts.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="n">The number.</param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetTopHosts(DateTime start, DateTime end, int n)
        {
            return await _parserRepository.GetTopHosts(start, end, n);
        }

        /// <summary>
        /// Gets the top routes.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="n">The number.</param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetTopRoutes(DateTime start, DateTime end, int n)
        {
            return await _parserRepository.GetTopRoutes(start, end, n);
        }
    }
}
