using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DAL.Repositories
{
    public interface ILogRepository : IDisposable
    {
        Task<IEnumerable<string>> GetTopHosts(DateTime? start, DateTime? end, int? n);

        Task<IEnumerable<string>> GetTopRoutes(DateTime? start, DateTime? end, int? n);

        Task<IEnumerable<Log>> GetLogs(DateTime? start, DateTime? end, int? offset, int? limit);
    }
}
