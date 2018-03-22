using DomainModels.Models;

namespace DAL.Repositories
{
    public interface ILogRepository
    {
        /// <summary>
        /// Adds the specified log.
        /// </summary>
        /// <param name="log">The log.</param>
        void Add(Log log);

        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
    }
}