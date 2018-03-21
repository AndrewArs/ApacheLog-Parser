using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogParserWebApi.DAL.Repositories;
using LogParserWebApi.DomainModels.Models;

namespace LogParserWebApi.Services.Services.LogService
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _parserRepository;

        public LogService(ILogRepository parserRepository)
        {
            _parserRepository = parserRepository;
        }

        public async Task<IEnumerable<Log>> GetLogs(DateTime start, DateTime end, int offset, int limit)
        {
            return await _parserRepository.GetLogs(start, end, offset, limit);
        }

        public async Task<IEnumerable<string>> GetTopHosts(DateTime start, DateTime end, int n)
        {
            return await _parserRepository.GetTopHosts(start, end, n);
        }

        public async Task<IEnumerable<string>> GetTopRoutes(DateTime start, DateTime end, int n)
        {
            return await _parserRepository.GetTopRoutes(start, end, n);
        }
    }
}
