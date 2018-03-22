using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DAL.Repositories
{
    public interface ILogRepository : IDisposable
    {
        void Add(Log logUnit);

        Task<IEnumerable<string>> GetTopHosts(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int n = 10);

        Task<IEnumerable<string>> GetTopRoutes(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int n = 10);

        Task<IEnumerable<Log>> GetLogs(DateTime start = default(DateTime),
            DateTime end = default(DateTime), int offset = 0, int limit = 10);

        void SaveChanges();
    }
}
