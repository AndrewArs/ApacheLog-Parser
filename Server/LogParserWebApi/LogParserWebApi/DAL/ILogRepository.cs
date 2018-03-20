using System;
using LogParserWebApi.DomainModels;
using System.Collections.Generic;

namespace LogParserWebApi.DAL
{
    public interface ILogRepository : IDisposable
    {
        void Add(Log logUnit);

        IEnumerable<Log> GetTopHosts(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int n = 10);

        IEnumerable<Log> GetTopRoutes(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int n = 10);

        IEnumerable<Log> GetLogs(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int offset = 0, int limit = 10);
    }
}
