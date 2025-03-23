using Microsoft.EntityFrameworkCore;
using WorkTimeTracker.Models;

namespace WorkTimeTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<WorkLog> WorkLogs { get; set; }
    }
}