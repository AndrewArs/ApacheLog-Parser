using LogParserWebApi.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace LogParserWebApi.DAL.Context
{
    public class LogContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        
        public LogContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Log>().HasIndex(l => l.Id);
        }
    }
}
