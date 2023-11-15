using Microsoft.EntityFrameworkCore;
using WebAPILogging.Entities;

namespace WebAPIProvaProgettoFinale.DataSource
{
    public class LoggingDBContext:DbContext
    {
        public LoggingDBContext() {}
        public LoggingDBContext(DbContextOptions<LoggingDBContext> options)
        : base(options) {}
        public DbSet<Logs> Logs { get; set; }
    }
}
