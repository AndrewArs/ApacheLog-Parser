using LogParserWebApi.DAL.Context;
using LogParserWebApi.DomainModels;
using System;
using System.Collections.Generic;

namespace LogParserWebApi.DAL
{
    public class LogRepository : ILogRepository
    {
        private readonly LogContext _logContext;

        public LogRepository()
        {
            _logContext = new LogContext();
        }

        public void Add(Log logUnit)
        {
            return;
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

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _logContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
