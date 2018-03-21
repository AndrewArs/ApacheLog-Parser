using LogParserWebApi.DAL.Context;
using LogParserWebApi.DomainModels;
using System;
using System.Collections.Generic;

namespace LogParserWebApi.DAL
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
            _logContext.SaveChanges();
        }

        public IEnumerable<Log> GetTopHosts(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int n = 10)
        {
            return null;
        }

        public IEnumerable<Log> GetTopRoutes(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int n = 10)
        {
            return null;
        }

        public IEnumerable<Log> GetLogs(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int offset = 0, int limit = 10)
        {
            return null;
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
