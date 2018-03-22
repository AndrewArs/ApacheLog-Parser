using DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class LogContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        public DbSet<Geolocation> Geolocations { get; set; }

        public LogContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
