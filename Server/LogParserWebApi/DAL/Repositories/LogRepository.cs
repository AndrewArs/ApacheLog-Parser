using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        /// Gets the top hosts.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetTopHosts(DateTime? start, DateTime? end, int? n)
        {
            return await _logContext.Logs.Where(CreateDateExpression(start, end))
                                         .GroupBy(log => log.Host)
                                         .OrderByDescending(g => g.Count())
                                         .Take(n.Value)
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
        public async Task<IEnumerable<string>> GetTopRoutes(DateTime? start, DateTime? end, int? n)
        {
            return await _logContext.Logs.Where(CreateDateExpression(start, end))
                                         .GroupBy(log => log.Route)
                                         .OrderByDescending(g => g.Count())
                                         .Take(n.Value)
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
        public async Task<IEnumerable<Log>> GetLogs(DateTime? start, DateTime? end, int? offset, int? limit)
        {
            return await _logContext.Logs.Where(CreateDateExpression(start, end))
                                         .OrderBy(log => log.Date)
                                         .Skip(offset.Value)
                                         .Take(limit.Value)
                                         .ToListAsync();
        }
        
        private Expression<Func<Log, bool>> CreateDateExpression(DateTime? start, DateTime? end)
        {
            if(start.HasValue && end.HasValue)
            {
                return log => log.Date >= start && log.Date <= end;
            }
            else if(start.HasValue)
            {
                return log => log.Date >= start;
            }
            else if (end.HasValue)
            {
                return log => log.Date <= end;
            }
            else
            {
                return log => true;
            }
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
