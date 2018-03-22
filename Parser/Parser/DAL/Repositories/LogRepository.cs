using DAL.Context;
using DomainModels.Models;

namespace DAL.Repositories
{
    /// <summary>
    /// Log repository
    /// </summary>
    /// <seealso cref="DAL.Repositories.ILogRepository" />
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

        /// <inheritdoc />
        /// <summary>
        /// Adds the specified log.
        /// </summary>
        /// <param name="log">The log.</param>
        public void Add(Log log)
        {
            _logContext.Logs.Add(log);
        }

        /// <inheritdoc />
        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            _logContext.SaveChanges();
        }
    }
}