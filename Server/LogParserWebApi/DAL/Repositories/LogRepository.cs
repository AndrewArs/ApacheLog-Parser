using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class LogRepository : ILogRepository
    {
        /// <summary>
        /// The log context
        /// </summary>
        private readonly LogContext _logContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogRepository"/> class.
        /// </summary>
        /// <param name="logContext">The log context.</param>
        public LogRepository(LogContext logContext)
        {
            _logContext = logContext;
        }

        /// <summary>
        /// Adds the specified log unit.
        /// </summary>
        /// <param name="logUnit">The log unit.</param>
        public void Add(Log logUnit)
        {
            _logContext.Logs.Add(logUnit);
        }

        /// <summary>
        /// Gets the top hosts.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetTopHosts(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int n = 10)
        {
            if (start == default(DateTime) && end == default(DateTime))
            {
                return await _logContext.Logs.GroupBy(log => log.Host)
                                             .OrderByDescending(g => g.Count())
                                             .Take(n)
                                             .Select(log => log.Key)
                                             .ToListAsync();
            }
            if (end == default(DateTime))
            {
                return await _logContext.Logs.Where(log => log.Date >= start)
                                             .GroupBy(log => log.Host)
                                             .OrderByDescending(g => g.Count())
                                             .Take(n)
                                             .Select(log => log.Key)
                                             .ToListAsync();
            }
            if (start == default(DateTime))
            {
                return await _logContext.Logs.Where(log => log.Date <= end)
                                             .GroupBy(log => log.Host)
                                             .OrderByDescending(g => g.Count())
                                             .Take(n)
                                             .Select(log => log.Key)
                                             .ToListAsync();
            }

            return await _logContext.Logs.Where(log => log.Date >= start && log.Date <= end)
                                         .GroupBy(log => log.Host)
                                         .OrderByDescending(g => g.Count())
                                         .Take(n)
                                         .Select(log => log.Key)
                                         .ToListAsync();
        }

        /// <summary>
        /// Gets the top routes.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetTopRoutes(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int n = 10)
        {
            if (start == default(DateTime) && end == default(DateTime))
            {
                return await _logContext.Logs.GroupBy(log => log.Route)
                                             .OrderByDescending(g => g.Count())
                                             .Take(n)
                                             .Select(log => log.Key)
                                             .ToListAsync();
            }
            if (end == default(DateTime))
            {
                return await _logContext.Logs.Where(log => log.Date >= start)
                                             .GroupBy(log => log.Route)
                                             .OrderByDescending(g => g.Count())
                                             .Take(n)
                                             .Select(log => log.Key)
                                             .ToListAsync();
            }
            if (start == default(DateTime))
            {
                return await _logContext.Logs.Where(log => log.Date <= end)
                                             .GroupBy(log => log.Route)
                                             .OrderByDescending(g => g.Count())
                                             .Take(n)
                                             .Select(log => log.Key)
                                             .ToListAsync();
            }

            return await _logContext.Logs.Where(log => log.Date >= start && log.Date <= end)
                                         .GroupBy(log => log.Route)
                                         .OrderByDescending(g => g.Count())
                                         .Take(n)
                                         .Select(log => log.Key)
                                         .ToListAsync();
        }

        /// <summary>
        /// Gets the logs.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            _logContext.SaveChanges();
        }

        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
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

        /// <inheritdoc />
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
