using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogParserWebApi.DAL.Context;
using LogParserWebApi.DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace LogParserWebApi.DAL.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly LogContext _logContext;

        public LogRepository(LogContext logContext)
        {
            _logContext = logContext;
        }

        public void Add(Log logUnit)
        {
            _logContext.Add(logUnit);
        }

        public async Task<IEnumerable<string>> GetTopHosts(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int n = 10)
        {
            if (start == default(DateTime) && end == default(DateTime))
            {
                return await _logContext.Logs.GroupBy(log => log.Host)
                                             .Take(n)
                                             .Select(log => log.Key)
                                             .ToListAsync();
            }
            if (end == default(DateTime))
            {
                return await _logContext.Logs.Where(log => log.Date >= start)
                                             .GroupBy(log => log.Host)
                                             .Take(n)
                                             .Select(log => log.Key)
                                             .ToListAsync();
            }
            if (start == default(DateTime))
            {
                return await _logContext.Logs.Where(log => log.Date <= end)
                                             .GroupBy(log => log.Host)
                                             .Take(n)
                                             .Select(log => log.Key)
                                             .ToListAsync();
            }

            return await _logContext.Logs.Where(log => log.Date >= start && log.Date <= end)
                                         .GroupBy(log => log.Host)
                                         .Take(n)
                                         .Select(log => log.Key)
                                         .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetTopRoutes(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int n = 10)
        {
            if (start == default(DateTime) && end == default(DateTime))
            {
                return await _logContext.Logs.GroupBy(log => log.Route)
                                             .Take(n)
                                             .Select(log => log.Key)
                                             .ToListAsync();
            }
            if (end == default(DateTime))
            {
                return await _logContext.Logs.Where(log => log.Date >= start)
                                             .GroupBy(log => log.Route)
                                             .Take(n)
                                             .Select(log => log.Key)
                                             .ToListAsync();
            }
            if (start == default(DateTime))
            {
                return await _logContext.Logs.Where(log => log.Date <= end)
                                             .GroupBy(log => log.Route)
                                             .Take(n)
                                             .Select(log => log.Key)
                                             .ToListAsync();
            }

            return await _logContext.Logs.Where(log => log.Date >= start && log.Date <= end)
                                         .GroupBy(log => log.Route)
                                         .Take(n)
                                         .Select(log => log.Key)
                                         .ToListAsync();
        }

        public async Task<IEnumerable<Log>> GetLogs(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int offset = 0, int limit = 10)
        {
            if (start == default(DateTime) && end == default(DateTime))
            {
                return await _logContext.Logs.OrderBy(log => log.Date)
                                             .Skip(offset)
                                             .Take(limit)
                                             .ToListAsync();
            }
            if (end == default(DateTime))
            {
                return await _logContext.Logs.Where(log => log.Date >= start)
                                             .OrderBy(log => log.Date)
                                             .Skip(offset)
                                             .Take(limit)
                                             .ToListAsync();
            }
            if (start == default(DateTime))
            {
                return await _logContext.Logs.Where(log => log.Date <= end)
                                             .OrderBy(log => log.Date)
                                             .Skip(offset)
                                             .Take(limit)
                                             .ToListAsync();
            }

            return await _logContext.Logs.Where(log => log.Date >= start && log.Date <= end)
                                         .OrderBy(log => log.Date)
                                         .Skip(offset)
                                         .Take(limit)
                                         .ToListAsync();
        }

        public void SaveChanges()
        {
            _logContext.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _logContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
