using DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class LogContext : DbContext
    {
        /// <summary>
        /// Gets or sets the logs.
        /// </summary>
        /// <value>
        /// The logs.
        /// </value>
        public DbSet<Log> Logs { get; set; }

        public LogContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
