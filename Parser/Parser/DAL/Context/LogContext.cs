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

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DAL.Context.LogContext" /> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public LogContext(DbContextOptions options) : base(options)
        {
        }
    }
}
